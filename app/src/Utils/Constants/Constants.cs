namespace Utils.Contstants
{
    public struct Constants
    {
        public struct UrlConstants
        {
            public const string SEMBO_END_POINT = "https://developers.sembo.com/sembo/hotels-test/countries/?/hotels";
            public static readonly string[] SEMBO_COUNTRIES = {"es", "fr", "it"};
        }

        public struct HeaderConstants
        {
            public const string HEADER = "X-API-Key";
            public const string VALUE = "90bcd3b87715c8aebdcfb727e7de7e9e2f4c192c";
        }

        public struct ErrorConstants
        {
            public const string COUNTRY_NOT_FOUND = "Country Not Found";
        }

        public struct NumericConstants
        {
            public const int MAX_NUMBER_OF_RETRIES = 30;
        }
    }
}