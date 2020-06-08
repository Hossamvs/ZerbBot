using System.IO;
using Newtonsoft.Json;


namespace ZerbBot
{
    class Config
    {
        private const string CONFIGFOLDER = "Resources";
        private const string CONFIGFILE = "config.json";

        public static BotConfig bot;

        static Config()
        {
            //creates the directory if it is missing
            if (!Directory.Exists(CONFIGFOLDER))
                Directory.CreateDirectory(CONFIGFOLDER); 
            
            //creates the json file and seralizes it 
            if(!File.Exists(CONFIGFOLDER + "/" + CONFIGFILE))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText(CONFIGFOLDER + "/" + CONFIGFILE, json);
            }
            else //If the file exists read the data from it into "bot" 
            {
                string json = File.ReadAllText(CONFIGFOLDER + "/" + CONFIGFILE);
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
            }
        }

        //Has the Token and the prefix used for commands
        public struct BotConfig
        {
            public string token;
            public string cmdPrefix;
        }
    }
}
