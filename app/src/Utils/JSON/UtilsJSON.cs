using System.Collections.Generic;
using Newtonsoft.Json;
using Utils.HTTP;

namespace Utils.JSON
{
    public class UtilsJSON : IGetJsonHttp
    {
        private IGetFromUrl oGetFromUrl;
        
        public UtilsJSON(){
            oGetFromUrl = new UtilsHTTP();
        }

        public void IGetJsonHttp<R>(out R pTargetClass, string pUrl, Dictionary<string, string> pHeaders){
            pTargetClass = JsonConvert.DeserializeObject<R>(oGetFromUrl.GetFromUrl(pUrl, pHeaders));
        }

    }
}