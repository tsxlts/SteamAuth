using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SteamAuth
{
    public class SteamWeb
    {
        public static string MOBILE_APP_USER_AGENT = "okhttp/3.12.12";

        public static async Task<string> GETRequest(string url, CookieContainer cookies)
        {
            string response;
            using (CookieAwareWebClient wc = new CookieAwareWebClient())
            {
                wc.Encoding = Encoding.UTF8;
                wc.CookieContainer = cookies;
                wc.Headers[HttpRequestHeader.UserAgent] = SteamWeb.MOBILE_APP_USER_AGENT;
                response = await wc.DownloadStringTaskAsync(url);
            }
            return response;
        }

        public static async Task<string> POSTRequest(string url, CookieContainer cookies, NameValueCollection body)
        {
            if (body == null)
                body = new NameValueCollection();

            string response;
            using (CookieAwareWebClient wc = new CookieAwareWebClient())
            {
                wc.Encoding = Encoding.UTF8;
                wc.CookieContainer = cookies;
                wc.Headers[HttpRequestHeader.UserAgent] = SteamWeb.MOBILE_APP_USER_AGENT;
                byte[] result = await wc.UploadValuesTaskAsync(new Uri(url), "POST", body);
                response = Encoding.UTF8.GetString(result);
            }
            return response;
        }

        public static async Task<SteamApiResponse<T>> POSTRequest<T>(string url, CookieContainer cookies, NameValueCollection body)
        {
            if (body == null)
                body = new NameValueCollection();

            using (CookieAwareWebClient wc = new CookieAwareWebClient())
            {
                wc.Encoding = Encoding.UTF8;
                wc.CookieContainer = cookies;
                wc.Headers[HttpRequestHeader.UserAgent] = SteamWeb.MOBILE_APP_USER_AGENT;
                byte[] result = await wc.UploadValuesTaskAsync(new Uri(url), "POST", body);
                string response = Encoding.UTF8.GetString(result);

                var resultCode = ErrorCodes.Invalid;
                var eresult = wc.ResponseHeaders.Get("x-eresult");
                if (!string.IsNullOrWhiteSpace(eresult) && int.TryParse(eresult, out var resultInt))
                {
                    resultCode = (ErrorCodes)resultInt;
                }

                SteamApiResponse<T> responseBody = new SteamApiResponse<T>
                {
                    EResult = resultCode,
                    Response = default
                };
                if (!string.IsNullOrWhiteSpace(response) && !typeof(string).Equals(typeof(T)))
                {
                    responseBody = JsonConvert.DeserializeObject<SteamApiResponse<T>>(response);
                }

                responseBody.EResult = resultCode;
                return responseBody;
            }
        }
    }
}
