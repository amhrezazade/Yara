using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yara.Models;

namespace Yara.Service
{
    public static class db
    {
        private static string localFileName = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "data.dat");
        private static string token = "";
        public static async Task<appData> LoadAsync()
        {
            try 
            {
                string txt = await File.ReadAllTextAsync(localFileName);
                return JsonConvert.DeserializeObject<appData>(txt);

            }
            catch//(Exception ex)
            {
                return null;
            }   
        }

        public static appData Load()
        {
            try
            {
                string txt = File.ReadAllText(localFileName);
                return JsonConvert.DeserializeObject<appData>(txt);

            }
            catch //(Exception ex)
            {
                return null;
            }
        }

        public static async Task Save(appData data)
        {

            try
            {
                string txt = JsonConvert.SerializeObject(data);
                await File.WriteAllTextAsync(localFileName, txt);
            }
            catch //(Exception ex)
            {
                return;
            }
        }

        public static async Task<string> LoadTokenAsync()
        {
            try
            {
                if (token == string.Empty)
                    return await File.ReadAllTextAsync(localFileName + "a");
                else
                    return token;
            }
            catch //(Exception ex)
            {
                return null;
            }
        }

        public static string LoadToken()
        {
            try
            {
                if (token == string.Empty)
                    return File.ReadAllText(localFileName + "a");
                else
                    return token;
            }
            catch //(Exception ex)
            {
                return null;
            }
        }

        public static async Task SaveToken(string data)
        {
            try
            {
                token = data;
                await File.WriteAllTextAsync(localFileName + "a", data);

            }
            catch //(Exception ex)
            {
                return;
            }
        }

        public static async Task SaveProfileImage(byte[] data)
        {
            try
            {
                await File.WriteAllBytesAsync(localFileName + ".jpg", data);

            }
            catch //(Exception ex)
            {
                return;
            }
        }

        public static async Task<Bitmap> LoadProfileImageAsync()
        {
            try
            {
                var bytes =  await File.ReadAllBytesAsync(localFileName + ".jpg");
                return  await BitmapFactory.DecodeByteArrayAsync(bytes, 0, bytes.Length);
            }
            catch //(Exception ex)
            {
                return null;
            }
        }


        public static Bitmap LoadProfileImage()
        {
            try
            {
                var bytes = File.ReadAllBytes(localFileName + ".jpg");
                return BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
            }
            catch //(Exception ex)
            {
                return null;
            }
        }

        public static bool clearData()
        {
            try
            {
                File.Delete(localFileName);
                File.Delete(localFileName + "a");
                File.Delete(localFileName + ".jpg");
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}