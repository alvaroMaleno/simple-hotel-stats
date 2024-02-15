using System.Collections.Generic;

namespace Models
{
    public class Country
    {
        public string isoCountryId {get; set; }
        public decimal average { get; set; }
        public List<Hotel>[] oHotelList { get; set; }
    }
}
