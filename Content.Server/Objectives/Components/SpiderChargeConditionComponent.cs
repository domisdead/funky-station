// SPDX-FileCopyrightText: 2023 Slava0135 <40753025+Slava0135@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 deltanedas <@deltanedas:kde.org>
// SPDX-FileCopyrightText: 2024 Vyacheslav Kovalevsky <40753025+Slava0135@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 deltanedas <39013340+deltanedas@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using Content.Server.Ninja.Systems;
using Content.Server.Objectives.Systems;

namespace Content.Server.Objectives.Components;

/// <summary>
/// Requires that the player is a ninja and blew up their spider charge at its target location.
/// </summary>
[RegisterComponent, Access(typeof(NinjaConditionsSystem), typeof(SpiderChargeSystem), typeof(SpaceNinjaSystem))]
public sealed partial class SpiderChargeConditionComponent : Component
{
    /// <summary>
    /// Warp point that the spider charge has to target
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public EntityUid? Target;
}
