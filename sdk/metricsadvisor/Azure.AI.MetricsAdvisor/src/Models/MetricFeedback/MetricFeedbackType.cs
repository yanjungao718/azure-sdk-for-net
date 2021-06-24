// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The <see cref="MetricFeedbackType"/>. See each specific type for a description of each. </summary>
    [CodeGenModel("FeedbackType")]
    public readonly partial struct MetricFeedbackType : IEquatable<MetricFeedbackType>
    {
        /// <summary>
        /// Indicates that the point was incorrectly labeled by the service.
        /// You can specify whether a point should or shouldn't be an anomaly.
        /// </summary>
        public static MetricFeedbackType Anomaly { get; } = new MetricFeedbackType(AnomalyValue);

        /// <summary>
        /// Indicates that this is the start of a trend change.
        /// </summary>
        public static MetricFeedbackType ChangePoint { get; } = new MetricFeedbackType(ChangePointValue);

        /// <summary>
        /// Indicates that this is an interval of seasonality.
        /// </summary>
        public static MetricFeedbackType Period { get; } = new MetricFeedbackType(PeriodValue);

        /// <summary>
        /// A comment describing the reason this point is or is not an anomaly.
        /// </summary>
        public static MetricFeedbackType Comment { get; } = new MetricFeedbackType(CommentValue);
    }
}
