using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Manilal_V5NG.BaseBLL;
using Manilal_V5NG.Models;
using System.Data;
using System.Diagnostics;
namespace Manilal_V5NG.Controllers.CommonBLL
{
    public class VerifyRights
    {
        public string CmpId { get; set; }
        public string FormId { get; set; }
        public string CodeCity { get; set; }
        public string EntryDt { get; set; }
    }
    public class Report
    {
        public string SEARCHCRITERIA(params object[] parameterValues)
        {
            string SQLPARA = "'";
            if (parameterValues is object & parameterValues.Length > 0)
            {
                short p;
                var loopTo = (short)(parameterValues.Length - 1);
                for (p = 0; p <= loopTo; p++)
                {
                    // SQLPARA = Conversions.ToString(Operators.AddObject(SQLPARA + "','", parameterValues[p]));
                    SQLPARA = SQLPARA + "','" + parameterValues[p];
                }

                SQLPARA = SQLPARA + "'";
                SQLPARA = SQLPARA.Substring(3, SQLPARA.Length - 3);
                
            }
            return SQLPARA;

        }
        public string SQLQUERY_PARA(params object[] parameterValues)
        {
            string SQLPARA = "'";
            if (parameterValues is object & parameterValues.Length > 0)
            {
                short p;
                var loopTo = (short)(parameterValues.Length - 1);
                for (p = 0; p <= loopTo; p++)
                    // SQLPARA = Conversions.ToString(Operators.AddObject(SQLPARA + "','", parameterValues[p]));
                    SQLPARA = SQLPARA + "','" + parameterValues[p];
            }

            SQLPARA = SQLPARA + "'";
            SQLPARA = SQLPARA.Substring(3, SQLPARA.Length - 3);
            return SQLPARA;
        }
        /* public string REPORT_LOG_BATCH(string fkReportId, string SearchCTA, string SqlQueryPARA,string CMPID) 
          {
             DAL objDAL = new DAL();
             DataSet ds = new DataSet();
             string PKID = null;
             string path = null;
             string oBatchFile = null;
             string oOutputFile = null;
             string oSQLStatementFile = null;
             string oFilePath = null;
             string strSQL = null;
             try
             {
                 ds = objDAL.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_REPORT_LOG_INSERT_BATCH", CMPID , fkReportId, SearchCTA, SqlQueryPARA);
                 if (ds.Tables.Count > 0)
                 {
                     if (ds.Tables[0].Rows.Count > 0)
                     {
                         PKID = ds.Tables[0].Rows[0]["RptID"].ToString();
                     }
                 }
                 if (Convert.ToInt64(PKID) > 0L)
                 {
                     //  StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\Account_Statement_columnwise.html");
                     path = HttpContext.Current.Server.MapPath("..\\..\\").ToString() + System.Configuration.ConfigurationManager.AppSettings["EXPORT_TO_XL"].ToString();
                     oBatchFile = "COR_OVERSEAS_AGENT_" + CMPID + "_Batch.bat";
                     oOutputFile = "COR_OVERSEAS_AGENT_" + CMPID + "_Out.txt";
                     oSQLStatementFile = "COR_OVERSEAS_AGENT_" + CMPID + "_SQL.sql";
                     oFilePath =  HttpContext.Current.Server.MapPath("..\\..\\Data\\ExportToExcel\\batch\\").ToString();
                     if (System.IO.File.Exists(oFilePath + oOutputFile))
                     {
                         System.IO.File.Delete(oFilePath + oOutputFile);
                     }

                     if (System.IO.File.Exists(oFilePath + oBatchFile))
                     {
                         System.IO.File.Delete(oFilePath + oBatchFile);
                     }

                     if (System.IO.File.Exists(oFilePath + oSQLStatementFile))
                     {
                         System.IO.File.Delete(oFilePath + oSQLStatementFile);
                     }
                   //  strSQL = "sqlcmd -S " + BLL_ConnString.AssingValue("Logon_server") + " -d " + BLL_ConnString.AssingValue("Logon_database") + " -U " + BLL_ConnString.AssingValue("Logon_user_id") + " -P " + BLL_ConnString.AssingValue("Logon_password") + " -i " + oFilePath + @"\" + oSQLStatementFile + " -o " + oFilePath + @"\" + oOutputFile;
                     Process proc = new Process();
                     proc.StartInfo.FileName = path;
                     proc.StartInfo.Arguments = PKID;
                     proc.Start(); 
                     proc = null; 
                 }
                 return PKID;
             }            
             finally
             {
                 PKID = null;
                 path = null;

             }


         }*/
        public string REPORT_LOG_BATCH_CLIENTPROFIT(string fkReportId, string SearchCTA, string SqlQueryPARA, string CMPID, string Type)
        {
            DAL objDAL = new DAL();
            DataSet ds = new DataSet();
            string PKID = null;
            string path = null;


            try
            {
                ds = objDAL.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_REPORT_LOG_INSERT_BATCH", CMPID, fkReportId, SearchCTA, SqlQueryPARA);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    PKID = ds.Tables[0].Rows[0]["RPTID"].ToString();
                }

                if (!string.IsNullOrEmpty(PKID))
                {
                    string oBatchFile = "CP_Batch.bat";
                    string oOutputFile = "CP_Out.txt";
                    string oSQLStatementFile = "CP_SQL.sql";

                    //GET PATH FROM WEB.CONFIG
                    string oFilePath = HttpContext.Current.Server.MapPath(@"..\..\Data\ExportToExcel").ToString();

                    if (File.Exists(oFilePath + "\\" + oOutputFile))
                    {
                        File.Delete(oFilePath + "\\" + oOutputFile);
                    }

                    if (File.Exists(oFilePath + "\\" + oBatchFile))
                    {
                        File.Delete(oFilePath + "\\" + oBatchFile);
                    }

                    if (File.Exists(oFilePath + "\\" + oSQLStatementFile))
                    {
                        File.Delete(oFilePath + "\\" + oSQLStatementFile);
                    }

                    string strSQL = "sqlcmd -S " + ConnectionString.AssingValue("Logon_server") + " -d " + ConnectionString.AssingValue("Logon_database") + " -U " + ConnectionString.AssingValue("Logon_user_id") + " -P " + ConnectionString.AssingValue("Logon_password") + " -i " + oFilePath + "\\" + oSQLStatementFile + " -o " + oFilePath + "\\" + oOutputFile;

                    using (StreamWriter oStreamBatch = File.CreateText(oFilePath + "\\" + oBatchFile))
                    {
                        oStreamBatch.WriteLine("");
                        oStreamBatch.WriteLine(strSQL);
                        oStreamBatch.WriteLine("");
                        oStreamBatch.WriteLine(oFilePath + "\\" + "EXPORT_TO_XL.EXE " + PKID);
                        oStreamBatch.WriteLine("EXIT");
                    }
                    string str2;
                    if (Type == "CLIENT")
                    {
                        str2 = "EXEC USP_ACC_MIS_CLIENTPROFITABILITY_EXE '" + PKID + "'," + SqlQueryPARA;
                    }
                    else
                    {
                        str2 = "EXEC USP_ACC_MIS_CLIENTPROFITABILITY_EXE_AGENT '" + PKID + "'," + SqlQueryPARA;
                    }


                    using (StreamWriter oStreamSQL = File.CreateText(oFilePath + "\\" + oSQLStatementFile))
                    {
                        oStreamSQL.WriteLine("");
                        oStreamSQL.WriteLine(str2);
                        oStreamSQL.WriteLine("");
                    }

                    Process proc_BATCH = new Process();
                    proc_BATCH.StartInfo.FileName = oFilePath + "\\" + oBatchFile;
                    proc_BATCH.Start();

                }
                return PKID;
            }
            finally
            {
                PKID = null;
                path = null;
            }


        }

        public string REPORT_LOG(string fkReportId, string SearchCTA, string SqlQueryPARA, string CMPID)
        {
            DAL objDAL = new DAL();
            DataSet ds = new DataSet();
            string PKID = null;
            string path = null;
            try
            {
                ds = objDAL.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_REPORT_LOG_INSERT", CMPID, fkReportId, SearchCTA, SqlQueryPARA);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        PKID = ds.Tables[0].Rows[0]["RptID"].ToString();
                    }
                }
                if (Convert.ToInt64(PKID) > 0L)
                {
                    //  StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\Account_Statement_columnwise.html");
                    path = HttpContext.Current.Server.MapPath("..\\..\\").ToString() + System.Configuration.ConfigurationManager.AppSettings["EXPORT_TO_XL"].ToString();
                    Process proc = new Process();
                    proc.StartInfo.FileName = path;
                    proc.StartInfo.Arguments = PKID;
                    proc.Start();
                    proc = null;
                }
                return PKID;
            }
            finally
            {
                PKID = null;
                path = null;

            }

        }
        public string REPORT_LOG_BATCH(string fkReportId, string SearchCTA, string SqlQueryPARA, string CMPID)
        {
            DAL objDAL = new DAL();
            DataSet ds = new DataSet();
            string PKID = null;
            string path = null;
            string oBatchFile = null;
            string oOutputFile = null;
            string oSQLStatementFile = null;
            string oFilePath = null;
            string strSQL = null;
            StreamWriter oStreamBatch = null;
            StreamWriter oStreamSQL = null;
            bool isRedirect = false;
            try
            {
                ds = objDAL.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_REPORT_LOG_INSERT_BATCH", CMPID, fkReportId, SearchCTA, SqlQueryPARA);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        PKID = ds.Tables[0].Rows[0]["RptID"].ToString();
                    }
                }
                if (Convert.ToInt64(PKID) > 0L)
                {
                    try
                    {

                        //  StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\Account_Statement_columnwise.html");
                        path = HttpContext.Current.Server.MapPath("..\\..\\").ToString() + System.Configuration.ConfigurationManager.AppSettings["EXPORT_TO_XL"].ToString();

                        oBatchFile = "COR_OVERSEAS_AGENT_" + CMPID + "_Batch.bat";
                        oOutputFile = "COR_OVERSEAS_AGENT_" + CMPID + "_Out.txt";
                        oSQLStatementFile = "COR_OVERSEAS_AGENT_" + CMPID + "_SQL.sql";

                        oFilePath = HttpContext.Current.Server.MapPath("..\\..\\Data\\ExportToExcel\\batch\\").ToString();
                        if (File.Exists(oFilePath + oOutputFile))
                        {
                            System.IO.File.Delete(oFilePath + oOutputFile);
                        }

                        if (System.IO.File.Exists(oFilePath + oBatchFile))
                        {
                            System.IO.File.Delete(oFilePath + oBatchFile);
                        }

                        if (System.IO.File.Exists(oFilePath + oSQLStatementFile))
                        {
                            System.IO.File.Delete(oFilePath + oSQLStatementFile);
                        }

                        strSQL = "sqlcmd -S " + ConnectionString.AssingValue("Logon_server") + " -d " + ConnectionString.AssingValue("Logon_database") + " -U " + ConnectionString.AssingValue("Logon_user_id") + " -P " + ConnectionString.AssingValue("Logon_password") + " -i " + oFilePath + @"\" + oSQLStatementFile + " -o " + oFilePath + @"\" + oOutputFile;
                        //'sqlcmd
                        //'-S [protocol:]server[\instance_name][,port]
                        //'-d db_name 
                        //'-U login_id 
                        //'-P password 
                        //'-i input_file 
                        //'-o output_file 

                        //oStreamBatch = System.IO.File.CreateText((oFilePath + ("\\" + oBatchFile)));

                        try
                        {
                            using (StreamWriter writer = System.IO.File.CreateText(oFilePath + @"\" + oBatchFile))
                            {
                                writer.Write("");
                                writer.WriteLine(strSQL);
                                writer.WriteLine(oFilePath.Replace(@"batch\", "") + "EXPORTTOEXCEL.EXE " + PKID);
                                writer.WriteLine("EXIT");
                            }
                        }
                        catch (Exception exp)
                        {
                            Console.Write(exp.Message);
                        }

                        string str3 = String.Empty; string str2 = String.Empty;
                        str2 = "EXEC USP_ACCT_RPT_OUTSTANDING_CLIENTBILL_35_BRANCH_OVERSEAS_AGENT_EXE '" + PKID + "'," + SqlQueryPARA;
                        using (StreamWriter writer = File.CreateText(oFilePath + @"\" + oSQLStatementFile))
                        {
                            writer.WriteLine("");
                            writer.WriteLine(str2);
                            writer.WriteLine("");
                        }
                    }
                    finally
                    {
                        if (!(oStreamBatch == null))
                        {
                            oStreamBatch.Close();
                        }
                        oStreamBatch = null;

                        if (!(oStreamSQL == null))
                        {
                            oStreamSQL.Close();
                        }
                        oStreamSQL = null;
                    }

                    Process proc_BATCH = new Process();
                    proc_BATCH.StartInfo.FileName = (oFilePath + ("\\" + oBatchFile));
                    proc_BATCH.StartInfo.Arguments = PKID;
                    proc_BATCH.Start();
                    isRedirect = true;
                }
                return PKID;
            }
            finally
            {
                path = null;
                if (!(objDAL == null))
                {
                    objDAL.Dispose();
                }

                if (!(ds == null))
                {
                    ds.Dispose();
                }
                PKID = null;
                path = null;

            }


        }

    }
    //public string REPORT_LOG_BATCH_JOBPROFIT(string fkReportId, string SearchCTA, string SqlQueryPARA, string CMPID, string Type)
    //{
    //    DAL objDAL = new DAL();
    //    DataSet ds = new DataSet();
    //    string PKID = null;
    //    string path = null;


    //    try
    //    {
    //        ds = objDAL.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_REPORT_LOG_INSERT_BATCH", CMPID, fkReportId, SearchCTA, SqlQueryPARA);

    //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //        {
    //            PKID = ds.Tables[0].Rows[0]["RPTID"].ToString();
    //        }

    //        if (!string.IsNullOrEmpty(PKID))
    //        {
    //            string oBatchFile = "CP_Batch.bat";
    //            string oOutputFile = "CP_Out.txt";
    //            string oSQLStatementFile = "CP_SQL.sql";

    //            //GET PATH FROM WEB.CONFIG
    //            string oFilePath = HttpContext.Current.Server.MapPath(@"..\..\Data\ExportToExcel").ToString();

    //            if (File.Exists(oFilePath + "\\" + oOutputFile))
    //            {
    //                File.Delete(oFilePath + "\\" + oOutputFile);
    //            }

    //            if (File.Exists(oFilePath + "\\" + oBatchFile))
    //            {
    //                File.Delete(oFilePath + "\\" + oBatchFile);
    //            }

    //            if (File.Exists(oFilePath + "\\" + oSQLStatementFile))
    //            {
    //                File.Delete(oFilePath + "\\" + oSQLStatementFile);
    //            }

    //            string strSQL = "sqlcmd -S " + ConnectionString.AssingValue("Logon_server") + " -d " + ConnectionString.AssingValue("Logon_database") + " -U " + ConnectionString.AssingValue("Logon_user_id") + " -P " + ConnectionString.AssingValue("Logon_password") + " -i " + oFilePath + "\\" + oSQLStatementFile + " -o " + oFilePath + "\\" + oOutputFile;

    //            using (StreamWriter oStreamBatch = File.CreateText(oFilePath + "\\" + oBatchFile))
    //            {
    //                oStreamBatch.WriteLine("");
    //                oStreamBatch.WriteLine(strSQL);
    //                oStreamBatch.WriteLine("");
    //                oStreamBatch.WriteLine(oFilePath + "\\" + "ERP_EXPORT.EXE " + PKID);
    //                oStreamBatch.WriteLine("EXIT");
    //            }
    //            string str2;
    //            if (Type == "CLIENT")
    //            {
    //                str2 = "EXEC USP_ACC_MIS_CLIENTPROFITABILITY_EXE '" + PKID + "'," + SqlQueryPARA;
    //            }
    //            else
    //            {
    //                str2 = "EXEC USP_ACC_MIS_CLIENTPROFITABILITY_EXE_AGENT '" + PKID + "'," + SqlQueryPARA;
    //            }


    //            using (StreamWriter oStreamSQL = File.CreateText(oFilePath + "\\" + oSQLStatementFile))
    //            {
    //                oStreamSQL.WriteLine("");
    //                oStreamSQL.WriteLine(str2);
    //                oStreamSQL.WriteLine("");
    //            }

    //            Process proc_BATCH = new Process();
    //            proc_BATCH.StartInfo.FileName = oFilePath + "\\" + oBatchFile;
    //            proc_BATCH.Start();

    //        }
    //        return PKID;
    //    }
    //    finally
    //    {
    //        PKID = null;
    //        path = null;
    //    }


    //}


}