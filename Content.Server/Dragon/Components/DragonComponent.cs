// SPDX-FileCopyrightText: 2022 CrudeWax <75271456+CrudeWax@users.noreply.github.com>
// SPDX-FileCopyrightText: 2022 Leon Friedrich <60421075+ElectroJr@users.noreply.github.com>
// SPDX-FileCopyrightText: 2022 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2022 metalgearsloth <metalgearsloth@gmail.com>
// SPDX-FileCopyrightText: 2022 mirrorcult <lunarautomaton6@gmail.com>
// SPDX-FileCopyrightText: 2023 DrSmugleaf <DrSmugleaf@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 DrSmugleaf <drsmugleaf@gmail.com>
// SPDX-FileCopyrightText: 2023 PilgrimViis <PilgrimViis@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 Visne <39844191+Visne@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 keronshb <54602815+keronshb@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 deltanedas <39013340+deltanedas@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using Content.Shared.NPC.Prototypes;
using Robust.Shared.Audio;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

namespace Content.Server.Dragon
{
    [RegisterComponent]
    public sealed partial class DragonComponent : Component
    {

        /// <summary>
        /// If we have active rifts.
        /// </summary>
        [DataField("rifts")]
        public List<EntityUid> Rifts = new();

        public bool Weakened => WeakenedAccumulator > 0f;

        /// <summary>
        /// When any rift is destroyed how long is the dragon weakened for
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite), DataField("weakenedDuration")]
        public float WeakenedDuration = 120f;

        /// <summary>
        /// Has a rift been destroyed and the dragon in a temporary weakened state?
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite), DataField("weakenedAccumulator")]
        public float WeakenedAccumulator = 0f;

        [ViewVariables(VVAccess.ReadWrite), DataField("riftAccumulator")]
        public float RiftAccumulator = 0f;

        /// <summary>
        /// Maximum time the dragon can go without spawning a rift before they die.
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite), DataField("maxAccumulator")] public float RiftMaxAccumulator = 300f;

        [DataField("spawnRiftAction", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
        public string SpawnRiftAction = "ActionSpawnRift";

        /// <summary>
        /// Spawns a rift which can summon more mobs.
        /// </summary>
        [DataField("spawnRiftActionEntity")]
        public EntityUid? SpawnRiftActionEntity;

        [ViewVariables(VVAccess.ReadWrite), DataField("riftPrototype", customTypeSerializer: typeof(PrototypeIdSerializer<EntityPrototype>))]
        public string RiftPrototype = "CarpRift";

        [ViewVariables(VVAccess.ReadWrite), DataField("soundDeath")]
        public SoundSpecifier? SoundDeath = new SoundPathSpecifier("/Audio/Animals/space_dragon_roar.ogg");

        [ViewVariables(VVAccess.ReadWrite), DataField("soundRoar")]
        public SoundSpecifier? SoundRoar =
            new SoundPathSpecifier("/Audio/Animals/space_dragon_roar.ogg")
            {
                Params = AudioParams.Default.WithVolume(3f),
            };

        /// <summary>
        /// NPC faction to re-add after being zombified.
        /// Prevents zombie dragon from being attacked by its own carp.
        /// </summary>
        [DataField]
        public ProtoId<NpcFactionPrototype> Faction = "Dragon";
    }
}
