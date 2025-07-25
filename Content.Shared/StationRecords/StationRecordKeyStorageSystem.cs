// SPDX-FileCopyrightText: 2022 Flipp Syder <76629141+vulppine@users.noreply.github.com>
// SPDX-FileCopyrightText: 2022 metalgearsloth <comedian_vs_clown@hotmail.com>
// SPDX-FileCopyrightText: 2023 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 metalgearsloth <31366439+metalgearsloth@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Tayrtahn <tayrtahn@gmail.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using Robust.Shared.GameStates;

namespace Content.Shared.StationRecords;

public sealed class StationRecordKeyStorageSystem : EntitySystem
{
    [Dependency] private readonly SharedStationRecordsSystem _records = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<StationRecordKeyStorageComponent, ComponentGetState>(OnGetState);
        SubscribeLocalEvent<StationRecordKeyStorageComponent, ComponentHandleState>(OnHandleState);
    }

    private void OnGetState(EntityUid uid, StationRecordKeyStorageComponent component, ref ComponentGetState args)
    {
        args.State = new StationRecordKeyStorageComponentState(_records.Convert(component.Key));
    }

    private void OnHandleState(EntityUid uid, StationRecordKeyStorageComponent component, ref ComponentHandleState args)
    {
        if (args.Current is not StationRecordKeyStorageComponentState state)
            return;
        component.Key = _records.Convert(state.Key);
    }

    /// <summary>
    ///     Assigns a station record key to an entity.
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="key"></param>
    /// <param name="keyStorage"></param>
    public void AssignKey(EntityUid uid, StationRecordKey key, StationRecordKeyStorageComponent? keyStorage = null)
    {
        if (!Resolve(uid, ref keyStorage))
        {
            return;
        }

        keyStorage.Key = key;
        Dirty(uid, keyStorage);
    }

    /// <summary>
    ///     Removes a station record key from an entity.
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="keyStorage"></param>
    /// <returns></returns>
    public StationRecordKey? RemoveKey(EntityUid uid, StationRecordKeyStorageComponent? keyStorage = null)
    {
        if (!Resolve(uid, ref keyStorage) || keyStorage.Key == null)
        {
            return null;
        }

        var key = keyStorage.Key;
        keyStorage.Key = null;
        Dirty(uid, keyStorage);

        return key;
    }

    /// <summary>
    ///     Checks if an entity currently contains a station record key.
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="keyStorage"></param>
    /// <returns></returns>
    public bool CheckKey(EntityUid uid, StationRecordKeyStorageComponent? keyStorage = null)
    {
        if (!Resolve(uid, ref keyStorage))
        {
            return false;
        }

        return keyStorage.Key != null;
    }
}
