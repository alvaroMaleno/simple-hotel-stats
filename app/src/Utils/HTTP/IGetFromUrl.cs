using System.Collections.Generic;

namespace Utils.HTTP
{
    public interface IGetFromUrl
    {
        string GetFromUrl(string pUrl, Dictionary<string, string> pHeaders);
    }
}