using Xunit;
using Models;
using DataServer;

namespace HotelAPI.Tests.DataServerTest
{
    public class CountryDataCacheTest
    {
        private IGetCountryData oGetCountryData = CountryDataCache.GetInstance(new DataConsumer.HotelAPIDataConsumer());
        private readonly string ISO_CODE = "ES";

        [Fact]
        public void Get_Data_For_A_Country_Returns_Data()
        {
            object oCountryObject; 
            oGetCountryData.IGetCountryData(ISO_CODE, out oCountryObject);
            Assert.NotNull(oCountryObject);
        }

        [Fact]
        public void GetData_For_A_Country_Returns_A_Country_Object()
        {
            object oCountryObject; 
            oGetCountryData.IGetCountryData(ISO_CODE, out oCountryObject);
            Assert.IsType<Country>(oCountryObject);
        }

        [Fact]
        public void GetData_For_A_Country_Returns_A_Country_Object_With_Same_ISO_Country()
        {
            object oCountryObject; 
            oGetCountryData.IGetCountryData(ISO_CODE, out oCountryObject);
            Country oCountry = (Country) oCountryObject;
            Assert.True(oCountry.isoCountryId == ISO_CODE);
        }

        [Fact]
        public void GetData_For_A_Country_Returns_A_CountryObject_With_Top_Three()
        {
            object oCountryObject; 
            oGetCountryData.IGetCountryData(ISO_CODE, out oCountryObject);
            Country oCountry = (Country) oCountryObject;
            Assert.Equal(oCountry.oHotelList.Length, 3);
        }

        [Fact]
        public void GetData_For_A_Country_Returns_A_Country_Object_With_Not_Null_Avg()
        {
            object oCountryObject; 
            oGetCountryData.IGetCountryData(ISO_CODE, out oCountryObject);
            Country oCountry = (Country) oCountryObject;
            Assert.NotNull(oCountry.average);
        }

        [Fact]
        public void GetData_For_Each_Country_Returns_A_Country_Object_With_Same_ISO_Country_Code()
        {
            foreach (var country in Utils.Contstants.Constants.UrlConstants.SEMBO_COUNTRIES)
            {
                object oCountryObject; 
                oGetCountryData.IGetCountryData(country.ToUpper(), out oCountryObject);
                Country oCountry = (Country) oCountryObject;
                Assert.Equal(oCountry.isoCountryId, country.ToUpper());
            }
        }

        [Fact]
        public void GetData_For_A_Not_Country_Returns_A_String_Error()
        {
            object oCountryObject; 
            oGetCountryData.IGetCountryData("ZZ", out oCountryObject);
            Assert.IsType<string>(oCountryObject);
        }

    }
}
