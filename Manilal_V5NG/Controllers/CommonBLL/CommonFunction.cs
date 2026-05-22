using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Xml;
using System.Xml.Xsl;
using System.Text;

namespace Manilal_V5NG.Controllers.CommonBLL
{
    public class CommonFunction
    {

        internal static string ConvertToWord_open(string folder, string xlsFileName, DataSet DsFile, string FILE_NAME)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string output;
            string strPath = "", strReturnPath="";
            XmlDocument XMLFILE = new XmlDataDocument(DsFile);
            try
            {
                XslCompiledTransform xsl = new XslCompiledTransform();
               // xsl.Load(HttpContext.Current.Server.MapPath("~") + "\\xslFiles\\Export\\" + xlsFileName, new XsltSettings(false, true), new XmlUrlResolver());
                xsl.Load(HttpContext.Current.Server.MapPath("..\\..\\") + "\\include\\xml\\" + folder + "\\" + xlsFileName, new XsltSettings(false, true), new XmlUrlResolver());
                using (XmlTextWriter xtw = new XmlTextWriter(new StringWriter(sb)))
                {
                    xsl.Transform(XMLFILE, xtw);
                    xtw.Flush();
                }

                output = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + sb.ToString();
                System.IO.StreamWriter oWrite;
                strPath = HttpContext.Current.Server.MapPath("~") + "\\DATA\\EXPORT\\" + FILE_NAME + ".doc";
                // strReturnPath =  HttpContext.Current.Request.Url + "/DATA/EXPORT/" + FILE_NAME + ".doc"; 
                string urlpath = System.Configuration.ConfigurationManager.AppSettings["DOWNLOADPATH"];// WebConfigurationManager.AppSettings["DOWNLOADPATH"];
                strReturnPath = urlpath + "DATA/EXPORT/" + FILE_NAME + ".doc";
                if (File.Exists(strPath))
                {
                    File.Delete(strPath);
                }

                oWrite = File.CreateText(strPath);
                oWrite.WriteLine(output);
                oWrite.Close();
            }
            finally
            {
                sb = null;
                output = null;
            }

            return strReturnPath;
        }

        internal static string GetIpAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

         internal static string ConvertToExcel_open(string folder, string xlsFileName, XmlDocument XMLFILE)//(string folder, string xlsFileName, XmlDocument XMLFILE, string FILE_NAME)
        {
            StringBuilder sb = new StringBuilder();
            string output;
            try
            {
                XslCompiledTransform xsl = new XslCompiledTransform();
                xsl.Load(HttpContext.Current.Server.MapPath("~") + "\\include\\xml\\" + folder + "\\" + xlsFileName, new XsltSettings(false, true), new XmlUrlResolver());
                using (StringWriter sw = new StringWriter(sb))
                using (XmlTextWriter xtw = new XmlTextWriter(sw))
                {
                    xsl.Transform(XMLFILE, xtw);
                    xtw.Flush();
                }
                output = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" + sb.ToString();

            }
            finally
            {
                sb = null;
                //output = null;
            }

            return output;
        }
     

    }
}