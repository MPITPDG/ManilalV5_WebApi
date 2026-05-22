using Manilal_V5NG.BaseBLL;
using Manilal_V5NG.Models;
using Manilal_V5NG.Controllers.CommonBLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mail;
using System.Text;
using System.Web;
using System.IO;
using System.Xml.Xsl;
using System.Xml;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Manilal_V5NG.Controllers
{
    public class EdiController : ApiController
    {

        /// <summary>Perform TXT HYC AUTO APPROVAL ORDERS records.</summary>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage EDI_TXT_HYC_AUTO_APPROVAL_ORDERS()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;

            //strSpName = "Usp_Export_Shipment_Status_New";

          
           
                strXslFilename = "xsl_EDI_HAPPYCHIC_FORWARDER_SHIPMENT_APPROVAL.xsl";
           

            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EDI_TXT_HYC_AUTO_APPROVAL_ORDERS");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Edi", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = ds.Tables[0].Rows[0]["FILENAMET"].ToString() + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        /// <summary>Search and retrieve HAPPYCHIC SEARCH STATUS records.</summary>
        /// <param name="SearchType">Search type/column identifier.</param>
        /// <param name="Value">Search filter value.</param>
        /// <param name="Value1">Search filter value.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult EDI_HAPPYCHIC_SEARCH_STATUS(string SearchType, string Value, string Value1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EDI_HAPPYCHIC_SEARCH_STATUS", SearchType, Value, (Value1 != null) ? Value1 : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Edi/EDI_HAPPYCHIC_SEARCH_STATUS");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve list of HAPPYCHIC PENDING records.</summary>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult EDI_HAPPYCHIC_PENDING_LIST(string Mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EDI_HAPPYCHIC_CONT_MAWBNO_PENDING_LIST", Mode);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Edi/EDI_HAPPYCHIC_PENDING_LIST");
            }
            return Ok(ds);
        }
    }
}
