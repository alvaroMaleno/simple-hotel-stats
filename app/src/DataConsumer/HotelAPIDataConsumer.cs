using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Utils.JSON;
using Models;

namespace DataConsumer
{
    public class HotelAPIDataConsumer : IDataConsumer
    {
        private IGetJsonHttp oGetJsonHttp = new UtilsJSON();
        private ConcurrentDictionary<string, List<Hotel>> oCountryHotelsDictionary;
        private Dictionary<string, string> oHeaders;

        public HotelAPIDataConsumer(){
            oHeaders = new Dictionary<string, string>();
            this.oHeaders.Add(
                Utils.Contstants.Constants.HeaderConstants.HEADER, 
                Utils.Contstants.Constants.HeaderConstants.VALUE);
            oCountryHotelsDictionary = new ConcurrentDictionary<string, List<Hotel>>();
        }

        public async void IConsumeDataFromExternalAPI(Dictionary<string, List<Hotel>> pCountriesKeyHotelListDictionary){
            List<Task> oTaskList = new List<Task>();
            foreach (var country in Utils.Contstants.Constants.UrlConstants.SEMBO_COUNTRIES)
                oTaskList.Add(this.GetDataFromUrl(country));

            foreach (var oTask in oTaskList)
                await oTask;

            foreach (var keyValue in oCountryHotelsDictionary)
                pCountriesKeyHotelListDictionary.Add(keyValue.Key, keyValue.Value);
        }

        private async Task GetDataFromUrl(string country)
        {
            List<Hotel> oHotelList;
            for(int i = 0; i <= Utils.Contstants.Constants.NumericConstants.MAX_NUMBER_OF_RETRIES; i++)
            {
                try
                {
                    oGetJsonHttp.IGetJsonHttp<List<Hotel>>(
                    out oHotelList, 
                    Utils.Contstants.Constants.UrlConstants.SEMBO_END_POINT.Replace("?", country), 
                    this.oHeaders);
                }
                catch (System.Exception)
                {
                    continue;
                }
                this.oCountryHotelsDictionary.TryAdd(oHotelList[0].isoCountryId, oHotelList);
                break;
            }
            System.GC.Collect();
        }
    }
}