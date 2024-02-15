using System.Collections.Generic;

namespace Utils.JSON
{
    public interface IGetJsonHttp
    {
        void IGetJsonHttp<R>(out R pTargetClass, string pUrl, Dictionary<string, string> pHeaders);
    }
}