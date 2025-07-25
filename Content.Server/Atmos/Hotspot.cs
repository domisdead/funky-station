// SPDX-FileCopyrightText: 2020 Metal Gear Sloth <metalgearsloth@gmail.com>
// SPDX-FileCopyrightText: 2020 Víctor Aguilera Puerto <6766154+Zumorica@users.noreply.github.com>
// SPDX-FileCopyrightText: 2020 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2021 Vera Aguilera Puerto <gradientvera@outlook.com>
// SPDX-FileCopyrightText: 2022 wrexbe <81056464+wrexbe@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

namespace Content.Server.Atmos
{
    public struct Hotspot
    {
        [ViewVariables]
        public bool Valid;

        [ViewVariables]
        public bool SkippedFirstProcess;

        [ViewVariables]
        public bool Bypassing;

        [ViewVariables]
        public float Temperature;

        [ViewVariables]
        public float Volume;

        /// <summary>
        ///     State for the fire sprite.
        /// </summary>
        [ViewVariables]
        public byte State;
    }
}
