// SPDX-FileCopyrightText: 2024 Piras314 <p1r4s@proton.me>
// SPDX-FileCopyrightText: 2024 Tadeo <td12233a@gmail.com>
// SPDX-FileCopyrightText: 2024 username <113782077+whateverusername0@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later AND MIT

using Robust.Shared.Prototypes;

namespace Content.Shared.Heretic.Prototypes;

[ImplicitDataDefinitionForInheritors]
public abstract partial class RitualCustomBehavior
{
    /// <param name="outstr">Output string in case something is missing</param>
    /// <returns>If the behavior was successful or not</returns>
    public abstract bool Execute(RitualData args, out string? outstr);

    /// <summary>
    ///     If the ritual is successful do *this*.
    /// </summary>
    /// <param name="args"></param>
    public abstract void Finalize(RitualData args);
}

public readonly record struct RitualData(EntityUid Performer, EntityUid Platform, ProtoId<HereticRitualPrototype> RitualId, IEntityManager EntityManager);
