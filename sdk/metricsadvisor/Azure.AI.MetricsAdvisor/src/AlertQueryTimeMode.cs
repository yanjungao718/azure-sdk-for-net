// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Specifies which time property of an <see cref="AnomalyAlert"/> will be used to filter results
    /// in the <see cref="MetricsAdvisorClient.GetAlerts"/> and the <see cref="MetricsAdvisorClient.GetAlertsAsync"/>
    /// operations.
    /// </summary>
    [CodeGenModel("TimeMode")]
    public enum AlertQueryTimeMode
    {
        /// <summary>
        /// </summary>
        AnomalyTime,
        /// <summary>
        /// </summary>
        CreatedTime,
        /// <summary>
        /// </summary>
        ModifiedTime
    }
}
