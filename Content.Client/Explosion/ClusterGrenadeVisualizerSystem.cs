// SPDX-FileCopyrightText: 2023 TemporalOroboros <TemporalOroboros@gmail.com>
// SPDX-FileCopyrightText: 2024 Aexxie <codyfox.077@gmail.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using Content.Shared.Explosion;
using Content.Shared.Explosion.Components;
using Robust.Client.GameObjects;

namespace Content.Client.Explosion;

public sealed class ClusterGrenadeVisualizerSystem : VisualizerSystem<ClusterGrenadeVisualsComponent>
{
    protected override void OnAppearanceChange(EntityUid uid, ClusterGrenadeVisualsComponent comp, ref AppearanceChangeEvent args)
    {
        if (args.Sprite == null)
            return;

        if (AppearanceSystem.TryGetData<int>(uid, ClusterGrenadeVisuals.GrenadesCounter, out var grenadesCounter, args.Component))
            args.Sprite.LayerSetState(0, $"{comp.State}-{grenadesCounter}");
    }
}
