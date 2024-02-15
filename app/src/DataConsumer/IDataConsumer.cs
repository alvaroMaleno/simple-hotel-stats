using System.Collections.Generic;
using Models;

namespace DataConsumer
{
    public interface IDataConsumer
    {
        void IConsumeDataFromExternalAPI(Dictionary<string, List<Hotel>> pCountriesKeyHotelListDictionary);
    }
}