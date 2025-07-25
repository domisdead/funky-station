// SPDX-FileCopyrightText: 2021 Pieter-Jan Briers <pieterjan.briers+git@gmail.com>
// SPDX-FileCopyrightText: 2022 Leon Friedrich <60421075+ElectroJr@users.noreply.github.com>
// SPDX-FileCopyrightText: 2022 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2022 mirrorcult <lunarautomaton6@gmail.com>
// SPDX-FileCopyrightText: 2022 wrexbe <81056464+wrexbe@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 PJBot <pieterjan.briers+bot@gmail.com>
// SPDX-FileCopyrightText: 2024 Tadeo <td12233a@gmail.com>
// SPDX-FileCopyrightText: 2024 Tayrtahn <tayrtahn@gmail.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

namespace Content.Shared.Emoting;

public sealed class EmoteSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<EmoteAttemptEvent>(OnEmoteAttempt);
    }

    public void SetEmoting(EntityUid uid, bool value, EmotingComponent? component = null)
    {
        if (value && !Resolve(uid, ref component))
            return;

        component = EnsureComp<EmotingComponent>(uid);

        if (component.Enabled == value)
            return;

        Dirty(uid, component);
    }

    private void OnEmoteAttempt(EmoteAttemptEvent args)
    {
        if (!TryComp(args.Uid, out EmotingComponent? emote) || !emote.Enabled)
            args.Cancel();
    }
}
