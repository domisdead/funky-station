// SPDX-FileCopyrightText: 2023 Emisse <99158783+Emisse@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 Kevin Zheng <kevinz5000@gmail.com>
// SPDX-FileCopyrightText: 2023 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 TemporalOroboros <TemporalOroboros@gmail.com>
// SPDX-FileCopyrightText: 2025 Tay <td12233a@gmail.com>
// SPDX-FileCopyrightText: 2025 slarticodefast <161409025+slarticodefast@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using Content.Server.Atmos.Piping.Unary.EntitySystems;
using Content.Shared.Chemistry.Components;

namespace Content.Server.Atmos.Piping.Unary.Components;

/// <summary>
/// Used for an entity that converts moles of gas into units of reagent.
/// </summary>
[RegisterComponent]
[Access(typeof(GasCondenserSystem))]
public sealed partial class GasCondenserComponent : Component
{
    /// <summary>
    /// The ID for the pipe node.
    /// </summary>
    [DataField]
    public string Inlet = "pipe";

    /// <summary>
    /// The ID for the solution.
    /// </summary>
    [DataField]
    public string SolutionId = "tank";

    /// <summary>
    /// The solution that gases are condensed into.
    /// </summary>
    [ViewVariables]
    public Entity<SolutionComponent>? Solution = null;

    /// <summary>
    /// For a condenser, how many U of reagents are given per each mole of gas.
    /// </summary>
    /// <remarks>
    /// Derived from a standard of 500u per canister:
    /// 400u / 1871.71051 moles per canister
    /// </remarks>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float MolesToReagentMultiplier = 0.2137f;
}
