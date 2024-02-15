using Microsoft.Extensions.Logging;
using Xunit;
using Controllers;
using Models;

namespace HotelAPI.Tests.Controller
{
    public class HotelAPIControllerTest
    {
        private HotelAPIController oHotelAPIController = 
        new HotelAPIController(new Logger<HotelAPIController>(new LoggerFactory()));

        [Fact]
        public void Get_For_Wrong_Country_Returns_An_Error_Message()
        {
            Assert.Throws<System.ArgumentException>(() => oHotelAPIController.Get("Z"));
        }

        [Fact]
        public void Get_For_Each_ISO_Country_Returns_Right_Results()
        {
            foreach (var country in Utils.Contstants.Constants.UrlConstants.SEMBO_COUNTRIES)
            {
                Country oCountryResponse = (Country)oHotelAPIController.Get(country.ToUpper());
                Assert.Equal(country.ToUpper(), oCountryResponse.isoCountryId);
                Assert.Equal(3, oCountryResponse.oHotelList.Length);
                Assert.NotNull(oCountryResponse.average);
            }
        }
    }
}
