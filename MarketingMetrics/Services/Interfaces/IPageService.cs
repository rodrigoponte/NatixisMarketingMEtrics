namespace MarketingMetrics.Services.Interfaces
{
    using MarketingMetrics.DTOs;

    /// <summary>
    /// Defines the <see cref="IPageService" />.
    /// </summary>
    public interface IPageService
    {
        /// <summary>
        /// The SaveVisitorPage.
        /// </summary>
        /// <param name="visitor">The visitor<see cref="VisitorPageRequest"/>.</param>
        bool SaveVisitorPage(VisitorPageRequest visitor);

        /// <summary>
        /// The GetDistinctVisitorsPage.
        /// </summary>
        /// <param name="UrlPage">The UrlPage<see cref="string"/>.</param>
        /// <returns>The <see cref="VisitorPageResponse"/>.</returns>
        VisitorPageResponse GetDistinctVisitorsPage(string UrlPage);
    }
}
