// SPDX-FileCopyrightText: 2024 Piras314 <p1r4s@proton.me>
// SPDX-FileCopyrightText: 2024 Tadeo <td12233a@gmail.com>
// SPDX-FileCopyrightText: 2024 username <113782077+whateverusername0@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 Drywink <43855731+Drywink@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later AND MIT

using Content.Shared.Heretic.Prototypes;

namespace Content.Client.Heretic;

// these do nothing and are there just for yaml limter to shut the fuck up.
// make sure they stay up in sync with the server counterpart.
// regards.
// - john

public sealed partial class RitualAshAscendBehavior : RitualSacrificeBehavior { }
public sealed partial class RitualMuteGhoulifyBehavior : RitualSacrificeBehavior { }
public sealed partial class RitualAscensionBehavior : RitualSacrificeBehavior { }

[Virtual] public partial class RitualSacrificeBehavior : RitualCustomBehavior
{
    public override bool Execute(RitualData args, out string? outstr)
    {
        outstr = null;
        return true;
    }

    public override void Finalize(RitualData args)
    {
        // do nothing
    }
}

public sealed partial class RitualTemperatureBehavior : RitualCustomBehavior
{
    public override bool Execute(RitualData args, out string? outstr)
    {
        outstr = null;
        return true;
    }

    public override void Finalize(RitualData args)
    {
        // do nothing
    }
}

public sealed partial class RitualReagentPuddleBehavior : RitualCustomBehavior
{
    public override bool Execute(RitualData args, out string? outstr)
    {
        outstr = null;
        return true;
    }

    public override void Finalize(RitualData args)
    {
        // do nothing
    }
}

public sealed partial class RitualKnowledgeBehavior : RitualCustomBehavior
{
    public override bool Execute(RitualData args, out string? outstr)
    {
        outstr = null;
        return true;
    }

    public override void Finalize(RitualData args)
    {
        // do nothing
    }
}
