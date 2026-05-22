using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace Manilal_V5NG.Utils
{
    public static class Extensions
    {
        public static int IfNullThenZero(this object value)
        {
            if (value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }

        public static string IfNullThenEmpty(this object value)
        {
            if (value == DBNull.Value)
            {
                return "";
            }
            else
            {
                return Convert.ToString(value).Trim();
            }
        }



        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }

        public static string GetFirst(this string source, int tail_length)
        {
            if (source.Trim() == "")
                return source;
            return source.Substring(0, tail_length);
        }
    }
}