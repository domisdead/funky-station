// SPDX-FileCopyrightText: 2023 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 blueDev2 <89804215+blueDev2@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using Content.Server.Station.Systems;

namespace Content.Server.Cargo.Components;

/// <summary>
/// This is used for marking containers as
/// containing goods for fulfilling bounties.
/// </summary>
[RegisterComponent]
public sealed partial class CargoBountyLabelComponent : Component
{
    /// <summary>
    /// The ID for the bounty this label corresponds to.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public string Id = string.Empty;

    /// <summary>
    /// Used to prevent recursion in calculating the price.
    /// </summary>
    public bool Calculating;

    /// <summary>
    /// The Station System to check and remove bounties from
    /// </summary>
    [DataField]
    public EntityUid? AssociatedStationId;
}
