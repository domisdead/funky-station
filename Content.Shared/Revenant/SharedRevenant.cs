// SPDX-FileCopyrightText: 2023 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 Leon Friedrich <60421075+ElectroJr@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 V <97265903+formlessnameless@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 corresp0nd <46357632+corresp0nd@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using Content.Shared.Actions;
using Content.Shared.DoAfter;
using Robust.Shared.Serialization;

namespace Content.Shared.Revenant;

[Serializable, NetSerializable]
public sealed partial class SoulEvent : SimpleDoAfterEvent
{
}

public sealed class SoulSearchDoAfterComplete : EntityEventArgs
{
    public readonly EntityUid Target;

    public SoulSearchDoAfterComplete(EntityUid target)
    {
        Target = target;
    }
}

public sealed class SoulSearchDoAfterCancelled : EntityEventArgs
{
}

[Serializable, NetSerializable]
public sealed partial class HarvestEvent : SimpleDoAfterEvent
{
}

public sealed class HarvestDoAfterComplete : EntityEventArgs
{
    public readonly EntityUid Target;

    public HarvestDoAfterComplete(EntityUid target)
    {
        Target = target;
    }
}

public sealed class HarvestDoAfterCancelled : EntityEventArgs
{
}

public sealed partial class RevenantShopActionEvent : InstantActionEvent
{
}

public sealed partial class RevenantDefileActionEvent : InstantActionEvent
{
}

public sealed partial class RevenantOverloadLightsActionEvent : InstantActionEvent
{
}

public sealed partial class RevenantBlightActionEvent : InstantActionEvent
{
}

public sealed partial class RevenantMalfunctionActionEvent : InstantActionEvent
{
}

public sealed partial class RevenantBloodWritingEvent : InstantActionEvent // imp
{
}


[NetSerializable, Serializable]
public enum RevenantVisuals : byte
{
    Corporeal,
    Stunned,
    Harvesting,
}

[NetSerializable, Serializable]
public enum RevenantVisualLayers : byte
{
    Digit1,
    Digit2,
    Digit3
}
