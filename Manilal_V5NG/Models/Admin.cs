using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manilal_V5NG.Models
{
    public class Quotation_Client
    {
        public string PK_CLIENTID { get; set; }
        public string CLIENT_NAME { get; set; }
        public string CLIENT_ADD1 { get; set; }
        public string CLIENT_ADD2 { get; set; }
        public string CLIENT_CITY { get; set; }
        public string CLIENT_COUNTRY { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE { get; set; }
        public string MAKERID { get; set; }
        public string MAKERIP { get; set; }
    }
    public class SalesEnquiry
    {
        public string PK_ID { get; set; }
        public string ENQREFNO { get; set; }
        public string ENQRECPTDT { get; set; }
        public string ENQINPUTBY { get; set; }
        public string ENQTYPE { get; set; }
        public string SHIPMENT { get; set; }
        public string EXIM { get; set; }
        public string INCOTERM { get; set; }
        public string NETWORK { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string AGENT_NAME { get; set; }
        public string SALESPERSON { get; set; }
        public string BRANCH { get; set; }
        public string MODE { get; set; }
        public string AOD { get; set; }
        public string AOA { get; set; }
        public string DIMENSION { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string EMAIL { get; set; }
        public string REMARK { get; set; }
        public string JOBNO { get; set; }
        public string SHIPPER { get; set; }

        public string CONSIGNEE { get; set; }
        public string STATUS { get; set; }
        public string ENQ_QUOT_DATE { get; set; }
        public string QUOTRATEDAYS { get; set; }
        public string SPREMARK { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string MAKERID { get; set; }
        public string MAKERIP { get; set; }


    }
    public class Quotation_Details
    {
        public string PKID { get; set; }
        public string FK_QUOTID { get; set; }
        public string QUOT_CODE { get; set; }
        public string CHRG_CODE { get; set; }
        public string CURCODE { get; set; }
        public string RATE { get; set; }
        public string EX_RATE { get; set; }
        public string MIN_RATE { get; set; }
        public string UNITTYPE { get; set; }
        public string UNIT { get; set; }
        public string CHRG_TYPE { get; set; }
        public string MAKERID { get; set; }
        public string VGUID { get; set; }
        public string QUOTDTLID { get; set; }

    }

    public class Quotation_Master
    {
        public string PK_QUOTID { get; set; }
        public string QUOT_CODE { get; set; }
        public string QUOT_DATE { get; set; }
        public string VALIDUPTO { get; set; }
        public string CLIENT_CODE { get; set; }
        public string CLIENT_ORIGIN { get; set; }
        public string SHIP_MODE { get; set; }
        public string SHIP_TYPE { get; set; }
        public string VGUID { get; set; }
        public string SHIPPINGLINE { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string INCOTERM { get; set; }
        public string CONTLOADTYPE { get; set; }
        public string WEIGHT { get; set; }
        public string CHWEIGHT { get; set; }
        public string VOLUME { get; set; }
        public string LOAD { get; set; }
        public string NARRATION { get; set; }
        public string AIRLINE { get; set; }
        public string COMPANY_CODE { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string CITYCODE { get; set; }
        public string MAKERID { get; set; }
        public string MAKERIP { get; set; }
        public string MAKERDT { get; set; }

    }
    public class IAdmin
    {
        public string USRCODE { get; set; }
        public string USRNAME { get; set; }
        public string PASSWORD { get; set; }
        public string DATELINE { get; set; }
        public string FULLNAME { get; set; }
        public string GREET { get; set; }
        public string EMAIL { get; set; }
        public string ACTIVECITY { get; set; }
        public string ACTIVECITYCODE { get; set; }
        public string AUTHORITY { get; set; }
        public string ISADMIN { get; set; }
        public string ROLE { get; set; }
        public string IMG { get; set; }
        public string LOCATION { get; set; }
        public string ID { get; set; }
        public string NOOFDAYS { get; set; }
        public string UNBLOCK { get; set; }
        public string ISRESIGNED { get; set; }
       
    }


    public class FinancialYear
    {
        public string Citycode { get; set; }
        public string CmpCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }

    public class companychild
    {
        public string pk_cmpaddressid { get; set; }
        public string fk_cmpcode { get; set; }
        public string braddrs1 { get; set; }
        public string braddrs2 { get; set; }
        public string braddrs3 { get; set; }
        public string fk_cityId { get; set; }
        public string brphoneno { get; set; }
        public string brfaxno { get; set; }
        public string bremail { get; set; }
        public string brcmpImage { get; set; }
        public string brcmpurl { get; set; }
        public string brtax { get; set; }
        public string brgstno { get; set; }
        public string bracstmntfrom { get; set; }
        public string bracstmntfrmemail { get; set; }
        public string brishblissu { get; set; }
        public string brishawbissw { get; set; }
        public string brisactive { get; set; }
        public string brismore { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string cmpid { get; set; }
        public string vguid { get; set; }
        public string reqmode { get; set; }
    }

    public class companymain
    {
        public string pk_cmpId { get; set; }
        public string cmpcode { get; set; }
        public string cmpname { get; set; }
        public string cmpaddr1 { get; set; }
        public string cmpaddr2 { get; set; }
        public string cmpaddr3 { get; set; }
        public string cmpcity { get; set; }
        public string cmpactivecity { get; set; }
        public string cmpactivecitycode { get; set; }
        public string cmpcustlicno { get; set; }
        public string cmpiatacode { get; set; }

        public string cmptelno { get; set; }
        public string cmpfaxno { get; set; }
        public string cmpemail { get; set; }
        public string cmprgdsrvtax { get; set; }
        public string cmprgdtpttax { get; set; }

        public string cmprgdauxtax { get; set; }
        public string cmprgdesic { get; set; }
        public string cmprgdinctaxno { get; set; }
        public string cmptanno { get; set; }
        public string cmprgdstrtax { get; set; }
        public string cmprgdchsrvtax { get; set; }

        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string VGUID { get; set; }

    }

    public class BP_Bank_Payment_Group
    {
        public string pkGroupId { get; set; }
        public string fkGroupCmpId { get; set; }
        public string GroupCmp_UserName { get; set; }
        //public string fkMemberCmpId { get; set; }
        //public string MemberCmp_UserName { get; set; }
        public string STR_TEXT { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string MODE { get; set; }
    }


    public class Client_Rate_Details
    {
        public string PKID { get; set; }
        public string FK_QUTDETID { get; set; }
        public string FK_QUTID { get; set; }
        public string CHRG_CODE { get; set; }
        public string CURCODE { get; set; }
        public string RATE { get; set; }
        public string EXRATE { get; set; }
        public string MIN_RATE { get; set; }
        public string UNIT { get; set; }
        public string CHRG_TYPE { get; set; }
        public string MAKERID { get; set; }
        public string VGUID { get; set; }

    }

    public class Client_Rate_Master {
        public string PKQUTID { get; set; }
        public string CLIENT_CODE { get; set; }
        public string SHIP_MODE { get; set; }
        public string CLIENT_ORIGIN { get; set; }
        public string EFFECT_FRMDT { get; set; }
        public string EFFECT_TODT { get; set; }
        public string MAKERID { get; set; }
        public string VGUID { get; set; }
        public string MAKERIP { get; set; }
        public string CMPCODE { get; set; }
        public string SHIP_TYPE { get; set; }
        public string SHIPPINGLINE { get; set; }
        public string CITYCODE { get; set; }

    }
    public class QUOT_RATE_MASTER
    {
        public string PKRTID { get; set; }
        public string SHIPPINGLINE { get; set; }
        public string SHIP_TYPE { get; set; }
        public string SHIP_MODE { get; set; }
        public string STUFF_TYPE { get; set; }
        public string POL { get; set; }
        public string TERMINAL { get; set; }
        public string POD { get; set; }
        public string CONT_SIZE { get; set; }
        public string CONT_TYPE { get; set; }
        public string ITEM_TYPE { get; set; }
        public string CHARGE_CODE { get; set; }
        public string RATE { get; set; }
        public string EXRATE { get; set; }
        public string CURRCODE { get; set; }
        public string EFRMDT { get; set; }
        public string ETODT { get; set; }
        public string MAKERID { get; set; }
        public string MAKERDT { get; set; }
        public string MAKERIP { get; set; }

    }

}