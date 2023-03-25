using Newtonsoft.Json;
using System.Text;

namespace HH2Tests.Api.IntegrationTests.Helpers
{
    public static class HttpContentHepler
    {
        public static HttpContent ToJsonToHttpContent( this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            return httpContent;
        }
    }
}
