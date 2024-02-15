using System.Net.Http;
using System.Collections.Generic;

namespace Utils.HTTP
{
    public class UtilsHTTP : IGetFromUrl
    {
        public UtilsHTTP(){}

        public string GetFromUrl(string pUrl, Dictionary<string, string> pHeaders){
            HttpClientHandler oClientHandler = new HttpClientHandler();
            oClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient oHttpClient = new HttpClient(oClientHandler);

            foreach (var headerKeyStringValue in pHeaders)
                oHttpClient.DefaultRequestHeaders.Add(headerKeyStringValue.Key, headerKeyStringValue.Value);
            
            return oHttpClient.GetStringAsync(pUrl).Result;
        }
    }
}