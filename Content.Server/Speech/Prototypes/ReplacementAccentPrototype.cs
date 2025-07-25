// SPDX-FileCopyrightText: 2025 Tay <td12233a@gmail.com>
// SPDX-FileCopyrightText: 2025 slarticodefast <161409025+slarticodefast@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using Robust.Shared.Prototypes;

namespace Content.Server.Speech.Prototypes;

[Prototype("accent")]
public sealed partial class ReplacementAccentPrototype : IPrototype
{
    /// <inheritdoc/>
    [ViewVariables]
    [IdDataField]
    public string ID { get; private set; } = default!;

    /// <summary>
    ///     If this array is non-null, the full text of anything said will be randomly replaced with one of these words.
    /// </summary>
    [DataField]
    public string[]? FullReplacements;

    /// <summary>
    ///     If this dictionary is non-null and <see cref="FullReplacements"/> is null, any keys surrounded by spaces
    ///     (words) will be replaced by the value, attempting to intelligently keep capitalization.
    /// </summary>
    [DataField]
    public Dictionary<string, string>? WordReplacements;

    /// <summary>
    /// Allows you to substitute words, not always, but with some chance
    /// </summary>
    [DataField]
    public float ReplacementChance = 1f;
}
