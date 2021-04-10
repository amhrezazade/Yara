﻿using Android.App;
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
using System.Text;

namespace Yara.Data
{
    public static class db
    {
        private static string localFileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "data.dat");

        public static appData Load()
        {
            try 
            {
                string txt = File.ReadAllText(localFileName);
                return JsonConvert.DeserializeObject<appData>(txt);

            }
            catch(Exception ex)
            {
                return null;
            }   
        }

        public static void Save(appData data)
        {

            try
            {
                string txt = JsonConvert.SerializeObject(data);
                File.WriteAllText(localFileName, txt);

            }
            catch (Exception ex)
            {
                return;
            }
        }


        public static void clearData()
        {
            try
            {
                File.Delete(localFileName);
            }
            catch
            { }
        }

    }
}