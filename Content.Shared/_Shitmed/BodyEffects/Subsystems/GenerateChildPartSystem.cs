// SPDX-FileCopyrightText: 2024 BombasterDS <115770678+BombasterDS@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Tadeo <td12233a@gmail.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later AND MIT

using Content.Shared.Body.Part;
using Content.Shared.Body.Systems;
using Content.Shared._Shitmed.Body.Events;
using Robust.Shared.Map;
using Robust.Shared.Timing;
using Robust.Shared.Network;
using System.Numerics;

namespace Content.Shared._Shitmed.BodyEffects.Subsystems;

public sealed class GenerateChildPartSystem : EntitySystem
{
    [Dependency] private readonly SharedBodySystem _bodySystem = default!;
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly INetManager _net = default!;
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<GenerateChildPartComponent, BodyPartComponentsModifyEvent>(OnPartComponentsModify);
    }

    private void OnPartComponentsModify(EntityUid uid, GenerateChildPartComponent component, ref BodyPartComponentsModifyEvent args)
    {
        if (args.Add)
            CreatePart(uid, component);
        //else
            //DeletePart(uid, component);
    }

    private void CreatePart(EntityUid uid, GenerateChildPartComponent component)
    {
        if (!TryComp(uid, out BodyPartComponent? partComp)
            || partComp.Body is null
            || component.Active)
            return;

        // I pinky swear to also move this to the server side properly next update :)
        if (_net.IsServer)
        {
            var childPart = Spawn(component.Id, new EntityCoordinates(partComp.Body.Value, Vector2.Zero));

            if (!TryComp(childPart, out BodyPartComponent? childPartComp))
                return;

            var slotName = _bodySystem.GetSlotFromBodyPart(childPartComp);
            _bodySystem.TryCreatePartSlot(uid, slotName, childPartComp.PartType, out var _);
            _bodySystem.AttachPart(uid, slotName, childPart, partComp, childPartComp);
            component.ChildPart = childPart;
            component.Active = true;
            Dirty(childPart, childPartComp);
        }
    }

    // Still unusued, gotta figure out what I want to do with this function outside of fuckery with mantis blades.
    private void DeletePart(EntityUid uid, GenerateChildPartComponent component)
    {
        if (!TryComp(uid, out BodyPartComponent? partComp))
            return;

        _bodySystem.DropSlotContents((uid, partComp));
        var ev = new BodyPartDroppedEvent((uid, partComp));
        RaiseLocalEvent(uid, ref ev);
        QueueDel(uid);
    }
}

