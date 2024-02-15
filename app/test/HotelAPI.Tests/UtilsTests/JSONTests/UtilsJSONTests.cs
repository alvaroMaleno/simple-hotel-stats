using System.Collections.Generic;
using Xunit;
using Utils.JSON;
using Models;

namespace HotelAPI.Tests.UtilsTests.JSONTests
{
    public class JSONTests
    {
        private UtilsJSON oUtilsJSON = new UtilsJSON();
        private string exampleUrl = 
        Utils.Contstants.Constants.UrlConstants.SEMBO_END_POINT.Replace(
            "?", 
            Utils.Contstants.Constants.UrlConstants.SEMBO_COUNTRIES[0]);

        [Fact]
        public void GetFromUrl_Gets_UnserializedResponse()
        {
            for(int i = 0; i < 10; i++){
                List<Hotel> oHotels;
                try
                {
                    oUtilsJSON.IGetJsonHttp<List<Hotel>>(out oHotels, exampleUrl, new Dictionary<string, string>());
                }
                catch (System.Exception)
                {
                    continue;
                }
                Assert.NotNull(oHotels); 
                Assert.True(oHotels.Count > 0); 
                break;
            }
        }

        [Fact]
        public void GetFromUrl_Gets_Catch_503_Error()
        {
            for(int i = 0; i < 10; i++){
                List<Hotel> oHotels;
                try
                {
                    oUtilsJSON.IGetJsonHttp<List<Hotel>>(out oHotels, exampleUrl, new Dictionary<string, string>());
                }
                catch (System.Exception oException)
                {
                    Assert.True(oException.Message.Contains("503"));
                    break;
                }
            }
        }
    }
}
