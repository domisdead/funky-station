// SPDX-FileCopyrightText: 2024 Tornado Tech <54727692+Tornado-Technology@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using System.Threading;
using System.Threading.Tasks;
using Robust.Shared.Random;

namespace Content.Server.NPC.HTN.PrimitiveTasks.Operators.Math;

/// <summary>
/// Set random float value between <see cref="SetRandomFloatOperator.MinAmount"/> and
/// <see cref="SetRandomFloatOperator.MaxAmount"/> specified <see cref="SetRandomFloatOperator.TargetKey"/>
/// in the <see cref="NPCBlackboard"/>.
/// </summary>
public sealed partial class SetRandomFloatOperator : HTNOperator
{
    [Dependency] private readonly IRobustRandom _random = default!;

    [DataField(required: true), ViewVariables]
    public string TargetKey = string.Empty;

    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float MaxAmount = 1f;

    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float MinAmount;

    public override async Task<(bool Valid, Dictionary<string, object>? Effects)> Plan(NPCBlackboard blackboard,
        CancellationToken cancelToken)
    {
        return (
            true,
            new Dictionary<string, object>
            {
                { TargetKey, _random.NextFloat(MinAmount, MaxAmount) }
            }
        );
    }
}
