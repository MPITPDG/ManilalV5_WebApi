using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manilal_V5NG.Models
{
    public class Importfra
    {
        //---- Arrival
        public string Tempdata { get; set; }
        public string cmpid { get; set; }
        public string citycode { get; set; }
        public string cmpcode { get; set; }

        public string ARRIVALNO { get; set; }
        public string CODENO { get; set; }
        public string KEYFIELD { get; set; }

        public string PKGS { get; set; }

        public string ARRIVALDT { get; set; }
        public string DOUANENO { get; set; }
        public string DOUANEDT { get; set; }

        public string ARRIVALID { get; set; }
    }
    public class delivery_app
    {
        public string PKID { get; set; }
        public string DELINO { get; set; }
        public string APPTDT { get; set; }
        public string APPTTIME { get; set; }
        public string APPTMRK { get; set; }
        public string MODE { get; set; }
        public string USERID { get; set; }
        public string VGUID { get; set; }

    }
    public class delivery
    {
        public string MODE { get; set; }
        public string DELNO { get; set; }
        public string CLIENT { get; set; }
        public string SRNO { get; set; }
        public string DEORDER { get; set; }
        public string AGTNAME { get; set; }
        public string TEMPSTRING { get; set; }
        public string ACT_DT { get; set; }
        public string ACT_TIME { get; set; }
        public string ACT_RMK { get; set; }
        public string KEYFILED { get; set; }
        public string USERID { get; set; }
        public string VGUID { get; set; }
        public string CITYCODE { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string PALLET { get; set; }
        public string TRUCK { get; set; }
    }

    public class ConsolidationSearch
    {
        public string Mode { get; set; }
        public string Value { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string UserId { get; set; }
        public string CityCode { get; set; }
        public string CmpCode { get; set; }
        public string CityCode1 { get; set; }
        public string Username { get; set; }
    }

    public class ConsolidationRemarkUpdate
    {
        public string ContainerNo { get; set; }
        public string ConsoleNo { get; set; }
        public string Type { get; set; }
        public string JobNo { get; set; }
        public string Value { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public Int32 CustomDocType { get; set; }
        public Int32 PkId { get; set; }
        public Int32 CmpId { get; set; }
        public string CityCode { get; set; }
        public string CmpCode { get; set; }
        public string MakerIp { get; set; }
        public string Remarks { get; set; }
        public string Seq { get; set; }
    }

    public class ManualConsoleJob
    {
        public string ID { get; set; }
        public string CONSOLENO { get; set; }
        public string JOBNO { get; set; }
        public string HAWBNO { get; set; }
        public string HAWBDT { get; set; }
        public string IMPORTER { get; set; }
        public string NOOFPKGS { get; set; }
        public string WEIGHT { get; set; }
        public string VOLUME { get; set; }
        public string FREIGHT { get; set; }
        public string ICOTERM { get; set; }
        public string EXPORTER { get; set; }
        public string CHBLWT { get; set; }
        public string FCRSDT { get; set; }
        public string DESTINATION { get; set; }
        public string RELEASEDT { get; set; }
        public string LOGINID { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCEODE { get; set; }
        public string VGUID { get; set; }

    }
    public class ManualOrder
    {
        public string ID { get; set; }
        public string CONSOLENO { get; set; }
        public string JOBNO { get; set; }
        public string ORDERNO { get; set; }
        public string NOOFPCS { get; set; }
        public string TYPEOFPCS { get; set; }
        public string LSD { get; set; }
        public string HSCODE { get; set; }
        public string HSCODE_DESC { get; set; }
        public string LOGINID { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE { get; set; }
        public string VGUID { get; set; }
    }
    public class ManualConsoleIU
    {
        public string CONSOLENO { get; set; }
        public string CONSOLEDT { get; set; }
        public string MODE { get; set; }
        public string SENTFROM { get; set; }
        public string AGENT { get; set; }
        public string DESTINATION { get; set; }
        public string SHIPLINE { get; set; }
        public string VESSEL { get; set; }
        public string MBLNO { get; set; }
        public string MBLDT { get; set; }
        public string AIRLINE { get; set; }
        public string FLIGHTNO { get; set; }
        public string FLIGHTDT { get; set; }
        public string ACTUALFLIGHTNO { get; set; }
        public string ACTUALFLIGHTDT { get; set; }
        public string MAWBNO { get; set; }
        public string MAWBDT { get; set; }
        public string ETA { get; set; }
        public string VIA { get; set; }
        public string NOOFPKGS { get; set; }
        public string TYPEOFPKGS { get; set; }
        public string WEIGHT { get; set; }
        public string VOLUME { get; set; }
        public string CITYCODE { get; set; }
        public string HOUSEBL { get; set; }
        public string FREIGHT { get; set; }
        public string CMPCODE { get; set; }
        public string TRANSCITY { get; set; }
        public string REMARK { get; set; }
        public string TRANSPORTER { get; set; }
        public string TRANSPORTBY { get; set; }
        public string CARGONOTE { get; set; }
        public string CARGONOTEDT { get; set; }
        public string CHBLWT { get; set; }
        public string VSL_PORT { get; set; }
        public string CONTAINER1 { get; set; }
        public string CONTAINER2 { get; set; }
        public string CONTAINER3 { get; set; }
        public string CONTAINER4 { get; set; }
        public string LOGINID { get; set; }
        public string ACTION { get; set; }
        public string CITYCODE1 { get; set; }
        public string CO2 { get; set; }
        public string VGUID { get; set; }
    }

    public class ConsolidationExchangeRate
    {
        public string ConsoleNo { get; set; }
        public string ContainerNo { get; set; }
        public string TransportOne { get; set; }
        public string ConnVesselOne { get; set; }
        public string EtdPortOne { get; set; }
        public string TransportTwo { get; set; }
        public string ConnVesselTwo { get; set; }
        public string EtdPortTwo { get; set; }
        public string DestCurOne { get; set; }
        public string ValueOne { get; set; }
        public string DestCurTwo { get; set; }
        public string ValueTwo { get; set; }
        public string OnwardBy { get; set; }
        public string OnwardPort { get; set; }
        public Int32 CmpId { get; set; }
    }

    public class ConsolidationDossierObservartion : UserInfo
    {
        public string PK_ID { get; set; }
        public string CONSOLENO { get; set; }
        public string V_ETA1 { get; set; }
        public string NEW_ETA1 { get; set; }
        public string V_ETA2 { get; set; }
        public string NEW_ETA2 { get; set; }
        public string V_ETA3 { get; set; }
        public string NEW_ETA3 { get; set; }
        public string REL_PRINT { get; set; }
        public string REL_SENT { get; set; }
        public string REQ_RDV { get; set; }
        public string CONF_RDV { get; set; }
        public string CAN_DT { get; set; }
        public string PINCODE { get; set; }
        public string ORD_DE_TRANS { get; set; }
        public string DO_PIN_TRANS { get; set; }
        public string INSTR_DOUANE { get; set; }
        public string COPY_DOC_MAIL { get; set; }
        public string ORG_DOC { get; set; }
        public string T1_RECVD { get; set; }
        public string T1_SENT { get; set; }
        public string SHPLINE_INVDT { get; set; }
        public string PAYMT_SHPLINE_INVDT { get; set; }
    }

    public class ConsolidationJobDossierObservartion : UserInfo
    {
        public string PK_ID { get; set; }
        public string JOBNO { get; set; }
        public string INSTR_DOUANE { get; set; }
        public string T1_RECVD { get; set; }
        public string T1_SENT { get; set; }
        public string ORD_DE_TRANS { get; set; }
        public string REQ_RDV { get; set; }
        public string CONF_RDV { get; set; }
        public string COPY_DOC_MAIL { get; set; }
        public string SHPLINE_INVDT { get; set; }
        public string PAYMT_SHPLINE_INVDT { get; set; }
    }

    public class ConsolidationJobReception : UserInfo
    {
        public string PK_ID { get; set; }
        public string JOBNO { get; set; }
        public string CONSOLENO { get; set; }
        public string CTNS_RECUS { get; set; }
        public string PAL { get; set; }
        public string TYPE_PAL { get; set; }
        public string RESERVES { get; set; }
        public string BON_MAG_DU { get; set; }
        public string PACK { get; set; }
        public string DELIVERY_SITE { get; set; }
    }

    public class UserInfo
    {
        public string CMPID { get; set; }
        public string CITYCODE { get; set; }
        public string CMPCODE { get; set; }
        public string MAKERIP { get; set; }
    }
    public class ConsoleContainer : UserInfo
    {
        public string ID { get; set; }
        public string CONSOLENO { get; set; }
        public string CONTAINERNO { get; set; }
        public string CONTAINERSIZE { get; set; }
        public string CONTAINERSIZE1 { get; set; }
        public string CONTAINERSTATUS { get; set; }
        public string DESTPORT { get; set; }
        public string AGTSEALNO { get; set; }
        public string CUSTSEALNO { get; set; }
        public string FREIGHTUSD { get; set; }
        public string BAFUSD { get; set; }
        public string DIRECTVSL { get; set; }
        public string TRANSPORT1 { get; set; }
        public string CONVESSEL1 { get; set; }
        public string CONVESSEL1VOY { get; set; }
        public string ETDPORT1 { get; set; }
        public string ETA1 { get; set; }
        public string TRANSPORT2 { get; set; }
        public string CONVESSEL2 { get; set; }
        public string CONVESSEL2VOY { get; set; }
        public string ETDPORT2 { get; set; }
        public string ETA2 { get; set; }
        public string ONWARDTRANS { get; set; }
        public string ONWARDTRANSBY { get; set; }
        public string ONWARDTRANSPORT { get; set; }
        public string ONWARDTRANSCOST { get; set; }
        public string ETA3 { get; set; }
        public string FREIGHTCUR { get; set; }
        public string BAFCUR { get; set; }
        public string OTHERNAME { get; set; }
        public string OTHERCUR { get; set; }
        public string OTHERAMT { get; set; }
        public string OTHERNAME1 { get; set; }
        public string OTHERCUR1 { get; set; }
        public string OTHERAMT1 { get; set; }
        public string SINGLESHPR { get; set; }
        public string OCUR1 { get; set; }
        public string OCURRATE1 { get; set; }
        public string OCUR2 { get; set; }
        public string OCURRATE2 { get; set; }
        public string DCUR1 { get; set; }
        public string DCURRATE1 { get; set; }
        public string DCUR2 { get; set; }
        public string DCURRATE2 { get; set; }
        
    }
    public class ConsoleContainerCLP : UserInfo
    {
        public string CONSOLENO { get; set; }
        public string CONTAINERNO { get; set; }
        public string CONTAINERSTR { get; set; }
    }

    public class HawbRatingMPCGO
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
      public class ConsoleInvoiceSeaLclRate
    {
        public string PKID { get; set; }
        public string EXRATE { get; set; }
        public string LCLISFREIGHT { get; set; }
        public string LCLIST1 { get; set; }
        public string LCLISDECHARGEMENT { get; set; }
        public string LCLISTRANSPORT { get; set; }

        public string LCLTRASPORTPAL { get; set; }
        public string ISSCAN { get; set; }
        public string SCANEUROAMT { get; set; }
        public string ISINSPPHYSIQUE { get; set; }
        public string INSPPHYSIQUEEUROAMT { get; set; }
        public string HEUREDATTENTE { get; set; }
        public string HEUREDATTENTEAMT { get; set; }
        public string FCLISMULTISTOP { get; set; }
        public string FCLMULTISTOEUROAMT { get; set; }
        public string LCLTRANSPORCBMEUROAMT { get; set; }
        public string CMPID { get; set; }
        public string MAKERIP { get; set; }
        public string IMPORTER { get; set; }

        public string LCLFREIGHTTUSDRATE { get; set; }
        public string LCLT1EUROAMT { get; set; }
        public string LCLDECHARGEMENTEURORATE { get; set; }
        public string ISTID { get; set; }
        public string LCLTIDEURORATE { get; set; }
        public string LCLTIDEUROAMT { get; set; }
        public string ISPEAGEDOUANE { get; set; }
        public string LCLPEAGEDOUANELEHAMT { get; set; }

    }
    public class ConsoleInvoiceSeaFclRate
    {
        public string PKID { get; set; }
        public string EXRATE { get; set; }
        public string ISGOHCONTAINER { get; set; }
        public string ISFCLFREIGHT { get; set; }
        public string FCLFREIGHTUSDACHAT { get; set; }
        public string FREIGHTDESC { get; set; }
        public string FCLFREIGHTUSDQUOTATION_A_LORIGINE { get; set; }

        public string FCLFREIGHTUSDSURCHGOH { get; set; }
        public string ISFCLBAF { get; set; }
        public string FCLBAFUSDDUMOISSIFACTURE { get; set; }
        public string ISFCLCAF { get; set; }
        public string FCLCAFUSDDUMOISLEFREIGHT { get; set; }
        public string ISFCLPEAGEDOUANE_LEH { get; set; }
        public string FCLPEAGEDOUANELEH_REMARKS { get; set; }
        public string ISFCLTHC { get; set; }
        public string FCLTHCEUROAMOUNT { get; set; }
        public string ISFCLLS { get; set; }
        public string FCLLSEUROAMOUNT { get; set; }
        public string ISFCLBL { get; set; }
        public string FCLBLEUROAMOUNT { get; set; }
        public string ISFCLISPS { get; set; }
        public string FCL_ISPS_EURO_AMOUNT { get; set; }
        public string ISFCL_CONSOLE_FEE { get; set; }
        public string FCL_CONSOLE_FEE_REMARKS { get; set; }
        public string ISFCLT1 { get; set; }
        public string ISFCL_TRACTION { get; set; }
        public string ISFCL_TRACTION_LEH { get; set; }
        public string ISFCL_MULTISTOP { get; set; }
        public string ISFCL_TRUCKING { get; set; }
        public string ISFCL_FABRICATION_GOH { get; set; }
        public string ISFCL_DEMONTAGE_GOH { get; set; }
        public string IS_SCAN { get; set; }
        public string SCAN_EURO_AMOUNT { get; set; }
        public string IS_INSPECTION_PHYSIQUE { get; set; }
        public string INSPECTION_PHYSIQUE_EURO_AMOUNT { get; set; }
        public string IS_HEURE_DATTENTE { get; set; } 
        public string HEURE_DATTENTE_EURO_AMOUNT { get; set; }
        public string IS_MESURE_GAZ { get; set; }
        public string MESURE_GAZ_EURO_AMOUNT { get; set; }
        public string CMPID { get; set; }
        public string MAKERIP { get; set; }
        public string IMPORTER { get; set; }
        public string FCL_CONSOLE_EURO_AMOUNT { get; set; }
        public string FCL_T1_EURO_AMOUNT { get; set; }
        public string FCL_TRACTION_ANV_ZEE_EURO_AMOUNT { get; set; }
        public string FCL_MULTISTOP_EURO_AMOUNT { get; set; }
        public string IS_TID { get; set; }
        public string FCL_TID_EURO_RATE { get; set; }
        public string FCL_TID_EURO_AMOUNT { get; set; }
        public string FCL_TRACTION_LEH_EURO_BACT { get; set; }

    }
    public class ImportInstructionModel
    {
        public string searchtxt { get; set; }
        public string searchval { get; set; }
        public string citycode { get; set; }
        public int cntimporter { get; set; }
        public string jobstr { get; set; }
        public string custodoc { get; set; }
        public string supplier { get; set; }
        public string eta_flg { get; set; }
        public string dtsortie { get; set; }
        public string locfrt { get; set; }
        public string tinull { get; set; }
        public string nature { get; set; }
        public string tarifdouane { get; set; }
        public string fature { get; set; }
        public string colisage { get; set; }
        public string certificate { get; set; }
        public string forma { get; set; }
        public string licence { get; set; }
        public string agent { get; set; }
        public string dtrelaese { get; set; }
        public string nulllbl { get; set; }
        public string transport { get; set; }
        public string Snature { get; set; }
        public string starifdouane { get; set; }
        public string verbl { get; set; }
        public string lloyds { get; set; }
        public string dt126e { get; set; }
        public string agtcode { get; set; }
        public string blnber { get; set; }
        public string itemnber { get; set; }
        public string articlenum { get; set; }
        public string ecornum { get; set; }
        public string Artnom { get; set; }
        public string dt126A { get; set; }
        public string T1numPlcdt { get; set; }
        public string validity { get; set; }
        public string M71No { get; set; }
        public string IM7cust { get; set; }
        public string warAddr { get; set; }
        public string laoding { get; set; }
        public string nullIM4 { get; set; }
        public string issued { get; set; }
        public string strtno { get; set; }
        public string nbrcrt { get; set; }
        public string weight { get; set; }
        public string nullIM42 { get; set; }
        public string issued2 { get; set; }
        public string strtno2 { get; set; }
        public string nbrcrt2 { get; set; }
        public string weight2 { get; set; }
        public string nullIM43 { get; set; }
        public string issued3 { get; set; }
        public string strtno3 { get; set; }
        public string nbrcrt3 { get; set; }
        public string weight3 { get; set; }
        public string nullIM44 { get; set; }
        public string issued4 { get; set; }
        public string strtno4 { get; set; }
        public string nbrcrt4 { get; set; }
        public string weight4 { get; set; }
        public string dtheure { get; set; }
        public string username { get; set; }
        public string supaddress { get; set; }
        public string mode { get; set; }
        public string consoleno { get; set; }
        public string jobno { get; set; }
        public string mawbno { get; set; }
        public string hawbno { get; set; }
        public string cde { get; set; }
        public string pol { get; set; }
        public string pod { get; set; }
        public string colis { get; set; }
        public string poids { get; set; }
        public string volume { get; set; }
        public string ddmsg { get; set; }
        public string importer { get; set; }
        public string eta { get; set; }
        public string makerid { get; set; }
        public string makerip { get; set; }
    }
}