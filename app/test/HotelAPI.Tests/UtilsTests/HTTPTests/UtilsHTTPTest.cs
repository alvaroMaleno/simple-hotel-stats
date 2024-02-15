using System.Collections.Generic;
using Xunit;
using Utils.HTTP;

namespace HotelAPI.Tests.UtilsTests.HTTPTests
{
    public class HTTP
    {
        private UtilsHTTP oUtilsHTTP = new UtilsHTTP();
        private string exampleUrl = "https://www.google.com/";

        [Fact]
        public void GetFromUrl_Gets_Response()
        {
            Assert.NotNull(oUtilsHTTP.GetFromUrl(exampleUrl, new Dictionary<string, string>()));
        }

        [Fact]
        public void GetFromUrl_Gets_Not_Empty_Response()
        {
            Assert.NotEmpty(oUtilsHTTP.GetFromUrl(exampleUrl, new Dictionary<string, string>()));
        }
    }
}
