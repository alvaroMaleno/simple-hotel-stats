using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using DataConsumer;
using Models;
using System;

namespace DataServer
{
    public class CountryDataCache : IGetCountryData
    {
        private static IGetCountryData _instance;
        private ConcurrentDictionary<string, Country> oCountryISOKyeCountryValue;

        public static IGetCountryData GetInstance(IDataConsumer pDataConsumer)
        {
            if (_instance is null)
            {
                _instance = new CountryDataCache(pDataConsumer);
            }
            return _instance;
        }

        private CountryDataCache(IDataConsumer pDataConsumer)
        {
            oCountryISOKyeCountryValue = new ConcurrentDictionary<string, Country>();
            new HotelInfoManager(pDataConsumer,
                                 oCountryISOKyeCountryValue).CompleteData();
        }

        public void IGetCountryData(string pCountry, out object pCountryData)
        {
            if (this.oCountryISOKyeCountryValue.ContainsKey(pCountry))
                pCountryData = this.oCountryISOKyeCountryValue[pCountry];
            else
                pCountryData = Utils.Contstants.Constants.ErrorConstants.COUNTRY_NOT_FOUND;
        }

        internal class HotelInfoManager
        {
            private IDataConsumer oDataConsumer;
            private ConcurrentDictionary<string, Country> oCountryISOKyeCountryValue;

            internal HotelInfoManager(
                IDataConsumer pDataConsumer,
                ConcurrentDictionary<string, Country> pCountryISOKyeCountryValue)
            {
                this.oDataConsumer = pDataConsumer;
                this.oCountryISOKyeCountryValue = pCountryISOKyeCountryValue;
            }

            public async Task CompleteData()
            {

                Dictionary<string, List<Hotel>> oCountryKeyHotelListDictionary = new Dictionary<string, List<Hotel>>();
                this.oDataConsumer.IConsumeDataFromExternalAPI(oCountryKeyHotelListDictionary);

                List<Task> oTaskList = new List<Task>();
                foreach (var oCountryKeyHotelListValue in oCountryKeyHotelListDictionary)
                    oTaskList.Add(this.CreateCountryObject(oCountryKeyHotelListValue));

                foreach (var oTask in oTaskList)
                    await oTask;
            }

            private async Task CreateCountryObject(KeyValuePair<string, List<Hotel>> oCountryKeyHotelListValue)
            {
                Dictionary<string, List<Hotel>> oScoreKeyHotelList = new Dictionary<string, List<Hotel>>();
                this.AddCountryToCacheDictionary(
                    this.GetSumAndOrdererHotelsByAvg(oCountryKeyHotelListValue.Value, oScoreKeyHotelList),
                    oCountryKeyHotelListValue,
                    oScoreKeyHotelList);
            }

            private void AddCountryToCacheDictionary(
                decimal sum,
                KeyValuePair<string, List<Hotel>> pCountryKeyHotelListValue,
                Dictionary<string, List<Hotel>> pScoreKeyHotelList)
            {
                Country oCountry = new Country();

                oCountry.average = sum / pCountryKeyHotelListValue.Value.Count;
                oCountry.isoCountryId = pCountryKeyHotelListValue.Key;
                oCountry.oHotelList = new List<Hotel>[pScoreKeyHotelList.Keys.Count];

                int index = 0;
                foreach (var oScoreKeyHotelListValue in pScoreKeyHotelList)
                {
                    index = Int32.Parse(oScoreKeyHotelListValue.Key.Split('-')[1]);
                    oCountry.oHotelList[index] = oScoreKeyHotelListValue.Value;
                }
                this.oCountryISOKyeCountryValue.TryAdd(pCountryKeyHotelListValue.Key, oCountry);
            }

            private decimal GetSumAndOrdererHotelsByAvg(List<Hotel> pHotelList, Dictionary<string, List<Hotel>> oScoreKeyHotelList)
            {
                Dictionary<string, List<Hotel>> oUnorderedAverageKeyHotelList = new Dictionary<string, List<Hotel>>();
                decimal sum = 0;
                List<decimal> scoresList = new List<decimal>();
                //Summing scores and Preparing them to be ordered
                foreach (var pHotel in pHotelList)
                {
                    decimal hotelScore;
                    if (Decimal.TryParse(pHotel.score.Replace('.', (',')), out hotelScore))
                    {
                        sum += hotelScore;
                        scoresList.Add(hotelScore);

                        if (!oUnorderedAverageKeyHotelList.ContainsKey(pHotel.score))
                            oUnorderedAverageKeyHotelList.Add(pHotel.score, new List<Hotel>());

                        oUnorderedAverageKeyHotelList[pHotel.score].Add(pHotel);
                    }
                }

                //Ordering from min to max the scores and looking for top three.
                decimal[] scoresArray = scoresList.ToArray();
                Array.Sort(scoresArray);
                decimal previousScore = 0;
                decimal currentScore = 0;
                string averageString = String.Empty;
                int position = 0;
                for (int i = 0; i < scoresArray.Length; i++)
                {
                    currentScore = scoresArray[scoresArray.Length - i - 1]; //From Last Position of the array

                    if (previousScore == currentScore)
                        continue;

                    previousScore = currentScore;
                    averageString = currentScore.ToString();
                    oScoreKeyHotelList.Add(
                        String.Concat(averageString, '-', position),
                        oUnorderedAverageKeyHotelList[averageString.Replace(',', '.')]);

                    position += 1;
                    if (position == 3)//Top 3 has been found yet
                        break;
                }
                return sum;
            }
        }
    }
}