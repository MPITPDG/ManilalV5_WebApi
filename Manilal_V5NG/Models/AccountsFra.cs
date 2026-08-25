using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manilal_V5NG.Models
{
    public class AutoPurchaseResetRequest
    {
        public string GUID { get; set; }
    }
    public class AutoPurchaseSaveRequest
    {
        public string ID { get; set; }
        public string ENTRYNO { get; set; }
        public string ENTRYDATE { get; set; }   // dd/mm/yyyy
        public string SUPPLIER { get; set; }
        public string BILLNO { get; set; }
        public string PAIDDT { get; set; }       // dd/mm/yyyy
        public string TOT_EURO { get; set; }
        public string StrFilename { get; set; }
        public string CATID { get; set; }
        public string SUPINVDT { get; set; }     // dd/mm/yyyy
        public string SUP_ADDRID { get; set; }

        // Session-equivalent values supplied by the Angular login context.
        public string CMPID { get; set; }
        public string CITYCODE1 { get; set; }
        public string CMP_CODE { get; set; }
        public string MAKERIP { get; set; }
        public string GUID { get; set; }
        public string CITYCODE { get; set; }
    }

    public class Creditubmit
    {


        public string INVNO { get; set; }
        public string INVDT { get; set; }
        public string PAYDT { get; set; }
        public string client { get; set; }
        public string NOOF_PKS { get; set; }
        public string Typ_pkgs { get; set; }
        public string Clent_Ref { get; set; }
        public string NoofPcs { get; set; }
        public string Wt_Kilo { get; set; }
        public string CHBLWT { get; set; }
        public string HAWBNO { get; set; }
        public string HAWBDT { get; set; }
        public string Vref { get; set; }
        public string Carrier { get; set; }
        public string ETD { get; set; }
        public string ETA { get; set; }
        public string CUR_ID { get; set; }
        public string EX_Rate { get; set; }
        public string CMP_CODE { get; set; }
        public string citycode { get; set; }
        public string citycode1 { get; set; }
        public string CMPID { get; set; }
        public string Chk_Print { get; set; }
        public string VGUID { get; set; }
        public string CRT_ADDID { get; set; }
    }

    public class Creditnotechargesdel
    {

        public string ID { get; set; }
        public string CMPID { get; set; }
        public string EXCHANGE_RATE { get; set; }
        public string VGUID { get; set; }

    }

    public class Creditnoteclosuredel
    {

        public string ID { get; set; }
        public string CMPID { get; set; }
        public string VGUID { get; set; }

    }

    public class creditnotebill
    {

        public string BILLNO { get; set; }
        public string AMT { get; set; }
        public string VGUID { get; set; }
        public string CMPID { get; set; }
        public string client { get; set; }

    }

    public class creditnotechr
    {

        public string ID { get; set; }
        public string INVNO { get; set; }
        public string CHRGCODE { get; set; }
        public string ACCOUNT { get; set; }
        public string CHRGDESC { get; set; }
        public string CHRGDESC1 { get; set; }
        public string TAXABLE { get; set; }
        public string AMTEURO { get; set; }
        public string IsEdit { get; set; }
        public string CMPID { get; set; }
        public string EX_RATE { get; set; }
        public string TMP_STR { get; set; }
        public string CITYCODE { get; set; }
        public string VGUID { get; set; }

    }

    public class Creditnoteclosure
    {

        public string ID { get; set; }
        public string INVNO { get; set; }
        public string ENCLOSURE { get; set; }
        public string CMPID { get; set; }
        public string VGUID { get; set; }

    }

    public class Filjobcreditnote
    {
        public string SEARCH_MODE { get; set; }
        public string JOBNO { get; set; }
        public string REM_JOBNO { get; set; }
        public string cmpid { get; set; }
        public string client { get; set; }
        public string CITYCODE { get; set; }
        public string vguid { get; set; }
    }

    public class InvFraMain
    {


        public string INVNO { get; set; }
        public string INVDT { get; set; }
        public string PAYDT { get; set; }
        public string INV_TYPE { get; set; }
        public string MODE { get; set; }
        public string client { get; set; }
        public string NOOF_PKS { get; set; }
        public string Typ_pkgs { get; set; }
        public string Clent_Ref { get; set; }
        public string NoofPcs { get; set; }
        public string Wt_Kilo { get; set; }
        public string CHBLWT { get; set; }
        public string HAWBNO { get; set; }
        public string HAWBDT { get; set; }
        public string Vref { get; set; }
        public string Carrier { get; set; }
        public string ETD { get; set; }
        public string ETA { get; set; }
        public string CUR_ID { get; set; }
        public string EX_Rate { get; set; }
        public string CMP_CODE { get; set; }
        public string citycode { get; set; }
        public string citycode1 { get; set; }
        public string CMPID { get; set; }
        public string VGUID { get; set; }
        public string Inv_AddId { get; set; }
    }

    public class InvFraChrgeDtls
    {

        public string ID { get; set; }
        public string INVNO { get; set; }
        public string CHRGCODE { get; set; }
        public string ACCOUNT { get; set; }
        public string CHRGDESC { get; set; }
        public string CHRGDESC1 { get; set; }
        public string TAXABLE { get; set; }
        public string AMTEURO { get; set; }
        public string ISEDITABLE { get; set; }
        public string CMPID { get; set; }
        public string EX_RATE { get; set; }
        public string TMP_STR { get; set; }
        public string CITYCODE { get; set; }
        public string VGUID { get; set; }

    }
    public class InvFraEnclosure
    {

        public string ID { get; set; }
        public string INVNO { get; set; }
        public string ENCLOSURE { get; set; }
        public string CMPID { get; set; }
        public string VGUID { get; set; }

    }
    public class Filjobdata
    {
        public string SEARCH_TYPE { get; set; }
        public string INV_TYPE { get; set; }
        public string JOBNO { get; set; }
        public string REM_JOBNO { get; set; }
        public string MODE { get; set; }
        public string cmpid { get; set; }
        public string client { get; set; }
        public string CITYCODE { get; set; }
        public string vguid { get; set; }
    }
    public class Filjob
    {
        public string SEARCH_MODE { get; set; }
        public string client { get; set; }
        public string INV_TYPE { get; set; }
        public string FRM_DT { get; set; }
        public string TO_DT { get; set; }
        public string MODE { get; set; }
        public string CITYCODE { get; set; }
    }
    public class MasterInvoiceExchangRate
    {
        public int PkId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string For { get; set; }
        public string Rate { get; set; }
        public string MakerId { get; set; }
        public string MakerIp { get; set; }
    }

    public class PurchaseIu
    {
        public int Id { get; set; }
        public int EntryNo { get; set; }
        public string Supplier { get; set; }
        public string EntryDate { get; set; }
        public string BillNo { get; set; }
        public string BillDate { get; set; }
        public string TotalEuro { get; set; }
        public string InvoiceCurrency { get; set; }
        public string ExRate { get; set; }
        public string ExRate1 { get; set; }
        public string SupplierInvDate { get; set; }
        public string MakerId { get; set; }
        public string Guid { get; set; }
        public string CmpCode { get; set; }
        public string CityCode { get; set; }
        public string CityCode1 { get; set; }
        public string MakerIp { get; set; }
        public string Sup_addrid { get; set; }
    }

    public class PurchaseDetailsIu
    {
        public int Id { get; set; }
        public int TableIndex_Id { get; set; }
        public int EntryNo { get; set; }
        public string Account { get; set; }
        public string JobNo { get; set; }
        public string MawbMbl { get; set; }
        public string Narration { get; set; }
        public string InvoiceEuro { get; set; }
        public string DeductionEuro { get; set; }
        public string Rate { get; set; }
        public string MakerId { get; set; }
        public string Guid { get; set; }
        public string MakerIp { get; set; }
    }
    public class ReportConsoleSummary
    {
        public string TYPE { get; set; }
        public string CONSOLENOFR { get; set; }
        public string CONSOLENOTO { get; set; }
        public string CONS_MODE { get; set; }
        public string CITY { get; set; }
        public string IMPOTERCODE { get; set; }
    }
    public class AutoPurchase
    {
        public string ID { get; set; }
        public string ENTRYNO { get; set; }
        public string ENTRYDATE { get; set; }
        public string SUPPLIER { get; set; }
        public string BILLNO { get; set; }
        public string PAIDDT { get; set; }
        public string TOT_EURO { get; set; }
        public string StrFilename { get; set; }
        public string CATID { get; set; }
        public string SUPINVDT { get; set; }
        public string CMPID { get; set; }
        public string CITYCODE1 { get; set; }
        public string CMP_CODE { get; set; }
        public string MAKERIP { get; set; }
        public string GUID { get; set; }
        public string CITYCODE { get; set; }
        public string SUP_ADDRID { get; set; }

    }
}