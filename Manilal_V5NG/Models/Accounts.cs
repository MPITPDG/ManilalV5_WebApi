
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manilal_V5NG.Models
{
    public class consigneejobprofit
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string JobNoFrom { get; set; }
        public string JobNoTo { get; set; }
        public string SearchType { get; set; }
        public string DateType { get; set; }
        public string Mode { get; set; }
        public string citycode1 { get; set; }
        public string citycode { get; set; }
        public string cmpcode { get; set; }
        public string concode { get; set; }
        public string consgname { get; set; }
        public string username { get; set; }
        public string headerfromdt { get; set; }
        public string headertodt { get; set; }
    }
    public class EInvoice
    {

        //public string Version { get; set; } ="1.1";
        private string _Version = "1.1";
        public string Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }
        }
        //public Versiondtls versionDtls { get; set; }
        public tranDtls TranDtls { get; set; }
        //public List<Dates> pcdates { get; set; }
        public docDtls DocDtls { get; set; }
        public sellerDtls SellerDtls { get; set; }
        public buyerDtls BuyerDtls { get; set; }
        public valDtls Valdtls { get; set; }
        public List<itemlist> ItemList { get; set; }

    }
    public class Versiondtls
    {
        public string Version { get; set; }
    }
    public class tranDtls
    {

        public string TaxSch { get; set; }
        public string SupTyp { get; set; }
        public string IgstOnIntra { get; set; }
        public string RegRev { get; set; }
        public string EcmGstin { get; set; }
        // public string InvoiceNo { get; set; }

    }
    public class docDtls
    {

        public string Typ { get; set; }
        public string No { get; set; }
        public string Dt { get; set; }
        // public string InvoiceNo { get; set; }
    }
    public class sellerDtls
    {

        public string Gstin { get; set; }
        public string LglNm { get; set; }
        public string TrdNm { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Loc { get; set; }
        public Int32 Pin { get; set; }
        public string Stcd { get; set; }
        // public string InvoiceNo { get; set; }
    }
    public class buyerDtls
    {
        public string Gstin { get; set; }
        public string LglNm { get; set; }
        public string TrdNm { get; set; }
        public string Pos { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Loc { get; set; }
        public Int32 Pin { get; set; }
        public string Stcd { get; set; }
        //public string InvoiceNo { get; set; }
    }
    public class valDtls
    {
        public decimal AssVal { get; set; }
        public decimal IgstVal { get; set; }
        public decimal CgstVal { get; set; }
        public decimal SgstVal { get; set; }
        public double CesVal { get; set; }
        public double StCesVal { get; set; }
        public double Discount { get; set; }
        public double OthChrg { get; set; }
     
        public decimal RndOffAmt { get; set; }
        public decimal TotInvVal { get; set; }
    }
    public class itemlist
    {
        public string SlNo { get; set; }
        public string PrdDesc { get; set; }
        public string IsServc { get; set; }
        public string HsnCd { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double TotAmt { get; set; }
        public double Discount { get; set; }
        public double PreTaxVal { get; set; }
        public double AssAmt { get; set; }
        public double GstRt { get; set; }
        public double IgstAmt { get; set; }
        public double CgstAmt { get; set; }
        public double SgstAmt { get; set; }
        public double CesRt { get; set; }
        public double CesAmt { get; set; }
        public double CesNonAdvlAmt { get; set; }
        public double StateCesRt { get; set; }
        public double StateCesAmt { get; set; }
        public double StateCesNonAdvlAmt { get; set; }
        public double OthChrg { get; set; }
        public double TotItemVal { get; set; }

    }
    public class ApiResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
    public class StaffPurchaseInvoiceMaster
    {
        public string ID { get; set; }
        public string CMPID { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string CITYCODE { get; set; }
        public string USERNAME { get; set; }
        public string ENTRYNO { get; set; }
        public string ENTRYDT { get; set; }
        public string STATUS { get; set; }
        public string SUP_CODE { get; set; }
        public string SUP_NAME { get; set; }
        public string SUP_INVNO { get; set; }
        public string SUP_INVDT { get; set; }
        public string SUP_BILLRECEIVEDDT { get; set; }
        public string SUP_DUEDT { get; set; }
        public string PASSFLAG { get; set; }
        public string PASSEDBY { get; set; }
        public string PASSEDAMT { get; set; }
        public string INVAMT { get; set; }
        public string VOUCHERNO { get; set; }
        public string MAWBN0 { get; set; }
        public string FREIGHTG100235 { get; set; }
        public string SURCHARGEG101468 { get; set; }
        public string AIRFRTCOMMG100153 { get; set; }
        public string FRTREBATEG100186 { get; set; }
        public string NARRATION { get; set; }
        public string ACTUALAMOUNT { get; set; }
        public string VGUID { get; set; }
        public string MAKER_ID { get; set; }
        public string MAKER_IP { get; set; }
        public string ACTION { get; set; }
        public string DOCUMENTG100179 { get; set; }
        public string FK_SUP_ADDR_ID { get; set; }
        public string AMSENSEXP_G102024 { get; set; }
        public string MISCEXP_G102025 { get; set; }
    }


    public class StaffPurchaseInvoiceDtls
    {
        public string ID { get; set; }
        public string ENTRYNO { get; set; }
        public string CLIENT { get; set; }
        public string JOBNO { get; set; }
        public string DEDUCTION { get; set; }
        public string AMOUNT { get; set; }
        public string USERNAME { get; set; }
        public string NARRATION { get; set; }
        public string IS_NOT_EDIT_ABLE { get; set; }
        public string ITEMCODE { get; set; }
        public string VGUID { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string ITEM { get; set; }
        public string ACC_PURCHASEDTLS_ID { get; set; }
        public string STATUS { get; set; }
        public string IsJobReport { get; set; }
        public string ITEM_DATAVALUE { get; set; }
        public string SRPIPASSAMOUNT { get; set; }
         public string cmpid { get; set; }
        public string STR { get; set; }
        public string PUR_TAXABLE { get; set; }
        public string ISTDSAPP { get; set; }
        public string PUR_TDS { get; set; }
        public string MAWBNO { get; set; }
        public string SUPCODE { get; set; }
        public string MAWBFLAG { get; set; }
    }

    public class Authorisation
    {
        public string cmp_code { get; set; }
        public string citycode { get; set; }
        public string NOSTR { get; set; }
        public string CHKAuthorityFlag { get; set; }
        public string CMPID { get; set; }
        public string INVOICENO { get; set; }
        public string CRTNO { get; set; }
    }
    public class JournalVoucherMaster
    {
        public string ID { get; set; }
        public string CMPID { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string CITYCODE { get; set; }
        public string USERNAME { get; set; }
        public string ENTRYNO { get; set; }
        public string ENTRYDT { get; set; }
        public string STATUS { get; set; }
        public string NARRATION { get; set; }
        public string VGUID { get; set; }
        public string MAKER_ID { get; set; }
        public string MAKER_IP { get; set; }
        public string ACTION { get; set; }
       
    }

    public class JournalVoucherDtls
    {
        public string ID { get; set; }
        public string ENTRYNO { get; set; }
        public string CLIENT { get; set; }
        public string JOBNO { get; set; }
        public string BILLNO { get; set; }
        public string JV_TRN { get; set; }
        public string DEBIT { get; set; }
        public string CREDIT { get; set; }
        public string ENTRYTYPE { get; set; }
        public string NARRATION { get; set; }
        public string ITEMCODE { get; set; }
        public string DEPTID { get; set; }
        public string VGUID { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string ITEM { get; set; }
        public string DEPARTMENT { get; set; }
        public string JV_DTLS_ID { get; set; }
        public string STATUS { get; set; }
        public string ISJOBREPORT { get; set; }
        public string ITEM_DATAVALUE { get; set; }
        public string ISOLDENTRY { get; set; }

    }

    public class InvJobDtls
    {
        public string ID { get; set; }
        public string INV_NO { get; set; }
        public string INV_JOBNO { get; set; }
        public string INV_PKGS { get; set; }
        public string INV_GRWT { get; set; }
        public string VGUID { get; set; }
        public string ACC_JOBDTLS_ID { get; set; }
        public string CMPID { get; set; }

    }
    public class InvChrgeDtls
    {
        public string ID { get; set; }
        public string INV_NO { get; set; }
        public string INV_CHRGCODE { get; set; }
        public string INV_ACCOUNT { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string INV_DESC_CHRG { get; set; }
        public string INV_DESC1_CHRG1 { get; set; }
        public string INV_DESC2_CHRG1 { get; set; }
        public string INV_TAXABLE { get; set; }

        public string INV_AMOUNT { get; set; }
        public string INV_INRAMT { get; set; }
        public string INV_TAXABLE_AMOUNT { get; set; }
        public string INV_TAXABLE_INRAMT { get; set; }

        public string USERNAME { get; set; }
        public string VGUID { get; set; }
        public string ACC_CHARGDTLS_ID { get; set; }

        public string CMPID { get; set; }

        public string CMPCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string CITYCODE { get; set; }
        public string INV_QTY { get; set; }
        public string INV_RATE { get; set; }
        public string INV_CURRENCY { get; set; }
        public string INV_EXRATE { get; set; }

    }

    public class InvEnclosure
    {
        public string ID { get; set; }
        public string INV_NO { get; set; }
        public string INV_ENCLCODE { get; set; }
        public string INV_DESC { get; set; }
        public string INV_NUMBER { get; set; }
        public string USERNAME { get; set; }
        public string VGUID { get; set; }
        public string ACC_ENCLDTLS_ID { get; set; }
        public string CMPID { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string CITYCODE { get; set; }

    }
    public class InvDispatch
    {
        public string ID { get; set; }
        public string INV_NO { get; set; }
        public string INV_DESPCODE { get; set; }
        public string INV_DESC { get; set; }
        public string INV_NUMBER { get; set; }
        public string USERNAME { get; set; }
        public string VGUID { get; set; }
        public string ACC_DESPDTLS_ID { get; set; }
        public string CMPID { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string CITYCODE { get; set; }

    }
    public class InvoiceMain
    {
        public string CMPID { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string CITYCODE { get; set; }
        public string INV_NO { get; set; }
        public string INV_DATE { get; set; }
        public string INV_CLIENT { get; set; }
        public string INV_CLIENT_NM { get; set; }
        public string INV_SHIPPER { get; set; }
        public string INV_SHIPPER_NM { get; set; }
        public string INV_BILLTYPE { get; set; }
        public string INV_PKGS { get; set; }
        public string INV_TYPEOFPKG { get; set; }
        public string INV_NOOFPCS { get; set; }
        public string INV_TYPEOFPCS { get; set; }
        public string INV_CLIENTREF { get; set; }
        public string INV_WT { get; set; }
        public string INV_VOL { get; set; }
        public string INV_HAWBNO { get; set; }
        public string INV_HAWBDT { get; set; }
        public string INV_CARRIER { get; set; }
        public string INV_GOODS { get; set; }
        public string INV_CUR { get; set; }
        public string INV_CUR_NM { get; set; }
        public string INV_CURINR { get; set; }
        public string INV_CURRATE { get; set; }
        public string INV_CURRATE1 { get; set; }
        public string INV_TAX { get; set; }
        public string INV_ADVANCE { get; set; }
        public string DETAILNARRATIONSTR { get; set; }
        public string NARRATIONID { get; set; }
        public string NARRATIONDESC { get; set; }
        public string VGUID { get; set; }
        public string MAKER_ID { get; set; }
        public string MAKER_IP { get; set; }       
        public string SHIPINGBILLNO { get; set; }
        public string SHIPBILLDT { get; set; }
        public string paydt { get; set; }
        public string INV_TYPE { get; set; }
        public string CLIENTCONT { get; set; }
        public string INVSTARTDATE { get; set; }
    }

    public class creditnoteBillno
    {
        public string ID { get; set; }
        public string CRT_NO { get; set; }
        public string CRT_INVNO { get; set; }
        public string CRT_AMOUNT { get; set; }
        public string CRT_ADJUST { get; set; }
        public string CMPID { get; set; }
        public string VGUID { get; set; }
        public string ACC_INVDTLS_ID { get; set; }
        public string INVSTATUS { get; set; }
        public string CRT_CLIENT { get; set; }
    }
    public class creditnote
    {
        public string CMPID { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string CITYCODE { get; set; }
        public string ID { get; set; }
        public string CRT_NO { get; set; }
        public string CRT_DATE { get; set; }
        public string CRT_CLIENT { get; set; }
        public string CRT_SHIPPER { get; set; }
        public string CRT_BILLTYPE { get; set; }
        public string CRT_PKGS { get; set; }
        public string CRT_TYPEOFPKG { get; set; }
        public string CRT_NOOFPCS { get; set; }
        public string CRT_TYPEOFPCS { get; set; }
        public string CRT_CLIENTREF { get; set; }
        public string CRT_WT { get; set; }
        public string CRT_VOL { get; set; }
        public string CRT_HAWBNO { get; set; }
        public string CRT_HAWBDT { get; set; }
        public string CRT_CARRIER { get; set; }
        public string CRT_GOODS { get; set; }
        public string CRT_CUR { get; set; }
        public string CRT_CURINR { get; set; }
        public string CRT_CURRATE { get; set; }
        public string CRT_CURRATE1 { get; set; }
        public string CRT_TAX { get; set; }
        public string CRT_CUR_NM { get; set; }
        public string NARRATIONDESC { get; set; }
        public string MAKERIP { get; set; }
        public string BILLTOADDID { get; set; }
        public string VGUID { get; set; }
        public string CN_TYPE { get; set; }
    }
    public class BRBPCRCPCE

    {
        public string CMPID { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string CITYCODE { get; set; }
        public string USERNAME { get; set; }
        public string ENTRYNO { get; set; }
        public string ENTRYDT { get; set; }
        public string STATUS { get; set; }
        public string OURBANK { get; set; }
        public string OURBANKNM { get; set; }
        public string CHEQUETYPE { get; set; }
        public string CHEQUENO { get; set; }
        public string CHEQUEDT { get; set; }
        public string BANK { get; set; }
        public string NARRATION { get; set; }
        public string ACTUALAMOUNT { get; set; }
        public string VGUID { get; set; }
        public string MAKER_ID { get; set; }
        public string MAKER_IP { get; set; }
        public string NOTOVERFLAG { get; set; }
        public string ACTION { get; set; }
        public string PAYEENAME { get; set; }
        public string MAKERIP { get; set; }
        public string BANKREFNO { get; set; }
    }

    public class BRBPCRCPCEDTL

    {
        public string ID { get; set; }
        public string ENTRYNO { get; set; }
        public string CLIENT { get; set; }
        public string JOBNO { get; set; }
        public string BILLNO { get; set; }
        public string DEDUCTION { get; set; }
        public string AMOUNT { get; set; }
        public string ENTRYTYPE { get; set; }
        public string EMP_CODE { get; set; }
        public string USERNAME { get; set; }
        public string CRPARENTENTRYNO { get; set; }
        public string NARRATION { get; set; }
        public string IS_NOT_EDIT_ABLE { get; set; }
        public string ITEMCODE { get; set; }
        public string DEPTID { get; set; }
        public string VGUID { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string ITEM { get; set; }
        public string DEPARTMENT { get; set; }
        public string ACC_BANKDTLS_ID { get; set; }
        public string STATUS { get; set; }
        public string ISJOBREPORT { get; set; }
        public string EMP_CODE_VALUE { get; set; }
        public string EMP_CODE_TEXT { get; set; }
        public string ITEM_DATAVALUE { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string ISOLDENTRY { get; set; }
        public string STRINGTEXT { get; set; }
        public string IS_GST { get; set; }
        public string ISTDSCALC { get; set; }
        public string IS_TDS { get; set; }
        public string CMPID { get; set; }
        public string GSTRATE { get; set; }

    }
    public class ChequeStock

    {
        public string CHQ_CREATER_ID { get; set; }
        public string USER_IP { get; set; }
        public string CHQ_CREATED_DATE { get; set; }
        public string CMP_CODE { get; set; }
        public string CITY_CODE { get; set; }
        public string OURBANK { get; set; }
        public string STCHEQUENO { get; set; }
        public string ENDCHEQUENO { get; set; }

    }


    public class ProformaConvert
    {
        public string PROF_NO { get; set; }
        public string CMPID { get; set; }
        public string VGUID { get; set; }
    }
}
