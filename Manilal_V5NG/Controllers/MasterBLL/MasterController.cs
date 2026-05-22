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
 

namespace Manilal_V5NG.Controllers.MasterBLL
{
    public class MasterController : ApiController
    {
        /// <summary>Retrieve quotation data for print view by quotation code.</summary>
        /// <param name="QUOTCODE">QUOTCODE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MASTER_QUOTATION_PRINT(string QUOTCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_QUOTATION_PRINT", QUOTCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MASTER_QUOTATION_PRINT");
            }
            return Ok(ds);
        }
        /// <summary>Insert or update a temporary TDS detail row for a general account.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult MST_GENERAL_ACCOUNT_TDS_TMP_IU_NG([FromBody]supplierchildTDS cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_GENACT_MST_TDS_DET_TMP_IU", cd.PKID, cd.ACCT_CODE, cd.SECTIONID, cd.PER_RATE, cd.FRMDT, cd.TODT, cd.TDS_LIMIT_AMT, cd.TDS_TYPE, cd.MAKERID, cd.MAKERIP, cd.VGUID, (cd.LDCRATE != null) ? cd.LDCRATE : "0.00", (cd.CMPCODE != null) ? cd.CMPCODE : "0", (cd.LDCCERTNO != null) ? cd.LDCCERTNO : "", cd.GENACTTDSDTLID);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/MST_GENERAL_ACCOUNT_TDS_TMP_IU_NG");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Reset temporary general account data for the given VGUID session.</summary>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MST_GENERAL_ACCOUNT_RESET(string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_GENACT_MST_RESET", VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST_GENERAL_ACCOUNT");
            }
            return Ok(ds);
        }
        /// <summary>Populate the general account form with existing record data (NG version).</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="MAKERID">User code of the record maker.</param>
        /// <param name="MAKERIP">IP address of the record maker.</param>
        /// <param name="VGUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MST_GENERAL_ACCOUNT_POPULATE_NG(String ID, string MAKERID, string MAKERIP, string VGUID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_GENERAL_ACCOUNT_POPULATE_NG", ID, MAKERID, MAKERIP, VGUID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST_GENERAL_ACCOUNT_POPULATE_NG");
            }
            return Ok(ds);
        }
        /// <summary>Load dropdown reference data for the general account master page.</summary>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GenActMstpageload(string CMPID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_GENACT_PAGELOAD", CMPID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/GenActMstpageload");
            }
            return Ok(ds);
        }

        /// <summary>Insert or update a general account master record (NG version).</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult MST_GENERAL_ACCOUNT_IU_NG([FromBody]GeneralAccountMaster cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_GENERAL_ACCOUNT_IU_NG", cd.ID, cd.AccName, cd.UnderGroup, cd.SACCode, cd.Invoice, cd.Bank, cd.JobRpt, cd.invreg_isreport, cd.IsExpenseLock, cd.IsPurchase_Show, cd.MUM, (cd.DEL != null) ? cd.DEL : "", (cd.MAA != null) ? cd.MAA : "", (cd.BLR != null) ? cd.BLR : "", (cd.AMD != null) ? cd.AMD : "", (cd.TRN != null) ? cd.TRN : "", (cd.TRU != null) ? cd.TRU : "", (cd.COC != null) ? cd.COC : "", cd.IsEmployee, cd.Company, cd.MakerID, cd.MakerIP, cd.VGUID, (cd.IS_TDS_APP != null) ? cd.IS_TDS_APP : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST_GENERAL_ACCOUNT_IU_NG");
            }
            return Ok(ds);
        }
        /// <summary>Retrieve the accounts item code list for dropdown population.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GET_MST_ACCOUNTS_ITEMCODE()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_ACCOUNTS_ITEMCODE_FILL_DROPDOWN");
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST_ACCOUNTS_ITEMCODE_FILL_DROPDOWN");
            }
            return Ok(ds);
        }



        /* drop down*/
        /// <summary>Retrieve the country list for dropdown population.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult populatecountry( )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_EXP_City_FillCountry");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/populatecountry");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /* PAGE LOAD FILL*/
        /// <summary>Populate city details for the given city code.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult populateCity([FromUri]string citycode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_EXP_City_Populate", citycode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/populateCity");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /* CITY SAVE */
        /// <summary>Insert or update a city master record.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult cityIU([FromBody]Master cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_City_IU", cd.id, cd.city_code, cd.city_name, cd.city_country, cd.city_seaport, cd.city_airport, cd.city_consoleorigin, cd.city_consoledest, cd.city_deldest, cd.city_tranship, cd.MakerID, cd.MakerIP, cd.cmp_code, cd.citycode);  
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/cityIU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /* sEARCH lIST*/
        /// <summary>Search city records by name.</summary>
        /// <param name="strname">strname parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult searchlist([FromUri]string strname)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_EXP_City_Fill", strname);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/searchlist");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /*-----EXPORTER /CLIENT ---------*/
        //
        /// <summary>Retrieve exporter/client details for the given exporter code.</summary>
        /// <param name="_ExpCode"> Exp Code parameter.</param>
        /// <param name="RequestMode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_Exp_Details([FromUri]string _ExpCode,string RequestMode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP35_EXP_FILLDETAILS", _ExpCode, (RequestMode != null) ? RequestMode : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/Fill_Exp_Details");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve the branch city list for dropdown population.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_BranchCity()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_CMP_FILLCITY", 1885);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/Fill_BranchCity");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Insert or update an exporter invoice address child record.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult exporter_child_IU([FromBody]expoterchild cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_MSTINVCHILDAdd_IU", cd.childrecdId, cd.exp_invadd1, cd.exp_invadd2, cd.exp_invadd3, cd.exp_invpincode, cd.exp_invpinposition, cd.exp_invcity,cd.vguid,cd.MakerIP,cd.MakerID, cd.EXP_GSTNO, cd.EXP_GSTARNNO, cd.EXP_GSTtitle, cd.Exp_GSTcontP, cd.Exp_GSTtelno, cd.EXP_GSTMobno, cd.EXP_GSTcontemail, cd.expid,cd.reqmode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/exporter_child_IU");
            }
            finally
            {
                objDal.Dispose();
               
            }
            return Ok(ds);
        }
        /// <summary>Delete a temporary exporter address child record.</summary>
        /// <param name="id">Primary key ID of the record.</param>
        /// <param name="guid">Session GUID for temporary record management.</param>
        /// <param name="makerid">User code of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult exporter_child_delete([FromUri]string id,string guid ,string makerid )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_MSTINVCHILDDELETE_IU", id, guid, makerid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/exporter_child_IU");
            }
            finally
            {
                objDal.Dispose();                
            }
            return Ok(ds);
        }
        /*
        /// <summary>Insert or update an exporter/client master record.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult exporter_Main_IU([FromBody]ExpoterMain cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                var id=(cd.id != null) ? cd.id : "";

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_EXPORTER_IU",                    
                cd.id, (cd.exp_sname  != null) ? cd.exp_sname  : "", cd.exp_name,(cd.exp_add1!= null) ?  cd.exp_add1  : "", (cd.exp_add2 != null) ? cd.exp_add2: "", (cd.exp_add3 != null) ? cd.exp_add3  : "", 
                (cd.exp_pincode!= null) ?  cd.exp_pincode  : "", (cd.exp_pinposition  != null) ? cd.exp_pinposition   : "", (cd.exp_city  != null) ? cd.exp_city   : "", (cd.exp_country != null) ?cd.exp_country    : "", 
                (cd.exp_invadd1 != null) ? cd.exp_invadd1   : "", (cd.exp_invadd2  != null) ? cd.exp_invadd2  : "", (cd.exp_invadd3 != null) ? cd.exp_invadd3   : "", (cd.exp_invpincode != null) ? cd.exp_invpincode   : "", 
                (cd.exp_invpinposition  != null) ? cd.exp_invpinposition   : "", (cd.exp_invcity  != null) ?  cd.exp_invcity  : "", (cd.exp_invcountry  != null) ? cd.exp_invcountry  : "", (cd.exp_telno  != null) ?cd.exp_telno    : "", 
                (cd.exp_faxno != null) ?cd.exp_faxno   : "", (cd.exp_telex != null) ?cd.exp_telex    : "", (cd.exp_email  != null) ?cd.exp_email    : "", (cd.exp_rbicode   != null) ? cd.exp_rbicode   : "", 
                (cd.exp_imno  != null) ? cd.exp_imno   : "", (cd.exp_itno  != null) ?cd.exp_itno    : "", (cd.exp_bank  != null) ? cd.exp_bank   : "", (cd.exp_custpno  != null) ?cd.exp_custpno    : "", 
                (cd.exp_hscertno   != null) ?cd.exp_hscertno    : "", (cd.exp_hscertdt   != null) ? cd.exp_hscertdt   : "", (cd.exp_contact1   != null) ? cd.exp_contact1   : "", (cd.exp_cont1email   != null) ?cd.exp_cont1email    : "", 
                (cd.exp_contact2   != null) ? cd.exp_contact2   : "", (cd.exp_cont2email   != null) ?cd.exp_cont2email    : "", (cd.exp_contact3   != null) ?cd.exp_contact3    : "", 
                (cd.exp_cont3email   != null) ?cd.exp_cont3email    : "", (cd.exp_contact4   != null) ?cd.exp_contact4    : "", (cd.exp_cont4email   != null) ?cd.exp_cont4email    : "", (cd.exp_typea   != null) ?  cd.exp_typea  : "", 
                (cd.exp_typeb   != null) ? cd.exp_typeb   : "", (cd.exp_expthouse   != null) ? cd.exp_expthouse   : "", (cd.exp_certvaliddt   != null) ?cd.exp_certvaliddt    : "", 
                (cd.exp_state   != null) ? cd.exp_state  : "", (cd.exp_telno1   != null) ? cd.exp_telno1   : "", (cd.exp_faxno1   != null) ? cd.exp_faxno1   : "",(cd.exp_telno2  != null) ?  cd.exp_telno2  : "", 
                (cd.exp_faxno2  != null) ? cd.exp_faxno2    : "", (cd.exp_telno3   != null) ? cd.exp_telno3   : "", (cd.exp_faxno3   != null) ? cd.exp_faxno3   : "", (cd.exp_telno4   != null) ? cd.exp_telno4   : "", 
                (cd.exp_faxno4  != null) ?  cd.exp_faxno4  : "", (cd.exp_ieccode  != null) ?  cd.exp_ieccode   : "", (cd.exp_acctno   != null) ? cd.exp_acctno   : "", (cd.exp_bankaddr1  != null) ? cd.exp_bankaddr1   : "", 
                (cd.exp_bankaddr2  != null) ?cd.exp_bankaddr2    : "", (cd.exp_acctno1   != null) ? cd.exp_acctno1   : "", (cd.exp_delarcode   != null) ? cd.exp_delarcode   : "", 
                (cd.exp_rbiwaiverno   != null) ? cd.exp_rbiwaiverno   : "", (cd.exp_title  != null) ? cd.exp_title   : "", (cd.exp_title1   != null) ?cd.exp_title1    : "", 
                (cd.exp_title2   != null) ?cd.exp_title2   : "", (cd.exp_title3   != null) ?cd.exp_title3  : "", (cd.exp_title4   != null) ?cd.exp_title4    : "", 
                (cd.exp_designation1   != null) ?cd.exp_designation1    : "", (cd.exp_designation2   != null) ?cd.exp_designation2    : "", (cd.exp_designation3  != null) ? cd.exp_designation3   : "", 
                (cd.exp_designation4   != null) ?cd.exp_designation4    : "", (cd.exp_commrate  != null) ?cd.exp_commrate    : "", (cd.exp_division   != null) ? cd.exp_division   : "", 
                (cd.exp_range   != null) ?cd.exp_range    : "", (cd.exp_ItcGroupcode   != null) ?  cd.exp_ItcGroupcode  : "", (cd.exp_mobile1   != null) ?cd.exp_mobile1    : "", 
                (cd.exp_mobile2   != null) ? cd.exp_mobile2   : "", (cd.exp_mobile3  != null) ? cd.exp_mobile3  : "", (cd.exp_mobile4  != null) ? cd.exp_mobile4   : "", 
                (cd.con_code   != null) ?  cd.con_code  : "", (cd.exporterin   != null) ? cd.exporterin   : "", (cd.importerin   != null) ? cd.importerin   : "", 
                (cd.exporterfr   != null) ? cd.exporterfr   : "", (cd.importerfr  != null) ? cd.importerfr   : "" , (cd.exporter   != null) ? cd.exporter   : "", 
                (cd.importer  != null) ? cd.importer   : "", (cd.srcagent   != null) ?cd.srcagent   : "", (cd.consignee  != null) ? cd.consignee   : "", 
                (cd.exp_panno  != null) ?  cd.exp_panno  : "",  (cd.exp_servicetax   != null) ? cd.exp_servicetax   : "", 			
                cd.MakerIP, cd.cmpid, cd.cmp_code, cd.citycode, cd.RequestMode, (cd.exp_EORINUMBER   != null) ?cd.exp_EORINUMBER    : "", 
                (cd.TANNO != null) ? cd.TANNO   : "",(cd.EXP_GSTNO != null) ? cd.EXP_GSTNO   : "", (cd.EXP_GSTARNNO   != null) ?cd.EXP_GSTARNNO    : "",
                (cd.EXP_GSTtitle != null) ?    cd.EXP_GSTtitle  : "", (cd.TANNO != null) ? cd.TANNO   : "", (cd.Exp_GSTtelno != null) ? cd.Exp_GSTtelno   : "" ,  
                (cd.EXP_GSTMobno != null) ? cd.EXP_GSTMobno   : "" ,  (cd.EXP_GSTcontemail != null) ? cd.EXP_GSTcontemail   : "",  cd.VGUID);
                   /// cd.id, cd.exp_sname, cd.exp_name, cd.exp_add1, cd.exp_add2, cd.exp_add3, cd.exp_pincode, cd.exp_pinposition, cd.exp_city, cd.exp_country, cd.exp_invadd1, cd.exp_invadd2, cd.exp_invadd3, cd.exp_invpincode, cd.exp_invpinposition, cd.exp_invcity, cd.exp_invcountry, cd.exp_telno, cd.exp_faxno, cd.exp_telex, cd.exp_email, cd.exp_rbicode, cd.exp_imno, cd.exp_itno, cd.exp_bank, cd.exp_custpno, cd.exp_hscertno, cd.exp_hscertdt, cd.exp_contact1, cd.exp_cont1email, cd.exp_contact2, cd.exp_cont2email, cd.exp_contact3, cd.exp_cont3email, cd.exp_contact4, cd.exp_cont4email, cd.exp_typea, cd.exp_typeb, cd.exp_expthouse, cd.exp_certvaliddt, cd.exp_state, cd.exp_telno1, cd.exp_faxno1, cd.exp_telno2, cd.exp_faxno2, cd.exp_telno3, cd.exp_faxno3, cd.exp_telno4, cd.exp_faxno4, cd.exp_ieccode, cd.exp_acctno, cd.exp_bankaddr1, cd.exp_bankaddr2, cd.exp_acctno1, cd.exp_delarcode, cd.exp_rbiwaiverno, cd.exp_title, cd.exp_title1, cd.exp_title2, cd.exp_title3, cd.exp_title4, cd.exp_designation1, cd.exp_designation2, cd.exp_designation3, cd.exp_designation4, cd.exp_commrate, cd.exp_division, cd.exp_range, cd.exp_ItcGroupcode, cd.exp_mobile1, cd.exp_mobile2, cd.exp_mobile3, cd.exp_mobile4, cd.con_code, cd.exporterin, cd.importerin, cd.exporterfr, cd.importerfr, cd.exporter, cd.importer, cd.srcagent, cd.consignee, cd.exp_panno, cd.exp_servicetax, cd.MakerIP, cd.cmpid, cd.cmp_code, cd.citycode, cd.RequestMode, cd.exp_EORINUMBER, cd.TANNO, cd.EXP_GSTNO, cd.EXP_GSTARNNO, cd.EXP_GSTtitle, cd.Exp_GSTcontP, cd.Exp_GSTtelno, cd.EXP_GSTMobno, cd.EXP_GSTcontemail, cd.VGUID);
                var expcode =   ds.Tables[0].Rows[0]["EXPCODE"].ToString();
                UploadFilesMovetoEdoc(expcode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/exporter_Main_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
       */
        /// <summary>Insert or update an exporter/client master record.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]        
        public IHttpActionResult Exporter_Main_IU([FromBody]ExpoterMain cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_EXPORTER_IU",
                cd.id, (cd.exp_sname != null) ? cd.exp_sname : "", cd.exp_name, (cd.exp_add1 != null) ? cd.exp_add1 : "", (cd.exp_add2 != null) ? cd.exp_add2 : "", (cd.exp_add3 != null) ? cd.exp_add3 : "",
                (cd.exp_pincode != null) ? cd.exp_pincode : "", (cd.exp_pinposition != null) ? cd.exp_pinposition : "", (cd.exp_city != null) ? cd.exp_city : "", (cd.exp_country != null) ? cd.exp_country : "",
                (cd.exp_invadd1 != null) ? cd.exp_invadd1 : "", (cd.exp_invadd2 != null) ? cd.exp_invadd2 : "", (cd.exp_invadd3 != null) ? cd.exp_invadd3 : "", (cd.exp_invpincode != null) ? cd.exp_invpincode : "",
                (cd.exp_invpinposition != null) ? cd.exp_invpinposition : "", (cd.exp_invcity != null) ? cd.exp_invcity : "", (cd.exp_invcountry != null) ? cd.exp_invcountry : "", (cd.exp_telno != null) ? cd.exp_telno : "",
                (cd.exp_faxno != null) ? cd.exp_faxno : "", (cd.exp_telex != null) ? cd.exp_telex : "", (cd.exp_email != null) ? cd.exp_email : "", (cd.exp_rbicode != null) ? cd.exp_rbicode : "",
                (cd.exp_imno != null) ? cd.exp_imno : "", (cd.exp_itno != null) ? cd.exp_itno : "", (cd.exp_bank != null) ? cd.exp_bank : "", (cd.exp_custpno != null) ? cd.exp_custpno : "",
                (cd.exp_hscertno != null) ? cd.exp_hscertno : "", (cd.exp_hscertdt != null) ? cd.exp_hscertdt : "", (cd.exp_contact1 != null) ? cd.exp_contact1 : "", (cd.exp_cont1email != null) ? cd.exp_cont1email : "",
                (cd.exp_contact2 != null) ? cd.exp_contact2 : "", (cd.exp_cont2email != null) ? cd.exp_cont2email : "", (cd.exp_contact3 != null) ? cd.exp_contact3 : "",
                (cd.exp_cont3email != null) ? cd.exp_cont3email : "", (cd.exp_contact4 != null) ? cd.exp_contact4 : "", (cd.exp_cont4email != null) ? cd.exp_cont4email : "", (cd.exp_typea != null) ? cd.exp_typea : "",
                (cd.exp_typeb != null) ? cd.exp_typeb : "", (cd.exp_expthouse != null) ? cd.exp_expthouse : "", (cd.exp_certvaliddt != null) ? cd.exp_certvaliddt : "",
                (cd.exp_state != null) ? cd.exp_state : "", (cd.exp_telno1 != null) ? cd.exp_telno1 : "", (cd.exp_faxno1 != null) ? cd.exp_faxno1 : "", (cd.exp_telno2 != null) ? cd.exp_telno2 : "",
                (cd.exp_faxno2 != null) ? cd.exp_faxno2 : "", (cd.exp_telno3 != null) ? cd.exp_telno3 : "", (cd.exp_faxno3 != null) ? cd.exp_faxno3 : "", (cd.exp_telno4 != null) ? cd.exp_telno4 : "",
                (cd.exp_faxno4 != null) ? cd.exp_faxno4 : "", (cd.exp_ieccode != null) ? cd.exp_ieccode : "", (cd.exp_acctno != null) ? cd.exp_acctno : "", (cd.exp_bankaddr1 != null) ? cd.exp_bankaddr1 : "",
                (cd.exp_bankaddr2 != null) ? cd.exp_bankaddr2 : "", (cd.exp_acctno1 != null) ? cd.exp_acctno1 : "", (cd.exp_delarcode != null) ? cd.exp_delarcode : "",
                (cd.exp_rbiwaiverno != null) ? cd.exp_rbiwaiverno : "", (cd.exp_title != null) ? cd.exp_title : "", (cd.exp_title1 != null) ? cd.exp_title1 : "",
                (cd.exp_title2 != null) ? cd.exp_title2 : "", (cd.exp_title3 != null) ? cd.exp_title3 : "", (cd.exp_title4 != null) ? cd.exp_title4 : "",
                (cd.exp_designation1 != null) ? cd.exp_designation1 : "", (cd.exp_designation2 != null) ? cd.exp_designation2 : "", (cd.exp_designation3 != null) ? cd.exp_designation3 : "",
                (cd.exp_designation4 != null) ? cd.exp_designation4 : "", (cd.exp_commrate != null) ? cd.exp_commrate : "", (cd.exp_division != null) ? cd.exp_division : "",
                (cd.exp_range != null) ? cd.exp_range : "", (cd.exp_ItcGroupcode != null) ? cd.exp_ItcGroupcode : "", (cd.exp_mobile1 != null) ? cd.exp_mobile1 : "",
                (cd.exp_mobile2 != null) ? cd.exp_mobile2 : "", (cd.exp_mobile3 != null) ? cd.exp_mobile3 : "", (cd.exp_mobile4 != null) ? cd.exp_mobile4 : "",
                (cd.con_code != null) ? cd.con_code : "", (cd.exporterin != null) ? cd.exporterin : "", (cd.importerin != null) ? cd.importerin : "",
                (cd.exporterfr != null) ? cd.exporterfr : "", (cd.importerfr != null) ? cd.importerfr : "", (cd.exporter != null) ? cd.exporter : "",
                (cd.importer != null) ? cd.importer : "", (cd.srcagent != null) ? cd.srcagent : "", (cd.consignee != null) ? cd.consignee : "",
                (cd.exp_panno != null) ? cd.exp_panno : "", (cd.exp_servicetax != null) ? cd.exp_servicetax : "",
                cd.MakerIP, cd.cmpid, cd.cmp_code, cd.citycode, cd.RequestMode, (cd.exp_EORINUMBER != null) ? cd.exp_EORINUMBER : "",
                (cd.TANNO != null) ? cd.TANNO : "", 
                (cd.EXP_GSTNO != null) ? cd.EXP_GSTNO : "", 
                (cd.EXP_GSTARNNO != null) ? cd.EXP_GSTARNNO : "",
                (cd.EXP_GSTtitle != null) ? cd.EXP_GSTtitle : "",
                (cd.Exp_GSTcontP != null) ? cd.Exp_GSTcontP : "",
                (cd.Exp_GSTtelno != null) ? cd.Exp_GSTtelno : "",
                (cd.EXP_GSTMobno != null) ? cd.EXP_GSTMobno : "", 
                (cd.EXP_GSTcontemail != null) ? cd.EXP_GSTcontemail : "", cd.VGUID,
                (cd.ISSEZCLIENT != null) ? cd.ISSEZCLIENT : "", (cd.SIRENNO != null) ? cd.SIRENNO : "",
                (cd.CREDITPERIOD_SEA != null) ? cd.CREDITPERIOD_SEA : "", (cd.CREDITPERIOD_AIR != null) ? cd.CREDITPERIOD_AIR : "", (cd.ISOVERSEASAGENT != null) ? cd.ISOVERSEASAGENT : "0");
                /// cd.id, cd.exp_sname, cd.exp_name, cd.exp_add1, cd.exp_add2, cd.exp_add3, cd.exp_pincode, cd.exp_pinposition, cd.exp_city, cd.exp_country, cd.exp_invadd1, cd.exp_invadd2, cd.exp_invadd3, cd.exp_invpincode, cd.exp_invpinposition, cd.exp_invcity, cd.exp_invcountry, cd.exp_telno, cd.exp_faxno, cd.exp_telex, cd.exp_email, cd.exp_rbicode, cd.exp_imno, cd.exp_itno, cd.exp_bank, cd.exp_custpno, cd.exp_hscertno, cd.exp_hscertdt, cd.exp_contact1, cd.exp_cont1email, cd.exp_contact2, cd.exp_cont2email, cd.exp_contact3, cd.exp_cont3email, cd.exp_contact4, cd.exp_cont4email, cd.exp_typea, cd.exp_typeb, cd.exp_expthouse, cd.exp_certvaliddt, cd.exp_state, cd.exp_telno1, cd.exp_faxno1, cd.exp_telno2, cd.exp_faxno2, cd.exp_telno3, cd.exp_faxno3, cd.exp_telno4, cd.exp_faxno4, cd.exp_ieccode, cd.exp_acctno, cd.exp_bankaddr1, cd.exp_bankaddr2, cd.exp_acctno1, cd.exp_delarcode, cd.exp_rbiwaiverno, cd.exp_title, cd.exp_title1, cd.exp_title2, cd.exp_title3, cd.exp_title4, cd.exp_designation1, cd.exp_designation2, cd.exp_designation3, cd.exp_designation4, cd.exp_commrate, cd.exp_division, cd.exp_range, cd.exp_ItcGroupcode, cd.exp_mobile1, cd.exp_mobile2, cd.exp_mobile3, cd.exp_mobile4, cd.con_code, cd.exporterin, cd.importerin, cd.exporterfr, cd.importerfr, cd.exporter, cd.importer, cd.srcagent, cd.consignee, cd.exp_panno, cd.exp_servicetax, cd.MakerIP, cd.cmpid, cd.cmp_code, cd.citycode, cd.RequestMode, cd.exp_EORINUMBER, cd.TANNO, cd.EXP_GSTNO, cd.EXP_GSTARNNO, cd.EXP_GSTtitle, cd.Exp_GSTcontP, cd.Exp_GSTtelno, cd.EXP_GSTMobno, cd.EXP_GSTcontemail, cd.VGUID);
                if (ds.Tables[0].Rows[0]["STATUS"].ToString() == "100")
                {
                    var expcode = ds.Tables[0].Rows[0]["EXPCODE"].ToString();
                    UploadFilesMovetoEdoc(expcode);
                }
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/exporter_Main_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }


        /// <summary>Upload a file to the server and save it.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult UploadFiles()
        {             
            var uploadedFileNames = new List<string>();
            string result = string.Empty;
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                //httpRequest.Form["cmpid"]
               
                HttpResponseMessage response = new HttpResponseMessage();
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    var postedFile = httpRequest.Files[0];
                    var folderpath =HttpContext.Current.Server.MapPath("~/DATA/Edoc/");
                    var filePath = HttpContext.Current.Server.MapPath("~/DATA/Edoc/" + postedFile.FileName);                    
                    postedFile.SaveAs(filePath);
                    uploadedFileNames.Add(httpRequest.Files[0].FileName);
                    ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_EXPOTER_TMP_UPLOAD_IU", 0, "", httpRequest.Form["DOCTYPE"], postedFile.FileName, "", httpRequest.Form["CMPID"], httpRequest.Form["guid"], folderpath, httpRequest.Form["filesize"], httpRequest.Form["Makerip"]);
                    var imageName = ds.Tables[1].Rows[0]["ACTFILENAME"].ToString();
                    File.Move(filePath, HttpContext.Current.Server.MapPath("~/DATA/Edoc/" +imageName));
                    File.Delete(filePath);
                    
                }
                result =  "files uploaded succesfully";
                
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/UploadFiles");
            }
            return Ok(ds);
        }

        /// <summary>Remove an uploaded document file from the server.</summary>
        /// <param name="PKID">Primary key ID of the record.</param>
        /// <param name="FILENAME">FILENAME parameter.</param>
        /// <param name="CMPID">Primary key of the company.</param>
        /// <param name="GUID">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult RemoveUploadFiles(string PKID,string FILENAME ,string CMPID ,string GUID )
        {            
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                var filePath = HttpContext.Current.Server.MapPath("~/DATA/Edoc/" + FILENAME);
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_EXPOTER_TMP_UPLOAD_DELETE",PKID,CMPID,GUID);
                File.Delete(filePath);
                
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/RemoveUploadFiles");
            }
            return Ok(ds);
        }
          /// <summary>Load dropdown reference data for the master page.</summary>
          /// <param name="CMPID">Primary key of the company.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
        public IHttpActionResult masterpageload(string CMPID )
        {            
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                 
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_EXPOTER_PAGELOAD",CMPID);
                 
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/masterpageload");
            }
            return Ok(ds);
        }
         
          private string  UploadFilesMovetoEdoc( string expotercode )
          {
              var uploadedFileNames = new List<string>();
              WebClient client = new WebClient();

              string result = string.Empty;
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {
                  var sorc_path = ""; var sorc_filename = ""; var dest_path = ""; var dest_filenmae = ""; var filename = "";
                  var sorc_filepath="";var dest_filepath="";
                  //httpRequest.Form["cmpid"]
                 //System.IO.File.Copy(sourceFile, destinationFile);
                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_EXPOTER_UPLOADEDOC", 0, "8", 23, expotercode);
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++){
                        sorc_path = ds.Tables[0].Rows[j]["SORC_UPLOADPATH"].ToString();
                        sorc_filename = ds.Tables[0].Rows[j]["SORC_UPLOADFULLFILENAME"].ToString();
                        sorc_filepath=sorc_path+sorc_filename;
                        dest_path = ds.Tables[0].Rows[j]["DEST_UPLOADPATH"].ToString();
                        dest_filenmae = ds.Tables[0].Rows[j]["DEST_UPLOADFULLFILENAME"].ToString();
                        dest_filepath=dest_filepath ;
                        filename= ds.Tables[0].Rows[j]["FILENAME"].ToString();
                     
                        File.Move(sorc_filepath, HttpContext.Current.Server.MapPath("~/DATA/Edoc/" + filename));
                        var crnt_filename=HttpContext.Current.Server.MapPath("~/DATA/Edoc/" + filename);
                        // F:\Project\Application\eDocument\DATA\CLIENT\EXPORTER
                        //string path = @"\\109.15.43.138\eDocument\DATA\CLIENT\EXPORTER\" + expotercode;
                        string path = "http://109.15.43.138/Exptkyc/";// +expotercode;
                      //  string path = @"\\109.15.43.138\F$\Project\Application\eDocument\\DATA\CLIENT\EXPORTER\" + expotercode;
                      
                       //  DirectoryInfo di = Directory.CreateDirectory(path);
                         client.UploadFile(path + filename, crnt_filename);
                      
                       //  System.IO.File.Copy(crnt_filename, path + filename, true);
                        // File.Copy(crnt_filename, path + "\\" + filename, true);
                        File.Delete(sorc_filepath);
                        //System.IO.File.Copy(crnt_filename, "", true);
                    }
                  
                  result = "files uploaded succesfully";

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/UploadFiles");
              }
              return result;
          }

        /*-------------END--- CONSIGNEE SATRT-------------------*/


          /// <summary>Retrieve the consignee document type list.</summary>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult con_documentList_load()
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_Consignee_LODocuments");

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/con_documentList_load");
              }
              return Ok(ds);
          }
          /// <summary>Insert or update a consignee master record.</summary>
          /// <param name="cd">Request body model containing the record fields.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpPost]
          public IHttpActionResult Consignee_IU([FromBody]consigneemaster cd)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {
                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_Consignee_IU",cd.id, cd.con_sname,  cd.con_name,  cd.con_title, 
                    (cd.con_add1   != null) ?cd.con_add1   :   "",(cd.con_add2   != null) ?cd.con_add2   :   "",(cd.con_add3   != null) ?cd.con_add3   :   "",
                    (cd.con_email   != null) ?cd.con_email   :   "",(cd.con_pincode   != null) ?cd.con_pincode   :   "",(cd.con_pinposition   != null) ?cd.con_pinposition   :   "",
                    (cd.con_city   != null) ?cd.con_city   :   "",(cd.con_country   != null) ?cd.con_country   :   "",(cd.con_telno   != null) ?cd.con_telno   :   "",
                    (cd.con_faxno   != null) ?cd.con_faxno   :   "",(cd.con_title1   != null) ?cd.con_title1   :   "",(cd.con_contact1   != null) ?cd.con_contact1   :   "",
                    (cd.con_designation1   != null) ?cd.con_designation1   :   "",(cd.con_telno1   != null) ?cd.con_telno1   :   "",(cd.con_faxno1   != null) ?cd.con_faxno1   :   "",
                    (cd.con_mobile1   != null) ?cd.con_mobile1   :   "",(cd.con_cont1email   != null) ?cd.con_cont1email   :   "",(cd.con_title2   != null) ?cd.con_title2   :   "",
                    (cd.con_contact2   != null) ?cd.con_contact2   :   "",(cd.con_designation2   != null) ?cd.con_designation2   :   "",(cd.con_telno2   != null) ?cd.con_telno2   :   "",
                    (cd.con_faxno2   != null) ?cd.con_faxno2   :   "",(cd.con_mobile2   != null) ?cd.con_mobile2   :   "",(cd.con_cont2email   != null) ?cd.con_cont2email   :   "",
                    (cd.con_title3   != null) ?cd.con_title3   :   "",(cd.con_contact3   != null) ?cd.con_contact3   :   "",(cd.con_designation3   != null) ?cd.con_designation3   :   "",
                    (cd.con_telno3   != null) ?cd.con_telno3   :   "",(cd.con_faxno3   != null) ?cd.con_faxno3   :   "",(cd.con_mobile3   != null) ?cd.con_mobile3   :   "",
                    (cd.con_cont3email   != null) ?cd.con_cont3email   :   "",(cd.con_title4   != null) ?cd.con_title4   :   "",(cd.con_contact4   != null) ?cd.con_contact4   :   "",
                    (cd.con_designation4   != null) ?cd.con_designation4   :   "",(cd.con_telno4   != null) ?cd.con_telno4   :   "",(cd.con_faxno4   != null) ?cd.con_faxno4   :   "",
                    (cd.con_mobile4   != null) ?cd.con_mobile4   :   "",(cd.con_cont4email   != null) ?cd.con_cont4email   :   "",(cd.con_approval   != null) ?cd.con_approval   :   "",
                    (cd.con_sourceagt   != null) ?cd.con_sourceagt   :   "N",(cd.con_doccode   != null) ?cd.con_doccode   :   "",(cd.con_cneefrance   != null) ?cd.con_cneefrance   :   "N",
                    (cd.con_cneeothers   != null) ?cd.con_cneeothers   :   "N", cd.MakerID , cd.MakerIP ,
                    cd.cmp_code,cd.citycode ,(cd.RequestMode != null) ?cd.RequestMode :   "",
                    (cd.con_EORINUMBER != null) ?cd.con_EORINUMBER :   "", (cd.IsSytiyaclient != null) ?cd.IsSytiyaclient :   "N", (cd.SIRENNO != null) ? cd.SIRENNO : "");
              }
              catch (Exception ex)
              {
                  ds = ErrorLog.Error(ex, "Master/Consignee_IU");
              }
              finally
              {
                  objDal.Dispose();

              }
              return Ok(ds);
          }//

          /// <summary>Populate the consignee form with existing record data.</summary>
          /// <param name="concode">concode parameter.</param>
          /// <param name="RequestMode">Operation mode or filter type.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult consignee_populate(string concode, string RequestMode)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_Consignee_Populate", concode, (RequestMode != null) ? RequestMode : "");

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/consignee_populate");
              }
              return Ok(ds);
          }
          /// <summary>Fill consignee details to add as an exporter record.</summary>
          /// <param name="concode">concode parameter.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Fill_Consg_Details_AddAs_Expoter(string concode)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_EXPORTER_FILLCONSG", concode);

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Fill_Consg_Details_AddAs_Expoter");
              }
              return Ok(ds);
          }
          /// <summary>Common master search across exporters, consignees, suppliers, and agents.</summary>
          /// <param name="rqPage">rq Page parameter.</param>
          /// <param name="strSearchTxt">str Search Txt parameter.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Master_Search_common(string rqPage, string strSearchTxt)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_SEARCH_COMMON_NEW", rqPage, strSearchTxt);

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Master_Search_common");
              }
              return Ok(ds);
          } //
          /// <summary>Delete an exporter request list entry.</summary>
          /// <param name="strSearchTxt">str Search Txt parameter.</param>
          /// <param name="makerid">User code of the record maker.</param>
          /// <param name="makerip">IP address of the record maker.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Master_REQLIST_DELETE(string strSearchTxt,string makerid,string makerip)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_EXPORTER_REQLIST_DELETE", strSearchTxt,makerid,makerip);

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Master_REQLIST_DELETE");
              }
              return Ok(ds);
          }

        //SUPPLIER MASTER START HERE 


          /// <summary>Insert or update a supplier address child record.</summary>
          /// <param name="cd">Request body model containing the record fields.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpPost]
          public IHttpActionResult SUPPLIER_CHILD_IU([FromBody]supplierchild cd)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {
                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_SUP_MSTCHILDADD_IU", cd.Pk_SupAdd_Id, cd.fksup_code,
                    (cd.sup_add1 != null) ? cd.sup_add1 : "", (cd.sup_add2 != null) ? cd.sup_add2 : "", (cd.sup_add3 != null) ? cd.sup_add3 : "",
                    (cd.sup_pincode != null) ? cd.sup_pincode : "", (cd.sup_position != null) ? cd.sup_position : "",
                    (cd.sup_city != null) ? cd.sup_city : "", (cd.TelNo != null) ? cd.TelNo : "", (cd.FaxNo != null) ? cd.FaxNo : "",
                    (cd.sup_GSTNO != null) ? cd.sup_GSTNO : "", (cd.sup_GSTARNNO != null) ? cd.sup_GSTARNNO : "", (cd.sup_GSTcontP != null) ? cd.sup_GSTcontP : "", (cd.sup_GSTtelno != null) ? cd.sup_GSTtelno : "",
                    (cd.sup_GSTMobno != null) ? cd.sup_GSTMobno : "", (cd.sup_GSTcontemail != null) ? cd.sup_GSTcontemail : "", (cd.sup_GSTtitle != null) ? cd.sup_GSTtitle : "",
                    cd.vguid, cd.MakerID, cd.MakerIP, cd.maineSupid, (cd.reqmode != null) ? cd.reqmode : "", cd.IS_Gst_Reg);
                    
              }
              catch (Exception ex)
              {
                  ds = ErrorLog.Error(ex, "Master/SUPPLIER_CHILD_IU");
              }
              finally
              {
                  objDal.Dispose();

              }
              return Ok(ds);
          }
        /// <summary>Insert or update a supplier TDS detail child record.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult SUPPLIER_CHILD_TDS_IU([FromBody]supplierchildTDS cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL(); 
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_SUP_MSTCHILD_TDS_DET_IU",cd.PKID, cd.SUP_CODE, cd.SECTIONID, cd.PER_RATE, cd.FRMDT, cd.TODT, cd.TDS_LIMIT_AMT, cd.TDS_TYPE, cd.MAKERID , cd.MAKERIP,cd.VGUID,cd.MODEOFENTRY, cd.LDCRATE);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/SUPPLIER_CHILD_TDS_IU");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update a supplier master record.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
          public IHttpActionResult SUPPLIER_MASTER_IU([FromBody]suppliermaster cd)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {
                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_Supplier_IU", cd.id, cd.sup_sname, cd.sup_name,
                  (cd.sup_title != null) ? cd.sup_title : "",(cd.sup_add1 != null) ? cd.sup_add1 : "",(cd.sup_add2 != null) ? cd.sup_add2 : "",(cd.sup_add3 != null) ? cd.sup_add3 : "",
                  (cd.sup_email != null) ? cd.sup_email : "",(cd.sup_pincode != null) ? cd.sup_pincode : "",(cd.sup_pinposition != null) ? cd.sup_pinposition : "",(cd.sup_city != null) ? cd.sup_city : "",
                  (cd.sup_country != null) ? cd.sup_country : "",(cd.sup_telno != null) ? cd.sup_telno : "",(cd.sup_faxno != null) ? cd.sup_faxno : "",(cd.sup_title1 != null) ? cd.sup_title1 : "",
                  (cd.sup_contact1 != null) ? cd.sup_contact1 : "",(cd.sup_designation1 != null) ? cd.sup_designation1 : "",(cd.sup_telno1 != null) ? cd.sup_telno1 : "",(cd.sup_faxno1 != null) ? cd.sup_faxno1 : "",
                  (cd.sup_mobile1 != null) ? cd.sup_mobile1 : "",(cd.sup_cont1email != null) ? cd.sup_cont1email : "",(cd.sup_title2 != null) ? cd.sup_title2 : "",(cd.sup_contact2 != null) ? cd.sup_contact2 : "",
                  (cd.sup_designation2 != null) ? cd.sup_designation2 : "",(cd.sup_telno2 != null) ? cd.sup_telno2 : "",(cd.sup_faxno2 != null) ? cd.sup_faxno2 : "",(cd.sup_mobile2 != null) ? cd.sup_mobile2 : "",
                  (cd.sup_cont2email != null) ? cd.sup_cont2email : "",(cd.sup_title3 != null) ? cd.sup_title3 : "",(cd.sup_contact3 != null) ? cd.sup_contact3 : "",(cd.sup_designation3 != null) ? cd.sup_designation3 : "",
                  (cd.sup_telno3 != null) ? cd.sup_telno3 : "",   (cd.sup_faxno3 != null) ? cd.sup_faxno3 : "",(cd.sup_mobile3 != null) ? cd.sup_mobile3 : "",(cd.sup_cont3email != null) ? cd.sup_cont3email : "",
                  (cd.sup_title4 != null) ? cd.sup_title4 : "",(cd.sup_contact4 != null) ? cd.sup_contact4 : "",(cd.sup_designation4 != null) ? cd.sup_designation4 : "",(cd.sup_telno4 != null) ? cd.sup_telno4 : "",
                  (cd.sup_faxno4 != null) ? cd.sup_faxno4 : "",(cd.sup_mobile4 != null) ? cd.sup_mobile4 : "",(cd.sup_cont4email != null) ? cd.sup_cont4email : "",(cd.airline != null) ? cd.airline : "",
                  (cd.airlineagent != null) ? cd.airlineagent : "",(cd.shippingline != null) ? cd.shippingline : "",(cd.warehouse != null) ? cd.warehouse : "",(cd.transporter != null) ? cd.transporter : "",
                  (cd.agent != null) ? cd.agent : "",(cd.fwarehouse != null) ? cd.fwarehouse : "",(cd.others != null) ? cd.others : "",(cd.sup_airlinecode != null) ? cd.sup_airlinecode : "",
                  (cd.agentcity != null) ? cd.agentcity : "",(cd.city != null) ? cd.city : "",(cd.sup_panno != null) ? cd.sup_panno : "",(cd.sup_servicetax != null) ? cd.sup_servicetax : "",
                  cd.cmpid, cd.MakerIP, cd.cmp_code, cd.citycode,(cd.RequestMode != null) ? cd.RequestMode : "",(cd.sup_EORINUMBER != null) ? cd.sup_EORINUMBER : "",(cd.Sup_TANNO != null) ? cd.Sup_TANNO : "",
                  (cd.sup_GSTNO != null) ? cd.sup_GSTNO : "",(cd.sup_GSTARNNO != null) ? cd.sup_GSTARNNO : "",(cd.sup_GSTtitle != null) ? cd.sup_GSTtitle : "",(cd.sup_GSTcontP != null) ? cd.sup_GSTcontP : "",
                  (cd.sup_GSTtelno != null) ? cd.sup_GSTtelno : "",(cd.sup_GSTMobno != null) ? cd.sup_GSTMobno : "",(cd.sup_GSTcontemail != null) ? cd.sup_GSTcontemail : "",cd.vguid ,(cd.IS_TDS != null)?  cd.IS_TDS :"");

              }
              catch (Exception ex)
              {
                  ds = ErrorLog.Error(ex, "Master/SUPPLIER_MASTER_IU");
              }
              finally
              {
                  objDal.Dispose();

              }
              return Ok(ds);
          }

          /// <summary>Populate the supplier form with existing record data.</summary>
          /// <param name="fkSup_code">fk Sup code parameter.</param>
          /// <param name="RequestMode">Operation mode or filter type.</param>
          /// <param name="makerid">User code of the record maker.</param>
          /// <param name="vguid">Session GUID for temporary record management.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Master_supplier_Populate(string fkSup_code, string RequestMode,string  makerid, string vguid)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {
                
                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_Supplier_Populate", fkSup_code, (RequestMode != null) ? RequestMode : "",makerid,vguid);

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Master_supplier_Populate");
              }
              return Ok(ds);
          }

          /// <summary>Load dropdown reference data for the supplier master page.</summary>
          /// <param name="CMPID">Primary key of the company.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Supplierpageload(string CMPID)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_SUPPLIER_PAGELOAD", CMPID);

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Supplierpageload");
              }
              return Ok(ds);
          }

          /// <summary>Delete a consignee request list entry.</summary>
          /// <param name="strSearchTxt">str Search Txt parameter.</param>
          /// <param name="makerid">User code of the record maker.</param>
          /// <param name="makerip">IP address of the record maker.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Master_REQLIST_DELETE_consignee(string strSearchTxt, string makerid, string makerip)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_CONSIGNEE_REQLIST_DELETE", strSearchTxt, makerid, makerip);

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Master_REQLIST_DELETE_consignee");
              }
              return Ok(ds);
          }
          /// <summary>Delete a supplier request list entry.</summary>
          /// <param name="strSearchTxt">str Search Txt parameter.</param>
          /// <param name="makerid">User code of the record maker.</param>
          /// <param name="makerip">IP address of the record maker.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Master_REQLIST_DELETE_Supplier(string strSearchTxt, string makerid, string makerip)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_SUPPLIER_REQLIST_DELETE", strSearchTxt, makerid, makerip);

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Master_REQLIST_DELETE_Supplier");
              }
              return Ok(ds);
          }

          /// <summary>Delete an agent request list entry.</summary>
          /// <param name="strSearchTxt">str Search Txt parameter.</param>
          /// <param name="makerid">User code of the record maker.</param>
          /// <param name="makerip">IP address of the record maker.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Master_REQLIST_DELETE_Agent(string strSearchTxt, string makerid, string makerip)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_AGENT_REQLIST_DELETE", strSearchTxt, makerid, makerip);

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Master_REQLIST_DELETE_Agent");
              }
              return Ok(ds);
          }
          /// <summary>Delete a liner request list entry.</summary>
          /// <param name="strSearchTxt">str Search Txt parameter.</param>
          /// <param name="makerid">User code of the record maker.</param>
          /// <param name="makerip">IP address of the record maker.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Master_REQLIST_DELETE_Liner(string strSearchTxt, string makerid, string makerip)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_LINER_REQLIST_DELETE", strSearchTxt, makerid, makerip);

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Master_REQLIST_DELETE_Liner");
              }
              return Ok(ds);
          }

          ///// Vessel agent  

          /// <summary>Retrieve the liner list for vessel agent dropdown population.</summary>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult AgentFill()
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_AgentVessel_FillLiners");

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/AgentFill");
              }
              return Ok(ds);
          }

          /// <summary>Populate the vessel agent form with existing record data.</summary>
          /// <param name="fkAgt_code">fk Agt code parameter.</param>
          /// <param name="RequestMode">Operation mode or filter type.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Master_VesselAgent_Populate(string fkAgt_code, string RequestMode)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_AgentVessel_Populate", fkAgt_code, (RequestMode != null) ? RequestMode : "");

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Master_supplier_Populate");
              }
              return Ok(ds);
          }

        //


          /// <summary>Insert or update a vessel agent master record.</summary>
          /// <param name="cd">Request body model containing the record fields.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpPost]
          public IHttpActionResult Vessel_Agent_MASTER_IU([FromBody]VesselAgent cd)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {
                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_AgentVessel_IU", (cd.id != null) ? cd.id : "",
                        (cd.agt_sname != null) ? cd.agt_sname : "",(cd.agt_name != null) ? cd.agt_name : "",(cd.agt_title != null) ? cd.agt_title : "",(cd.agt_add1 != null) ? cd.agt_add1 : "",(cd.agt_add2 != null) ? cd.agt_add2 : "",(cd.agt_add3 != null) ? cd.agt_add3 : "",
                        (cd.agt_email != null) ? cd.agt_email : "",(cd.agt_pincode != null) ? cd.agt_pincode : "",(cd.agt_pinposition != null) ? cd.agt_pinposition : "",(cd.agt_city != null) ? cd.agt_city : "",
                        (cd.agt_country != null) ? cd.agt_country : "",(cd.agt_telno != null) ? cd.agt_telno : "",
                        (cd.agt_faxno != null) ? cd.agt_faxno : "",(cd.agt_title1 != null) ? cd.agt_title1 : "",(cd.agt_contact1 != null) ? cd.agt_contact1 : "",
                        (cd.agt_designation1 != null) ? cd.agt_designation1 : "",(cd.agt_telno1 != null) ? cd.agt_telno1 : "",(cd.agt_faxno1 != null) ? cd.agt_faxno1 : "",
                        (cd.agt_mobile1 != null) ? cd.agt_mobile1 : "",(cd.agt_cont1email != null) ? cd.agt_cont1email : "",(cd.agt_title2 != null) ? cd.agt_title2 : "",
                        (cd.agt_contact2 != null) ? cd.agt_contact2 : "",(cd.agt_designation2 != null) ? cd.agt_designation2 : "",
                        (cd.agt_telno2 != null) ? cd.agt_telno2 : "",(cd.agt_faxno2 != null) ? cd.agt_faxno2 : "",(cd.agt_mobile2 != null) ? cd.agt_mobile2 : "",
                        (cd.agt_cont2email != null) ? cd.agt_cont2email : "",(cd.agt_title3 != null) ? cd.agt_title3 : "",(cd.agt_contact3 != null) ? cd.agt_contact3 : "",
                        (cd.agt_designation3 != null) ? cd.agt_designation3 : "",(cd.agt_telno3 != null) ? cd.agt_telno3 : "",(cd.agt_faxno3 != null) ? cd.agt_faxno3 : "",
                        (cd.agt_mobile3 != null) ? cd.agt_mobile3 : "",(cd.agt_cont3email != null) ? cd.agt_cont3email : "",(cd.agt_title4 != null) ? cd.agt_title4 : "",
                        (cd.agt_contact4 != null) ? cd.agt_contact4 : "",(cd.agt_designation4 != null) ? cd.agt_designation4 : "",(cd.agt_telno4 != null) ? cd.agt_telno4 : "",
                        (cd.agt_faxno4 != null) ? cd.agt_faxno4 : "",(cd.agt_mobile4 != null) ? cd.agt_mobile4 : "",(cd.agt_cont4email != null) ? cd.agt_cont4email : "",
                        (cd.agt_liner1 != null) ? cd.agt_liner1 : "",(cd.agt_liner2 != null) ? cd.agt_liner2 : "",(cd.agt_liner3 != null) ? cd.agt_liner3 : "",
                        (cd.agt_liner4 != null) ? cd.agt_liner4 : "", (cd.agt_panno != null) ? cd.agt_panno : "", cd.MakerID, cd.MakerIP, cd.cmp_code, cd.citycode, (cd.RequestMode != null) ? cd.RequestMode : "");

              }
              catch (Exception ex)
              {
                  ds = ErrorLog.Error(ex, "Master/Vessel_Agent_MASTER_IU");
              }
              finally
              {
                  objDal.Dispose();

              }
              return Ok(ds);
          }
        //liner 
          /// <summary>Insert or update a shipping liner master record.</summary>
          /// <param name="cd">Request body model containing the record fields.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpPost]
          public IHttpActionResult Shiping_liner_IU([FromBody]Linermaster cd)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {
                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_LINER_IU",  (cd.id!=null) ? cd.id:"",
                     (cd.liner_sname !=null) ? cd.liner_sname :"",(cd.liner_name !=null) ? cd.liner_name :"",(cd.liner_add1 !=null) ? cd.liner_add1 :"",
                     (cd.liner_add2 !=null) ? cd.liner_add2 :"",(cd.liner_add3 !=null) ? cd.liner_add3 :"",(cd.liner_pincode !=null) ? cd.liner_pincode :"",
                     (cd.liner_pinposition !=null) ? cd.liner_pinposition :"",
                     (cd.liner_city !=null) ? cd.liner_city :"",(cd.liner_country !=null) ? cd.liner_country :"",(cd.liner_telno !=null) ? cd.liner_telno :"",
                     (cd.liner_faxno != null) ? cd.liner_faxno : "", (cd.liner_email != null) ? cd.liner_email : "", cd.MakerIP,
                     cd.MakerID, cd.cmp_code, cd.citycode, (cd.RequestMode != null) ? cd.RequestMode : "");
              }
              catch (Exception ex)
              {
                  ds = ErrorLog.Error(ex, "Master/Shiping_liner_IU");
              }
              finally
              {
                  objDal.Dispose();

              }
              return Ok(ds);
          }
          /// <summary>Populate the liner form with existing record data.</summary>
          /// <param name="fkliner_code">fkliner code parameter.</param>
          /// <param name="RequestMode">Operation mode or filter type.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Master_Liner_Populate(string fkliner_code, string RequestMode)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_FILL_LINER_DET", fkliner_code, (RequestMode != null) ? RequestMode : "");

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Master_Liner_Populate");
              }
              return Ok(ds);
          }

        // CONSIGNEE BANK
          /// <summary>Insert or update a consignee bank master record.</summary>
          /// <param name="cd">Request body model containing the record fields.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpPost]
          public IHttpActionResult Consignee_bank_IU([FromBody]Bank_master cd)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {
                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_CONSGBANK_IU", (cd.id != null) ? cd.id : "",
                    (cd.bank_sname != null) ? cd.bank_sname : "", (cd.bank_name != null) ? cd.bank_name : "", (cd.bank_add1 != null) ? cd.bank_add1 : "",
                    (cd.bank_add2 != null) ? cd.bank_add2 : "", (cd.bank_add3 != null) ? cd.bank_add3 : "", (cd.bank_pincode != null) ? cd.bank_pincode : "", (cd.bank_pinposition != null) ? cd.bank_pinposition : "",
                    (cd.bank_city != null) ? cd.bank_city : "", (cd.bank_country != null) ? cd.bank_country : "", (cd.bank_telno != null) ? cd.bank_telno : "",
                    (cd.bank_faxno != null) ? cd.bank_faxno : "", (cd.bank_telex != null) ? cd.bank_telex : "", (cd.bank_email != null) ? cd.bank_email : "",
                    (cd.bank_contact1 != null) ? cd.bank_contact1 : "", (cd.bank_cont1email != null) ? cd.bank_cont1email : "", (cd.bank_contact2 != null) ? cd.bank_contact2 : "",
                    (cd.bank_cont2email != null) ? cd.bank_cont2email : "", (cd.bank_contact3 != null) ? cd.bank_contact3 : "", (cd.bank_cont3email != null) ? cd.bank_cont3email : "",
                    (cd.bank_contact4 != null) ? cd.bank_contact4 : "", (cd.bank_cont4email != null) ? cd.bank_cont4email : "", (cd.bank_telno1 != null) ? cd.bank_telno1 : "",
                    (cd.bank_faxno1 != null) ? cd.bank_faxno1 : "", (cd.bank_telno2 != null) ? cd.bank_telno2 : "", (cd.bank_faxno2 != null) ? cd.bank_faxno2 : "",
                    (cd.bank_telno3 != null) ? cd.bank_telno3 : "", (cd.bank_faxno3 != null) ? cd.bank_faxno3 : "", (cd.bank_telno4 != null) ? cd.bank_telno4 : "",
                    (cd.bank_faxno4 != null) ? cd.bank_faxno4 : "", (cd.bank_title != null) ? cd.bank_title : "", (cd.bank_title1 != null) ? cd.bank_title1 : "",
                    (cd.bank_title2 != null) ? cd.bank_title2 : "", (cd.bank_title3 != null) ? cd.bank_title3 : "", (cd.bank_title4 != null) ? cd.bank_title4 : "",
                    (cd.bank_designation1 != null) ? cd.bank_designation1 : "", (cd.bank_designation2 != null) ? cd.bank_designation2 : "", (cd.bank_designation3 != null) ? cd.bank_designation3 : "",
                    (cd.bank_designation4 != null) ? cd.bank_designation4 : "", (cd.bank_mobile1 != null) ? cd.bank_mobile1 : "", (cd.bank_mobile2 != null) ? cd.bank_mobile2 : "",
                    (cd.bank_mobile3 != null) ? cd.bank_mobile3 : "", (cd.bank_mobile4 != null) ? cd.bank_mobile4 : "", cd.MakerIP,
                     cd.MakerID, cd.cmp_code, cd.citycode);

              }
              catch (Exception ex)
              {
                  ds = ErrorLog.Error(ex, "Master/Consignee_bank_IU");
              }
              finally
              {
                  objDal.Dispose();

              }
              return Ok(ds);
          }
          /// <summary>Populate the consignee bank form with existing record data.</summary>
          /// <param name="fkbankcode">fkbankcode parameter.</param>
          /// <returns>DataSet with the requested data serialized as JSON.</returns>
          [HttpGet]
          public IHttpActionResult Master_bankdet_Populate(string fkbankcode)
          {
              DataSet ds = new DataSet();
              DAL objDal = new DAL();
              try
              {

                  ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP35_EXP_CONSGBANK_FILLDETAILS", fkbankcode) ;

              }
              catch (Exception ex)
              {
                  ErrorLog.Error(ex, "Master/Master_bankdet_Populate");
              }
              return Ok(ds);
          }


        /*ADDED FOR GENERAL ACCOUNT PAGE*/
        /// <summary>Retrieve the full list of general accounts for dropdown population.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MST_GENERAL_ACCOUNT_FILL()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_GENERAL_ACCOUNT_FILL");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST_GENERAL_ACCOUNT_FILL");
            }
            return Ok(ds);
        }



        /// <summary>Insert or update a general account master record.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult MST_GENERAL_ACCOUNT_IU([FromBody]GeneralAccountMaster cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_GENERAL_ACCOUNT_IU", cd.ID, cd.AccName, cd.UnderGroup, cd.SACCode, cd.Invoice, cd.Bank, cd.JobRpt, cd.invreg_isreport, cd.IsExpenseLock, cd.IsPurchase_Show, cd.MUM, cd.DEL, cd.MAA, cd.BLR, cd.AMD, cd.DAC, cd.IsEmployee, cd.Company, cd.MakerID, cd.MakerIP);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST_GENERAL_ACCOUNT_FILL");
            }
            return Ok(ds);
        }

        /// <summary>Search general account records with multiple filter criteria.</summary>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="AccName">Acc Name parameter.</param>
        /// <param name="AccOption">Acc Option parameter.</param>
        /// <param name="UnderGroup">Under Group parameter.</param>
        /// <param name="Invoice">Invoice parameter.</param>
        /// <param name="Bank">Bank parameter.</param>
        /// <param name="JobRpt">Job Rpt parameter.</param>
        /// <param name="invreg_isreport">invreg isreport parameter.</param>
        /// <param name="IsExpenseLock">Is Expense Lock parameter.</param>
        /// <param name="IsPurchase_Show">Is Purchase Show parameter.</param>
        /// <param name="IsEmployee">Is Employee parameter.</param>
        /// <param name="MUM">MUM parameter.</param>
        /// <param name="DEL">DEL parameter.</param>
        /// <param name="MAA">MAA parameter.</param>
        /// <param name="BLR">BLR parameter.</param>
        /// <param name="AMD">AMD parameter.</param>
        /// <param name="DAC">DAC parameter.</param>
        /// <param name="Company">Company parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MST_GENERAL_ACCOUNT_SEARCH(String Mode, String AccName, string AccOption, string UnderGroup, string Invoice, string Bank, string JobRpt, string invreg_isreport, string IsExpenseLock, string IsPurchase_Show, string IsEmployee, string MUM, string DEL, string MAA, string BLR, string AMD, string DAC, string Company)

        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {


                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_GENERAL_ACCOUNT_SEARCH_20200601_1930", (Mode != null) ? Mode : "", (AccName != null) ? AccName : "", (AccOption != null) ? AccOption : "", (UnderGroup != null) ? UnderGroup : "", (Invoice != null) ? Invoice : "", (Bank != null) ? Bank : "", (JobRpt != null) ? JobRpt : "", (invreg_isreport != null) ? invreg_isreport : "", (IsExpenseLock != null) ? IsExpenseLock : "", (IsPurchase_Show != null) ? IsPurchase_Show : "", (IsEmployee != null) ? IsEmployee : "", (MUM != null) ? MUM : "", (DEL != null) ? DEL : "", (MAA != null) ? MAA : "", (BLR != null) ? BLR : "", (AMD != null) ? AMD : "", (DAC != null) ? DAC : "", (Company != null) ? Company : "");
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST_GENERAL_ACCOUNT_SEARCH");
            }
            return Ok(ds);
        }
        /// <summary>Populate the general account form with existing record data.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MST_GENERAL_ACCOUNT_POPULATE(String ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_GENERAL_ACCOUNT_POPULATE", ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST_GENERAL_ACCOUNT_POPULATE");
            }
            return Ok(ds);
        }
        /*ADDED FOR ITEM CODE PAGE*/
        /// <summary>Retrieve item codes for dropdown population.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MST__ACCOUNTS_ITEMCODE_FILL_DROPDOWN()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_ACCOUNTS_ITEMCODE_FILL_DROPDOWN");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST__ACCOUNTS_ITEMCODE_FILL_DROPDOWN");
            }
            return Ok(ds);
        }

        /// <summary>Retrieve item codes for the given company for dropdown population.</summary>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MST_ACCOUNTS_ITEMCODE_FILL_DROPDOWN_CITY(string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_ACCOUNTS_ITEMCODE_FILL_DROPDOWN_CITY", CMPCODE);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST_ACCOUNTS_ITEMCODE_FILL_DROPDOWN_CITY");
            }
            return Ok(ds);
        }

        /// <summary>Search and retrieve item code records for the grid display.</summary>
        /// <param name="CmpCode">Company code identifier.</param>
        /// <param name="CityCode">City/branch code.</param>
        /// <param name="AccCode">Acc Code parameter.</param>
        /// <param name="ItemName">Item Name parameter.</param>
        /// <param name="SearchType">Search type/column identifier.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult MST_ACCOUNTS_ITEMCODE_FILL_GRID(string CmpCode, string CityCode, string AccCode, string ItemName, string SearchType)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_ACCOUNTS_ITEMCODE_FILL_GRID_NG", (CmpCode != null) ? CmpCode : "", (CityCode != null) ? CityCode : "", (AccCode != null) ? AccCode : "", (ItemName != null) ? ItemName : "", (SearchType != null) ? SearchType : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/MST_ACCOUNTS_ITEMCODE_FILL_GRID");
            }
            return Ok(ds);
        }



        /// <summary>Insert a new accounts item code record.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult MST_ACCOUNTS_ITEMCODE_IU([FromBody]ItemCode cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_ACCOUNTS_ITEMCODE_IU", cd.CmpCode, cd.CityCode, cd.AccCode, cd.ItemName, cd.ExpireDate, cd.Remarks, cd.MakerID, cd.MakerIP);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin/MST_ACCOUNTS_ITEMCODE_IU");
            }
            return Ok(ds);
        }

        /// <summary>Update an existing accounts item code record.</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult MST_ACCOUNTS_ITEMCODE_UPDATE([FromBody]ItemCode cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_ACCOUNTS_ITEMCODE_UPDATE", cd.CmpCode, cd.CityCode, cd.ITEMCODE, cd.AccCode, cd.ItemName, cd.ExpireDate, cd.Remarks, cd.MakerID, cd.MakerIP);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/MST_ACCOUNTS_ITEMCODE_UPDATE");
            }
            return Ok(ds);
        }


        /// <summary>Retrieve the charge master account list for dropdown population.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CHARGEMASTER_ACCOUNT_FILL()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCT_CHARGE_MST_FILL", "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/ACC_CHARGEMASTER_ACCOUNT_FILL");
            }
            return Ok(ds);
        }


        /// <summary>Insert or update a charge master record.</summary>
        /// <param name="CM">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ACC_CHARGE_MASTER_IU([FromBody]ChargeMaster CM)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCT_CHARGE_MASTER_IU", (CM.ID != null) ? CM.ID : "0", CM.CHRG_CODE, CM.CHRG_ACCOUNT, CM.CHRG_DESC, CM.CHRG_DESC1, CM.CHRG_TAXABLE, CM.ISINVOIREGIREPORT, CM.ISPURCHASE, CM.MakerID, CM.MakerIP);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/ACC_CHARGE_MASTER_IU");
            }
            return Ok(ds);
        }


        /// <summary>Populate the charge master form with existing record data.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CHARGE_MASTER_POPULATE(String ID)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_CHARGE_POPULATE", ID);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/ACC_CHARGE_MASTER_POPULATE");
            }
            return Ok(ds);
        }

        /// <summary>Search charge master records with filter criteria.</summary>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="ChargeName">Charge Name parameter.</param>
        /// <param name="ChargeOption">Charge Option parameter.</param>
        /// <param name="UnderAccount">Under Account parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ACC_CHARGE_MASTER_SEARCH(String Mode, String ChargeName, string ChargeOption, string UnderAccount)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_MST_CHARGE_SEARCH", Mode, (ChargeName != null) ? ChargeName : "", ChargeOption, (UnderAccount != null) ? UnderAccount : "");

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Master/ACC_CHARGE_MASTER_SEARCH");
            }
            return Ok(ds);
        }
        /* added on 14-jul-2022 for tds details insert update*/
        /// <summary>Insert or update a supplier TDS detail record (NG version).</summary>
        /// <param name="cd">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult SUPPLIER_CHILD_TDS_IU_NG([FromBody]supplierchildTDS cd)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_SUP_MSTCHILD_TDS_DET_IU_NG", cd.PKID, cd.ID, cd.SUP_CODE, cd.SECTIONID, cd.PER_RATE, cd.FRMDT, cd.TODT, cd.TDS_LIMIT_AMT, cd.TDS_TYPE, cd.MAKERID, cd.MAKERIP, cd.VGUID, cd.MODEOFENTRY, (cd.LDCRATE != null) ? cd.LDCRATE : "0.00", (cd.CMPCODE != null) ? cd.CMPCODE : "0", (cd.reqmode != null) ? cd.reqmode : "", (cd.LDCCERTNO != null) ? cd.LDCCERTNO : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/SUPPLIER_CHILD_TDS_IU_NG");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Delete a temporary supplier address child record.</summary>
        /// <param name="id">Primary key ID of the record.</param>
        /// <param name="guid">Session GUID for temporary record management.</param>
        /// <param name="makerid">User code of the record maker.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="SUP_CODE">SUP CODE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult supplier_TempAddress_delete([FromUri]string id, string guid, string makerid, string Mode, string SUP_CODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_SUP_MSTCHILDDELETE_IU", id, guid, makerid, Mode, (SUP_CODE != null) ? SUP_CODE : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/supplier_TempAddress_delete");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Delete a confirmed supplier address record.</summary>
        /// <param name="id">Primary key ID of the record.</param>
        /// <param name="guid">Session GUID for temporary record management.</param>
        /// <param name="makerid">User code of the record maker.</param>
        /// <param name="Mode">Operation mode or filter type.</param>
        /// <param name="SUP_CODE">SUP CODE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult supplier_Address_delete([FromUri]string id, string guid, string makerid, string Mode, string SUP_CODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_SUP_MST_ADDRESSDELETE", id, guid, makerid, (Mode != null) ? Mode : "", (SUP_CODE != null) ? SUP_CODE : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Master/supplier_Address_delete");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

   
    }

}
