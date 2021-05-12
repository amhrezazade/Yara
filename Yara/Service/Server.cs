
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Yara.Models;
using System.Net.Http;

namespace Yara.Service
{
    public static class Server
    {
        public enum TestApiResult
        {
            OK,
            DataNull,
            TokenError,
            NetworkError,
            Unknown
        }

        public struct ApiResult
        {
            public bool ok;
            public string Res;
            public int code;
        }



        private static async Task<ApiResult> Request(string Rout,string body, string UserToken = null)
        {
            try
            {

                WebClient client = new WebClient();
                string token;
                if (UserToken == null)
                {
                    var data = await db.LoadToken();
                    if (data == null)
                        token = "";
                    else
                        token = data;
                }
                else
                    token = UserToken;

                client.Headers.Add("x-auth-token", token);

                client.Headers[HttpRequestHeader.UserAgent] = StaticData.UserAgent;

                if (body == string.Empty)
                {
                    string baseSiteString = client.DownloadString(StaticData.BaseUrl + Rout);
                    return new ApiResult()
                    {
                        ok = true,
                        Res = baseSiteString,
                        code = 200
                    };
                }


                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string res = client.UploadString(StaticData.BaseUrl + Rout, body);



                return new ApiResult()
                {
                    ok = true,
                    Res = res,
                    code = 200
                };

            }
            catch (WebException ex)
            {
                if (ex.Response == null)
                    return new ApiResult()
                    {
                        ok = false,
                        Res = "خطای اتصال به سرور",
                        code = 503
                    };
                var response = (HttpWebResponse)ex.Response;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return new ApiResult()
                    {
                        ok = false,
                        Res = "خطای انقضای توکن",
                        code = (int)response.StatusCode
                    };
                var sr = new StreamReader(response.GetResponseStream());
                var res = await sr.ReadToEndAsync();
                return new ApiResult()
                {
                    ok = false,
                    Res = res,
                    code = (int)response.StatusCode
                };
            }
            catch (Exception ex)
            {
                return new ApiResult()
                {
                    ok = false,
                    Res = ex.Message,
                    code = 501
                };
            }
        }


        public static async Task<TestApiResult> Test()
        {
            var data = await db.LoadToken();
            if (data == null)
                return TestApiResult.DataNull;
            string url = "/api/lessons/activeTerm";
            var r = await Request(url,string.Empty);
            if (r.code == 200)
                return TestApiResult.OK;
            if (r.code == 503)
                return TestApiResult.NetworkError;
            if (r.code == 401)
                return TestApiResult.TokenError;
            return TestApiResult.Unknown;
        }

        public static async Task<ApiResult> Get(string rout, string token = null)
        {
            var output = await Request(rout,string.Empty, token);

            if (output.code == 401 || output.code == 501)
                System.Diagnostics.Process.GetCurrentProcess().Kill();

            return output;

        }

        public static async Task Put(string rout)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(StaticData.BaseUrl + rout);
                request.Headers.Add("x-auth-token", await db.LoadToken());
                request.Method = "PUT";
                request.ContentLength = 0;
                request.Host = StaticData.ServerHost;
                await request.GetResponseAsync();
            }
            catch(Exception ex)
            {
            }
        }


        public static async Task<ApiResult> Post(string rout, string body)
        {
            var output = await Request(rout, body);

            if (output.code == 401 || output.code == 501)
                System.Diagnostics.Process.GetCurrentProcess().Kill();

            return output;

        }

        public static async Task<byte[]> GetProfileImageBytes(string Filename)
        {
            try 
            {
                return await new WebClient().DownloadDataTaskAsync(StaticData.ProfileImageURL + Filename);
            }
            catch 
            {
                return null;
            }
        }

    }
}