// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary> <see cref="MetricFeedback"/>s are used to describe feedback on unsatisfactory anomaly detection results.
    /// When feedback is created for a given metric, it is applied to future anomaly detection processing of the same series.
    /// The processed points will not be re-calculated. </summary>
    [CodeGenModel("MetricFeedback")]
    public abstract partial class MetricFeedback : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of the <see cref="MetricFeedback"/> class. </summary>
        /// <param name="metricId"> The metric unique Id. </param>
        /// <param name="dimensionFilter"> The <see cref="GetAllFeedbackFilter" /> to apply to the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> is null. </exception>
        internal MetricFeedback(string metricId, GetAllFeedbackFilter dimensionFilter)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(dimensionFilter, nameof(dimensionFilter));

            MetricId = metricId;
            DimensionKey = new DimensionKey(dimensionFilter.Dimension);
        }

        internal MetricFeedback(string metricId, DimensionKey dimensionKey)
        {
            MetricId = metricId;
            DimensionKey = dimensionKey;
        }

        /// <summary> Initializes a new instance of MetricFeedback. </summary>
        /// <param name="type"> feedback type. </param>
        /// <param name="id"> feedback unique id. </param>
        /// <param name="createdTime"> feedback created time. </param>
        /// <param name="userPrincipal"> user who gives this feedback. </param>
        /// <param name="metricId"> metric unique id. </param>
        /// <param name="dimensionFilter"> . </param>
        internal MetricFeedback(MetricFeedbackKind type, string id, DateTimeOffset? createdTime, string userPrincipal, string metricId, GetAllFeedbackFilter dimensionFilter)
        {
            Kind = type;
            Id = id;
            CreatedTime = createdTime;
            UserPrincipal = userPrincipal;
            MetricId = metricId;
            DimensionKey = new DimensionKey(dimensionFilter.Dimension);
        }

        /// <summary> The <see cref="MetricFeedbackKind"/> of this feedback.</summary>
        [CodeGenMember("FeedbackType")]
        public MetricFeedbackKind Kind { get; internal set; }

        /// <summary> feedback unique id. </summary>
        [CodeGenMember("FeedbackId")]
        public string Id { get; }

        /// <summary> feedback created time. </summary>
        public DateTimeOffset? CreatedTime { get; }

        /// <summary> user who gives this feedback. </summary>
        public string UserPrincipal { get; }

        /// <summary> metric unique id. </summary>
        public string MetricId { get; }

        /// <summary>
        /// </summary>
        public DimensionKey DimensionKey { get; }

        /// <summary> The dimension filter. </summary>
        internal GetAllFeedbackFilter DimensionFilter => new GetAllFeedbackFilter(DimensionKey.Dimension);

        internal static MetricFeedback DeserializeMetricFeedback(JsonElement element)
        {
            if (element.TryGetProperty("feedbackType", out JsonElement discriminator))
            {
                var discriminatorString = discriminator.GetString();

                switch (discriminatorString)
                {
                    case "Anomaly":
                        return MetricAnomalyFeedback.DeserializeMetricAnomalyFeedback(element);
                    case "ChangePoint":
                        return MetricChangePointFeedback.DeserializeMetricChangePointFeedback(element);
                    case "Comment":
                        return MetricCommentFeedback.DeserializeMetricCommentFeedback(element);
                    case "Period":
                        return MetricPeriodFeedback.DeserializeMetricPeriodFeedback(element);
                    default:
                        throw new ArgumentException($"Unknown feedback type returned by the service: {discriminatorString}");
                }
            }
            else
            {
                throw new ArgumentException("The feedback type was not returned by the service");
            }
        }
    }
}
