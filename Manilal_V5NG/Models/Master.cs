using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

namespace Manilal_V5NG.Models
{
    public class Master  
    {

        //City
        public string id { get; set; }
        public string city_code { get; set; }
        public string city_name { get; set; }
        public string city_country { get; set; }
        public string city_seaport { get; set; }
        public string city_airport { get; set; }
        public string city_consoleorigin { get; set; }
        public string city_consoledest { get; set; }
        public string city_deldest { get; set; }
        public string city_tranship { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string cmp_code { get; set; }
        public string citycode { get; set; }

    }
    public class expoterchild  
    {
        public string childrecdId { get; set; }
        public string exp_invadd1 { get; set; }
        public string exp_invadd2 { get; set; }
        public string exp_invadd3 { get; set; }
        public string exp_invpincode { get; set; }
        public string exp_invpinposition { get; set; }
        public string exp_invcity { get; set; }
        public string EXP_GSTNO { get; set; }
        public string EXP_GSTARNNO { get; set; }
        public string EXP_GSTtitle { get; set; }
        public string Exp_GSTcontP { get; set; }
        public string Exp_GSTtelno { get; set; }
        public string EXP_GSTMobno { get; set; }
        public string EXP_GSTcontemail { get; set; }
        public string expid { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string cmp_code { get; set; }
        public string citycode { get; set; }
        public string cmpcode { get; set; }
        public string cmpid { get; set; }
        public string vguid { get; set; }
        public string reqmode { get; set; }
    }
    public class ExpoterMain
    {
        public string id { get; set; }
        public string exp_sname { get; set; }
        public string exp_name { get; set; }
        public string exp_add1 { get; set; }
        public string exp_add2 { get; set; }
        public string exp_add3 { get; set; }
        public string exp_pincode { get; set; }
        public string exp_pinposition { get; set; }
        public string exp_city { get; set; }
        public string exp_country { get; set; }
        public string exp_invadd1 { get; set; }
        public string exp_invadd2 { get; set; }
        public string exp_invadd3 { get; set; }
        public string exp_invpincode { get; set; }
        public string exp_invpinposition { get; set; }
        public string exp_invcity { get; set; }
        public string exp_invcountry { get; set; }
        public string exp_telno { get; set; }
        public string exp_faxno { get; set; }
        public string exp_telex { get; set; }
        public string exp_email { get; set; }
        public string exp_rbicode { get; set; }
        public string exp_imno { get; set; }
        public string exp_itno { get; set; }
        public string exp_bank { get; set; }
        public string exp_custpno { get; set; }
        public string exp_hscertno { get; set; }
        public string exp_hscertdt { get; set; }
        public string exp_contact1 { get; set; }
        public string exp_cont1email { get; set; }
        public string exp_contact2 { get; set; }
        public string exp_cont2email { get; set; }
        public string exp_contact3 { get; set; }
        public string exp_cont3email { get; set; }
        public string exp_contact4 { get; set; }
        public string exp_cont4email { get; set; }
        public string exp_typea { get; set; }
        public string exp_typeb { get; set; }
        public string exp_expthouse { get; set; }
        public string exp_certvaliddt { get; set; }
        public string exp_state { get; set; }
        public string exp_telno1 { get; set; }
        public string exp_faxno1 { get; set; }
        public string exp_telno2 { get; set; }
        public string exp_faxno2 { get; set; }
        public string exp_telno3 { get; set; }
        public string exp_faxno3 { get; set; }
        public string exp_telno4 { get; set; }
        public string exp_faxno4 { get; set; }
        public string exp_ieccode { get; set; }
        public string exp_acctno { get; set; }
        public string exp_bankaddr1 { get; set; }
        public string exp_bankaddr2 { get; set; }
        public string exp_acctno1 { get; set; }
        public string exp_delarcode { get; set; }
        public string exp_rbiwaiverno { get; set; }
        public string exp_title { get; set; }
        public string exp_title1 { get; set; }
        public string exp_title2 { get; set; }
        public string exp_title3 { get; set; }
        public string exp_title4 { get; set; }
        public string exp_designation1 { get; set; }
        public string exp_designation2 { get; set; }
        public string exp_designation3 { get; set; }
        public string exp_designation4 { get; set; }
        public string exp_commrate { get; set; }
        public string exp_division { get; set; }
        public string exp_range { get; set; }
        public string exp_ItcGroupcode { get; set; }
        public string exp_mobile1 { get; set; }
        public string exp_mobile2 { get; set; }
        public string exp_mobile3 { get; set; }
        public string exp_mobile4 { get; set; }
        public string con_code { get; set; }
        public string exporterin { get; set; }
        public string importerin { get; set; }
        public string exporterfr { get; set; }
        public string importerfr { get; set; }
        public string exporter { get; set; }
        public string importer { get; set; }
        public string srcagent { get; set; }
        public string consignee { get; set; }
        public string exp_panno { get; set; }
        public string exp_servicetax { get; set; }
        public string MakerIP { get; set; }
        public string cmpid { get; set; }
        public string cmp_code { get; set; }
        public string citycode { get; set; }
        public string RequestMode { get; set; }
        public string exp_EORINUMBER { get; set; }
        public string TANNO { get; set; }
        public string EXP_GSTNO { get; set; }
        public string EXP_GSTARNNO { get; set; }
        public string EXP_GSTtitle { get; set; }
        public string Exp_GSTcontP { get; set; }
        public string Exp_GSTtelno { get; set; }
        public string EXP_GSTMobno { get; set; }
        public string EXP_GSTcontemail { get; set; }
        public string VGUID { get; set; }
        public string ISSEZCLIENT { get; set; }
        public string SIRENNO { get; set; }
        public string CREDITPERIOD_SEA { get; set; }
        public string CREDITPERIOD_AIR { get; set; }
        public string ISOVERSEASAGENT { get; set; }
    }
    public class consigneemaster
    {
        public string id { get; set; }
        public string con_sname { get; set; }
        public string con_name { get; set; }
        public string con_title { get; set; }
        public string con_add1 { get; set; }
        public string con_add2 { get; set; }
        public string con_add3 { get; set; }
        public string con_email { get; set; }
        public string con_pincode { get; set; }
        public string con_pinposition { get; set; }
        public string con_city { get; set; }
        public string con_country { get; set; }
        public string con_telno { get; set; }
        public string con_faxno { get; set; }
        public string con_title1 { get; set; }
        public string con_contact1 { get; set; }
        public string con_designation1 { get; set; }
        public string con_telno1 { get; set; }
        public string con_faxno1 { get; set; }
        public string con_mobile1 { get; set; }
        public string con_cont1email { get; set; }
        public string con_title2 { get; set; }
        public string con_contact2 { get; set; }
        public string con_designation2 { get; set; }
        public string con_telno2 { get; set; }
        public string con_faxno2 { get; set; }
        public string con_mobile2 { get; set; }
        public string con_cont2email { get; set; }
        public string con_title3 { get; set; }
        public string con_contact3 { get; set; }
        public string con_designation3 { get; set; }
        public string con_telno3 { get; set; }
        public string con_faxno3 { get; set; }
        public string con_mobile3 { get; set; }
        public string con_cont3email { get; set; }
        public string con_title4 { get; set; }
        public string con_contact4 { get; set; }
        public string con_designation4 { get; set; }
        public string con_telno4 { get; set; }
        public string con_faxno4 { get; set; }
        public string con_mobile4 { get; set; }
        public string con_cont4email { get; set; }
        public string con_approval { get; set; }
        public string con_sourceagt { get; set; }
        public string con_doccode { get; set; }
        public string con_cneefrance { get; set; }
        public string con_cneeothers { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string cmp_code { get; set; }
        public string citycode { get; set; }
        public string RequestMode { get; set; }
        public string con_EORINUMBER { get; set; }
        public string IsSytiyaclient { get; set; }
        public string SIRENNO { get; set; }
    }
    public class supplierchild
    {
        public string Pk_SupAdd_Id { get; set; }
        public string fksup_code { get; set; }
        public string sup_add1 { get; set; }
        public string sup_add2 { get; set; }
        public string sup_add3 { get; set; }
        public string sup_pincode { get; set; }
        public string sup_position { get; set; }
        public string sup_city { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string sup_GSTNO { get; set; }
        public string sup_GSTARNNO { get; set; }
        public string sup_GSTcontP { get; set; }
        public string sup_GSTtelno { get; set; }
        public string sup_GSTMobno { get; set; }
        public string sup_GSTcontemail { get; set; }
        public string sup_GSTtitle { get; set; }
        public string maineSupid { get; set; }
        public string IS_Gst_Reg { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string cmp_code { get; set; }
        public string citycode { get; set; }
        public string cmpcode { get; set; }
        public string cmpid { get; set; }
        public string vguid { get; set; }
        public string reqmode { get; set; }

    }

    public class supplierchildTDS
    {
        public string PKID { get; set; }
        public string SUP_CODE { get; set; }
        public string SECTIONID { get; set; }
        public string PER_RATE { get; set; }
        public string FRMDT { get; set; }
        public string TODT { get; set; }
        public string TDS_LIMIT_AMT { get; set; }
        public string TDS_TYPE { get; set; }
        public string MAKERID { get; set; }
        public string MAKERDT { get; set; }
        public string MAKERIP { get; set; }
        public string VGUID { get; set; }
        public string MODEOFENTRY { get; set; }
        public string LDCRATE { get; set; }
        public string CMPCODE { get; set; }
        public string ID { get; set; }
        public string reqmode { get; set; }
        public string LDCCERTNO { get; set; }
        public string FK_GENACT_MST_ID { get; set; }
        public string ACCT_CODE { get; set; }
        public string GENACTTDSDTLID { get; set; }
    }
    public class suppliermaster
    {
        public string id { get; set; }
        public string sup_sname { get; set; }
        public string sup_name { get; set; }
        public string sup_title { get; set; }
        public string sup_add1 { get; set; }
        public string sup_add2 { get; set; }
        public string sup_add3 { get; set; }
        public string sup_email { get; set; }
        public string sup_pincode { get; set; }
        public string sup_pinposition { get; set; }
        public string sup_city { get; set; }
        public string sup_country { get; set; }
        public string sup_telno { get; set; }
        public string sup_faxno { get; set; }
        public string sup_title1 { get; set; }
        public string sup_contact1 { get; set; }
        public string sup_designation1 { get; set; }
        public string sup_telno1 { get; set; }
        public string sup_faxno1 { get; set; }
        public string sup_mobile1 { get; set; }
        public string sup_cont1email { get; set; }
        public string sup_title2 { get; set; }
        public string sup_contact2 { get; set; }
        public string sup_designation2 { get; set; }
        public string sup_telno2 { get; set; }
        public string sup_faxno2 { get; set; }
        public string sup_mobile2 { get; set; }
        public string sup_cont2email { get; set; }
        public string sup_title3 { get; set; }
        public string sup_contact3 { get; set; }
        public string sup_designation3 { get; set; }
        public string sup_telno3 { get; set; }
        public string sup_faxno3 { get; set; }
        public string sup_mobile3 { get; set; }
        public string sup_cont3email { get; set; }
        public string sup_title4 { get; set; }
        public string sup_contact4 { get; set; }
        public string sup_designation4 { get; set; }
        public string sup_telno4 { get; set; }
        public string sup_faxno4 { get; set; }
        public string sup_mobile4 { get; set; }
        public string sup_cont4email { get; set; }
        public string airline { get; set; }
        public string airlineagent { get; set; }
        public string shippingline { get; set; }
        public string warehouse { get; set; }
        public string transporter { get; set; }
        public string agent { get; set; }
        public string fwarehouse { get; set; }
        public string others { get; set; }
        public string sup_airlinecode { get; set; }
        public string agentcity { get; set; }
        public string city { get; set; }
        public string sup_panno { get; set; }
        public string sup_servicetax { get; set; }
        public string sup_EORINUMBER { get; set; }
        public string Sup_TANNO { get; set; }
        public string sup_GSTNO { get; set; }
        public string sup_GSTARNNO { get; set; }
        public string sup_GSTtitle { get; set; }
        public string sup_GSTcontP { get; set; }
        public string sup_GSTtelno { get; set; }
        public string sup_GSTMobno { get; set; }
        public string sup_GSTcontemail { get; set; }
        public string maineSupid { get; set; }
        public string RequestMode { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string cmp_code { get; set; }
        public string citycode { get; set; }
        public string cmpcode { get; set; }
        public string cmpid { get; set; }
        public string vguid { get; set; }
        public string reqmode { get; set; }
        public string IS_TDS { get; set; }
    }

    public class VesselAgent
    {
        public string id { get; set; }
        public string agt_sname { get; set; }
        public string agt_name { get; set; }
        public string agt_title { get; set; }
        public string agt_add1 { get; set; }
        public string agt_add2 { get; set; }
        public string agt_add3 { get; set; }
        public string agt_email { get; set; }
        public string agt_pincode { get; set; }
        public string agt_pinposition { get; set; }
        public string agt_city { get; set; }
        public string agt_country { get; set; }
        public string agt_telno { get; set; }
        public string agt_faxno { get; set; }
        public string agt_title1 { get; set; }
        public string agt_contact1 { get; set; }
        public string agt_designation1 { get; set; }
        public string agt_telno1 { get; set; }
        public string agt_faxno1 { get; set; }
        public string agt_mobile1 { get; set; }
        public string agt_cont1email { get; set; }
        public string agt_title2 { get; set; }
        public string agt_contact2 { get; set; }
        public string agt_designation2 { get; set; }
        public string agt_telno2 { get; set; }
        public string agt_faxno2 { get; set; }
        public string agt_mobile2 { get; set; }
        public string agt_cont2email { get; set; }
        public string agt_title3 { get; set; }
        public string agt_contact3 { get; set; }
        public string agt_designation3 { get; set; }
        public string agt_telno3 { get; set; }
        public string agt_faxno3 { get; set; }
        public string agt_mobile3 { get; set; }
        public string agt_cont3email { get; set; }
        public string agt_title4 { get; set; }
        public string agt_contact4 { get; set; }
        public string agt_designation4 { get; set; }
        public string agt_telno4 { get; set; }
        public string agt_faxno4 { get; set; }
        public string agt_mobile4 { get; set; }
        public string agt_cont4email { get; set; }
        public string agt_liner1 { get; set; }
        public string agt_liner2 { get; set; }
        public string agt_liner3 { get; set; }
        public string agt_liner4 { get; set; }
        public string agt_panno { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string cmp_code { get; set; }
        public string citycode { get; set; }
        public string RequestMode { get; set; }

    }

    public class Linermaster
    {
        public string id { get; set; }
        public string liner_sname { get; set; }
        public string liner_name { get; set; }
        public string liner_add1 { get; set; }
        public string liner_add2 { get; set; }
        public string liner_add3 { get; set; }
        public string liner_pincode { get; set; }
        public string liner_pinposition { get; set; }
        public string liner_city { get; set; }
        public string liner_country { get; set; }
        public string liner_telno { get; set; }
        public string liner_faxno { get; set; }
        public string liner_email { get; set; }
        public string MakerIP { get; set; }
        public string MakerID { get; set; }
        public string cmp_code { get; set; }
        public string citycode { get; set; }
        public string RequestMode { get; set; }

    }

    public class Bank_master
    {
        public string id { get; set; }
        public string bank_sname { get; set; }
        public string bank_name { get; set; }
        public string bank_add1 { get; set; }
        public string bank_add2 { get; set; }
        public string bank_add3 { get; set; }
        public string bank_pincode { get; set; }
        public string bank_pinposition { get; set; }
        public string bank_city { get; set; }
        public string bank_country { get; set; }
        public string bank_telno { get; set; }
        public string bank_faxno { get; set; }
        public string bank_telex { get; set; }
        public string bank_email { get; set; }
        public string bank_contact1 { get; set; }
        public string bank_cont1email { get; set; }
        public string bank_contact2 { get; set; }
        public string bank_cont2email { get; set; }
        public string bank_contact3 { get; set; }
        public string bank_cont3email { get; set; }
        public string bank_contact4 { get; set; }
        public string bank_cont4email { get; set; }
        public string bank_telno1 { get; set; }
        public string bank_faxno1 { get; set; }
        public string bank_telno2 { get; set; }
        public string bank_faxno2 { get; set; }
        public string bank_telno3 { get; set; }
        public string bank_faxno3 { get; set; }
        public string bank_telno4 { get; set; }
        public string bank_faxno4 { get; set; }
        public string bank_title { get; set; }
        public string bank_title1 { get; set; }
        public string bank_title2 { get; set; }
        public string bank_title3 { get; set; }
        public string bank_title4 { get; set; }
        public string bank_designation1 { get; set; }
        public string bank_designation2 { get; set; }
        public string bank_designation3 { get; set; }
        public string bank_designation4 { get; set; }
        public string bank_mobile1 { get; set; }
        public string bank_mobile2 { get; set; }
        public string bank_mobile3 { get; set; }
        public string bank_mobile4 { get; set; }
        public string MakerIP { get; set; }
        public string MakerID { get; set; }
        public string cmp_code { get; set; }
        public string citycode { get; set; }

    }

    /*ACCOUNT */
    public class GeneralAccountMaster
    {
        public string ID { get; set; }
        public string AccName { get; set; }
        public string UnderGroup { get; set; }
        public string SACCode { get; set; }
        public string Invoice { get; set; }
        public string Bank { get; set; }
        public string JobRpt { get; set; }
        public string invreg_isreport { get; set; }
        public string IsExpenseLock { get; set; }
        public string IsPurchase_Show { get; set; }
        public string MUM { get; set; }
        public string DEL { get; set; }
        public string MAA { get; set; }
        public string BLR { get; set; }
        public string AMD { get; set; }
        public string DAC { get; set; }
        public string TRN { get; set; }
        public string TRU { get; set; }
        public string COC { get; set; }
        public string IsEmployee { get; set; }
        public string AccOption { get; set; }
        public string Company { get; set; }
        public string MakerIP { get; set; }
        public string MakerID { get; set; }
        public string Mode { get; set; }
        public string IS_TDS_APP { get; set; }
        public string VGUID { get; set; }
    }
    public class ItemCode
    {
        public string CmpCode { get; set; }
        public string CityCode { get; set; }
        public string AccCode { get; set; }
        public string ItemName { get; set; }
        public string ExpireDate { get; set; }
        public string Remarks { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string ITEMCODE { get; set; }


    }

    public class ChargeMaster
    {
        public string ID { get; set; }
        public string CHRG_CODE { get; set; }
        public string CHRG_ACCOUNT { get; set; }
        public string CHRG_DESC { get; set; }
        public string CHRG_DESC1 { get; set; }
        public string CHRG_TAXABLE { get; set; }
        public string ISINVOIREGIREPORT { get; set; }
        public string ISPURCHASE { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
                     
    }

}