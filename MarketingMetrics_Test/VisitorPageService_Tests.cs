using MarketingMetrics.DTOs;
using MarketingMetrics.Services.Interfaces;
using Moq;
using Xunit;

namespace MarketingMetrics_Test
{
    public class VisitorPageService_Tests
    {
        private readonly Mock<IPageService> _mock;

        public VisitorPageService_Tests()
        {
            _mock = new Mock<IPageService>();
        }

        [Fact]
        public void SaveVisitorPage_OK()
        {
            _mock.Setup(x => x.SaveVisitorPage(It.IsAny<VisitorPageRequest>())).Returns(true);

            Assert.True(_mock.Object.SaveVisitorPage(GeneratedRequestValueValid()));
        }

        [Fact]
        public void SaveVisitorPage_InvalidData()
        {
            _mock.Setup(x => x.SaveVisitorPage(It.IsAny<VisitorPageRequest>())).Returns(false);

            Assert.False(_mock.Object.SaveVisitorPage(GeneratedRequestValueFailed()));
        }

        [Fact]
        public void GetDistinctVisitorsPage_OK()
        {
            _mock.Setup(x => x.GetDistinctVisitorsPage(It.IsAny<string>())).Returns(GeneratedResponseValue());

            Assert.Equal("exemplo.com.br", _mock.Object.GetDistinctVisitorsPage("exemplo.com.br").UrlPage);
            Assert.Equal(0, _mock.Object.GetDistinctVisitorsPage("exemplo.com.br").NumberVisitors);
        }

        [Fact]
        public void GetDistinctVisitorsPage_InvalidParameter()
        {
            _mock.Setup(x => x.GetDistinctVisitorsPage(It.IsAny<string>())).Returns((VisitorPageResponse)null);

            Assert.Null(_mock.Object.GetDistinctVisitorsPage(string.Empty));
        }

        public VisitorPageRequest GeneratedRequestValueValid()
        {
            return new VisitorPageRequest()
            {
                VisitorId = "abcdef",
                UrlPage = "exemplo.com.br"
            };
        }

        public VisitorPageRequest GeneratedRequestValueFailed()
        {
            return new VisitorPageRequest()
            {
                VisitorId = null,
                UrlPage = "exemplo.com.br"
            };
        }

        public VisitorPageResponse GeneratedResponseValue()
        {
            return new VisitorPageResponse()
            {
                UrlPage = "exemplo.com.br",
                NumberVisitors = 0
            };
        }
    }
}
