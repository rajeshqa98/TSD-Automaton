
using Npoi.Mapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TSDHybridFramework.Core.DataMapper;


namespace MAW.Core.Utils
{
    class Excel
    {
        private string excelFilePath { get; set; }
        private Mapper excel;


        public Excel(String fileName) {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            var excelFilePath = projectPath + String.Format("TestData\\{0}.xlsx", fileName); ;
            excel = new Mapper(excelFilePath);
        }

        public Mapper Reader() {
            return excel;
        }

        public void ReadSheet(String sheetName) {
            //Solution for System.NotSupportedException: No data is available for encoding 1252
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            System.Collections.Generic.List<RowInfo<User>> users = this.Reader().Take<User>().ToList();
            


        }

        static void Main(string[] args)
        {

            List<User> users =User.GetFromExcel();

            foreach (User user in users) {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.ToString());


            }

        }
    }
}
