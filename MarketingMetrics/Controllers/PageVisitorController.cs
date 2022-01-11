namespace MarketingMetrics.Controllers
{
    using MarketingMetrics.DTOs;
    using MarketingMetrics.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="PageVisitorController" />.
    /// </summary>
    [Route("v1/[controller]")]
    [ApiController]
    public class PageVisitorController : ControllerBase
    {
        /// <summary>
        /// Defines the _service.
        /// </summary>
        private readonly IPageService _service;

        /// <summary>
        /// Defines the _logger.
        /// </summary>
        private readonly ILogger<PageVisitorController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageVisitorController"/> class.
        /// </summary>
        /// <param name="service">The service<see cref="IPageService"/>.</param>
        /// <param name="logger">The logger<see cref="ILogger{PageVisitorController}"/>.</param>
        public PageVisitorController(IPageService service,
                                     ILogger<PageVisitorController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// The GetDistinctVisitorsPage.
        /// </summary>
        /// <param name="UrlPage">The UrlPage<see cref="string"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet("GetDistinctVisitorsPage")]
        [ProducesResponseType(typeof(VisitorPageResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetDistinctVisitorsPage([Required][FromQuery] string UrlPage)
        {
            try
            {
                var result = _service.GetDistinctVisitorsPage(UrlPage);
                if(result != null)
                    return Ok(result);
                else
                    return BadRequest("A url must be specified in the search.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, "An unexpected error has occurred.");
            }
        }

        /// <summary>
        /// The SaveVisitorPage.
        /// </summary>
        /// <param name="visitor">The visitor<see cref="VisitorPageRequest"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPost("SaveVisitorPage")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult SaveVisitorPage([FromBody] VisitorPageRequest visitor)
        {
            try
            {
                if(_service.SaveVisitorPage(visitor))
                    return Ok();
                else
                    return BadRequest("Data provided is invalid.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode((int)HttpStatusCode.InternalServerError, "An unexpected error has occurred.");
            }
        }
    }
}
