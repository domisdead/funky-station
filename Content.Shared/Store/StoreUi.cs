// SPDX-FileCopyrightText: 2022 Leon Friedrich <60421075+ElectroJr@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 deltanedas <39013340+deltanedas@users.noreply.github.com>
// SPDX-FileCopyrightText: 2023 deltanedas <@deltanedas:kde.org>
// SPDX-FileCopyrightText: 2024 Fildrance <fildrance@gmail.com>
// SPDX-FileCopyrightText: 2024 Nemanja <98561806+EmoGarbage404@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 Piras314 <p1r4s@proton.me>
// SPDX-FileCopyrightText: 2024 keronshb <54602815+keronshb@users.noreply.github.com>
// SPDX-FileCopyrightText: 2024 username <113782077+whateverusername0@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: MIT

using Content.Shared.FixedPoint;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization;

namespace Content.Shared.Store;

[Serializable, NetSerializable]
public enum StoreUiKey : byte
{
    Key
}

[Serializable, NetSerializable]
public sealed class StoreUpdateState : BoundUserInterfaceState
{
    public readonly HashSet<ListingData> Listings;

    public readonly Dictionary<ProtoId<CurrencyPrototype>, FixedPoint2> Balance;

    public readonly bool ShowFooter;

    public readonly bool AllowRefund;

    public StoreUpdateState(HashSet<ListingData> listings, Dictionary<ProtoId<CurrencyPrototype>, FixedPoint2> balance, bool showFooter, bool allowRefund)
    {
        Listings = listings;
        Balance = balance;
        ShowFooter = showFooter;
        AllowRefund = allowRefund;
    }
}

[Serializable, NetSerializable]
public sealed class StoreRequestUpdateInterfaceMessage : BoundUserInterfaceMessage
{

}

[Serializable, NetSerializable]
public sealed class StoreBuyListingMessage : BoundUserInterfaceMessage
{
    public ListingData Listing;

    public StoreBuyListingMessage(ListingData listing)
    {
        Listing = listing;
    }
}

[Serializable, NetSerializable]
public sealed class StoreRequestWithdrawMessage : BoundUserInterfaceMessage
{
    public string Currency;

    public int Amount;

    public StoreRequestWithdrawMessage(string currency, int amount)
    {
        Currency = currency;
        Amount = amount;
    }
}

/// <summary>
///     Used when the refund button is pressed
/// </summary>
[Serializable, NetSerializable]
public sealed class StoreRequestRefundMessage : BoundUserInterfaceMessage
{

}
