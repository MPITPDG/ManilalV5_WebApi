using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manilal_V5NG.BaseBLL
{
    public class ConnectionString
    {
        public static string getConnString()
        {
            return System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];
        }
        public static string AssingValue(string strSetting)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["ENC"] == "Y")
                return DeCrypt(System.Configuration.ConfigurationManager.AppSettings[strSetting], "");
            else
                return System.Configuration.ConfigurationManager.AppSettings[strSetting];
        }
        private static string DeCrypt(string texti, string salasana)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["ENC"] == "Y")
            {
                int T, TT, G;
                string DeCrypted = "";
                double sana = 0;
                double X1 = 0;

                for (T = 1; T <= (salasana.Length); T++)
                {
                    sana = Convert.ToChar(salasana.Substring((T - 1), 1));
                    X1 = X1 + sana;
                }
                X1 = Convert.ToInt16((X1 * 0.1) / 6);
                salasana = Convert.ToString(X1);
                G = 0;
                for (TT = 1; TT <= texti.Length; TT++)
                {
                    // sana = Asc(Strings.Mid(texti, TT, 1));
                    sana = Convert.ToChar(Mid(texti, TT, 1));
                    G = G + 1;
                    if (G == 6)
                        G = 0;
                    X1 = 0;
                    if (G == 0)
                        X1 = sana + (salasana.Length - 2);
                    if (G == 1)
                        X1 = sana - (salasana.Length - 5);
                    if (G == 2)
                        X1 = sana + (salasana.Length - 4);
                    if (G == 3)
                        X1 = sana - (salasana.Length - 2);
                    if (G == 4)
                        X1 = sana + (salasana.Length - 3);
                    if (G == 5)
                        X1 = sana - (salasana.Length - 5);
                    X1 = X1 - G;
                    DeCrypted = DeCrypted + Convert.ToString(X1);
                }
                return DeCrypted;
            }
            else
                return texti;
        }
        public static string Mid(string s, int a, int b)

        {

            string temp = s.Substring(a - 1, b);

            return temp;

        }
        //public static string AssingValue(string strSetting)
        //{
        //    if (System.Configuration.ConfigurationManager.AppSettings["ENC"] == "Y")
        //    {
        //        return DeCrypt(System.Configuration.ConfigurationManager.AppSettings[strSetting], "");
        //    }
        //    else
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings[strSetting];
        //    }
        //}
    }

}