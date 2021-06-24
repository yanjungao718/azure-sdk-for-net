// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Filters the result of feedback-related operations.
    /// </summary>
    [CodeGenModel("FeedbackDimensionFilter")]
    public partial class GetAllFeedbackFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllFeedbackFilter"/> class.
        /// </summary>
        public GetAllFeedbackFilter()
        {
        }

        /// <summary> Initializes a new instance of FeedbackDimensionFilter. </summary>
        /// <param name="dimension"> metric dimension filter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimension"/> is null. </exception>
        internal GetAllFeedbackFilter(IDictionary<string, string> dimension)
        {
            if (dimension == null)
            {
                throw new ArgumentNullException(nameof(dimension));
            }

            Dimension = dimension;
        }

        /// <summary>
        /// Filters the result by series. Only feedbacks for the series in the time series group specified will
        /// be returned.
        /// </summary>
        public DimensionKey DimensionKey { get; set; }

        /// <summary>
        /// Filters the result by <see cref="MetricFeedback.Kind"/>.
        /// </summary>
        public MetricFeedbackKind? FeedbackKind { get; set; }

        /// <summary>
        /// Filters the result under the chosen <see cref="TimeMode"/>. Only results from this point in time,
        /// in UTC, will be returned.
        /// </summary>
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Filters the result under the chosen <see cref="TimeMode"/>. Only results up to this point in time,
        /// in UTC, will be returned.
        /// </summary>
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// Specifies to which time property of a <see cref="MetricFeedback"/> the filters <see cref="StartTime"/>
        /// and <see cref="EndTime"/> will be applied.
        /// </summary>
        public FeedbackQueryTimeMode? TimeMode { get; set; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal IDictionary<string, string> Dimension
        {
            get => DimensionKey?.Dimension ?? new Dictionary<string, string>();
            set => DimensionKey = new DimensionKey(value);
        }
    }
}
