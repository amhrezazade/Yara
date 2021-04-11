using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Yara.Data;
using Yara.Models;
using Yara.Models.apiModels;

namespace Yara.Service
{

    public enum TestApiResult
    {
        OK,
        DataNull,
        TokenError,
        NetworkError,
        Unknown
    }
    public static class Api
    {
        const string baseUrl = "https://yaraapi.mazust.ac.ir";

        public static async Task<TestApiResult> Test()
        {
            var data = db.Load();

            if (data == null)
                return TestApiResult.DataNull;
            try
            {
                string url;
                HttpWebRequest request;

                url = baseUrl + "/api/lessons/activeTerm";


                request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("x-auth-token", data.user.token);
                var Response = await request.GetResponseAsync();
                var response = (HttpWebResponse)Response;
                var sr = new StreamReader(response.GetResponseStream());
                var res = await sr.ReadToEndAsync();
                return TestApiResult.OK;

            }
            catch (WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    return TestApiResult.TokenError;
                return TestApiResult.NetworkError;
            }
            catch (Exception ex)
            {
                return TestApiResult.Unknown;
            }


        }



        public static async Task<ApiResult<string>> Login(LoginModel m)
        {
            try
            {
                string url;
                HttpWebRequest request;

                url = baseUrl + "/api/auth";
                string body = JsonConvert.SerializeObject(m);
                byte[] messageBytes = Encoding.UTF8.GetBytes(body);
                
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                var stream = await request.GetRequestStreamAsync();
                await stream.WriteAsync(messageBytes, 0, messageBytes.Length);
                stream.Flush();
                var Response = await request.GetResponseAsync();
                var response = (HttpWebResponse)Response;
                var sr = new StreamReader(response.GetResponseStream());
                var res = await sr.ReadToEndAsync();
                return new ApiResult<string>(res);

            }
            catch (WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;
                var sr = new StreamReader(response.GetResponseStream());
                var res = await sr.ReadToEndAsync();
                return new ApiResult<string>(null, false, res);
            }
            catch (Exception ex)
            {
                return new ApiResult<string>(null, false, ex.Message);
            }

            
        }
        
        public static async Task<ApiResult<Student>> GetStudetData(string UserToken = null)
        {
            try
            {
                string token;
                if (UserToken == null)
                    token = db.Load().user.token;
                else
                    token = UserToken;

                string url;
                HttpWebRequest request;

                url = baseUrl + "/api/students";
                

                request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("x-auth-token", token);
                var Response = await request.GetResponseAsync();
                var response = (HttpWebResponse)Response;
                var sr = new StreamReader(response.GetResponseStream());
                var res = await sr.ReadToEndAsync();
                return new ApiResult<Student>(JsonConvert.DeserializeObject<Student>(res));
            }
            catch (WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;
                var sr = new StreamReader(response.GetResponseStream());
                var res = await sr.ReadToEndAsync();
                return new ApiResult<Student>(null, false, res);
            }
            catch (Exception ex)
            {
                return new ApiResult<Student>(null, false, ex.Message);
            }
        }

        
    }
}