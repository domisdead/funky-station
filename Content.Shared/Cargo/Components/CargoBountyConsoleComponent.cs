// SPDX-FileCopyrightText: 2023 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Killerqu00 <47712032+Killerqu00@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 Tay <td12233a@gmail.com>
// SPDX-FileCopyrightText: 2025 slarticodefast <161409025+slarticodefast@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using Robust.Shared.Audio;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Shared.Cargo.Components;

[RegisterComponent]
public sealed partial class CargoBountyConsoleComponent : Component
{
    /// <summary>
    /// The id of the label entity spawned by the print label button.
    /// </summary>
    [DataField("bountyLabelId", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
    public string BountyLabelId = "PaperCargoBountyManifest";

    /// <summary>
    /// The time at which the console will be able to print a label again.
    /// </summary>
    [DataField("nextPrintTime", customTypeSerializer: typeof(TimeOffsetSerializer))]
    public TimeSpan NextPrintTime = TimeSpan.Zero;

    /// <summary>
    /// The time between prints.
    /// </summary>
    [DataField("printDelay")]
    public TimeSpan PrintDelay = TimeSpan.FromSeconds(5);

    /// <summary>
    /// The sound made when printing occurs
    /// </summary>
    [DataField("printSound")]
    public SoundSpecifier PrintSound = new SoundPathSpecifier("/Audio/Machines/printer.ogg");

    /// <summary>
    /// The sound made when the bounty is skipped.
    /// </summary>
    [DataField("skipSound")]
    public SoundSpecifier SkipSound = new SoundPathSpecifier("/Audio/Effects/Cargo/ping.ogg");

    /// <summary>
    /// The sound made when bounty skipping is denied due to lacking access.
    /// </summary>
    [DataField("denySound")]
    public SoundSpecifier DenySound = new SoundPathSpecifier("/Audio/Effects/Cargo/buzz_two.ogg");
}

[NetSerializable, Serializable]
public sealed class CargoBountyConsoleState : BoundUserInterfaceState
{
    public List<CargoBountyData> Bounties;
    public List<CargoBountyHistoryData> History;
    public TimeSpan UntilNextSkip;

    public CargoBountyConsoleState(List<CargoBountyData> bounties, List<CargoBountyHistoryData> history, TimeSpan untilNextSkip)
    {
        Bounties = bounties;
        History = history;
        UntilNextSkip = untilNextSkip;
    }
}

[Serializable, NetSerializable]
public sealed class BountyPrintLabelMessage : BoundUserInterfaceMessage
{
    public string BountyId;

    public BountyPrintLabelMessage(string bountyId)
    {
        BountyId = bountyId;
    }
}

[Serializable, NetSerializable]
public sealed class BountySkipMessage : BoundUserInterfaceMessage
{
    public string BountyId;

    public BountySkipMessage(string bountyId)
    {
        BountyId = bountyId;
    }
}
