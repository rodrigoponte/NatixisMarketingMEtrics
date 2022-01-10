namespace MarketingMetrics.DTOs
{
    using System;

    /// <summary>
    /// Defines the <see cref="VisitorAccessLog" />.
    /// </summary>
    public class VisitorAccessLog
    {
        /// <summary>
        /// Gets or sets the VisitorId.
        /// </summary>
        public string VisitorId { get; set; }

        /// <summary>
        /// Gets or sets the UrlPage.
        /// </summary>
        public string UrlPage { get; set; }

        /// <summary>
        /// Gets or sets the AccessMoment.
        /// </summary>
        public DateTime AccessMoment { get; set; }
    }
}
