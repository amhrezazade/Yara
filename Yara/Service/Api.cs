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
    public static class Api
    {
        public static async Task<ApiResult<string>> Login(LoginModel m)
        {
            string rout = "/api/auth";
            string body = JsonConvert.SerializeObject(m);
            var res = await Server.Post(rout, body);
            return new ApiResult<string>(res.Res,res.ok,res.Res);
        }
        
        public static async Task<ApiResult<Student>> GetStudetData(string UserToken = null)
        {
            string rout = "/api/students";
            var res = await Server.Get(rout, UserToken);
            if (res.ok)
                return new ApiResult<Student>(JsonConvert.DeserializeObject<Student>(res.Res));
            return new ApiResult<Student>(null,res.ok,res.Res);
        }


    }
}