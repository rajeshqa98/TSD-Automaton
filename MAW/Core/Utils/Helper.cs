using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TSDHybridFramework.Core.Utils
{
    class Helper
    {

        public static string GetProjectBaseDirectoryPath() {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }

        public static Dictionary<string, string> ReadJsonAsDictionary(string jsonFileName) {
            jsonFileName = jsonFileName.ToLower();
            if (!jsonFileName.EndsWith(".json")) {
                jsonFileName = jsonFileName + ".json";
            }

            var projectPath = Helper.GetProjectBaseDirectoryPath();
            var excelFilePath = projectPath + String.Format("TestData\\{0}", jsonFileName);
            string json = File.ReadAllText(excelFilePath);
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            return values;

        }

        public static string GetValue(string key) {
            Dictionary<string, string> dictionary = ReadJsonAsDictionary("config");

            if (dictionary.ContainsKey(key)) {
                return dictionary[key];
            }
            Console.Error.WriteLine(String.Format("There is no key '{0}' available in config file",key));
           
            return null;

        }
    }
}
