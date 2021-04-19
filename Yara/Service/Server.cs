
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Yara.Data;


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

        public const string baseUrl = "https://yaraapi.mazust.ac.ir";

        private static async Task<ApiResult> Request(HttpWebRequest req)
        {
            try
            {
                req.UserAgent = "Yara Notifier Android Application";
                var Response = await req.GetResponseAsync();
                var response = (HttpWebResponse)Response;
                var sr = new StreamReader(response.GetResponseStream());
                var res = await sr.ReadToEndAsync();
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

        private static async Task<ApiResult> Request(string Rout, string UserToken = null)
        {
            string token;
            if (UserToken == null)
            {
                var data = db.Load();
                if (data == null)
                    return new ApiResult()
                    {
                        ok = false,
                        Res = "خطای توکن",
                        code = 502
                    };
                token = data.user.token;
            }
            else
                token = UserToken;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl + Rout);
            request.Headers.Add("x-auth-token", token);
            return await Request(request);
        }

        public static async Task<TestApiResult> Test()
        {
            string url = "/api/lessons/activeTerm";
            var r = await Request(url);
            if (r.code == 502)
                return TestApiResult.DataNull;
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
            var output = await Request(rout, token);

            if (output.code == 401 || output.code == 401)
                System.Diagnostics.Process.GetCurrentProcess().Kill();

            return output;

        }

        public static async Task<ApiResult> Post(string rout, string body)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl + rout);
                request.Method = "POST";
                request.ContentType = "application/json";
                Stream stream;
                stream = await request.GetRequestStreamAsync();
                byte[] messageBytes = Encoding.UTF8.GetBytes(body);
                await stream.WriteAsync(messageBytes, 0, messageBytes.Length);
                stream.Flush();
                return await Request(request);
            }
            catch(Exception ex)
            {
                return new ApiResult()
                {
                    ok = false,
                    Res ="خطای ارتباط با سرور",
                    code = 501
                };
            }

        }

    }
}