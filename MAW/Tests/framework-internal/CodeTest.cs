using MAW.Core.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TSDHybridFramework.Core.DataMapper;
using TSDHybridFramework.Core.Utils;

namespace TSDHybridFramework.Tests.framework_internal
{
    class CodeTest
    {

        [Test]
        public void excel_code_test()
        {
             List<User> users =User.GetFromExcel();

            foreach (User user in users)
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.ToString());
            }


            

            Excel excel = new Excel("Data");
            List<Dictionary<string, string>> rows
                = excel.ReadSheet("User");

            Console.WriteLine(rows.Count);


            foreach (KeyValuePair<string, string> ele2 in rows[1])
            {
                Console.WriteLine("{0} : {1}", ele2.Key, ele2.Value);
            }
        }

        [Test]
        public void read_json_as_dictionary() {
            string fileName = "config";
            Console.WriteLine("Read all value");
            Dictionary<string, string> dictionary= Helper.ReadJsonAsDictionary(fileName);

            foreach (var item in dictionary)
            {
                Console.WriteLine("Key: {0}, Value: {1}",
                    item.Key, item.Value);
            }

        }

        [Test]
        public void get_value_from_config()
        {
             
            Console.WriteLine("Get a value from key");
            string v = Helper.GetValue("browser");
            Console.WriteLine(v);
        }
    }
}
