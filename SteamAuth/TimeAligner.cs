﻿using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;

namespace SteamAuth
{
    /// <summary>
    /// Class to help align system time with the Steam server time. Not super advanced; probably not taking some things into account that it should.
    /// Necessary to generate up-to-date codes. In general, this will have an error of less than a second, assuming Steam is operational.
    /// </summary>
    public class TimeAligner
    {
        private static bool _aligned = false;
        private static int _timeDifference = 0;

        public static long GetSteamTime()
        {
            if (!TimeAligner._aligned)
            {
                TimeAligner.AlignTime();
            }
            return Util.GetSystemUnixTime() + _timeDifference;
        }

        public static async Task<long> GetSteamTimeAsync()
        {
            if (!TimeAligner._aligned)
            {
                await TimeAligner.AlignTimeAsync();
            }
            return Util.GetSystemUnixTime() + _timeDifference;
        }

        public static void AlignTime()
        {
            long currentTime = Util.GetSystemUnixTime();
            using (HttpClient client = new HttpClient(new HttpClientHandler()))
            {
                try
                {
                    var response = client.PostAsync(new Uri(APIEndpoints.TWO_FACTOR_TIME_QUERY), new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                    })).ConfigureAwait(false).GetAwaiter().GetResult();
                    string body = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                    TimeQuery query = JsonConvert.DeserializeObject<TimeQuery>(body);
                    TimeAligner._timeDifference = (int)(query.Response.ServerTime - currentTime);
                    TimeAligner._aligned = true;
                }
                catch (WebException)
                {
                    return;
                }
            }
        }

        public static async Task AlignTimeAsync()
        {
            long currentTime = Util.GetSystemUnixTime();
            using (HttpClient client = new HttpClient(new HttpClientHandler()))
            {
                try
                {
                    var response = await client.PostAsync(new Uri(APIEndpoints.TWO_FACTOR_TIME_QUERY), new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                    }));
                    string body = await response.Content.ReadAsStringAsync();
                    TimeQuery query = JsonConvert.DeserializeObject<TimeQuery>(body);
                    TimeAligner._timeDifference = (int)(query.Response.ServerTime - currentTime);
                    TimeAligner._aligned = true;
                }
                catch (WebException)
                {
                    return;
                }
            }
        }

        internal class TimeQuery
        {
            [JsonProperty("response")]
            internal TimeQueryResponse Response { get; set; }

            internal class TimeQueryResponse
            {
                [JsonProperty("server_time")]
                public long ServerTime { get; set; }
            }

        }
    }
}
