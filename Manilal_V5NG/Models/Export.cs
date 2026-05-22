using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manilal_V5NG.Models
{
    public class ConsignmentDetails
    {
        public int cmpid { get; set; }
        public string citycode { get; set; }
        public string cmpcode { get; set; }

        //-- vessel port'
        public int TBL_INDEXID { get; set; }
        public string PK_PORTID { get; set; }
        public string VSL_RTNO { get; set; }
        public string ROTATION { get; set; }
        public string PORT { get; set; }
        public string ETA { get; set; }
        public string ARRIVAL { get; set; }
        public string ETD { get; set; }
        public string SAILING { get; set; }
        public string CARTING { get; set; }
        public string VSLDELAY { get; set; }
        public string NOTCALLED { get; set; }
        public string USERNAME { get; set; }

        public string GUID { get; set; }
        //----vessel agent
        public int TBL_INDEXIDAGT { get; set; }
        public string PK_AGTID { get; set; }
        public string VSL_AGENT { get; set; }
        public string AGT_LINER { get; set; }
        public string AGT_CARTPLACE { get; set; }
        public string AGT_CARTCLERK { get; set; }

        //----------vessel mst
        public string PK_id { get; set; }
        public string VSL_NAME { get; set; }
        public string VSL_VOYNO { get; set; }
        public string VSL_SNAME { get; set; }
        public string MAKERIP { get; set; }

        //----------------------------------------end of vessel 
    }

    public class FCRGeneration
    {
        public string EXPTNO { get; set; }
        public string jobnos { get; set; }
        public string POD { get; set; }
        public string Citycode { get; set; }
        public string citycode1 { get; set; }
        public string FCRNO { get; set; }
        public string FCRDT { get; set; }
        public string FRTYPE { get; set; }
        public string FRTCur { get; set; }
        public string FRTAMT { get; set; }
        public string HBLType { get; set; }
        public string DeliveryTo { get; set; }
        public string cmpcode { get; set; }
        public string username { get; set; }
        public string Types { get; set; }
        public string switchhbl { get; set; }
    }

    public class swichFCRGeneration
    {
        public string FCRNO { get; set; }
        public string CITYCODE1 { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE { get; set; }
        public string USERNAME { get; set; }
    }

        public class FCRPrintview
    {
        public string SHIPPER { get; set; }
        public string CONSIGNEE { get; set; }
        public string NOTIFYPARTY { get; set; }
        public string CARRIER { get; set; }
        public string APPLYTO { get; set; }
        public string VESSEL { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string PODEL { get; set; }
        public string MARKSANDNOS { get; set; }
        public string NOOFPKGS { get; set; }
        public string ITCDESC { get; set; }
        public string GRWT { get; set; }
        public string VOL { get; set; }
        public string MISC { get; set; }
        public string PLACEDATE { get; set; }
        public string PP { get; set; }
        public string CC { get; set; }
        public string TOTPP { get; set; }
        public string TOTCC { get; set; }
        public string RECPTPLACE { get; set; }
        public string EXPNO { get; set; }
        public string FCRNo { get; set; }
        public string UERNAME { get; set; }
        public string CITYCODE { get; set; }
        public string rider { get; set; }

    }
    public class vslSearch
    {
        public string SEARCHMODE { get; set; }
        public string VSLNAME { get; set; }
        public string VSL_VOY { get; set; }
        public string CITYCODE { get; set; }
    }
    public class container
    {
        public string vsl_rtno { get; set; }
        public string Port { get; set; }
        public string ContainerID { get; set; }

    }

    public class containerIU
    {
        public string vsl_rtno { get; set; }
        public string Port { get; set; }
        public string ContainerID { get; set; }

        public string EXPT_AGENT { get; set; }
        public string CONTAINERNO { get; set; }
        public string CONTAINERSIZE { get; set; }
        public string CONTAINERSIZE1 { get; set; }
        public string CONTAINERSTATUS { get; set; }
        public string DESTPORT { get; set; }
        public string AGTSEALNO { get; set; }
        public string HSTUFFED { get; set; }
        public string STUFFWHERE { get; set; }
        public string CUSTSEALNO { get; set; }
        public string FREIGHTUSD { get; set; }
        public string BAFUSD { get; set; }
        public string STUFFWHERE1 { get; set; }
        public string STUFFWHERE2 { get; set; }
        public string STUFFINGCITY { get; set; }
        public string REMARK { get; set; }
        public string FREIGHT { get; set; }
        public string LINERCONTRACT { get; set; }
        public string THCINR { get; set; }
        public string OCUR1 { get; set; }
        public string OCURRATE1 { get; set; }
        public string OCUR2 { get; set; }
        public string OCURRATE2 { get; set; }
        public string DCUR1 { get; set; }
        public string DCURRATE1 { get; set; }
        public string DCUR2 { get; set; }
        public string DCURRATE2 { get; set; }
        public string FREIGHTCUR { get; set; }
        public string BAFCUR { get; set; }
        public string THCNAME { get; set; }
        public string THCCUR { get; set; }
        public string OTHERNAME { get; set; }
        public string OTHERCUR { get; set; }
        public string OTHERAMT { get; set; }
        public string SHPGLINE { get; set; }
        public string BCARRIERNO { get; set; }
        public string BCARRIERDT { get; set; }
        public string MOVETYPE { get; set; }
        public string cmpid { get; set; }
        public string GUID { get; set; }
        public string cmpcode { get; set; }
        public string MakerIP { get; set; }
        public string CITYCODE { get; set; }
        public string contract { get; set; }
        public string CO2_Emission_Level { get; set; }
    }

    public class MainConsignmentDetails
    {
        public int cmpid { get; set; }
        public string citycode { get; set; }
        public string mode { get; set; }
        public string concode { get; set; }
        public string vesselcode { get; set; }
        public string vesselport { get; set; }
    }

    public class Package
    {
        public string indexid { get; set; }
        public string pkgnoid { get; set; }
        public string exptno { get; set; }
        public string pkgtype { get; set; }
        public string pkgfrom { get; set; }
        public string pkgto { get; set; }
        public string pkgalphabet { get; set; }
        public string userid { get; set; }
        public string guid { get; set; }
    }

    public class Itc
    {
        public string itctype { get; set; }
        public string hditccodeid { get; set; }
        public string hdexptno { get; set; }
        public string itccode { get; set; }
        public string itcfobinr { get; set; }
        public string itcsrno { get; set; }
        public string itcunitone { get; set; }
        public string itctypeone { get; set; }
        public string itcnotice { get; set; }
        public string itcconditionno { get; set; }
        public string itcunittwo { get; set; }
        public string itctypetwo { get; set; }
        public string itcpercent { get; set; }
        public string itcpercenta { get; set; }
        public string itcperunit { get; set; }
        public string dbkamt { get; set; }
        public string itcgroupcode { get; set; }
        public string itcdescription { get; set; }
        public string userid { get; set; }
        public string hditcid { get; set; }
        public string guid { get; set; }
        public string hditcdescid { get; set; }
    }

    public class Order
    {
        public string ordertype { get; set; }
        public string ordernoid { get; set; }
        public string orderid { get; set; }
        public string exptno { get; set; }
        public string orderno { get; set; }
        public string orderpiece { get; set; }
        public string ordertypeofpiece { get; set; }
        public string orderwarehouse { get; set; }
        public string orderpackage { get; set; }
        public string ordergrwt { get; set; }
        public string ordervolume { get; set; }
        public string ordernetwt { get; set; }
        public string orderchblwt { get; set; }
        public string orderitemdesc { get; set; }
        public string orderlsddt { get; set; }
        public string orderreferenceno { get; set; }
        public string orderfobval { get; set; }
        public string ordercurrency { get; set; }
        public string orderdrndt { get; set; }
        public string userid { get; set; }
        public string guid { get; set; }
        public string ordercneedept { get; set; }
        public string ordercontainerno { get; set; }
        public string ordericshscode { get; set; }
        public string ordericshsdescription { get; set; }
        public string concode { get; set; }
    }

    public class Main
    {
        public string PkId { get; set; }
        public string exptno { get; set; }
        public string expt_mode { get; set; }
        public string expt_exporter { get; set; }
        public string expt_billto { get; set; }
        public string manufacturer { get; set; }
        public string expt_consignee { get; set; }
        public string expt_bank { get; set; }
        public string notifybuyer { get; set; }
        public string expt_buyer { get; set; }
        public string expt_srcagt { get; set; }
        public string CmpId { get; set; }
        public string MakerIp { get; set; }
        public string Agent { get; set; }
        public string SubAgent { get; set; }
        public string SeviceType { get; set; }
        public string expt_vessel { get; set; }
        public string expt_noofpkgs { get; set; }
        public string expt_typeofpkgs { get; set; }
        public string expt_noofpcs { get; set; }
        public string expt_typeofpcs { get; set; }
        public string grosswt { get; set; }
        public string netwt { get; set; }
        public string volume { get; set; }
        public string chblwt { get; set; }
        public string invno { get; set; }
        public string invdate { get; set; }
        public string docrecddt { get; set; }
        public string incoterm { get; set; }
        public string freight { get; set; }
        public string shipbilltype { get; set; }
        public string pol { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE { get; set; }
    }

    public class Consignment
    {
        public string Exptno { get; set; }
        public string Expt_Guid { get; set; }
        public string Expt_Mode { get; set; }
        public string Expt_Exporter { get; set; }
        public string Expt_Billto { get; set; }
        public string Expt_Consignee { get; set; }
        public string Expt_Docrecd { get; set; }
        public string Expt_Ldgport { get; set; }
        public string Expt_Grino { get; set; }
        public string Expt_Gridate { get; set; }
        public string Expt_Invno { get; set; }
        public string Expt_Invdate { get; set; }
        public string Expt_Invtype { get; set; }
        public string Expt_Cur { get; set; }
        public string Expt_Curname { get; set; }
        public string Expt_Currate { get; set; }
        public string Expt_Curinrrate { get; set; }
        public string Expt_Invamt { get; set; }
        public string Expt_Insamt { get; set; }
        public string Expt_Freight { get; set; }
        public string Expt_Fob { get; set; }
        public string Expt_Shipbilltype { get; set; }
        public string Expt_Noofpkgs { get; set; }
        public string Expt_Typeofpkgs { get; set; }
        public string Expt_Noofpcs { get; set; }
        public string Expt_Typeofpcs { get; set; }
        public string Expt_Grwt { get; set; }
        public string Expt_Netwt { get; set; }
        public string Expt_Volume { get; set; }
        public string Expt_Mktvalue { get; set; }
        public string Expt_Vessel { get; set; }
        public string Expt_Vslagent { get; set; }
        public string Expt_Pod { get; set; }
        public string Expt_It { get; set; }
        public string Expt_Destcity { get; set; }
        public string Expt_Destcountry { get; set; }
        public string Expt_Frt { get; set; }
        public string Expt_Remarks { get; set; }
        public string Citycode { get; set; }
        public string Cmpcode { get; set; }
        public string Invcommission { get; set; }
        public string Invdiscount { get; set; }
        public string Invdeductamt { get; set; }
        public string Invdeductdesc { get; set; }
        public string Implable { get; set; }
        public string Billentryno { get; set; }
        public string Billentrydt { get; set; }
        public string Sbvalue { get; set; }
        public string Sbamount { get; set; }
        public string Sbbooktype { get; set; }
        public string Arformno { get; set; }
        public string Arformdt { get; set; }
        public string Sbprorecptno { get; set; }
        public string Sbprorecptdt { get; set; }
        public string Sbexempt1 { get; set; }
        public string Sbexempt2 { get; set; }
        public string Sbexempt3 { get; set; }
        public string Sbdeecbookno { get; set; }
        public string Sbdeecbookdt { get; set; }
        public string Sbdeeclicno { get; set; }
        public string Sbgroupcode { get; set; }
        public string Sbsionno { get; set; }
        public string Sbexpbookno { get; set; }
        public string Sbexpbookdt { get; set; }
        public string Sbduty { get; set; }
        public string Sbdutyamt { get; set; }
        public string Sbcess { get; set; }
        public string Notifybuyer { get; set; }
        public string Expt_Buyer { get; set; }
        public string Natureofpayment { get; set; }
        public string Expt_Packing { get; set; }
        public string Commname { get; set; }
        public string Commaddr1 { get; set; }
        public string Commaddr2 { get; set; }
        public string Commissionrate { get; set; }
        public string Division { get; set; }
        public string Range { get; set; }
        public string Arformno1 { get; set; }
        public string Arformdt1 { get; set; }
        public string Commissionrate1 { get; set; }
        public string Division1 { get; set; }
        public string Range1 { get; set; }
        public string Arformno2 { get; set; }
        public string Arformdt2 { get; set; }
        public string Commissionrate2 { get; set; }
        public string Division2 { get; set; }
        public string Range2 { get; set; }
        public string Arformno3 { get; set; }
        public string Arformdt3 { get; set; }
        public string Commissionrate3 { get; set; }
        public string Division3 { get; set; }
        public string Range3 { get; set; }
        public string Exptcontractno { get; set; }
        public string Periodofpayment { get; set; }
        public string Expt_Quotavaliddt { get; set; }
        public string Expt_Quotaobtaindt { get; set; }
        public string Expt_Quotaexpirydt { get; set; }
        public string Manufacturer { get; set; }
        public string Quotacertno { get; set; }
        public string Quotacertno1 { get; set; }
        public string Quotacertno2 { get; set; }
        public string Yr { get; set; }
        public string Expt_Grwtshipper { get; set; }
        public string Expt_Volumeshipper { get; set; }
        public string Expt_Cartplace { get; set; }
        public string Expt_Bank { get; set; }
        public string Expt_Srcagt { get; set; }
        public string Expt_Chblwt { get; set; }
        public string Vsl_Code { get; set; }
        public string Vsl_Port { get; set; }
        public string Username { get; set; }
        public string Id { get; set; }
        public string Citycode1 { get; set; }
        public string Recddocstr { get; set; }
        public string Calldocstr { get; set; }
        public string Cartdate { get; set; }
        public string Prealertdate { get; set; }
        public string Airlinename { get; set; }
        public string Planflightno { get; set; }
        public string Planflightdate { get; set; }
        public string Actflightno { get; set; }
        public string Actflightdate { get; set; }
        public string Mawbdest { get; set; }
        public string Mawbfrt { get; set; }
        public string Tranport1 { get; set; }
        public string Flightno1 { get; set; }
        public string Etd1 { get; set; }
        public string Eta1 { get; set; }
        public string Tranport2 { get; set; }
        public string Flightno2 { get; set; }
        public string Etd2 { get; set; }
        public string Eta2 { get; set; }
        public string Mawbno { get; set; }
        public string Mawbdate { get; set; }
        public string Hawbno { get; set; }
        public string Hawbdate { get; set; }
        public string Marks1 { get; set; }
        public string Marks2 { get; set; }
        public string Marks3 { get; set; }
        public string Marks4 { get; set; }
        public string Marks5 { get; set; }
        public string Marks6 { get; set; }
        public string Marks7 { get; set; }
        public string Marks8 { get; set; }
        public string Marks9 { get; set; }
        public string Marks10 { get; set; }
        public string Marks11 { get; set; }
        public string Marks12 { get; set; }
        public string Marks13 { get; set; }
        public string Marks14 { get; set; }
        public string Marks15 { get; set; }
        public string Makerip { get; set; }
        public string Isdiffair { get; set; }
        public string Exwork { get; set; }
        public string Customclr { get; set; }
        public string Freightfrd { get; set; }
        public string ActualDocReceived { get; set; }
        public string SubAgentId { get; set; }
        public string PKID { get; set; }
        public string CmpId { get; set; }
        public string MakerIp { get; set; }
        public string agentid { get; set; }
        public string MODEOF_SHIPMENT { get; set; }
        public string FK_TERMINALID { get; set; }
    }

    public class ConsignmentLogCompleted
    {
        public string status { get; set; }
        public string pagetype { get; set; }
        public string guid { get; set; }
        public string cmpid { get; set; }
    }

    public class Search
    {
        public string Type { get; set; }
        public string VslName { get; set; }
        public string VoyageNo { get; set; }
    }

    public class CommonSearch
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }
        public string Type5 { get; set; }
        public string Type6 { get; set; }
        public string CmpId { get; set; }
        public string RoleType { get; set; }
        public string CodeCity { get; set; }
    }

    public class CommonThree
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string CmpId { get; set; }
        public string RoleType { get; set; }
        public string CodeCity { get; set; }
        public string GUID { get; set; }
    }

    public class CommonFour
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }
        public string CmpId { get; set; }
        public string RoleType { get; set; }
        public string CodeCity { get; set; }
    }

    public class CommonFive
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }
        public string Type5 { get; set; }
        public string CmpId { get; set; }
        public string RoleType { get; set; }
        public string CodeCity { get; set; }
    }

    public class CommonSix
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }
        public string Type5 { get; set; }
        public string Type6 { get; set; }
        public string CmpId { get; set; }
        public string RoleType { get; set; }
        public string CodeCity { get; set; }
    }

    public class CommonSeven
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }
        public string Type5 { get; set; }
        public string Type6 { get; set; }
        public string Type7 { get; set; }
        public string CmpId { get; set; }
        public string RoleType { get; set; }
        public string CodeCity { get; set; }
    }

    public class CommonEight
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }
        public string Type5 { get; set; }
        public string Type6 { get; set; }
        public string Type7 { get; set; }
        public string Type8 { get; set; }
        public string CmpId { get; set; }
        public string RoleType { get; set; }
        public string CodeCity { get; set; }
    }

    public class CommonNine
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }
        public string Type5 { get; set; }
        public string Type6 { get; set; }
        public string Type7 { get; set; }
        public string Type8 { get; set; }
        public string Type9 { get; set; }
        public string CmpId { get; set; }
        public string RoleType { get; set; }
        public string CodeCity { get; set; }
    }

    public class CommonTen
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }
        public string Type5 { get; set; }
        public string Type6 { get; set; }
        public string Type7 { get; set; }
        public string Type8 { get; set; }
        public string Type9 { get; set; }
        public string Type10 { get; set; }
        public string CmpId { get; set; }
        public string RoleType { get; set; }
        public string CodeCity { get; set; }
    }

    public class MawbRating
    {
        public string EXPTNO { get; set; }
        public string MAWBNO { get; set; }
        public string CITYCODE { get; set; }
        public string CHBL_WGT { get; set; }
        public string GROSS_WGT { get; set; }
        public string CHBL_WGT_USER { get; set; }
        public string GROSS_WGT_USER { get; set; }
        public string FREIGHT { get; set; }
        public string FRT_CHARGEABLE_AS_TAR { get; set; }
        public string FRT_CHARGEABLE_AS_NET { get; set; }
        public string FRT_PAYABLE_ON_TAR { get; set; }
        public string FRT_RATE_PER_KG_TAR { get; set; }
        public string FRT_RATE_TAR { get; set; }
        public string FRT_PAYABLE_ON_NET { get; set; }
        public string FRT_RATE_PER_KG_NET { get; set; }
        public string FRT_RATE_NET { get; set; }
        public string FSC_PAYABLE_ON_TAR { get; set; }
        public string FSC_RATE_PER_KG_TAR { get; set; }
        public string FSC_RATE_TAR { get; set; }
        public string FSC_PAYABLE_ON_NET { get; set; }
        public string FSC_RATE_PER_KG_NET { get; set; }
        public string FSC_RATE_NET { get; set; }
        public string IRC_PAYABLE_ON_TAR { get; set; }
        public string IRC_RATE_PER_KG_TAR { get; set; }
        public string IRC_RATE_TAR { get; set; }
        public string IRC_PAYABLE_ON_NET { get; set; }
        public string IRC_RATE_PER_KG_NET { get; set; }
        public string IRC_RATE_NET { get; set; }
        public string XRAY_PAYABLE_ON_TAR { get; set; }
        public string XRAY_RATE_PER_KG_TAR { get; set; }
        public string XRAY_RATE_TAR { get; set; }
        public string XRAY_PAYABLE_ON_NET { get; set; }
        public string XRAY_RATE_PER_KG_NET { get; set; }
        public string XRAY_RATE_NET { get; set; }
        public string MC_PAYABLE_ON_TAR { get; set; }
        public string MC_RATE_PER_KG_TAR { get; set; }
        public string MC_RATE_TAR { get; set; }
        public string MC_PAYABLE_ON_NET { get; set; }
        public string MC_RATE_PER_KG_NET { get; set; }
        public string MC_RATE_NET { get; set; }
        public string CTG_PAYABLE_ON_TAR { get; set; }
        public string CTG_RATE_PER_KG_TAR { get; set; }
        public string CTG_RATE_TAR { get; set; }
        public string CTG_PAYABLE_ON_NET { get; set; }
        public string CTG_RATE_PER_KG_NET { get; set; }
        public string CTG_RATE_NET { get; set; }
        public string DUE_CARRIER_TAR { get; set; }
        public string DUE_CARRIER_NET { get; set; }
        public string HAWB_TAR { get; set; }
        public string HAWB_NET { get; set; }
        public string PCA_TAR { get; set; }
        public string PCA_NET { get; set; }
        public string DUE_AGENT_TAR { get; set; }
        public string DUE_AGENT_NET { get; set; }
        public string TOTAL_TAR { get; set; }
        public string TOTAL_NET { get; set; }
        public string OTHER_CHRG_TAR { get; set; }
        public string OTHER_CHRG_NET { get; set; }
        public string REMARK { get; set; }
        public string AMS_RATE_TAR { get; set; }
        public string AMS_RATE_NET { get; set; }
        public string OTHER_NAME1 { get; set; }
        public string OTHER_NAME2 { get; set; }
        public string OTHER_RATE1_TAR { get; set; }
        public string OTHER_RATE2_TAR { get; set; }
        public string OTHER_RATE1_NET { get; set; }
        public string OTHER_RATE2_NET { get; set; }
        public string OTHER_RATE1_TAR_CAL { get; set; }
        public string OTHER_RATE2_TAR_CAL { get; set; }
        public string OTHER_RATE1_NET_CAL { get; set; }
        public string OTHER_RATE2_NET_CAL { get; set; }
        public string ISNETEDIT { get; set; }
        public string ISMIN { get; set; }
        public string SUPPLIER_NET { get; set; }
        public string AIR_FRT_COMM_NET { get; set; }
        public string FRT_REBATE_NET { get; set; }
        public string TDS_NET { get; set; }
        public string SERVICE_TAX_NET { get; set; }
        public string FRT_RATE_TAR_FRT { get; set; }
        public string FSC_RATE_TAR_FRT { get; set; }
        public string IRC_RATE_TAR_FRT { get; set; }
        public string XRAY_RATE_TAR_FRT { get; set; }
        public string MC_RATE_TAR_FRT { get; set; }
        public string CTG_RATE_TAR_FRT { get; set; }
        public string AMS_RATE_TAR_FRT { get; set; }
        public string HAWB_RATE_TAR_FRT { get; set; }
        public string PCA_RATE_TAR_FRT { get; set; }
        public string OTHER_RATE_TAR_FRT { get; set; }
        public string FRT_RATE_NET_FRT { get; set; }
        public string FSC_RATE_NET_FRT { get; set; }
        public string IRC_RATE_NET_FRT { get; set; }
        public string XRAY_RATE_NET_FRT { get; set; }
        public string MC_RATE_NET_FRT { get; set; }
        public string CTG_RATE_NET_FRT { get; set; }
        public string AMS_RATE_NET_FRT { get; set; }
        public string HAWB_RATE_NET_FRT { get; set; }
        public string PCA_RATE_NET_FRT { get; set; }
        public string OTHER_RATE_NET_FRT { get; set; }
        public string OTHER_RATE1_TAR_FRT { get; set; }
        public string OTHER_RATE2_TAR_FRT { get; set; }
        public string DUE_CARRIER_TAR_CC { get; set; }
        public string DUE_AGENT_TAR_CC { get; set; }
        public string TOTAL_TAR_CC { get; set; }
        public string OTHER_RATE1_NET_FRT { get; set; }
        public string OTHER_RATE2_NET_FRT { get; set; }
        public string DUE_CARRIER_NET_CC { get; set; }
        public string DUE_AGENT_NET_CC { get; set; }
        public string TOTAL_NET_CC { get; set; }
        public string TDS_ACCTCODE { get; set; }
        public string SERVICETAX_ACCTCODE { get; set; }
        public string CmpCode { get; set; }
        public string CmpId { get; set; }
        public string MakerIp { get; set; }
        public string AGENTS_RATE { get; set; }
        public string THC_PAYABLE_ON_TAR { get; set; }
        public string THC_RATE_PER_KG_TAR { get; set; }
        public string THC_RATE_TAR { get; set; }
        public string THC_PAYABLE_ON_NET { get; set; }
        public string THC_RATE_PER_KG_NET { get; set; }
        public string THC_RATE_NET { get; set; }
        public string THC_RATE_TAR_FRT { get; set; }
        public string THC_RATE_NET_FRT { get; set; }
        public string BUSINES_PROMO_NET { get; set; }
        public string BP_PAYABLE_ON_TAR { get; set; }
        public string BP_RATE_PER_KG_TAR { get; set; }
        public string BP_RATE_TAR { get; set; }
        public string BP_PAYABLE_ON_NET { get; set; }
        public string BP_RATE_PER_KG_NET { get; set; }
        public string BP_RATE_NET { get; set; }
        public string BP_RATE_TAR_FRT { get; set; }
        public string BP_RATE_NET_FRT { get; set; }

        public string DEST_TRUCKING_PAYABLE_ON_TAR { get; set; }
        public string DEST_TRUCKING_RATE_PER_KG_TAR { get; set; }
        public string DEST_TRUCKING_RATE_TAR { get; set; }
        public string DEST_TRUCKING_PAYABLE_ON_NET { get; set; }
        public string DEST_TRUCKING_RATE_PER_KG_NET { get; set; }
        public string DEST_TRUCKING_RATE_NET { get; set; }
        public string DEST_TRUCKING_RATE_TAR_FRT { get; set; }
        public string DEST_TRUCKING_RATE_NET_FRT { get; set; }
    }

    public class HawbRating
    {
        public string HAWBNO { get; set; }
        public string PPCHRG_SELLING { get; set; }
        public string CCCHRG_SELLING { get; set; }
        public string PPTOTAGT_SELLING { get; set; }
        public string PPTOTCARR_SELLING { get; set; }
        public string PPTOT_SELLING { get; set; }
        public string CCTOT_SELLING { get; set; }
        public string PP_SCHRG_FSC_SELL { get; set; }
        public string PP_SCHRG_IRC_SELL { get; set; }
        public string PP_SCHRG_XRAY_SELL { get; set; }
        public string CC_SCHRG_FSC_SELL { get; set; }
        public string CC_SCHRG_IRC_SELL { get; set; }
        public string CC_SCHRG_XRAY_SELL { get; set; }
        public string REMARK { get; set; }
        public string IS_AGREED_RATED { get; set; }
        public string FREIGHT_RATE_PER_KG { get; set; }
        public string PREPAID_PER { get; set; }
        public string COLLECT_PER { get; set; }
        public string FREIGHT_CHARGABLE_AS { get; set; }
        public string FRT_RATE_SCHRG_FSC_PO { get; set; }
        public string FRT_RATE_SCHRG_IRC_PO { get; set; }
        public string FRT_RATE_SCHRG_XRAY_PO { get; set; }
        public string RATE_AGREED_BY { get; set; }
        public string RATE_AGREED_ON { get; set; }
        public string FREIGHT_RATE_BASIC { get; set; }
        public string FRT_RATE_SCHRG_FSC { get; set; }
        public string FRT_RATE_SCHRG_IRC { get; set; }
        public string FRT_RATE_SCHRG_XRAY { get; set; }
        public string CHARGEBLE_WT { get; set; }
        public string GROSS_WT { get; set; }
        public string EXCH_RATE { get; set; }
        public string EXCH_CUR { get; set; }
        public string INR_RATE { get; set; }
        public string CCCHRG_SELLING_CUR { get; set; }
        public string CC_SCHRG_FSC_SELL_CUR { get; set; }
        public string CC_SCHRG_IRC_SELL_CUR { get; set; }
        public string CC_SCHRG_XRAY_SELL_CUR { get; set; }
        public string CCCHRG_SELLING_INR { get; set; }
        public string CC_SCHRG_FSC_SELL_INR { get; set; }
        public string CC_SCHRG_IRC_SELL_INR { get; set; }
        public string CC_SCHRG_XRAY_SELL_INR { get; set; }
        public string CCTOTAGT_SELLING_INR { get; set; }
        public string CCTOTCARR_SELLING_INR { get; set; }
        public string PPCHRG_SELLING_CUR { get; set; }
        public string PPCHRG_SELLING_INR { get; set; }
        public string PP_SCHRG_FSC_SELL_CUR { get; set; }
        public string PP_SCHRG_FSC_SELL_INR { get; set; }
        public string PP_SCHRG_IRC_SELL_CUR { get; set; }
        public string PP_SCHRG_IRC_SELL_INR { get; set; }
        public string PP_SCHRG_XRAY_SELL_CUR { get; set; }
        public string PP_SCHRG_XRAY_SELL_INR { get; set; }
        public string FREIGHT_RATE_BASIC_PO { get; set; }
        public string FRT_RATE_MC_PO { get; set; }
        public string FRT_RATE_MC { get; set; }
        public string PP_MC_SELL { get; set; }
        public string CC_MC_SELL { get; set; }
        public string CC_MC_SELL_CUR { get; set; }
        public string CC_MC_SELL_INR { get; set; }
        public string FRT_RATE_CTG_PO { get; set; }
        public string FRT_RATE_CTG { get; set; }
        public string PP_CTG_SELL { get; set; }
        public string CC_CTG_SELL { get; set; }
        public string CC_CTG_SELL_CUR { get; set; }
        public string CC_CTG_SELL_INR { get; set; }
        public string PP_HAWB_SELL { get; set; }
        public string CC_HAWB_SELL { get; set; }
        public string CC_HAWB_SELL_CUR { get; set; }
        public string CC_HAWB_SELL_INR { get; set; }
        public string PP_PCA_SELL { get; set; }
        public string CC_PCA_SELL { get; set; }
        public string CC_PCA_SELL_CUR { get; set; }
        public string CC_PCA_SELL_INR { get; set; }
        public string PP_OTHER_SELL { get; set; }
        public string CC_OTHER_SELL { get; set; }
        public string CC_OTHER_SELL_CUR { get; set; }
        public string CC_OTHER_SELL_INR { get; set; }
        public string PP_MC_SELL_CUR { get; set; }
        public string PP_MC_SELL_INR { get; set; }
        public string PP_CTG_SELL_CUR { get; set; }
        public string PP_CTG_SELL_INR { get; set; }
        public string PP_HAWB_SELL_CUR { get; set; }
        public string PP_HAWB_SELL_INR { get; set; }
        public string PP_PCA_SELL_CUR { get; set; }
        public string PP_PCA_SELL_INR { get; set; }
        public string PP_OTHER_SELL_CUR { get; set; }
        public string PP_OTHER_SELL_INR { get; set; }
        public string PP_DC_SELL { get; set; }
        public string PP_DC_SELL_CUR { get; set; }
        public string PP_DC_SELL_INR { get; set; }
        public string CC_DC_SELL { get; set; }
        public string CC_DC_SELL_CUR { get; set; }
        public string CC_DC_SELL_INR { get; set; }
        public string PP_SCR_SELL { get; set; }
        public string PP_SCR_SELL_CUR { get; set; }
        public string PP_SCR_SELL_INR { get; set; }
        public string CC_SCR_SELL { get; set; }
        public string CC_SCR_SELL_CUR { get; set; }
        public string CC_SCR_SELL_INR { get; set; }
        public string PP_MYC_SELL { get; set; }
        public string PP_MYC_SELL_CUR { get; set; }
        public string PP_MYC_SELL_INR { get; set; }
        public string CC_MYC_SELL { get; set; }
        public string CC_MYC_SELL_CUR { get; set; }
        public string CC_MYC_SELL_INR { get; set; }
        public string CityCode { get; set; }
        public string CmpCode { get; set; }
        public string CmpId { get; set; }
        public string MakerIP { get; set; }
        public string TRANSPORT_MODE { get; set; }
        public string Procument { get; set; }
        public string FRT_RATE_THC_PO { get; set; }
        public string FRT_RATE_THC { get; set; }
        public string PP_THC_SELL { get; set; }
        public string CC_THC_SELL { get; set; }
        public string CC_THC_SELL_CUR { get; set; }
        public string CC_THC_SELL_INR { get; set; }
        public string PP_THC_SELL_CUR { get; set; }
        public string PP_THC_SELL_INR { get; set; }
        public string FRT_RATE_DDC_PO { get; set; }
        public string FRT_RATE_DDC { get; set; }
        public string PP_DDC_SELL { get; set; }
        public string CC_DDC_SELL { get; set; }
        public string CC_DDC_SELL_CUR { get; set; }
        public string CC_DDC_SELL_INR { get; set; }
        public string PP_DDC_SELL_CUR { get; set; }
        public string PP_DDC_SELL_INR { get; set; }

        public string FRT_RATE_FOB_PO { get; set; }
        public string FRT_RATE_FOB { get; set; }
        public string PP_FOB_SELL { get; set; }
        public string CC_FOB_SELL { get; set; }
        public string CC_FOB_SELL_CUR { get; set; }
        public string CC_FOB_SELL_INR { get; set; }
        public string PP_FOB_SELL_CUR { get; set; }
        public string PP_FOB_SELL_INR { get; set; }
    }

    public class JobRating
    {
        public string EXPTNO { get; set; }
        public string PPCHRG_SELLING { get; set; }
        public string CCCHRG_SELLING { get; set; }
        public string PPTOTAGT_SELLING { get; set; }
        public string CCTOTAGT_SELLING { get; set; }
        public string PPTOTCARR_SELLING { get; set; }
        public string CCTOTCARR_SELLING { get; set; }
        public string PPTOT_SELLING { get; set; }
        public string CCTOT_SELLING { get; set; }
        public string OTHCHRG_SELLING { get; set; }
        public string PP_SCHRG_FSC_SELL { get; set; }
        public string PP_SCHRG_IRC_SELL { get; set; }
        public string PP_SCHRG_XRAY_SELL { get; set; }
        public string CC_SCHRG_FSC_SELL { get; set; }
        public string CC_SCHRG_IRC_SELL { get; set; }
        public string CC_SCHRG_XRAY_SELL { get; set; }
        public string REMARK { get; set; }
        public string FREIGHT_RATE_PER_KG { get; set; }
        public string PREPAID_PER { get; set; }
        public string COLLECT_PER { get; set; }
        public string FREIGHT_CHARGABLE_AS { get; set; }
        public string FRT_RATE_SCHRG_FSC_PO { get; set; }
        public string FRT_RATE_SCHRG_IRC_PO { get; set; }
        public string FRT_RATE_SCHRG_XRAY_PO { get; set; }
        public string RATE_AGREED_BY { get; set; }
        public string RATE_AGREED_ON { get; set; }
        public string FREIGHT_RATE_BASIC { get; set; }
        public string FRT_RATE_SCHRG_FSC { get; set; }
        public string FRT_RATE_SCHRG_IRC { get; set; }
        public string FRT_RATE_SCHRG_XRAY { get; set; }
        public string EXCH_RATE { get; set; }
        public string EXCH_CUR { get; set; }
        public string INR_RATE { get; set; }
        public string CCCHRG_SELLING_CUR { get; set; }
        public string CC_SCHRG_FSC_SELL_CUR { get; set; }
        public string CC_SCHRG_IRC_SELL_CUR { get; set; }
        public string CC_SCHRG_XRAY_SELL_CUR { get; set; }
        public string CCTOTAGT_SELLING_CUR { get; set; }
        public string CCTOTCARR_SELLING_CUR { get; set; }
        public string CCCHRG_SELLING_INR { get; set; }
        public string CC_SCHRG_FSC_SELL_INR { get; set; }
        public string CC_SCHRG_IRC_SELL_INR { get; set; }
        public string CC_SCHRG_XRAY_SELL_INR { get; set; }
        public string CCTOTAGT_SELLING_INR { get; set; }
        public string CCTOTCARR_SELLING_INR { get; set; }
        public string CityCode { get; set; }
        public string CmpCode { get; set; }
        public string CmpId { get; set; }
        public string MakerIP { get; set; }
    }

    public class PrintMawbNo
    {
        public string MAWBNO { get; set; }
        public string MAWBDT { get; set; }
        public string EXPTNO { get; set; }
        public string GRWT { get; set; }
        public string CHBL_WT { get; set; }
        public string FRT_TYPE { get; set; }
        public string FRT_CUR { get; set; }
        public string FRT_AMT { get; set; }
        public string CityCode { get; set; }
        public string CmpId { get; set; }
        public string CmpCode { get; set; }
        public string ISDDX { get; set; }
        public string DDXWAREHSE { get; set; }
    }

    public class PrintHawbNo
    {
        public string HAWBNO { get; set; }
        public string HAWBDT { get; set; }
        public string EXPTNO { get; set; }
        public string GRWT { get; set; }
        public string CHBL_WT { get; set; }
        public string FRT_TYPE { get; set; }
        public string FRT_CUR { get; set; }
        public string FRT_AMT { get; set; }
        public string CityCode { get; set; }
        public string CityCode1 { get; set; }
        public string CmpId { get; set; }
        public string CmpCode { get; set; }
    }

    public class printupdateHawbno
    {
        public string HAWBNO { get; set; }
        public string SHPR { get; set; }
        public string CNSEE { get; set; }
        public string AGTNAME { get; set; }
        public string IATA { get; set; }
        public string AGTACNO { get; set; }
        public string DEPARTURE { get; set; }
        public string IMP_TO { get; set; }
        public string FRSTCARR { get; set; }
        public string TO1 { get; set; }
        public string IMP_BY { get; set; }
        public string TO2 { get; set; }
        public string BY1 { get; set; }
        public string CURR { get; set; }
        public string CHGS { get; set; }
        public string PPDWT { get; set; }
        public string COLLWT { get; set; }
        public string OTHRPPD { get; set; }
        public string OTHRCOLL { get; set; }
        public string CARRVAL { get; set; }
        public string CUSTVAL { get; set; }
        public string DEST { get; set; }
        public string FLT1 { get; set; }
        public string FLT2 { get; set; }
        public string INSAMT { get; set; }
        public string ACINFO { get; set; }
        public string HANDINFO { get; set; }
        public string PCS { get; set; }
        public string KG { get; set; }
        public string GRWT { get; set; }
        public string RTCL { get; set; }
        public string ITMNO { get; set; }
        public string CHRGWT { get; set; }
        public string RATE { get; set; }
        public string TOT { get; set; }
        public string IDESC { get; set; }
        public string PPCHRG { get; set; }
        public string PPVAL { get; set; }
        public string PPTAX { get; set; }
        public string PPTOTAGT { get; set; }
        public string PPTOTCARR { get; set; }
        public string PPTOT { get; set; }
        public string PPCURRATE { get; set; }
        public string CCCHRG { get; set; }
        public string CCVAL { get; set; }
        public string CCTAX { get; set; }
        public string CCTOTAGT { get; set; }
        public string CCTOTCARR { get; set; }
        public string CCTOT { get; set; }
        public string CCURRATE { get; set; }
        public string OTHCHRG { get; set; }
        public string TOTCOLLCHRG { get; set; }
        public string BOTTOM { get; set; }
        public string agtname1 { get; set; }

    }
    public class printupdateMawbno
    {
        public string MAWBNO { get; set; }
        public string SHPR { get; set; }
        public string CNSEE { get; set; }
        public string AGTNAME { get; set; }
        public string IATA { get; set; }
        public string AGTACNO { get; set; }
        public string DEPARTURE { get; set; }
        public string IMP_TO { get; set; }
        public string FRSTCARR { get; set; }
        public string TO1 { get; set; }
        public string IMP_BY { get; set; }
        public string TO2 { get; set; }
        public string BY1 { get; set; }
        public string CURR { get; set; }
        public string CHGS { get; set; }
        public string PPDWT { get; set; }
        public string COLLWT { get; set; }
        public string OTHRPPD { get; set; }
        public string OTHRCOLL { get; set; }
        public string CARRVAL { get; set; }
        public string CUSTVAL { get; set; }
        public string DEST { get; set; }
        public string FLT1 { get; set; }
        public string FLT2 { get; set; }
        public string INSAMT { get; set; }
        public string ACINFO { get; set; }
        public string HANDINFO { get; set; }
        public string PCS { get; set; }
        public string KG { get; set; }
        public string RTCL { get; set; }
        public string ITMNO { get; set; }
        public string RATE { get; set; }
        public string TOT { get; set; }
        public string IDESC { get; set; }
        public string PPCHRG { get; set; }
        public string PPVAL { get; set; }
        public string PPTAX { get; set; }
        public string PPTOTAGT { get; set; }
        public string PPTOTCARR { get; set; }
        public string PPTOT { get; set; }
        public string PPCURRATE { get; set; }
        public string CCCHRG { get; set; }
        public string CCVAL { get; set; }
        public string CCTAX { get; set; }
        public string CCTOTAGT { get; set; }
        public string CCTOTCARR { get; set; }
        public string CCTOT { get; set; }
        public string CCURRATE { get; set; }
        public string OTHCHRG { get; set; }
        public string TOTCOLLCHRG { get; set; }
        public string BOTTOM { get; set; }
        public string AGTNAME1 { get; set; }
        public string DESC { get; set; }
        public string AIRLINE_ADDRS { get; set; }

    }
    public class ShippingBill
    {
        public string PkId { get; set; }
        public string ExptNo { get; set; }
        public string CustomDate { get; set; }
        public string ShipBillNo { get; set; }
        public string ShipBillDate { get; set; }
        public string ExaminDate { get; set; }
        public string Objection { get; set; }
        public string Remark { get; set; }
        public string CCNo { get; set; }
        public string CCDate { get; set; }
        public string CmpId { get; set; }
        public string MakerIp { get; set; }
    }

    public class ReceiptCargo
    {
        public string Tbl_IndexId { get; set; }
        public string CargoId { get; set; }
        public string ExptNo { get; set; }
        public string NoOfPkgs { get; set; }
        public string RecdDate { get; set; }
        public string RecdWhere { get; set; }
        public string RecdLocal { get; set; }
        public string RecdTime { get; set; }
        public string RecdLocalTime { get; set; }
        public string Guid { get; set; }
        public string CmpId { get; set; }
        public string Type { get; set; }
    }

    public class ExportNo
    {
        public string ExptNos { get; set; }
        public string VesselRtNo { get; set; }
        public string VesselPort { get; set; }
        public string ExptAgent { get; set; }
        public string CmpId { get; set; }
        public string MakerIp { get; set; }
    }

    public class ContainerNo
    {
        public string ExptVessel { get; set; }
        public string VesselRtNo { get; set; }
        public string VesselPort { get; set; }
        public string ExptAgent { get; set; }
        public string ShipLiner { get; set; }
        public string GuId { get; set; }
        public string CmpId { get; set; }
        public string MakerIp { get; set; }
    }

    public class ContainerLoadingConfirmation
    {
        public string Expt_Vessel { get; set; }
        public string ContainerNo { get; set; }
        public string DestPort { get; set; }
        public string Expt_Agent { get; set; }
        public string LoadDt { get; set; }
        public string Port1loaddt { get; set; }
        public string port2loaddt { get; set; }
        public string TransPortOne { get; set; }
        public string ConVesselOne { get; set; }
        public string EtaOne { get; set; }
        public string TransportOne { get; set; }
        public string ConVsselTwo { get; set; }
        public string Eta2 { get; set; }
        public string DirectVsl { get; set; }
        public string OnwardTrans { get; set; }
        public string OnwardTransBy { get; set; }
        public string OnwardTransPort { get; set; }
        public string OnwardTransCost { get; set; }
        public string Eta3 { get; set; }
        public string EtdPort1 { get; set; }
        public string EtdPort2 { get; set; }
        public string Multi_Dest { get; set; }
        public string CityCode { get; set; }
        public string CmpId { get; set; }
        public string MakerIp { get; set; }
        public string ATAPort { get; set; }
        public string precarby { get; set; }
        public string PlcRecpt { get; set; }
        public string EtdPor { get; set; }
        public string EtdporHr { get; set; }
        public string EtdporMin { get; set; }
        public string EtaPol { get; set; }
        public string EtaPolHr { get; set; }
        public string EtaPolMin { get; set; }
    }

    public class ContainerCLP
    {

        public string ContainerNo { get; set; }
        public string ContVerified { get; set; }
        public string clpString { get; set; }
        public string cmpid { get; set; }
        public string vsl_rtno { get; set; }
        public string CITYCODE { get; set; }

        public string CMPCODE { get; set; }
        public string vsl_port { get; set; }

    }

    public class CLPPallet
    {
        public string vsl_rtno { get; set; }
        public string ContainerID { get; set; }
        public string ContainerNo { get; set; }
        public string huhpnk { get; set; }
        public string CON_CODE { get; set; }
        public string NO_OF_PALLETS { get; set; }
        public string id { get; set; }


    }

    public class cartingSea
    {
        public string vsl_rtno { get; set; }
        public string citycode { get; set; }
        public string cmpcode { get; set; }
        public string port { get; set; }

        public string exptstr { get; set; }
        public string vslagent { get; set; }
        public string remark { get; set; }
        public string cmpid { get; set; }

        public string cartid { get; set; }
        public string exptno { get; set; }

    }

    public class OrderBookingSearch
    {
        public string SearchType { get; set; }
        public string ReferenceNo { get; set; }
        public string EdiGroup { get; set; }
        public string Mode { get; set; }
        public string OrderNo { get; set; }
        public string UserType { get; set; }
        public string ExpCode { get; set; }
        public string CityCode { get; set; }
        public string CmpCode { get; set; }
    }

    public class OrderBooking
    {
        public string Type { get; set; }
        public string OrderId { get; set; }
        public string Concode { get; set; }
        public string Mode { get; set; }
        public string OrderNo { get; set; }
        public string StyleNo { get; set; }
        public string ItemDescription { get; set; }
        public string Pieces { get; set; }
        public string TypeOfPcs { get; set; }
        public string Packages { get; set; }
        public string GrossWeight { get; set; }
        public string Volume { get; set; }
        public string NetWeight { get; set; }
        public string BookingDate { get; set; }
        public string CargoExpectedDate { get; set; }
        public string DocsExpectedEDate { get; set; }
        public string EtdE { get; set; }
        public string EtaE { get; set; }
        public string ApprovalDate { get; set; }
        public string CargoReceivedDate { get; set; }
        public string Exporter { get; set; }
        public string Transhipment { get; set; }
        public string ETDTranshipmentDate { get; set; }
        public string ETATranshipmentDate { get; set; }
        public string Rebooking { get; set; }
        public string ActualApprovalDate { get; set; }
        public string ActualApprovalBy { get; set; }
        public string SupContactDate { get; set; }
        public string ShipmentConfirmation { get; set; }
        public string NewShipmentDate { get; set; }
        public string EdiGroup { get; set; }
        public string CmpCode { get; set; }
        public string Citycode { get; set; }
        public string MakerId { get; set; }
    }

    public class OrderBookingAdd
    {
        public string ORDMODE { get; set; }
        public string TEMPSTRING { get; set; }
        public string BOOKINGDT { get; set; }
        public string CARGOEDT { get; set; }
        public string DOCSEDT { get; set; }
        public string ETDE { get; set; }
        public string ETAE { get; set; }
        public string APPROVALDT { get; set; }
        public string CRAGORECVDDT { get; set; }
        public string CONCODE { get; set; }
        public string EXPCODE { get; set; }
        public string ISTRANS { get; set; }
        public string ETDTRANS { get; set; }
        public string ETATRANS { get; set; }
        public string ACTLAPPROVAL { get; set; }
        public string ACTLAPPROVALBY { get; set; }
        public string SUP_CONTACT_DT { get; set; }
        public string SHIP_CONFIRM { get; set; }
        public string NEW_SHIP_DT { get; set; }
        public string FK_GRPID { get; set; }
        public string MakerId { get; set; }
        public string CITY { get; set; }
    }

    public class ActualFlightDate
    {
        public string ExptNo { get; set; }
        public string SubAgent { get; set; }
        public string ActualFlightDt { get; set; }
        public string Co2EmissionLevel { get; set; }
        public string CmpCode { get; set; }
        public string Citycode { get; set; }
        public string MakerId { get; set; }
        public string MAWBDEST { get; set; }
        public string MAWBFRT { get; set; }

        public string TRAPORT1 { get; set; }
        public string FLTNO1 { get; set; }
        public string ETD1 { get; set; }
        public string ETA1 { get; set; }
        public string TRAPORT2 { get; set; }
        public string FLTNO2 { get; set; }
        public string ETD2 { get; set; }
        public string ETA2 { get; set; }

        public string ActualFlightNo { get; set; }
    }

    public class ExportConsignmentJob
    {
        public string Id { get; set; }
        public string JobNo { get; set; }
        public string ClientName { get; set; }
        public string NoOfPackages { get; set; }
        public string Narration { get; set; }
        public string JobType { get; set; }
        public string MakerId { get; set; }
        public string MakerIp { get; set; }
        public string CmpCode { get; set; }
        public string CityCode { get; set; }
        public string CityCode1 { get; set; }
        public string NoofPieces { get; set; }
        public string Orderno { get; set; }
        public string SupInvno { get; set; }
        public string DocrecptDt { get; set; }
        public string SupInvDt { get; set; }
        public string whs { get; set; }
        public string vendorskucode { get; set; }
        public string boxnumber { get; set; }
    }
    public class bldetails
    {
        public string BLNO { get; set; }
        public string BLDATE { get; set; }
        public string BLTYPE { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE { get; set; }
        public string STR { get; set; }

    }
    public class BranchJobTransfer
    {
        public string OldJobNo { get; set; }
        public string Branch { get; set; }
        public string UserRemarks { get; set; }
        public string CmpCode { get; set; }
        public string MakerId { get; set; }
        public string MakerIp { get; set; }
        public string CityCode { get; set; }
    }


    public class OrderSizeDeatils
    {
        public string ExptNo { get; set; }
        public string Concode { get; set; }
        public string OrderNo { get; set; }
        public string StyleNo { get; set; }
        public string TotalPackage { get; set; }
        public string Str { get; set; }
        public string MakerId { get; set; }
        public string MakerIp { get; set; }
    }

    public class mbl
    {
        public string JOBNO { get; set; }
        public string MBLNO { get; set; }
        public string MBLDT { get; set; }
        public string FRTYPE { get; set; }
        public string FRTCURR { get; set; }
        public string FRTAMT { get; set; }
        public string ENTERON { get; set; }
        public string MAKERID { get; set; }
        public string BLTYPE { get; set; }
        public string JOBSTR { get; set; }
        public string CITY_CODE { get; set; }
    }
    public class mblprint
    {

        public string jobno { get; set; }
        public string shipper { get; set; }
        public string consignee { get; set; }
        public string notify { get; set; }
        public string expno { get; set; }
        public string blno { get; set; }
        public string Carriage { get; set; }
        public string RecptPlce { get; set; }
        public string Vessel { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string PODEL { get; set; }
        public string FrtPaidAt { get; set; }
        public string NumofBL { get; set; }
        public string MarksAndNos { get; set; }
        public string NoofPkgs { get; set; }
        public string ItcDesc { get; set; }
        public string GrWt { get; set; }
        public string Vol { get; set; }
        public string PlaceDate { get; set; }
        public string Misc { get; set; }


    }
    public class Epcopy
    {
        public string SECHMODE { get; set; }
        public string RPTFRMT { get; set; }
        public string VALUE { get; set; }
        public string EXPT_MODE { get; set; }
        public string Subject { get; set; }

    }

    public class Annexure
    {
        public string ExptNo { get; set; }
        public string Parameter { get; set; }
        public string Sample { get; set; }
        public string CargoStatus { get; set; }
        public string NoOfPcs { get; set; }
        public string NoOfContainer { get; set; }
        public string Unit { get; set; }
        public string RotationDate { get; set; }
        public string PeriodPaymentContract { get; set; }
        public string ExporterDesignation { get; set; }
        public string DDate { get; set; }
        public string CHADesignation { get; set; }
        public string IdCardNo { get; set; }
        public string EXPTYPEA { get; set; }
        public string EXPTYPEB { get; set; }
        public string MarksAndNumber { get; set; }
        public string Commission { get; set; }
        public string Discount { get; set; }
        public string Misc { get; set; }
        public string Deduction { get; set; }
        public string Freight { get; set; }
        public string Insurance { get; set; }
        public string Stuffing { get; set; }
        public string Shipper { get; set; }
        public string Consignee { get; set; }
        public string Agency { get; set; }
        public string ConsigneeCountry { get; set; }
        public string Pod { get; set; }
        public string FinalDestination { get; set; }
        public string NameAddressOfBuyer { get; set; }
        public string StrContainer { get; set; }
        public string StrExchangeRate { get; set; }
        public string CmpCode { get; set; }
        public string CityCode { get; set; }
        public string MakerId { get; set; }
    }

    public class AnnexureItemDetail
    {
        public string StrData { get; set; }
        public string CmpCode { get; set; }
        public string CityCode { get; set; }
        public string ExptNo { get; set; }
        public string CmpId { get; set; }
        public string GuId { get; set; }
        public string Status { get; set; }
    }

    public class AnnexureDrawback
    {
        public string StrData { get; set; }
        public string CmpCode { get; set; }
        public string CityCode { get; set; }
        public string ExptNo { get; set; }
        public string CmpId { get; set; }
    }

    public class AnnexureDeecEpcg
    {
        public string StrData { get; set; }
        public string CmpCode { get; set; }
        public string CityCode { get; set; }
        public string ExptNo { get; set; }
        public string CmpId { get; set; }
    }

    public class EpcopyRecvdDt
    {

        public string strExptNo { get; set; }
        public string epcopydt { get; set; }
        public string epcopysentdt { get; set; }
        public string EP_CopyOfSBillNo { get; set; }
        public string EP_CopyOfSBillDt { get; set; }
        public string DEPB_CopyOfSBillNo { get; set; }
        public string DEPB_CopyOfSBillDt { get; set; }
        public string ARE1_No { get; set; }
        public string ARE1_Dt { get; set; }
        public string ARE1_NoCopyReceived { get; set; }
        public string ARE2_No { get; set; }
        public string ARE2_Dt { get; set; }
        public string ARE2_NoCopyReceived { get; set; }
        public string ARE3_No { get; set; }
        public string ARE3_Dt { get; set; }
        public string ARE3_NoCopyReceived { get; set; }
        public string OriginalMateReceiptNo { get; set; }
        public string OriginalMateReceiptDt { get; set; }
        public string citycode { get; set; }
        public string cmp_code { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string CourierNo { get; set; }
        public string CourierDt { get; set; }
        public string CourierRemark { get; set; }
    }
    public class containerFSTmpIu
    {

        public string CONTAINERNO { get; set; }
        public string CONTSIZE { get; set; }
        public string CONTSIZE1 { get; set; }
        public string EXPTNO { get; set; }
        public string PKGS { get; set; }
        public string CBM { get; set; }
        public string Pcs { get; set; }
        public string GrWt { get; set; }
        public string NetWt { get; set; }
        public string CLP_SEQ { get; set; }

        public string USERID { get; set; }
        public string VGUID { get; set; }
        public string ID { get; set; }
        public string CONTAINERID { get; set; }
        public string CONTSTATUS { get; set; }
        public string DESTPORT { get; set; }
        public string MOVETYPE { get; set; }
        public string STEAM_AGENTNO { get; set; }
        public string CUSTOM_AGENTNO { get; set; }
        public string FREIGHT { get; set; }

    }

    public class ContainerFS
    {
        public string VSL_RTNO { get; set; }
        public string VSL_PORT { get; set; }
        public string VSL_AGNT { get; set; }
        public string VSL_SHIPLINE { get; set; }
       
        public string USERID { get; set; }
        public string VGUID { get; set; }
    }
}