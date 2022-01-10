namespace MarketingMetrics.Services.Implementation
{
    using MarketingMetrics.DTOs;
    using MarketingMetrics.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="PageService" />.
    /// </summary>
    public class PageService : IPageService
    {
        /// <summary>
        /// Gets or sets the _acessos.
        /// </summary>
        private readonly IList<VisitorAccessLog> _acessos;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageService"/> class.
        /// </summary>
        public PageService()
        {
            _acessos = new List<VisitorAccessLog>();
        }

        /// <summary>
        /// The SaveVisitorPage.
        /// </summary>
        /// <param name="visitor">The visitor<see cref="VisitorPageRequest"/>.</param>
        public void SaveVisitorPage(VisitorPageRequest visitor)
        {
            if (string.IsNullOrEmpty(visitor.UrlPage) || string.IsNullOrEmpty(visitor.VisitorId))
                throw new ArgumentNullException();

            _acessos.Add(new VisitorAccessLog() { VisitorId = visitor.VisitorId, UrlPage = visitor.UrlPage, AccessMoment = DateTime.Now });
        }

        /// <summary>
        /// The GetDistinctVisitorsPage.
        /// </summary>
        /// <param name="UrlPage">The UrlPage<see cref="string"/>.</param>
        /// <returns>The <see cref="VisitorPageResponse"/>.</returns>
        public VisitorPageResponse GetDistinctVisitorsPage(string UrlPage)
        {
            if (string.IsNullOrEmpty(UrlPage))
                throw new ArgumentNullException();

            int visitors = _acessos.Where(w => w.UrlPage == UrlPage).Select(s => s.VisitorId).Distinct().Count();

            return new VisitorPageResponse() { UrlPage = UrlPage, NumberVisitors = visitors };
        }
    }
}
