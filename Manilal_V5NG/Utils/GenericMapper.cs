using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Web;

namespace Manilal_V5NG.Utils
{
    public class GenericMapper
    {
        public static object GetItem(DataTable d)
        {
            dynamic MyDynamic = new ExpandoObject();
            IDictionary<String, object> dItem = MyDynamic as IDictionary<String, object>;
            bool hasObject = false;
            foreach (DataRow dtRow in d.Rows)
            {
                foreach (DataColumn dc in d.Columns)
                {
                    dItem.Add(Convert.ToString(dc), Convert.ToString(dtRow[dc]));
                }
                hasObject = true;
                break;
            }
            return hasObject ? dItem : null;
        }

        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public static string GetUniqueId()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
    }
}