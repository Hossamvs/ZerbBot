using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;


namespace ZerbBot
{
    class Utilities
    {
        //Dictionary to interact with JSON file
        private static Dictionary<string, string> alerts;


        static Utilities()
        {
            string json = File.ReadAllText("SystemLang/alerts.json");           

            var data = JsonConvert.DeserializeObject <dynamic>(json);
            
            alerts = data.ToObject<Dictionary<string, string>>();
            
        }

        //Returns value if key is found inside dictionary
        public static string GetAlert(string key)
        {           
            if (alerts.ContainsKey(key))
                return alerts[key];

            return "";
        }
        
        public static string GetFormattedAlert(string key, object parameter)
        {
            if (alerts.ContainsKey(key))
                return String.Format(alerts[key], parameter);

            return "";
        }
    }
}
