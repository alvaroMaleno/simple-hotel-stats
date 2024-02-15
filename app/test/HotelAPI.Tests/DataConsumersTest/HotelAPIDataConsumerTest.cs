using System.Collections.Generic;
using Xunit;
using Models;
using DataConsumer;

namespace HotelAPI.Tests.UtilsTests.HotelAPIDataConsumerTest
{
    public class HotelAPIDataConsumerTest
    {
        private HotelAPIDataConsumer oHotelAPIDataConsumer = new HotelAPIDataConsumer();

        [Fact]
        public void GetFromUrl_Gets_Non_Empty_Dictionary()
        {
            Dictionary<string, List<Hotel>> oCountriesKeyHotelListDictionary = new Dictionary<string, List<Hotel>>();
            oHotelAPIDataConsumer.IConsumeDataFromExternalAPI(oCountriesKeyHotelListDictionary);
            Assert.True(oCountriesKeyHotelListDictionary.Values.Count > 0);
        }

        [Fact]
        public void GetFromUrl_Gets_The_Expected_Number_Of_Results()
        {
            Dictionary<string, List<Hotel>> oCountriesKeyHotelListDictionary = new Dictionary<string, List<Hotel>>();
            oHotelAPIDataConsumer.IConsumeDataFromExternalAPI(oCountriesKeyHotelListDictionary);
            Assert.Equal(
                oCountriesKeyHotelListDictionary.Values.Count, Utils.Contstants.Constants.UrlConstants.SEMBO_COUNTRIES.Length);
        }

    }
}
