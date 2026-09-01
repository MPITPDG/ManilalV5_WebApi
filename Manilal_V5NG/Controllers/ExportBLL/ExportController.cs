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

namespace Manilal_V5NG.Controllers.ExportBLL
{
    public class ExportController : ApiController

    {
        // upload (parsed order lines + submit state) when the popup is reopened.
        [HttpGet]
        public IHttpActionResult PackingListUploadGet([FromUri] string exptno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PL_UPLOAD_GET",
                    exptno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PackingListUploadGet");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        [HttpPost]
        public IHttpActionResult PackingListUploadSave([FromBody] PlUploadLine obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PL_UPLOAD_SAVE",
                    string.IsNullOrEmpty(obj.Mode) ? "S" : obj.Mode,
                    obj.ExptNo ?? "", obj.OrderNo ?? "", obj.StyleNo ?? "", obj.Concode ?? "",
                    obj.FileName ?? "", obj.OrderJson ?? "", obj.SubmitState ?? "pending", obj.MakerId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PackingListUploadSave");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        // Store / fetch the uploaded packing-list PDF so "View PDF" also works in
        // a restored session. FILEDATA (varbinary) serialises to base64 in JSON.
        [HttpPost]
        public IHttpActionResult PackingListUploadFileSave([FromBody] PlUploadFile obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                byte[] bytes = Convert.FromBase64String(obj.FileBase64 ?? "");
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PL_UPLOAD_FILE_IU",
                    obj.FileName ?? "", bytes, obj.MakerId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PackingListUploadFileSave");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult Exp_Booking_OrderNo_Authorisation(string cmpid, string cmp_code, string RoleType)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_ORDERNO_BOOKING_AUTHORISATION", cmpid, cmp_code, RoleType);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/Exp_Booking_OrderNo_Authorisation");
            }
            return Ok(ds);
        }

        [HttpPost]
        public IHttpActionResult Exp_Booking_OrderNo_Authorisation_SaveUpdate([FromBody] Bookingauthorisation ba)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_ORDERNO_BOOKING_AUTHORISATION_ASSIGN", ba.cmp_code, ba.citycode, ba.OrdStylestr, ba.CHKAuthorityFlag, ba.cmpid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/Exp_Booking_OrderNo_Authorisation_SaveUpdate");
            }
            return Ok(ds);
        }
        [HttpGet]
        public IHttpActionResult PackingListUploadFileGet([FromUri] string filename)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PL_UPLOAD_FILE_GET",
                    filename);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PackingListUploadFileGet");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        [HttpPost]
        public IHttpActionResult OrderSizeDetailsSubmitPakingList([FromBody] OrderSizeDeatils obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_ORDER_SIZE_DET_IU_UPLOADPACKINGLIST",
                    obj.ExptNo, obj.Concode, obj.OrderNo, obj.StyleNo, obj.TotalPackage, obj.Str, obj.MakerId, obj.MakerIp,
                    string.IsNullOrEmpty(obj.Source) ? "MANUAL" : obj.Source,
                    obj.FileName ?? "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderSizeDetailsSubmitPakingList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve GetExportConsignmentNew records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult GetExportConsignmentNew([FromBody] ConsignmentDetails cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_FILLDROPDOWN_NEW", cd.citycode, cd.cmpcode, cd.cmpid); //USP_ASP_EXP_NEW_EXPORT_CONSIGNMENT_PAGELOAD
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/GetExportConsignmentNew");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform UpdateJob records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateJob([FromBody] Main cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_JOB_UPDATE",
                    cd.PkId, cd.exptno, cd.expt_mode, cd.expt_exporter, cd.expt_billto, cd.expt_consignee,
                     cd.expt_buyer, cd.Agent, cd.SubAgent, cd.SeviceType, cd.expt_vessel, cd.expt_noofpkgs, cd.expt_typeofpkgs,
                     cd.expt_noofpcs, cd.expt_typeofpcs, cd.grosswt, cd.netwt, cd.volume, cd.chblwt, cd.invno, cd.invdate, cd.docrecddt,
                     cd.incoterm, cd.freight, cd.shipbilltype, cd.pol, cd.CmpId, cd.MakerIp, cd.CMPCODE, cd.CITYCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateJob");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Insert or update EXPT SHIPMENTPROGRESS BLDETAILS records.</summary>
        /// <param name="bl">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult EXPT_SHIPMENTPROGRESS_BLDETAILS_UPDATE([FromBody] bldetails bl)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_BL_UPDATE", bl.BLNO, bl.BLDATE, bl.BLTYPE, bl.CMPCODE, bl.CITYCODE, bl.STR);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/EXPT_SHIPMENTPROGRESS_BLDETAILS_UPDATE");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform EXPT SHIPMENT PROGRESS GETBLDATA records.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="EXPT_VESSEL">EXPT VESSEL parameter.</param>
        /// <param name="VSL_PORT">VSL PORT parameter.</param>
        /// <param name="BLNO">Bill of lading number.</param>
        /// <param name="BLDATE">BLDATE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult EXPT_SHIPMENT_PROGRESS_GETBLDATA(String CMPCODE, String CITYCODE, String EXPT_VESSEL, String VSL_PORT, String BLNO, String BLDATE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXPT_SHIPMENT_PROGRESS_GETBLDATA", CMPCODE, CITYCODE, EXPT_VESSEL, VSL_PORT, (BLNO != null) ? BLNO : "", (BLDATE != null) ? BLDATE : "");
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/EXPT_SHIPMENT_PROGRESS_GETBLDATA");
            }
            return Ok(ds);
        }

        /// <summary>Perform ExportEditCo2Update records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportEditCo2Update([FromBody]ActualFlightDate cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(
                    ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EDIT_CO2_UPDATE",
                    cd.ExptNo, cd.Co2EmissionLevel, cd.CmpCode, cd.Citycode, cd.MakerId);
                var message = string.Empty;
                var sub = string.Empty;
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportEditCo2Update");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve GetExportConsignment records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult GetExportConsignment([FromBody]ConsignmentDetails cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_FILLDROPDOWN", cd.citycode, cd.cmpcode); //USP_ASP_EXP_NEW_EXPORT_CONSIGNMENT_PAGELOAD
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/GetExportConsignment");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform OrderBookingList records.</summary>
        /// <param name="Concode">Concode parameter.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="Citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult OrderBookingList([FromUri]string Concode, string Mode, string Citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_ORDER_BOOKING_LIST", Concode, Mode, Citycode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderBookingList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform OrderNoQcList records.</summary>
        /// <param name="exptno">Export job number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult OrderNoQcList([FromUri]string exptno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ASP_EXPT_ORDER_QCCHECKING_GET", exptno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderNoQcList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform OrderNoQcListSubmit records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult OrderNoQcListSubmit([FromBody]CommonFour obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ASP_EXPT_ORDER_QCCHECKING_IU",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4);        // TempString, ExptNo, MakerId, MakerIp
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderNoQcListSubmit");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


        /// <summary>Retrieve GetMainConsignment records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult GetMainConsignment([FromBody]MainConsignmentDetails obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_MAIN_FILLDROPDOWN", obj.mode, obj.concode, obj.vesselcode, obj.vesselport, obj.citycode, obj.cmpid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/GetMainConsignment");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve GetMainConsignmentOrderList records.</summary>
        /// <param name="concode">concode parameter.</param>
        /// <param name="expcode">expcode parameter.</param>
        /// <param name="exptmode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetMainConsignmentOrderList([FromUri]string concode, string expcode, string exptmode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXPT_CONSIGNMENT_ORDER_BOOKING_LIST", concode, expcode, exptmode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/GetMainConsignmentOrderList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        //---------------------vessel master

        /// <summary>Retrieve dropdown data for GetExportVslpageload records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult GetExportVslpageload_fill([FromBody]ConsignmentDetails cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_VSL_PAGELOAD_FILL");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/GetExportVslpageload_fill");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform ExportVslPortAgtDtls TmpIu records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportVslPortAgtDtls_TmpIu([FromBody]ConsignmentDetails cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_VSL_TMPDTLS_IU", cd.TBL_INDEXID, cd.PK_PORTID, cd.VSL_RTNO, cd.ROTATION, cd.PORT, cd.ETA, cd.ARRIVAL, cd.ETD, cd.SAILING, cd.CARTING, cd.VSLDELAY, cd.NOTCALLED, cd.USERNAME, cd.cmpid, cd.GUID, cd.TBL_INDEXIDAGT, cd.PK_AGTID, (cd.VSL_AGENT != null) ? cd.VSL_AGENT : "", (cd.AGT_LINER != null) ? cd.AGT_LINER : "", cd.AGT_CARTPLACE, cd.AGT_CARTCLERK);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportVslPortAgtDtls_TmpIu");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform ExportVslPortAgtDtls Tmpdelete records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportVslPortAgtDtls_Tmpdelete([FromBody]ConsignmentDetails cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_VSL_TMPDTLS_DELETE", cd.TBL_INDEXID, cd.PK_PORTID, cd.VSL_RTNO, cd.PORT, cd.cmpid, cd.GUID, cd.TBL_INDEXIDAGT, cd.PK_AGTID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportVslPortAgtDtls_TmpIu");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Insert or update ExportVslMst records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportVslMst_IU([FromBody]ConsignmentDetails cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_VESSEL_IU", cd.PK_id, cd.VSL_RTNO, cd.VSL_NAME, cd.VSL_VOYNO, cd.VSL_NAME, cd.cmpid, cd.GUID, cd.USERNAME, cd.MAKERIP);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportVslMst_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Search and retrieve ExportVslMst records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportVslMst_Search([FromBody]ConsignmentDetails cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_VESSEL_SEARCH", cd.VSL_NAME, cd.VSL_VOYNO, cd.citycode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportVslMst_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }
        /// <summary>Populate form with existing data for ExportVslMst records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportVslMst_Populate([FromBody]ConsignmentDetails cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_VESSEL_POPULATE", cd.VSL_RTNO, cd.cmpid, cd.GUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportVslMst_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
            //------------- end of vessel 
        }

        /// <summary>Perform ExportVslMst ResetAll records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportVslMst_ResetAll([FromBody]ConsignmentDetails cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_VESSEL_RESETALL", cd.cmpid, cd.GUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportVslMst_ResetAll");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }

        //------------- end of vessel 

        //---------------------start FCR generation
        /// <summary>Load page reference data for Export FCR records.</summary>
        /// <param name="fg">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_FCR_Pageload([FromBody]FCRGeneration fg)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_PRNTDOC_FCR_PAGELOAD", fg.Citycode, fg.EXPTNO);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_FCR_Pageload");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        //---------------------start FCR generation
        /// <summary>Perform Export FCR GENERATION records.</summary>
        /// <param name="fg">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_FCR_GENERATION([FromBody]FCRGeneration fg)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_PRNTDOC_FCR_GENERATION", fg.Citycode, fg.EXPTNO, fg.jobnos, fg.POD, fg.citycode1, fg.FCRDT, fg.FRTYPE, (fg.FRTCur != null) ? fg.FRTCur : "", (fg.FRTAMT != null) ? fg.FRTAMT : "", fg.HBLType, (fg.DeliveryTo != null) ? fg.DeliveryTo : "", fg.cmpcode, fg.username, fg.FCRNO, fg.switchhbl);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_FCR_GENERATION");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform EXPORT SWICH FCR GENERATION records.</summary>
        /// <param name="fg">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult EXPORT_SWICH_FCR_GENERATION([FromBody]swichFCRGeneration fg)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_PRNTDOC_FCR_SWITCHBL_GENERATION", fg.FCRNO, fg.CITYCODE1, fg.CMPCODE, fg.CITYCODE, fg.USERNAME);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/EXPORT_SWICH_FCR_GENERATION");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform Export FCR PRINTPREVIEW records.</summary>
        /// <param name="fg">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_FCR_PRINTPREVIEW([FromBody]FCRGeneration fg)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_PRNTDOC_FCR_PRINTVIEW", fg.FCRNO);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_FCR_PRINTPREVIEW");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Load the FCR / HBL / MTO final print document details for the HTML print page.</summary>
        /// <param name="fcrno">FCR / House B/L / MTO number.</param>
        /// <param name="cmpid">Logged in user id, used to key the print staging tables.</param>
        /// <param name="printtype">SeaWay Bill flag ("1" seaway bill, "0" or empty otherwise).</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult EXP_PRNTDOC_FCR_PRINT_CRYPRNT(String fcrno, String cmpid, String printtype)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_PRNTDOC_FCR_PRINTVIEW_CRYPRNT",
                    fcrno, cmpid, (printtype != null) ? printtype : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/EXP_PRNTDOC_FCR_PRINT_CRYPRNT");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform Export FCR PRINTUPDATE records.</summary>
        /// <param name="fp">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_FCR_PRINTUPDATE([FromBody]FCRPrintview fp)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_PRNTDOC_FCR_PRINTUPDATE", fp.SHIPPER, fp.CONSIGNEE,
                    fp.NOTIFYPARTY, (fp.CARRIER != null) ? fp.CARRIER : "", (fp.APPLYTO != null) ? fp.APPLYTO : "", (fp.VESSEL != null) ? fp.VESSEL : "",
                    (fp.POL != null) ? fp.POL : "", (fp.POD != null) ? fp.POD : "", (fp.PODEL != null) ? fp.PODEL : "", (fp.MARKSANDNOS != null) ? fp.MARKSANDNOS : "",
                    (fp.NOOFPKGS != null) ? fp.NOOFPKGS : "", (fp.ITCDESC != null) ? fp.ITCDESC : "", (fp.GRWT != null) ? fp.GRWT : "", (fp.VOL != null) ? fp.VOL : "",
                     (fp.MISC != null) ? fp.MISC : "", (fp.PLACEDATE != null) ? fp.PLACEDATE : "", (fp.PP != null) ? fp.PP : "", (fp.CC != null) ? fp.CC : "",
                     (fp.TOTPP != null) ? fp.TOTPP : "", (fp.TOTCC != null) ? fp.TOTCC : "", (fp.RECPTPLACE != null) ? fp.RECPTPLACE : "", fp.EXPNO, fp.FCRNo, fp.UERNAME, fp.CITYCODE, (fp.rider != null) ? fp.rider : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_FCR_PRINTUPDATE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        //---------------------END UP TO FCR.MTO PRINTING 
        //START CONTAINER GENERATION


        /// <summary>Retrieve list of Export Vessel records.</summary>
        /// <param name="vsl">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_Vessel_List([FromBody]vslSearch vsl)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_VESSEL_LIST", vsl.SEARCHMODE, vsl.VSLNAME, vsl.VSL_VOY, vsl.CITYCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_Vessel_List");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Retrieve print/view data for Export container records.</summary>
        /// <param name="CN">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_container_View([FromBody]container CN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CONTAINER_VIEW", CN.vsl_rtno, CN.Port);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_container_View");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform Export container filldropdown records.</summary>
        /// <param name="CN">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_container_filldropdown([FromBody]container CN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CONTAINER_FILLDROPDOWN", CN.vsl_rtno, CN.Port);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_container_filldropdown");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Populate form with existing data for Export container records.</summary>
        /// <param name="CN">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_container_Populate([FromBody]container CN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CONTAINER_POPULATE", CN.ContainerID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_container_Populate");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update Export container records.</summary>
        /// <param name="CN">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_container_IU([FromBody]containerIU CN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_CONTAINER_IU", CN.ContainerID, CN.vsl_rtno, CN.EXPT_AGENT, CN.CONTAINERNO, CN.CONTAINERSIZE, CN.CONTAINERSIZE1, CN.CONTAINERSTATUS, CN.DESTPORT, CN.AGTSEALNO, CN.HSTUFFED, CN.STUFFWHERE, CN.CUSTSEALNO, CN.FREIGHTUSD, CN.BAFUSD, CN.STUFFWHERE1, CN.STUFFWHERE2, CN.STUFFINGCITY, CN.REMARK, CN.FREIGHT, CN.LINERCONTRACT, CN.THCINR, CN.OCUR1, CN.OCURRATE1, CN.OCUR2, CN.OCURRATE2, CN.DCUR1, CN.DCURRATE1, CN.DCUR2, CN.DCURRATE2, CN.FREIGHTCUR, CN.BAFCUR, CN.THCNAME, CN.THCCUR, CN.OTHERNAME, CN.OTHERCUR, CN.OTHERAMT, CN.SHPGLINE, CN.Port, CN.MOVETYPE, CN.BCARRIERNO, CN.BCARRIERDT, CN.cmpid, CN.CITYCODE, CN.cmpcode, CN.contract, (CN.CO2_Emission_Level == null) ? "0" : CN.CO2_Emission_Level);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_container_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        //
        /// <summary>Populate form with existing data for Export containerCLP records.</summary>
        /// <param name="CN">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_containerCLP_Populate([FromBody]containerIU CN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CONTAINER_CLP_VIEW", CN.vsl_rtno, CN.Port, CN.CONTAINERNO, CN.EXPT_AGENT, CN.GUID, "VIEW", CN.cmpcode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_containerCLP_Populate");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        //--------------------------------------------------START Consignment-------------------------------------------------------------
        //--------------Start Package No
        /// <summary>Perform ConsignmentPackage records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentPackage([FromBody]Package cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_Exp_Mst_Export_Package_IUD", cd.indexid, cd.pkgnoid, cd.exptno, cd.pkgtype, cd.pkgfrom, cd.pkgto, cd.pkgalphabet, cd.userid, cd.guid); //USP_ASP_EXP_NEW_EXPORT_CONSIGNMENT_PAGELOAD
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentPackage");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //--------------End Package No

        //--------------Start ITC
        /// <summary>Perform ConsignmentITC records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentITC([FromBody]Itc cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_Exp_Mst_Export_ITC_IUD", cd.itctype, cd.hditccodeid, cd.hdexptno, cd.itccode, cd.itcfobinr, cd.itcsrno, cd.itcunitone, cd.itctypeone, cd.itcnotice, cd.itcconditionno, cd.itcunittwo, cd.itctypetwo, cd.itcpercent, cd.itcpercenta, cd.itcperunit, cd.dbkamt, cd.itcgroupcode, cd.itcdescription, cd.userid, cd.hditcid, cd.guid, cd.hditcdescid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentITC");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //--------------End ITC

        //--------------Start Order
        /// <summary>Perform ConsignmentOrder records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentOrder([FromBody]Order cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_Exp_Mst_Export_OrderNo_IUD", cd.ordertype, cd.ordernoid, cd.orderid, cd.exptno, cd.orderno, cd.orderpiece, cd.ordertypeofpiece, cd.orderwarehouse, cd.orderpackage, cd.ordergrwt, cd.ordervolume, cd.ordernetwt, cd.orderchblwt, cd.orderitemdesc, cd.orderlsddt, cd.orderreferenceno, cd.orderfobval, cd.ordercurrency, cd.orderdrndt, cd.userid, cd.guid, cd.ordercneedept, cd.ordercontainerno, cd.ordericshscode, cd.ordericshsdescription, cd.concode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentOrder");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //--------------End Order
        //--------------Start Final Submit
        /// <summary>Insert or update Mst Export records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Exp_Mst_Export_IU([FromBody]Consignment cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_IU",
                    cd.Exptno, cd.Expt_Guid, cd.Expt_Mode, cd.Expt_Exporter, cd.Expt_Billto, cd.Expt_Consignee, cd.Expt_Docrecd,
                    cd.Expt_Ldgport, cd.Expt_Grino, cd.Expt_Gridate, cd.Expt_Invno, cd.Expt_Invdate, cd.Expt_Invtype, cd.Expt_Cur,
                    cd.Expt_Curname, cd.Expt_Currate, cd.Expt_Curinrrate, cd.Expt_Invamt, cd.Expt_Insamt, cd.Expt_Freight,
                    cd.Expt_Fob, cd.Expt_Shipbilltype, cd.Expt_Noofpkgs, cd.Expt_Typeofpkgs, cd.Expt_Noofpcs, cd.Expt_Typeofpcs,
                    cd.Expt_Grwt, cd.Expt_Netwt, cd.Expt_Volume, cd.Expt_Mktvalue, cd.Expt_Vessel, cd.Expt_Vslagent, cd.Expt_Pod,
                    cd.Expt_It, cd.Expt_Destcity, cd.Expt_Destcountry, cd.Expt_Frt, cd.Expt_Remarks, cd.Citycode, cd.Cmpcode,
                    cd.Invcommission, cd.Invdiscount, cd.Invdeductamt, cd.Invdeductdesc, cd.Implable, cd.Billentryno, cd.Billentrydt,
                    cd.Sbvalue, cd.Sbamount, cd.Sbbooktype, cd.Arformno, cd.Arformdt, cd.Sbprorecptno, cd.Sbprorecptdt, cd.Sbexempt1,
                    cd.Sbexempt2, cd.Sbexempt3, cd.Sbdeecbookno, cd.Sbdeecbookdt, cd.Sbdeeclicno, cd.Sbgroupcode, cd.Sbsionno, cd.Sbexpbookno,
                    cd.Sbexpbookdt, cd.Sbduty, cd.Sbdutyamt, cd.Sbcess, cd.Notifybuyer, cd.Expt_Buyer, cd.Natureofpayment, cd.Expt_Packing,
                    cd.Commname, cd.Commaddr1, cd.Commaddr2, cd.Commissionrate, cd.Division, cd.Range, cd.Arformno1, cd.Arformdt1,
                    cd.Commissionrate1, cd.Division1, cd.Range1, cd.Arformno2, cd.Arformdt2, cd.Commissionrate2, cd.Division2, cd.Range2,
                    cd.Arformno3, cd.Arformdt3, cd.Commissionrate3, cd.Division3, cd.Range3, cd.Exptcontractno, cd.Periodofpayment,
                    cd.Expt_Quotavaliddt, cd.Expt_Quotaobtaindt, cd.Expt_Quotaexpirydt, cd.Manufacturer, cd.Quotacertno, cd.Quotacertno1,
                    cd.Quotacertno2, cd.Yr, cd.Expt_Grwtshipper, cd.Expt_Volumeshipper, cd.Expt_Cartplace, cd.Expt_Bank, cd.Expt_Srcagt,
                    cd.Expt_Chblwt, cd.Vsl_Port, cd.Username, cd.Id, cd.Citycode1, cd.Recddocstr, cd.Calldocstr, cd.Cartdate, cd.Prealertdate,
                    cd.Airlinename, cd.Planflightno, cd.Planflightdate, cd.Actflightno, cd.Actflightdate, cd.Mawbdest, cd.Mawbfrt, cd.Tranport1,
                    cd.Flightno1, cd.Etd1, cd.Eta1, cd.Tranport2, cd.Flightno2, cd.Etd2, cd.Eta2, cd.Mawbno, cd.Mawbdate, cd.Hawbno, cd.Hawbdate,
                    cd.Marks1, cd.Marks2, cd.Marks3, cd.Marks4, cd.Marks5, cd.Marks6, cd.Marks7, cd.Marks8, cd.Marks9, cd.Marks10, cd.Marks11,
                    cd.Marks12, cd.Marks13, cd.Marks14, cd.Marks15, cd.Makerip, cd.Isdiffair, cd.Exwork, cd.Customclr, cd.Freightfrd, cd.ActualDocReceived, cd.SubAgentId, cd.agentid,
                    cd.MODEOF_SHIPMENT, cd.FK_TERMINALID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Exp_Mst_Export_IU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ExportLogCompleted records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportLogCompleted([FromBody]ConsignmentLogCompleted obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_LOG_COMPLETE",
                    obj.status, obj.pagetype, obj.guid, obj.cmpid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportLogCompleted");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //--------------End Final Submit

        //--------------Start Order
        /// <summary>Perform ConsignmentSearchFillDropdown records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentSearchFillDropdown([FromBody]Search cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_SEARCH_FILL_DROPDOWN", cd.Type, cd.VslName, cd.VoyageNo);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentSearchFillDropdown");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //--------------End Order
        //--------------Start Search Shipper Consignee
        /// <summary>Perform ConsignmentSearchShipperConsignee records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentSearchShipperConsignee([FromBody]Search cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_SEARCH_FILL_SHIPPER_CONSIGNEE", cd.Type, cd.VslName, cd.VoyageNo);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentSearchShipperConsignee");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //--------------End Search Shipper Consignee
        //--------------Start Search Shipper Consignee List
        /// <summary>Perform ConsignmentSearchList records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentSearchList([FromBody]CommonSearch cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_SEARCH_LIST", cd.Type1, cd.Type2, cd.Type3, cd.Type4);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentSearchList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //--------------End Search Shipper Consignee List
        //--------------Start Edit Search
        /// <summary>Perform ConsignmentEditSearchView records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentEditSearchView([FromBody]CommonSearch cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_SEARCH_VIEW", cd.Type1, cd.Type2);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentEditSearchView");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //--------------End Edit Search
        //--------------Start Edit Fill Details
        /// <summary>Perform ConsignmentEditFillDetail records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentEditFillDetail([FromBody]CommonSearch cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_FILL_DETAILS", cd.Type1, cd.Type2, cd.Type3, cd.Type4, cd.Type5);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentEditFillDetail");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //--------------End Edit Fill Details
        /// <summary>Perform ExportEditActualFlightDateData records.</summary>
        /// <param name="ExptNo">Export job number.</param>
        /// <param name="Citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ExportEditActualFlightDateData([FromUri]string ExptNo, string Citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EDIT_ACTUAL_FLIGHT_DATE_DATA", ExptNo, Citycode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportEditActualFlightDateData");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform ExportEditActualFlightDateUpdate records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportEditActualFlightDateUpdate([FromBody]ActualFlightDate cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(
                    ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EDIT_ACTUAL_FLIGHT_DATE_UPDATE",
                    cd.ExptNo, cd.SubAgent, cd.Co2EmissionLevel, cd.MAWBDEST, cd.MAWBFRT, cd.TRAPORT1, cd.FLTNO1, cd.ETD1, cd.ETA1, cd.TRAPORT2, cd.FLTNO2, cd.ETD2, cd.ETA2, cd.CmpCode, cd.Citycode, cd.MakerId, cd.ActualFlightNo, cd.ActualFlightDt);
                var message = string.Empty;
                var sub = string.Empty;
                if (ds.Tables[0].Rows[0][1].ToString() == "MAIL")
                {
                    message = "FLIGHT NO : " + ds.Tables[0].Rows[0]["FLIGHTNO"].ToString() + "- " + ds.Tables[0].Rows[0]["ACTUALFLIGHTDT"].ToString() + "\n" +
                               "MAWBNO : " + ds.Tables[0].Rows[0]["AEROBILLNO"].ToString() + "\n" +
                                "CONSIGNEE :" + ds.Tables[0].Rows[0]["CONSIGNEE"].ToString() + "\n" +
                                   "DESTINATION  :" + ds.Tables[0].Rows[0]["EXPT_POD"].ToString() + "\n" +
                                   "ETA HAS BEEN MODIFIED FROM " + ds.Tables[0].Rows[0]["OLDETA"].ToString() + " TO " +
                                    ds.Tables[0].Rows[0]["ETA"].ToString() + " By" + ds.Tables[0].Rows[0]["cmp_name"].ToString();
                    sub = "MAWBNO : " + ds.Tables[0].Rows[0]["AEROBILLNO"].ToString() + " AIR ETA MODIFIED";

                    // Send_Mail("admin@manilal.net", "nisha@manilal.com", "", "nisha@manilal.com;sujit@manilal.com", "Arrival Entered", message);
                    common_sendmail(message, ds.Tables[0].Rows[0]["IPADDS"].ToString(), ds.Tables[0].Rows[0]["FROMMAIL"].ToString(), ds.Tables[0].Rows[0]["TO"].ToString(), ds.Tables[0].Rows[0]["CC"].ToString(), ds.Tables[0].Rows[0]["BCC"].ToString(), ds.Tables[0].Rows[0]["PWD"].ToString(), sub);

                }



            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportEditActualFlightDateUpdate");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        //--------------Start Edit Fill Details
        /// <summary>Perform SourceAgent records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult SourceAgent([FromBody]CommonSearch cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_SRCAGT_FILLDROPDOWN", cd.Type1, cd.Type2);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/SourceAgent");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PortGoods FillDropDown records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PortGoods_FillDropDown([FromBody]CommonSearch cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_PORTGOODS_FILLDROPDOWN", cd.Type1, cd.Type2, cd.Type3, cd.Type4);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PortGoods_FillDropDown");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AirShipment Show OtherExptNo records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult AirShipment_Show_OtherExptNo([FromBody]CommonSearch cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_AIRSHIPMENT_SHOW_OTHEREXPTNO", cd.Type1, cd.Type2);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AirShipment_Show_OtherExptNo");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdateMarksNumber records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateMarksNumber([FromBody]CommonSearch cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_UPDATE_MARKS_NUMBERS", cd.Type1, cd.Type2, "", "", "", "", "", "", "", "", "", "", "", "", "", "", cd.Type3, cd.Type4);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateMarksNumber");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdateDocument records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateDocument([FromBody]CommonEight cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_UPDATE_DOCUMENTS", cd.Type1, cd.Type2, cd.Type3, cd.Type4, cd.Type5, cd.Type6, cd.Type7, cd.Type8);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateDocument");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ConsigneeView records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsigneeView([FromBody]CommonThree cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_CONSIGNMENT", cd.Type1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsigneeView");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdateConsigneeRemark records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateConsigneeRemark([FromBody]CommonFive cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_UPDATE_CONREMARK", cd.Type1, cd.Type2, cd.Type3, cd.Type4, cd.Type5);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateConsigneeRemark");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdateQuota records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateQuota([FromBody]CommonTen cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_UPDATE_QUOTA", cd.Type1, cd.Type2, cd.Type3, cd.Type4, cd.Type5, cd.Type6, cd.Type7, cd.Type8, cd.Type9, cd.Type10);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateQuota");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdatePackage records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdatePackage([FromBody]CommonFour cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_UPDATE_PKGNO", cd.Type1, cd.Type2, cd.Type3, cd.Type4);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdatePackage");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdateOrder records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateOrder([FromBody]CommonSix cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_UPDATE_ORDERNO", cd.Type1, cd.Type2, cd.Type3, cd.Type4, cd.Type5, cd.Type6);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateOrder");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdateITC records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateITC([FromBody]CommonFour cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_UPDATE_ITC", cd.Type1, cd.Type2, cd.Type3, cd.Type4);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateITC");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdateShipmentClr records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateShipmentClr([FromBody]CommonSeven cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_UPDATE_CLEARANCE", cd.Type1, cd.Type2, cd.Type3, cd.Type4, cd.Type5, cd.Type6, cd.Type7);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateShipmentClr");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform InvoiceFillDropdown records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult InvoiceFillDropdown([FromBody]CommonThree cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_INVOICE_FILLDROPDOWN");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/InvoiceFillDropdown");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdateInvoice records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateInvoice([FromBody]Consignment cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_UPDATE_INVOICE",
                    cd.PKID, cd.Exptno, cd.Expt_Docrecd,
                    cd.Expt_Grino, cd.Expt_Gridate, cd.Expt_Invno, cd.Expt_Invdate, cd.Expt_Cur,
                    cd.Expt_Curname, cd.Expt_Currate, cd.Expt_Curinrrate, cd.Expt_Invtype, cd.Expt_Invamt, cd.Expt_Freight, cd.Expt_Insamt,
                    cd.Invdiscount, cd.Expt_Packing, cd.Invcommission, cd.Commname, cd.Commaddr1, cd.Commaddr2, cd.Natureofpayment,
                    cd.Invdeductamt, cd.Invdeductdesc, cd.Expt_Fob, cd.Expt_Mktvalue, cd.Expt_Shipbilltype,
                    cd.Sbvalue, cd.Sbamount, cd.Sbbooktype, cd.Sbprorecptno, cd.Sbprorecptdt, cd.Sbdeecbookno, cd.Sbdeecbookdt, cd.Sbdeeclicno,
                    cd.Sbexpbookno, cd.Sbexpbookdt, cd.Sbexempt1, cd.Sbexempt2, cd.Sbexempt3,
                    cd.Sbgroupcode, cd.Sbsionno, cd.Sbduty, cd.Sbdutyamt, cd.Sbcess, cd.Implable, cd.Billentryno, cd.Billentrydt,
                    cd.Arformno, cd.Arformdt, cd.Commissionrate, cd.Division, cd.Range,
                    cd.Arformno1, cd.Arformdt1, cd.Commissionrate1, cd.Division1, cd.Range1,
                    cd.Arformno2, cd.Arformdt2, cd.Commissionrate2, cd.Division2, cd.Range2,
                    cd.Arformno3, cd.Arformdt3, cd.Commissionrate3, cd.Division3, cd.Range3,
                    cd.CmpId, cd.MakerIp, cd.Expt_Frt);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateInvoice");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve FillAgentDropdown records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult FillAgentDropdown([FromBody]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_MST_EXPORT_UPDATE_PORT_FILL_AGENT", obj.Type1, obj.Type2);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/FillAgentDropdown");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdatePort records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdatePort([FromBody]Consignment cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_UPDATE_PORT",
                    cd.PKID, cd.Exptno, cd.Expt_Mode, cd.Vsl_Code, cd.Vsl_Port, cd.Expt_Vslagent, cd.Cartdate,
                    cd.Prealertdate, cd.Airlinename, cd.Planflightno, cd.Planflightdate, cd.Actflightno, cd.Actflightdate,
                    cd.Mawbdest, cd.Mawbfrt, cd.Tranport1,
                    cd.Flightno1, cd.Etd1, cd.Eta1, cd.Tranport2, cd.Flightno2, cd.Etd2, cd.Eta2, cd.Mawbno, cd.Mawbdate, cd.Hawbno, cd.Hawbdate,
                    cd.Expt_Ldgport, cd.Expt_Cartplace, cd.Expt_Pod, cd.Expt_It, cd.Expt_Destcity, cd.Expt_Destcountry, cd.Expt_Grwtshipper,
                    cd.Expt_Volumeshipper, cd.Expt_Grwt, cd.Expt_Netwt, cd.Expt_Volume, cd.Expt_Frt, cd.Expt_Chblwt, cd.Expt_Remarks,
                    cd.Expt_Noofpkgs, cd.Expt_Typeofpkgs, cd.Expt_Noofpcs, cd.Expt_Typeofpcs, cd.CmpId, cd.MakerIp, (cd.FK_TERMINALID != null) ? cd.FK_TERMINALID : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdatePort");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


        //
        /// <summary>Perform UpdateMain records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateMain([FromBody]Main cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_UPDATE_MAIN",
                    cd.PkId, cd.exptno, cd.expt_mode, cd.expt_exporter, cd.expt_billto, cd.manufacturer, cd.expt_consignee,
                    cd.expt_bank, cd.notifybuyer, cd.expt_buyer, cd.expt_srcagt, cd.CmpId, cd.MakerIp);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateMain");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


        /// <summary>Perform ConsignmentView records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentView([FromBody]CommonThree cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_VIEW_CONSIGNMENT", cd.Type1, cd.Type2);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentView");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PageConsignmentView records.</summary>
        /// <param name="exptno">Export job number.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PageConsignmentView([FromUri]string exptno, int cmpid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_VIEW_CONSIGNMENT", exptno, cmpid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PageConsignmentView");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ConsignmentInvoiceView records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentInvoiceView([FromBody]CommonThree cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_VIEW_CONSIGNMENT_INVOICE", cd.Type1, cd.Type2, cd.Type3);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentInvoiceView");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ConsignmentChronologyView records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentChronologyView([FromBody]CommonThree cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_VIEW_CONSIGNMENT_CHRONOLOGY", cd.Type1, cd.Type2, cd.Type3);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentChronologyView");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform UpdateCancelshipment records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UpdateCancelshipment([FromBody]CommonThree cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_UPDATECANCEL", cd.Type1, cd.Type2, cd.Type3, cd.RoleType);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/UpdateCancelshipment");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


        /// <summary>Perform ConsignmentCLPView records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentCLPView([FromBody]CommonFive cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_VIEW_CONSIGNMENT_CLP", cd.Type1, cd.Type2, cd.Type3, cd.Type4, cd.Type5);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentCLPView");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ConsignmentMAWBFill DROPDOWN records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsignmentMAWBFill_DROPDOWN([FromBody]CommonThree cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_MAWB_FILL_DROPDOWN", cd.Type1, cd.Type2);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentMAWBFill_DROPDOWN");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve print/view data for Consignment MAWB PP CC records.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Consignment_MAWB_PP_CC_View([FromBody]CommonThree cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_MAWB_PP_CC_VIEW", cd.Type1, cd.Type2, cd.Type3, cd.GUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Consignment_MAWB_PP_CC_View");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update MST EXPORT MAWB PP CC records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult EXP_MST_EXPORT_MAWB_PP_CC_UPDATE([FromBody]MawbRating obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_MAWB_PP_CC_UPDATE",
                    obj.EXPTNO, obj.MAWBNO, obj.CITYCODE, (obj.CHBL_WGT != null) ? obj.CHBL_WGT : "", (obj.GROSS_WGT != null) ? obj.GROSS_WGT : "", (obj.CHBL_WGT_USER != null) ? obj.CHBL_WGT_USER : "",
                    (obj.GROSS_WGT_USER != null) ? obj.GROSS_WGT_USER : "", (obj.FREIGHT != null) ? obj.FREIGHT : "", (obj.FRT_CHARGEABLE_AS_TAR != null) ? obj.FRT_CHARGEABLE_AS_TAR : "", (obj.FRT_CHARGEABLE_AS_NET != null) ? obj.FRT_CHARGEABLE_AS_NET : "",
                    (obj.FRT_PAYABLE_ON_TAR != null) ? obj.FRT_PAYABLE_ON_TAR : "", (obj.FRT_RATE_PER_KG_TAR != null) ? obj.FRT_RATE_PER_KG_TAR : "", (obj.FRT_RATE_TAR != null) ? obj.FRT_RATE_TAR : "",
                    (obj.FRT_PAYABLE_ON_NET != null) ? obj.FRT_PAYABLE_ON_NET : "", (obj.FRT_RATE_PER_KG_NET != null) ? obj.FRT_RATE_PER_KG_NET : "", (obj.FRT_RATE_NET != null) ? obj.FRT_RATE_NET : "", (obj.FSC_PAYABLE_ON_TAR != null) ? obj.FSC_PAYABLE_ON_TAR : "",
                    (obj.FSC_RATE_PER_KG_TAR != null) ? obj.FSC_RATE_PER_KG_TAR : "", (obj.FSC_RATE_TAR != null) ? obj.FSC_RATE_TAR : "", (obj.FSC_PAYABLE_ON_NET != null) ? obj.FSC_PAYABLE_ON_NET : "", (obj.FSC_RATE_PER_KG_NET != null) ? obj.FSC_RATE_PER_KG_NET : "",
                    (obj.FSC_RATE_NET != null) ? obj.FSC_RATE_NET : "", (obj.IRC_PAYABLE_ON_TAR != null) ? obj.IRC_PAYABLE_ON_TAR : "", (obj.IRC_RATE_PER_KG_TAR != null) ? obj.IRC_RATE_PER_KG_TAR : "", (obj.IRC_RATE_TAR != null) ? obj.IRC_RATE_TAR : "",
                    (obj.IRC_PAYABLE_ON_NET != null) ? obj.IRC_PAYABLE_ON_NET : "", (obj.IRC_RATE_PER_KG_NET != null) ? obj.IRC_RATE_PER_KG_NET : "", (obj.IRC_RATE_NET != null) ? obj.IRC_RATE_NET : "", (obj.XRAY_PAYABLE_ON_TAR != null) ? obj.XRAY_PAYABLE_ON_TAR : "",
                    (obj.XRAY_RATE_PER_KG_TAR != null) ? obj.XRAY_RATE_PER_KG_TAR : "", (obj.XRAY_RATE_TAR != null) ? obj.XRAY_RATE_TAR : "", (obj.XRAY_PAYABLE_ON_NET != null) ? obj.XRAY_PAYABLE_ON_NET : "", (obj.XRAY_RATE_PER_KG_NET != null) ? obj.XRAY_RATE_PER_KG_NET : "",
                    (obj.XRAY_RATE_NET != null) ? obj.XRAY_RATE_NET : "", (obj.MC_PAYABLE_ON_TAR != null) ? obj.MC_PAYABLE_ON_TAR : "", (obj.MC_RATE_PER_KG_TAR != null) ? obj.MC_RATE_PER_KG_TAR : "", (obj.MC_RATE_TAR != null) ? obj.MC_RATE_TAR : "",
                    (obj.MC_PAYABLE_ON_NET != null) ? obj.MC_PAYABLE_ON_NET : "", (obj.MC_RATE_PER_KG_NET != null) ? obj.MC_RATE_PER_KG_NET : "", (obj.MC_RATE_NET != null) ? obj.MC_RATE_NET : "", (obj.CTG_PAYABLE_ON_TAR != null) ? obj.CTG_PAYABLE_ON_TAR : "",
                    (obj.CTG_RATE_PER_KG_TAR != null) ? obj.CTG_RATE_PER_KG_TAR : "", (obj.CTG_RATE_TAR != null) ? obj.CTG_RATE_TAR : "", (obj.CTG_PAYABLE_ON_NET != null) ? obj.CTG_PAYABLE_ON_NET : "", (obj.CTG_RATE_PER_KG_NET != null) ? obj.CTG_RATE_PER_KG_NET : "",
                    (obj.CTG_RATE_NET != null) ? obj.CTG_RATE_NET : "", (obj.DUE_CARRIER_TAR != null) ? obj.DUE_CARRIER_TAR : "", (obj.DUE_CARRIER_NET != null) ? obj.DUE_CARRIER_NET : "", (obj.HAWB_TAR != null) ? obj.HAWB_TAR : "",
                    (obj.HAWB_NET != null) ? obj.HAWB_NET : "", (obj.PCA_TAR != null) ? obj.PCA_TAR : "", (obj.PCA_NET != null) ? obj.PCA_NET : "", (obj.DUE_AGENT_TAR != null) ? obj.DUE_AGENT_TAR : "", (obj.DUE_AGENT_NET != null) ? obj.DUE_AGENT_NET : "",
                    (obj.TOTAL_TAR != null) ? obj.TOTAL_TAR : "", (obj.TOTAL_NET != null) ? obj.TOTAL_NET : "", (obj.OTHER_CHRG_TAR != null) ? obj.OTHER_CHRG_TAR : "",
                    (obj.OTHER_CHRG_NET != null) ? obj.OTHER_CHRG_NET : "", (obj.REMARK != null) ? obj.REMARK : "", (obj.AMS_RATE_TAR != null) ? obj.AMS_RATE_TAR : "",
                    (obj.AMS_RATE_NET != null) ? obj.AMS_RATE_NET : "", (obj.OTHER_NAME1 != null) ? obj.OTHER_NAME1 : "", (obj.OTHER_NAME2 != null) ? obj.OTHER_NAME2 : "",
                    (obj.OTHER_RATE1_TAR != null) ? obj.OTHER_RATE1_TAR : "", (obj.OTHER_RATE2_TAR != null) ? obj.OTHER_RATE2_TAR : "",
                    (obj.OTHER_RATE1_NET != null) ? obj.OTHER_RATE1_NET : "", (obj.OTHER_RATE2_NET != null) ? obj.OTHER_RATE2_NET : "",
                    (obj.OTHER_RATE1_TAR_CAL != null) ? obj.OTHER_RATE1_TAR_CAL : "", (obj.OTHER_RATE2_TAR_CAL != null) ? obj.OTHER_RATE2_TAR_CAL : "", (obj.OTHER_RATE1_NET_CAL != null) ? obj.OTHER_RATE1_NET_CAL : "",
                    (obj.OTHER_RATE2_NET_CAL != null) ? obj.OTHER_RATE2_NET_CAL : "", (obj.ISNETEDIT != null) ? obj.ISNETEDIT : "", (obj.ISMIN != null) ? obj.ISMIN : "", (obj.SUPPLIER_NET != null) ? obj.SUPPLIER_NET : "",
                    (obj.AIR_FRT_COMM_NET != null) ? obj.AIR_FRT_COMM_NET : "", (obj.FRT_REBATE_NET != null) ? obj.FRT_REBATE_NET : "", (obj.TDS_NET != null) ? obj.TDS_NET : "",
                    (obj.SERVICE_TAX_NET != null) ? obj.SERVICE_TAX_NET : "", (obj.FRT_RATE_TAR_FRT != null) ? obj.FRT_RATE_TAR_FRT : "", (obj.FSC_RATE_TAR_FRT != null) ? obj.FSC_RATE_TAR_FRT : "",
                    (obj.IRC_RATE_TAR_FRT != null) ? obj.IRC_RATE_TAR_FRT : "", (obj.XRAY_RATE_TAR_FRT != null) ? obj.XRAY_RATE_TAR_FRT : "", (obj.MC_RATE_TAR_FRT != null) ? obj.MC_RATE_TAR_FRT : "",
                    (obj.CTG_RATE_TAR_FRT != null) ? obj.CTG_RATE_TAR_FRT : "", (obj.AMS_RATE_TAR_FRT != null) ? obj.AMS_RATE_TAR_FRT : "", (obj.HAWB_RATE_TAR_FRT != null) ? obj.HAWB_RATE_TAR_FRT : "",
                    (obj.PCA_RATE_TAR_FRT != null) ? obj.PCA_RATE_TAR_FRT : "", (obj.OTHER_RATE_TAR_FRT != null) ? obj.OTHER_RATE_TAR_FRT : "", (obj.FRT_RATE_NET_FRT != null) ? obj.FRT_RATE_NET_FRT : "",
                    (obj.FSC_RATE_NET_FRT != null) ? obj.FSC_RATE_NET_FRT : "", (obj.IRC_RATE_NET_FRT != null) ? obj.IRC_RATE_NET_FRT : "", (obj.XRAY_RATE_NET_FRT != null) ? obj.XRAY_RATE_NET_FRT : "",
                    (obj.MC_RATE_NET_FRT != null) ? obj.MC_RATE_NET_FRT : "", (obj.CTG_RATE_NET_FRT != null) ? obj.CTG_RATE_NET_FRT : "", (obj.AMS_RATE_NET_FRT != null) ? obj.AMS_RATE_NET_FRT : "",
                    (obj.HAWB_RATE_NET_FRT != null) ? obj.HAWB_RATE_NET_FRT : "", (obj.PCA_RATE_NET_FRT != null) ? obj.PCA_RATE_NET_FRT : "", (obj.OTHER_RATE_NET_FRT != null) ? obj.OTHER_RATE_NET_FRT : "",
                    (obj.OTHER_RATE1_TAR_FRT != null) ? obj.OTHER_RATE1_TAR_FRT : "", (obj.OTHER_RATE2_TAR_FRT != null) ? obj.OTHER_RATE2_TAR_FRT : "", (obj.DUE_CARRIER_TAR_CC != null) ? obj.DUE_CARRIER_TAR_CC : "",
                    (obj.DUE_AGENT_TAR_CC != null) ? obj.DUE_AGENT_TAR_CC : "", (obj.TOTAL_TAR_CC != null) ? obj.TOTAL_TAR_CC : "", (obj.OTHER_RATE1_NET_FRT != null) ? obj.OTHER_RATE1_NET_FRT : "",
                    (obj.OTHER_RATE2_NET_FRT != null) ? obj.OTHER_RATE2_NET_FRT : "", (obj.DUE_CARRIER_NET_CC != null) ? obj.DUE_CARRIER_NET_CC : "", (obj.DUE_AGENT_NET_CC != null) ? obj.DUE_AGENT_NET_CC : "",
                    (obj.TOTAL_NET_CC != null) ? obj.TOTAL_NET_CC : "", (obj.TDS_ACCTCODE != null) ? obj.TDS_ACCTCODE : "", (obj.SERVICETAX_ACCTCODE != null) ? obj.SERVICETAX_ACCTCODE : "",
                     obj.CmpCode, obj.CmpId, obj.MakerIp, (obj.AGENTS_RATE != null) ? obj.AGENTS_RATE : "", (obj.THC_PAYABLE_ON_TAR != null) ? obj.THC_PAYABLE_ON_TAR : "",
                    (obj.THC_RATE_PER_KG_TAR != null) ? obj.THC_RATE_PER_KG_TAR : "", (obj.THC_RATE_TAR != null) ? obj.THC_RATE_TAR : "", (obj.THC_PAYABLE_ON_NET != null) ? obj.THC_PAYABLE_ON_NET : "",
                    (obj.THC_RATE_PER_KG_NET != null) ? obj.THC_RATE_PER_KG_NET : "", (obj.THC_RATE_NET != null) ? obj.THC_RATE_NET : "", (obj.THC_RATE_TAR_FRT != null) ? obj.THC_RATE_TAR_FRT : "",
                    (obj.THC_RATE_NET_FRT != null) ? obj.THC_RATE_NET_FRT : "", (obj.BUSINES_PROMO_NET != null) ? obj.BUSINES_PROMO_NET : "", (obj.BP_PAYABLE_ON_TAR != null) ? obj.BP_PAYABLE_ON_TAR : "",
                    (obj.BP_RATE_PER_KG_TAR != null) ? obj.BP_RATE_PER_KG_TAR : "", (obj.BP_RATE_TAR != null) ? obj.BP_RATE_TAR : "", (obj.BP_PAYABLE_ON_NET != null) ? obj.BP_PAYABLE_ON_NET : "",
                    (obj.BP_RATE_PER_KG_NET != null) ? obj.BP_RATE_PER_KG_NET : "", (obj.BP_RATE_NET != null) ? obj.BP_RATE_NET : "", (obj.BP_RATE_TAR_FRT != null) ? obj.BP_RATE_TAR_FRT : "",
                    (obj.BP_RATE_NET_FRT != null) ? obj.BP_RATE_NET_FRT : "",

                     (obj.DEST_TRUCKING_PAYABLE_ON_TAR != null) ? obj.DEST_TRUCKING_PAYABLE_ON_TAR : "",
                    (obj.DEST_TRUCKING_RATE_PER_KG_TAR != null) ? obj.DEST_TRUCKING_RATE_PER_KG_TAR : "", (obj.DEST_TRUCKING_RATE_TAR != null) ? obj.DEST_TRUCKING_RATE_TAR : "", (obj.DEST_TRUCKING_PAYABLE_ON_NET != null) ? obj.DEST_TRUCKING_PAYABLE_ON_NET : "",
                    (obj.DEST_TRUCKING_RATE_PER_KG_NET != null) ? obj.DEST_TRUCKING_RATE_PER_KG_NET : "", (obj.DEST_TRUCKING_RATE_NET != null) ? obj.DEST_TRUCKING_RATE_NET : "", (obj.DEST_TRUCKING_RATE_TAR_FRT != null) ? obj.DEST_TRUCKING_RATE_TAR_FRT : "",
                    (obj.DEST_TRUCKING_RATE_NET_FRT != null) ? obj.DEST_TRUCKING_RATE_NET_FRT : "");

                //obj.EXPTNO, obj.MAWBNO, obj.CITYCODE, obj.CHBL_WGT, obj.GROSS_WGT, obj.CHBL_WGT_USER,
                //obj.GROSS_WGT_USER, obj.FREIGHT, obj.FRT_CHARGEABLE_AS_TAR, obj.FRT_CHARGEABLE_AS_NET,
                //obj.FRT_PAYABLE_ON_TAR, obj.FRT_RATE_PER_KG_TAR, obj.FRT_RATE_TAR, obj.FRT_PAYABLE_ON_NET,
                //obj.FRT_RATE_PER_KG_NET, obj.FRT_RATE_NET, obj.FSC_PAYABLE_ON_TAR, obj.FSC_RATE_PER_KG_TAR,
                //obj.FSC_RATE_TAR, obj.FSC_PAYABLE_ON_NET, obj.FSC_RATE_PER_KG_NET, obj.FSC_RATE_NET, obj.IRC_PAYABLE_ON_TAR,
                //obj.IRC_RATE_PER_KG_TAR, obj.IRC_RATE_TAR, obj.IRC_PAYABLE_ON_NET, obj.IRC_RATE_PER_KG_NET, obj.IRC_RATE_NET,
                //obj.XRAY_PAYABLE_ON_TAR, obj.XRAY_RATE_PER_KG_TAR, obj.XRAY_RATE_TAR, obj.XRAY_PAYABLE_ON_NET,
                //obj.XRAY_RATE_PER_KG_NET, obj.XRAY_RATE_NET, obj.MC_PAYABLE_ON_TAR, obj.MC_RATE_PER_KG_TAR,
                //obj.MC_RATE_TAR, obj.MC_PAYABLE_ON_NET, obj.MC_RATE_PER_KG_NET, obj.MC_RATE_NET, obj.CTG_PAYABLE_ON_TAR,
                //obj.CTG_RATE_PER_KG_TAR, obj.CTG_RATE_TAR, obj.CTG_PAYABLE_ON_NET, obj.CTG_RATE_PER_KG_NET, obj.CTG_RATE_NET,
                //obj.DUE_CARRIER_TAR, obj.DUE_CARRIER_NET, obj.HAWB_TAR, obj.HAWB_NET, obj.PCA_TAR, obj.PCA_NET, obj.DUE_AGENT_TAR,
                //obj.DUE_AGENT_NET, obj.TOTAL_TAR, obj.TOTAL_NET, obj.OTHER_CHRG_TAR, obj.OTHER_CHRG_NET, obj.REMARK, obj.AMS_RATE_TAR,
                //obj.AMS_RATE_NET, obj.OTHER_NAME1, obj.OTHER_NAME2, obj.OTHER_RATE1_TAR, obj.OTHER_RATE2_TAR, obj.OTHER_RATE1_NET,
                //obj.OTHER_RATE2_NET, obj.OTHER_RATE1_TAR_CAL, obj.OTHER_RATE2_TAR_CAL, obj.OTHER_RATE1_NET_CAL, obj.OTHER_RATE2_NET_CAL,
                //obj.ISNETEDIT, obj.ISMIN, obj.SUPPLIER_NET, obj.AIR_FRT_COMM_NET, obj.FRT_REBATE_NET, obj.TDS_NET, obj.SERVICE_TAX_NET,
                //obj.FRT_RATE_TAR_FRT, obj.FSC_RATE_TAR_FRT, obj.IRC_RATE_TAR_FRT, obj.XRAY_RATE_TAR_FRT, obj.MC_RATE_TAR_FRT,
                //obj.CTG_RATE_TAR_FRT, obj.AMS_RATE_TAR_FRT, obj.HAWB_RATE_TAR_FRT, obj.PCA_RATE_TAR_FRT, obj.OTHER_RATE_TAR_FRT,
                //obj.FRT_RATE_NET_FRT, obj.FSC_RATE_NET_FRT, obj.IRC_RATE_NET_FRT, obj.XRAY_RATE_NET_FRT, obj.MC_RATE_NET_FRT,
                //obj.CTG_RATE_NET_FRT, obj.AMS_RATE_NET_FRT, obj.HAWB_RATE_NET_FRT, obj.PCA_RATE_NET_FRT, obj.OTHER_RATE_NET_FRT,
                //obj.OTHER_RATE1_TAR_FRT, obj.OTHER_RATE2_TAR_FRT, obj.DUE_CARRIER_TAR_CC, obj.DUE_AGENT_TAR_CC, obj.TOTAL_TAR_CC,
                //obj.OTHER_RATE1_NET_FRT, obj.OTHER_RATE2_NET_FRT, obj.DUE_CARRIER_NET_CC, obj.DUE_AGENT_NET_CC, obj.TOTAL_NET_CC,
                //obj.TDS_ACCTCODE, obj.SERVICETAX_ACCTCODE, obj.CmpCode, obj.CmpId, obj.MakerIp, obj.AGENTS_RATE, obj.THC_PAYABLE_ON_TAR,
                //obj.THC_RATE_PER_KG_TAR, obj.THC_RATE_TAR, obj.THC_PAYABLE_ON_NET, obj.THC_RATE_PER_KG_NET, obj.THC_RATE_NET,
                //obj.THC_RATE_TAR_FRT, obj.THC_RATE_NET_FRT, obj.BUSINES_PROMO_NET, obj.BP_PAYABLE_ON_TAR, obj.BP_RATE_PER_KG_TAR,
                //obj.BP_RATE_TAR, obj.BP_PAYABLE_ON_NET, obj.BP_RATE_PER_KG_NET, obj.BP_RATE_NET, obj.BP_RATE_TAR_FRT, obj.BP_RATE_NET_FRT);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/EXP_MST_EXPORT_MAWB_PP_CC_UPDATE");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ConsignmentHAWBFill DROPDOWN records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ConsignmentHAWBFill_DROPDOWN()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_HAWB_FILL_DROPDOWN");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ConsignmentHAWBFill_DROPDOWN");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve print/view data for Consignment HAWB PP CC records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Consignment_HAWB_PP_CC_View([FromUri]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_HAWB_VIEW",
                    obj.Type1, obj.Type2, obj.Type3, obj.GUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Consignment_HAWB_PP_CC_View");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update MST EXPORT HAWB FRT records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult EXP_MST_EXPORT_HAWB_FRT_UPDATE([FromBody]HawbRating obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_HAWB_UPDATE",
                    obj.HAWBNO, obj.PPCHRG_SELLING, obj.CCCHRG_SELLING, obj.PPTOTAGT_SELLING, obj.PPTOTCARR_SELLING, obj.PPTOT_SELLING,
                    obj.CCTOT_SELLING, obj.PP_SCHRG_FSC_SELL, obj.PP_SCHRG_IRC_SELL, obj.PP_SCHRG_XRAY_SELL, obj.CC_SCHRG_FSC_SELL,
                    obj.CC_SCHRG_IRC_SELL, obj.CC_SCHRG_XRAY_SELL, obj.REMARK, obj.IS_AGREED_RATED, obj.FREIGHT_RATE_PER_KG, obj.PREPAID_PER,
                    obj.COLLECT_PER, obj.FREIGHT_CHARGABLE_AS, obj.FRT_RATE_SCHRG_FSC_PO, obj.FRT_RATE_SCHRG_IRC_PO, obj.FRT_RATE_SCHRG_XRAY_PO,
                    obj.RATE_AGREED_BY, obj.RATE_AGREED_ON, obj.FREIGHT_RATE_BASIC, obj.FRT_RATE_SCHRG_FSC, obj.FRT_RATE_SCHRG_IRC, obj.FRT_RATE_SCHRG_XRAY,
                    obj.CHARGEBLE_WT, obj.GROSS_WT, obj.EXCH_RATE, (obj.EXCH_CUR != null) ? obj.EXCH_CUR : "", obj.INR_RATE, obj.CCCHRG_SELLING_CUR, obj.CC_SCHRG_FSC_SELL_CUR,
                    obj.CC_SCHRG_IRC_SELL_CUR, obj.CC_SCHRG_XRAY_SELL_CUR, obj.CCCHRG_SELLING_INR, obj.CC_SCHRG_FSC_SELL_INR, obj.CC_SCHRG_IRC_SELL_INR,
                    obj.CC_SCHRG_XRAY_SELL_INR, obj.CCTOTAGT_SELLING_INR, obj.CCTOTCARR_SELLING_INR, obj.PPCHRG_SELLING_CUR, obj.PPCHRG_SELLING_INR,
                    obj.PP_SCHRG_FSC_SELL_CUR, obj.PP_SCHRG_FSC_SELL_INR, obj.PP_SCHRG_IRC_SELL_CUR, obj.PP_SCHRG_IRC_SELL_INR, obj.PP_SCHRG_XRAY_SELL_CUR,
                    obj.PP_SCHRG_XRAY_SELL_INR, obj.FREIGHT_RATE_BASIC_PO, obj.FRT_RATE_MC_PO, obj.FRT_RATE_MC, obj.PP_MC_SELL, obj.CC_MC_SELL,
                    obj.CC_MC_SELL_CUR, obj.CC_MC_SELL_INR, obj.FRT_RATE_CTG_PO, obj.FRT_RATE_CTG, obj.PP_CTG_SELL, obj.CC_CTG_SELL, obj.CC_CTG_SELL_CUR,
                    obj.CC_CTG_SELL_INR, obj.PP_HAWB_SELL, obj.CC_HAWB_SELL, obj.CC_HAWB_SELL_CUR, obj.CC_HAWB_SELL_INR, obj.PP_PCA_SELL, obj.CC_PCA_SELL,
                    obj.CC_PCA_SELL_CUR, obj.CC_PCA_SELL_INR, obj.PP_OTHER_SELL, obj.CC_OTHER_SELL, obj.CC_OTHER_SELL_CUR, obj.CC_OTHER_SELL_INR,
                    obj.PP_MC_SELL_CUR, obj.PP_MC_SELL_INR, obj.PP_CTG_SELL_CUR, obj.PP_CTG_SELL_INR, obj.PP_HAWB_SELL_CUR, obj.PP_HAWB_SELL_INR,
                    obj.PP_PCA_SELL_CUR, obj.PP_PCA_SELL_INR, obj.PP_OTHER_SELL_CUR, obj.PP_OTHER_SELL_INR, obj.PP_DC_SELL, obj.PP_DC_SELL_CUR,
                    obj.PP_DC_SELL_INR, obj.CC_DC_SELL, obj.CC_DC_SELL_CUR, obj.CC_DC_SELL_INR, obj.PP_SCR_SELL, obj.PP_SCR_SELL_CUR, obj.PP_SCR_SELL_INR,
                    obj.CC_SCR_SELL, obj.CC_SCR_SELL_CUR, obj.CC_SCR_SELL_INR, obj.PP_MYC_SELL, obj.PP_MYC_SELL_CUR, obj.PP_MYC_SELL_INR, obj.CC_MYC_SELL,
                    obj.CC_MYC_SELL_CUR, obj.CC_MYC_SELL_INR, obj.CityCode, obj.CmpCode,
                    obj.CmpId, obj.MakerIP, obj.TRANSPORT_MODE, obj.Procument, obj.FRT_RATE_THC_PO,
                     obj.FRT_RATE_THC, obj.PP_THC_SELL, obj.PP_THC_SELL_CUR, obj.PP_THC_SELL_INR,
                     obj.CC_THC_SELL, obj.CC_THC_SELL_CUR, obj.CC_THC_SELL_INR,
                    obj.FRT_RATE_DDC_PO, obj.FRT_RATE_DDC,
                    obj.PP_DDC_SELL, obj.PP_DDC_SELL_CUR, obj.PP_DDC_SELL_INR, obj.CC_DDC_SELL,
                    obj.CC_DDC_SELL_CUR, obj.CC_DDC_SELL_INR,
                    obj.FRT_RATE_FOB_PO, obj.FRT_RATE_FOB,
                    obj.PP_FOB_SELL, obj.PP_FOB_SELL_CUR, obj.PP_FOB_SELL_INR, obj.CC_FOB_SELL,
                    obj.CC_FOB_SELL_CUR, obj.CC_FOB_SELL_INR);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/EXP_MST_EXPORT_HAWB_FRT_UPDATE");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve dropdown data for JOBFREIGHTRATE FILL DROPDOWN records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult JOBFREIGHTRATE_FILL_DROPDOWN()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_JOBFREIGHTRATE_FILL_DROPDOWN");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/JOBFREIGHTRATE_FILL_DROPDOWN");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Populate form with existing data for JobFreightRate Populate data records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult JobFreightRate_Populate_data([FromUri]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_JOBFREIGHTRATE_POPULATE", obj.Type1, obj.Type2);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/JobFreightRate_Populate_data");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update MST EXPORT JOBFREIGHTRATE records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult EXP_MST_EXPORT_JOBFREIGHTRATE_UPDATE([FromBody]JobRating obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_JOBFREIGHTRATE_UPDATE",
                    obj.EXPTNO, obj.PPCHRG_SELLING, obj.CCCHRG_SELLING, obj.PPTOTAGT_SELLING, obj.CCTOTAGT_SELLING, obj.PPTOTCARR_SELLING,
                    obj.CCTOTCARR_SELLING, obj.PPTOT_SELLING, obj.CCTOT_SELLING, obj.OTHCHRG_SELLING, obj.PP_SCHRG_FSC_SELL, obj.PP_SCHRG_IRC_SELL,
                    obj.PP_SCHRG_XRAY_SELL, obj.CC_SCHRG_FSC_SELL, obj.CC_SCHRG_IRC_SELL, obj.CC_SCHRG_XRAY_SELL, obj.REMARK, obj.FREIGHT_RATE_PER_KG,
                    obj.PREPAID_PER, obj.COLLECT_PER, obj.FREIGHT_CHARGABLE_AS, obj.FRT_RATE_SCHRG_FSC_PO, obj.FRT_RATE_SCHRG_IRC_PO, obj.FRT_RATE_SCHRG_XRAY_PO,
                    obj.RATE_AGREED_BY, obj.RATE_AGREED_ON, obj.FREIGHT_RATE_BASIC, obj.FRT_RATE_SCHRG_FSC, obj.FRT_RATE_SCHRG_IRC, obj.FRT_RATE_SCHRG_XRAY,
                    obj.EXCH_RATE, obj.EXCH_CUR, obj.INR_RATE, obj.CCCHRG_SELLING_CUR, obj.CC_SCHRG_FSC_SELL_CUR, obj.CC_SCHRG_IRC_SELL_CUR,
                    obj.CC_SCHRG_XRAY_SELL_CUR, obj.CCTOTAGT_SELLING_CUR, obj.CCTOTCARR_SELLING_CUR, obj.CCCHRG_SELLING_INR, obj.CC_SCHRG_FSC_SELL_INR,
                    obj.CC_SCHRG_IRC_SELL_INR, obj.CC_SCHRG_XRAY_SELL_INR, obj.CCTOTAGT_SELLING_INR, obj.CCTOTCARR_SELLING_INR, obj.CityCode,
                    obj.CmpCode, obj.CmpId, obj.MakerIP);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/EXP_MST_EXPORT_JOBFREIGHTRATE_UPDATE");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        //--------------------------------------------------END Consignment-------------------------------------------------------------

        //--------------------------------------------------START Print Document-------------------------------------------------------------
        /// <summary>Perform PrintDocumentAirMawbList records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PrintDocumentAirMawbList([FromUri]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_MAWBNO_PAGELOAD", obj.Type1, obj.Type2, obj.Type3);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentAirMawbList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PrintDocumentAirMawbUpdatePageload records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PrintDocumentAirMawbUpdatePageload([FromUri]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_MAWBNO_UPDATE_PAGELOAD",
                    (obj.Type1 != null) ? obj.Type1 : "", obj.Type2, obj.Type3);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentAirMawbUpdatePageload");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PrintDocumentAirMawbUpdateIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PrintDocumentAirMawbUpdateIU([FromBody]PrintMawbNo obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_MAWBNO_IU",
                    obj.MAWBNO, obj.MAWBDT, obj.EXPTNO, obj.GRWT, obj.CHBL_WT, obj.FRT_TYPE, obj.FRT_CUR, obj.FRT_AMT, obj.CityCode, obj.CmpId, obj.CmpCode, obj.ISDDX, obj.DDXWAREHSE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentAirMawbUpdateIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //

        /// <summary>Perform PrintDocumentAirMawbPrint records.</summary>
        /// <param name="mawbno">Master airway bill number.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="isprint">isprint parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PrintDocumentAirMawbPrint([FromUri]string mawbno, string cmpid, string isprint)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_MAWBNO_PRINT_PAGELOAD", mawbno, cmpid, isprint);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentAirMawbPrint");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //
        /// <summary>Perform MawbnoprintUpdate records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult MawbnoprintUpdate([FromBody]printupdateMawbno obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_MAWBNO_PRINT_UPDATE",
                    //obj.MAWBNO,obj.SHPR,obj.CNSEE,obj.AGTNAME,obj.IATA,obj.AGTACNO,obj.DEPARTURE,obj.IMP_TO,obj.FRSTCARR,
                    //obj.TO1,obj.IMP_BY,obj.TO2,obj.BY1,obj.CURR,obj.CHGS,obj.PPDWT,obj.COLLWT,obj.OTHRPPD,obj.OTHRCOLL,obj.CARRVAL,obj.CUSTVAL,obj.DEST,
                    //obj.FLT1,obj.FLT2,obj.INSAMT,obj.ACINFO,obj.HANDINFO,obj.PCS,obj.KG,obj.RTCL,obj.ITMNO,obj.RATE,obj.TOT,obj.IDESC,obj.PPCHRG,obj.PPVAL,obj.PPTAX,
                    //obj.PPTOTAGT,obj.PPTOTCARR,obj.PPTOT,obj.PPCURRATE,obj.CCCHRG,obj.CCVAL,obj.CCTAX,obj.CCTOTAGT,obj.CCTOTCARR,obj.CCTOT,obj.CCURRATE,
                    //obj.OTHCHRG,obj.TOTCOLLCHRG,obj.BOTTOM,obj.AGTNAME1,obj.DESC

                    obj.MAWBNO, obj.SHPR, obj.CNSEE, obj.AGTNAME, (obj.IATA != null) ? obj.IATA : "", (obj.AGTACNO != null) ? obj.AGTACNO : "",
                    (obj.DEPARTURE != null) ? obj.DEPARTURE : "", (obj.IMP_TO != null) ? obj.IMP_TO : "", (obj.FRSTCARR != null) ? obj.FRSTCARR : "",
                    (obj.TO1 != null) ? obj.TO1 : "", (obj.IMP_BY != null) ? obj.IMP_BY : "", (obj.TO2 != null) ? obj.TO2 : "",
                    (obj.BY1 != null) ? obj.BY1 : "", (obj.CURR != null) ? obj.CURR : "", (obj.CHGS != null) ? obj.CHGS : "", (obj.PPDWT != null) ? obj.PPDWT : "",
                    (obj.COLLWT != null) ? obj.COLLWT : "", (obj.OTHRPPD != null) ? obj.OTHRPPD : "", (obj.OTHRCOLL != null) ? obj.OTHRCOLL : "",
                    (obj.CARRVAL != null) ? obj.CARRVAL : "", (obj.CUSTVAL != null) ? obj.CUSTVAL : "", (obj.DEST != null) ? obj.DEST : "",
                    (obj.FLT1 != null) ? obj.FLT1 : "", (obj.FLT2 != null) ? obj.FLT2 : "", (obj.INSAMT != null) ? obj.INSAMT : "",
                    (obj.ACINFO != null) ? obj.ACINFO : "", (obj.HANDINFO != null) ? obj.HANDINFO : "", (obj.PCS != null) ? obj.PCS : "",
                    (obj.KG != null) ? obj.KG : "", (obj.RTCL != null) ? obj.RTCL : "", (obj.ITMNO != null) ? obj.ITMNO : "",
                    (obj.RATE != null) ? obj.RATE : "", (obj.TOT != null) ? obj.TOT : "", (obj.IDESC != null) ? obj.IDESC : "",
                    (obj.PPCHRG != null) ? obj.PPCHRG : "", (obj.PPVAL != null) ? obj.PPVAL : "", (obj.PPTAX != null) ? obj.PPTAX : "", (obj.PPTOTAGT != null) ? obj.PPTOTAGT : "",
                    (obj.PPTOTCARR != null) ? obj.PPTOTCARR : "", (obj.PPTOT != null) ? obj.PPTOT : "", (obj.PPCURRATE != null) ? obj.PPCURRATE : "",
                    (obj.CCCHRG != null) ? obj.CCCHRG : "", (obj.CCVAL != null) ? obj.CCVAL : "", (obj.CCTAX != null) ? obj.CCTAX : "", (obj.CCTOTAGT != null) ? obj.CCTOTAGT : "",
                    (obj.CCTOTCARR != null) ? obj.CCTOTCARR : "", (obj.CCTOT != null) ? obj.CCTOT : "", (obj.CCURRATE != null) ? obj.CCURRATE : "",
                    (obj.OTHCHRG != null) ? obj.OTHCHRG : "", (obj.TOTCOLLCHRG != null) ? obj.TOTCOLLCHRG : "", (obj.BOTTOM != null) ? obj.BOTTOM : "",
                    (obj.AGTNAME1 != null) ? obj.AGTNAME1 : "", (obj.DESC != null) ? obj.DESC : "", (obj.AIRLINE_ADDRS != null) ? obj.AIRLINE_ADDRS : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/MawbnoprintUpdate");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform PrintDocumentAirHawbList records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PrintDocumentAirHawbList([FromUri]CommonFour obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_HAWBNO_PAGELOAD",
                    (obj.Type1 != null) ? obj.Type1 : "", obj.Type2, obj.Type3, obj.Type4);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentAirHawbList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PrintDocumentAirHawbUpdatePageload records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PrintDocumentAirHawbUpdatePageload([FromUri]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_HAWBNO_UPDATE_PAGELOAD",
                    (obj.Type1 != null) ? obj.Type1 : "", (obj.Type2 != null) ? obj.Type2 : "", obj.Type3);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentAirHawbUpdatePageload");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PrintDocumentAirHawbUpdateIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PrintDocumentAirHawbUpdateIU([FromBody]PrintHawbNo obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_HAWBNO_IU",
                    (obj.HAWBNO != null) ? obj.HAWBNO : "",
                    (obj.HAWBDT != null) ? obj.HAWBDT : "",
                    (obj.EXPTNO != null) ? obj.EXPTNO : "",
                    obj.GRWT, obj.CHBL_WT,
                    obj.FRT_TYPE, obj.FRT_CUR, obj.FRT_AMT, obj.CityCode,
                    obj.CityCode1, obj.CmpId, obj.CmpCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentAirHawbUpdateIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform hawbnoprintload records.</summary>
        /// <param name="hawbno">House airway bill number.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult hawbnoprintload([FromUri]string hawbno, string cmpid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_PRINTDOC_HAWBNO_PRINT_PAGELOAD", hawbno, cmpid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/hawbnoprintload");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Load HAWBNO print document details for the print page.</summary>
        /// <param name="hawbno">House airway bill number.</param>
        /// <param name="userid">userid parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult EXP_PRINTDOC_HAWBNO_PRINT_PAGELOAD(String hawbno, String userid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_PRINTDOC_HAWBNO_PRINT_PAGELOAD", hawbno, userid);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/EXP_PRINTDOC_HAWBNO_PRINT_PAGELOAD");
            }
            return Ok(ds);
        }
        //(obj.HAWBNO != null) ? obj.HAWBNO : "",
        /// <summary>Perform hawbnoprintUpdate records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult hawbnoprintUpdate([FromBody]printupdateHawbno obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_HAWBNO_PRINT_UPDATE",
                    obj.HAWBNO, obj.SHPR, obj.CNSEE, obj.AGTNAME, (obj.IATA != null) ? obj.IATA : "", (obj.AGTACNO != null) ? obj.AGTACNO : "",
                    (obj.DEPARTURE != null) ? obj.DEPARTURE : "", (obj.IMP_TO != null) ? obj.IMP_TO : "", (obj.FRSTCARR != null) ? obj.FRSTCARR : "",
                    (obj.TO1 != null) ? obj.TO1 : "", (obj.IMP_BY != null) ? obj.IMP_BY : "", (obj.TO2 != null) ? obj.TO2 : "",
                    (obj.BY1 != null) ? obj.BY1 : "", (obj.CURR != null) ? obj.CURR : "", (obj.CHGS != null) ? obj.CHGS : "", (obj.PPDWT != null) ? obj.PPDWT : "",
                    (obj.COLLWT != null) ? obj.COLLWT : "", (obj.OTHRPPD != null) ? obj.OTHRPPD : "", (obj.OTHRCOLL != null) ? obj.OTHRCOLL : "",
                    (obj.CARRVAL != null) ? obj.CARRVAL : "", (obj.CUSTVAL != null) ? obj.CUSTVAL : "", (obj.DEST != null) ? obj.DEST : "",
                    (obj.FLT1 != null) ? obj.FLT1 : "", (obj.FLT2 != null) ? obj.FLT2 : "", (obj.INSAMT != null) ? obj.INSAMT : "",
                    (obj.ACINFO != null) ? obj.ACINFO : "", (obj.HANDINFO != null) ? obj.HANDINFO : "", (obj.PCS != null) ? obj.PCS : "",
                    (obj.GRWT != null) ? obj.GRWT : "", (obj.KG != null) ? obj.KG : "", (obj.RTCL != null) ? obj.RTCL : "", (obj.ITMNO != null) ? obj.ITMNO : "",
                    (obj.CHRGWT != null) ? obj.CHRGWT : "", (obj.RATE != null) ? obj.RATE : "", (obj.TOT != null) ? obj.TOT : "", (obj.IDESC != null) ? obj.IDESC : "",
                    (obj.PPCHRG != null) ? obj.PPCHRG : "", (obj.PPVAL != null) ? obj.PPVAL : "", (obj.PPTAX != null) ? obj.PPTAX : "", (obj.PPTOTAGT != null) ? obj.PPTOTAGT : "",
                    (obj.PPTOTCARR != null) ? obj.PPTOTCARR : "", (obj.PPTOT != null) ? obj.PPTOT : "", (obj.PPCURRATE != null) ? obj.PPCURRATE : "",
                    (obj.CCCHRG != null) ? obj.CCCHRG : "", (obj.CCVAL != null) ? obj.CCVAL : "", (obj.CCTAX != null) ? obj.CCTAX : "", (obj.CCTOTAGT != null) ? obj.CCTOTAGT : "",
                    (obj.CCTOTCARR != null) ? obj.CCTOTCARR : "", (obj.CCTOT != null) ? obj.CCTOT : "", (obj.CCURRATE != null) ? obj.CCURRATE : "",
                    (obj.OTHCHRG != null) ? obj.OTHCHRG : "", (obj.TOTCOLLCHRG != null) ? obj.TOTCOLLCHRG : "", (obj.BOTTOM != null) ? obj.BOTTOM : "",
                    (obj.agtname1 != null) ? obj.agtname1 : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/hawbnoprintUpdate");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform PrintDocumentPrealertPageload records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PrintDocumentPrealertPageload([FromUri]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_CONT_MAWB_PAGELOAD_LIST",
                    obj.Type1, obj.Type2, obj.Type3);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentPrealertPageload");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }



        /// <summary>Perform PrintDocumentPrealertPrepare records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PrintDocumentPrealertPrepare([FromBody]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string FileName = "";
            string File_Name = "";
            File_Name = "PREALERT_" + obj.Type1;    //obj.Type1 = MAWBNO
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_PRINTDOC_MAWB_PREPAIR_PREALERT",
                    obj.Type1, obj.Type2);
                FileName = CommonFunction.ConvertToWord_open("Export", "xsl_Exp_Mst_Export_PrintDoc_PreparePrealert_Air.xsl", ds, File_Name);
                ds = null;
                ds = ErrorLog.ConvertStringToDataset("100#" + FileName);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentPrealertPrepare");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PrintDocumentPrealertPrepare word records.</summary>
        /// <param name="Type1">Type1 parameter.</param>
        /// <param name="Type2">Type2 parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage PrintDocumentPrealertPrepare_word([FromUri] string Type1, string Type2)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string File_Name = "";
            StringBuilder stringBuilder = new StringBuilder();
            File_Name = "PREALERT_" + Type1;    //obj.Type1 = MAWBNO

            ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_EXP_PRINTDOC_MAWB_PREPAIR_PREALERT",
                Type1, (Type2 != null) ? Type2 : "");

            //stringBuilder.AppendLine(@"<style> td { mso-number-format:\@; } </style> ");
            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head>");
            stringBuilder.Append("<body bgcolor='#FFFFFF' text='#000000'><table width='100%' border='1' cellspacing='2' cellpadding='8'>");
            stringBuilder.Append("<tr><td height='37'> <div align='center'><font size='3' face='Arial'><b><font size='4'>MANILAL PATEL - MADRAS  <br><br>");
            stringBuilder.Append("</font></b></font> <font face='Arial' size='3'>AIR FREIGHT - PREALERT</font></div></td></tr>");
            stringBuilder.Append("<tr> <td height='2'> <table width='100%' border='0' cellspacing='1' cellpadding='5'> <tr>");
            stringBuilder.Append("<td width='5%'><b><font size='2' face='Arial'>TO</font></b></td> <td width='30%'>&nbsp;</td>");
            stringBuilder.Append("<td width='7%'><b><font size='2' face='Arial'>ATTN</font></b></td>   <td width='34%'>&nbsp;</td>");
            stringBuilder.Append("<td width='7%'><b><font size='2' face='Arial'>DATE</font></b></td> <td width='17%'>&nbsp;</td> </tr> </table></td>  </tr>");
            stringBuilder.Append("<tr> <td> <table width='100%' border='1' cellspacing='0' cellpadding='5'>");
            stringBuilder.Append("<tr><td width='14%'><b><font size='1' face='	Verdana, Arial, Helvetica, sans-serif'>MAWB NO</font></b></td>");
            stringBuilder.Append("<td width='18%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + Convert.ToString(ds.Tables[0].Rows[0]["MAWBNODET"]) + "</font></td>");
            stringBuilder.Append("<td width='20%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>FLT NO.</font></b></td>");
            stringBuilder.Append("<td width='18%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + Convert.ToString(ds.Tables[0].Rows[0]["FLIGHTNO"]) + "</font></td>");
            stringBuilder.Append("<td width='14%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>CONX FLT</font></b></td>");
            stringBuilder.Append("<td width='16%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + Convert.ToString(ds.Tables[0].Rows[0]["FLIGHTNO1"]) + "</font></td> </tr>");
            stringBuilder.Append("<tr>  <td width='14%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>TOTAL PKGS</font></b></td>");
            stringBuilder.Append("<td width='18%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + Convert.ToString(ds.Tables[0].Rows[0]["TOT_PKGS"]) + "</font></td>");
            stringBuilder.Append("<td width='20%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>GROSS WT.</font></b></td>");
            stringBuilder.Append("<td width='18%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + Convert.ToString(ds.Tables[0].Rows[0]["GR_WT"]) + "</font></td>");
            stringBuilder.Append("<td width='14%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT</font></b></td>");
            stringBuilder.Append("<td width='16%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + Convert.ToString(ds.Tables[0].Rows[0]["CHBL_WT"]) + "</font></td>  </tr>");
            stringBuilder.Append("<tr><td width='14%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>MAWB FRT</font></b></td>");
            stringBuilder.Append("<td width='18%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + Convert.ToString(ds.Tables[0].Rows[0]["MAWB_FRT"]) + "</font></td>");
            stringBuilder.Append("<td width='20%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>CUSTOM CLRD ON</font></b></td>");
            stringBuilder.Append("<td width='18%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + Convert.ToString(ds.Tables[0].Rows[0]["CLR_DT"]) + "</font></td>");
            stringBuilder.Append("<td width='14%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>MAWB DEST</font></b></td>");
            stringBuilder.Append("<td width='16%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + Convert.ToString(ds.Tables[0].Rows[0]["DEST_CITY"]) + "  </font></td> </tr>  </table></td>");
            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {//
                    stringBuilder.Append("<tr><td> <table width='100%' border='1' cellspacing='0' cellpadding='5'>");
                    stringBuilder.Append("<td width='13%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>HAWB NO</font></b></td>");
                    stringBuilder.Append("<td width='19%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWBNODET"].ToString() + "</font></td>");
                    stringBuilder.Append("<td width='20%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>HAWB DEST </font></b></td>");
                    stringBuilder.Append("<td width='18%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["DEST_CITY"].ToString() + " </font></td>");
                    stringBuilder.Append("<td width='13%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>HAWB FRT </font></b></td>");
                    stringBuilder.Append("<td width='17%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["MAWB_FRT"].ToString() + "</font></td></tr>");
                    stringBuilder.Append("<td width='13%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>TOTAL CTNS</font></b></td>");
                    stringBuilder.Append("<td width='19%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["TOT_CTNS"].ToString() + "</font></td>");
                    stringBuilder.Append("<td width='20%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>GROSS WT.</font></b></td>");
                    stringBuilder.Append("<td width='18%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["GR_WT"].ToString() + "</font></td>");
                    stringBuilder.Append("<td width='13%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT</font></b></td>");
                    stringBuilder.Append("<td width='17%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CHBL_WT"].ToString() + "</font></td>  </tr>");
                    stringBuilder.Append("<tr> <td width='13%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>NO OF PCS</font></b></td>");
                    stringBuilder.Append("<td width='19%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["TOT_PCS"].ToString() + "</font></td>");
                    stringBuilder.Append("<td width='20%'><font size='1'><b></b></font></td>");
                    stringBuilder.Append("<td width='18%'><font size='2'>&nbsp;</font></td>");
                    stringBuilder.Append("<td width='13%'><font size='1'><b></b></font></td>");
                    stringBuilder.Append("<td width='17%'><font size='2'>&nbsp;</font></td> </tr>");
                    stringBuilder.Append("<tr><td width='13%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>CONSIGNEE</font></b></td>");
                    stringBuilder.Append("<td colspan='5'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CONSIGNEE"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;</font></td>  </tr>");
                    stringBuilder.Append("<tr><td width='13%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>SHIPPER</font></b></td>");
                    stringBuilder.Append("<td colspan='5'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["SHIPPER"].ToString() + "</font></td> </tr>");
                    stringBuilder.Append("<tr><td width='13%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>COMMODITY</font></b></td>");
                    stringBuilder.Append("<td colspan='5'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["COMMIDITY"].ToString() + "</font></td></tr>");
                    stringBuilder.Append(" </table> <br>");
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds.Tables[2].Rows.Count; j++)
                        {

                            if (ds.Tables[1].Rows[i]["HAWBNO"].ToString() == ds.Tables[2].Rows[j]["HOUSEBILLNO"].ToString())
                            {
                                stringBuilder.Append("<table width='100%' border='1' cellspacing='0' cellpadding='3'>");
                                stringBuilder.Append("<tr><td width='13%'> <div align='center'><font size='1' face='Verdana, Arial, Helvetica, sans-serif'><b>P/O NO</b></font></div></td>");
                                stringBuilder.Append("<td width='16%'> <div align='center'><font size='1' face='Verdana, Arial, Helvetica, sans-serif'><b>STYLE NO</b></font></div></td>");
                                stringBuilder.Append("<td width='13%'> <div align='center'><font size='1' face='Verdana, Arial, Helvetica, sans-serif'><b>CTNS</b></font></div></td>");
                                stringBuilder.Append("<td width='18%'><div align='center'><font size='1'><b><font face='Verdana, Arial, Helvetica, sans-serif'>DOCS RECD</font></b></font></div></td>");
                                stringBuilder.Append("<td width='18%'><div align='center'><font size='1'><b><font face='Verdana, Arial, Helvetica, sans-serif'>CGO RECD</font></b></font></div></td>");
                                stringBuilder.Append("<td width='20%'><div align='center'><font size='1' face='Verdana, Arial, Helvetica, sans-serif'><b>DESTINATION DOCS RECD</b></font></div></td>");
                                stringBuilder.Append("<td width='20%'> <div align='center'><font size='1' face='Verdana, Arial, Helvetica, sans-serif'><b>NO.OF PCS</b></font></div></td>");
                                stringBuilder.Append("</tr>");
                                stringBuilder.Append("<tr><td width='13%'> <div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["ORDERNO"].ToString() + "</font></div></td>");
                                stringBuilder.Append("<td width='16%'> <div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["STYLENO"].ToString() + "</font></div></td>");
                                stringBuilder.Append("<td width='18%'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["PKGS"].ToString() + "</font></div></td>");
                                stringBuilder.Append("<td width='18%'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["DOCRCD"].ToString() + "</font></div></td>");
                                stringBuilder.Append("<td width='20%'> <div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["CARGORECD"].ToString() + "</font></div></td>");
                                stringBuilder.Append("<td width='20%'> <div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["DEST_DOC"].ToString() + "</font></div></td>");
                                stringBuilder.Append("<td width='13%'> <div align='center'><font size='2'><font face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["PIECES"].ToString() + "</font></font></div></td>");
                                stringBuilder.Append(" </tr>  </table></td> </tr>");
                            }
                        }
                    }
                    else
                    {
                        stringBuilder.Append("<table width='100%' border='1' cellspacing='0' cellpadding='3'>");
                        stringBuilder.Append("<tr><td width='13%'> <div align='center'><font size='1' face='Verdana, Arial, Helvetica, sans-serif'><b>P/O NO</b></font></div></td>");
                        stringBuilder.Append("<td width='16%'> <div align='center'><font size='1' face='Verdana, Arial, Helvetica, sans-serif'><b>STYLE NO</b></font></div></td>");
                        stringBuilder.Append("<td width='13%'> <div align='center'><font size='1' face='Verdana, Arial, Helvetica, sans-serif'><b>CTNS</b></font></div></td>");
                        stringBuilder.Append("<td width='18%'><div align='center'><font size='1'><b><font face='Verdana, Arial, Helvetica, sans-serif'>DOCS RECD</font></b></font></div></td>");
                        stringBuilder.Append("<td width='18%'><div align='center'><font size='1'><b><font face='Verdana, Arial, Helvetica, sans-serif'>CGO RECD</font></b></font></div></td>");
                        stringBuilder.Append("<td width='20%'><div align='center'><font size='1' face='Verdana, Arial, Helvetica, sans-serif'><b>DESTINATION DOCS RECD</b></font></div></td>");
                        stringBuilder.Append("<td width='20%'> <div align='center'><font size='1' face='Verdana, Arial, Helvetica, sans-serif'><b>NO.OF PCS</b></font></div></td>");
                        stringBuilder.Append("</tr>");
                        stringBuilder.Append("<tr><td width='13%'> <div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'> </font></div></td>");
                        stringBuilder.Append("<td width='16%'> <div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'> </font></div></td>");
                        stringBuilder.Append("<td width='18%'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'> </font></div></td>");
                        stringBuilder.Append("<td width='18%'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'> </font></div></td>");
                        stringBuilder.Append("<td width='20%'> <div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'> </font></div></td>");
                        stringBuilder.Append("<td width='20%'> <div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'> </font></div></td>");
                        stringBuilder.Append("<td width='13%'> <div align='center'><font size='2'><font face='Verdana, Arial, Helvetica, sans-serif'> </font></font></div></td>");
                        stringBuilder.Append(" </tr>  </table></td> </tr>");

                    }


                }
            }


            stringBuilder.Append("<tr><td><strong><font size='2' face='Arial'>" + ds.Tables[3].Rows[0]["REMARK"].ToString() + " &nbsp; &nbsp;</font></strong></td></tr>");
            stringBuilder.Append(" <tr> <td></td>  </tr>");
            stringBuilder.Append("</table> </body> </html>");
            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = File_Name + ".doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        /// <summary>Perform PrintDocumentPrealertAuto records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PrintDocumentPrealertAuto([FromBody]CommonFour obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ASP_IMP_CONSOLE_GENERATE_AIR_IU",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentPrealertAuto");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PrintDocumentPrealertSending oldDesign records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PrintDocumentPrealertSending_oldDesign([FromBody]CommonFour obj)
        {
            DataSet ds = new DataSet();

            DataTable dt = new DataTable();
            dt.Columns.Add("status", typeof(int));
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("statusText", typeof(string));
            //ds.Tables.Add(dt);
            //ds.Tables[0].TableName = "Table";

            DAL objDal = new DAL();
            try
            {
                var message = string.Empty;
                var cneemessage = string.Empty;
                var mail_cnee = string.Empty;
                string ipad, pwd;
                string[] strMails;
                string Mail_From = string.Empty, Mail_To = string.Empty,
                    Mail_CC = string.Empty, Mail_BCC = string.Empty,
                    Mail_Sub = string.Empty, Mail_Body = string.Empty,
                    Mail_Type = string.Empty, Mail_HBNo = string.Empty,
                    Mail_HBNoAF = string.Empty, MAWBNO = string.Empty;
                string sendMail = string.Empty;

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_EXP_PRELEART_EXPT_MASTER",
                    obj.Type1, obj.Type2);

                if (ds.Tables.Count > 1)
                {
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        message = "<table width=100% border=1 cellspacing=2 cellpadding=4 ID=Table1><tr><td height=37><div align=center><font size=3 face=Arial><b><font size=4>MANILAL PATEL - " + ds.Tables[0].Rows[0]["CITYNAME"].ToString().Trim() + "<br><br></font></b></font><font face=Arial size=3>AIR FREIGHT - PREALERT</font></div></td></tr><tr><td height=2><table width=100% border=0 cellspacing=1 cellpadding=5 ID=Table2><tr><td width=5%><b><font size=2 face=Arial>TO</font></b></td><td width=30%>&nbsp;</td><td width=7%><b><font size=2 face=Arial>ATTN</font></b></td><td width=34%>&nbsp;</td>	<td width=7%><b><font size=2 face=Arial>DATE</font></b></td><td width=17%><font size=2 face=Arial>".ToString() + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</font>&nbsp;</td></tr></table></td></tr>  </font>&nbsp;</td></tr></table></td></tr>";
                        message = message + "<tr><td>";
                        message = message + "<table width=100% border=1 cellspacing=0 cellpadding=5 ID=Table3>";
                        message = message + "<tr><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CONSOLE NO.</font></b></td><td width=18% colspan=5><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["consoleno"].ToString().Trim() + "</font></td></tr>";
                        message = message + "<tr><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>MAWB NO</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["aerobillno"].ToString().Trim() + "</font></td><td width=20%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>FLT NO.</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["FltNo"].ToString().Trim() + "</font></td><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CONX FLT</font></b></td><td width=16%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["ConxFlt"].ToString().Trim() + "&nbsp;</font></td></tr>";
                        message = message + "<tr><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>TOTAL PKGS</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["TotalPkgs"].ToString().Trim() + "</font></td><td width=20%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>GROSS WT.</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["GrossWT"].ToString().Trim() + "</font></td><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT</font></b></td><td width=16%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["ChblWT"].ToString().Trim() + "</font></td></tr>";
                        message = message + "<tr><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>MAWB FRT</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["MFRT"].ToString().Trim() + "</font></td><td width=20%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CUSTOM CLRD ON</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["CUSTOM"].ToString().Trim() + "</font></td><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>MAWB DEST</font></b></td><td width=16%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["MDestCity"].ToString().Trim() + "</font></td></tr>";
                        if (ds.Tables[0].Rows[0]["ETA"].ToString() != "FALSE")
                        {
                            message = message + "<tr><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>ETA</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["ETA"].ToString().Trim() + "</font></td><td width=20%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'></font></b></td><td width=16%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td></tr>";
                        }
                        message = message + "</table></td></tr>";
                    }
                    if (ds.Tables[1].Rows.Count >= 1)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            message = message + "<tr><td>";
                            message = message + "<table width=100% border=1 cellspacing=0 cellpadding=5 ID=Table4>";
                            message = message + "<tr><td width=13%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>JOB NO</font></b></td><td width=19% colspan=5><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["JobNo"].ToString() + "</font></td></tr>";
                            message = message + "<tr><td width=13%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>HAWB NO</font></b></td>";
                            message = message + "<td width=19%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB_AF"].ToString() + "</font></td>";
                            message = message + "<td width=20%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>HAWB DEST </font></b></td>";
                            message = message + "<td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB_DEST"].ToString() + "</font></td>";
                            message = message + "<td width=13%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>HAWB FRT </font></b></td>";
                            message = message + "<td width=17%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["FREIGHT"].ToString() + "</font></td>";
                            message = message + "</tr>";
                            message = message + "<tr><td width=13%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>TOTAL CTNS</font></b></td>";
                            message = message + "<td width=19%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["TotalCTNS"].ToString() + "</font></td>";
                            message = message + "<td width=20%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>GROSS WT.</font></b></td>";
                            message = message + "<td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["GROSSWT"].ToString() + "</font></td>";
                            message = message + "<td width=13%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT</font></b></td>";
                            message = message + "<td width=17%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CHBLWT"].ToString() + "</font></td>";
                            message = message + "</tr>";
                            message = message + "<tr><td width=13%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>NO OF PCS</font></b></td>";
                            message = message + "<td width=19%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["TotalPcs"].ToString() + "</font></td>";
                            message = message + "<td width=20%><font size=1><b>&nbsp;</b></font></td>";
                            message = message + "<td width=18%><font size=2>&nbsp;</font></td>";
                            message = message + "<td width=13%><font size=1><b>&nbsp;</b></font></td>";
                            message = message + "<td width=17%><font size=2>&nbsp;</font></td>";
                            message = message + "</tr>";
                            message = message + "<tr><td width=13%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CONSIGNEE</font></b></td>";
                            message = message + "<td colspan=5><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Consignee"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;</font></td>";
                            message = message + "</tr>";
                            message = message + "<tr><td width=13%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>SHIPPER</font></b></td>";
                            message = message + "<td colspan=5><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["exporter"].ToString() + "</font></td>";
                            message = message + "</tr>";
                            message = message + "<tr><td width=13%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>COMMODITY</font></b></td>";
                            message = message + "<td colspan=5><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Desc"].ToString() + "</font></td>";
                            message = message + "</tr>";
                            message = message + "</table><br>";
                            message = message + "<table width='100%' border=1 cellspacing=0 cellpadding=3><tr><td width='13%'> <div align=center><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>P/O NO</b></font></div></td><td width='16%'> <div align=center><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>STY NO</b></font></div></td><td width='13%'> <div align=center><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>CTNS</b></font></div></td><td width='18%'><div align=center><font size=1><b><font face='Verdana, Arial, Helvetica, sans-serif'> DOCS RECD</font></b></font></div></td><td width='18%'><div align=center><font size=1><b><font face='Verdana, Arial, Helvetica, sans-serif'>CGO RECD</font></b></font></div></td><td width='20%'><div align=center><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>DESTINATION DOCS RECD</b></font></div></td><td width='20%'> <div align=center><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>NO.OF PCS</b></font></div></td></tr>";
                            if (ds.Tables[2].Rows.Count >= 1)
                            {
                                for (int j = 0; j < ds.Tables[2].Rows.Count; j++)
                                {
                                    if (ds.Tables[2].Rows[j]["housebillno"].ToString().Trim() == ds.Tables[1].Rows[i]["HAWB"].ToString().Trim())
                                    {
                                        message = message + "<tr><td width=13%><div align=center><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["PoNo"].ToString().Trim() + "</font></div></td>";
                                        message = message + "<td width=16%><div align=center><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["StyleNo"].ToString().Trim() + "</font></div></td>";
                                        message = message + "<td width=13%><div align=center><font size=2><font face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["CTNS"].ToString().Trim();
                                        message = message + "</font></font></div></td><td width=18%><div align=center><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["DocsRecd"].ToString().Trim();
                                        message = message + "</font></div></td><td width=18%><div align=center><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["CgoRecd"].ToString().Trim();
                                        message = message + "</font></div></td><td width=20%><div align=center><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["DestDocsRecd"].ToString().Trim();
                                        message = message + "</font></div></td><td width=20%><div align=center><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["Pieces"].ToString().Trim() + "</font></div></td></tr>";
                                    }
                                }
                            }
                            message = message + "</table></td> </tr>";
                            strMails = ds.Tables[1].Rows[i]["EMail"].ToString().Split('*');

                            cneemessage = "<table width='100%' border='1' cellspacing='3' cellpadding='3' ID='Table1'><tr>	<td><table width='100%' border='0' cellspacing='0' cellpadding='0' ID='Table2'>";
                            cneemessage = cneemessage + "<tr><td width='23%' height='84'><div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td><td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0' ID='Table3'><tr><td colspan='2'><font size='6' face='Arial'><strong>" + ds.Tables[1].Rows[i]["CmpName"].ToString() + "</strong></font></td></tr><tr><td width='48%'><font size='2' face='Arial'></font></td><td width='52%'><font size='2' face='Arial'><br><br>E-MAIL : mplil@free.fr </font></td></tr></table></td></tr></table></td></tr>";
                            cneemessage = cneemessage + "<tr><td><div align='right'><font face='arial' size='2'><strong>E-MAIL MESSAGE</strong></font></div></td></tr>";
                            cneemessage = cneemessage + "<tr><td><table width='100%' border='0' align='center' cellpadding='2' cellspacing='2' ID='Table4'>";
                            cneemessage = cneemessage + "<tr><td width='10%'><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>TO :</font></b></td>";
                            cneemessage = cneemessage + "<td width='43%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Consignee"].ToString() + "&nbsp;</font></td>";
                            cneemessage = cneemessage + "<td width='11%'><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>ATTN :</font></b></td>";
                            cneemessage = cneemessage + "<td width='36%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["ATTN1"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>CC :</font></b></td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["ATTNCC"].ToString() + "</font></td>";
                            cneemessage = cneemessage + "<td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>ATTN :</font></b></td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["ATTN2"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>DATE :</font></b></td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + DateTime.Today.ToString() + "</font></td>";
                            cneemessage = cneemessage + "<td>&nbsp;</td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>N/REF :</font></b></td>";
                            cneemessage = cneemessage + "<td colspan='3'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["JobNo"].ToString() + "&nbsp;";
                            cneemessage = cneemessage + "</font><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "</table></td></tr>";
                            cneemessage = cneemessage + "<tr><td><div align='center'><strong><font size='3' face='Arial'><u>PREALERT</u></font></b></div></td></tr>";
                            cneemessage = cneemessage + "<tr><td height='86'><table width='100%' border='1' cellpadding='2' cellspacing='1' ID='Table5'>";
                            cneemessage = cneemessage + "<tr><td width='19%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>MAWB :</font></b></td><td width='81%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["MAWB"].ToString() + "&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>HAWB :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB"].ToString() + "&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>PROVENANCE :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Provenance"].ToString() + "&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>DESTINATION :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB_DEST"].ToString() + "&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "</table></td></tr>";
                            cneemessage = cneemessage + "<tr><td><table width='100%' border='1' cellspacing='1' cellpadding='2' ID='Table6'>";
                            cneemessage = cneemessage + "<tr><td width='19%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>NBRE DE COLIS:</font></b></td><td width='81%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["NBREDE"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>POIDS BRUT:</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["GROSSWT"].ToString() + "&nbsp;<strong>KG</strong></font></td></tr>";
                            if (ds.Tables[1].Rows[i]["CHBLWT_S"].ToString() != "FALSE")
                            {
                                cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT.:</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CHBLWT"].ToString() + "&nbsp;<strong>KG</strong></font></td></tr>";
                            }
                            cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>CUBAGE :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CUBAGE"].ToString() + "&nbsp;<strong>M3</strong></font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>NATURE :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Desc"].ToString() + "&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "</table></td></tr>";
                            cneemessage = cneemessage + "<tr><td><table width='100%' border='1' cellspacing='1' cellpadding='2' ID='Table7'>";
                            cneemessage = cneemessage + "<tr><td width='19%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>PO NO :</font></b></td><td width='81%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["PoNo"].ToString() + "&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>SHPR :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["exporter"].ToString() + "&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "</table></td></tr>";
                            cneemessage = cneemessage + "<tr><td><table width='100%' border='1' cellspacing='1' cellpadding='2' ID='Table8'>";
                            cneemessage = cneemessage + "<tr><td width='19%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>FREIGHT:</font></b></td><td width='81'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["FREIGHT"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "</table></td></tr>";
                            cneemessage = cneemessage + "<tr><td><table width='100%' border=1 cellspacing=1 cellpadding=2 ID='Table1'><tr><td width='26%'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>CARGO RECD DT.</font></b></td><td width='26%'><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["CargoRecdDT"].ToString() + "</font><strong></strong></td><td width='23%'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>DOCS RECD DT.</font></b></td><td width='25%'><strong></strong><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["DocsRecdDT"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>APPROVAL DT.</font></b></td><td> <font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["ApprovalDT"].ToString() + "&nbsp;</font> </td><td><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>DEST. DOCS RECD DT.</font></b></td><td><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["DescDocsRecdDT"].ToString() + "&nbsp;</font></td></tr>";
                            if (ds.Tables[1].Rows[i]["CLEARANCE"].ToString() != "FALSE")
                            {
                                cneemessage = cneemessage + "<tr><td><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>CLEARANCE DT.</font></b></td><td> <font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["CLEARANCE"].ToString() + "&nbsp;</font> </td><td><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>&nbsp;</font></b></td><td><font size=2 face=Verdana, Arial, Helvetica, sans-serif>&nbsp;</font></td></tr>";
                            }
                            cneemessage = cneemessage + "<tr><td height=26><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>DEPARTURE FLIGHT NO.</font></b></td><td><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["DeptFlightNo"].ToString() + "</font><strong></strong></td><td><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>ETA</font></b></td><td><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["eta"].ToString() + "</font></td></tr></table></td></tr>";
                            cneemessage = cneemessage + "</table>";

                            //For User Log
                            Mail_From = strMails[0].ToString().Trim().Replace(",", ";");
                            Mail_To = strMails[1].ToString().Trim().Replace(",", ";");
                            Mail_CC = strMails[2].ToString().Trim().Replace(",", ";");
                            Mail_BCC = strMails[3].ToString().Trim().Replace(",", ";");

                            //Mail_To = "nisha@manilal.com"
                            //Mail_CC = "sujit@manilal.com"

                            Mail_Sub = strMails[4].ToString().Trim();
                            Mail_Body = Mail_Body + cneemessage.Trim();
                            Mail_Type = "PreAlert";
                            Mail_HBNo = ds.Tables[1].Rows[i]["HAWB"].ToString();
                            ipad = ds.Tables[1].Rows[0]["IPADDS"].ToString();
                            pwd = ds.Tables[1].Rows[0]["PWD"].ToString();

                            Mail_HBNoAF = (i != 0) ? Mail_HBNoAF + "," + ds.Tables[1].Rows[i]["HAWB"].ToString() : ds.Tables[1].Rows[i]["HAWB"].ToString();

                            //Mail_From = "sujit@manilal.com"
                            //Mail_To = "sujit@manilal.com"
                            //Mail_CC = ""
                            sendMail = string.Empty;
                            //sendMail = Send_Mail(Mail_From, Mail_To, Mail_CC, Mail_BCC, Mail_Sub, cneemessage);
                            sendMail = common_sendmail(cneemessage, ipad, Mail_From, Mail_To, Mail_CC, Mail_BCC, pwd, Mail_Sub);
                            // sendMail = common_sendmail(cneemessage, ipad, Mail_From, "pdg.mp@manilal.com", "", "", pwd, Mail_Sub);
                            dt.Rows.Add(100, "HOUSE", sendMail);

                            objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_PRELEART_UserLog", obj.Type1, Mail_HBNo, Mail_Type, Mail_From, Mail_To, Mail_CC, Mail_BCC, Mail_Sub, obj.Type2, obj.Type3, obj.Type4);
                            cneemessage = "";
                        }
                    }

                    strMails = ds.Tables[0].Rows[0]["EMail"].ToString().Trim().Split('*');
                    message = message + "<tr><td><strong><font size=2 face=Arial>" + ds.Tables[0].Rows[0]["REMARK"].ToString().Trim() + "&nbsp; &nbsp;</font></strong></td></tr><tr><td>&nbsp;</td></tr></table>";

                    Mail_From = strMails[0].ToString().Trim().Replace(",", ";");
                    Mail_To = strMails[1].ToString().Trim().Replace(",", ";");
                    Mail_CC = strMails[2].ToString().Trim().Replace(",", ";");
                    Mail_BCC = strMails[3].ToString().Trim().Replace(",", ";");

                    //Mail_To = "nisha@manilal.com"
                    //Mail_CC = "sujit@manilal.com"

                    Mail_Sub = strMails[4].ToString().Trim();
                    Mail_HBNo = Mail_HBNoAF;
                    Mail_Type = "AF-PreAlert";
                    Mail_Body = Mail_Body + message.Trim();

                    ipad = ds.Tables[1].Rows[0]["IPADDS"].ToString();
                    pwd = ds.Tables[1].Rows[0]["PWD"].ToString();



                    sendMail = string.Empty;
                    //  sendMail = Send_Mail(Mail_From, Mail_To, Mail_CC, Mail_BCC, Mail_Sub, message);
                    sendMail = common_sendmail(message, ipad, Mail_From, Mail_To, Mail_CC, Mail_BCC, pwd, Mail_Sub);
                    //  sendMail = common_sendmail(message, ipad, Mail_From, "pdg.mp@manilal.com", "", "", pwd, Mail_Sub);
                    dt.Rows.Add(100, "CONSOLE", sendMail);

                    objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_PRELEART_UPDATE_ALERT", obj.Type1);
                    objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_PRELEART_UserLog", obj.Type1, Mail_HBNo, Mail_Type, Mail_From, Mail_To, Mail_CC, Mail_BCC, Mail_Sub, obj.Type2, obj.Type3, obj.Type4);
                    //WriteToFile(obj.Type1, obj.Type3, Mail_Body.Trim()); not neccasery to save prealert html file save to server
                }
                else
                {
                    dt.Rows.Add(100, "CONSOLE", ds.Tables[0].Rows[0]["Message"].ToString());
                    //ds.Tables[0].Rows[0]["Message"].ToString();
                }
                ds = null;
                ds = new DataSet();
                ds.Tables.Add(dt);
                ds.Tables[0].TableName = "Table";
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentPrealertSending");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform PrintDocumentPrealertSending records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PrintDocumentPrealertSending([FromBody]CommonFour obj)
        {
            DataSet ds = new DataSet();

            DataTable dt = new DataTable();
            dt.Columns.Add("status", typeof(int));
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("statusText", typeof(string));
            //ds.Tables.Add(dt);
            //ds.Tables[0].TableName = "Table";

            DAL objDal = new DAL();
            try
            {
                var message = string.Empty;
                var cneemessage = string.Empty;
                var mail_cnee = string.Empty;
                string ipad, pwd;
                string[] strMails;
                string Mail_From = string.Empty, Mail_To = string.Empty,
                    Mail_CC = string.Empty, Mail_BCC = string.Empty,
                    Mail_Sub = string.Empty, Mail_Body = string.Empty,
                    Mail_Type = string.Empty, Mail_HBNo = string.Empty,
                    Mail_HBNoAF = string.Empty, MAWBNO = string.Empty;
                string sendMail = string.Empty;

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_EXP_PRELEART_EXPT_MASTER",
                    obj.Type1, obj.Type2);
                /*
                  message variable is used for MAWB prealert data
                 
                  cneemessage variable is used for MAWB prealert data
                */

                if (ds.Tables.Count > 1)
                {
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        message = "<table width='80%' border='1' cellspacing=2 cellpadding=4 ID=Table1 align='center'><tr ><td colspan='6'><table width=100% border='0' cellspacing=0 cellpadding=5 ID=Table3 align='center'><tr  height='50'><td height=37 width='35%' align='center' border='none'><img src='http://180.179.207.163/erp-ng/Untitled-1.png' height='70'></td><td height=37 width='55%' border='none'><div><font size=3 color='#191970' face=Arial><b><font size=4>MANILAL PATEL - " + ds.Tables[0].Rows[0]["CITYNAME"].ToString().Trim() + "<br><br></font></b></font><font face=Arial color='#191970'  size=3>AIR FREIGHT - PREALERT</font></div></td></tr></table></td></tr></table>";
                        message = message + "<table width='80%' border='1' cellspacing=0 cellpadding=2 ID=Table3 align='center'><tr><td><table width=100% border='0' cellspacing=0 cellpadding=0 ID=Table3><tr><td colspan='6' height=2><table width=100% border=0 cellspacing=1 cellpadding=0 ID=Table2><tr><td width=5%><b><font size=2 face=Arial>TO</font></b></td><td width=30%>&nbsp;</td><td width=7%><b><font size=2 face=Arial>ATTN</font></b></td><td width=34%>&nbsp;</td>	<td width=7%><b><font size=2 face=Arial>DATE</font></b></td><td width=17%><font size=2 face=Arial>".ToString() + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</font>&nbsp;</td></tr></table></td></tr>  </table></td></tr></table>";
                        //  message = message + "<tr><td>";
                        message = message + "<table width='80%' border='1' cellspacing=0 cellpadding=0 ID=Table3 align='center'><tr><td><table width='100%' border='0' cellspacing=0 cellpadding=2 ID=Table3 align='center'>";
                        message = message + "<tr><td width='9%'border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CONSOLE NO. : </font></b></td>";
                        message = message + "<td width='19%'  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["consoleno"].ToString().Trim() + "</font></td>";
                        message = message + "<td width='9%' border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>MAWB NO. : </font></b></td>";
                        message = message + "<td width='19%' border='none' ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["aerobillno"].ToString().Trim() + "</font></td>";
                        message = message + "<td width='11%' border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>FLT NO. : </font></b></td>";
                        message = message + "<td width='23%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["FltNo"].ToString().Trim() + "</font></td></tr>";
                        message = message + "<tr><td border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CONX FLT : </font></b></td>";
                        message = message + "<td border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["ConxFlt"].ToString().Trim() + "&nbsp;</font></td>";
                        message = message + "<td  border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>TOTAL PKGS : </font></b></td>";
                        message = message + " <td  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["TotalPkgs"].ToString().Trim() + "</font></td>";
                        message = message + "<td  border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>GROSS WT. : </font></b></td>";
                        message = message + " <td  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["GrossWT"].ToString().Trim() + "</font></td></tr>";
                        message = message + "<tr><td align='right'  ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT : </font></b></td>";
                        message = message + "  <td  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["ChblWT"].ToString().Trim() + "</font></td>";
                        message = message + " <td align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>MAWB FRT : </font></b></td>";
                        message = message + "<td  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["MFRT"].ToString().Trim() + "</font></td>";
                        message = message + "<td  align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CUSTOM CLRD ON : </font></b></td>";
                        message = message + "  <td  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["CUSTOM"].ToString().Trim() + "</font></td></tr>";
                        message = message + "<tr><td align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>MAWB DEST. : </font></b></td>";
                        message = message + "   <td  width='18%'  colspan='5' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["MDestCity"].ToString().Trim() + "</font></td></tr>";

                        if (ds.Tables[0].Rows[0]["ETA"].ToString() != "FALSE")
                        {
                            message = message + "<tr><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>ETA :</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["ETA"].ToString().Trim() + "</font></td><td width=20%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'></font></b></td><td width=16%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td></tr>";
                        }
                        message = message + "</table></td></tr>";
                    }
                    if (ds.Tables[1].Rows.Count >= 1)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            message = message + "<tr><td>";

                            message = message + "<table width='100%' border='0' cellspacing=0 cellpadding=2 ID=Table3 align='center'>";
                            message = message + "<tr style='background-color: #26a6d4;'><td width='9%' border='none' align='right'><b><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'>JOB NO : </font></b></td>";
                            message = message + "<td width='19%'  border='none'><font size=2 color='white'  face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["JobNo"].ToString() + "</font></td>";
                            message = message + "<td width='9%' border='none' align='right'><b><font size=1 color='white'  face='Verdana, Arial, Helvetica, sans-serif'>NO OF PCS : </font></b></td>";
                            message = message + "<td width='19%'  border='none'><font size=2 color='white'  face='Verdana,  Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["TotalPcs"].ToString() + "</font></td>";
                            message = message + "<td width='11%' border='none' align='right'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'></font></b></td>";
                            message = message + "<td width='23%' border='none' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'></font></b></td></tr>";
                            message = message + "<tr><td width='9%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>HAWB NO : </font></b></td>";
                            message = message + "<td width='19%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB_AF"].ToString() + "</font></td>";
                            message = message + "<td width='9%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>HAWB DEST : </font></b></td>";
                            message = message + "<td width='19%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB_DEST"].ToString() + "</font></td>";
                            message = message + "<td width='11%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>HAWB FRT : </font></b></td>";
                            message = message + "<td width='23%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["FREIGHT"].ToString() + "</font></td></tr>";
                            message = message + "<tr><td width='9%' align='right'   border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>TOTAL CTNS : </font></b></td>";
                            message = message + "<td width='19%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["TotalCTNS"].ToString() + "</font></td>";
                            message = message + "<td width='9%' align='right'   border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>GROSS WT. : </font></b></td>";
                            message = message + "<td width='19%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["GROSSWT"].ToString() + "</font></td>";
                            message = message + "<td width='11%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT : </font></b></td>";
                            message = message + "<td width='23%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CHBLWT"].ToString() + "</font></td></tr>";
                            message = message + "<tr><td width='9%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif' >CONSIGNEE : </font></b></td>";
                            message = message + "<td  colspan='5' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Consignee"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;</font></td></tr>";
                            message = message + "<tr><td width='9%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif' >SHIPPER : </font></b></td>";
                            message = message + "<td colspan='5' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif' >" + ds.Tables[1].Rows[i]["exporter"].ToString() + "</font></td></tr>";
                            message = message + "<tr><td width='9%' align='right'  border='none'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>COMMODITY : </font></b></td>";
                            message = message + "<td colspan=5 border='none' ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'  >" + ds.Tables[1].Rows[i]["Desc"].ToString() + "</font></td></tr>";
                            message = message + "</table><br>";
                            // message = message + "<table width='100%' border=1 cellspacing=0 cellpadding=0  align='center'><tr><td><table width='100%' border='0' cellspacing=0 cellpadding=2 ID=Table3><tr style='background-color: #26a6d4;'><td width='100px'style='padding-left:4px;' > <div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>P/O NO</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>STY NO</b></font></div></td><td width='80px' style='border - bottom: black 1px solid; '> <div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>COMMODITY</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>CTNS</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '><div ><font size=1><b><font face='Verdana, Arial, Helvetica, sans-serif'> DOCS RECD</font></b></font></div></td><td width='150px' style='border - bottom: black 1px solid; '><div ><font size=1><b><font face='Verdana, Arial, Helvetica, sans-serif'>CGO RECD</font></b></font></div></td><td width='150px' style='border - bottom: black 1px solid; '><div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>DEST DOCS RECD</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>NO.OF PCS</b></font></div></td></tr>";
                            message = message + "<table width='95%' border=0 cellspacing=0 cellpadding=0  align='center'><tr><td><table width='100%' border='1' cellspacing=0 cellpadding=2 ID=Table3><tr style='background-color: #26a6d4;' ><td width='100px'style='padding-left:4px;' > <div ><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>P/O NO</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>STY NO</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>CTNS</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '><div ><font size=1 color='white'><b><font face='Verdana, Arial, Helvetica, sans-serif'> DOCS RECD</font></b></font></div></td><td width='150px' style='border - bottom: black 1px solid; '><div ><font size=1 color='white'><b><font face='Verdana, Arial, Helvetica, sans-serif'>CGO RECD</font></b></font></div></td><td width='150px' style='border - bottom: black 1px solid; '><div ><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>DEST DOCS RECD</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>NO.OF PCS</b></font></div></td></tr>";
                            if (ds.Tables[2].Rows.Count >= 1)
                            {
                                for (int j = 0; j < ds.Tables[2].Rows.Count; j++)
                                {
                                    if (ds.Tables[2].Rows[j]["housebillno"].ToString().Trim() == ds.Tables[1].Rows[i]["HAWB"].ToString().Trim())
                                    {
                                        message = message + "<tr><td width='100px' style='padding-left:4px;'><div ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["PoNo"].ToString().Trim() + "</font></div></td>";
                                        message = message + "<td width='100px'><div ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["StyleNo"].ToString().Trim() + "</font></div></td>";
                                        //  message = message + "<td  border='none' width='100px' ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Desc"].ToString() + "</font></td>";
                                        message = message + "<td width='80px'><div ><font size=2><font face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["CTNS"].ToString().Trim();
                                        message = message + "</font></font></div></td><td width='100px'><div><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["DocsRecd"].ToString().Trim();
                                        message = message + "</font></div></td><td width='100px'><div ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["CgoRecd"].ToString().Trim();
                                        message = message + "</font></div></td><td width='150px'><div ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["DestDocsRecd"].ToString().Trim() + "</font> </div> </td>";
                                        message = message + "<td width='100px'><div ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["Pieces"].ToString().Trim() + "</font></div></td>";
                                        // message = message + "<td  border='none' width=10%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'></font></td>";
                                        // message = message + "</font></div></td></tr>";
                                        message = message + "</tr></table><br></td> </tr>";
                                    }
                                }
                            }
                            //message = message + "</table></td> </tr></td> </tr></table>";
                            message = message + "</td> </tr></table>";
                            strMails = ds.Tables[1].Rows[i]["EMail"].ToString().Split('*');

                            cneemessage = "<table width='70%' border='1' cellspacing='0' cellpadding='0' ID='Table1' align='center'><tr>	<td><table width='100%' border='0' cellspacing='0' cellpadding='0' ID='Table2'>";
                            cneemessage = cneemessage + "<tr height='70'><td width='23%' height='70'><div align='center'><img src='http://180.179.207.163/erp-ng/Untitled-1.png' width='134' height='70'></div></td><td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0' ID='Table3'><tr><td colspan='2'><font size='6'  face='Arial'><strong>" + ds.Tables[1].Rows[i]["CmpName"].ToString() + "</strong></font></td></tr><tr><td width='48%'><font size='2' face='Arial'></font></td><td width='52%'><font size='2' color='black' face='Arial'><br>E-MAIL : airops2.lil@manilal.com </font></td></tr></table></td></tr></table></td></tr>";
                            cneemessage = cneemessage + "<tr height=2><td><div align='right'><font face='arial' size='2'><strong>E-MAIL MESSAGE</strong></font></div></td></tr>";
                            cneemessage = cneemessage + "<tr><td><table width='100%' border='0' align='center' cellpadding='1' cellspacing='2' ID='Table4'>";
                            cneemessage = cneemessage + "<tr><td width='10%'><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>TO :</font></b></td>";
                            cneemessage = cneemessage + "<td width='43%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Consignee"].ToString() + "&nbsp;</font></td>";
                            cneemessage = cneemessage + "<td width='11%'><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>ATTN :</font></b></td>";
                            cneemessage = cneemessage + "<td width='36%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["ATTN1"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>CC :</font></b></td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["ATTNCC"].ToString() + "</font></td>";
                            cneemessage = cneemessage + "<td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>ATTN :</font></b></td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["ATTN2"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>DATE :</font></b></td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + DateTime.Today.ToString() + "</font></td>";
                            cneemessage = cneemessage + "<td>&nbsp;</td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>N/REF :</font></b></td>";
                            cneemessage = cneemessage + "<td colspan='3'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["JobNo"].ToString() + "&nbsp;";
                            cneemessage = cneemessage + "</font><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "</table></td></tr>";
                            cneemessage = cneemessage + "<tr style='background-color: #26a6d4;'><td><div align='center'><strong><font size='3' color='white' face='Arial'><u>PREALERT</u></font></b></div></td></tr>";
                            cneemessage = cneemessage + "<tr><td height='86'><table width='100%' border='0' cellpadding='2' cellspacing='1' ID='Table5'>";
                            cneemessage = cneemessage + "<tr><td width='19%' border='none'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>MAWB :</font></b></td><td border='none'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["MAWB"].ToString() + "&nbsp;</font></td><td width='19%' border='none'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>HAWB :</font></b></td><td border='none'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB"].ToString() + "&nbsp;</font></td></tr>";
                            // cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>HAWB :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB"].ToString() + "&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>PROVENANCE :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Provenance"].ToString() + "&nbsp;</font></td><td width='19%' border='none'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>DESTINATION :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB_DEST"].ToString() + "&nbsp;</font></td></tr>";

                            if (ds.Tables[1].Rows[i]["CHBLWT_S"].ToString() != "FALSE")
                            {
                                cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT.:</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CHBLWT"].ToString() + "&nbsp;<strong>KG</strong></font></td></tr>";
                            }

                            cneemessage = cneemessage + "<tr><td width='19%' border='none'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>FREIGHT:</font></b></td><td width='81' border='none'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["FREIGHT"].ToString() + "</font></td><td border='none' width='19%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>SHPR :</font></b></td><td border='none'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["exporter"].ToString() + "&nbsp;</font></td></tr>";
                            //cneemessage = cneemessage + "</table></td></tr>";
                            cneemessage = cneemessage + "<tr><td width='15%' border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>CARGO RECD DT. :</font></b></td><td width='23%' border='none'><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["CargoRecdDT"].ToString() + "</font><strong></strong></td><td width='15%' border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>DOCS RECD DT. :</font></b></td><td width='25%' border='none'><strong></strong><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["DocsRecdDT"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>APPROVAL DT.:</font></b></td><td border='none'> <font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["ApprovalDT"].ToString() + "&nbsp;</font> </td><td border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>DEST. DOCS RECD DT. :</font></b></td><td border='none'><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["DescDocsRecdDT"].ToString() + "&nbsp;</font></td></tr>";
                            if (ds.Tables[1].Rows[i]["CLEARANCE"].ToString() != "FALSE")
                            {
                                cneemessage = cneemessage + "<tr><td><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>CLEARANCE DT. :</font></b></td><td> <font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["CLEARANCE"].ToString() + "&nbsp;</font> </td><td><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>&nbsp;</font></b></td><td><font size=2 face=Verdana, Arial, Helvetica, sans-serif>&nbsp;</font></td></tr>";
                            }
                            cneemessage = cneemessage + "<tr><td height=26 border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>DEPARTURE FLIGHT NO. :</font></b></td><td border='none'><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["DeptFlightNo"].ToString() + "</font><strong></strong></td><td border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>ETA :</font></b></td><td border='none'><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["eta"].ToString() + "</font></td></tr></table></td></tr>";

                            cneemessage = cneemessage + "<table width=70% border='1' cellspacing=0 cellpadding=0 ID=Table3 align='center'><tr style='background-color: #26a6d4;'><td width='13%' border='none'> <div align='center'><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>PO NO </b></font></div></td><td width='14%' border='none'> <div align='center'><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>NBRE DE COLIS </b></font></div></td><td width='13%' border='none'> <div align='center'><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>POIDS BRUT</b></font></div></td><td width='15%' border='none'><div align='center'><font size=1 color='white'><b><font face='Verdana, Arial, Helvetica, sans-serif'> NATURE</font></b></font></div></td><td width='18%' border='none'><div align='center'><font size=1 color='white'><b><font face='Verdana, Arial, Helvetica, sans-serif'>CUBAGE</font></b></font></div></td></tr>";
                            cneemessage = cneemessage + "<tr><td width=13%><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["PoNo"].ToString() + "&nbsp;</font></td>";
                            cneemessage = cneemessage + "<td width=16% border='none'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["NBREDE"].ToString() + "</font></div></td>";
                            cneemessage = cneemessage + "<td width=16% border='none'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["GROSSWT"].ToString() + "&nbsp;<strong>KG</strong></font></div></td>";
                            cneemessage = cneemessage + "<td width=16% border='none'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Desc"].ToString() + "&nbsp;</font></div></td>";
                            cneemessage = cneemessage + "<td width=16% border='none'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CUBAGE"].ToString() + "&nbsp;<strong>M3</strong></font></div></td>";

                            cneemessage = cneemessage + "</td> </tr></table>";
                            cneemessage = cneemessage + "</table></td></tr>";

                            //For User Log
                            Mail_From = strMails[0].ToString().Trim(); //.Replace(",", ",");
                            Mail_To = strMails[1].ToString().Trim().Replace(",", ", ");
                            Mail_CC = strMails[2].ToString().Trim().Replace(",", ", ");
                            Mail_BCC = strMails[3].ToString().Trim().Replace(",",", ");

                            //Mail_To = "sujit@manilal.com";
                            //Mail_CC = "nalini.pdg@manilal.com";
                            //Mail_To = "nisha@manilal.com"
                            //Mail_CC = "sujit@manilal.com"

                            Mail_Sub = strMails[4].ToString().Trim();
                            Mail_Body = Mail_Body + cneemessage.Trim();
                            Mail_Type = "PreAlert";
                            Mail_HBNo = ds.Tables[1].Rows[i]["HAWB"].ToString();
                            ipad = ds.Tables[1].Rows[0]["IPADDS"].ToString();
                            pwd = ds.Tables[1].Rows[0]["PWD"].ToString();

                            Mail_HBNoAF = (i != 0) ? Mail_HBNoAF + "," + ds.Tables[1].Rows[i]["HAWB"].ToString() : ds.Tables[1].Rows[i]["HAWB"].ToString();

                            //Mail_From = "sujit@manilal.com"
                            //Mail_To = "sujit@manilal.com"
                            //Mail_CC = ""
                            sendMail = string.Empty;
                            //sendMail = Send_Mail(Mail_From, Mail_To, Mail_CC, Mail_BCC, Mail_Sub, cneemessage);
                            sendMail = common_sendmail(cneemessage, ipad, Mail_From, Mail_To, Mail_CC, Mail_BCC, pwd, Mail_Sub);
                            // sendMail = common_sendmail(cneemessage, ipad, Mail_From, "pdg.mp@manilal.com", "", "", pwd, Mail_Sub);
                            dt.Rows.Add(100, "HOUSE", sendMail);

                            objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_PRELEART_UserLog", obj.Type1, Mail_HBNo, Mail_Type, Mail_From, Mail_To, Mail_CC, Mail_BCC, Mail_Sub, obj.Type2, obj.Type3, obj.Type4);
                            cneemessage = "";
                        }
                    }

                    strMails = ds.Tables[0].Rows[0]["EMail"].ToString().Trim().Split('*');
                    message = message + "<tr><td><strong><font size=2 face=Arial>" + ds.Tables[0].Rows[0]["REMARK"].ToString().Trim() + "&nbsp; &nbsp;</font></strong></td></tr><tr><td>&nbsp;</td></tr></table>";

                    //Mail_From = strMails[0].ToString().Trim().Replace(",", ";");
                    //Mail_To = strMails[1].ToString().Trim().Replace(",", ";");
                    //Mail_CC = strMails[2].ToString().Trim().Replace(",", ";"); //strMails[2].ToString().Trim().Replace(",", ";");
                    //Mail_BCC = strMails[3].ToString().Trim().Replace(",", ";");

                    Mail_From = strMails[0].ToString().Trim().Replace(",", ",");
                    Mail_To = strMails[1].ToString().Trim().Replace(",", ",");
                    Mail_CC = strMails[2].ToString().Trim().Replace(",", ", "); //strMails[2].ToString().Trim().Replace(",", ";");
                    Mail_BCC = strMails[3].ToString().Trim().Replace(",", ",");

                    //Mail_To = "nalini.pdg@manilal.com";
                    //Mail_CC = "sujit@manilal.com";

                    Mail_Sub = strMails[4].ToString().Trim();
                    Mail_HBNo = Mail_HBNoAF;
                    Mail_Type = "AF-PreAlert";
                    Mail_Body = Mail_Body + message.Trim();

                    ipad = ds.Tables[1].Rows[0]["IPADDS"].ToString();
                    pwd = ds.Tables[1].Rows[0]["PWD"].ToString();


                    sendMail = string.Empty;
                    sendMail = common_sendmail(message, ipad, Mail_From, Mail_To, Mail_CC, Mail_BCC, pwd, Mail_Sub);
                    dt.Rows.Add(100, "CONSOLE", sendMail);

                }
                else
                {
                    dt.Rows.Add(100, "CONSOLE", ds.Tables[0].Rows[0]["Message"].ToString());
                    //ds.Tables[0].Rows[0]["Message"].ToString();
                }
                ds = null;
                ds = new DataSet();
                ds.Tables.Add(dt);
                ds.Tables[0].TableName = "Table";
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentPrealertSending");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform PrintDocumentPrealertSending prev records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PrintDocumentPrealertSending_prev([FromBody]CommonFour obj)
        {
            DataSet ds = new DataSet();

            DataTable dt = new DataTable();
            dt.Columns.Add("status", typeof(int));
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("statusText", typeof(string));
            //ds.Tables.Add(dt);
            //ds.Tables[0].TableName = "Table";

            DAL objDal = new DAL();
            try
            {
                var message = string.Empty;
                var cneemessage = string.Empty;
                var mail_cnee = string.Empty;
                string ipad, pwd;
                string[] strMails;
                string Mail_From = string.Empty, Mail_To = string.Empty,
                    Mail_CC = string.Empty, Mail_BCC = string.Empty,
                    Mail_Sub = string.Empty, Mail_Body = string.Empty,
                    Mail_Type = string.Empty, Mail_HBNo = string.Empty,
                    Mail_HBNoAF = string.Empty, MAWBNO = string.Empty;
                string sendMail = string.Empty;

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_EXP_PRELEART_EXPT_MASTER",
                    obj.Type1, obj.Type2);
                /*
                  message variable is used for MAWB prealert data
                 
                  cneemessage variable is used for MAWB prealert data
                */

                if (ds.Tables.Count > 1)
                {
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        message = "<table width='80%' border='1' cellspacing=2 cellpadding=4 ID=Table1 align='center'><tr ><td colspan='6'><table width=100% border='0' cellspacing=0 cellpadding=5 ID=Table3 align='center'><tr  height='50'><td height=37 width='35%' align='center' border='none'><img src='http://180.179.207.163/erp-ng/Untitled-1.png' height='70'></td><td height=37 width='55%' border='none'><div><font size=3 color='#191970' face=Arial><b><font size=4>MANILAL PATEL - " + ds.Tables[0].Rows[0]["CITYNAME"].ToString().Trim() + "<br><br></font></b></font><font face=Arial color='#191970'  size=3>AIR FREIGHT - PREALERT</font></div></td></tr></table></td></tr></table>";
                        message = message + "<table width='80%' border='1' cellspacing=0 cellpadding=2 ID=Table3 align='center'><tr><td><table width=100% border='0' cellspacing=0 cellpadding=0 ID=Table3><tr><td colspan='6' height=2><table width=100% border=0 cellspacing=1 cellpadding=0 ID=Table2><tr><td width=5%><b><font size=2 face=Arial>TO</font></b></td><td width=30%>&nbsp;</td><td width=7%><b><font size=2 face=Arial>ATTN</font></b></td><td width=34%>&nbsp;</td>	<td width=7%><b><font size=2 face=Arial>DATE</font></b></td><td width=17%><font size=2 face=Arial>".ToString() + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "</font>&nbsp;</td></tr></table></td></tr>  </table></td></tr></table>";
                        //  message = message + "<tr><td>";
                        message = message + "<table width='80%' border='1' cellspacing=0 cellpadding=0 ID=Table3 align='center'><tr><td><table width='100%' border='0' cellspacing=0 cellpadding=2 ID=Table3 align='center'>";
                        message = message + "<tr><td width='9%'border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CONSOLE NO. : </font></b></td>";
                        message = message + "<td width='19%'  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["consoleno"].ToString().Trim() + "</font></td>";
                        message = message + "<td width='9%' border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>MAWB NO. : </font></b></td>";
                        message = message + "<td width='19%' border='none' ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["aerobillno"].ToString().Trim() + "</font></td>";
                        message = message + "<td width='11%' border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>FLT NO. : </font></b></td>";
                        message = message + "<td width='23%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["FltNo"].ToString().Trim() + "</font></td></tr>";
                        message = message + "<tr><td border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CONX FLT : </font></b></td>";
                        message = message + "<td border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["ConxFlt"].ToString().Trim() + "&nbsp;</font></td>";
                        message = message + "<td  border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>TOTAL PKGS : </font></b></td>";
                        message = message + " <td  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["TotalPkgs"].ToString().Trim() + "</font></td>";
                        message = message + "<td  border='none' align='right' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>GROSS WT. : </font></b></td>";
                        message = message + " <td  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["GrossWT"].ToString().Trim() + "</font></td></tr>";
                        message = message + "<tr><td align='right'  ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT : </font></b></td>";
                        message = message + "  <td  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["ChblWT"].ToString().Trim() + "</font></td>";
                        message = message + " <td align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>MAWB FRT : </font></b></td>";
                        message = message + "<td  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["MFRT"].ToString().Trim() + "</font></td>";
                        message = message + "<td  align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CUSTOM CLRD ON : </font></b></td>";
                        message = message + "  <td  border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["CUSTOM"].ToString().Trim() + "</font></td></tr>";
                        message = message + "<tr><td align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>MAWB DEST. : </font></b></td>";
                        message = message + "   <td  width='18%'  colspan='5' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["MDestCity"].ToString().Trim() + "</font></td></tr>";

                        if (ds.Tables[0].Rows[0]["ETA"].ToString() != "FALSE")
                        {
                            message = message + "<tr><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>ETA :</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[0].Rows[0]["ETA"].ToString().Trim() + "</font></td><td width=20%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></b></td><td width=18%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td><td width=14%><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'></font></b></td><td width=16%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td></tr>";
                        }
                        message = message + "</table></td></tr>";
                    }
                    if (ds.Tables[1].Rows.Count >= 1)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            message = message + "<tr><td>";

                            message = message + "<table width='100%' border='0' cellspacing=0 cellpadding=2 ID=Table3 align='center'>";
                            message = message + "<tr style='background-color: #26a6d4;'><td width='9%' border='none' align='right'><b><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'>JOB NO : </font></b></td>";
                            message = message + "<td width='19%'  border='none'><font size=2 color='white'  face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["JobNo"].ToString() + "</font></td>";
                            message = message + "<td width='9%' border='none' align='right'><b><font size=1 color='white'  face='Verdana, Arial, Helvetica, sans-serif'>NO OF PCS : </font></b></td>";
                            message = message + "<td width='19%'  border='none'><font size=2 color='white'  face='Verdana,  Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["TotalPcs"].ToString() + "</font></td>";
                            message = message + "<td width='11%' border='none' align='right'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'></font></b></td>";
                            message = message + "<td width='23%' border='none' ><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'></font></b></td></tr>";
                            message = message + "<tr><td width='9%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>HAWB NO : </font></b></td>";
                            message = message + "<td width='19%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB_AF"].ToString() + "</font></td>";
                            message = message + "<td width='9%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>HAWB DEST : </font></b></td>";
                            message = message + "<td width='19%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB_DEST"].ToString() + "</font></td>";
                            message = message + "<td width='11%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>HAWB FRT : </font></b></td>";
                            message = message + "<td width='23%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["FREIGHT"].ToString() + "</font></td></tr>";
                            message = message + "<tr><td width='9%' align='right'   border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>TOTAL CTNS : </font></b></td>";
                            message = message + "<td width='19%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["TotalCTNS"].ToString() + "</font></td>";
                            message = message + "<td width='9%' align='right'   border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>GROSS WT. : </font></b></td>";
                            message = message + "<td width='19%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["GROSSWT"].ToString() + "</font></td>";
                            message = message + "<td width='11%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT : </font></b></td>";
                            message = message + "<td width='23%' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CHBLWT"].ToString() + "</font></td></tr>";
                            message = message + "<tr><td width='9%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif' >CONSIGNEE : </font></b></td>";
                            message = message + "<td  colspan='5' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Consignee"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;</font></td></tr>";
                            message = message + "<tr><td width='9%' align='right'  border='none'><b><font size=1 face='Verdana, Arial, Helvetica, sans-serif' >SHIPPER : </font></b></td>";
                            message = message + "<td colspan='5' border='none'><font size=2 face='Verdana, Arial, Helvetica, sans-serif' >" + ds.Tables[1].Rows[i]["exporter"].ToString() + "</font></td></tr>";
                            message = message + "<tr><td width='9%' align='right'  border='none'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>COMMODITY : </font></b></td>";
                            message = message + "<td colspan=5 border='none' ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'  >" + ds.Tables[1].Rows[i]["Desc"].ToString() + "</font></td></tr>";
                            message = message + "</table><br>";
                            // message = message + "<table width='100%' border=1 cellspacing=0 cellpadding=0  align='center'><tr><td><table width='100%' border='0' cellspacing=0 cellpadding=2 ID=Table3><tr style='background-color: #26a6d4;'><td width='100px'style='padding-left:4px;' > <div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>P/O NO</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>STY NO</b></font></div></td><td width='80px' style='border - bottom: black 1px solid; '> <div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>COMMODITY</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>CTNS</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '><div ><font size=1><b><font face='Verdana, Arial, Helvetica, sans-serif'> DOCS RECD</font></b></font></div></td><td width='150px' style='border - bottom: black 1px solid; '><div ><font size=1><b><font face='Verdana, Arial, Helvetica, sans-serif'>CGO RECD</font></b></font></div></td><td width='150px' style='border - bottom: black 1px solid; '><div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>DEST DOCS RECD</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 face='Verdana, Arial, Helvetica, sans-serif'><b>NO.OF PCS</b></font></div></td></tr>";
                            message = message + "<table width='95%' border=0 cellspacing=0 cellpadding=0  align='center'><tr><td><table width='100%' border='1' cellspacing=0 cellpadding=2 ID=Table3><tr style='background-color: #26a6d4;' ><td width='100px'style='padding-left:4px;' > <div ><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>P/O NO</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>STY NO</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>CTNS</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '><div ><font size=1 color='white'><b><font face='Verdana, Arial, Helvetica, sans-serif'> DOCS RECD</font></b></font></div></td><td width='150px' style='border - bottom: black 1px solid; '><div ><font size=1 color='white'><b><font face='Verdana, Arial, Helvetica, sans-serif'>CGO RECD</font></b></font></div></td><td width='150px' style='border - bottom: black 1px solid; '><div ><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>DEST DOCS RECD</b></font></div></td><td width='100px' style='border - bottom: black 1px solid; '> <div ><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>NO.OF PCS</b></font></div></td></tr>";
                            if (ds.Tables[2].Rows.Count >= 1)
                            {
                                for (int j = 0; j < ds.Tables[2].Rows.Count; j++)
                                {
                                    if (ds.Tables[2].Rows[j]["housebillno"].ToString().Trim() == ds.Tables[1].Rows[i]["HAWB"].ToString().Trim())
                                    {
                                        message = message + "<tr><td width='100px' style='padding-left:4px;'><div ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["PoNo"].ToString().Trim() + "</font></div></td>";
                                        message = message + "<td width='100px'><div ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["StyleNo"].ToString().Trim() + "</font></div></td>";
                                        //  message = message + "<td  border='none' width='100px' ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Desc"].ToString() + "</font></td>";
                                        message = message + "<td width='80px'><div ><font size=2><font face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["CTNS"].ToString().Trim();
                                        message = message + "</font></font></div></td><td width='100px'><div><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["DocsRecd"].ToString().Trim();
                                        message = message + "</font></div></td><td width='100px'><div ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["CgoRecd"].ToString().Trim();
                                        message = message + "</font></div></td><td width='150px'><div ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>";
                                        message = message + ds.Tables[2].Rows[j]["DestDocsRecd"].ToString().Trim();
                                        message = message + "<td width='100px'><div ><font size=2 face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[2].Rows[j]["Pieces"].ToString().Trim() + "</font></div></td>";
                                        // message = message + "<td  border='none' width=10%><font size=2 face='Verdana, Arial, Helvetica, sans-serif'></font></td>";
                                        message = message + "</font></div></td></tr>";

                                    }
                                }
                            }
                            message = message + "</table></td> </tr>";
                            strMails = ds.Tables[1].Rows[i]["EMail"].ToString().Split('*');

                            cneemessage = "<table width='70%' border='1' cellspacing='0' cellpadding='0' ID='Table1' align='center'><tr>	<td><table width='100%' border='0' cellspacing='0' cellpadding='0' ID='Table2'>";
                            cneemessage = cneemessage + "<tr style='background-color: #26a6d4;' height='70'><td width='23%' height='70'><div align='center'><img src='http://180.179.207.163/erp-ng/Untitled-1.png' width='134' height='70'></div></td><td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0' ID='Table3'><tr><td colspan='2'><font size='6' color='white' face='Arial'><strong>" + ds.Tables[1].Rows[i]["CmpName"].ToString() + "</strong></font></td></tr><tr><td width='48%'><font size='2' color='white' face='Arial'></font></td><td width='52%'><font size='2' color='black' face='Arial'><br>E-MAIL : mplil@free.fr </font></td></tr></table></td></tr></table></td></tr>";
                            cneemessage = cneemessage + "<tr height=2><td><div align='right'><font face='arial' size='2'><strong>E-MAIL MESSAGE</strong></font></div></td></tr>";
                            cneemessage = cneemessage + "<tr><td><table width='100%' border='0' align='center' cellpadding='1' cellspacing='2' ID='Table4'>";
                            cneemessage = cneemessage + "<tr><td width='10%'><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>TO :</font></b></td>";
                            cneemessage = cneemessage + "<td width='43%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Consignee"].ToString() + "&nbsp;</font></td>";
                            cneemessage = cneemessage + "<td width='11%'><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>ATTN :</font></b></td>";
                            cneemessage = cneemessage + "<td width='36%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["ATTN1"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>CC :</font></b></td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["ATTNCC"].ToString() + "</font></td>";
                            cneemessage = cneemessage + "<td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>ATTN :</font></b></td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["ATTN2"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>DATE :</font></b></td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + DateTime.Today.ToString() + "</font></td>";
                            cneemessage = cneemessage + "<td>&nbsp;</td>";
                            cneemessage = cneemessage + "<td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>N/REF :</font></b></td>";
                            cneemessage = cneemessage + "<td colspan='3'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["JobNo"].ToString() + "&nbsp;";
                            cneemessage = cneemessage + "</font><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "</table></td></tr>";
                            cneemessage = cneemessage + "<tr style='background-color: #26a6d4;'><td><div align='center'><strong><font size='3' color='white' face='Arial'><u>PREALERT</u></font></b></div></td></tr>";
                            cneemessage = cneemessage + "<tr><td height='86'><table width='100%' border='0' cellpadding='2' cellspacing='1' ID='Table5'>";
                            cneemessage = cneemessage + "<tr><td width='19%' border='none'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>MAWB :</font></b></td><td border='none'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["MAWB"].ToString() + "&nbsp;</font></td><td width='19%' border='none'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>HAWB :</font></b></td><td border='none'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB"].ToString() + "&nbsp;</font></td></tr>";
                            // cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>HAWB :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB"].ToString() + "&nbsp;</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>PROVENANCE :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Provenance"].ToString() + "&nbsp;</font></td><td width='19%' border='none'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>DESTINATION :</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["HAWB_DEST"].ToString() + "&nbsp;</font></td></tr>";

                            if (ds.Tables[1].Rows[i]["CHBLWT_S"].ToString() != "FALSE")
                            {
                                cneemessage = cneemessage + "<tr><td><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>CHBL WT.:</font></b></td><td><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CHBLWT"].ToString() + "&nbsp;<strong>KG</strong></font></td></tr>";
                            }

                            cneemessage = cneemessage + "<tr><td width='19%' border='none'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>FREIGHT:</font></b></td><td width='81' border='none'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["FREIGHT"].ToString() + "</font></td><td border='none' width='19%'><b><font size='1' face='Verdana, Arial, Helvetica, sans-serif'>SHPR :</font></b></td><td border='none'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["exporter"].ToString() + "&nbsp;</font></td></tr>";
                            //cneemessage = cneemessage + "</table></td></tr>";
                            cneemessage = cneemessage + "<tr><td width='15%' border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>CARGO RECD DT. :</font></b></td><td width='23%' border='none'><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["CargoRecdDT"].ToString() + "</font><strong></strong></td><td width='15%' border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>DOCS RECD DT. :</font></b></td><td width='25%' border='none'><strong></strong><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["DocsRecdDT"].ToString() + "</font></td></tr>";
                            cneemessage = cneemessage + "<tr><td border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>APPROVAL DT.:</font></b></td><td border='none'> <font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["ApprovalDT"].ToString() + "&nbsp;</font> </td><td border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>DEST. DOCS RECD DT. :</font></b></td><td border='none'><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["DescDocsRecdDT"].ToString() + "&nbsp;</font></td></tr>";
                            if (ds.Tables[1].Rows[i]["CLEARANCE"].ToString() != "FALSE")
                            {
                                cneemessage = cneemessage + "<tr><td><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>CLEARANCE DT. :</font></b></td><td> <font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["CLEARANCE"].ToString() + "&nbsp;</font> </td><td><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>&nbsp;</font></b></td><td><font size=2 face=Verdana, Arial, Helvetica, sans-serif>&nbsp;</font></td></tr>";
                            }
                            cneemessage = cneemessage + "<tr><td height=26 border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>DEPARTURE FLIGHT NO. :</font></b></td><td border='none'><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["DeptFlightNo"].ToString() + "</font><strong></strong></td><td border='none'><b><font size=1 face=Verdana, Arial, Helvetica, sans-serif>ETA :</font></b></td><td border='none'><font size=2 face=Verdana, Arial, Helvetica, sans-serif>" + ds.Tables[1].Rows[i]["eta"].ToString() + "</font></td></tr></table></td></tr>";

                            cneemessage = cneemessage + "<table width=70% border='1' cellspacing=0 cellpadding=0 ID=Table3 align='center'><tr style='background-color: #26a6d4;'><td width='13%' border='none'> <div align='center'><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>PO NO </b></font></div></td><td width='14%' border='none'> <div align='center'><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>NBRE DE COLIS </b></font></div></td><td width='13%' border='none'> <div align='center'><font size=1 color='white' face='Verdana, Arial, Helvetica, sans-serif'><b>POIDS BRUT</b></font></div></td><td width='15%' border='none'><div align='center'><font size=1 color='white'><b><font face='Verdana, Arial, Helvetica, sans-serif'> NATURE</font></b></font></div></td><td width='18%' border='none'><div align='center'><font size=1 color='white'><b><font face='Verdana, Arial, Helvetica, sans-serif'>CUBAGE</font></b></font></div></td></tr>";
                            cneemessage = cneemessage + "<tr><td width=13%><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["PoNo"].ToString() + "&nbsp;</font></td>";
                            cneemessage = cneemessage + "<td width=16% border='none'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["NBREDE"].ToString() + "</font></div></td>";
                            cneemessage = cneemessage + "<td width=16% border='none'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["GROSSWT"].ToString() + "&nbsp;<strong>KG</strong></font></div></td>";
                            cneemessage = cneemessage + "<td width=16% border='none'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["Desc"].ToString() + "&nbsp;</font></div></td>";
                            cneemessage = cneemessage + "<td width=16% border='none'><div align='center'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'>" + ds.Tables[1].Rows[i]["CUBAGE"].ToString() + "&nbsp;<strong>M3</strong></font></div></td>";

                            cneemessage = cneemessage + "</td> </tr></table>";
                            cneemessage = cneemessage + "</table></td></tr>";

                            //For User Log
                            Mail_From = strMails[0].ToString().Trim().Replace(",", ";");
                            //Mail_To = strMails[1].ToString().Trim().Replace(",", ";");
                            //Mail_CC = strMails[2].ToString().Trim().Replace(",", ";");
                            //Mail_BCC = strMails[3].ToString().Trim().Replace(",", ";");

                            Mail_To = "sujit@manilal.com";
                            Mail_CC = "nalini.pdg@manilal.com";
                            //Mail_To = "nisha@manilal.com"
                            //Mail_CC = "sujit@manilal.com"

                            Mail_Sub = strMails[4].ToString().Trim();
                            Mail_Body = Mail_Body + cneemessage.Trim();
                            Mail_Type = "PreAlert";
                            Mail_HBNo = ds.Tables[1].Rows[i]["HAWB"].ToString();
                            ipad = ds.Tables[1].Rows[0]["IPADDS"].ToString();
                            pwd = ds.Tables[1].Rows[0]["PWD"].ToString();

                            Mail_HBNoAF = (i != 0) ? Mail_HBNoAF + "," + ds.Tables[1].Rows[i]["HAWB"].ToString() : ds.Tables[1].Rows[i]["HAWB"].ToString();

                            //Mail_From = "sujit@manilal.com"
                            //Mail_To = "sujit@manilal.com"
                            //Mail_CC = ""
                            sendMail = string.Empty;
                            //sendMail = Send_Mail(Mail_From, Mail_To, Mail_CC, Mail_BCC, Mail_Sub, cneemessage);
                            sendMail = common_sendmail(cneemessage, ipad, Mail_From, Mail_To, Mail_CC, Mail_BCC, pwd, Mail_Sub);
                            // sendMail = common_sendmail(cneemessage, ipad, Mail_From, "pdg.mp@manilal.com", "", "", pwd, Mail_Sub);
                            dt.Rows.Add(100, "HOUSE", sendMail);

                            objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_PRELEART_UserLog", obj.Type1, Mail_HBNo, Mail_Type, Mail_From, Mail_To, Mail_CC, Mail_BCC, Mail_Sub, obj.Type2, obj.Type3, obj.Type4);
                            cneemessage = "";
                        }
                    }

                    strMails = ds.Tables[0].Rows[0]["EMail"].ToString().Trim().Split('*');
                    message = message + "<tr><td><strong><font size=2 face=Arial>" + ds.Tables[0].Rows[0]["REMARK"].ToString().Trim() + "&nbsp; &nbsp;</font></strong></td></tr><tr><td>&nbsp;</td></tr></table>";

                    Mail_From = strMails[0].ToString().Trim().Replace(",", ";");
                    //Mail_To = strMails[1].ToString().Trim().Replace(",", ";");
                    //Mail_CC = strMails[2].ToString().Trim().Replace(",", ";"); //strMails[2].ToString().Trim().Replace(",", ";");
                    //Mail_BCC = strMails[3].ToString().Trim().Replace(",", ";");

                    Mail_To = "sujit@manilal.com";
                    Mail_CC = "nalini.pdg@manilal.com";

                    Mail_Sub = strMails[4].ToString().Trim();
                    Mail_HBNo = Mail_HBNoAF;
                    Mail_Type = "AF-PreAlert";
                    Mail_Body = Mail_Body + message.Trim();

                    ipad = ds.Tables[1].Rows[0]["IPADDS"].ToString();
                    pwd = ds.Tables[1].Rows[0]["PWD"].ToString();


                    sendMail = string.Empty;
                    sendMail = common_sendmail(message, ipad, Mail_From, Mail_To, Mail_CC, Mail_BCC, pwd, Mail_Sub);
                    dt.Rows.Add(100, "CONSOLE", sendMail);

                }
                else
                {
                    dt.Rows.Add(100, "CONSOLE", ds.Tables[0].Rows[0]["Message"].ToString());
                    //ds.Tables[0].Rows[0]["Message"].ToString();
                }
                ds = null;
                ds = new DataSet();
                ds.Tables.Add(dt);
                ds.Tables[0].TableName = "Table";
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentPrealertSending");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        private string common_sendmail(string mail_body, string ipadd, string Frmmail, string Tomail, string cc, string bcc, string pwd, string subject)
        {
            string status = string.Empty;
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            try
            {
                if (Frmmail != "")
                {
                    mail.From = new System.Net.Mail.MailAddress(Frmmail);
                }

                if (Tomail != "")
                {
                    mail.To.Add(new System.Net.Mail.MailAddress(Tomail));
                }
                if (cc != "")
                {
                    mail.CC.Add(new System.Net.Mail.MailAddress(cc));
                }
                mail.Subject = subject;
                mail.Body = mail_body;
                mail.IsBodyHtml = true;
                if (Tomail != "" || cc != "")
                {
                    if (bcc != "")
                    {
                        //MailBcc = MailBcc + ";pdg.mp@manilal.com";
                        mail.Bcc.Add(new System.Net.Mail.MailAddress(bcc));
                    }
                    else
                    {
                        bcc = "pdg.mp@manilal.com";
                        //mail.Bcc.Add(new System.Net.Mail.MailAddress(MailBcc));
                    }
                    System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient(ipadd);
                    SmtpServer.Port = 587; //25
                    SmtpServer.Credentials = new System.Net.NetworkCredential(Frmmail, pwd);
                    SmtpServer.EnableSsl = false;
                    SmtpServer.Send(mail);
                    status = "Mail Send Successfully.";
                }
                else
                {
                    status = "There is no Mail Address to Send Mail.";
                }
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return status;
        }


        private string Send_Mail(string MailFrom, string MailTo, string MailCC, string MailBcc, string MailSub, string MailBody)
        {
            string status = string.Empty;
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            try
            {
                if (MailFrom != "")
                {
                    mail.From = new System.Net.Mail.MailAddress(MailFrom);
                }
                if (MailTo == "")
                {
                    MailTo = "sanoj.pdg@manilal.com";
                }
                if (MailTo != "")
                {
                    mail.To.Add(new System.Net.Mail.MailAddress(MailTo));
                }
                if (MailCC != "")
                {
                    mail.CC.Add(new System.Net.Mail.MailAddress(MailCC));
                }
                mail.Subject = MailSub;
                mail.Body = MailBody;
                mail.IsBodyHtml = true;
                if (MailTo != "" || MailCC != "")
                {
                    if (MailBcc != "")
                    {
                        //MailBcc = MailBcc + ";pdg.mp@manilal.com";
                        //mail.Bcc.Add(new System.Net.Mail.MailAddress(MailBcc));
                    }
                    else
                    {
                        //MailBcc = "pdg.mp@manilal.com";
                        //mail.Bcc.Add(new System.Net.Mail.MailAddress(MailBcc));
                    }
                    System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("LOCALHOST");
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(MailFrom, "WkuxkZo9ik9");
                    SmtpServer.EnableSsl = false;
                    SmtpServer.Send(mail);
                    status = "Mail Send Successfully.";
                }
                else
                {
                    status = "There is no Mail Address to Send Mail.";
                }
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return status;
        }

        private void WriteToFile(string pMABNO, string pMakerId, string pMessage)
        {
            string oPreAlertFile;
            string oFilePath;
            System.IO.StreamWriter oStreamPreAlert = null;
            try
            {
                oPreAlertFile = ("PREALERT_"
                            + (pMABNO + ("_"
                            + (DateTime.Now.ToString("yyyyMMddHHmm") + ("_"
                            + (pMakerId + ".html"))))));
                oFilePath = System.Configuration.ConfigurationManager.AppSettings["FILE_PATH"];
                if (System.IO.File.Exists((oFilePath + ("\\" + oPreAlertFile))))
                {
                    System.IO.File.Delete((oFilePath + ("\\" + oPreAlertFile)));
                }

                oStreamPreAlert = System.IO.File.CreateText((oFilePath + ("\\" + oPreAlertFile)));
                oStreamPreAlert.WriteLine("");
                oStreamPreAlert.WriteLine("");
                oStreamPreAlert.WriteLine(pMessage);
                oStreamPreAlert.WriteLine("");
                oStreamPreAlert.WriteLine("");
            }
            finally
            {
                if (!(oStreamPreAlert == null))
                {
                    oStreamPreAlert.Close();
                }
                oStreamPreAlert = null;
            }
        }

        /// <summary>Perform PrintDocumentPrealertSendingView records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PrintDocumentPrealertSendingView([FromUri]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_CONSOLE_PREALERT_VIEW",
                    obj.Type1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrintDocumentPrealertSendingView");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //--------------------------------------------------END Print Document-------------------------------------------------------------

        //--------------------------------------------------START Shipment Progress-----------------------------------------------------------
        /// <summary>Perform ShipmentCommonSearch records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ShipmentCommonSearch([FromUri]CommonFive obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_CONSIGNMENT_SEARCH",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ShipmentCommonSearch");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ShipmentCommonView records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ShipmentCommonView([FromUri]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_CONSIGNMENT",
                    obj.Type1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ShipmentCommonView");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ShipmentProgressPopulate records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ShipmentProgressPopulate([FromUri]CommonFour obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_CONSIGNMENT_POPULATE",
                    obj.Type1, obj.Type2, (obj.Type3 != null) ? obj.Type3 : "", obj.Type4);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ShipmentProgressPopulate");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ShippingBillShipmentProgressUpdate records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ShippingBillShipmentProgressUpdate([FromBody]ShippingBill obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_SHIPPING_BILL",
                    obj.PkId, obj.ExptNo, obj.CustomDate, obj.ShipBillNo, obj.ShipBillDate, obj.ExaminDate,
                    obj.Objection, obj.Remark, obj.CCNo, obj.CCDate, obj.CmpId, obj.MakerIp);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ShippingBillShipmentProgressUpdate");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ReceiptCargoUpdateDtlsShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ReceiptCargoUpdateDtlsShipmentProgress([FromBody]ReceiptCargo obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_ROC_DTLS_IUD",
                    obj.Tbl_IndexId, obj.CargoId, obj.ExptNo, obj.NoOfPkgs, obj.RecdDate, obj.RecdWhere,
                    obj.RecdLocal, obj.RecdTime, obj.RecdLocalTime, obj.Guid, obj.CmpId, obj.Type);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ReceiptCargoUpdateDtlsShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ReceiptCargoUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ReceiptCargoUpdateShipmentProgress([FromBody]CommonFive obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_ROC",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ReceiptCargoUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ApprovalReceivedUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ApprovalReceivedUpdateShipmentProgress([FromBody]CommonSeven obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_APPROVAL_RECEIVED",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5, obj.Type6, obj.Type7);//PKID, EXPTNO, EXPTAPPDT, EXPTAPPWM, CONREMARK, cmpid, MakerIP
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ApprovalReceivedUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform MeasurementUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult MeasurementUpdateShipmentProgress([FromBody]CommonFive obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_MEASUREMENT",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5);//PKID, EXPTNO, EXPTCBM, cmpid, MakerIP
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/MeasurementUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform OutOfChargeUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult OutOfChargeUpdateShipmentProgress([FromBody]CommonFive obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_OUT_OF_CHARGE",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5);//PKID, EXPTNO, OUTCHARGEDT, cmpid, MakerIP
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OutOfChargeUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform BlDetailsUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult BlDetailsUpdateShipmentProgress([FromBody]CommonTen obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_BL_DETAILS",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5,
                    obj.Type6, obj.Type7, obj.Type8, obj.Type9, obj.Type10);//PKID, EXPTNO, EXPT_BLNO, EXPT_BLDT, EXPT_HBLNO, EXPT_HBLDT, EXPT_BLTYPE, EXPT_MBLFRT, cmpid, MakerIP
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/BlDetailsUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform CartingAirUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult CartingAirUpdateShipmentProgress([FromBody]CommonFive obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CARTING_AIR",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5);//PKID, EXPTNO, CARTEDDT, cmpid, MakerIP
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/CartingAirUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform PrepaidfrtdtUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PrepaidfrtdtUpdateShipmentProgress([FromBody]CommonFive obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_PREPAID_AAPROVD_DT_SHIPPER",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5);//PKID, EXPTNO, CARTEDDT, cmpid, MakerIP
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrepaidfrtdtUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform PrealertSentOnUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PrealertSentOnUpdateShipmentProgress([FromBody]CommonFive obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_PREALERT_SENT_ON",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5);//PKID, EXPTNO, PREALERTDT, cmpid, MakerIP
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PrealertSentOnUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform DestinationDocumentUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult DestinationDocumentUpdateShipmentProgress([FromBody]CommonFive obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_DESTINATION_DOCUMENT",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5);//PKID, EXPTNO, PREALERTDT, cmpid, MakerIP
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/DestinationDocumentUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform TransferSeaToAirShipmentProgressPopulate records.</summary>
        /// <param name="CityCode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult TransferSeaToAirShipmentProgressPopulate([FromUri]string CityCode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_SEA_TO_AIR_FILL",
                    CityCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/TransferSeaToAirShipmentProgressPopulate");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform TransferSeaToAirUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult TransferSeaToAirUpdateShipmentProgress([FromBody]CommonSix obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_SEA_TO_AIR",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5, obj.Type6);//EXPTNO, CMPCODE, citycode, citycode1, cmpid, MakerIP
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/TransferSeaToAirUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


        /// <summary>Perform ROCProvisionShipmentProgressFill records.</summary>
        /// <param name="CityCode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ROCProvisionShipmentProgressFill([FromUri]string CityCode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_ROC_PRO_FILLDROPDOWN",
                    CityCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ROCProvisionShipmentProgressFill");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ScanDocSentShipmentProgressFill records.</summary>
        /// <param name="ContainerNo">Container No parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ScanDocSentShipmentProgressFill([FromUri]string ContainerNo)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_SDS_FILL",
                    ContainerNo);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ScanDocSentShipmentProgressFill");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


        /// <summary>Perform ScanDocSentUpdateShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ScanDocSentUpdateShipmentProgress([FromBody]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                string[] arrayList = new string[] { };
                arrayList = obj.Type1.Split('|');
                for (int i = 0; i < arrayList.Length; i++)
                {
                    objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_SDS",
                    arrayList[i].Split(',')[0], arrayList[i].Split(',')[1], arrayList[i].Split(',')[2], obj.Type2, obj.Type3);   // CONTAINERID, CONTAINERNO, EXPT_VESSEL, cmpid, MakerIP
                }

                ds = ErrorLog.ConvertStringToDataset("100");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ScanDocSentUpdateShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


        /// <summary>Perform PendingShipment ShipmentProgressFill records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PendingShipment_ShipmentProgressFill([FromBody]CommonThree obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_PEND_SHIP_FILL",
                    obj.Type1, obj.Type2, obj.Type3);                   // VesselName, VoyageNo, CityCode
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PendingShipment_ShipmentProgressFill");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PendingShipment ShipmentProgressView records.</summary>
        /// <param name="VesselRtNo">Vessel Rt No parameter.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PendingShipment_ShipmentProgressView([FromUri]string VesselRtNo, string CityCode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_PEND_SHIP_VIEW",
                    VesselRtNo, CityCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PendingShipment_ShipmentProgressView");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PendingShipment ShipmentProgressView Agent records.</summary>
        /// <param name="VesselRtNo">Vessel Rt No parameter.</param>
        /// <param name="VesselPort">Vessel Port parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PendingShipment_ShipmentProgressView_Agent([FromUri]string VesselRtNo, string VesselPort)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_PEND_SHIP_VIEW_AGENT",
                    VesselRtNo, VesselPort);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PendingShipment_ShipmentProgressView_Agent");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Populate form with existing data for PendingShipment ShipmentProgress ContainerNo records.</summary>
        /// <param name="ExptVessel">Expt Vessel parameter.</param>
        /// <param name="ContainerNo">Container No parameter.</param>
        /// <param name="CmpId">Primary key of the company.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult PendingShipment_ShipmentProgress_ContainerNo_Populate([FromUri]string ExptVessel, string ContainerNo, string CmpId, string CityCode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_PEND_SHIP_CONTAINERNO_POPULATE",
                    ExptVessel, ContainerNo, CmpId, CmpId, CityCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PendingShipment_ShipmentProgress_ContainerNo_Populate");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


        /// <summary>Perform PendingShipment ShipmentProgress ContainerNo records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PendingShipment_ShipmentProgress_ContainerNo([FromBody]ContainerNo obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_PEND_SHIP_CONTAINERNO",
                    obj.ExptVessel, obj.VesselRtNo, obj.ExptAgent, obj.VesselPort, obj.ShipLiner, obj.GuId, obj.CmpId, obj.MakerIp);                   // VesselName, VoyageNo, CityCode
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PendingShipment_ShipmentProgress_ContainerNo");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform PendingShipment ShipmentProgress ExportNo records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PendingShipment_ShipmentProgress_ExportNo([FromBody]ExportNo obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_PEND_SHIP_EXPORTNO",
                    obj.ExptNos, obj.VesselRtNo, obj.ExptAgent, obj.VesselPort, obj.CmpId, obj.MakerIp);                 //EXPORTNO, EXPT_VESSEL_NEW, EXPT_AGENT, VSL_PORT, cmpid, MakerIP
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PendingShipment_ShipmentProgress_ExportNo");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


        /// <summary>Perform ContainerLoadingConf ShipmentProgress records.</summary>
        /// <param name="ExptVessel">Expt Vessel parameter.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ContainerLoadingConf_ShipmentProgress([FromUri]string ExptVessel, string CityCode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CONTAINER_LOADING_CONF_VIEW",
                    ExptVessel, CityCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ContainerLoadingConf_ShipmentProgress");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Populate form with existing data for ContainerLoadingConf ShipmentProgress records.</summary>
        /// <param name="ExptVessel">Expt Vessel parameter.</param>
        /// <param name="ContainerNo">Container No parameter.</param>
        /// <param name="MultiDest">Multi Dest parameter.</param>
        /// <param name="Dest">Dest parameter.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ContainerLoadingConf_ShipmentProgress_Populate([FromUri]string ExptVessel, string ContainerNo, string MultiDest, string Dest, string CityCode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CONTAINER_LOADING_POPULATE",
                    ExptVessel, ContainerNo, MultiDest, Dest, CityCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ContainerLoadingConf_ShipmentProgress_Populate");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update ContainerLoadingConf ShipmentProgress records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ContainerLoadingConf_ShipmentProgress_Update([FromBody]ContainerLoadingConfirmation obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CONTAINER_LOADING_UPDATE",
                    obj.Expt_Vessel, obj.ContainerNo, obj.DestPort, obj.Expt_Agent, obj.LoadDt,
                    obj.Port1loaddt, obj.port2loaddt, obj.TransPortOne, obj.ConVesselOne, obj.EtaOne,
                    obj.TransportOne, obj.ConVsselTwo, obj.Eta2, obj.DirectVsl, obj.OnwardTrans, obj.OnwardTransBy,
                    obj.OnwardTransPort, obj.OnwardTransCost, obj.Eta3, obj.EtdPort1, obj.EtdPort2, obj.Multi_Dest,
                    obj.CityCode, obj.CmpId, obj.MakerIp, obj.ATAPort, (obj.precarby != null) ? obj.precarby : "", (obj.PlcRecpt != null) ? obj.PlcRecpt : "", (obj.EtdPor != null) ? obj.EtdPor : "", (obj.EtdporHr != null) ? obj.EtdporHr : "", (obj.EtdporMin != null) ? obj.EtdporMin : "", (obj.EtaPol != null) ? obj.EtaPol : "", (obj.EtaPolHr != null) ? obj.EtaPolHr : "", (obj.EtaPolMin != null) ? obj.EtaPolMin : "");                 //EXPT_VESSEL, CONTAINERNO, DESTPORT, EXPT_AGENT, LOADDT, PORT1LOADDT, PORT2LOADDT, TRANSPORT1, CONVESSEL1, ETA1, TRANSPORT2, CONVESSEL2, ETA2, DIRECTVSL, ONWARDTRANS, ONWARDTRANSBY, ONWARDTRANSPORT, ONWARDTRANSCOST, ETA3, ETDPORT1, ETDPORT2, MULTI_DEST, HttpContext.Current.Session("CITYCODE"), HttpContext.Current.Session("CMPID"), HttpContext.Current.Session("MakerIP")
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ContainerLoadingConf_ShipmentProgress_Update");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ContainerLoadingConf ShipmentProgress SendMail records.</summary>
        /// <param name="mail_body">mail body parameter.</param>
        /// <param name="ipadd">ipadd parameter.</param>
        /// <param name="Frmmail">Frmmail parameter.</param>
        /// <param name="Tomail">Tomail parameter.</param>
        /// <param name="cc">cc parameter.</param>
        /// <param name="bcc">bcc parameter.</param>
        /// <param name="pwd">pwd parameter.</param>
        /// <param name="subject">subject parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ContainerLoadingConf_ShipmentProgress_SendMail([FromUri]string mail_body, string ipadd, string Frmmail, string Tomail, string cc, string bcc, string pwd, string subject)
        {
            string status = string.Empty;
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            string mailcc = (cc != null) ? cc : "";
            string mailbcc = (cc != null) ? cc : "";
            try
            {
                if (Frmmail != "")
                {
                    mail.From = new System.Net.Mail.MailAddress(Frmmail);
                }

                if (Tomail != "")
                {
                    string[] mailto = Tomail.Split(';');
                    foreach (string mailid in mailto)
                    {
                        mail.To.Add(new System.Net.Mail.MailAddress(mailid));
                    }

                }
                if (mailcc != "")
                {
                    mail.CC.Add(new System.Net.Mail.MailAddress(mailcc));
                }
                mail.Subject = subject;
                mail.Body = mail_body;
                mail.IsBodyHtml = true;
                if (Tomail != "" || mailcc != "")
                {
                    if (mailbcc != "")
                    {
                        //MailBcc = MailBcc + ";pdg.mp@manilal.com";
                        mail.Bcc.Add(new System.Net.Mail.MailAddress(mailbcc));
                    }
                    else
                    {
                        mailbcc = "pdg.mp@manilal.com";
                        mail.Bcc.Add(new System.Net.Mail.MailAddress(mailbcc));

                        //mail.Bcc.Add(new System.Net.Mail.MailAddress(MailBcc));
                    }
                    System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient(ipadd);
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(Frmmail, pwd);
                    SmtpServer.EnableSsl = false;
                    SmtpServer.Send(mail);
                    status = "Mail Send Successfully.";
                }
                else
                {
                    status = "There is no Mail Address to Send Mail.";
                }
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            return Ok(status);
            /*
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = Frmmail;
                mail.To = Tomail;
                mail.Bcc =bcc;
                mail.Subject =subject;
                mail.Body = mail_body;
                mail.BodyFormat = MailFormat.Html;
                SmtpMail.SmtpServer = ipadd;
                SmtpMail.Send(mail);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/ContainerLoadingConf_ShipmentProgress_SendMail");
            }
            finally
            {

            }
            return Ok(1);*/
        }
        //--------------------------------------------------END Shipment Progress-------------------------------------------------------------

        /*
        /// <summary>Perform ConvertHtmlToExcelDownload records.</summary>
        /// <param name="id">Primary key ID of the record.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ConvertHtmlToExcelDownload([FromUri]string id)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\clp_template.html");
                string readFile = reader.ReadToEnd();
                string myString = "";
                myString = readFile;
                myString = myString.Replace("[name]", "Sanoj");


                byte[] byteArray = Encoding.UTF8.GetBytes(myString);
                MemoryStream stream = new MemoryStream(byteArray);
                stream.WriteTo(HttpContext.Current.Response.OutputStream);

                HttpContext.Current.Response.AddHeader("Content-Disposition", "Attachment;filename=clp.xls");
                HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/ConvertHtmlToExcelDownload");
            }
            finally
            {

            }
            return Ok(100);
        }
         */

        /// <summary>Insert or update Export containerCLP records.</summary>
        /// <param name="CN">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_containerCLP_IU([FromBody]ContainerCLP CN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_CONTAINER_CLP_IU", CN.ContainerNo, CN.vsl_rtno, CN.cmpid, CN.ContVerified, CN.CITYCODE, CN.clpString, CN.CMPCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_containerCLP_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform Export containerCLP Pallets records.</summary>
        /// <param name="CN">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_containerCLP_Pallets([FromBody]CLPPallet CN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CONTAINER_PALLETS_FILL", CN.ContainerID, CN.ContainerNo, CN.vsl_rtno, CN.huhpnk);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_containerCLP_Pallets");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Insert or update Export containerCLP Pallets records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_containerCLP_Pallets_IU([FromBody]List<CLPPallet> Pallet)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                foreach (var item in Pallet)
                {

                    objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CONTAINER_PALLETS_IU", item.id, item.ContainerID, item.ContainerNo, item.vsl_rtno, item.CON_CODE, item.NO_OF_PALLETS, item.huhpnk);
                }
                ds = ErrorLog.Success("100", "Saved");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_containerCLP_Pallets");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }


        //private string ConvertToExcel_open(string folder, string xlsFileName, XmlDocument XMLFILE)//(string folder, string xlsFileName, XmlDocument XMLFILE, string FILE_NAME)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    string output;

        //    string strPath = "";
        //    string path = "";
        //    try
        //    {
        //        XslCompiledTransform xsl = new XslCompiledTransform();
        //        xsl.Load(HttpContext.Current.Server.MapPath("..\\..\\") + "\\include\\xml\\" + folder + "\\" + xlsFileName, new XsltSettings(false, true), new XmlUrlResolver());
        //        using (StringWriter sw = new StringWriter(sb))
        //        using (XmlTextWriter xtw = new XmlTextWriter(sw))
        //        {
        //            xsl.Transform(XMLFILE, xtw);
        //            xtw.Flush();
        //        }
        //        output = "<?xml version=\"1.0\" encoding=\"utf-16\"?>" + sb.ToString();

        //        //System.IO.StreamWriter oWrite;
        //        //strPath = HttpContext.Current.Server.MapPath("..\\..\\") + "DATA\\EXPORT\\" + FILE_NAME + ".XLS";
        //        //path = FILE_NAME + ".XLS";
        //        //if (File.Exists(strPath))
        //        //{
        //        //    File.Delete(strPath);
        //        //}
        //        //oWrite = File.CreateText(strPath);
        //        //oWrite.WriteLine(output);
        //        //oWrite.Close();
        //    }
        //    finally
        //    {
        //        sb = null;
        //        //output = null;
        //    }

        //    return output;
        //}


        /// <summary>Perform ConvertHtmlToExcelDownload records.</summary>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage ConvertHtmlToExcelDownload([FromUri]ContainerCLP clp)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();

            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_UPDATE_CONTAINER_CLP_EXL_GENERATION", clp.ContainerNo, clp.vsl_rtno, clp.vsl_port, clp.CMPCODE, clp.CITYCODE);//"MSKU6975339", "201810284", "NH1", "01", "MUM");

            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\clp_template.html");
            string readFile = reader.ReadToEnd();
            string myString = string.Empty;
            myString = readFile;

            if (ds.Tables.Count > 0)
            {
                string containersize = string.Empty;
                string containerstatus = string.Empty;
                containersize = Convert.ToString(ds.Tables[1].Rows[0]["CONTAINERSIZE1"]);
                if (containersize.Trim() == "F") { containersize = "'"; }
                else { containersize = Convert.ToString(ds.Tables[1].Rows[0]["CONTAINERSIZE1"]); }
                containerstatus = Convert.ToString(ds.Tables[1].Rows[0]["CONATINERSTATUS"]);
                string DIRECT_VSL = Convert.ToString(ds.Tables[1].Rows[0]["DIRECT_VSL"]);
                StringBuilder sb = new StringBuilder();
                if (DIRECT_VSL.Trim() == "no")
                {
                    sb.AppendLine("<tr height='17' style='mso-height-source: userset; height: 12.75pt'>");
                    sb.AppendLine("<td height='17' class='xl49' style='height: 12.75pt'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl49' style='border-left: none'> </td>");
                    sb.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl32'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl26'></td>");
                    sb.AppendLine("<td class='xl32'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl26'></td>");
                    sb.AppendLine("<td class='xl31'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl26'></td><td class='xl32'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl49' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl49' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl32'>&nbsp;</td></tr>");
                    sb.AppendLine("<tr height='17' style='mso-height-source: userset; height: 12.75pt'>");
                    sb.AppendLine("<td height='17' class='xl49' style='height: 12.75pt'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl49' style='border-left: none' colspan='3'>");
                    sb.AppendLine(Convert.ToString(ds.Tables[1].Rows[0]["TRANS1"]));
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td><td class='xl26'></td>");
                    sb.AppendLine("<td class='xl32'>&nbsp;</td><td class='xl31' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl26'></td> <td class='xl31'>&nbsp;</td> <td class='xl26'></td>");
                    sb.AppendLine("<td class='xl32'>&nbsp;</td>  <td class='xl49' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl49' style='border-left: none'>&nbsp;</td><td class='xl31' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl32'>&nbsp;</td> </tr>");
                    sb.AppendLine("<tr height='17' style='mso-height-source: userset; height: 12.75pt'>");
                    sb.AppendLine("<td height='17' class='xl49' style='height: 12.75pt'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl49' style='border-left: none' colspan='3'>");
                    sb.AppendLine(Convert.ToString(ds.Tables[1].Rows[0]["TRANS1MSG"]));
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td><td class='xl26'></td>");
                    sb.AppendLine("<td class='xl32'>&nbsp;</td> <td class='xl31' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl26'></td><td class='xl31'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl26'></td> <td class='xl32'>&nbsp;</td> <td class='xl49' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl49' style='border-left: none'>&nbsp;</td><td class='xl31' style='border-left: none'>&nbsp;</td>");
                    sb.AppendLine("<td class='xl32'>&nbsp;</td></tr>");

                    if (ds.Tables[1].Rows[0]["TRANS2"].ToString() != "")
                    {
                        sb.AppendLine("<tr height='17' style='mso-height-source: userset; height: 12.75pt'>");
                        sb.AppendLine("<td height='17' class='xl49' style='height: 12.75pt'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl49' style='border-left: none' colspan='3'>");
                        sb.AppendLine(Convert.ToString(ds.Tables[1].Rows[0]["TRANS2ETA"]));
                        sb.AppendLine("</td>");
                        sb.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td><td class='xl26'></td>");
                        sb.AppendLine("<td class='xl32'>&nbsp;</td> <td class='xl31' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl26'></td> <td class='xl31'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl26'></td> <td class='xl32'>&nbsp;</td><td class='xl49' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl49' style='border-left: none'>&nbsp;</td><td class='xl31' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl32'>&nbsp;</td></tr>");
                        sb.AppendLine("<tr height='17' style='mso-height-source: userset; height: 12.75pt'>");
                        sb.AppendLine("<td height='17' class='xl49' style='height: 12.75pt'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl49' style='border-left: none' colspan='3'>");
                        sb.AppendLine(Convert.ToString(ds.Tables[1].Rows[0]["TRANS2"]));
                        sb.AppendLine("</td>");

                        sb.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td><td class='xl26'></td>");
                        sb.AppendLine("<td class='xl32'>&nbsp;</td> <td class='xl31' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl26'></td> <td class='xl31'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl26'></td> <td class='xl32'>&nbsp;</td><td class='xl49' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl49' style='border-left: none'>&nbsp;</td><td class='xl31' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl32'>&nbsp;</td></tr>");
                        sb.AppendLine("<tr height='17' style='mso-height-source: userset; height: 12.75pt'>");
                        sb.AppendLine("<td height='17' class='xl49' style='height: 12.75pt'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl49' style='border-left: none' colspan='3'>");
                        sb.AppendLine(Convert.ToString(ds.Tables[1].Rows[0]["TRANS2MSG"]));
                        sb.AppendLine("</td>");
                        sb.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td><td class='xl26'></td>");
                        sb.AppendLine("<td class='xl32'>&nbsp;</td> <td class='xl31' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl26'></td> <td class='xl31'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl26'></td> <td class='xl32'>&nbsp;</td><td class='xl49' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl49' style='border-left: none'>&nbsp;</td><td class='xl31' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl32'>&nbsp;</td></tr>");
                        sb.AppendLine("<tr height='17' style='mso-height-source: userset; height: 12.75pt'>");
                        sb.AppendLine("<td height='17' class='xl49' style='height: 12.75pt'>&nbsp;</td><td class='xl49' style='border-left: none' colspan='3'>");
                        sb.AppendLine(Convert.ToString(ds.Tables[1].Rows[0]["TRANSETA"]));
                        sb.AppendLine("</td>");
                        sb.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td><td class='xl26'></td>");
                        sb.AppendLine("<td class='xl32'>&nbsp;</td> <td class='xl31' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl26'></td> <td class='xl31'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl26'></td> <td class='xl32'>&nbsp;</td> <td class='xl49' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl49' style='border-left: none'>&nbsp;</td><td class='xl31' style='border-left: none'>&nbsp;</td>");
                        sb.AppendLine("<td class='xl32'>&nbsp;</td></tr>");
                    }
                }

                StringBuilder sb1 = new StringBuilder();

                string BL_FCRNO = string.Empty,
                        SHIPPER = string.Empty,
                        CONSIGNEE = string.Empty,
                        MARKSNO = string.Empty,
                        PKGS = string.Empty,
                        ITCDESC = string.Empty,
                        CON_GRWT = string.Empty,
                        CON_VOLUME = string.Empty;

                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    BL_FCRNO = string.Empty;
                    SHIPPER = string.Empty;
                    CONSIGNEE = string.Empty;
                    MARKSNO = string.Empty;
                    PKGS = string.Empty;
                    ITCDESC = string.Empty;
                    CON_GRWT = string.Empty;
                    CON_VOLUME = string.Empty;

                    BL_FCRNO = Convert.ToString(ds.Tables[2].Rows[i]["BL_FCRNO"]);
                    SHIPPER = Convert.ToString(ds.Tables[2].Rows[i]["SHIPPER"]);
                    CONSIGNEE = Convert.ToString(ds.Tables[2].Rows[i]["CONSIGNEE"]);
                    MARKSNO = Convert.ToString(ds.Tables[2].Rows[i]["MARKSNO"]);
                    PKGS = Convert.ToString(ds.Tables[2].Rows[i]["PKGS"]);
                    ITCDESC = Convert.ToString(ds.Tables[2].Rows[i]["ITCDESC"]);
                    CON_GRWT = Convert.ToString(ds.Tables[2].Rows[i]["CON_GRWT"]);
                    CON_VOLUME = Convert.ToString(ds.Tables[2].Rows[i]["CON_VOLUME"]);


                    string[] order = MARKSNO.Split(',');
                    if (order.Length > 1)
                    {
                        foreach (string orderno in order)
                        {
                            MARKSNO = orderno;
                            sb1.AppendLine("<tr height=15 style='height:11.25pt'>");
                            sb1.AppendLine("<td height=2 class=xl50 style='height:11.25pt'><div align='left'>");
                            sb1.AppendLine(BL_FCRNO);
                            sb1.AppendLine("</div></td>");
                            sb1.AppendLine("<td class=xl49 style='border-left:none' height='2'>");
                            sb1.AppendLine(SHIPPER);
                            sb1.AppendLine("</td> <td class=xl49 style='border-left:none' colspan='2' height='2'>");
                            sb1.AppendLine(CONSIGNEE);
                            sb1.AppendLine("</td>");

                            sb1.AppendLine("<td class='xl49' style='border-left: none' colspan='3' height='2'>");
                            sb1.AppendLine(MARKSNO);
                            sb1.AppendLine("</td>");

                            sb1.AppendLine("<td class=xl49 colspan='2' height='2' align='right'> <div align='right'>");
                            sb1.AppendLine(PKGS);
                            sb1.AppendLine("</div></td>");
                            sb1.AppendLine("<td class=xl49 style='border-left:none' colspan='3'   height='2' align='right'> <div align='right'>&nbsp;");
                            sb1.AppendLine(ITCDESC);
                            sb1.AppendLine("</div> </td>");

                            sb1.AppendLine("<td class=xl49 style='border-left:none' height='2' align='right'> <div align='right'>");
                            sb1.AppendLine(CON_GRWT);
                            sb1.AppendLine("</div></td>");
                            sb1.AppendLine("<td class=xl49 style='border-left:none' height='2' align='right'> <div align='right'>");
                            sb1.AppendLine(CON_VOLUME);
                            sb1.AppendLine("</div></td>");
                            sb1.AppendLine("<td class='xl26' style='border-left: none' height='2'>&nbsp;</td>  <td class='xl32' height='2'>&nbsp;</td> </tr>");

                            BL_FCRNO = ""; SHIPPER = ""; CONSIGNEE = ""; MARKSNO = ""; PKGS = ""; ITCDESC = ""; CON_GRWT = ""; CON_VOLUME = "";
                        }

                    }
                    else
                    {
                        sb1.AppendLine("<tr height=15 style='height:11.25pt'>");
                        sb1.AppendLine("<td height=2 class=xl50 style='height:11.25pt'><div align='left'>");
                        sb1.AppendLine(BL_FCRNO);
                        sb1.AppendLine("</div></td>");
                        sb1.AppendLine("<td class=xl49 style='border-left:none' height='2'>");
                        sb1.AppendLine(SHIPPER);
                        sb1.AppendLine("</td> <td class=xl49 style='border-left:none' colspan='2' height='2'>");
                        sb1.AppendLine(CONSIGNEE);
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("<td class='xl49' style='border-left: none' colspan='3' height='2'>");
                        sb1.AppendLine(MARKSNO);
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("<td class=xl49 colspan='2' height='2' align='right'> <div align='right'>");
                        sb1.AppendLine(PKGS);
                        sb1.AppendLine("</div></td>");
                        sb1.AppendLine("<td class=xl49 style='border-left:none' colspan='3'   height='2' align='right'> <div align='right'>&nbsp;");
                        sb1.AppendLine(ITCDESC);
                        sb1.AppendLine("</div> </td>");

                        sb1.AppendLine("<td class=xl49 style='border-left:none' height='2' align='right'> <div align='right'>");
                        sb1.AppendLine(CON_GRWT);
                        sb1.AppendLine("</div></td>");
                        sb1.AppendLine("<td class=xl49 style='border-left:none' height='2' align='right'> <div align='right'>");
                        sb1.AppendLine(CON_VOLUME);
                        sb1.AppendLine("</div></td>");
                        sb1.AppendLine("<td class='xl26' style='border-left: none' height='2'>&nbsp;</td>  <td class='xl32' height='2'>&nbsp;</td> </tr>");

                    }

                    sb1.AppendLine("<tr height='17' style='mso-height-source: userset; height: 12.75pt'>");
                    sb1.AppendLine("<td height='17' class'xl49' style='height: 12.75pt'>&nbsp;</td> <td class='xl49' style='border-left: none'>&nbsp;</td>");
                    sb1.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td> ");
                    sb1.AppendLine("<td class='xl32'>&nbsp;</td> <td class='xl31' style='border-left: none'>&nbsp;</td><td class='xl26'></td>");
                    sb1.AppendLine("<td class='xl32'>&nbsp;</td><td class='xl31' style='border-left: none'>&nbsp;</td>");
                    sb1.AppendLine("<td class='xl26'></td>  <td class='xl31'>&nbsp;</td>  <td class='xl26'></td> <td class='xl32'>&nbsp;</td>");
                    sb1.AppendLine("<td class='xl49' style='border-left: none'>&nbsp;</td><td class='xl49' style='border-left: none'>&nbsp;</td>");
                    sb1.AppendLine("<td class='xl31' style='border-left: none'>&nbsp;</td> <td class='xl32'>&nbsp;</td> </tr>");

                }

                myString = myString.Replace("[CMP_NAME]", Convert.ToString(ds.Tables[1].Rows[0]["CMP_NAME"]))
                                    .Replace("[cmpadd]", Convert.ToString(ds.Tables[1].Rows[0]["ADDRS"]))
                                    .Replace("[CMP_TEL]", Convert.ToString(ds.Tables[1].Rows[0]["CMP_TEL"]))
                                    .Replace("[CMP_FAX]", Convert.ToString(ds.Tables[1].Rows[0]["CMP_FAX"]))
                                    .Replace("[CMP_MAIL]", Convert.ToString(ds.Tables[1].Rows[0]["CMP_MAIL"]))
                                    .Replace("[CONTAINER]", Convert.ToString(ds.Tables[1].Rows[0]["CONTAINER"]))
                                    .Replace("[SHPGLINE]", Convert.ToString(ds.Tables[1].Rows[0]["SHPGLINE"]))
                                    .Replace("[CONTAINERSIZE1]", Convert.ToString(ds.Tables[1].Rows[0]["CONTAINERSIZE"]) + " " + containersize + containerstatus)
                                    .Replace("[SEALMSG]", Convert.ToString(ds.Tables[1].Rows[0]["SEALMSG"]))
                                    .Replace("[CITY]", Convert.ToString(ds.Tables[1].Rows[0]["CITY"]))
                                    .Replace("[VSLNAME]", Convert.ToString(ds.Tables[1].Rows[0]["VSLNAME"]))
                                    .Replace("[VOYNO]", Convert.ToString(ds.Tables[1].Rows[0]["VOYNO"]))
                                    .Replace("[POL]", Convert.ToString(ds.Tables[1].Rows[0]["POL"]))
                                    .Replace("[POD]", Convert.ToString(ds.Tables[1].Rows[0]["POD"]))
                                    .Replace("[ETD_MSG]", Convert.ToString(ds.Tables[1].Rows[0]["ETD_MSG"]))
                                    .Replace("[ETA]", Convert.ToString(ds.Tables[1].Rows[0]["ETA"]))
                                    .Replace("[CUSTSEALNO]", Convert.ToString(ds.Tables[1].Rows[0]["CUSTSEALNO"]))
                                    .Replace("[STUFFEDWHERE]", Convert.ToString(ds.Tables[1].Rows[0]["STUFFEDWHERE"]))
                                    .Replace("[DIRECT_VSLSTRING]", Convert.ToString(sb))
                                    .Replace("[FCRString]", Convert.ToString(sb1))
                                    .Replace("[TOT_CONT_PKGS]", Convert.ToString(ds.Tables[3].Rows[0]["TOT_CONT_PKGS"]))
                                    .Replace("[TOT_CONT_GRWT]", Convert.ToString(ds.Tables[3].Rows[0]["TOT_CONT_GRWT"]))
                                    .Replace("[TOT_CONT_CBM]", Convert.ToString(ds.Tables[3].Rows[0]["TOT_CONT_CBM"]));
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(myString);
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "clp.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }

        /// <summary>Perform ServerIp records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ServerIp()
        {
            var MyUrl = HttpContext.Current.Request.UserHostAddress;
            return Ok(MyUrl.ToString());
        }



        //------------Start Carting Sea ----------------
        /// <summary>Search and retrieve Carting SearchList records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Carting_SearchList_populate([FromUri]cartingSea cs)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SEACARTING_SEARCHLIST", cs.vsl_rtno, cs.citycode, cs.cmpcode, cs.port);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Carting_SearchList_populate");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }

        /// <summary>Insert or update Carting Sea records.</summary>
        /// <param name="cs">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Carting_Sea_IU([FromBody]cartingSea cs)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_CARTING_SEA_IU", cs.exptstr, cs.vsl_rtno, cs.vslagent, cs.port, cs.cmpid, cs.citycode, cs.cmpcode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Carting_Sea_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }

        /// <summary>Delete Carting Sea records.</summary>
        /// <param name="cs">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Carting_Sea_DELETE([FromBody]cartingSea cs)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_CARTING_SEA_DELETE", cs.cartid, cs.cmpid, cs.exptno, cs.citycode, cs.cmpcode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Carting_Sea_DELETE");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }

        /// <summary>Populate form with existing data for Carting vsl agent records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Carting_vsl_agent_populate([FromUri]vslSearch vs)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_VSL_AGENT_POPULATE", vs.CITYCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Carting_vsl_agent_populate");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }
        //------------End Carting Sea ----------------

        /// <summary>Perform Carting Sea VslTransfer records.</summary>
        /// <param name="cs">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Carting_Sea_VslTransfer([FromBody]cartingSea cs)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_CARTING_SEA_VSL_TRANSFER", cs.vsl_rtno, cs.vslagent, cs.port, cs.exptno, cs.citycode, cs.cmpcode, cs.cmpid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Carting_Sea_VslTransfer");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }

        /// <summary>Perform listcontainer records.</summary>
        /// <param name="cs">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult listcontainer([FromBody]container cs)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_LIST_CONTAIER", cs.ContainerID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Carting_Sea_VslTransfer");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /******************Booking Start Here***********************/
        /// <summary>Perform OrderBookingDropdownFill records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="edigroup">edigroup parameter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="optional">optional parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult OrderBookingDropdownFill([FromUri]string citycode, string edigroup, string cmpcode, string optional)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                if (optional == "new")
                {
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                            CommandType.StoredProcedure,
                            "USP_EXP_MST_EXPORT_ORDERNO_BOOKING_FILLDROPDOWN",
                            citycode, edigroup, cmpcode);
                }
                else
                {
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                        CommandType.StoredProcedure,
                        "USP_EXP_MST_EXPORT_ORDERNO_BOOKING_FILLDROPDOWN_NEW",
                        citycode, edigroup, "0", cmpcode);
                }
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderBookingDropdownFill");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform OrderBookingSearch records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult OrderBookingSearch([FromBody]OrderBookingSearch obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_BOOKING_INCOMING_SERACH_LIST",
                    obj.EdiGroup, obj.Mode, obj.OrderNo, obj.UserType, obj.ExpCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderBookingSearch");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


        /// <summary>Perform OrderBookingSearchList records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult OrderBookingSearchList([FromBody]OrderBookingSearch obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_ORDERNO_BOOKING_SEARCH_LIST",
                    obj.SearchType, obj.OrderNo, obj.ReferenceNo, obj.CmpCode, obj.CityCode, obj.EdiGroup, obj.Mode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderBookingSearchList");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform OrderBookingAdd records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult OrderBookingAdd([FromBody]OrderBookingAdd obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_ORDERNO_BOOKING_STEP1_IUD",
                  obj.ORDMODE, obj.TEMPSTRING, obj.BOOKINGDT, obj.CARGOEDT, obj.DOCSEDT, obj.ETDE, obj.ETAE, obj.APPROVALDT,
                  obj.CRAGORECVDDT, obj.CONCODE, obj.EXPCODE, obj.ISTRANS, obj.ETDTRANS, obj.ETATRANS, obj.ACTLAPPROVAL,
                  obj.ACTLAPPROVALBY, obj.SUP_CONTACT_DT, obj.SHIP_CONFIRM, obj.NEW_SHIP_DT, obj.FK_GRPID, obj.CITY, obj.MakerId, Convert.ToString(CommonFunction.GetIpAddress()));
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderBookingAdd");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform OrderBookingInsertUpdate records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult OrderBookingInsertUpdate([FromBody]OrderBooking obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_ORDERNO_BOOKING_IUD",
                   obj.Type, obj.OrderId, obj.Concode, obj.Mode, obj.OrderNo, obj.StyleNo, obj.ItemDescription, obj.Pieces,
                   obj.TypeOfPcs, obj.Packages, obj.GrossWeight, obj.Volume, obj.NetWeight, obj.BookingDate, obj.CargoExpectedDate,
                   obj.DocsExpectedEDate, obj.EtdE, obj.EtaE, obj.ApprovalDate, obj.CargoReceivedDate, obj.Exporter, obj.Transhipment,
                   obj.ETDTranshipmentDate, obj.ETATranshipmentDate, obj.Citycode, obj.CmpCode, obj.MakerId, obj.Rebooking, obj.ActualApprovalDate,
                   obj.ActualApprovalBy, obj.SupContactDate, obj.ShipmentConfirmation, obj.NewShipmentDate, obj.EdiGroup);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderBookingInsertUpdate");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /******************Booking End Here***********************/

        /******************PSS Start Here***********************/
        /// <summary>Perform PssManage records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PssManage([FromBody]CommonFive obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {   //obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5 = SEARCH, EXPTNO, PSS, CMPID, MAKERIP
                if (obj.Type1 == "SEARCH")
                {
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                            CommandType.StoredProcedure,
                            "USP_EXP_CONSIGNMENT_PSS_SEARCH",
                            obj.Type2);
                }
                else
                {
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                        CommandType.StoredProcedure,
                        "USP_EXP_CONSIGNMENT_PSS_UPDATE",
                        obj.Type2, obj.Type3, obj.Type4, obj.Type5);
                }
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/PssManage");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /******************PSS End Here***********************/

        /******************Export Consignment JOB NO Start Here***********************/
        /// <summary>Retrieve GetExportConsignmentJobClientData records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetExportConsignmentJobClientData([FromUri]string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                        CommandType.StoredProcedure,
                        "USP_EXP_MST_EXPORT_MISC_JOB_FILL_CLIENT",
                        citycode);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/GetExportConsignmentJobClientData");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ExportConsignmentJobSearch records.</summary>
        /// <param name="jobno">Job number.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ExportConsignmentJobSearch([FromUri]string jobno, string cmpcode, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                        CommandType.StoredProcedure,
                        "USP_EXP_MST_EXPORT_MISC_JOB_POPULATE",
                        jobno, cmpcode, citycode);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportConsignmentJobSearch");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ExportConsignmentJobIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportConsignmentJobIU([FromBody]ExportConsignmentJob obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_MISC_JOB_IU",
                    obj.Id, obj.JobNo, obj.ClientName, obj.NoOfPackages, obj.Narration, obj.JobType,
                    obj.MakerId, obj.MakerIp, obj.CmpCode, obj.CityCode, obj.CityCode1, (obj.NoofPieces != null) ? obj.NoofPieces : "0", (obj.Orderno != null) ? obj.Orderno : "", (obj.DocrecptDt != null) ? obj.DocrecptDt : "", (obj.SupInvno != null) ? obj.SupInvno : "", (obj.SupInvDt != null) ? obj.SupInvDt : "", (obj.whs != null) ? obj.whs : "0", (obj.vendorskucode != null) ? obj.vendorskucode : "", (obj.boxnumber != null) ? obj.boxnumber : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportConsignmentJobIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /******************Export Consignment JOB NO End Here***********************/

        /******************Export Consignment BRANCH JOB TRANSFER Start Here***********************/
        /// <summary>Retrieve GetExportConsignmentBranchFillDropdown records.</summary>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetExportConsignmentBranchFillDropdown([FromUri]string citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                        CommandType.StoredProcedure,
                        "USP_CMP_Fill_BRANCH",
                        citycode1);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/GetExportConsignmentBranchFillDropdown");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform ExportConsignmentBranchJobTransferI records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ExportConsignmentBranchJobTransferI([FromBody]BranchJobTransfer obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string[] arrCityCode = obj.Branch.Split('|');
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_TRANSFER_JOB_BRANCH",
                    obj.OldJobNo, obj.UserRemarks, obj.CmpCode, arrCityCode[0], obj.MakerId, obj.MakerIp, obj.CityCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/ExportConsignmentBranchJobTransferI");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /******************Export Consignment BRANCH JOB TRANSFER End Here***********************/

        /******************Order Size Detail Start here****************************************/
        /// <summary>Perform OrderSizeDetailsList records.</summary>
        /// <param name="orderno">orderno parameter.</param>
        /// <param name="styleno">styleno parameter.</param>
        /// <param name="exptno">Export job number.</param>
        /// <param name="concode">concode parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult OrderSizeDetailsList([FromUri]string orderno, string styleno, string exptno, string concode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_ORDER_SIZE_DET_GET",
                    orderno, styleno, exptno, concode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderSizeDetailsList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform OrderSizeDetailsSubmit records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult OrderSizeDetailsSubmit([FromBody]OrderSizeDeatils obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_ORDER_SIZE_DET_IU",
                    obj.ExptNo, obj.Concode, obj.OrderNo, obj.StyleNo, obj.TotalPackage, obj.Str, obj.MakerId, obj.MakerIp);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/OrderSizeDetailsSubmit");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /******************Order Size Detail end here****************************************/

        /******************Dockett Print start here****************************************/
        /// <summary>Perform DocketPrint records.</summary>
        /// <param name="exptno">Export job number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult DocketPrint([FromUri]string exptno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_DOCKET_PRINT",
                    exptno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/DocketPrint");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /******************Dockett Print end here****************************************/

        /******************Annexure start here****************************************/
        /// <summary>Perform AnnexureSearchList records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="exptno">Export job number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult AnnexureSearchList([FromUri]string citycode, string exptno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_DOCKET_PRINT_ANNEXURE_LIST",
                    exptno, citycode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureSearchList");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AnnexureEditPopulateData records.</summary>
        /// <param name="exptno">Export job number.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult AnnexureEditPopulateData([FromUri]string exptno, string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_ANNEXURE_EDIT_POPULATE_DATA",
                    exptno, citycode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureEditPopulateData");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AnnexureEditIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult AnnexureEditIU([FromBody]Annexure obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_ANNEXURE_EDIT_IU",
                    obj.ExptNo, obj.Parameter, obj.Sample, obj.CargoStatus, obj.NoOfPcs, obj.NoOfContainer, obj.Unit, obj.RotationDate,
                    obj.PeriodPaymentContract, obj.ExporterDesignation, obj.DDate, obj.CHADesignation, obj.IdCardNo, obj.EXPTYPEA,
                    obj.EXPTYPEB, obj.MarksAndNumber, obj.Commission, obj.Discount, obj.Misc, obj.Deduction, obj.Freight, obj.Insurance,
                    obj.Stuffing, obj.Shipper, obj.Consignee, obj.Agency, obj.ConsigneeCountry, obj.Pod, obj.FinalDestination,
                    obj.NameAddressOfBuyer, obj.StrContainer, obj.StrExchangeRate, obj.CmpCode, obj.CityCode, obj.MakerId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureEditIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AnnexureItemDetailPopulateData records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult AnnexureItemDetailPopulateData([FromBody]AnnexureItemDetail obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_DOCKET_PRINT_ANNEXURE_ITEMDESC_VIEW_NEW",
                    obj.CmpCode, obj.CityCode, obj.ExptNo, obj.GuId, obj.Status);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureItemDetailPopulateData");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AnnexureItemDetailIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult AnnexureItemDetailIU([FromBody]AnnexureItemDetail obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_DOCKET_PRINT_ANNEXURE_ITEMDESC_IU_NEW",
                    obj.ExptNo, obj.StrData, obj.CmpCode, obj.CmpId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureItemDetailIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform AnnexureDrawbackPopulateData records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult AnnexureDrawbackPopulateData([FromBody]AnnexureDrawback obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_DOCKET_PRINT_ANNEXURE_DBK_VIEW_NEW",
                    obj.CmpCode, obj.CityCode, obj.ExptNo);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureDrawbackPopulateData");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AnnexureDrawbackIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult AnnexureDrawbackIU([FromBody]AnnexureDrawback obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_DOCKET_PRINT_ANNEXURE_DBK_IU_NEW",
                    obj.ExptNo, obj.StrData, obj.CmpCode, obj.CmpId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureDrawbackIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AnnexureDeecEpcgPopulateData records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult AnnexureDeecEpcgPopulateData([FromBody]AnnexureDeecEpcg obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_DOCKET_PRINT_ANNEXURE_DEECLIC_VIEW_NEW",
                    obj.CmpCode, obj.CityCode, obj.ExptNo);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureDeecEpcgPopulateData");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AnnexureDeecEpcgIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult AnnexureDeecEpcgIU([FromBody]AnnexureDeecEpcg obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_DOCKET_PRINT_ANNEXURE_DEECLIC_IU_NEW",
                    obj.ExptNo, obj.StrData, obj.CmpCode, obj.CmpId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureDeecEpcgIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AnnexureDfrcPopulateData records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult AnnexureDfrcPopulateData([FromBody]AnnexureDeecEpcg obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_DOCKET_PRINT_ANNEXURE_DFRC_VIEW_NEW",
                    obj.CmpCode, obj.CityCode, obj.ExptNo);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureDfrcPopulateData");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AnnexureDfrcIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult AnnexureDfrcIU([FromBody]AnnexureDeecEpcg obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_DOCKET_PRINT_ANNEXURE_DFRC_IU_NEW",
                    obj.ExptNo, obj.StrData, obj.CmpCode, obj.CmpId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexureDfrcIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform AnnexurePrintPage records.</summary>
        /// <param name="exptno">Export job number.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="type">type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult AnnexurePrintPage([FromUri]string exptno, string citycode, string type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_DOCKET_PRINT_PREVIEW_ANNEXURE",
                    exptno, citycode, type);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/AnnexurePrintPage");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /******************Annexure end here****************************************/


        /// <summary>Perform printdoc mbl listview records.</summary>
        /// <param name="bl">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult exp_printdoc_mbl_listview([FromBody]mbl bl)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXPT_PRINTDOC_MBL_PAGELOAD", bl.JOBNO, bl.CITY_CODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/exp_printdoc_mbl_listview");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }
        /// <summary>Insert or update printdoc mbl records.</summary>
        /// <param name="bl">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult exp_printdoc_mbl_iu([FromBody]mbl bl)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXPT_PRINTDOC_MBL_IU", bl.JOBNO, bl.MBLNO,
                    bl.MBLDT, (bl.FRTYPE != null) ? bl.FRTYPE : "", (bl.FRTCURR != null) ? bl.FRTCURR : "", (bl.FRTAMT != null) ? bl.FRTAMT : "", bl.MAKERID,
                     (bl.BLTYPE != null) ? bl.BLTYPE : "", bl.JOBSTR, bl.CITY_CODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/exp_printdoc_mbl_iu");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }
        /// <summary>Perform printdoc mb printload records.</summary>
        /// <param name="bl">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult exp_printdoc_mb_printload([FromBody]mbl bl)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXPT_PRINTDOC_MBL_PRINT_LOAD", bl.JOBNO, bl.MBLNO);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/exp_printdoc_mb_printload");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }
        /// <summary>Insert or update printdoc mb print records.</summary>
        /// <param name="blp">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult exp_printdoc_mb_print_update([FromBody]mblprint blp)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try  // (blp. != null) ? blp. : ""
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXPT_PRINTDOC_MBL_PRINT_UPDATE", blp.jobno, blp.shipper, blp.consignee,
                    (blp.notify != null) ? blp.notify : "", (blp.expno != null) ? blp.expno : "", blp.blno, (blp.Carriage != null) ? blp.Carriage : "",
                    (blp.RecptPlce != null) ? blp.RecptPlce : "", (blp.Vessel != null) ? blp.Vessel : "", blp.POL, blp.POD, (blp.PODEL != null) ? blp.PODEL : "",
                    (blp.FrtPaidAt != null) ? blp.FrtPaidAt : "", (blp.NumofBL != null) ? blp.NumofBL : "", (blp.MarksAndNos != null) ? blp.MarksAndNos : "",
                    (blp.NoofPkgs != null) ? blp.NoofPkgs : "", (blp.ItcDesc != null) ? blp.ItcDesc : "", (blp.GrWt != null) ? blp.GrWt : "",
                    (blp.Vol != null) ? blp.Vol : "", (blp.PlaceDate != null) ? blp.PlaceDate : "", (blp.Misc != null) ? blp.Misc : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/exp_printdoc_mb_print_update");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }

        /// <summary>Perform Generate EpCopy records.</summary>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_EpCopy([FromUri]Epcopy ep)
        {

            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();

            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_RPT_EP_COPY_COVERSHEET", ep.SECHMODE, ep.VALUE, ep.EXPT_MODE);
            StreamReader reader;

            if (ep.RPTFRMT == "tbl")
            {
                //if (ep.EXPT_MODE == "Air")
                //{
                reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\Ep_Copy_Air_tbl_template.html");
                //}
                //else
                //{
                //    reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\EPCopy_Sea_template.html");
                //}

            }
            else
            {

                reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\EPCopy_Statemnt_template.html");
            }




            string readFile = reader.ReadToEnd();
            string myString = string.Empty;
            myString = readFile;
            StringBuilder sb = new StringBuilder();

            string HEADER = "", filename = "", Subject = "", tblhead = "";
            if (ds.Tables.Count > 0)
            {

                Subject = ep.Subject;
                filename = Convert.ToString(ds.Tables[0].Rows[0]["CITY_NAME"]).Trim() + Convert.ToString(ds.Tables[0].Rows[0]["SHIPBILLNO"]).Trim();



                HEADER = Convert.ToString(ds.Tables[0].Rows[0]["CMP_BOLDNAME"]) + ' ' + Convert.ToString(ds.Tables[0].Rows[0]["CMP_FULLNAME"]);

                if (ep.EXPT_MODE == "Air")
                {
                    tblhead = " <td style=' border: 1px solid black; top:384px;left:2px;width:109px;height:32px;'> <span class='fci9fl51y3kf40-0'>Actual&nbsp;Flight&nbsp;No</span><span class='fci9fl51y3kf40-0'>.</span></td>";
                    tblhead = tblhead + "<td style=' border: 1px solid black; top:384px;left:2px;width:126px;height:32px;'> <span class='fci9fl51y3kf40-0'>Actual&nbsp;Flight&nbsp;Date</span></td>";
                }
                else
                {
                    tblhead = " <td style=' border: 1px solid black; top:384px;left:2px;width:109px;height:32px;'> <span class='fci9fl51y3kf40-0'>Mate&nbsp;Receipt &nbsp;No</span><span class='fci9fl51y3kf40-0'>.</span></td>";
                    tblhead = tblhead + "<td style=' border: 1px solid black; top:384px;left:2px;width:126px;height:32px;'> <span class='fci9fl51y3kf40-0'>Mate&nbsp;Receipt &nbsp;Date</span></td>";
                }
                int j = 1;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    if (ep.RPTFRMT == "tbl")
                    {
                        sb.AppendLine("<tr> <td align='left' class='adi9fl51y3kf40-0' style=' border: 1px solid black;  top:384px;left:2px;width:30px;height:32px;'>  ");
                        sb.AppendLine(j.ToString());
                        sb.AppendLine("</td>");

                        sb.AppendLine(" <td style=' border: 1px solid black; top:384px;left:2px;width:128px;height:32px;'>");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["OUR REF.NO."]));
                        sb.AppendLine(" </td>");

                        sb.AppendLine("<td style=' border: 1px solid black; top:384px;left:2px;width:80px;height:32px;'> ");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["expt_noofpkgs"]));
                        sb.AppendLine("</td> ");

                        sb.AppendLine(" <td style=' border: 1px solid black; top:384px;left:2px;width:134px;height:32px;'>");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["SHIPBILLNO"]));
                        sb.AppendLine(" </td>");

                        sb.AppendLine("<td style=' border: 1px solid black; top:384px;left:2px;width:104px;height:32px;'> ");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["EXPT_SHIPBILLDT"]));
                        sb.AppendLine(" </td>");

                        if (ep.EXPT_MODE == "Air")
                        {
                            sb.AppendLine(" <td style=' border: 1px solid black; top:384px;left:2px;width:109px;height:32px;'>");
                            sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["FLIGHTNO"]));
                            sb.AppendLine("</td> ");

                            sb.AppendLine("<td style=' border: 1px solid black; top:384px;left:2px;width:126px;height:32px;'> ");
                            sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["FLIGHTDT"]));
                            sb.AppendLine("</td> </tr>");

                            sb.AppendLine(" <tr><td colspan='7' style=' border: 1px solid black; top:384px;left:2px;width:128px;height:32px;'>");
                            sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["AIRLINEDTLS"]));
                            if (Convert.ToString(ds.Tables[0].Rows[i]["DEPB_COPYOFSBILLNO"]) != "")
                            {
                                sb.AppendLine("DEPB Copy of S/Bill No. :- " + Convert.ToString(ds.Tables[0].Rows[i]["DEPB_COPYOFSBILLNO"]));
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[i]["REMARK1"]) != "")
                            {
                                sb.AppendLine("ARE :- " + Convert.ToString(ds.Tables[0].Rows[i]["REMARK1"]));
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[i]["REMARK2"]) != "")
                            {
                                sb.AppendLine("ARE :- " + Convert.ToString(ds.Tables[0].Rows[i]["REMARK2"]));
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[i]["REMARK3"]) != "")
                            {
                                sb.AppendLine("ARE :- " + Convert.ToString(ds.Tables[0].Rows[i]["REMARK3"]));
                            }

                            sb.AppendLine(" </td></tr>");
                        }
                        else
                        {
                            sb.AppendLine("<td style=' border: 1px solid black; top:384px;left:2px;width:109px;height:32px;'> ");
                            sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["MIR NO."]));
                            sb.AppendLine("</td> ");

                            sb.AppendLine("<td style=' border: 1px solid black; top:384px;left:2px;width:126px;height:32px;'> ");
                            sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["MIR NO."]));
                            sb.AppendLine(" </td></tr>");

                            sb.AppendLine(" <tr><td colspan='7' style=' border: 1px solid black; top:384px;left:2px;width:128px;height:32px;'>");

                            if (Convert.ToString(ds.Tables[0].Rows[i]["DEPB_COPYOFSBILLNO"]) != "")
                            {
                                sb.AppendLine("DEPB Copy of S/Bill No. :- " + Convert.ToString(ds.Tables[0].Rows[i]["DEPB_COPYOFSBILLNO"]));
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[i]["REMARK1"]) != "")
                            {
                                sb.AppendLine("ARE :- " + Convert.ToString(ds.Tables[0].Rows[i]["REMARK1"]));
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[i]["REMARK2"]) != "")
                            {
                                sb.AppendLine("ARE :- " + Convert.ToString(ds.Tables[0].Rows[i]["REMARK2"]));
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[i]["REMARK3"]) != "")
                            {
                                sb.AppendLine("ARE :- " + Convert.ToString(ds.Tables[0].Rows[i]["REMARK3"]));
                            }

                            sb.AppendLine(" </td></tr>");

                        }


                    }
                    else
                    {
                        sb.AppendLine("<div title='Text Object' class='adi9g81d9zh40-0' style='top:391px;left:8px;width:16px;height:15px;'>");
                        sb.AppendLine("<table width='16px' border='0' cellpadding='0' cellspacing='0'>");
                        sb.AppendLine(" <td align='left'>");
                        sb.AppendLine("<span class='fci9g81d9zh40-3'> ");
                        sb.AppendLine(j.ToString());
                        sb.AppendLine("</span></td></table></div>");

                        sb.AppendLine("<div title='Text Object' class='adi9g81d9zh40-0' style='top:391px;left:24px;width:648px;height:16px;'>");
                        sb.AppendLine("<table width='648px' border='0' cellpadding='0' cellspacing='0'>");
                        sb.AppendLine("<td align='left'>");

                        sb.AppendLine("<span class='fci9g81d9zh40-0'>Our&nbsp;Ref</span><span class='fci9g81d9zh40-0'>.&nbsp;</span>");
                        sb.AppendLine("<span class='fci9g81d9zh40-0'>No</span><span class='fci9g81d9zh40-0'>.&nbsp;</span><span class='fci9g81d9zh40-0'>");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["OUR REF.NO."]));
                        sb.AppendLine(" </span><span class='fci9g81d9zh40-0'>-</span><span class='fci9g81d9zh40-0'>");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["expt_noofpkgs"]));
                        sb.AppendLine("</span><span class='fci9g81d9zh40-0'>,&nbsp;</span><span class='fci9g81d9zh40-0'>");
                        sb.AppendLine("S</span><span class='fci9g81d9zh40-0'>/</span><span class='fci9g81d9zh40-0'>b&nbsp;No</span><span class='fci9g81d9zh40-0'>:&nbsp;</span><span class='fci9g81d9zh40-0'>");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["SHIPBILLNO"]));

                        sb.AppendLine("<span class='fci9g81d9zh40-0'>");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["EXPT_SHIPBILLDT"]));
                        sb.AppendLine("</span><span class='fci9g81d9zh40-0'>MIR</span><span class='fci9g81d9zh40-0'>:-&nbsp;-</span>");
                        sb.AppendLine("<span class='fci9g81d9zh40-0'nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>");

                        sb.AppendLine("</span></div><div title=' (String)' class='adi9fl51y3kf40-0' style='top:440px;left:32px;width:712px;height:15px;'><span class='fci9fl51y3kf40-3'>&nbsp;");


                        if (Convert.ToString(ds.Tables[0].Rows[i]["DEPB_COPYOFSBILLNO"]) != "")
                        {
                            sb.AppendLine("DEPB Copy of S/Bill No. :- " + Convert.ToString(ds.Tables[0].Rows[i]["DEPB_COPYOFSBILLNO"]));
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["REMARK1"]) != "")
                        {
                            sb.AppendLine("ARE :- " + Convert.ToString(ds.Tables[0].Rows[i]["REMARK1"]));
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["REMARK2"]) != "")
                        {
                            sb.AppendLine("ARE :- " + Convert.ToString(ds.Tables[0].Rows[i]["REMARK2"]));
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[i]["REMARK3"]) != "")
                        {
                            sb.AppendLine("ARE :- " + Convert.ToString(ds.Tables[0].Rows[i]["REMARK3"]));
                        }
                    }

                    j = j + 1;
                }
                // FOOTER = Convert.ToString(ds.Tables[0].Rows[0]["CMP_NAME"]);

            }

            myString = myString.Replace("[EXPORTERNAME]", Convert.ToString(ds.Tables[0].Rows[0]["EXPORTERNAME"]))
                                   .Replace("[Subject]", Convert.ToString(ep.Subject))
                                   .Replace("[CMP_ADD1]", Convert.ToString(ds.Tables[0].Rows[0]["CMP_ADD1"]))
                                   .Replace("[CMP_ADD2]", Convert.ToString(ds.Tables[0].Rows[0]["CMP_ADD2"]))
                                   .Replace("[CMP_ADD3]", Convert.ToString(ds.Tables[0].Rows[0]["CMP_ADD3"]))
                                   .Replace("[CMP_TELNO]", Convert.ToString(ds.Tables[0].Rows[0]["CMP_TELNO"]))
                                   .Replace("[CMP_FAXNO]", Convert.ToString(ds.Tables[0].Rows[0]["CMP_FAXNO"]))
                                   .Replace("[CMP_EMAIL]", Convert.ToString(ds.Tables[0].Rows[0]["CMP_EMAIL"]))
                                   .Replace("[CITY_NAME]", Convert.ToString(ds.Tables[0].Rows[0]["CITY_NAME"]))
                                   .Replace("[date]", Convert.ToString(ds.Tables[0].Rows[0]["PRINTDT"]))
                                   .Replace("[EXP_CITY]", Convert.ToString(ds.Tables[0].Rows[0]["EXP_CITY"]))


                                  .Replace("[HEADER]", Convert.ToString(HEADER))
                                  .Replace("[EXPTNO]", Convert.ToString(sb))
                                  .Replace("[FOOTER]", Convert.ToString(ds.Tables[0].Rows[0]["CMP_NAME"]))
                                  .Replace("[null]", Convert.ToString(""))
                                  .Replace("[Subject1]", Convert.ToString("Shipped on :"))
                                   .Replace("[tblhead]", Convert.ToString(tblhead));


            byte[] byteArray = Encoding.UTF8.GetBytes(myString);
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = filename + ".html";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;

        }


        /// <summary>Perform EpCopySearch records.</summary>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="Searchtype">Search type/column identifier.</param>
        /// <param name="SearchValue">Search Value parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult exp_EpCopySearch([FromUri]string CityCode, string Searchtype, string SearchValue)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_EP_COPY_LIST", Searchtype, SearchValue, CityCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/exp_EpCopySearch");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }

        /// <summary>Perform Epcopy recvddt Udate records.</summary>
        /// <param name="ep">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult exp_Epcopy_recvddt_Udate([FromBody]EpcopyRecvdDt ep)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_EP_COPY_UPDATE", ep.strExptNo, ep.epcopydt, ep.epcopysentdt, ep.EP_CopyOfSBillNo, ep.EP_CopyOfSBillDt, ep.DEPB_CopyOfSBillNo, ep.DEPB_CopyOfSBillDt, ep.ARE1_No, ep.ARE1_Dt, ep.ARE1_NoCopyReceived, ep.ARE2_No, ep.ARE2_Dt, ep.ARE2_NoCopyReceived, ep.ARE3_No, ep.ARE3_Dt, ep.ARE3_NoCopyReceived, ep.OriginalMateReceiptNo, ep.OriginalMateReceiptDt, ep.citycode, ep.cmp_code, ep.MakerID, ep.MakerIP, ep.CourierNo, ep.CourierDt, ep.CourierRemark);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/exp_Epcopy_recvddt_Udate");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);

        }


        //--------------- Report---------------------1. Ep-Copy Excel

        /// <summary>Perform Rpt EpCopy records.</summary>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="Type">Type parameter.</param>
        /// <param name="Exporter">Exporter parameter.</param>
        /// <param name="DateType">Date Type parameter.</param>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="City">City parameter.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="Username">Username parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage exp_Rpt_EpCopy([FromUri]string Mode, string Type, string Exporter, string DateType, string FromDate, string ToDate, string City, string cmp_code, string CityCode, string Username)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            // String str = "";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXPT_RPT_EP_COPY", Mode, Type, Exporter, DateType, FromDate, ToDate, City, cmp_code);
            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\Exp_rpt_EpCopy_exptExl_template.html");
            string readFile = reader.ReadToEnd();
            string myString = string.Empty;
            myString = readFile;
            // string Header1 = "", Header2 = "", Header3 = "", Header4 = "", Header5 = "", Header6 = "", Header7 = "",Header="";
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        sb.AppendLine("<tr height=21 style='mso-height-source:userset;height:15.75pt'>");
                        sb.AppendLine("<td colspan=11 height=25 class=xl81 width=1690 style='height:18.75pt;  width:1269pt'> ");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["HEADER"]));
                        sb.AppendLine("<span style='mso-spacerun:yes'>&nbsp;</span>");
                        sb.AppendLine("</td> </tr>");
                    }
                    else if (i == 1)
                    {
                        sb.AppendLine("<tr height=21 style='height:15.0pt'>");
                        sb.AppendLine("<td colspan=11 height=20 class=xl78 width=256 style='height:15.0pt;width:192pt'> ");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["HEADER"]));
                        sb.AppendLine("<span style='mso-spacerun:yes'>&nbsp;</span>");
                        sb.AppendLine("</td> </tr>");
                    }
                    else
                    {
                        sb.AppendLine("<tr height=20 style='height:15.0pt'>");
                        sb.AppendLine("<td colspan=11 height=20 class=xl78 width=256 style='height:15.0pt;width:192pt'> ");
                        sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["HEADER"]));
                        sb.AppendLine("<span style='mso-spacerun:yes'>&nbsp;</span>");
                        sb.AppendLine("</td> </tr>");
                    }

                }
            }
            for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
            {
                sb1.AppendLine("<tr height=20 style='height:15.0pt '>");
                sb1.AppendLine("<td height=20 class=xl75 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["MP. Ref"]));
                sb1.AppendLine("</td>");
                sb1.AppendLine("<td height=20 class=xl75 width=157 style='border-top:none;border-left:none;width:118pt''> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Document Received on "]));
                sb1.AppendLine("</td>");
                sb1.AppendLine("<td height=20 class=xl75 width=145 style='height:15.0pt;border-top:none;  width:192pt'> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["EP Copy Received on "]));
                sb1.AppendLine("</td>");
                sb1.AppendLine("<td height=20 class=xl75 width=114 style='height:15.0pt;border-top:none;  width:192pt'> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["EP Copy Sent on "]));
                sb1.AppendLine("</td>");
                sb1.AppendLine("<td height=20 class=xl75 width=256 style='height:15.0pt;border-top:none;  width:192pt'> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Shipper "]));
                sb1.AppendLine("</td>");
                sb1.AppendLine("<td height=20 class=xl75 width=256 style='height:15.0pt;border-top:none;  width:192pt'> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Document Through "]));
                sb1.AppendLine("</td>");
                sb1.AppendLine("<td height=20 class=xl75 width=115 style='height:15.0pt;border-top:none;  width:192pt'> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Shipping Bill No."]));
                sb1.AppendLine("</td>");
                sb1.AppendLine("<td height=20 class=xl75 width=111 style='height:15.0pt;border-top:none;  width:192pt'> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Shipping Bill Dt."]));
                sb1.AppendLine("</td>");
                sb1.AppendLine("<td height=20 class=xl75 width=78 style='height:15.0pt;border-top:none;  width:192pt'> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Consignee"]));
                sb1.AppendLine("</td>");
                sb1.AppendLine("<td height=20 class=xl75 width=78 style='height:15.0pt;border-top:none;  width:192pt'> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["No. of Pkgs "]));
                sb1.AppendLine("</td>");

                sb1.AppendLine("<td height=20 class=xl75 width=78 style='height:15.0pt;border-top:none;  width:192pt'> ");
                sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Type of Pkgs "]));
                sb1.AppendLine("</td>  </tr>");

            }

            myString = myString.Replace("[Header]", Convert.ToString(sb))
                        .Replace("[ROWsColl]", Convert.ToString(sb1));

            byte[] byteArray = Encoding.UTF8.GetBytes(myString);
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Ep_copy_" + Username.Trim() + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }


        /// <summary>Retrieve Fill City records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_City()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_NormalFillCity");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Fill_City");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Retrieve Fill Exporter records.</summary>
        /// <param name="Cmpid">Primary key of the company.</param>
        /// <param name="Citycode">City/branch code.</param>
        /// <param name="Citycode1">Secondary city/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_Exporter([FromUri]string Cmpid, string Citycode, string Citycode1)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_CMP_FillExpoter", Cmpid, Citycode, Citycode1);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Fill_Exporter");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        //--------------------------2. DSR Report
        /// <summary>Load page reference data for Fill dsr records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_dsr_PAGELOAD()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_RPT_DSR_FILL_DROPDOWN");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Fill_dsr_PAGELOAD");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        //
        /// <summary>Perform Rpt DSR records.</summary>
        /// <param name="concode">concode parameter.</param>
        /// <param name="expcode">expcode parameter.</param>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="origin">origin parameter.</param>
        /// <param name="cmp_id">cmp id parameter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage exp_Rpt_DSR([FromUri]string concode, string expcode, string FromDate, string origin, string cmp_id, string cmpcode, string Mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            // String str = "";


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_RPT_DSR", concode, expcode, FromDate, origin, cmp_id, cmpcode, Mode);
            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\Exp_rpt_DSR_template.html");
            string readFile = reader.ReadToEnd();
            string myString = string.Empty;
            myString = readFile;
            // string Header1 = "", Header2 = "", Header3 = "", Header4 = "", Header5 = "", Header6 = "", Header7 = "",Header="";
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            if (ds.Tables.Count > 0)
            {
                for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.AppendLine("<tr height=21 style='mso-height-source:userset;height:15.75pt'>");
                    sb.AppendLine("td height=35 class=xl67 width=53 style='height:26.25pt;width:40pt'>");
                    sb.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["HEADER"]));
                    sb.AppendLine("<span style='mso-spacerun:yes'>&nbsp;</span>");
                    sb.AppendLine("</td> </tr>");
                }
                if (Mode == "1")
                {
                    sb2.AppendLine("<tr height=35 style='height:26.25pt'>");
                    sb2.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> <b>ORIGIN </b></td>");
                    sb2.AppendLine("< td class=xl67 width = 99 style='border-left:none;width:74pt'><b>Shipper Name</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 68 style='border-left:none;width:51pt'><b>Order No.</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 118 style='border-left:none;width:89pt'><b>Article Reference</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 132 style='border-left:none;width:99pt'><b> Cargo Receipt Date</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 203 style='border-left:none;width:152pt'> <b>  Document Receipt Date(Dest.)</b> </td>");
                    sb2.AppendLine("< td class=xl67 width = 218 style='border-left:none;width:164pt'> <b>  Redcats Approval Received date</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 110 style='border-left:none;width:83pt'><b>No.of Packages</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 129 style='border-left:none;width:97pt'> <b> Actual Weight(KG) </b> </td>");
                    sb2.AppendLine(" < td class=xl67 width = 138 style='border-left:none;width:104pt'> <b> Volume Weight(KG) </b> </td>");
                    sb2.AppendLine(" < td class=xl67 width = 140 style='border-left:none;width:105pt'> <b>  MAWB No.AND  Date</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 72 style='border-left:none;width:54pt'><b>HAWB No.</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 110 style='border-left:none;width:83pt'> <b>Flight No. /  Date</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 32 style='border-left:none;width:24pt'><b>ETD</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 32 style='border-left:none;width:24pt'><b>ETA</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 71 style='border-left:none;width:53pt'><b>REMARKS</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 129 style='border-left:none;width:97pt'><b>FREIGHT COLLECT</b></td>");
                    sb2.AppendLine(" < td class=xl67 width = 211 style='border-left:none;width:158pt'><b>AIR FREIGHT  RATE / KG IN USD</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 77 style='border-left:none;width:58pt'><b>FREIGHT %</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 256 style='border-left:none;width:192pt'><b>AIRPORT TO  AIRPORT FREIGHT AMOUNT(USD) - PREPAID</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 67 style='border-left:none;width:50pt'><b>COLLECT</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 110 style='border-left:none;width:83pt'><b>TradeBeam PL#</b></td>");
                    sb2.AppendLine("< td class=xl67 width = 41 style='border-left:none;width:31pt'><b>PSS#</b></td>");
                    sb2.AppendLine("</tr>");

                }
                else
                {
                    sb2.AppendLine("<tr height=35 style='height:26.25pt'>");
                    sb2.AppendLine("<td height=20 class=xl67 width=180 style='height:15.0pt;border-top:none;  width:192pt'> <b>OUR REF </b></td>");
                    sb2.AppendLine("<td height=20 class=xl67 width=180 style='height:15.0pt;border-top:none;  width:192pt'> <b> ORIGIN</b> </td>");
                    sb2.AppendLine("<td class=xl67 width = 99 style='border-left:none;width:74pt'>  <b>CLINET_INV_REF</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 68 style='border-left:none;width:51pt'> <b>SHIPPER NAME</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 118 style='border-left:none;width:89pt'> <b>CONSIGNEE NAME</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 132 style='border-left:none;width:99pt'> <b>AGENT</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 203 style='border-left:none;width:152pt'> <b>DOCS RECVD</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 218 style='border-left:none;width:164pt'> <b>CARGO RECVD</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 110 style='border-left:none;width:83pt'> <b>POD</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 129 style='border-left:none;width:97pt'> <b>POL</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 138 style='border-left:none;width:104pt'> <b>CONTAINERNO</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 100 style='border-left:none;width:105pt'> <b> NO OF CONT</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 140 style='border-left:none;width:54pt'> <b>LINER</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 110 style='border-left:none;width:83pt'> <b>LINER_BOOKINGNO</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 120 style='border-left:none;width:24pt'> <b>VSL NAME</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 32 style='border-left:none;width:24pt'> <b>ETD</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 71 style='border-left:none;width:53pt'> <b>ATD</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 129 style='border-left:none;width:97pt'> <b>ETA</b></td>");
                    sb2.AppendLine("<td class=xl67 width = 130 style='border-left:none;width:158pt'> <b>MBL No</b></td>");

                    sb2.AppendLine("<td class=xl67 width = 120 style='border-left:none;width:192pt'> <b>Shipping Bill</b></td>");

                    sb2.AppendLine("</tr>");
                }
                if (Mode == "1")
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        sb1.AppendLine("<tr height=20 style='height:15.0pt'>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["ORIGIN"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=250 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Shipper Name"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Order No."]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Article Reference"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Cargo Receipt Date"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Document Receipt Date (Dest.)"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Redcats Approval  Received date"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["No. of Packages"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Actual Weight (KG)"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Volume Weight (KG)"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["MAWB No. AND Date"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["HAWB No."]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Flight No. / Date"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["ETD"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["ETA"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=250 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["REMARKS"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["FREIGHT COLLECT"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["AIR FREIGHT RATE / KG IN USD"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["FREIGHT %"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["AIRPORT TO AIRPORT FREIGHT AMOUNT (USD) - PREPAID"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["COLLECT"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["TradeBeam PL#"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["PSS#"]));
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("</tr>");
                    }
                }
                else
                {
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        sb1.AppendLine("<tr height=20 style='height:15.0pt'>");

                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["OUR REF"]));
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("<td height=20 class=xl69 width=250 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["ORIGIN"]));
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["CLINET_INV_REF"]));
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["SHIPPER NAME"]));
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["CONSIGNEE NAME"]));
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["AGENT"]));
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["DOCS RECVD"]));
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["CARGO RECVD"]));
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["POD"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["POL"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["CONTAINERNO"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["NO OF CONT"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["LINER"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["LINER_BOOKINGNO"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["VSL_NAME"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["ETD"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=250 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["ATD"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["ETA"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["MBL No"]));
                        sb1.AppendLine("</td>");
                        sb1.AppendLine("<td height=20 class=xl69 width=180 style='height:15.0pt;border-top:none;  width:192pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[1].Rows[i]["Shipping Bill"]));
                        sb1.AppendLine("</td>");

                        sb1.AppendLine("</tr>");
                    }
                }

            }


            myString = myString.Replace("[Header]", Convert.ToString(sb))
                           .Replace("[Header1]", Convert.ToString(sb2))
                          .Replace("[ROWsColl]", Convert.ToString(sb1));

            byte[] byteArray = Encoding.UTF8.GetBytes(myString);
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);



            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "DSR_Report.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }

        //-------------------------3. TONNAGE REPORT


        /// <summary>Load page reference data for Fill Tonnage records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_Tonnage_PAGELOAD()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Export_FillConsinee");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Fill_Tonnage_PAGELOAD");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }//
        /// <summary>Perform Rpt AirTonnage records.</summary>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="ToDate">End date for the date range filter.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="Origin">Origin parameter.</param>
        /// <param name="Consignee">Consignee parameter.</param>
        /// <param name="Type">Type parameter.</param>
        /// <param name="WeekDay">Week Day parameter.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="destination">destination parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage exp_Rpt_AirTonnage([FromUri]string FromDate, string ToDate, string Mode, string Origin, string Consignee, string Type, string WeekDay, string cmpid, string cmpcode, string destination)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            if (Mode == "AIR")
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Export_Air_ToneAge", FromDate, ToDate, Mode, Origin, Consignee, Type, WeekDay);
            }
            else if (Mode == "SEA")
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXPORT_SEA_TONEAGE", FromDate, ToDate, Mode, Origin, Consignee, Type, WeekDay, cmpid, cmpcode);
            }
            else
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Export_DestSea_ToneAge", FromDate, ToDate, Mode, Origin, Consignee, Type, WeekDay, destination);
            }

            int countDtColumn = ds.Tables[0].Columns.Count;
            stringBuilder.AppendLine(@"<style> td { mso-number-format:\@; } </style><table>");


            //For Columns
            for (int i = 0; i < countDtColumn; i++)
            {
                stringBuilder.AppendLine("<th>");
                stringBuilder.AppendLine(Convert.ToString(ds.Tables[0].Columns[i].ColumnName));
                stringBuilder.AppendLine("</th>");
            }
            stringBuilder.AppendLine("</tr>");
            //For Rows
            for (int j = 0; j < ds.Tables[1].Rows.Count; j++)
            {
                stringBuilder.AppendLine("<tr style='background-color: white; color: Black;font-size:9pt;font-family: Arial;'>");
                for (int k = 0; k < countDtColumn; k++)
                {
                    stringBuilder.AppendLine("<td>");
                    stringBuilder.AppendLine(Convert.ToString(ds.Tables[0].Rows[j][k]));
                    stringBuilder.AppendLine("</td>");
                }
                stringBuilder.AppendLine("</tr>");
            }
            stringBuilder.AppendLine("</table>");

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "AIR_TONNAGE.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        // -------------------shipment - status


        /// <summary>Retrieve Fill ship status source agent records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_ship_status_source_agent()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Export_FillSourceAgent");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Fill_ship_status_source_agent");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }


        /// <summary>Retrieve Fill ship status business associate records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_ship_status_business_associate()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Export_FillBA");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Fill_ship_status_business_associate");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /*
        /// <summary>Perform Rpt shipment Status records.</summary>
        /// <param name="ClientType">Client/exporter code.</param>
        /// <param name="Client">Client/exporter code.</param>
        /// <param name="Origin">Origin parameter.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="Nameclient">Client/exporter code.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage exp_Rpt_shipment_Status([FromUri]string ClientType, string Client, string Origin, string Mode, string FromDate, string cmpcode, string Nameclient)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();


            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Export_Shipment_Status_New", ClientType, Client, Origin, Mode, FromDate, cmpcode);

            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("..\\..\\") + "Include\\template\\Exp_rpt_Shipment_status.html");
            string readFile = reader.ReadToEnd();
            string myString = string.Empty;
            string header = "", header1 = "", header2 = "", header3 = "", mainhead = "", mainhead2 = "";

            if (Mode == "AIR")
            {
                header = "<td class=xl85 width=62 style='border-top:none;border-left:none;width:47pt'>CHARGEBLE WT.</td>";
                header1 = "<td class=xl85 width=62 style='border-top:none;border-left:none;width:47pt'>FLT DTLS</td>";
                header2 = "<td class=xl85 width=62 style='border-top:none;border-left:none;width:47pt'> TRNSSHIPMENT</td>";
                header3 = "<td class=xl85 width=62 style='border-top:none;border-left:none;width:47pt'>MAWB</td>";

            }
            else
            {
                header1 = "<td class=xl85 width=62 style='border-top:none;border-left:none;width:47pt'>CONTAINERNO</td>";
                header2 = "<td class=xl85 width=62 style='border-top:none;border-left:none;width:47pt'> VESSEL</td>";
                header3 = "<td class=xl85 width=62 style='border-top:none;border-left:none;width:47pt'>FCR NO.</td>";
            }

            myString = readFile;
            // string Header1 = "", Header2 = "", Header3 = "", Header4 = "", Header5 = "", Header6 = "", Header7 = "",Header="";
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            if (ds.Tables.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb1.AppendLine("<tr height=20 style='height:15.0pt '>");
                    sb1.AppendLine("<td height=20 class=xl70 width=62 style='height:15.0pt;border-top:none;  width:47pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["ORIGIN"]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 width=100 style='border-top:none;border-left:none;width:75pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["M.P. REF."]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 width=194  style='border-top:none;border-left:none;width:146pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["SHIPPER"]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65  width=132 style='border-top:none;border-left:none;width:99pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["CONSIGNEE"]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 width=132 style='border-top:none;border-left:none;width:99pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["ORDER DETAILS"]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 align=right width=46 style='border-top:none;border-left:none; width:35pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["CTNS."]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 style='border-top:none;border-left:none;width:24pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["FRT"]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65  align=right width=51 style='border-top:none;border-left:none; width:38pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["GR.WT"]));
                    sb1.AppendLine("</td>");
                    if (Mode == "AIR")
                    {
                        sb1.AppendLine("<td height=20 class=xl65 align=right width=51 style='border-top:none;border-left:none; width:38pt'> ");
                        sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["CHARGEBLE WT."]));
                        sb1.AppendLine("</td>");
                    }
                    sb1.AppendLine("<td height=20 class=xl65 width=62 style='border-top:none;border-left:none; width:47pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["VOLUME"]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65  width=94 style='border-top:none;border-left:none;width:71pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["DOCS. RECD."]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 width=50 style='border-top:none;border-left:none;width:38pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["CARGO RECD."]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 width=50 style='border-top:none;border-left:none;width:38pt''> ");
                    if (Mode == "AIR")
                    {
                        sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["APPROVAL RECD"]));
                    }
                    else { sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["APPROVAL RECD"])); }

                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 width=137 style='border-top:none;border-left:none;width:103pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["CLRCE"]));
                    sb1.AppendLine("</td>");

                    sb1.AppendLine("<td height=20 class=xl65 width=120 style='height:15.0pt;border-top:none;  width:192pt'> ");
                    if (Mode == "AIR")
                    {
                        sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["FLT DTLS"]));
                    }
                    else
                    {
                        sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["CONTAINERNO"]));
                    }
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 width=250 style='height:15.0pt;border-top:none;  width:192pt'> ");
                    if (Mode == "AIR")
                    {
                        sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["TRNSSHIPMENT"]));
                    }
                    else
                    { sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["VESSEL"])); }

                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 width=94 style='border-top:none;border-left:none;width:71pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["ETD"]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 width=94 style='border-top:none;border-left:none;width:71pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["ETA"]));
                    sb1.AppendLine("</td>");
                    sb1.AppendLine("<td height=20 class=xl65 width=94 style='border-top:none;border-left:none;width:71pt'> ");
                    sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["DESTINATION"]));
                    sb1.AppendLine("</td>");

                    sb1.AppendLine("<td height=20 class=xl65 width=94 style='border-top:none;border-left:none;width:71pt'> ");
                    if (Mode == "AIR")
                    {
                        sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["MAWB"]));
                    }
                    else
                    { sb1.AppendLine(Convert.ToString(ds.Tables[0].Rows[i]["FCR"])); }

                    sb1.AppendLine("</td>");
                    sb1.AppendLine("</tr>");
                }

                mainhead = "<tr height=20 style='height:15.0pt'> <td colspan=19 height=20 class=xl81 style='height:15.0pt'>";
                mainhead = mainhead + Convert.ToString(ds.Tables[1].Rows[0]["Header"]) + "</td></tr>";
                mainhead2 = "<tr height=20 style='height:15.0pt'> <td colspan=19 height=20 class=xl81 style='height:15.0pt'>";
                mainhead2 = mainhead2 + Nameclient + "  - " + Mode + "</td></tr>";

            }

            myString = myString.Replace("[header]", header)
                .Replace("[header1]", header1)
                .Replace("[header2]", header2)
                .Replace("[header3]", header3)
                .Replace("[MainHead]", mainhead)
                .Replace("[Client]", mainhead2)

                .Replace("[ROWsColl]", Convert.ToString(sb1));

            byte[] byteArray = Encoding.UTF8.GetBytes(myString);
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);



            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Shipment_status.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        */
        /// <summary>Perform Rpt shipment Status records.</summary>
        /// <param name="ClientType">Client/exporter code.</param>
        /// <param name="Client">Client/exporter code.</param>
        /// <param name="Origin">Origin parameter.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="FromDate">Start date for the date range filter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="Nameclient">Client/exporter code.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage exp_Rpt_shipment_Status([FromUri]string ClientType, string Client, string Origin, string Mode, string FromDate, string cmpcode, string Nameclient)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string myString = string.Empty;

            //strSpName = "Usp_Export_Shipment_Status_New";

            if (Mode == "AIR")
            {
                strXslFilename = "xsl_Expo_Rpt_Shipment_Status_Air.xsl";
            }
            else
            {
                strXslFilename = "xsl_Expo_Rpt_Shipment_Status.xsl";
            }

            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "Usp_Export_Shipment_Status_New", ClientType, Client, Origin, Mode, FromDate, cmpcode);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            myString = CommonFunction.ConvertToExcel_open("Export", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(myString));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Shipment_status_" + Mode + "_" + Client + "_" + Nameclient.ToString() + ".xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;

        }
        


        // chargo on hang 

        /// <summary>Retrieve Fill consignee cargo onhand records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_consignee_cargo_onhand()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_RPT_AIR_CARGOONHAND_FILL_DROPDOWN");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Fill_consignee_cargo_onhand");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform Rpt Cargo onhand records.</summary>
        /// <param name="CONCODE">CONCODE parameter.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="cmp_code">Company code identifier.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage exp_Rpt_Cargo_onhand([FromUri]string CONCODE, string citycode, string cmp_code, string Mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string strData = string.Empty;


            if (Mode == "AIR")
            {
                strSpName = "USP_EXP_RPT_AIR_CARGOONHAND";
                strXslFilename = "xsl_Exp_Rpt_Air_CargoOnHand.xsl";
            }
            else
            {
                strSpName = "USP_EXP_RPT_AIR_CARGOONHAND_SEA";
                strXslFilename = "xsl_Exp_Rpt_Air_CargoOnHand_Sea.xsl";
            }
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, strSpName, CONCODE, citycode, cmp_code);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            strData = CommonFunction.ConvertToExcel_open("Export", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(strData));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "SEA_CARGOONHAND.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }

        /// <summary>Perform Generate Chronology records.</summary>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_Chronology([FromUri]string mode, string citycode1, string fromdate, string todate, string cmpcode)
        {
            DataSet dsDetails = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            dsDetails = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_EXPT_CHRONOLOGYLIST_REPORT",
                (mode != null) ? mode : "",
                (citycode1 != null) ? citycode1 : "",
                (fromdate != null) ? fromdate : "",
               (todate != null) ? todate : "", cmpcode);

            stringBuilder.AppendLine(@"<style> td { mso-number-format:\@; } </style><table border='1'>");
            stringBuilder.AppendLine("<tr height='30%' style='background-color: #507CD1; color: white;font-size:10pt;font-family: Arial;font-weight:bold;'>");
            //For Columns
            for (int i = 0; i < dsDetails.Tables[0].Columns.Count; i++)
            {
                stringBuilder.AppendLine("<th>");

                if (i == 13)
                {
                    stringBuilder.AppendLine((mode == "Air") ? "FLIGHT NO" : "VESSEL NAME");
                }
                else if (i == 14)
                {
                    stringBuilder.AppendLine((mode == "Air") ? "FLIGHT DT" : "VOYAGE NO");
                }
                else if (i == 15)
                {
                    stringBuilder.AppendLine((mode == "Air") ? "ACTUAL FLIGHT DT" : "ACTUAL SELLING DT");
                }
                else
                {
                    stringBuilder.AppendLine(dsDetails.Tables[0].Columns[i].ColumnName);
                }
                stringBuilder.AppendLine("</th>");
            }
            stringBuilder.AppendLine("</tr>");
            //For Rows
            for (int j = 0; j < dsDetails.Tables[0].Rows.Count; j++)
            {
                stringBuilder.AppendLine(String.Format("<tr style='{0}'>", dsDetails.Tables[0].Rows[j]["STYLE"]));
                for (int k = 0; k < dsDetails.Tables[0].Columns.Count; k++)
                {
                    stringBuilder.AppendLine("<td>");
                    stringBuilder.AppendLine(Convert.ToString(dsDetails.Tables[0].Rows[j][k]));
                    stringBuilder.AppendLine("</td>");
                }
                stringBuilder.AppendLine("</tr>");
            }
            stringBuilder.AppendLine("</table>");

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Chronology.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        /// <summary>Perform Generate Delivery Status records.</summary>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="supplier">Supplier code.</param>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_Delivery_Status([FromUri]string mode, string citycode, string supplier, string fromdate, string todate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_ExptDeliveryStatus",
                mode.Split('.')[0],
                (citycode != null) ? citycode : "",
                supplier,
                fromdate,
               todate);

            StringBuilder sbHeader = new StringBuilder();

            sbHeader.AppendLine("<br/><br/><table cellspacing='0' cellpadding='4' width='100%' border='1'>");
            sbHeader.AppendLine("<tbody>");
            sbHeader.AppendLine("<tr style='FONT-WEIGHT: bold; FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana, Arial; TEXT-ALIGN: center'>");
            sbHeader.AppendLine("<td colspan='23'>");
            sbHeader.AppendLine("Delivered On ( From " + fromdate + " Till " + todate + " ) and Contract = " + mode.Split('.')[1]);
            sbHeader.AppendLine("</td>");
            sbHeader.AppendLine("</tr>");
            sbHeader.AppendLine("</tbody>");
            sbHeader.AppendLine("<br/><br/><table border='1'");
            sbHeader.AppendLine("<tbody>");
            sbHeader.AppendLine("<tr style='background-color: #507CD1; color: white;font-size:10pt;font-family: Arial;font-weight:bold;'>");
            sbHeader.AppendLine("<td rowspan='2'>Port of Loading</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>Name of Vessel</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>Container No</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>Container Size</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>CNEE</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' colspan='3'>20 ' DRY</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' colspan='3'>40 ' DRY</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' colspan='3'>40' HC</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>Total TEU</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>Total LCL</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>Custom Cleared On (A)</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>SailedOn (B)</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>DAYS (C = B-A)</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>Actual Arrival Date (D)</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>Trasmit Time DAYS (E = D-B)</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>Actual Delivery Date (F)</td>");
            sbHeader.AppendLine("<td style='BORDER-LEFT: black 1px solid' rowspan='2'>DAYS (G = F-D)</td>");
            sbHeader.AppendLine("</tr>");
            sbHeader.AppendLine("<tr style='background-color: #507CD1; color: white;font-size:10pt;font-family: Arial;font-weight:bold;'>");
            sbHeader.AppendLine("<td style='BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid'>NB</td>");
            sbHeader.AppendLine("<td style='BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid'>CBM</td>");
            sbHeader.AppendLine("<td style='BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid'>UTIL. RATE</td>");
            sbHeader.AppendLine("<td style='BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid'>NB</td>");
            sbHeader.AppendLine("<td style='BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid'>CBM</td>");
            sbHeader.AppendLine("<td style='BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid'>UTIL. RATE</td>");
            sbHeader.AppendLine("<td style='BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid'>NB</td>");
            sbHeader.AppendLine("<td style='BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid'>CBM</td>");
            sbHeader.AppendLine("<td style='BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid'>UTIL. RATE</td>");
            sbHeader.AppendLine("</tr>");


            if (ds.Tables[0].Rows.Count > 0)
            {
                string containersize = string.Empty, size1 = string.Empty, totcbm = string.Empty,
                    NB = string.Empty, NB1 = string.Empty, NB2 = string.Empty, NB3 = string.Empty, totNB = string.Empty,
                    CBM = string.Empty, UTIL = string.Empty, custom = string.Empty, sailing = string.Empty, days = string.Empty,
                    actualarrivaldt = string.Empty, actualdeliverydt = string.Empty;
                NB1 = "0";
                NB2 = "0";
                NB3 = "0";
                totNB = "0";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sbHeader.AppendLine("<tr style='background-color: #EFF3FB; color: #333333; font-size: 8pt;vertical-align: top;' height=20>");
                    sbHeader.AppendLine(String.Format("<td style='width:117px'>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["port"])));
                    sbHeader.AppendLine(String.Format("<td align=left>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["vsl_name"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["containerno"])));
                    sbHeader.AppendLine(String.Format("<td align=left>{0} - {1}</td>", Convert.ToString(ds.Tables[0].Rows[i]["containersize"]), Convert.ToString(ds.Tables[0].Rows[i]["size1"])));
                    sbHeader.AppendLine(String.Format("<td align=left>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["con_sname"])));

                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["20F_NB"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["20F_CBM"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["20F_UTIL_RATE"])));

                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["40F_NB"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["40F_CBM"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["40F_UTIL_RATE"])));

                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["40H_NB"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["40H_CBM"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["40H_UTIL_RATE"])));

                    sbHeader.AppendLine(String.Format("<td align=left>{0}</td>", Convert.ToString("")));
                    sbHeader.AppendLine(String.Format("<td align=left>{0}</td>", Convert.ToString("")));

                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["custom"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["sailing"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["DAYS"])));

                    sbHeader.AppendLine(String.Format("<td align=left>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["actualarrivaldt"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["ACTUAL_ARRIVAL_DAYS"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["actualdeliverydt"])));
                    sbHeader.AppendLine(String.Format("<td align=right>{0}</td>", Convert.ToString(ds.Tables[0].Rows[i]["ACTUAL_DELIVERY_DAYS"])));
                    sbHeader.AppendLine("</tr>");
                }
            }



            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(sbHeader));
            sbHeader.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Chronology.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        /// <summary>Perform Generate Shipment Progress records.</summary>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="citycode1">Secondary city/branch code.</param>
        /// <param name="fromdate">Start date for the date range filter.</param>
        /// <param name="todate">End date for the date range filter.</param>
        /// <param name="datetype">datetype parameter.</param>
        /// <param name="displaytype">displaytype parameter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_Shipment_Progress([FromUri]string mode, string citycode1, string fromdate, string todate, string datetype, string displaytype, string cmpcode, string citycode)
        {
            DataSet dsData = new DataSet();
            DataSet dsDetails = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();

            dsData = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_Common_Company", cmpcode, citycode);
            string strData = string.Empty;
            if (dsData.Tables.Count > 0)
            {
                stringBuilder.AppendLine("<b>");
                stringBuilder.AppendLine(Convert.ToString(dsData.Tables[0].Rows[0]["cmp_name"]));
                stringBuilder.AppendLine(" - ");
                stringBuilder.AppendLine(Convert.ToString(dsData.Tables[0].Rows[0]["city_name"]));
                stringBuilder.AppendLine("</b><br/>");
            }

            stringBuilder.AppendLine("<br /><b>Shipment Progrss Report</b>");
            stringBuilder.AppendLine("<br /><b>Mode :-");
            stringBuilder.AppendLine(mode);
            stringBuilder.AppendLine(" Dated On: ");
            stringBuilder.AppendLine(fromdate);
            stringBuilder.AppendLine(" To ");
            stringBuilder.AppendLine(todate);
            stringBuilder.AppendLine("</b><br />");

            dsDetails = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_Expt_Chronology2",
                mode,
                (citycode1 != null) ? citycode1 : "",
                fromdate, todate, datetype, displaytype);

            if (dsDetails.Tables.Count > 0)
            {
                stringBuilder.AppendLine("<table>");
                stringBuilder.AppendLine("<tr style='background-color: #507CD1; color: Aqua;font-size:10pt;font-family: Arial;font-weight:bold;'>");
                //For Columns
                for (int i = 0; i < dsDetails.Tables[0].Columns.Count; i++)
                {
                    stringBuilder.AppendLine("<th>");
                    stringBuilder.AppendLine(dsDetails.Tables[0].Columns[i].ColumnName);
                    stringBuilder.AppendLine("</th>");
                }
                stringBuilder.AppendLine("</tr>");
                //For Rows
                for (int j = 0; j < dsDetails.Tables[0].Rows.Count; j++)
                {
                    if (j % 2 == 0)
                    {
                        stringBuilder.AppendLine("<tr style='background-color: #D1DDF1; color: #333333; font-size: 8pt;text-align: left;vertical-align: top;'>");
                    }
                    else
                    {
                        stringBuilder.AppendLine("<tr style='background-color: #EFF3FB; color: #333333; font-size: 8pt;text-align: left;vertical-align: top;'>");
                    }
                    for (int k = 0; k < dsDetails.Tables[0].Columns.Count; k++)
                    {
                        stringBuilder.AppendLine("<td>");
                        stringBuilder.AppendLine(Convert.ToString(dsDetails.Tables[0].Rows[j][k]));
                        stringBuilder.AppendLine("</td>");
                    }

                    stringBuilder.AppendLine("</tr>");
                }
                stringBuilder.AppendLine("</table>");
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "Shipment_Progress.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;

        }

        /// <summary>Perform Generate Air Cargo Status records.</summary>
        /// <param name="client">Client/exporter code.</param>
        /// <param name="agent">agent parameter.</param>
        /// <param name="origin">origin parameter.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_Air_Cargo_Status([FromUri]string client, string agent, string origin, string cmpid, string cmpcode)
        {
            DataSet dsDetails = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            dsDetails = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_EXP_RPT_CAROG_STATUS_XSL",
                (client != null) ? client : "",
                (agent != null) ? agent : "",
                (origin != null) ? origin : "",
               (cmpid != null) ? cmpid : "");

            int countDtColumn = dsDetails.Tables[1].Columns.Count;
            stringBuilder.AppendLine(@"<style> td { mso-number-format:\@; } </style><table>");
            //For Headers
            for (int i = 0; i < dsDetails.Tables[0].Rows.Count; i++)
            {
                stringBuilder.AppendLine(String.Format("<tr><td colspan='{0}'>", countDtColumn));
                stringBuilder.AppendLine(String.Format("<br />{0}", Convert.ToString(dsDetails.Tables[0].Rows[i]["HEADER"])));
                stringBuilder.AppendLine("</td></tr>");
            }

            stringBuilder.AppendLine(String.Format("<tr><td colspan='{0}'>&nbsp;</td></tr>", countDtColumn));
            stringBuilder.AppendLine("</table>");
            stringBuilder.AppendLine("<table border='1'>");
            stringBuilder.AppendLine("<tr height='30%' style='background-color: #FFFF66; color: Black;font-size:10pt;font-family: Arial;font-weight:bold;'>");
            //For Columns
            for (int i = 0; i < countDtColumn; i++)
            {
                stringBuilder.AppendLine("<th>");
                stringBuilder.AppendLine(Convert.ToString(dsDetails.Tables[1].Columns[i].ColumnName));
                stringBuilder.AppendLine("</th>");
            }
            stringBuilder.AppendLine("</tr>");
            //For Rows
            for (int j = 0; j < dsDetails.Tables[1].Rows.Count; j++)
            {
                stringBuilder.AppendLine("<tr style='background-color: white; color: Black;font-size:9pt;font-family: Arial;'>");
                for (int k = 0; k < countDtColumn; k++)
                {
                    stringBuilder.AppendLine("<td>");
                    stringBuilder.AppendLine(Convert.ToString(dsDetails.Tables[1].Rows[j][k]));
                    stringBuilder.AppendLine("</td>");
                }
                stringBuilder.AppendLine("</tr>");
            }
            stringBuilder.AppendLine("</table>");

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_CARGO_STATUS.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        /// <summary>Perform Generate Tracking Air Booking Report records.</summary>
        /// <param name="client">Client/exporter code.</param>
        /// <param name="agent">agent parameter.</param>
        /// <param name="origin">origin parameter.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_Tracking_Air_Booking_Report([FromUri]string client, string agent, string origin, string cmpid, string cmpcode)
        {
            DataSet dsDetails = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            dsDetails = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_EXP_RPT_TRACKING_AIR_BOOKING_XSL",
                (client != null) ? client : "",
                (agent != null) ? agent : "",
                (origin != null) ? origin : "",
               (cmpid != null) ? cmpid : "");

            int countDtColumn = dsDetails.Tables[1].Columns.Count;
            stringBuilder.AppendLine(@"<style> td { mso-number-format:\@; } </style><table>");
            //For Headers
            for (int i = 0; i < dsDetails.Tables[0].Rows.Count; i++)
            {
                stringBuilder.AppendLine(String.Format("<tr><td colspan='{0}'>", countDtColumn));
                stringBuilder.AppendLine(String.Format("<br />{0}", Convert.ToString(dsDetails.Tables[0].Rows[i]["HEADER"])));
                stringBuilder.AppendLine("</td></tr>");
            }

            stringBuilder.AppendLine(String.Format("<tr><td colspan='{0}'>&nbsp;</td></tr>", countDtColumn));
            stringBuilder.AppendLine("</table>");
            stringBuilder.AppendLine("<table border='1'>");
            stringBuilder.AppendLine("<tr height='30%' style='background-color: #FFFF66; color: Black;font-size:10pt;font-family: Arial;font-weight:bold;'>");
            //For Columns
            for (int i = 0; i < countDtColumn; i++)
            {
                stringBuilder.AppendLine("<th>");
                stringBuilder.AppendLine(Convert.ToString(dsDetails.Tables[1].Columns[i].ColumnName));
                stringBuilder.AppendLine("</th>");
            }
            stringBuilder.AppendLine("</tr>");
            //For Rows
            for (int j = 0; j < dsDetails.Tables[1].Rows.Count; j++)
            {
                stringBuilder.AppendLine("<tr style='background-color: white; color: Black;font-size:8pt;font-family: Arial;'>");
                for (int k = 0; k < countDtColumn; k++)
                {
                    stringBuilder.AppendLine("<td>");
                    stringBuilder.AppendLine(Convert.ToString(dsDetails.Tables[1].Rows[j][k]));
                    stringBuilder.AppendLine("</td>");
                }
                stringBuilder.AppendLine("</tr>");
            }
            stringBuilder.AppendLine("</table>");

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_TRACKING_AIR_BOOKING_REPORT.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        /// <summary>Perform Generate Tracking Air Shipment Report records.</summary>
        /// <param name="client">Client/exporter code.</param>
        /// <param name="agent">agent parameter.</param>
        /// <param name="origin">origin parameter.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_Tracking_Air_Shipment_Report([FromUri]string client, string agent, string origin, string cmpid, string cmpcode)
        {
            DataSet dsDetails = new DataSet();
            DAL objDal = new DAL();
            dsDetails = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_EXP_RPT_TRACKING_AIR_SHIPMENTS_XSLT",
                (client != null) ? client : "",
                (agent != null) ? agent : "",
                (origin != null) ? origin : "",
               (cmpid != null) ? cmpid : "");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(dsDetails.GetXml());

            string strXsltData = string.Empty;

            if (client == "C105596")//"EPHIGIA"
            {
                strXsltData = CommonFunction.ConvertToExcel_open("Export", "xsl_Exp_Rpt_Tracking_Air_Shipment_XL_EPHIGIA.xsl", xmlDoc);
            }
            else if (client == "C100043")//"JULES"
            {
                strXsltData = CommonFunction.ConvertToExcel_open("Export", "xsl_Exp_Rpt_Tracking_Air_Shipment_XL_JULES.xsl", xmlDoc);
            }
            else if (client == "C104071")//"PIMKIE"
            {
                strXsltData = CommonFunction.ConvertToExcel_open("Export", "xsl_Exp_Rpt_Tracking_Air_Shipment_XL_PIMPKIE.xsl", xmlDoc);
            }
            else if (client == "C100002")//"SAS KIABI EUROPE"
            {
                strXsltData = CommonFunction.ConvertToExcel_open("Export", "xsl_Exp_Rpt_Tracking_Air_Shipment_XL_KIABI.xsl", xmlDoc);
            }
            else   //Other selected Consignee
            {
                strXsltData = CommonFunction.ConvertToExcel_open("Export", "xsl_Exp_Rpt_Tracking_Air_Shipment_XL.xsl", xmlDoc);
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(strXsltData));
            strXsltData = string.Empty;
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_TRACKING_AIR_SHIPMENTS_REPORT.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        /// <summary>Perform FCR printflagUpdate records.</summary>
        /// <param name="fcr">fcr parameter.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="userid">userid parameter.</param>
        /// <param name="Type">Type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult FCR_printflagUpdate(string fcr, string citycode, string userid, string Type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_PRNTDOC_FCR_PRINT_FLAG_UPDATE", fcr, citycode, userid, Type);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/FCR_printflagUpdate");
            }
            return Ok(ds);
        }

        //container factory stuffing
        /// <summary>Retrieve dropdown data for ContainerFS records.</summary>
        /// <param name="vsl">vsl parameter.</param>
        /// <param name="port">port parameter.</param>
        /// <param name="CMPCOD">CMPCOD parameter.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ContainerFS_Fill(string vsl, string port, string CMPCOD, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_CONTAINERFS_FILLDROPDOWN", vsl, port, CMPCOD, CITYCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/ContainerFS_Fill");
            }
            return Ok(ds);
        }
        /// <summary>Perform ContainerFS FillExptno records.</summary>
        /// <param name="exptno">Export job number.</param>
        /// <param name="userid">userid parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ContainerFS_FillExptno(string exptno, string userid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_CONTAINERFS_FILLEXPTNO", exptno, userid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/ContainerFS_FillExptno");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update Export containerFSTmp records.</summary>
        /// <param name="CN">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_containerFSTmp_IU([FromBody]containerFSTmpIu CN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_CONTAINERFS_TMP_IU", CN.ID, CN.CONTAINERID, CN.CONTAINERNO, CN.CONTSIZE, CN.CONTSIZE1, CN.EXPTNO, CN.PKGS, CN.CBM, CN.Pcs, CN.GrWt, CN.NetWt, CN.CLP_SEQ, CN.USERID, CN.VGUID, CN.CONTSTATUS, CN.DESTPORT, CN.MOVETYPE, CN.STEAM_AGENTNO, CN.CUSTOM_AGENTNO, CN.FREIGHT);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_containerFSTmp_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update Export containerFS records.</summary>
        /// <param name="CN">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Export_containerFS_IU([FromBody]ContainerFS CN)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_CONTAINERFS_IU", CN.VSL_RTNO, CN.VSL_PORT, CN.VSL_AGNT, CN.VSL_SHIPLINE, CN.USERID, CN.VGUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/Export_containerFS_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Delete ContainerFS records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="userid">userid parameter.</param>
        /// <param name="vguid">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ContainerFS_DELETE(string ID, string userid, string vguid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_CONTAINERFS_TMP_DELETE", ID, userid, vguid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/ContainerFS_DELETE");
            }
            return Ok(ds);
        }

        /// <summary>Load page reference data for ContainerFS records.</summary>
        /// <param name="userid">userid parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ContainerFS_PAGELOAD(string userid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_EXP_SHIPMENT_PROGRESS_CONTAINERFS_TMP_PAGELOAD", userid);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Export/ContainerFS_PAGELOAD");
            }
            return Ok(ds);
        }
        /// <summary>Perform EXPT EXPORT DASHBOARD Vessel records.</summary>
        /// <param name="CityCode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult EXPT_EXPORT_DASHBOARD_Vessel([FromUri]string CityCode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXPT_EXPORT_DASHBOARD",
                    CityCode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/EXPT_EXPORT_DASHBOARD_Vessel");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }


    }

}
