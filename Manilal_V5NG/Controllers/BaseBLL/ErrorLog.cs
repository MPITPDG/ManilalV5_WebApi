using Manilal_V5NG.BaseBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Manilal_V5NG.BaseBLL
{
    public class ErrorLog
    {
        /// <summary>HttpContext.Items key under which Error() stashes the last exception message, so a controller can report the real cause instead of an empty DataSet.</summary>
        public const string LastErrorKey = "ErrorLog.LastErrorMessage";

        public static DataSet Error(Exception errortype, string url)
        {
            DataSet ds = new DataSet();
            try
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Items[LastErrorKey] = errortype.Message;
                }
                DataTable table = new DataTable();
                table.Columns.Add("STATUS", typeof(int));
                table.Columns.Add("STATUSTEXT", typeof(string));
                table.Columns.Add("url", typeof(string));
                table.Rows.Add(101, errortype.Message, url);
                ds.Tables.Add(table);
                ds.Tables[0].TableName = "Table";
                //dalObjUser.ExecuteDataset(constr, CommandType.StoredProcedure, "USP35_Error_Log", errortype, remoteaddr, optional, message, stacktrace);
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }

        public static DataSet ConvertStringToDataset(string message)
        {
            DataSet ds = new DataSet();
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("STATUS", typeof(string));
                table.Rows.Add(message);
                ds.Tables.Add(table);
                ds.Tables[0].TableName = "Table";
                //dalObjUser.ExecuteDataset(constr, CommandType.StoredProcedure, "USP35_Error_Log", errortype, remoteaddr, optional, message, stacktrace);
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }

        public static DataTable UserRights(string pMode, string formId, string codeCity, string entryDate)
        {
            DataTable table = new DataTable();
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                table.TableName = "VerifyRight";
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "usp_GetUserRightsForForms", pMode, formId, codeCity, entryDate);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    table = ds.Tables[0];
                }
                else if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    table = ds.Tables[0];
                    table.Merge(ds.Tables[1], false);
                }
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return table;
        }

        public static DataSet Success(string Status, string Message)
        {
            DataSet ds = new DataSet();
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("STATUS", typeof(int));
                table.Columns.Add("statusText", typeof(string));
                table.Rows.Add(101, Message);
                ds.Tables.Add(table);
                ds.Tables[0].TableName = "Table";
                //dalObjUser.ExecuteDataset(constr, CommandType.StoredProcedure, "USP35_Error_Log", errortype, remoteaddr, optional, message, stacktrace);
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
    }
}