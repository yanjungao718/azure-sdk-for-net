﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    public partial class SubscriptionPolicies
    {
        internal static SubscriptionPolicies DeserializeSubscriptionPolicies(JsonElement element)
        {
            Optional<string> locationPlacementId = default;
            Optional<string> quotaId = default;
            Optional<SpendingLimit> spendingLimit = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("locationPlacementId"))
                {
                    locationPlacementId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("quotaId"))
                {
                    quotaId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("spendingLimit"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    spendingLimit = property.Value.GetString().ToSpendingLimit();
                    continue;
                }
            }
            return new SubscriptionPolicies(locationPlacementId.Value, quotaId.Value, Optional.ToNullable(spendingLimit));
        }
    }
}
