using MAW.Core.Utils;
using Npoi.Mapper;
using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSDHybridFramework.Core.DataMapper
{
    class User
    {
        [Column("UserName")]
        public string Name { get; set; }
        public string Pass   { get; set; }
        public string Url { get; set; }



        public static List<User> GetFromExcel() {
            Excel excel = new Excel("Data");
            List<RowInfo<User>> userRows = excel.Reader().Take<User>().ToList();
            List<User> users = new List<User>();

            foreach (var user in userRows) {
                users.Add(user.Value);
            }

            return users;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
