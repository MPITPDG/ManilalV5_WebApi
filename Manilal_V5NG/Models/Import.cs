using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manilal_V5NG.Models
{
    public class GOODSRETURN
    {
        public string Id { get; set; }
        public string GRTNNO { get; set; }
        public string GRTNDATE { get; set; }
        public string CLIENT { get; set; }
        public string CLIENTADDID { get; set; }
        public string RETURNNO { get; set; }
        public string CLIENTINVNO { get; set; }
        public string PONO { get; set; }
        public string RETURNDATE { get; set; }
        public string RETURNTIME { get; set; }
        public string MAKERID { get; set; }
        public string MAKERIP { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string VGUID { get; set; }
        public string REMARK { get; set; }
        public string ACTION { get; set; }
        public string SCANTYPE { get; set; }

    }
    public class GOODSRETURNITEM
    {
        public string ID { get; set; }
        public string FK_GRTNNO { get; set; }
        public string FK_ITEMID { get; set; }
        public string RETURNQTY { get; set; }
        public string UOM { get; set; }
        public string GRTNDTLSID { get; set; }
        public string FK_RETURNREASON { get; set; }
        public string FK_RETURNTYPE { get; set; }
        public string EDFLAG { get; set; }
        public string ISDELETED { get; set; }
        public string VGUID { get; set; }
        public string MAKERID { get; set; }
        public string ITEMCODE { get; set; }
        public string EAN { get; set; }
        public string CONTAINERNO { get; set; }
        public string BOXNO { get; set; }
        public string KIABICODE { get; set; }
    }
    public class FillTable
    {
        public string ImportId { get; set; }
        public string TableNo { get; set; }
        public string TableName { get; set; }
    }

    public class Import 
    {
        public string ImpMode { get; set; }
        public string imp_id { get; set; }
        public string fk_Imp_Code { get; set; }
        public string fk_Vsl_Air_name { get; set; }
        public string fk_Agt_name { get; set; }
        public string Mbl_Mabl_NO { get; set; }
        public string Mbl_Mabl_DT { get; set; }
        public string Bbl_Habl_NO { get; set; }
        public string Bbl_Habl_DT { get; set; }
        public string Dir_vessel { get; set; }
        public string fk_Trans_vsl_name { get; set; }
        public string fk_Trans_Port { get; set; }
        public string Bank_Ref_No { get; set; }
        public string Party_Ref_No { get; set; }
        public string GlDate { get; set; }
        public string LastFreeDate { get; set; }
        public string fk_ShipmentPort { get; set; }
        public string Desc_Good { get; set; }
        public string NumOfPkg1 { get; set; }
        public string TypeOfPkg { get; set; }
        public string GrossWt { get; set; }
        public string NetWt { get; set; }
        public string BoeNo { get; set; }
        public string BoeDt { get; set; }
        public string BoeRemark { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDt { get; set; }
        public string fk_Incoterm { get; set; }
        public string InvoiceValue { get; set; }
        public string fk_cur_name { get; set; }
        public string InvExchRate { get; set; }
        public string InvTot { get; set; }
        public string FrightAmt { get; set; }
        public string fk_FrightCur { get; set; }
        public string FrightExchRate { get; set; }
        public string FrightTot { get; set; }
        public string InsAmt { get; set; }
        public string fk_InsCur { get; set; }
        public string InsExchRate { get; set; }
        public string InsTot { get; set; }
        public string ComAmt { get; set; }
        public string fk_ComCur { get; set; }
        public string ComExchRate { get; set; }
        public string ComTot { get; set; }
        public string CifAmt { get; set; }
        public string AccessValue { get; set; }
        public string AdvRec1 { get; set; }
        public string AdvRec1Dt { get; set; }
        public string AdvRec2 { get; set; }
        public string AdvRec2Dt { get; set; }
        public string AdvRec3 { get; set; }
        public string AdvRec3Dt { get; set; }
        public string AdvRec4 { get; set; }
        public string AdvRec4Dt { get; set; }
        public string ExamDate { get; set; }
        public string ExamRemark { get; set; }
        public string AssessDate { get; set; }
        public string AssessRemark { get; set; }
        public string CustomClerk { get; set; }
        public string DockClerk { get; set; }
        public string fk_BillTo { get; set; }
        public string fk_BillOfEntry { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string Citycode1 { get; set; }
        public string CmpCode { get; set; }
        public string ArrivingDateAtICD { get; set; }
        public string Doc_Cancel { get; set; }
        public string Remark { get; set; }
        public string fk_ArilineId { get; set; }
        public string FightNo { get; set; }
        public string FightDate { get; set; }
        public string fk_ArilineId_Transhipment { get; set; }
        public string FightNo_Transhipment { get; set; }
        public string FightDate_Transhipment { get; set; }
        public string fk_ArrivalPort { get; set; }
        public string Exp_Arrival_Date { get; set; }
        public string Act_Arrival_Date { get; set; }
        public string BusinessAssociate { get; set; }
        public string Bill_EntryNO { get; set; }
        public string EXWORKS { get; set; }
        public string CUSTOM_CLR { get; set; }
        public string FREIGHT_FRD { get; set; }
        public string VSL_NAME { get; set; }
        public string VSL_VOYAGENO { get; set; }
        public string VSL_IGMNO { get; set; }
        public string VSL_ARRIVALPORT { get; set; }

        public string VSL_ARRIVALPORTPOD { get; set; }
        public string VSL_BERTHNO { get; set; }
        public string PARTY_REFNO { get; set; }
        public string FINAL_DESTPORT { get; set; }
        public string ARRV_DTFINALDEST { get; set; }
        public string ONLINE_SUB_DT { get; set; }
        public string ONLINE_SUB_BY { get; set; }
        public string DUTY_AMT { get; set; }
        public string STAMP_DUTY { get; set; }
        public string DUTYPAIDBY { get; set; }
        public string DO_RECEIVED_ON { get; set; }
        public string DELIVERY_VALIDATE_DT { get; set; }
        public string DELIVERYMODE { get; set; }
        public string IGMdt { get; set; }




        public List<DateOfRod> DateOfRod { get; set; }
        public List<Goods> Goods { get; set; }
        public List<Boe> Boe { get; set; }
        public List<Duty> Duty { get; set; }
        public List<SteAgent> SteAgent { get; set; }
        public List<Port> Port { get; set; }
        public List<Octroi> Octroi { get; set; }
        public List<Delivery> Delivery { get; set; }
        public List<Invoice> Invoice { get; set; }
        public List<DocCallForUs> DocCallForUs { get; set; }
    }

    public class DateOfRod
    {
        public string STATUS { get; set; }
        public string fk_ImpoterId { get; set; }
        public string Import_Code { get; set; }
        public string pk__DateOfROD_DtlsId { get; set; }
        public string pk_tblIndex { get; set; }
        public string DateOfRODdt { get; set; }
        public string DateOfRODremark { get; set; }
    }

    public class Goods
    {
        public string STATUS { get; set; }
        public string fk_ImpoterId { get; set; }
        public string Import_Code { get; set; }
        public string pk__Good_DtlsId { get; set; }
        public string pk_tblIndex { get; set; }
        public string ContainerNumber { get; set; }
        public string ContainerSize { get; set; }
        public string NoOfPackages { get; set; }
        public string ContLength { get; set; }
        public string ContType { get; set; }
    }

    public class Boe
    {
        public string STATUS { get; set; }
        public string fk_ImpoterId { get; set; }
        public string Import_Code { get; set; }
        public string pk__BOE_DtlsId { get; set; }
        public string pk_tblIndex { get; set; }
        public string BOEno { get; set; }
        public string BOEdt { get; set; }
        public string BOEremark { get; set; }
    }

    public class Duty
    {
        public string STATUS { get; set; }
        public string fk_ImpoterId { get; set; }
        public string Import_Code { get; set; }
        public string pk__Duty_DtlsId { get; set; }
        public string pk_tblIndex { get; set; }
        public string DutyPaid { get; set; }
        public string DutyIns { get; set; }
        public string DutyPaidOn { get; set; }
        public string DutyCashNo { get; set; }
        public string DutyRemark { get; set; }
    }

    public class SteAgent
    {
        public string STATUS { get; set; }
        public string fk_ImpoterId { get; set; }
        public string Import_Code { get; set; }
        public string pk__SteAgent_DtlsId { get; set; }
        public string pk_tblIndex { get; set; }
        public string SteType { get; set; }
        public string SteRecNo { get; set; }
        public string StePaydt { get; set; }
        public string SteAmount { get; set; }
        public string SteTypeValue { get; set; }
        public string SteRemark { get; set; }
    }

    public class Port
    {
        public string STATUS { get; set; }
        public string fk_ImpoterId { get; set; }
        public string Import_Code { get; set; }
        public string pk__Port_DtlsId { get; set; }
        public string pk_tblIndex { get; set; }
        public string PortRecNo { get; set; }
        public string PortPaiddt { get; set; }
        public string PortAmount { get; set; }
        public string PortRemark { get; set; }
    }

    public class Octroi
    {
        public string STATUS { get; set; }
        public string fk_ImpoterId { get; set; }
        public string Import_Code { get; set; }
        public string pk__Octroi_DtlsId { get; set; }
        public string pk_tblIndex { get; set; }
        public string OctRecNo { get; set; }
        public string OctRecPaidDT { get; set; }
        public string OctAmount { get; set; }
        public string OctRemark { get; set; }
    }

    public class Delivery
    {
        public string STATUS { get; set; }
        public string fk_ImpoterId { get; set; }
        public string Import_Code { get; set; }
        public string pk__Del_DtlsId { get; set; }
        public string pk_tblIndex { get; set; }
        public string OH_truck { get; set; }
        public string trackValue { get; set; }
        public string TruckNo { get; set; }
        public string TruckType { get; set; }
        public string RateAgreed { get; set; }
        public string DelDate { get; set; }
        public string DelRemark { get; set; }
        public string truck { get; set; }
    }

    public class Invoice
    {
        public string STATUS { get; set; }
        public string fk_ImpoterId { get; set; }
        public string Import_Code { get; set; }
        public string pk_Inv_DtlsId { get; set; }
        public string pk_tblIndex { get; set; }
        public string Invoice_No { get; set; }
        public string Invoice_Date { get; set; }
    }

    public class DocCallForUs
    {
        public string STATUS { get; set; }
        public string fk_ImpoterId { get; set; }
        public string Import_Code { get; set; }
        public string pk_DocCall_DtlsId { get; set; }
        public string pk_tblIndex { get; set; }
        public string DocName { get; set; }
        public string ReceivedOn { get; set; }
        public string AcknowledgedOn { get; set; }
        public string ISEDIT { get; set; }
    }

    public class ImportSearch
    {
        public string Mode { get; set; }
        public string ImportCode { get; set; }
        public string ImportFromDate { get; set; }
        public string ImportToDate { get; set; }
        public string Importer { get; set; }
        public string ImporterType { get; set; }
        public string BillTo { get; set; }
        public string BillToType { get; set; }
        public string Vessel { get; set; }
        public string VesselType { get; set; }
        public string Agent { get; set; }
        public string AgentType { get; set; }
        public string GlFromDate { get; set; }
        public string GlToDate { get; set; }
        public string SearchType { get; set; }
        public string CityCode1 { get; set; }
        public string CmpCode { get; set; }
    }

    public class Vessel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string VoyageNo { get; set; }
        public string IGMNo { get; set; }
        public string ArrivalPort { get; set; }
        public string BerthNo { get; set; }
        public string ExpectedArrivalDate { get; set; }
        public string ActualArrivalDate { get; set; }
        public string MakerIp { get; set; }
        public string MakerId { get; set; }
        public string CityCode1 { get; set; }
    }

    public class Currency
    {
        public string Id { get; set; }
        public string CurrencyType { get; set; }
        public string Cities { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string ExchangeRate { get; set; }
        public string MakerIp { get; set; }
        public string MakerId { get; set; }
    }

    public class Airline
    {
        public string Id { get; set; }
        public string AirlineCode { get; set; }
        public string AirlineName { get; set; }
        public string MakerIp { get; set; }
        public string MakerId { get; set; }
        public string SearchText { get; set; }
    }

    public class Miscellaneous
    {
        public string Id { get; set; }
        public string JobNo { get; set; }
        public string ClientName { get; set; }
        public string NoOfPkgs { get; set; }
        public string Narration { get; set; }
        public string MakerIp { get; set; }
        public string MakerId { get; set; }
        public string CmpCode { get; set; }
        public string CityCode { get; set; }
        public string CityCode1 { get; set; }
    }
    public class wmsitemmaster
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string LocalItemName { get; set; }
        public string ItemGroupId { get; set; }
        public string ItemSubgroup { get; set; }
        public string Size { get; set; }
        public string Dimension { get; set; }
        public string Netwt { get; set; }
        public string Qty { get; set; }
        public string Rate { get; set; }
        public string TotalAmt { get; set; }
        public string IssueStatus { get; set; }
        public string ItemId { get; set; }
        public string currentstock { get; set; }
        public string OpeningStock { get; set; }
        public string ReserveStock { get; set; }
        public string minimumstock { get; set; }
        public string rejectedstock { get; set; }
        public string scrappedstock { get; set; }
        public string ReorderLevel { get; set; }
        public string MinOrderQty { get; set; }
        public string MinLeadTime { get; set; }
        public string MaxLeadTime { get; set; }
        public string MakerID { get; set; }
        public string MakerIP { get; set; }
        public string CMP_CODE { get; set; }
        public string CITYCODE { get; set; }
        public string CityCode1 { get; set; }
        public string Ean { get; set; }
        public string pk_Id { get; set; }
        public string UserName { get; set; }
        public string NoofLables { get; set; }
        public string MakerDt { get; set; }
        public string STR { get; set; }
        public string IsChecked { get; set; }
        public string UserId { get; set; }
    }

    public class GRN
    {
        public string Id { get; set; }
        public string GRNNO { get; set; }
        public string GRNDATE { get; set; }
        public string CONTAINERNO { get; set; }
        public string ORDERNO { get; set; }
        public string MAKERID { get; set; }
        public string MAKERIP { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string VGUID { get; set; }
        public string STATUS { get; set; }
        public string ACTION { get; set; }
        public string FK_SUPPLIER { get; set; }
        public string SHIPMENTTYPE { get; set; }
        public string GRNTYPE { get; set; }
    }  
    public class GRNITEM
    {
        public string ID { get; set; }
        public string GRNNO { get; set; }
        public string FK_ITEMID { get; set; }
        public string FK_ITEMGRPID { get; set; }
        public string FK_ITEMTYPEID { get; set; }
        public string FK_ITEMSIZEID { get; set; }
        public string QTY { get; set; }
        public string UOM { get; set; }
        public string GRNDTLSID { get; set; }
        public string EDFLAG { get; set; }
        public string ISDELETED { get; set; }
        public string ITEMCATEGORYNAME { get; set; }
        public string VGUID { get; set; }
        public string MAKERID { get; set; }
        public string ORDERNO { get; set; }
        public string ITEMCODE { get; set; }
        public string EANNO { get; set; }
        public string WHCODE { get; set; }
        public string RACKNO { get; set; }
        public string CONTAINERNO { get; set; }
        public string ENTRYSTARTDTTIME { get; set; }
        public string BOXNO { get; set; }
        public string MAKERIP { get; set; }
        public string NEWRACKNO { get; set; }
    }
    public class GOODSISSUE
    {
        public string Id { get; set; }
        public string GINNO { get; set; }
        public string GINDATE { get; set; }
        public string CLIENT { get; set; }
        public string CLIENTADDRESS { get; set; }
        public string ISSUEDATE { get; set; }
        public string LRNO { get; set; }
        public string LRDATE { get; set; }
        public string MAKERID { get; set; }
        public string MAKERIP { get; set; }
        public string CMPCODE { get; set; }
        public string CITYCODE { get; set; }
        public string CITYCODE1 { get; set; }
        public string VGUID { get; set; }
        public string STATUS { get; set; }
        public string ACTION { get; set; }
        public string DELAGENT { get; set; }
        public string ACKNO { get; set; }
        public string REMARK { get; set; }
        public string CONTAINERNO { get; set; }
    }
    public class GOODISSUEITEM
    {
        public string ID { get; set; }
        public string GINNO { get; set; }
        public string FK_ITEMID { get; set; }
        public string ISSUEQTY { get; set; }
        public string UOM { get; set; }
        public string GINDTLSID { get; set; }
        public string EDFLAG { get; set; }
        public string ISDELETED { get; set; }
        public string VGUID { get; set; }
        public string MAKERID { get; set; }
        public string ITEMCODE { get; set; }
        public string EAN { get; set; }
        public string BOXNO { get; set; }
        public string PONO { get; set; }
        public string CONTAINERNO { get;set; }
    }
}