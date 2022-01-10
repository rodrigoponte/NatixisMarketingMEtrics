namespace MarketingMetrics.DTOs
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="VisitorPageRequest" />.
    /// </summary>
    public class VisitorPageRequest
    {
        /// <summary>
        /// Gets or sets the VisitorId.
        /// </summary>
        [Required]
        public string VisitorId { get; set; }

        /// <summary>
        /// Gets or sets the UrlPage.
        /// </summary>
        [Required]
        public string UrlPage { get; set; }
    }
}
