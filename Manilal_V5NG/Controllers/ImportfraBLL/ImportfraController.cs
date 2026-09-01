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


namespace Manilal_V5NG.Controllers.ImportfraBLL
{
    public class ImportfraController : ApiController
    {
        public IHttpActionResult Fill_ODTPendingDelivery_List(string type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_PRINT_OEDERDTRANSPORT_PENDINGLIST", type);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/Fill_ODTPendingDelivery_List");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        private void NormalizeModel(ImportInstructionModel model)
        {
            foreach (var prop in typeof(ImportInstructionModel).GetProperties())
            {
                if (prop.PropertyType == typeof(string) && prop.CanRead && prop.CanWrite)
                {
                    var value = (string)prop.GetValue(model);
                    prop.SetValue(model, value ?? string.Empty);
                }
            }
        }
        /// <summary>Retrieve GetConsolePrintCommonview instructionduone records.</summary>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpPost]
        public HttpResponseMessage GetConsolePrintCommonview_instructionduone(ImportInstructionModel model)
        {
            try
            {
                DataSet ds = new DataSet();
                DataSet dsadd = new DataSet();
                DAL objDal = new DAL();
                StringBuilder stringBuilder = new StringBuilder();

                // Normalize null string properties
                NormalizeModel(model);

                if (model.mode == "sea")
                {
                    ds = objDal.ExecuteDataset(
                        ConnectionString.getConnString(),
                        CommandType.StoredProcedure,
                        "USP_IMPFRA_PRINT_COMMON_VIEW_JOB",
                        model.searchtxt,
                        model.searchval,
                        model.citycode,
                        model.jobstr,
                        model.makerid);
                }
                else
                {
                    ds = objDal.ExecuteDataset(
                        ConnectionString.getConnString(),
                        CommandType.StoredProcedure,
                        "USP_IMPFRA_PRINT_COMMON_VIEW_INSDUANE_AIR",
                        model.citycode,
                        model.jobstr,
                        model.makerid);
                }

                DataRow dr = ds.Tables[4].Rows[0];

                dsadd = objDal.ExecuteDataset(
                    ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_INS_IMPFRA_INSTRUCTIONDUANE",
                    model.consoleno, model.jobno, model.hawbno, model.mawbno,
                    model.supplier, model.cde, model.colis, model.poids,
                    model.volume, model.ddmsg, model.eta, model.dtsortie,
                    model.locfrt, model.tinull, model.importer, model.Snature,
                    model.tarifdouane, model.fature, model.colisage,
                    model.certificate, model.forma, model.licence,
                    Convert.ToString(dr["VSLNAME"]),
                    Convert.ToString(dr["CONTAINERDET"]),
                    Convert.ToString(dr["POL"]),
                    Convert.ToString(dr["DESTINATION"]),
                    model.eta,
                    Convert.ToString(dr["CONTAINERDET"]),
                    Convert.ToString(dr["CARRIER"]),
                    model.agent, model.dtrelaese, model.nulllbl,
                    model.transport, model.Snature, model.starifdouane,
                    model.custodoc, model.verbl, model.lloyds,
                    model.dt126e, model.agtcode, model.blnber,
                    model.itemnber, model.articlenum, model.ecornum,
                    model.Artnom, model.dt126A, model.T1numPlcdt,
                    model.validity, model.M71No, model.IM7cust,
                    model.warAddr, model.laoding, model.issued,
                    model.nullIM43, model.issued3, model.nullIM44,
                    model.issued4, model.dtheure,
                    Convert.ToString(dr["SHIPPERNAME"]),
                    Convert.ToString(dr["DOCRCDDT"]),
                    Convert.ToString(dr["CARGORECD"]),
                    Convert.ToString(dr["EXPTAPPDT"]),
                    Convert.ToString(dr["FLIGHTDET"]),
                    Convert.ToString(dr["MBLNO"]),
                    Convert.ToString(dr["POD"]),
                    model.makerid, model.makerip, model.mode);

                int countDtColumn = ds.Tables[0].Columns.Count;

                stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head><body>");
                stringBuilder.Append("<table width='100%' border='1' cellspacing='3' cellpadding='3'> <tr> <td><table width='100%' border='0' cellspacing='0' cellpadding='0'> ");
                stringBuilder.Append("<tr><td width='23%' height='84'> <div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td> ");
                stringBuilder.Append("<td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0'>");
                stringBuilder.Append("<tr><td colspan='2'><font size='6' face='Arial'><strong>" + Convert.ToString(ds.Tables[0].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr> ");
                stringBuilder.Append("<tr> <td width='48%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ADDRS"]) + "</font></td>");
                //stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_TELNO"]) + "<br>");
                //stringBuilder.Append("FAX : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_FAXNO"]) + "<br> E-MAIL : " + Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]) + "<br>");
                stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>E-MAIL : " + Convert.ToString(ds.Tables[0].Rows[0]["MAIL"]) + "<br>");
                stringBuilder.Append("<B>EORI : " + Convert.ToString(ds.Tables[0].Rows[0]["EORI_NUMBER"]) + "</B></font></td> </tr> </table></td> </tr></table></td>    </tr>");
                stringBuilder.Append("<tr><td><table width='100%' border='1' cellpadding='2' cellspacing='2'> <tr> <td width='41%'>");
                stringBuilder.Append("<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><strong>DESTINATAIRE</strong></font></td>");
                stringBuilder.Append("<td width='59%'> <font size='2' face='Verdana, Arial, Helvetica, sans-serif'> <b><font size='2' face='Arial'>" + model.supplier + "<br>");
                stringBuilder.Append("</font></b><font size='2' face='Arial'>" + model.supaddress + "&nbsp;</font></font></td> </tr>");
                stringBuilder.Append("</table></td> </tr><tr><td> <div align='center'><strong><font size='4' face='Arial'><strong>");


                stringBuilder.Append("INSTRUCTIONS DOUANE </strong></font></strong></div></td></tr> ");
                stringBuilder.Append("<tr><td>");
                stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");

                stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>REF A RAPPELER</span></strong></td>");
                stringBuilder.Append("<td width='58%' ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["JOBNO"]) + "</span></td> </tr> ");
                if (model.mode == "air")
                {
                    stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>MAWB </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["MAWBNO"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>HAWB </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["HAWBNO"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CDE </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CDE"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DOUANE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["DDMSG"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>" + model.eta_flg + " </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA1"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE DE SORTIE </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.dtsortie + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LOCALISATION DU FRET </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.locfrt + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td  colspan='2'  > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'> VOUS TROUVEREZ CI-JOINT LES DOCUMENTS NECESSAIRES A L'ETABLISSEMENT DE</span></p></td></tr>");

                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> </span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.tinull + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CLIENT</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["IMPORTER"]) + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NATURE </span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.nature + "</font></p></td></tr>");

                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TARIF DOUANIER </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.tarifdouane + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>FACTURE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.fature + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>COLISAGE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.colisage + "</font></p></td></tr>");
                    stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span .='font-size:10.0pt;font-family:Arial'>CERTIFICATE D'ORIGINE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.certificate + "</font></p></td></tr>");
                    stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>FORM A </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.forma + "</font></p></td></tr>");
                    stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LICENCE EXPORT</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.licence + "</font></p></td></tr>");
                    stringBuilder.Append("</table></tr></td>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'>MERCI           DE BIEN VOULOIR FAIRE LE NECESSAIRE<br>          <br>          Salutations,</font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong>" + model.username + "&nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");

                }
                if (model.mode == "sea")
                {
                    stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VSL NAME </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VSLNAME"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>P.O.L.  </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POL"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ETA  " + Convert.ToString(ds.Tables[4].Rows[0]["DESTINATION"]) + "</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CONTENEUR</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CONTAINERDET"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS  </span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CARRIER</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CARRIER"]) + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>AGENT NAME</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.agent + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>RELEASE DATE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.dtrelaese + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td  colspan='2'  > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'> VOUS TROUVEREZ CI-JOINT LES DOCUMENTS NECESSAIRES A L'ETABLISSEMENT DE</span></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'></span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.nulllbl + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TRANSPORT</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.transport + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NATURE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.nature + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TARIF DOUANIER</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.starifdouane + "</font></p></td></tr>");

                    stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'>INFORMATION ON CUSTOMS DOC</span></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.custodoc + "</font></p></td></tr>");

                    stringBuilder.Append("<tr>");
                    if (model.custodoc == "126 E")
                    {
                        stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VERBLIJFS NBER</span></strong></p></td>");
                        stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.verbl + "</font></p></td></tr>");
                        stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LLOYDS NBER</span></strong></p></td>");
                        stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.lloyds + "</font></p></td></tr>");
                        stringBuilder.Append("<tr  ><td width='42%'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE OF 126E </span></strong></p></td>");
                        stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.dt126e + "</font></p></td></tr>");

                        stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>AGENT CODE</span></strong></p></td>");
                        stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.agtcode + "</font></p></td></tr>");
                        stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>BL NBER GIVEN BY AGENT</span></strong></p></td>");
                        stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.blnber + "</font></p></td></tr>");
                        stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ITEM NBER</span></strong></p></td>");
                        stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.itemnber + "</font></p></td></tr>");
                        stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ARTICLE NBR</span></strong></p></td>");
                        stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.articlenum + "</font></p></td></tr>");

                    }

                    if (model.custodoc == "126 A")
                    {
                        stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ECOR NBER</span></strong></p></td>");
                        stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.ecornum + "</font></p></td></tr>");
                        stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ARTICLE NBER</span></strong></p></td>");
                        stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.Artnom + "</font></p></td></tr>");
                        stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE OF 126A</span></strong></p></td>");
                        stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.dt126A + "</font></p></td></tr> ");

                    }
                    if (model.custodoc == "T1")
                    {
                        stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>T1 NBER+PLACE+DATE</span></strong></p></td>");
                        stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.T1numPlcdt + "</font></p></td></tr>");
                        stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VALIDITY</span></strong></p></td>");
                        stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + model.validity + "</font></p></td></tr> ");
                    }
                    if (model.custodoc == "IM7T1")
                    {
                        stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>IM7T1 NUMBER</span></strong></p></td>");
                        stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.M71No + "</font></p></td></tr>");
                        stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CUSTOMS OFFICE FOR IM7T1</span></strong></p></td>");
                        stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.IM7cust + "</font></p></td></tr>");
                        stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>WAREHOUSE ADDRESS</span></strong></p></td>");
                        stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.warAddr + "</font></p></td></tr>");
                        stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>REF. OF LOADING</span></strong></p></td>");
                        stringBuilder.Append("<td colspan='2'> <p class=MsoNormal><font size='2' face='Arial'>" + model.laoding + "</font></p></td></tr> ");
                    }
                    stringBuilder.Append("</tr></table></td></tr><tr><td>");
                    stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");
                    stringBuilder.Append("<tr ><td colspan='5'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DETAILS OF T1 OR IM4 TO BE ISSUED </span></strong></p></td></tr>");
                    stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'></span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TO BE ISSUED ON</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>SIRET NO</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NBR CTNS</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>WEIGHT</span></strong></p></td></tr>");

                    stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + model.nullIM4 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.issued + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.strtno + "</font></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.nbrcrt + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.weight + "</font></p></td></tr> ");

                    stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + model.nullIM42 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.issued2 + "</font></p></td ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.strtno2 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.nbrcrt2 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.weight2 + "</font></p></td></tr> ");

                    stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + model.nullIM43 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.issued3 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.strtno3 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.nbrcrt3 + "</font></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.weight3 + "</font></p></td></tr> ");

                    stringBuilder.Append("<tr><td><p class=MsoNormal><font size='2' face='Arial'>" + model.nullIM44 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.issued4 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.strtno4 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.nbrcrt4 + "</font></p></td> ");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + model.weight4 + "</font></p></td></tr> </table>");
                    stringBuilder.Append(" </td></tr>");
                    stringBuilder.Append("  <tr><td><table border=1 cessspacing=1 cellpadding=1 width='100%'><tr><td><font face=arial size=2><strong>Date et heure a laquelle le T1 doit etre disponible sure le terminal</strong></font></td><td><font face=arial size=2>" + model.dtheure + "</font></td></tr></table></td></tr>");
                    stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'>MERCI           DE BIEN VOULOIR FAIRE LE NECESSAIRE<br>          <br>          Salutations,</font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong>" + model.username + "&nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");
                }
                byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
                stringBuilder.Clear();
                var dataStream = new MemoryStream(byteArray);
                HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                httpResponseMessage.Content = new StreamContent(dataStream);
                httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
                httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_PrintInstuctiondouane.doc";
                httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                return httpResponseMessage;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>Retrieve print/view data for IMPFRA PRINT ORDERDTRANSPORT SEA records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="jobno">Job number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMPFRA_PRINT_ORDERDTRANSPORT_SEA([FromUri] string citycode, string jobno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_PRINT_ORDERDTRANSPORT_JOB_SEA", citycode, jobno);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/IMPFRA_PRINT_ORDERDTRANSPORT_SEA");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsolePrint ordredrtrasport Multi records.</summary>
        /// <param name="searchtxt">Search text value.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="supplier">Supplier code.</param>
        /// <param name="supaddrs">supaddrs parameter.</param>
        /// <param name="warehouse">warehouse parameter.</param>
        /// <param name="warehouseaddress">warehouseaddress parameter.</param>
        /// <param name="dtelevnt">dtelevnt parameter.</param>
        /// <param name="statut">statut parameter.</param>
        /// <param name="documents">documents parameter.</param>
        /// <param name="lieu">lieu parameter.</param>
        /// <param name="dtheure">dtheure parameter.</param>
        /// <param name="Tderef">Tderef parameter.</param>
        /// <param name="conteneur">conteneur parameter.</param>
        /// <param name="tarif">tarif parameter.</param>
        /// <param name="username">username parameter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage GetConsolePrint_ordredrtrasport_Multi([FromUri] string searchtxt, string searchval, string citycode, string supplier, string supaddrs, string warehouse, string warehouseaddress, string dtelevnt, string statut, string documents, string lieu, string dtheure, string Tderef, string conteneur, string tarif, string username, string mode,
         string makerid, string makerip, string jobno, string co2emissionlevel, string biofuel)
        {
            DataSet ds = new DataSet();
            DataSet dsadd = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_IMPFRA_PRINT_ORDERDTRANSPORT_JOB_SEA", citycode, jobno);

            supaddrs = (supaddrs != null) ? supaddrs : "";

            dsadd = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
            "USP_IMPFRA_ORDERDTRANSPORT_INSERT", Convert.ToString(ds.Tables[4].Rows[0]["CONSOLENO"]),
            Convert.ToString(ds.Tables[4].Rows[0]["JOBNO"]), Convert.ToString(ds.Tables[4].Rows[0]["HAWBNO"]),
            Convert.ToString(ds.Tables[4].Rows[0]["MAWBNO"]), Convert.ToString(ds.Tables[4].Rows[0]["VSLNAME"]),
            Convert.ToString(ds.Tables[4].Rows[0]["POL"]), Convert.ToString(ds.Tables[4].Rows[0]["ETA"]),
            Convert.ToString(ds.Tables[4].Rows[0]["DESTINATION"]), Convert.ToString(ds.Tables[4].Rows[0]["CONTAINERDET"]),
            Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]), Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]),
            Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]), Convert.ToString(ds.Tables[4].Rows[0]["CARRIER"]),
            Convert.ToString(ds.Tables[4].Rows[0]["ORDERNO"]), Convert.ToString(ds.Tables[4].Rows[0]["CDE"]),
            Convert.ToString(ds.Tables[4].Rows[0]["IMPORTER"]), Convert.ToString(ds.Tables[4].Rows[0]["DDMSG"]),
            Convert.ToString(ds.Tables[4].Rows[0]["SHIPPERNAME"]), Convert.ToString(ds.Tables[4].Rows[0]["STR_PKGS"]),
            Convert.ToString(ds.Tables[4].Rows[0]["TOT_PCSPKG"]), Convert.ToString(ds.Tables[4].Rows[0]["PCS"]),
            Convert.ToString(ds.Tables[4].Rows[0]["DOCRCDDT"]), Convert.ToString(ds.Tables[4].Rows[0]["CARGORECD"]),
            Convert.ToString(ds.Tables[4].Rows[0]["EXPTAPPDT"]), Convert.ToString(ds.Tables[4].Rows[0]["FLIGHTDET"]),
            Convert.ToString(ds.Tables[4].Rows[0]["MBLNO"]), Convert.ToString(ds.Tables[4].Rows[0]["POD"]),
            Convert.ToString(ds.Tables[4].Rows[0]["ETA"]), citycode, Convert.ToString(ds.Tables[4].Rows[0]["VSL_PORT"]),
            co2emissionlevel, warehouse, supplier, warehouseaddress, (dtelevnt != null) ? dtelevnt : "",
            (statut != null) ? statut : "", (documents != null) ? documents : "", (lieu != null) ? lieu : "",
            (dtheure != null) ? dtheure : "", (Tderef != null) ? Tderef : "", Convert.ToString(ds.Tables[4].Rows[0]["CONTAINERDET"]), (tarif != null) ? tarif : "",
            (biofuel != null) ? biofuel : "", makerid, makerip);

            int countDtColumn = ds.Tables[0].Columns.Count;

            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head><body>");
            stringBuilder.Append("<table width='100%' border='1' cellspacing='3' cellpadding='3'> <tr> <td><table width='100%' border='0' cellspacing='0' cellpadding='0'> ");
            stringBuilder.Append("<tr><td width='23%' height='84'> <div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td> ");
            stringBuilder.Append("<td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0'>");
            stringBuilder.Append("<tr><td colspan='2'><font size='6' face='Arial'><strong>" + Convert.ToString(ds.Tables[0].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr> ");
            stringBuilder.Append("<tr> <td width='48%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ADDRS"]) + "</font></td>");
            stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_TELNO"]) + "<br>");
            //stringBuilder.Append("FAX : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_FAXNO"]) + "<br> E-MAIL : " + Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]) + "<br>");
            stringBuilder.Append("<B>EORI : " + Convert.ToString(ds.Tables[0].Rows[0]["EORI_NUMBER"]) + "</B></font></td> </tr> </table></td> </tr></table></td>    </tr>");
            stringBuilder.Append("<tr><td><table width='100%' border='1' cellpadding='2' cellspacing='2'> <tr> <td width='41%'>");
            stringBuilder.Append("<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><strong>DESTINATAIRE</strong></font></td>");
            stringBuilder.Append("<td width='59%'> <font size='2' face='Verdana, Arial, Helvetica, sans-serif'> <b><font size='2' face='Arial'>" + supplier + "<br>");
            stringBuilder.Append("</font></b><font size='2' face='Arial'>" + supaddrs + "&nbsp;</font></font></td> </tr>");
            stringBuilder.Append("</table></td> </tr><tr><td> <div align='center'><strong><font size='4' face='Arial'><strong>");


            stringBuilder.Append("ORDRE DE TRANSPORT(INDIVIDUAL SHIPMENT)</strong></font></strong></div></td></tr> ");
            stringBuilder.Append("<tr><td>");
            stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");

            stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>OUR REF</span></strong></td>");
            stringBuilder.Append("<td width='58%' ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["JOBNO"]) + "</span></td> </tr> ");


            stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>MBL </span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["MBLNO"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>P.O.L.  </span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POL"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>SHIPPING LINE </span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CARRIER"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ORDER NO. </span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CDE"]) + "</font></p></td></tr>");


            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS  </span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POD</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POD"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ETA</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA1"]) + "</font></p></td></tr>");


            stringBuilder.Append("</tr></table></td></tr><tr><td>");
            stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");
            stringBuilder.Append("<tr ><td colspan='5'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ADRESSE D'ENLEVEMENT - QUAI D'ENLEVEMENT    </span></strong></p></td></tr>");
            stringBuilder.Append("<tr><td colspan='5'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>" + warehouse + "</span></strong> <BR> " + warehouseaddress + "</p></td></tr>");
            stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> DATE ENLEVEMENT </span></strong></p></td>");
            stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>STATUT DOUANE / TRANSITAIRE </strong></p></td></tr>");


            stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + dtelevnt + "</font></p></td> ");
            stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + statut + "</font></p></td></tr> ");
            stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'> <strong>DOCUMENTS A JOINDRE A LA LIVRAISON :</strong></font></p></td>  ");
            stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + documents + "</font></p></td> </tr>");

            stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> LIEU DE LIVRAISON  </span></strong></p></td>");
            stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE ET HEURE / REFERENCES DE LIVRAISON </strong></p></td></tr>");


            stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + lieu + "</font></p></td> ");
            stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + dtheure + "</font></p></td </tr>");


            stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TERMINAL DE RESTITUTION + REF </span></strong></p></td>");
            stringBuilder.Append(" <td> <p class=MsoNormal><font size='2' face='Arial'>" + Tderef + "</font></p></td></tr> ");

            stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> CONTENEUR A RESTITUER LE :  </strong></p></td> ");
            stringBuilder.Append(" <td> <p class=MsoNormal><font size='2' face='Arial'>" + conteneur + "</font></p></td></tr> ");
            stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> TARIF    </strong></p></td> ");
            stringBuilder.Append(" <td> <p class=MsoNormal><font size='2' face='Arial'>" + tarif + "</font></p></td></tr> ");
            stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>BIOFUEL </span></strong></p></td>");
            stringBuilder.Append(" <td> <p class=MsoNormal><font size='2' face='Arial'>" + biofuel + "</font></p></td></tr> ");


            stringBuilder.Append("  </table>");
            stringBuilder.Append(" </td></tr>");
            //stringBuilder.Append("  <tr><td> </td></tr>");
            stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'> " + Convert.ToString(ds.Tables[7].Rows[0]["ENCLOSURE"]) + "</font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong>" + username + "&nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_Orderdetransport.doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }
        /// <summary>Retrieve GetConsolePrintCommonview instructionduone records.</summary>
        /// <param name="searchtxt">Search text value.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="jobstr">jobstr parameter.</param>
        /// <param name="custodoc">custodoc parameter.</param>
        /// <param name="supplier">Supplier code.</param>
        /// <param name="eta_flg">eta flg parameter.</param>
        /// <param name="dtsortie">dtsortie parameter.</param>
        /// <param name="locfrt">locfrt parameter.</param>
        /// <param name="tinull">tinull parameter.</param>
        /// <param name="nature">nature parameter.</param>
        /// <param name="tarifdouane">tarifdouane parameter.</param>
        /// <param name="fature">fature parameter.</param>
        /// <param name="colisage">colisage parameter.</param>
        /// <param name="certificate">certificate parameter.</param>
        /// <param name="forma">forma parameter.</param>
        /// <param name="licence">licence parameter.</param>
        /// <param name="agent">agent parameter.</param>
        /// <param name="dtrelaese">dtrelaese parameter.</param>
        /// <param name="nulllbl">nulllbl parameter.</param>
        /// <param name="transport">transport parameter.</param>
        /// <param name="Snature">Snature parameter.</param>
        /// <param name="starifdouane">starifdouane parameter.</param>
        /// <param name="verbl">verbl parameter.</param>
        /// <param name="lloyds">lloyds parameter.</param>
        /// <param name="dt126e">d t126 e parameter.</param>
        /// <param name="agtcode">agtcode parameter.</param>
        /// <param name="blnber">blnber parameter.</param>
        /// <param name="itemnber">itemnber parameter.</param>
        /// <param name="articlenum">articlenum parameter.</param>
        /// <param name="ecornum">ecornum parameter.</param>
        /// <param name="Artnom">Artnom parameter.</param>
        /// <param name="dt126A">d t126 A parameter.</param>
        /// <param name="T1numPlcdt">T1 n u m P l c d t parameter.</param>
        /// <param name="validity">validity parameter.</param>
        /// <param name="M71No">M71 N o parameter.</param>
        /// <param name="IM7cust">I M7 c u s t parameter.</param>
        /// <param name="warAddr">war Addr parameter.</param>
        /// <param name="laoding">laoding parameter.</param>
        /// <param name="nullIM4">null IM4 parameter.</param>
        /// <param name="issued">issued parameter.</param>
        /// <param name="strtno">strtno parameter.</param>
        /// <param name="nbrcrt">nbrcrt parameter.</param>
        /// <param name="weight">weight parameter.</param>
        /// <param name="nullIM42">null IM42 parameter.</param>
        /// <param name="issued2">issued2 parameter.</param>
        /// <param name="strtno2">strtno2 parameter.</param>
        /// <param name="nbrcrt2">nbrcrt2 parameter.</param>
        /// <param name="weight2">weight2 parameter.</param>
        /// <param name="nullIM43">null IM43 parameter.</param>
        /// <param name="issued3">issued3 parameter.</param>
        /// <param name="strtno3">strtno3 parameter.</param>
        /// <param name="nbrcrt3">nbrcrt3 parameter.</param>
        /// <param name="weight3">weight3 parameter.</param>
        /// <param name="nullIM44">null IM44 parameter.</param>
        /// <param name="issued4">issued4 parameter.</param>
        /// <param name="strtno4">strtno4 parameter.</param>
        /// <param name="nbrcrt4">nbrcrt4 parameter.</param>
        /// <param name="weight4">weight4 parameter.</param>
        /// <param name="dtheure">dtheure parameter.</param>
        /// <param name="username">username parameter.</param>
        /// <param name="supaddress">supaddress parameter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage GetConsolePrintCommonview_instructionduone([FromUri] string searchtxt, string searchval, string citycode, Int32 cntimporter, string jobstr, string custodoc, string supplier, string eta_flg, string dtsortie, string locfrt, string tinull, string nature, string tarifdouane, string fature, string colisage, string certificate, string forma, string licence, string agent, string dtrelaese, string nulllbl, string transport, string Snature, string starifdouane, string verbl, string lloyds, string dt126e, string agtcode, string blnber, string itemnber, string articlenum, string ecornum, string Artnom, string dt126A, string T1numPlcdt, string validity, string M71No, string IM7cust, string warAddr, string laoding, string nullIM4, string issued, string strtno, string nbrcrt, string weight, string nullIM42, string issued2, string strtno2, string nbrcrt2, string weight2, string nullIM43, string issued3, string strtno3, string nbrcrt3, string weight3, string nullIM44, string issued4, string strtno4, string nbrcrt4, string weight4, string dtheure, string username, string supaddress, string mode,
            string consoleno, string jobno, string hawbno, string mawbno, string cde, string pol, string pod, string colis, string poids, string volume, string ddmsg,
            string importer, string eta, string makerid, string makerip)
        {
            DataSet ds = new DataSet();
            DataSet dsadd = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            if (mode == "sea")
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_IMPFRA_PRINT_COMMON_VIEW_JOB", (searchtxt != null) ? searchtxt : "", (searchval != null) ? searchval : "", citycode, jobstr, makerid);

            }
            else
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                                CommandType.StoredProcedure,
                                "USP_IMPFRA_PRINT_COMMON_VIEW_INSDUANE_AIR", citycode, jobstr, makerid);
            }

            custodoc = (custodoc != null) ? custodoc : ""; supplier = (supplier != null) ? supplier : "";
            eta_flg = (eta_flg != null) ? eta_flg : "";
            dtsortie = (dtsortie != null) ? dtsortie : ""; locfrt = (locfrt != null) ? locfrt : "";
            tinull = (tinull != null) ? tinull : "";
            nature = (nature != null) ? nature : "";
            tarifdouane = (tarifdouane != null) ? tarifdouane : ""; fature = (fature != null) ? fature : ""; colisage = (colisage != null) ? colisage : "";
            certificate = (certificate != null) ? certificate : ""; forma = (forma != null) ? forma : "";
            licence = (licence != null) ? licence : ""; agent = (agent != null) ? agent : ""; dtrelaese = (dtrelaese != null) ? dtrelaese : "";
            nulllbl = (nulllbl != null) ? nulllbl : ""; transport = (transport != null) ? transport : ""; Snature = (Snature != null) ? Snature : "";
            starifdouane = (starifdouane != null) ? starifdouane : ""; verbl = (verbl != null) ? verbl : "";
            lloyds = (lloyds != null) ? lloyds : ""; dt126e = (dt126e != null) ? dt126e : ""; agtcode = (agtcode != null) ? agtcode : "";
            blnber = (blnber != null) ? blnber : ""; itemnber = (itemnber != null) ? itemnber : ""; articlenum = (articlenum != null) ? articlenum : "";

            ecornum = (ecornum != null) ? ecornum : ""; Artnom = (Artnom != null) ? Artnom : ""; dt126A = (dt126A != null) ? dt126A : "";
            T1numPlcdt = (T1numPlcdt != null) ? T1numPlcdt : ""; validity = (validity != null) ? validity : "";
            M71No = (M71No != null) ? M71No : ""; IM7cust = (IM7cust != null) ? IM7cust : ""; warAddr = (warAddr != null) ? warAddr : ""; laoding = (laoding != null) ? laoding : "";
            nullIM4 = (nullIM4 != null) ? nullIM4 : ""; issued = (issued != null) ? issued : ""; strtno = (strtno != null) ? strtno : ""; nbrcrt = (nbrcrt != null) ? nbrcrt : "";
            weight = (weight != null) ? weight : ""; nullIM42 = (nullIM42 != null) ? nullIM42 : "";
            issued2 = (issued2 != null) ? issued2 : ""; strtno2 = (strtno2 != null) ? strtno2 : ""; nbrcrt2 = (nbrcrt2 != null) ? nbrcrt2 : ""; weight2 = (weight2 != null) ? weight2 : "";
            nullIM43 = (nullIM43 != null) ? nullIM43 : ""; issued3 = (issued3 != null) ? issued3 : "";
            strtno3 = (strtno3 != null) ? strtno3 : ""; nbrcrt3 = (nbrcrt3 != null) ? nbrcrt3 : ""; weight3 = (weight3 != null) ? weight3 : ""; nullIM44 = (nullIM44 != null) ? nullIM44 : "";
            issued4 = (issued4 != null) ? issued4 : ""; strtno4 = (strtno4 != null) ? strtno4 : "";
            nbrcrt4 = (nbrcrt4 != null) ? nbrcrt4 : ""; weight4 = (weight4 != null) ? weight4 : ""; dtheure = (dtheure != null) ? dtheure : "";
            supaddress = (supaddress != null) ? supaddress : "";
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["conString_Manilal"];


            dsadd = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure,
             "USP_INS_IMPFRA_INSTRUCTIONDUANE", consoleno, jobno, hawbno, mawbno, supplier, cde, colis, poids, volume, ddmsg, eta, dtsortie, locfrt, tinull, importer, Snature, tarifdouane,
             fature, colisage, certificate, forma, licence, Convert.ToString(ds.Tables[4].Rows[0]["VSLNAME"]), Convert.ToString(ds.Tables[4].Rows[0]["CONTAINERDET"]),
             Convert.ToString(ds.Tables[4].Rows[0]["POL"]), Convert.ToString(ds.Tables[4].Rows[0]["DESTINATION"]), eta, Convert.ToString(ds.Tables[4].Rows[0]["CONTAINERDET"]), Convert.ToString(ds.Tables[4].Rows[0]["CARRIER"]),
             agent, dtrelaese, nulllbl, transport, Snature, starifdouane, custodoc, verbl, lloyds, dt126e,
        agtcode, blnber, itemnber, articlenum, ecornum, Artnom, dt126A,
        T1numPlcdt, validity, M71No, IM7cust, warAddr, laoding, issued,
        nullIM43, issued3, nullIM44, issued4, dtheure, Convert.ToString(ds.Tables[4].Rows[0]["SHIPPERNAME"]),
        Convert.ToString(ds.Tables[4].Rows[0]["DOCRCDDT"]), Convert.ToString(ds.Tables[4].Rows[0]["CARGORECD"]), Convert.ToString(ds.Tables[4].Rows[0]["EXPTAPPDT"]), Convert.ToString(ds.Tables[4].Rows[0]["FLIGHTDET"]),
        Convert.ToString(ds.Tables[4].Rows[0]["MBLNO"]),
        Convert.ToString(ds.Tables[4].Rows[0]["POD"]), makerid, makerip, mode);



            int countDtColumn = ds.Tables[0].Columns.Count;

            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head><body>");
            stringBuilder.Append("<table width='100%' border='1' cellspacing='3' cellpadding='3'> <tr> <td><table width='100%' border='0' cellspacing='0' cellpadding='0'> ");
            stringBuilder.Append("<tr><td width='23%' height='84'> <div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td> ");
            stringBuilder.Append("<td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0'>");
            stringBuilder.Append("<tr><td colspan='2'><font size='6' face='Arial'><strong>" + Convert.ToString(ds.Tables[0].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr> ");
            stringBuilder.Append("<tr> <td width='48%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ADDRS"]) + "</font></td>");
            //stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_TELNO"]) + "<br>");
            //stringBuilder.Append("FAX : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_FAXNO"]) + "<br> E-MAIL : " + Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]) + "<br>");
            stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>E-MAIL : " + Convert.ToString(ds.Tables[0].Rows[0]["MAIL"]) + "<br>");
            stringBuilder.Append("<B>EORI : " + Convert.ToString(ds.Tables[0].Rows[0]["EORI_NUMBER"]) + "</B></font></td> </tr> </table></td> </tr></table></td>    </tr>");
            stringBuilder.Append("<tr><td><table width='100%' border='1' cellpadding='2' cellspacing='2'> <tr> <td width='41%'>");
            stringBuilder.Append("<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><strong>DESTINATAIRE</strong></font></td>");
            stringBuilder.Append("<td width='59%'> <font size='2' face='Verdana, Arial, Helvetica, sans-serif'> <b><font size='2' face='Arial'>" + supplier + "<br>");
            stringBuilder.Append("</font></b><font size='2' face='Arial'>" + supaddress + "&nbsp;</font></font></td> </tr>");
            stringBuilder.Append("</table></td> </tr><tr><td> <div align='center'><strong><font size='4' face='Arial'><strong>");


            stringBuilder.Append("INSTRUCTIONS DOUANE </strong></font></strong></div></td></tr> ");
            stringBuilder.Append("<tr><td>");
            stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");

            stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>REF A RAPPELER</span></strong></td>");
            stringBuilder.Append("<td width='58%' ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["JOBNO"]) + "</span></td> </tr> ");
            if (mode == "air")
            {
                stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>MAWB </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["MAWBNO"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>HAWB </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["HAWBNO"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CDE </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CDE"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DOUANE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["DDMSG"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>" + eta_flg + " </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA1"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE DE SORTIE </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + dtsortie + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LOCALISATION DU FRET </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + locfrt + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td  colspan='2'  > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'> VOUS TROUVEREZ CI-JOINT LES DOCUMENTS NECESSAIRES A L'ETABLISSEMENT DE</span></p></td></tr>");

                stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> </span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + tinull + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CLIENT</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["IMPORTER"]) + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NATURE </span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nature + "</font></p></td></tr>");

                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TARIF DOUANIER </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + tarifdouane + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>FACTURE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + fature + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>COLISAGE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + colisage + "</font></p></td></tr>");
                stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CERTIFICATE D'ORIGINE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + certificate + "</font></p></td></tr>");
                stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>FORM A </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + forma + "</font></p></td></tr>");
                stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LICENCE EXPORT</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + licence + "</font></p></td></tr>");
                stringBuilder.Append("</table></tr></td>");

                stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'>MERCI           DE BIEN VOULOIR FAIRE LE NECESSAIRE<br>          <br>          Salutations,</font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong>" + username + "&nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");

            }
            if (mode == "sea")
            {
                stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VSL NAME </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VSLNAME"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>P.O.L.  </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POL"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ETA  " + Convert.ToString(ds.Tables[4].Rows[0]["DESTINATION"]) + "</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CONTENEUR</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CONTAINERDET"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS  </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CARRIER</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CARRIER"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>AGENT NAME</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + agent + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>RELEASE DATE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + dtrelaese + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td  colspan='2'  > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'> VOUS TROUVEREZ CI-JOINT LES DOCUMENTS NECESSAIRES A L'ETABLISSEMENT DE</span></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'></span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + nulllbl + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TRANSPORT</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + transport + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NATURE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + nature + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TARIF DOUANIER</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + starifdouane + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'>INFORMATION ON CUSTOMS DOC</span></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + custodoc + "</font></p></td></tr>");

                stringBuilder.Append("<tr>");
                if (custodoc == "126 E")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VERBLIJFS NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + verbl + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LLOYDS NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + lloyds + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE OF 126E </span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + dt126e + "</font></p></td></tr>");

                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>AGENT CODE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + agtcode + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>BL NBER GIVEN BY AGENT</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + blnber + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ITEM NBER</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + itemnber + "</font></p></td></tr>");
                    stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ARTICLE NBR</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + articlenum + "</font></p></td></tr>");

                }

                if (custodoc == "126 A")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ECOR NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + ecornum + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ARTICLE NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + Artnom + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE OF 126A</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + dt126A + "</font></p></td></tr> ");

                }
                if (custodoc == "T1")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>T1 NBER+PLACE+DATE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + T1numPlcdt + "</font></p></td></tr>");
                    stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VALIDITY</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + validity + "</font></p></td></tr> ");
                }
                if (custodoc == "IM7T1")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>IM7T1 NUMBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + M71No + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CUSTOMS OFFICE FOR IM7T1</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + IM7cust + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>WAREHOUSE ADDRESS</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + warAddr + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>REF. OF LOADING</span></strong></p></td>");
                    stringBuilder.Append("<td colspan='2'> <p class=MsoNormal><font size='2' face='Arial'>" + laoding + "</font></p></td></tr> ");
                }
                stringBuilder.Append("</tr></table></td></tr><tr><td>");
                stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");
                stringBuilder.Append("<tr ><td colspan='5'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DETAILS OF T1 OR IM4 TO BE ISSUED </span></strong></p></td></tr>");
                stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'></span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TO BE ISSUED ON</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>SIRET NO</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NBR CTNS</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>WEIGHT</span></strong></p></td></tr>");

                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + nullIM4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno + "</font></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight + "</font></p></td></tr> ");

                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + nullIM42 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued2 + "</font></p></td ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno2 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt2 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight2 + "</font></p></td></tr> ");

                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + nullIM43 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued3 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno3 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt3 + "</font></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight3 + "</font></p></td></tr> ");

                stringBuilder.Append("<tr><td><p class=MsoNormal><font size='2' face='Arial'>" + nullIM44 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight4 + "</font></p></td></tr> </table>");
                stringBuilder.Append(" </td></tr>");
                stringBuilder.Append("  <tr><td><table border=1 cessspacing=1 cellpadding=1 width='100%'><tr><td><font face=arial size=2><strong>Date et heure a laquelle le T1 doit etre disponible sure le terminal</strong></font></td><td><font face=arial size=2>" + dtheure + "</font></td></tr></table></td></tr>");
                stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'>MERCI           DE BIEN VOULOIR FAIRE LE NECESSAIRE<br>          <br>          Salutations,</font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong>" + username + "&nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");
            }
            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_PrintInstuctiondouane.doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }
        /// <summary>Retrieve print/view data for IMPFRA PRINT COMMON VIEW INSDUANE AIR records.</summary>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="jobno">Job number.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMPFRA_PRINT_COMMON_VIEW_INSDUANE_AIR([FromUri] string citycode, string jobno,string cmpid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_PRINT_COMMON_VIEW_INSDUANE_AIR", citycode, jobno, cmpid);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/IMPFRA_PRINT_COMMON_VIEW_INSDUANE_AIR");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of Fill PendingDelivery records.</summary>
        /// <param name="type">type parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_PendingDelivery_List(string type)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_PRINT_INSTRUDOUANE_PENDINGLIST", type);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/Fill_PendingDelivery_List");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Retrieve list of Fill Delivery records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_Delivery_List()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_DELIVERY_GETDYNAMIC_DELIVERY_LIST");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Fill_Delivery_List");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Retrieve pending delivery jobs across all masters for one consignee (multi-master delivery).</summary>
        /// <param name="concode">Consignee code.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_Delivery_List_ByConsignee(string concode, string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_DELIVERY_GETDYNAMIC_DELIVERY_LIST", concode, mode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Fill_Delivery_List_ByConsignee");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Insert or update FRA IMP INVOICE SEA GRP RATE UPDATE FCL records.</summary>
        /// <param name="Seafclrate">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult FRA_IMP_INVOICE_SEA_GRP_RATE_UPDATE_FCL([FromBody] ConsoleInvoiceSeaFclRate Seafclrate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_FRA_IMP_INVOICE_SEA_GRP_RATE_UPDATE_FCL",
                 Seafclrate.PKID, Seafclrate.EXRATE, Seafclrate.ISGOHCONTAINER, Seafclrate.ISFCLFREIGHT, Seafclrate.FCLFREIGHTUSDACHAT,
                 Seafclrate.FREIGHTDESC, Seafclrate.FCLFREIGHTUSDQUOTATION_A_LORIGINE, Seafclrate.FCLFREIGHTUSDSURCHGOH, Seafclrate.ISFCLBAF,
                 Seafclrate.FCLBAFUSDDUMOISSIFACTURE, Seafclrate.ISFCLCAF, Seafclrate.FCLCAFUSDDUMOISLEFREIGHT, Seafclrate.ISFCLPEAGEDOUANE_LEH, Seafclrate.FCLPEAGEDOUANELEH_REMARKS,
                 Seafclrate.ISFCLTHC, Seafclrate.FCLTHCEUROAMOUNT, Seafclrate.ISFCLLS, Seafclrate.FCLLSEUROAMOUNT, Seafclrate.ISFCLBL, Seafclrate.FCLBLEUROAMOUNT,
                 Seafclrate.ISFCLISPS, Seafclrate.FCL_ISPS_EURO_AMOUNT, Seafclrate.ISFCL_CONSOLE_FEE, Seafclrate.FCL_CONSOLE_FEE_REMARKS, Seafclrate.ISFCLT1, Seafclrate.ISFCL_TRACTION, Seafclrate.ISFCL_TRACTION_LEH,
                 Seafclrate.FCL_TRACTION_LEH_EURO_BACT,
                 Seafclrate.ISFCL_MULTISTOP, Seafclrate.ISFCL_TRUCKING, Seafclrate.ISFCL_FABRICATION_GOH, Seafclrate.ISFCL_DEMONTAGE_GOH, Seafclrate.IS_SCAN, Seafclrate.SCAN_EURO_AMOUNT,
                 Seafclrate.IS_INSPECTION_PHYSIQUE, Seafclrate.INSPECTION_PHYSIQUE_EURO_AMOUNT, Seafclrate.IS_HEURE_DATTENTE, Seafclrate.HEURE_DATTENTE_EURO_AMOUNT, Seafclrate.IS_MESURE_GAZ,
                 Seafclrate.MESURE_GAZ_EURO_AMOUNT, Seafclrate.CMPID, Seafclrate.MAKERIP, Seafclrate.IMPORTER, Seafclrate.FCL_CONSOLE_EURO_AMOUNT, Seafclrate.FCL_T1_EURO_AMOUNT,
                    Seafclrate.FCL_TRACTION_ANV_ZEE_EURO_AMOUNT, Seafclrate.FCL_MULTISTOP_EURO_AMOUNT, Seafclrate.IS_TID, Seafclrate.FCL_TID_EURO_RATE, Seafclrate.FCL_TID_EURO_AMOUNT
                    );
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Importfra/FRA_IMP_INVOICE_SEA_GRP_RATE_UPDATE_FCL");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Populate form with existing data for IMPFRA INVOICE SEA GRP POPULATE FCL records.</summary>
        /// <param name="pkid">Primary key ID of the record.</param>
        /// <param name="importer">importer parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMPFRA_INVOICE_SEA_GRP_POPULATE_FCL(string pkid, string importer)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_FRA_IMP_INVOICE_SEA_GRP_POPULATE_FCL", pkid, (importer != null) ? importer : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/IMPFRA_INVOICE_SEA_GRP_POPULATE_FCL");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Insert or update FRA IMP INVOICE SEA GRP RATE UPDATE LCL records.</summary>
        /// <param name="Sealclrate">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult FRA_IMP_INVOICE_SEA_GRP_RATE_UPDATE_LCL([FromBody] ConsoleInvoiceSeaLclRate Sealclrate)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_FRA_IMP_INVOICE_SEA_GRP_RATE_UPDATE_LCL",
                    Sealclrate.PKID, Sealclrate.EXRATE, Sealclrate.LCLISFREIGHT, Sealclrate.LCLIST1, Sealclrate.LCLISDECHARGEMENT, Sealclrate.LCLISTRANSPORT, Sealclrate.LCLTRASPORTPAL, Sealclrate.ISSCAN,
                    Sealclrate.SCANEUROAMT, Sealclrate.ISINSPPHYSIQUE, Sealclrate.INSPPHYSIQUEEUROAMT, Sealclrate.HEUREDATTENTE, Sealclrate.HEUREDATTENTEAMT, Sealclrate.FCLISMULTISTOP,
                    Sealclrate.FCLMULTISTOEUROAMT, Sealclrate.LCLTRANSPORCBMEUROAMT, Sealclrate.CMPID, Sealclrate.MAKERIP, Sealclrate.IMPORTER, Sealclrate.LCLFREIGHTTUSDRATE, Sealclrate.LCLT1EUROAMT,
                    Sealclrate.LCLDECHARGEMENTEURORATE, Sealclrate.ISTID, Sealclrate.LCLTIDEURORATE, Sealclrate.LCLTIDEUROAMT, Sealclrate.ISPEAGEDOUANE, Sealclrate.LCLPEAGEDOUANELEHAMT
                    );
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Importfra/FRA_IMP_INVOICE_SEA_GRP_RATE_UPDATE_LCL");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Populate form with existing data for IMPFRA INVOICE SEA GRP POPULATE LCL records.</summary>
        /// <param name="pkid">Primary key ID of the record.</param>
        /// <param name="importer">importer parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMPFRA_INVOICE_SEA_GRP_POPULATE_LCL(string pkid, string importer)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_FRA_IMP_INVOICE_SEA_GRP_POPULATE_LCL", pkid, (importer != null) ? importer : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/IMPFRA_INVOICE_SEA_GRP_POPULATE_LCL");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve dropdown data for IMPFRA INVOICE SEA GRP records.</summary>
        /// <param name="seaconsoleno">seaconsoleno parameter.</param>
        /// <param name="code">code parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMPFRA_INVOICE_SEA_GRP_FILL(string seaconsoleno, string code)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_FRA_IMP_INVOICE_SEA_GRP_FILL", seaconsoleno, (code != null) ? code : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/IMPFRA_INVOICE_SEA_GRP_FILL");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsolePrintCommonview withJob records.</summary>
        /// <param name="searchtxt">Search text value.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="jobno">Job number.</param>
        /// <param name="makerid">User code of the record maker.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsolePrintCommonview_withJob([FromUri] string searchtxt, string searchval, string citycode, string jobno,string makerid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_PRINT_COMMON_VIEW_JOB", searchtxt, searchval, citycode, jobno,makerid);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsolePrintCommonview_withJob");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for IMPFRA PRINT INSTRUDOUANE JOBDTLS records.</summary>
        /// <param name="type">type parameter.</param>
        /// <param name="mawbcontno">mawbcontno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMPFRA_PRINT_INSTRUDOUANE_JOBDTLS(string type, string mawbcontno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_PRINT_INSTRUDOUANE_JOBDTLS", type, mawbcontno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/GetImportFraPrintDouane");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsoleNoView records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult GetConsoleNoView_NG([FromBody] ConsolidationSearch obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_VIEW_NG",
                    obj.Value, obj.UserId, obj.Username);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleNoView_NG");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for IMPFRA CONS CONTAINER VIEW DTLS records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMPFRA_CONS_CONTAINER_VIEW_DTLS()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_CONS_CONTAINER_VIEW_DTLS");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMPFRA_CONS_CONTAINER_VIEW_DTLS");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform IMPFRA CONSOLEDATA EXCELWORKING records.</summary>
        /// <param name="FROMDT">Start date for the date range filter.</param>
        /// <param name="TODT">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMPFRA_CONSOLEDATA_EXCELWORKING(string FROMDT, string TODT)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_CONSOLEDATA_EXCELWORKING", FROMDT, TODT);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/IMPFRA_CONSOLEDATA_EXCELWORKING");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform RPT CLIENT CO2EMISSION records.</summary>
        /// <param name="CONCODE">CONCODE parameter.</param>
        /// <param name="FROMDT">Start date for the date range filter.</param>
        /// <param name="TODT">End date for the date range filter.</param>
        /// <param name="CMPCODE">Company code identifier.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage RPT_CLIENT_CO2EMISSION([FromUri]string CONCODE, string FROMDT, string TODT, string CMPCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            string strSpName = string.Empty, strXslFilename = string.Empty;
            string strData = string.Empty;
            strXslFilename = "xsl_importfra_clientwise_co2emission.xsl";
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_CLIENTWISE_CO2EMISSION_RPT", CONCODE, FROMDT, TODT, CMPCODE);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());

            strData = CommonFunction.ConvertToExcel_open("Importfra", strXslFilename, xmlDoc);



            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(strData));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_CLIENT_CO2_REPORT.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }
        /// <summary>Delete ConsoleRemark records.</summary>
        /// <param name="ID">Primary key ID of the record.</param>
        /// <param name="CONSOLENO">CONSOLENO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult ConsoleRemark_Delete(string ID, string CONSOLENO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_CONSOLE_REMARK_MULTI_DELETE", ID, CONSOLENO);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "ImportFra/ConsoleRemark_delete");
            }
            return Ok(ds);
        }
        /// <summary>Perform ConsoleRemarkInsertUpdate records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsoleRemarkInsertUpdate([FromBody]ConsolidationRemarkUpdate obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_REMARK_MULTI_IU",
                    obj.PkId, obj.ConsoleNo, obj.Remarks, obj.Seq);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/ConsoleNoRemarkInsertUpdate");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform PRINT DOSSIER Old records.</summary>
        /// <param name="CONSOLENO">CONSOLENO parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage PRINT_DOSSIER_OLD([FromUri]string CONSOLENO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string strData = string.Empty;
            string strFileNmae = string.Empty;

            strSpName = "USP_IMPFRA_CONSOLE_DOISSER_MAIN_VIEW";
            strXslFilename = "xsl_Impfra_Print_Dossier.xsl"; // "xsl_Expo_Rpt_Print_Dossier.xsl";

            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, strSpName, CONSOLENO);
            strFileNmae = Convert.ToString(ds.Tables[0].Rows[0]["filename"]);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());
            strData = CommonFunction.ConvertToExcel_open("Importfra", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(strData));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = strFileNmae; //"Print Dossier.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }
        /// <summary>Perform PRINT DOSSIER records.</summary>
        /// <param name="CONSOLENO">CONSOLENO parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage PRINT_DOSSIER([FromUri] string CONSOLENO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string strData = string.Empty;
            string strFileNmae = string.Empty;

            strSpName = "USP_IMPFRA_CONSOLE_DOISSER_MAIN_VIEW";
            strXslFilename = "xsl_Impfra_Print_Dossier.xsl";

            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, strSpName, CONSOLENO);

            strFileNmae = Convert.ToString(ds.Tables[0].Rows[0]["filename"]);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());

            strData = CommonFunction.ConvertToExcel("Importfra", strXslFilename, xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(strData);
            MemoryStream stream = new MemoryStream(byteArray);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition =
            new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")  ;
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = strFileNmae;
            httpResponseMessage.Content.Headers.ContentType =
            new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-excel")  ;

            return httpResponseMessage;
        }

        /// <summary>Perform PRINT DOSSIER RECEPTION records.</summary>
        /// <remarks>
        /// Second dossier export. Reuses USP_IMPFRA_CONSOLE_DOISSER_MAIN_VIEW untouched so the
        /// original PRINT_DOSSIER download is unaffected, then folds in the per-job warehouse
        /// reception columns from USP_IMPFRA_CONSOLE_JOB_RECEPTION_BYCONSOLE and rebuilds the
        /// manifest table grouped by delivery site with sous-total / total / ecart rows.
        /// The grouping is done here rather than in a proc because the manifest SELECT lives
        /// inside the existing main-view proc, which is deliberately not modified.
        /// </remarks>
        /// <param name="CONSOLENO">CONSOLENO parameter.</param>
        /// <returns>File download (Excel) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage PRINT_DOSSIER_RECEPTION([FromUri] string CONSOLENO)
        {
            DAL objDal = new DAL();
            DataSet ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure, "USP_IMPFRA_CONSOLE_DOISSER_MAIN_VIEW", CONSOLENO);

            DataSet dsRecep = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure, "USP_IMPFRA_CONSOLE_JOB_RECEPTION_BYCONSOLE", CONSOLENO);

            BuildReceptionManifest(ds, dsRecep, CONSOLENO);

            // Owner-layout header block. Added as TableHdr so the XSL can select it
            // independently of the main view's Table1.
            DataSet dsHdr = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure, "USP_IMPFRA_CONSOLE_DOSSIER_RECEPTION_HEADER", CONSOLENO);
            if (dsHdr.Tables.Count > 0 && dsHdr.Tables[0].Rows.Count > 0)
            {
                DataTable hdr = dsHdr.Tables[0].Copy();
                hdr.TableName = "TableHdr";
                ds.Tables.Add(hdr);
            }

            string strFileNmae = Convert.ToString(ds.Tables[0].Rows[0]["filename"]);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());

            string strData = CommonFunction.ConvertToExcel("Importfra", "xsl_Impfra_Print_Dossier_Reception.xsl", xmlDoc);

            byte[] byteArray = Encoding.UTF8.GetBytes(strData);
            MemoryStream stream = new MemoryStream(byteArray);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition =
            new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = strFileNmae;
            httpResponseMessage.Content.Headers.ContentType =
            new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-excel");

            return httpResponseMessage;
        }

        /// <summary>Columns of the manifest table that carry a running total.</summary>
        private static readonly string[] ReceptionTotalCols =
            { "NOOFPCS", "ORDERPKGS", "WEIGHT", "VOLUME", "CHBLWT", "CTNS_RECUS", "PAL" };

        /// <summary>Reception columns grafted onto the manifest table.</summary>
        private static readonly string[] ReceptionCols =
            { "CTNS_RECUS", "PAL", "TYPE_PAL", "RESERVES", "BON_MAG_DU", "PACK", "DELIVERY_SITE" };

        /// <summary>
        /// Replaces Table2 with a site-grouped version carrying the reception columns and a
        /// ROWTYPE marker the XSL branches on: G group header, D detail, S sous-total,
        /// T total console, E ecart manifeste / reception.
        /// </summary>
        private static void BuildReceptionManifest(DataSet ds, DataSet dsRecep, string CONSOLENO)
        {
            if (!ds.Tables.Contains("Table2")) { return; }

            DataTable src = ds.Tables["Table2"];

            // Reception rows keyed on the last 10 digits of the job number, because the console
            // view passes job numbers both with and without the '2020' prefix.
            Dictionary<string, DataRow> recep = new Dictionary<string, DataRow>();
            if (dsRecep.Tables.Count > 0)
            {
                foreach (DataRow r in dsRecep.Tables[0].Rows)
                {
                    string key = JobKey(Convert.ToString(r["JOBNO"]));
                    if (key != "" && !recep.ContainsKey(key)) { recep.Add(key, r); }
                }
            }

            DataTable dest = src.Clone();
            foreach (DataColumn c in dest.Columns) { c.DataType = typeof(string); }
            foreach (string c in ReceptionCols)
            {
                if (!dest.Columns.Contains(c)) { dest.Columns.Add(c, typeof(string)); }
            }
            dest.Columns.Add("ROWTYPE", typeof(string));
            dest.Columns.Add("GROUPLABEL", typeof(string));
            // 1-based delivery-site index; the XSL alternates its palette on this.
            dest.Columns.Add("GROUPIDX", typeof(string));
            dest.Columns.Add("ECARTNOTE", typeof(string));

            // Detail rows carrying their site, ordered site-then-original-sequence.
            List<DataRow> details = new List<DataRow>();
            List<string> sites = new List<string>();
            Dictionary<string, List<DataRow>> bySite = new Dictionary<string, List<DataRow>>();

            foreach (DataRow s in src.Rows)
            {
                // The main-view proc emits its own per-client 'TOTAL - <client>' rows, which
                // carry no job number. They must not become details or they double every sum.
                string jobno = src.Columns.Contains("JOBNO") && !s.IsNull("JOBNO")
                    ? Convert.ToString(s["JOBNO"]).Trim() : "";
                if (jobno == "") { continue; }

                DataRow d = dest.NewRow();
                foreach (DataColumn c in src.Columns)
                {
                    d[c.ColumnName] = s.IsNull(c) ? "" : Convert.ToString(s[c]);
                }

                string key = JobKey(jobno);
                DataRow rr;
                if (key != "" && recep.TryGetValue(key, out rr))
                {
                    foreach (string c in ReceptionCols)
                    {
                        d[c] = rr.Table.Columns.Contains(c) ? Convert.ToString(rr[c]) : "";
                    }
                }
                else
                {
                    foreach (string c in ReceptionCols) { d[c] = ""; }
                }

                d["ROWTYPE"] = "D";
                string site = Convert.ToString(d["DELIVERY_SITE"]).Trim();
                if (site == "") { site = "NON AFFECTE"; }
                d["GROUPLABEL"] = site;

                if (!bySite.ContainsKey(site)) { bySite.Add(site, new List<DataRow>()); sites.Add(site); }
                bySite[site].Add(d);
                details.Add(d);
            }

            // Emit: group header, details, sous-total ... then total console and ecart.
            int liv = 0;
            foreach (string site in sites)
            {
                liv++;
                DataRow head = dest.NewRow();
                head["ROWTYPE"] = "G";
                // e.g. "LIVRAISON 1  -  ELW LAUWIN-PLANQUE   (commandes SOLID / TC)"
                string packs = DistinctPacks(bySite[site]);
                head["GROUPLABEL"] = "LIVRAISON " + liv + "  -  " + site
                    + (packs == "" ? "" : "   (commandes " + packs + ")");
                head["GROUPIDX"] = liv.ToString();
                dest.Rows.Add(head);

                foreach (DataRow d in bySite[site])
                {
                    d["GROUPIDX"] = liv.ToString();
                    dest.Rows.Add(d);
                }

                DataRow sub = dest.NewRow();
                sub["ROWTYPE"] = "S";
                sub["GROUPIDX"] = liv.ToString();
                sub["GROUPLABEL"] = "SOUS-TOTAL  " + site;
                AddTotals(sub, bySite[site]);
                dest.Rows.Add(sub);
            }

            DataRow tot = dest.NewRow();
            tot["ROWTYPE"] = "T";
            tot["GROUPLABEL"] = "TOTAL CONSOLE " + JobKey(CONSOLENO);
            AddTotals(tot, details);
            dest.Rows.Add(tot);

            DataRow ecart = dest.NewRow();
            ecart["ROWTYPE"] = "E";
            ecart["GROUPLABEL"] = "ECART MANIFESTE / RECEPTION";
            decimal manifest = SumColumn(details, "ORDERPKGS");
            decimal received = SumColumn(details, "CTNS_RECUS");
            if (dest.Columns.Contains("ORDERPKGS"))
            {
                // FormatNum blanks a zero, but a zero ecart is the meaningful "all received" case.
                ecart["ORDERPKGS"] = (manifest - received).ToString(
                    System.Globalization.CultureInfo.InvariantCulture);
            }
            ecart["CTNS_RECUS"] = "";

            int captured = 0;
            bool anyReserve = false;
            foreach (DataRow d in details)
            {
                if (Convert.ToString(d["CTNS_RECUS"]).Trim() != "") { captured++; }
                string res = Convert.ToString(d["RESERVES"]).Trim();
                if (res != "" && res.ToUpperInvariant() != "NEANT") { anyReserve = true; }
            }
            if (captured == 0)
            {
                ecart["ECARTNOTE"] = "AUCUNE RECEPTION SAISIE";
            }
            else
            {
                ecart["ECARTNOTE"] = (manifest == received && captured == details.Count
                        ? "CONSOLE COMPLETE - " : "ECART - ")
                    + captured + "/" + details.Count + " BONS RECUS, "
                    + (anyReserve ? "AVEC RESERVES" : "AUCUNE RESERVE");
            }
            dest.Rows.Add(ecart);

            // Swap in place so the table keeps the element name the XSL selects on.
            ds.Tables.Remove(src);
            dest.TableName = "Table2";
            ds.Tables.Add(dest);
        }

        /// <summary>Distinct PACK values of a group, in first-seen order, for the group heading.</summary>
        private static string DistinctPacks(List<DataRow> rows)
        {
            List<string> packs = new List<string>();
            foreach (DataRow r in rows)
            {
                string p = Convert.ToString(r["PACK"]).Trim();
                if (p != "" && !packs.Contains(p)) { packs.Add(p); }
            }
            return string.Join(" / ", packs.ToArray());
        }

        private static void AddTotals(DataRow target, List<DataRow> rows)
        {
            foreach (string c in ReceptionTotalCols)
            {
                if (target.Table.Columns.Contains(c))
                {
                    target[c] = FormatNum(SumColumn(rows, c));
                }
            }
        }

        /// <summary>
        /// Sums a manifest column. Cells can hold several values separated by spaces or commas
        /// (multi-order jobs), so every numeric token in the cell counts.
        /// </summary>
        private static decimal SumColumn(List<DataRow> rows, string column)
        {
            decimal total = 0;
            foreach (DataRow r in rows)
            {
                if (!r.Table.Columns.Contains(column)) { continue; }
                string raw = Convert.ToString(r[column]);
                if (string.IsNullOrEmpty(raw)) { continue; }

                string[] parts = raw.Split(new char[] { ' ', ',', '\r', '\n', '\t' },
                    StringSplitOptions.RemoveEmptyEntries);
                foreach (string p in parts)
                {
                    decimal v;
                    if (decimal.TryParse(p, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out v))
                    {
                        total += v;
                    }
                }
            }
            return total;
        }

        private static string FormatNum(decimal value)
        {
            if (value == 0) { return ""; }
            return (value == decimal.Truncate(value))
                ? decimal.Truncate(value).ToString(System.Globalization.CultureInfo.InvariantCulture)
                : value.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture);
        }

        /// <summary>Last 10 digits of a job/console number, the form both prefixes share.</summary>
        private static string JobKey(string value)
        {
            string v = (value ?? "").Trim();
            return v.Length > 10 ? v.Substring(v.Length - 10) : v;
        }

        /// <summary>Generate SEA CONSOLE GENERATE AUTO records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult SEA_CONSOLE_GENERATE_AUTO([FromBody]CommonEight obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_ASP_IMP_CONSOLE_GENERATE_SEA_IU",
                    obj.Type1, obj.Type2, obj.Type3, obj.Type4, obj.Type5, obj.Type6, obj.Type7, obj.Type8);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Importfra/SEA_CONSOLE_GENERATE_AUTO");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform Impfra ActualarrivalSearchpageload records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Impfra_ActualarrivalSearchpageload()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALARRV_VSL_PAGELOAD_LIST");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_ActualarrivalSearchpageload");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform Impfra Actualarrivalpageload records.</summary>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="SMode">Operation mode or filter type.</param>
        /// <param name="value">Search filter value.</param>
        /// <param name="vslname">vslname parameter.</param>
        /// <param name="VSL_VOYNO">VSL VOYNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Impfra_Actualarrivalpageload([FromUri]string mode, string SMode, string value, string vslname, string VSL_VOYNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALARRV_REALETA_PAGELOAD", mode, SMode, value, vslname, VSL_VOYNO);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_Actualarrivalpageload");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Insert or update Impfra ActualarrivalSea records.</summary>
        /// <param name="arr">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Impfra_ActualarrivalSea_IU([FromBody]Importfra arr)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALARRV_REALETA_SEA_IU", arr.Tempdata, arr.cmpid, arr.citycode, arr.cmpcode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_ActualarrivalSea_IU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Insert or update Impfra ActualarrivalAir records.</summary>
        /// <param name="arr">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Impfra_ActualarrivalAir_IU([FromBody] Importfra arr)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALARRV_REALETA_AIR_IU", (arr.ARRIVALNO != null) ? arr.ARRIVALNO : "", arr.CODENO, arr.KEYFIELD, arr.cmpid, arr.citycode, arr.cmpcode, arr.PKGS, arr.ARRIVALDT, arr.DOUANENO, arr.DOUANEDT, (arr.ARRIVALID != null) ? arr.ARRIVALID : "");
                string arrivalno = Convert.ToString(ds.Tables[0].Rows[0]["ARRIVALNO"]);
                Impfra_Actualarrival_Mailsent(arrivalno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_ActualarrivalAir_IU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Insert or update Impfra ActualarrivalOther records.</summary>
        /// <param name="arr">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Impfra_ActualarrivalOther_IU([FromBody]Importfra arr)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALARRV_REALETA_OTHER_IU", arr.Tempdata, arr.cmpid, arr.citycode, arr.cmpcode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_ActualarrivalOther_IU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Delete Impfra Actualarrival records.</summary>
        /// <param name="arrivalno">arrivalno parameter.</param>
        /// <param name="cmpid">Primary key of the company.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="destport">destport parameter.</param>
        /// <param name="arrivalid">arrivalid parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Impfra_Actualarrival_delete([FromUri]string arrivalno, string cmpid, string mode, string destport,string arrivalid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALARRV_REALETA_DELETE", arrivalno, cmpid, mode, (destport != null) ? destport : "", arrivalid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_Actualarrival_delete");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        //

        /// <summary>Perform Impfra Actualarrival Mailsent records.</summary>
        /// <param name="arrivalno">arrivalno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Impfra_Actualarrival_Mailsent([FromUri]string arrivalno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALARRIVAL_MAIL_POPULATE", arrivalno);

                var message = string.Empty;
                message = "<table border=1> <tr> <thead> <th>CODENO</th> <th>KEYFIELD</th> <th>ARRIVALDT</th> <th>ARRIVAL_PKGS</th><th>TOT_PKGS</th><th>ENTERED_BY</th>";
                message = message + "<th>ENTERED_ON</th><th>REMARK</th></thead> </tr>";
                if (ds.Tables.Count >= 1)
                {
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            message = message + "<tr> <td>" + ds.Tables[0].Rows[i][0].ToString() + "</td><td>" + ds.Tables[0].Rows[i][1].ToString() + "</td><td>" + ds.Tables[0].Rows[i][2].ToString() + "</td><td>" + ds.Tables[0].Rows[i][3].ToString() + "</td></tr>";
                        }
                        message = message + "</table>";
                    }
                    Send_Mail("alerts@manilal.com", "venkatesh@manilal.com", "devanshi@manilal.com", "pdg.mp@manilal.com", "Arrival Entered", message);
                     //Send_Mail("admin@manilal.net", "pdg.mp@manilal.com", "", "", "Arrival Entered", message);
                }
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_Actualarrival_Mailsent");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
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
                    MailTo = "pdg.mp@manilal.com";
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
                  //  System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("202.71.136.193");
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
        // chargo on hang 

        /// <summary>Retrieve Fill consignee Delivery records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_consignee_Delivery()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_DELIVERY_CONS_FILL");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Fill_consignee_Delivery");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for Fill Delivery records.</summary>
        /// <param name="concode">concode parameter.</param>
        /// <param name="searchType">Search type/column identifier.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="userid">userid parameter.</param>
        /// <param name="vguid">Session GUID for temporary record management.</param>
        /// <param name="DELIVERYNO">DELIVERYNO parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_Delivery_view(string concode, string searchType, string searchval, string mode, string userid, string vguid, string DELIVERYNO)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_VIEW", concode, searchType, searchval, mode, userid, vguid, (DELIVERYNO != null) ? DELIVERYNO : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Fill_Delivery_view");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Retrieve print/view data for Fill Delivery view New records.</summary>
        /// <param name="concode">concode parameter.</param>
        /// <param name="searchType">Search type/column identifier.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="userid">userid parameter.</param>
        /// <param name="vguid">Session GUID for temporary record management.</param>
        /// <param name="DELIVERYNO">DELIVERYNO parameter.</param>
        /// <param name="Anotherdelivery">Anotherdelivery parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_Delivery_view_New(string concode, string searchType, string searchval, string mode, string userid, string vguid, string DELIVERYNO,string Anotherdelivery)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_VIEW_NEW", concode, searchType, searchval, mode, userid, vguid, (DELIVERYNO != null) ? DELIVERYNO : "", (Anotherdelivery != null) ? Anotherdelivery : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Fill_Delivery_view");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Insert or update Impfra delivery Appoint records.</summary>
        /// <param name="delap">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Impfra_delivery_Appoint_IU([FromBody]delivery_app delap)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_APPOINTMENT_TMP_IU", delap.PKID, delap.DELINO, delap.APPTDT, delap.APPTTIME, delap.APPTMRK, delap.MODE, delap.USERID, delap.VGUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_delivery_Appoint_IU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Delete Impfra delivery Appoint records.</summary>
        /// <param name="delap">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Impfra_delivery_Appoint_Delete([FromBody]delivery_app delap)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_APPT_DELETE", delap.PKID,delap.VGUID,delap.USERID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_delivery_Appoint_Delete");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update Impfra delivery records.</summary>
        /// <param name="del">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult Impfra_delivery_IU([FromBody]delivery del)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_IU", del.MODE, del.DELNO, del.CLIENT,
                    del.SRNO, del.DEORDER, del.AGTNAME, del.TEMPSTRING, del.ACT_DT, (del.ACT_TIME != null) ? del.ACT_TIME : "", (del.ACT_RMK != null) ? del.ACT_RMK : "", del.KEYFILED, del.USERID, del.VGUID, del.CITYCODE, 
                    del.CMPCODE, del.CITYCODE1, del.PALLET, del.TRUCK);
                var message = string.Empty;
                var subject = "";
                subject = ds.Tables[0].Rows[0][1].ToString();
                message = "<table border=1> <tr> <thead> <th>DELIVERYNO</th> <th>JOBNO</th> <th>IMPORTER</th> <th>MODE</th><th>PKGS</th><th>RDV DATE</th><th> DESTINATAIRE</th> ";
                message = message + "<th>DELIVERY_BY</th><th>KEYFIELD</th><th>DELIVERY_ENTERED_ON</th></thead> </tr>";
                if (ds.Tables.Count > 1)
                {
                    if (ds.Tables[1].Rows.Count >= 1)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            message = message + "<tr> <td>" + ds.Tables[1].Rows[i][0].ToString() + "</td><td>" + ds.Tables[1].Rows[i][1].ToString() + "</td><td>" + ds.Tables[1].Rows[i][2].ToString() + "</td><td>" + ds.Tables[1].Rows[i][3].ToString() + "</td>" + "<td>" + ds.Tables[1].Rows[i][4].ToString() + "</td>";
                            message = message + "<td>" + ds.Tables[1].Rows[i][5].ToString() + "</td>" + "<td>" + ds.Tables[1].Rows[i][6].ToString() + "</td>" + "<td>" + ds.Tables[1].Rows[i][7].ToString() + "</td>" + "<td>" + ds.Tables[1].Rows[i][8].ToString() + "</td>" + "<td>" + ds.Tables[1].Rows[i][9].ToString() + "</td></tr>";
                        }
                        message = message + "</table>";
                    }
                    Send_Mail("alerts@manilal.com", "venkatesh@manilal.com", "", "pdg.mp@manilal.com", subject, message);
                }
                 
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_delivery_IU");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform Delivery rest records.</summary>
        /// <param name="userid">userid parameter.</param>
        /// <param name="vguid">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Delivery_rest([FromUri] string userid, string vguid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_RESET", userid, vguid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Delivery_rest");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform DELIVERY BONMAGASINIER records.</summary>
        /// <param name="DELIVERYNO">DELIVERYNO parameter.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="SUPPLIER">Supplier code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult DELIVERY_BONMAGASINIER([FromUri]string DELIVERYNO, string CITYCODE, string SUPPLIER)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_BONMAGASINIER", DELIVERYNO, CITYCODE, (SUPPLIER != null) ? SUPPLIER : "", 1, "", "", "", "", "E");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/DELIVERY_BONMAGASINIER");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform Generate DELIVERY BONMAGASINIER records.</summary>
        /// <param name="DELIVERYNO">DELIVERYNO parameter.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="SUPPLIER">Supplier code.</param>
        /// <param name="nature">nature parameter.</param>
        /// <param name="dd">dd parameter.</param>
        /// <param name="makerid">User code of the record maker.</param>
        /// <param name="makerip">IP address of the record maker.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_DELIVERY_BONMAGASINIER([FromUri]string DELIVERYNO, string CITYCODE, string SUPPLIER, string nature, string dd, string makerid, string makerip)
        {
            DataSet dsDetails = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            dsDetails = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_IMPFRA_ACTUALDELIVERY_BONMAGASINIER",
                (DELIVERYNO != null) ? DELIVERYNO : "",
                (CITYCODE != null) ? CITYCODE : "",
                (SUPPLIER != null) ? SUPPLIER : "", 1,
               (nature != null) ? nature : "", (dd != null) ? dd : "",
                (makerid != null) ? makerid : "",
                (makerip != null) ? makerip : "", "R");

            int countDtColumn = dsDetails.Tables[1].Columns.Count;
           // stringBuilder.AppendLine(@"<style> td { mso-number-format:\@; } </style> ");

            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head>");
            stringBuilder.Append("<body><table width='100%' border='1' cellpadding='2' cellspacing='3' bordercolor='#000000'> ");
            stringBuilder.Append("<tr><td> <div align='center'><font size='6' face='Arial'><strong>BON MAGASINIER </strong></font></div></td>  </tr> ");
            stringBuilder.Append("<tr><td><table width='100%' border='0' cellspacing='0' cellpadding='0'>       ");
            stringBuilder.Append("<tr><td width='23%'><div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td>");
            stringBuilder.Append("<td width='77%'><table width='95%' border='0' align='center' cellpadding='2' cellspacing='2'><tr>");
            stringBuilder.Append("<td><b><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[1].Rows[0]["SUP_NAME"]) + "</font></b>");
            stringBuilder.Append(" <font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[1].Rows[0]["SUP_ADDRESS"]) + "&nbsp;</font>");
            stringBuilder.Append("<font size='2' face='Verdana, Arial, Helvetica, sans-serif'>&nbsp;</font></td> </tr>  </table></td> </tr> ");
            stringBuilder.Append("</table></td>  </tr>  <tr>     <td><table width='100%' border='1' cellspacing='2' cellpadding='2'> ");
            stringBuilder.Append("<tr><td width='25%'><strong><span style='font-size:10.0pt;font-family:Arial'>MAWB</span></strong></td>");
            stringBuilder.Append("<td colspan='2'><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[1].Rows[0]["MAWBNO"]) + "&nbsp;</font></td> </tr>");
            stringBuilder.Append("<tr> <td><strong><span style='font-size:10.0pt;font-family:Arial'>HAWB</span></strong></td>");
            stringBuilder.Append("<td colspan='2'><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[1].Rows[0]["HAWBNO"]) + "&nbsp;</font></td> </tr> ");
            stringBuilder.Append("<tr> <td><strong><span style='font-size:10.0pt;font-family:Arial'>NBREDE COLIS</span></strong></td>");
            stringBuilder.Append("<td width='40%'><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[1].Rows[0]["COLIS"]) + "&nbsp;</font></td> ");
            stringBuilder.Append("<td width='35%'><span style='font-size:10.0pt;font-family:Arial'>&nbsp;<strong>Date,signature, cachet</strong></span></td></tr>");
            stringBuilder.Append("<tr> <td><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS BRUT </span></strong></td> <td>");
            stringBuilder.Append("<font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[1].Rows[0]["POIDS"]) + "&nbsp;</font></td> <td rowspan='5'>&nbsp;</td>  </tr> ");
            stringBuilder.Append("<tr><td><strong><span style='font-size:10.0pt;font-family:Arial'>CUBAGE</span></strong></td>");
            stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[1].Rows[0]["CUBAGE"]) + "&nbsp;</font></td></tr> ");
            stringBuilder.Append("<tr><td><strong><span style='font-size:10.0pt;font-family:Arial'>NATURE</span></strong></td>");
            stringBuilder.Append("<td> <font size='2' face='Arial'> <span style='font-size:10.0pt;font-family:Arial'>" + nature + "&nbsp; </span> &nbsp;</font></td></tr>");
            stringBuilder.Append("<tr> <td><strong><span style='font-size:10.0pt;font-family:Arial'>D/D</span></strong></td>");
            stringBuilder.Append("<td><font size='2' face='Arial'> <span style='font-size:10.0pt;font-family:Arial'>" + dd + "&nbsp;</span></font></td></tr>");
            stringBuilder.Append("<tr><td><strong><span style='font-size:10.0pt;font-family:Arial'>DOUANE</span></strong></td>");
            stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[1].Rows[0]["DOUANE"]) + "&nbsp;</font></td> </tr></table></td>  </tr>");
            stringBuilder.Append("<tr><td height='114'><table width='95%' border='1' align='center' cellpadding='2' cellspacing='2'> ");
            stringBuilder.Append("<tr><td colspan='2'><font size='4' face='Arial'><strong>" + Convert.ToString(dsDetails.Tables[1].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr>");
            stringBuilder.Append(" <tr><td width='48%'><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[1].Rows[0]["CMPADDRESS"]) + "</font></td> ");
            stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(dsDetails.Tables[1].Rows[0]["CMP_TELENO"]) + "<br> ");
            stringBuilder.Append("FAX : " + Convert.ToString(dsDetails.Tables[1].Rows[0]["CMP_FAXNO"]) + "<br> ");
            stringBuilder.Append("E-MAIL : " + Convert.ToString(dsDetails.Tables[1].Rows[0]["EMAIL"]) + "<br><B>");
            stringBuilder.Append("EORI : " + Convert.ToString(dsDetails.Tables[1].Rows[0]["EORI_NUMBER"]) + " </B></font></td> </tr>");
            stringBuilder.Append("<tr><td colspan='2'><strong><font size='2' face='Arial'>JOB NO. : " + Convert.ToString(dsDetails.Tables[1].Rows[0]["JOBNO"]) + "</font></strong> </td> </tr></table> ");
            stringBuilder.Append("</td>  </tr> </table></body></html>");

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_BONMAGASINIER.doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        /// <summary>Perform DELIVERY BONDELIVRAISON records.</summary>
        /// <param name="DELIVERYNO">DELIVERYNO parameter.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult DELIVERY_BONDELIVRAISON([FromUri]string DELIVERYNO, string CITYCODE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_BONDELIVRAISON", DELIVERYNO, CITYCODE, 2, "", "E", "", "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/DELIVERY_BONDELIVRAISON");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform Generate DELIVERY BONDELIVRAISON records.</summary>
        /// <param name="DELIVERYNO">DELIVERYNO parameter.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="nature">nature parameter.</param>
        /// <param name="makerid">User code of the record maker.</param>
        /// <param name="makerip">IP address of the record maker.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_DELIVERY_BONDELIVRAISON([FromUri]string DELIVERYNO, string CITYCODE, string nature, string makerid, string makerip)
        {
            DataSet dsDetails = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            dsDetails = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_IMPFRA_ACTUALDELIVERY_BONDELIVRAISON",
                (DELIVERYNO != null) ? DELIVERYNO : "",
                (CITYCODE != null) ? CITYCODE : "", 2,
                 (nature != null) ? nature : "", "R", makerid, makerip);

            nature = (nature != null) ? nature : "";
            int countDtColumn = dsDetails.Tables[0].Columns.Count;
           // stringBuilder.AppendLine(@"<style> td { mso-number-format:\@; } </style> ");

            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head>");
            stringBuilder.Append("<body><table width='100%' border='1' cellpadding='2' cellspacing='3' bordercolor='#000000'>");
            stringBuilder.Append("<tr><td> <div align='center'><font size='6' face='Arial'><strong>BON DE LIVRAISON</strong></font></div></td>  </tr>  ");
            stringBuilder.Append("<tr><td><table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td width='23%' height='84'> ");
            stringBuilder.Append("<div align='center'><img src='http://www.manilal.com/MPLOGO003.jpg' width='134' height='84'></div></td>");
            stringBuilder.Append("<td width='77%'><table width='95%' border='1' align='center' cellpadding='2' cellspacing='2'><tr><td width='58%' valign='top'>");
            stringBuilder.Append("<font size='2' face='Arial'>ADDRESSDE LIVRASION :<br>" + Convert.ToString(dsDetails.Tables[0].Rows[0]["CON_ADDRESS"]));
            stringBuilder.Append("</font></td><td width='42%' valign='top'><font size='2' face='Arial'>DATEDE LIVRAISON:<br>");
            stringBuilder.Append(Convert.ToString(dsDetails.Tables[0].Rows[0]["APPTDT"]) + " <br> <br> HORAIRE:<br>" + Convert.ToString(dsDetails.Tables[0].Rows[0]["APPTTIME"]));
            stringBuilder.Append("</font></td></tr></table></td></tr></table></td></tr>");
            stringBuilder.Append("<tr><td><table width='100%' border='1' cellspacing='2' cellpadding='2'> <tr><td width='25%'><strong>");
            stringBuilder.Append("<span style='font-size:10.0pt;font-family:Arial'>MAWB</span></strong></td> <td colspan='2'><font size='2' face='Arial'>");
            stringBuilder.Append(Convert.ToString(dsDetails.Tables[0].Rows[0]["MAWBNO"]) + "&nbsp;</font></td>");
            stringBuilder.Append("</tr><tr><td><strong><span style='font-size:10.0pt;font-family:Arial'>HAWB</span></strong></td> ");
            stringBuilder.Append("<td colspan='2'><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[0].Rows[0]["HAWBNO"]) + "&nbsp;</font></td></tr>");
            stringBuilder.Append("<tr><td><strong><span style='font-size:10.0pt;font-family:Arial'>NBRE DE COLIS</span></strong></td>");
            stringBuilder.Append("<td width='40%'><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[0].Rows[0]["COLIS"]) + "&nbsp;&nbsp;");
            stringBuilder.Append("</font></td><td width='35%'><span style='font-size:10.0pt;font-family:Arial'>&nbsp;<strong>Date,signature, cachet</strong></span></td></tr>");
            stringBuilder.Append("<tr> <td><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS BRUT </span></strong></td> <td><font size='2' face='Arial'>");
            stringBuilder.Append(Convert.ToString(dsDetails.Tables[0].Rows[0]["POIDS"]) + "&nbsp;&nbsp;");
            stringBuilder.Append("&nbsp;</font></td> <td rowspan='5'>&nbsp;</td> </tr><tr> <td><strong><span style='font-size:10.0pt;font-family:Arial'>CUBAGE</span></strong></td>");
            stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[0].Rows[0]["CUBAGE"]) + "&nbsp;&nbsp;");
            stringBuilder.Append("&nbsp;</font></td></tr><tr> <td><strong><span style='font-size:10.0pt;font-family:Arial'>NATURE</span></strong></td> ");
            stringBuilder.Append("<td> <font size='2' face='Arial'> <span style='font-size:10.0pt;font-family:Arial'>" + nature + "&nbsp;</span> &nbsp;</font></td> </tr>");
            stringBuilder.Append("<tr> <td><strong><span style='font-size:10.0pt;font-family:Arial'>ORDERNO.</span></strong></td> ");
            stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[0].Rows[0]["ORDERNO"]) + "&nbsp;</font></td> </tr> <tr><td><strong>");
            stringBuilder.Append("<span style='font-size:10.0pt;font-family:Arial'>DOUANE</span></strong></td> <td><font size='2' face='Arial'>");
            stringBuilder.Append(Convert.ToString(dsDetails.Tables[0].Rows[0]["DOUANE"]) + "&nbsp;</font></td></tr>");
            stringBuilder.Append("</table></td></tr><tr> <td height='114'><table width='95%' border='1' align='center' cellpadding='2' cellspacing='2'> ");
            stringBuilder.Append("<tr><td colspan='2'><font size='4' face='Arial'><strong>" + Convert.ToString(dsDetails.Tables[0].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr> ");
            stringBuilder.Append("<tr><td width='48%'><font size='2' face='Arial'>" + Convert.ToString(dsDetails.Tables[0].Rows[0]["CMPADDRESS"]));
            stringBuilder.Append("</font></td><td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(dsDetails.Tables[0].Rows[0]["CMP_TELENO"]) + "<br> ");
            stringBuilder.Append("FAX : " + Convert.ToString(dsDetails.Tables[0].Rows[0]["CMP_FAXNO"]) + "<br>  E-MAIL : " + Convert.ToString(dsDetails.Tables[0].Rows[0]["EMAIL"]));
            stringBuilder.Append("<br><b>EORI : " + Convert.ToString(dsDetails.Tables[0].Rows[0]["EORI_NUMBER"]) + " </b> </font></td></tr>");
            stringBuilder.Append("<tr> <td colspan='2'><strong><font size='2' face='Arial'>JOB NO. : " + Convert.ToString(dsDetails.Tables[0].Rows[0]["JOBNO"]) + "</font></strong> </td></tr></table></td></tr>  </table></body></html>");
            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_BONDELIVRAISON.doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }
        /// <summary>Perform DELIVERY ORDERDETRANSPORT records.</summary>
        /// <param name="DELIVERYNO">DELIVERYNO parameter.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="DEST">DEST parameter.</param>
        /// <param name="ETAFLG">ETAFLG parameter.</param>
        /// <param name="ETADT">ETADT parameter.</param>
        /// <param name="TRANSPORT">TRANSPORT parameter.</param>
        /// <param name="STATUT_DUANE">STATUT DUANE parameter.</param>
        /// <param name="DATE_ENLEVEMENT">DATE ENLEVEMENT parameter.</param>
        /// <param name="TARIF">TARIF parameter.</param>
        /// <param name="MAKERID">User code of the record maker.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult DELIVERY_ORDERDETRANSPORT([FromUri]string DELIVERYNO, string CITYCODE, string DEST, string ETAFLG, string ETADT, string TRANSPORT, string STATUT_DUANE, string DATE_ENLEVEMENT, string TARIF, string MAKERID, string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_ORDREDETRANSPORT", DELIVERYNO, CITYCODE, 'B',
                        (DEST != null) ? DEST : "",
                        (ETAFLG != null) ? ETAFLG : "",
                        (ETADT != null) ? ETADT : "",
                        (TRANSPORT != null) ? TRANSPORT : "",
                        (STATUT_DUANE != null) ? STATUT_DUANE : "",
                        (DATE_ENLEVEMENT != null) ? DATE_ENLEVEMENT : "",
                        (TARIF != null) ? TARIF : "", MAKERID, mode);

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/DELIVERY_ORDERDETRANSPORT");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }
        /// <summary>Perform Generate DELIVERY ORDERDETRANSPORT records.</summary>
        /// <param name="DELIVERYNO">DELIVERYNO parameter.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="DEST">DEST parameter.</param>
        /// <param name="ETAFLG">ETAFLG parameter.</param>
        /// <param name="ETADT">ETADT parameter.</param>
        /// <param name="TRANSPORT">TRANSPORT parameter.</param>
        /// <param name="STATUT_DUANE">STATUT DUANE parameter.</param>
        /// <param name="DATE_ENLEVEMENT">DATE ENLEVEMENT parameter.</param>
        /// <param name="TARIF">TARIF parameter.</param>
        /// <param name="MAKERID">User code of the record maker.</param>
        /// <param name="username">username parameter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_DELIVERY_ORDERDETRANSPORT([FromUri]string DELIVERYNO, string CITYCODE, string DEST, string ETAFLG, string ETADT, string TRANSPORT, string STATUT_DUANE, string DATE_ENLEVEMENT, string TARIF, string MAKERID, string username, string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();


            StringBuilder stringBuilder = new StringBuilder();
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_ORDREDETRANSPORT", DELIVERYNO, CITYCODE, 'R',
                    (DEST != null) ? DEST : "",
                    (ETAFLG != null) ? ETAFLG : "",
                    (ETADT != null) ? ETADT : "",
                    (TRANSPORT != null) ? TRANSPORT : "",
                    (STATUT_DUANE != null) ? STATUT_DUANE : "",
                    (DATE_ENLEVEMENT != null) ? DATE_ENLEVEMENT : "",
                    (TARIF != null) ? TARIF : "", MAKERID, mode);
            int countDtColumn = ds.Tables[0].Columns.Count;
            //stringBuilder.AppendLine(@"<style> td { mso-number-format:\@; } </style> ");
            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head><body>");
            stringBuilder.Append("<table width='100%' border='1' cellspacing='3' cellpadding='3'> <tr> <td><table width='100%' border='0' cellspacing='0' cellpadding='0'> ");
            stringBuilder.Append("<tr><td width='23%' height='84'> <div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td> ");
            stringBuilder.Append("<td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0'>");
            stringBuilder.Append("<tr><td colspan='2'><font size='6' face='Arial'><strong>" + Convert.ToString(ds.Tables[2].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr> ");
            stringBuilder.Append("<tr> <td width='48%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["ADDRES"]) + "</font></td>");
            stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(ds.Tables[2].Rows[0]["CMP_TELENO"]) + "<br>");
            stringBuilder.Append("FAX : " + Convert.ToString(ds.Tables[2].Rows[0]["CMP_FAXNO"]) + "<br> E-MAIL : " + Convert.ToString(ds.Tables[2].Rows[0]["EMAIL"]) + "<br>");
            stringBuilder.Append("<B>EORI : " + Convert.ToString(ds.Tables[2].Rows[0]["EORI_NUMBER"]) + "</B></font></td> </tr> </table></td> </tr></table></td>    </tr>");
            stringBuilder.Append("<tr><td><table width='100%' border='1' cellpadding='2' cellspacing='2'> <tr> <td width='41%'>");
            stringBuilder.Append("<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><strong>DESTINATAIRE</strong></font></td>");
            stringBuilder.Append("<td width='59%'> <font size='2' face='Verdana, Arial, Helvetica, sans-serif'> <b><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["SUP_NAME"]) + "<br>");
            stringBuilder.Append("</font></b><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["SUP_ADDRESS"]) + "&nbsp;</font></font></td> </tr>");
            stringBuilder.Append("</table></td> </tr><tr><td> <div align='center'><strong><font size='4' face='Arial'><strong>");

            stringBuilder.Append("ORDRE DE TRANSPORT<font size=2>(INDIVIDUAL SHIPMENT)</font></strong></font></strong></div></td></tr> <tr><td>");

            stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");
            if (mode == "air")
            {
                stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>REF A RAPPELER</span></strong></td>");
            }
            else
            { stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>OUR REF</span></strong></td>"); }
            stringBuilder.Append("<td width='58%' ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["JOBNO"]) + "</span></td> </tr> <tr style='mso-yfti-irow:0'> ");
            if (mode == "air")
            {
                stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>MAWB</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["MAWBNO"]) + "</font></p></td></tr><tr style='mso-yfti-irow:1'>");
                stringBuilder.Append("<td > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>HAWB</span></strong></p></td>  ");
                stringBuilder.Append("<td > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["HAWBNO"]) + "</span></p></td> </tr> ");
                stringBuilder.Append("<tr style='mso-yfti-irow:3;mso-yfti-lastrow:yes'> <td ><strong><span style='font-size:10.0pt;font-family:Arial'>CDE</span></strong></td>");
            }
            else
            {
                stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CONTAINER</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["CONATINERNODET"]) + "</font></p></td></tr><tr style='mso-yfti-irow:1'>");
                stringBuilder.Append("<td > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>MBL</span></strong></p></td>  ");
                stringBuilder.Append("<td > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["HAWBNO"]) + "</span></p></td> </tr> ");
                stringBuilder.Append("<td > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>P.O.L</span></strong></p></td>  ");
                stringBuilder.Append("<td > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["POL"]) + "</span></p></td> </tr> ");
                stringBuilder.Append("<td > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>SHIPPING LINE</span></strong></p></td>  ");
                stringBuilder.Append("<td > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["SHIPLINE"]) + "</span></p></td> </tr> ");
                stringBuilder.Append("<tr style='mso-yfti-irow:3;mso-yfti-lastrow:yes'> <td ><strong><span style='font-size:10.0pt;font-family:Arial'>ORDERNO</span></strong></td>");
            }
            stringBuilder.Append("<td ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["ORDERNO"]) + "&nbsp;  </span></td> </tr> <tr style='mso-yfti-irow:2'> ");
            stringBuilder.Append("<td > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB  DE COLIS</span></strong></p></td>  ");
            stringBuilder.Append("<td > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["COLIS"]) + "</span></p></td> </tr>");
            stringBuilder.Append("<tr style='mso-yfti-irow:3;mso-yfti-lastrow:yes'> <td > <p class=MsoNormal><strong>");
            stringBuilder.Append("<span style='font-size:10.0pt;font-family:Arial'>POIDS</span></strong></p></td> ");
            stringBuilder.Append("<td > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["POIDS"]) + "&nbsp; </span></p></td> </tr> ");
            stringBuilder.Append("<tr style='mso-yfti-irow:3;mso-yfti-lastrow:yes'> <td ><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></td> ");
            stringBuilder.Append("<td ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["CUBAGE"]) + "&nbsp;   </span></td>  </tr> ");
            if (mode == "sea")
            {
                stringBuilder.Append("<tr style='mso-yfti-irow:3;mso-yfti-lastrow:yes'> <td ><strong><span style='font-size:10.0pt;font-family:Arial'>POD</span></strong></td> ");
                stringBuilder.Append("<td ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["POD"]) + "&nbsp;   </span></td>  </tr> ");
                stringBuilder.Append("<tr style='mso-yfti-irow:3;mso-yfti-lastrow:yes'> <td ><strong><span style='font-size:10.0pt;font-family:Arial'>ETA</span></strong></td> ");
                stringBuilder.Append("<td ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["eta"]) + "&nbsp;   </span></td>  </tr>  ");
            }
            if (mode == "air")
            {
                stringBuilder.Append(" <tr style='mso-yfti-irow:3;mso-yfti-lastrow:yes'> <td ><strong><span style='font-size:10.0pt;font-family:Arial'> " + Convert.ToString(ds.Tables[2].Rows[0]["ETA_FLG"]) + "   </span></strong></td>");
                stringBuilder.Append(" <td ><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["ETA_LILPAR"]) + "</font></td>");
                stringBuilder.Append("</tr> </table></td></tr> <tr> <td height='24'> <table width='100%' border='1' cellspacing='2' cellpadding='2'> ");
                stringBuilder.Append("<tr><td><span style='font-size:10.0pt;font-family:Arial'><strong>ADRESSE  D'ENLEVEMENT</strong></span>");
                stringBuilder.Append("<font size='2' face='Verdana, Arial, Helvetica, sans-serif'>&nbsp; </font></td> </tr> <tr><td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["TRANS_ADDRESS"]) + "<br> ");
                stringBuilder.Append("</font><font size='2' face='Arial'>  &nbsp;</font></td> </tr>  ");//</table></td> </tr>
            }
            if (mode == "sea")
            {
                stringBuilder.Append("  <tr> <td height='24' colspan='2'> <table width='100%' border='1' cellspacing='2' cellpadding='2'>");
                stringBuilder.Append("<tr><td><span style='font-size:10.0pt;font-family:Arial'><strong>QUAI D'ENLEVEMENT  </strong></span> </td>");
                stringBuilder.Append("<td><span style='font-size:10.0pt;font-family:Arial'><strong>QUAI DE RESTITUTION  </strong></span> </td>");
                stringBuilder.Append("<td><span style='font-size:10.0pt;font-family:Arial'><strong>AVANT LE  </strong></span> </td></tr> ");
                stringBuilder.Append("<tr> <td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["ENLEVEMENT"]) + "</font></td>  ");
                stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["RESTITUTION"]) + " </font></td>");
                stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["FREEDATE"]) + " </font></td></tr></table></td>    </tr>");

            }
            stringBuilder.Append("</table></td>    </tr>  <tr> <td><table class=MsoNormalTable border=1 cellpadding=0 width='100%'   style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");
            stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' height='20' ><strong><span style='font-size:10.0pt;font-family:Arial'>DATE  ENLEVEMENT </span></strong></td>");
            if (mode == "air")
            {
                stringBuilder.Append("<td width='58%' ><strong><span style='font-size:10.0pt;font-family:Arial'>STATUT  DOUANE </span></strong></td>  </tr> ");
            }
            else { stringBuilder.Append("<td width='58%' ><strong><span style='font-size:10.0pt;font-family:Arial'>STATUT  DOUANE / TRANSITAIRE  </span></strong></td>  </tr> "); }

            stringBuilder.Append("<tr style='mso-yfti-irow:0'> <td > <p class=MsoNormal> <font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["DATE_ENLEVEMENT"]) + "</font>    </p></td> ");
            stringBuilder.Append("<td style='width:10.0%;padding:1.5pt 1.5pt 1.5pt 1.5pt'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["STATUT_DUANE"]) + "</font></td> </tr> </table></td></tr> ");
            stringBuilder.Append("<tr> <td> <table class=MsoNormalTable border=1 cellpadding=0 width='100%'   style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'> ");
            stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>LIEU  DE LIVRAISON </span></strong></td> ");
            if (mode == "air")
            { stringBuilder.Append("<td width='58%'><strong><span style='font-size:10.0pt;font-family:Arial'>DATE  ET HEURE</span></strong></td> </tr> "); }
            else { stringBuilder.Append("<td width='58%'><strong><span style='font-size:10.0pt;font-family:Arial'>DATE  ET HEURE / REFERENCES DE LIVRAISON </span></strong></td> </tr> "); }

            stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td style='width:10.0%;padding:1.5pt 1.5pt 1.5pt 1.5pt'> <p class=MsoNormal><font size='2' face='Arial'> ");
            stringBuilder.Append(Convert.ToString(ds.Tables[2].Rows[0]["CON_ADDRESS"]));
            stringBuilder.Append("</font></p></td><td style='width:10.0%;padding:1.5pt 1.5pt 1.5pt 1.5pt'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["APPTTIME"]) + "&nbsp;</font></td>");
            stringBuilder.Append("</tr> </table></td>   </tr>  <tr> <td height='27'> <table class=MsoNormalTable border=1 cellpadding=0 width='100%'   style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'> ");
            stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>TARIF</span></strong></td>");
            stringBuilder.Append("<td width='58%' ><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[2].Rows[0]["TARIF"]) + "</font></td>  </tr>   </table></td> </tr>");

            stringBuilder.Append("<tr> <td> <p><font size='3' face='Arial'>" + Convert.ToString(ds.Tables[3].Rows[0]["ENCLOSURE"]));
            stringBuilder.Append(username + "&nbsp; </font><font size='3' face='Arial'><strong><br>          </strong></font></p></td>    </tr>  </form></table></body></html>");
            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_ORDERDETRANSPORT.doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;

        }

        /// <summary>Perform DELIVERY CONFIRMATIONDELIVRAISON records.</summary>
        /// <param name="DELIVERYNO">DELIVERYNO parameter.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult DELIVERY_CONFIRMATIONDELIVRAISON([FromUri]string DELIVERYNO, string CITYCODE, string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_CONFIRMATIONDELIVRAISON", DELIVERYNO, CITYCODE, 'E', "", "", "", "", "", "", "", "", "", "", "", mode, "");

            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/DELIVERY_CONFIRMATIONDELIVRAISON");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform Generate DELIVERY CONFIRMATIONDELIVRAISON records.</summary>
        /// <param name="DELIVERYNO">DELIVERYNO parameter.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="MSGTYPE">MSGTYPE parameter.</param>
        /// <param name="CC">CC parameter.</param>
        /// <param name="DATE">DATE parameter.</param>
        /// <param name="ATTN1">ATTN1 parameter.</param>
        /// <param name="ATTN2">ATTN2 parameter.</param>
        /// <param name="VOLNO">VOLNO parameter.</param>
        /// <param name="NATURE">NATURE parameter.</param>
        /// <param name="T1Ci_JOINTNO">T1 C i J O I N T N O parameter.</param>
        /// <param name="TRANSPORTER">TRANSPORTER parameter.</param>
        /// <param name="IMMATRICULATION">IMMATRICULATION parameter.</param>
        /// <param name="MAKERID">User code of the record maker.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="makerip">IP address of the record maker.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Generate_DELIVERY_CONFIRMATIONDELIVRAISON([FromUri]string DELIVERYNO, string CITYCODE, string MSGTYPE, string CC, string DATE, string ATTN1, string ATTN2, string VOLNO, string NATURE, string T1Ci_JOINTNO, string TRANSPORTER, string IMMATRICULATION, string MAKERID, string mode, string makerip)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();


            StringBuilder stringBuilder = new StringBuilder();
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_CONFIRMATIONDELIVRAISON", DELIVERYNO, CITYCODE, 'R',
            (MSGTYPE != null) ? MSGTYPE : "",
            (CC != null) ? CC : "",
            (DATE != null) ? DATE : "",
            (ATTN1 != null) ? ATTN1 : "",
            (ATTN2 != null) ? ATTN2 : "",
            (VOLNO != null) ? VOLNO : "",
            (NATURE != null) ? NATURE : "",
            (T1Ci_JOINTNO != null) ? T1Ci_JOINTNO : "",
            (TRANSPORTER != null) ? TRANSPORTER : "",
            (IMMATRICULATION != null) ? IMMATRICULATION : "",
            (MAKERID != null) ? MAKERID : "", mode, makerip);
            int countDtColumn = ds.Tables[0].Columns.Count;
           // stringBuilder.AppendLine(@"<style> td { mso-number-format:\@; } </style> ");
            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head><body>");
            stringBuilder.Append("<body><table width='100%' border='1' cellspacing='3' cellpadding='3'> <tr>  <td><table width='100%' border='0' cellspacing='0' cellpadding='0'>");
            stringBuilder.Append("<tr> <td width='23%' height='84'> <div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td>");
            stringBuilder.Append("<td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0'> <tr> <td colspan='2'>");
            stringBuilder.Append("<font size='6' face='Arial'><strong>" + Convert.ToString(ds.Tables[0].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr><tr><td width='48%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ADDRES"]) + "</font></td>");
            stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_TELENO"]) + "<br>  FAX : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_FAXNO"]) + "<br>   E-MAIL : " + Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]) + "<br> ");
            stringBuilder.Append("<B>EORI : " + Convert.ToString(ds.Tables[0].Rows[0]["EORI_NUMBER"]) + "</B> </font></td> </tr> </table></td> </tr> </table></td> </tr><tr> <td>");
            stringBuilder.Append("<div align='right'> <font size='2' face='Arial'><strong>" + MSGTYPE + "</strong></font>  </div></td></tr><tr>  <td>");
            stringBuilder.Append("<table width='100%' border='0' align='center' cellpadding='2' cellspacing='2'> <tr>  <td width='10%'>");
            stringBuilder.Append("<strong><font size='2' face='Arial'>TO :</font></strong></td> <td width='43%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["CON_NAME"]) + "&nbsp;</font></td> ");
            stringBuilder.Append("<td width='11%'><strong><font size='2' face='Arial'>ATTN :</font></strong></td>  <td width='36%'><font size='2' face='Arial'>");
            stringBuilder.Append("<span style='font-size:10.0pt;font-family:Arial'>" + ATTN1 + "</span> </font></td>  </tr>  <tr>  <td><strong><font size='2' face='Arial'>");
            stringBuilder.Append("CC :</font></strong></td> <td><font size='2' face='Arial'> <span style='font-size:10.0pt;font-family:Arial'>" + CC + "</span> ");
            stringBuilder.Append("</font></td> <td><strong><font size='2' face='Arial'>ATTN :</font></strong></td> <td><font size='2' face='Arial'>");
            stringBuilder.Append("<span style='font-size:10.0pt;font-family:Arial'>" + ATTN2 + "</span> </font></td> </tr> <tr><td><strong>");
            stringBuilder.Append("<font size='2' face='Arial'>DATE :</font></strong></td> <td><font size='2' face='Arial'> ");
            stringBuilder.Append("<span style='font-size:10.0pt;font-family:Arial'>" + DATE + "</span>               </font></td>            <td>&nbsp;</td> ");
            stringBuilder.Append("<td><font size='2' face='Arial'>&nbsp;</font></td> </tr> <tr>  <td><strong><font size='2' face='Arial'>N/REF :</font></strong></td> ");
            stringBuilder.Append("<td colspan='3'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["JOBNO"]) + "&nbsp; </font><font size='2' face='Arial'>&nbsp;</font></td> </tr></table>");
            stringBuilder.Append("</td></tr><tr><td height='27'> <div align='center'><strong><font size='3' face='Arial'>CONFIRMATION DE LIVRAISON</font></strong>");
            stringBuilder.Append("</div><br> <font size='2' face='Arial'>NOUS AVONS LE PLAISIR DE VOUS CONFIRMER DE LIVRAISON:</font></td>    </tr>    ");
            stringBuilder.Append("<tr><td> <table width='100%' border='1' cellpadding='2' cellspacing='1'> ");
            if (mode == "air")
            {
                stringBuilder.Append("<tr> <td width='20%'><strong><font size='2' face='Arial'>MAWB :</font></strong></td>");
                stringBuilder.Append("<td width='80%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["MAWBNO"]) + "&nbsp;</font></td></tr>");
            }
            if (mode == "air")
            { stringBuilder.Append("<tr> <td><strong><font size='2' face='Arial'>HAWB :</font></strong></td> "); }
            if (mode == "sea")
            { stringBuilder.Append("<tr> <td><strong><font size='2' face='Arial'>HBL :</font></strong></td> "); }
            stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["HAWBNO"]) + "&nbsp;</font></td></tr>");
            if (mode == "sea")
            {
                stringBuilder.Append("<tr> <td><strong><font size='2' face='Arial'>VESSEL :</font></strong></td> ");
                stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["VSL"]) + "&nbsp;</font></td></tr>");
                stringBuilder.Append("<tr> <td><strong><font size='2' face='Arial'>ETA :</font></strong></td> ");
                stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ETA"]) + "&nbsp;</font></td></tr>");
                stringBuilder.Append("<tr> <td><strong><font size='2' face='Arial'>CONTAINER :</font></strong></td> ");
                stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["CONTAINER"]) + "&nbsp;</font></td></tr>");

            }

            stringBuilder.Append("<tr><td><strong><font size='2' face='Arial'>PROVENANCE :</font></strong></td>");
            stringBuilder.Append(" <td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ORIGIN"]) + "&nbsp;</font></td> </tr>");
            if (mode == "air")
            {
                stringBuilder.Append(" <tr>  <td><strong><font size='2' face='Arial'>VOL NO :</font></strong></td>  ");
                stringBuilder.Append("<td><font size='2' face='Arial'> <span style='font-size:10.0pt;font-family:Arial'>" + VOLNO + "</span>  </font></td>   </tr>  ");
            }
            stringBuilder.Append("</table></td>");

            stringBuilder.Append("</tr> <tr><td><table width='100%' border='1' cellspacing='1' cellpadding='2'> ");
            stringBuilder.Append("<tr> <td width='20%'><strong><font size='2' face='Arial'>NBRE DE COLIS:</font></strong></td> ");
            stringBuilder.Append("<td width='80%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["COLIS"]));
            stringBuilder.Append("</font></td></tr> <tr>  <td><strong><font size='2' face='Arial'>POIDS BRUT:</font></strong></td> ");
            stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["POIDS"]) + "&nbsp;<strong>KG</strong></font></td> </tr>");
            stringBuilder.Append("<tr> <td><strong><font size='2' face='Arial'>CUBAGE :</font></strong></td> <td>");
            stringBuilder.Append("<font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["CUBAGE"]) + "&nbsp;<strong>M3</strong></font></td> </tr><tr> <td><strong>");
            stringBuilder.Append("<font size='2' face='Arial'>NATURE :</font></strong></td>  <td><font size='2' face='Arial'>");
            stringBuilder.Append("<span style='font-size:10.0pt;font-family:Arial'>" + NATURE + "</span>  &nbsp;</font></td></tr> </table></td></tr> ");
            stringBuilder.Append("<tr>       <td><table width='100%' border='1' cellspacing='1' cellpadding='2'> <tr> ");
            stringBuilder.Append("<td width='20%'><strong><font size='2' face='Arial'>PO NO :</font></strong></td> ");
            stringBuilder.Append("<td width='80%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ORDERNO"]) + "&nbsp;</font></td>          </tr> ");
            stringBuilder.Append("<tr> <td><strong><font size='2' face='Arial'>SHPR :</font></strong></td>");
            stringBuilder.Append("<td><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["SHIPPER"]) + "&nbsp;</font></td>  </tr>  </table></td> </tr> ");
            stringBuilder.Append("<tr> <td height='68'> <table width='100%' border='1' cellspacing='1' cellpadding='2'>  <tr>");
            stringBuilder.Append("<td width='20%'><strong><font size='2' face='Arial'>DATE DE LIVRASION:</font></strong></td> ");
            stringBuilder.Append("<td width='80%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["DELIVERYDT"]) + "&nbsp; </font></td>   </tr> ");
            stringBuilder.Append("<tr> <td><strong><font size='2' face='Arial'>T1 Ci-JOINT NO:</font></strong></td> ");
            stringBuilder.Append("<td><font size='2' face='Arial'> <span style='font-size:10.0pt;font-family:Arial'>" + T1Ci_JOINTNO + "</span>");
            stringBuilder.Append("</font></td></tr><tr> <td><strong><font size='2' face='Arial'>TRANSPORTEUR:</font></strong></td>");
            stringBuilder.Append("<td><font size='2' face='Arial'> <span style='font-size:10.0pt;font-family:Arial'>" + TRANSPORTER + "</span>  </font></td>  </tr>");
            if (mode == "air")
            {
                stringBuilder.Append("<tr><td><strong><font size='2' face='Arial'>IMMATRICULATION:</font></strong></td>  ");
                stringBuilder.Append("<td><font size='2' face='Arial'> <span style='font-size:10.0pt;font-family:Arial'>" + IMMATRICULATION + "</span></font></td></tr>");
            }
            stringBuilder.Append("</table></td></tr></form></table></body></html>");

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_CONFIRMATIONDELIVRAISON.doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;

        }
        /***************************Consolidation*************************************/
        /// <summary>Retrieve GetConsoleNoSearch records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult GetConsoleNoSearch([FromBody]ConsolidationSearch obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_GETCONSOLENO_SEARCH",
                    obj.Mode, obj.Value);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleNoSearch");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsoleNoList records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult GetConsoleNoList([FromBody]ConsolidationSearch obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),  CommandType.StoredProcedure,  "USP_IMPFRA_CONSOLE_LIST",  obj.Mode, obj.Value, (obj.FromDate != null) ? obj.FromDate : "", (obj.ToDate != null) ? obj.ToDate : "") ;
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleNoList");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsoleNoView records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult GetConsoleNoView([FromBody]ConsolidationSearch obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_VIEW",
                    obj.Value, obj.UserId, obj.Username);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleNoView");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsoleRemark records.</summary>
        /// <param name="containerno">containerno parameter.</param>
        /// <param name="consoleno">consoleno parameter.</param>
        /// <param name="type">type parameter.</param>
        /// <param name="jobno">Job number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsoleRemark([FromUri]string containerno, string consoleno, string type, string jobno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_GET_REMARK",
                    (containerno != null) ? containerno : "",
                    (consoleno != null) ? consoleno : "",
                    (type != null) ? type : "",
                    (jobno != null) ? jobno : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleRemark");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetCustomDocType records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetCustomDocType()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_CUSTOM_DOX_TYPE_FILL");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetCustomDocType");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform PostConsoleNoRemarkUpdate records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult PostConsoleNoRemarkUpdate([FromBody]ConsolidationRemarkUpdate obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_REMARK_IU",
                    obj.ContainerNo, obj.ConsoleNo, obj.Type, obj.JobNo, obj.Value, obj.Value1, obj.Value2,
                    obj.CmpId, obj.CityCode, obj.CmpCode, obj.CustomDocType, obj.MakerIp, obj.PkId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/PostConsoleNoRemarkUpdate");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetContainerTranshipCityFill records.</summary>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetContainerTranshipCityFill()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_CONTAINER_TRANSHIP_CITY_FILL");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetContainerTranshipCityFill");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetContainerTranshipVesselFill records.</summary>
        /// <param name="value">Search filter value.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetContainerTranshipVesselFill([FromUri]string value, string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_CONTAINER_TRANSHIP_VESSEL_FILL", value, mode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetContainerTranshipVesselFill");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetContainerExchangeRateView records.</summary>
        /// <param name="containerno">containerno parameter.</param>
        /// <param name="consoleno">consoleno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetContainerExchangeRateView([FromUri]string containerno, string consoleno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_CONTAINER_EXCHANGE_RATE", containerno, consoleno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetContainerExchangeRateView");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsoleDossierMainView records.</summary>
        /// <param name="consoleno">consoleno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsoleDossierMainView([FromUri]string consoleno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_DOISSER_MAIN_VIEW", consoleno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleDossierMainView");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsoleDossierJobView records.</summary>
        /// <param name="jobno">Job number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsoleDossierJobView([FromUri]string jobno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_DOISSER_JOB_VIEW", jobno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleDossierJobView");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform ConsolidationContainerUpdate records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsolidationContainerUpdate([FromBody]ConsolidationExchangeRate obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_CONTAINER_UPDATE",
                    obj.ConsoleNo, obj.ContainerNo, obj.TransportOne, obj.ConnVesselOne, obj.EtdPortOne,
                    obj.TransportTwo, obj.ConnVesselTwo, obj.EtdPortTwo, obj.DestCurOne, obj.ValueOne,
                    obj.DestCurTwo, obj.ValueTwo, obj.OnwardBy, obj.OnwardPort, "", obj.CmpId);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/ConsolidationContainerUpdate");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsoleDossierObservationList records.</summary>
        /// <param name="consoleno">consoleno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsoleDossierObservationList([FromUri]string consoleno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_DOSSIER_OBSERVATION_LIST", consoleno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleDossierObservationList");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform ConsolidationConsoleDossierObservationIu records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsolidationConsoleDossierObservationIu([FromBody]ConsolidationDossierObservartion obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_DOSSIER_OBSERVATION_IU",
                    obj.PK_ID, obj.CONSOLENO, obj.V_ETA1, obj.NEW_ETA1, obj.V_ETA2, obj.NEW_ETA2, obj.V_ETA3,
                    obj.NEW_ETA3, obj.REL_PRINT, obj.REL_SENT, obj.REQ_RDV, obj.CONF_RDV,
                    obj.CAN_DT, obj.PINCODE, obj.ORD_DE_TRANS, obj.DO_PIN_TRANS, obj.INSTR_DOUANE,
                    obj.COPY_DOC_MAIL, obj.ORG_DOC, obj.T1_RECVD, obj.T1_SENT, obj.SHPLINE_INVDT,
                    obj.PAYMT_SHPLINE_INVDT, obj.CMPID, obj.CITYCODE, obj.CMPCODE, obj.MAKERIP);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/ConsolidationConsoleDossierObservationIu");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsoleJobDossierObservationList records.</summary>
        /// <param name="jobno">Job number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsoleJobDossierObservationList([FromUri]string jobno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_JOB_DOSSIER_OBSERVATION_LIST", jobno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleJobDossierObservationList");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform ConsolidationConsoleJobDossierObservationIu records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsolidationConsoleJobDossierObservationIu([FromBody]ConsolidationJobDossierObservartion obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_JOB_DOSSIER_OBSERVATION_IU",
                    obj.PK_ID, obj.JOBNO, obj.INSTR_DOUANE, obj.T1_RECVD, obj.T1_SENT,
                    obj.ORD_DE_TRANS, obj.REQ_RDV, obj.CONF_RDV, obj.COPY_DOC_MAIL,
                    obj.SHPLINE_INVDT, obj.PAYMT_SHPLINE_INVDT, obj.CMPID, obj.CITYCODE,
                    obj.CMPCODE, obj.MAKERIP);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/ConsolidationConsoleJobDossierObservationIu");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsoleJobReceptionList records.</summary>
        /// <param name="jobno">Job number.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsoleJobReceptionList([FromUri]string jobno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_JOB_RECEPTION_LIST", jobno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleJobReceptionList");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform ConsolidationConsoleJobReceptionIu records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult ConsolidationConsoleJobReceptionIu([FromBody]ConsolidationJobReception obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_JOB_RECEPTION_IU",
                    obj.PK_ID, obj.JOBNO, obj.CONSOLENO, obj.CTNS_RECUS, obj.PAL,
                    obj.TYPE_PAL, obj.RESERVES, obj.BON_MAG_DU, obj.PACK, obj.DELIVERY_SITE,
                    obj.CMPID, obj.CITYCODE, obj.CMPCODE, obj.MAKERIP);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/ConsolidationConsoleJobReceptionIu");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve GetConsolDeliveryView records.</summary>
        /// <param name="deliveryno">deliveryno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsolDeliveryView([FromUri]string deliveryno )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_DELIVERY_VIEW",
                    deliveryno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsolDeliveryView");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /***************************Consolidation*************************************/
        //----------------Manual Console---------------------------------/

        public IHttpActionResult GetConsolePageload()
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_MST_PAGELOAD");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsolePageload");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsoleEditmodeview records.</summary>
        /// <param name="consoleno">consoleno parameter.</param>
        /// <param name="cmpcode">Company code identifier.</param>
        /// <param name="loginid">loginid parameter.</param>
        /// <param name="Citycode">City/branch code.</param>
        /// <param name="vguid">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsoleEditmodeview([FromUri]string consoleno, string cmpcode, string loginid, string Citycode, string vguid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_JOB_POPULATE", consoleno, cmpcode, loginid, Citycode, vguid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsoleEditmodeview");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsolejobPageload records.</summary>
        /// <param name="consoleno">consoleno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsolejobPageload([FromUri]string consoleno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CON_JOB_PAGELOAD", (consoleno != null) ? consoleno : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsolejobPageload");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform consoleJobIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult consoleJobIU([FromBody]ManualConsoleJob obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_JOB_TMP_IU",
                     obj.ID, obj.CONSOLENO, obj.JOBNO, (obj.HAWBNO != null) ? obj.HAWBNO : "", (obj.HAWBDT != null) ? obj.HAWBDT : "", obj.IMPORTER, obj.NOOFPKGS, obj.WEIGHT, obj.VOLUME, obj.FREIGHT,
                       obj.ICOTERM, obj.EXPORTER, obj.CHBLWT, obj.FCRSDT, obj.DESTINATION, obj.RELEASEDT, obj.LOGINID, obj.CMPCODE, obj.CITYCEODE, obj.VGUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/consoleJobIU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }



        /// <summary>Perform consoleOrderIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult consoleOrderIU([FromBody]ManualOrder obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_ORDER_TMP_IU",
                     obj.ID, obj.CONSOLENO, obj.JOBNO, obj.ORDERNO, obj.NOOFPCS, obj.TYPEOFPCS, obj.LSD, obj.HSCODE, obj.HSCODE_DESC, obj.LOGINID,
                       obj.CMPCODE, obj.CITYCODE, obj.VGUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/consoleOrderIU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform consoleIU records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult consoleIU([FromBody]ManualConsoleIU obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_FINAL_IU", obj.CONSOLENO, obj.CONSOLEDT, obj.MODE, obj.SENTFROM, obj.AGENT, obj.DESTINATION, (obj.SHIPLINE != null) ? obj.SHIPLINE : "", (obj.VESSEL != null) ? obj.VESSEL : "", (obj.MBLNO != null) ? obj.MBLNO : "",
                      (obj.MBLDT != null) ? obj.MBLDT : "", (obj.AIRLINE != null) ? obj.AIRLINE : "", (obj.FLIGHTNO != null) ? obj.FLIGHTNO : "", (obj.FLIGHTDT != null) ? obj.FLIGHTDT : "", (obj.ACTUALFLIGHTNO != null) ? obj.ACTUALFLIGHTNO : "", (obj.ACTUALFLIGHTDT != null) ? obj.ACTUALFLIGHTDT : "", (obj.MAWBNO != null) ? obj.MAWBNO : "", obj.MAWBDT, obj.ETA, obj.VIA, obj.NOOFPKGS, obj.TYPEOFPKGS, obj.WEIGHT,
                       obj.VOLUME, obj.CITYCODE, obj.HOUSEBL, obj.FREIGHT, obj.CMPCODE, (obj.TRANSCITY != null) ? obj.TRANSCITY : "", (obj.REMARK != null) ? obj.REMARK : "", (obj.TRANSPORTER != null) ? obj.TRANSPORTER : "", (obj.TRANSPORTBY != null) ? obj.TRANSPORTBY : "", (obj.CARGONOTE != null) ? obj.CARGONOTE : "", (obj.CARGONOTEDT != null) ? obj.CARGONOTEDT : "", (obj.CHBLWT != null) ? obj.CHBLWT : "",
                       (obj.VSL_PORT != null) ? obj.VSL_PORT : "", (obj.CONTAINER1 != null) ? obj.CONTAINER1 : "", (obj.CONTAINER2 != null) ? obj.CONTAINER2 : "" , (obj.CONTAINER3 != null) ? obj.CONTAINER3 : "", (obj.CONTAINER4 != null) ? obj.CONTAINER4 : "", obj.LOGINID, obj.ACTION, obj.CITYCODE1, obj.CO2, obj.VGUID);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/consoleIU");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        
        /// <summary>Retrieve GetsearchConsoleList records.</summary>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="value">Search filter value.</param>
        /// <param name="frmdt">Start date for the date range filter.</param>
        /// <param name="todt">End date for the date range filter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetsearchConsoleList([FromUri]string mode, string value, string frmdt, string todt)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_LIST", mode, (value != null) ? value : "", (frmdt != null) ? frmdt : "", (todt != null) ? todt : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsolejobPageload");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Reset temporary data for console records.</summary>
        /// <param name="loginid">loginid parameter.</param>
        /// <param name="guid">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult console_reset([FromUri]string loginid, string guid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_RESET_ALL", loginid, guid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/console_reset");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        //------------------End of Manual Console--------------

        //--------------- console on vessel
        /// <summary>Perform console containerview records.</summary>
        /// <param name="vessel">vessel parameter.</param>
        /// <param name="port">port parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult console_containerview([FromUri]string vessel, string port)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONS_CONTAINER_VIEW", vessel, port);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/console_containerview");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Load page reference data for console container records.</summary>
        /// <param name="vessel">vessel parameter.</param>
        /// <param name="port">port parameter.</param>
        /// <param name="consoleno">consoleno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult console_container_pageload([FromUri]string vessel, string port,string consoleno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONS_CONTAINER_PAGELOAD", vessel, port,  (consoleno != null) ? consoleno : "");
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/console_container_pageload");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform console container filldata records.</summary>
        /// <param name="consoleno">consoleno parameter.</param>
        /// <param name="containerno">containerno parameter.</param>
        /// <param name="vessel">vessel parameter.</param>
        /// <param name="port">port parameter.</param>
        /// <param name="userid">userid parameter.</param>
        /// <param name="guid">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult console_container_filldata([FromUri]string consoleno, string containerno, string vessel, string port, string userid, string guid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONS_CONTAINER_FILLDATA", consoleno, containerno, vessel, port, userid, guid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/console_container_filldata");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update consolecontainer records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult consolecontainer_iu([FromBody]ConsoleContainer obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_CONTAINER_IU",
                     obj.ID	,obj.CONSOLENO	,obj.CONTAINERNO	,obj.CONTAINERSIZE	,obj.CONTAINERSIZE1	,obj.CONTAINERSTATUS	,obj.DESTPORT	,
                     (obj.AGTSEALNO!= null) ? obj.AGTSEALNO:""	,(obj.CUSTSEALNO!= null) ? obj.CUSTSEALNO:""	,(obj.FREIGHTUSD!= null) ? obj.FREIGHTUSD:""	,(obj.BAFUSD!= null) ? obj.BAFUSD:""	,
                     (obj.DIRECTVSL!= null) ? obj.DIRECTVSL:""	,(obj.TRANSPORT1!= null) ? obj.TRANSPORT1:""	,(obj.CONVESSEL1!= null) ? obj.CONVESSEL1:""	,(obj.CONVESSEL1VOY!= null) ? obj.CONVESSEL1VOY:""	,
                     (obj.ETDPORT1!= null) ? obj.ETDPORT1:""	,(obj.ETA1!= null) ? obj.ETA1:""	,(obj.TRANSPORT2!= null) ? obj.TRANSPORT2:""	,(obj.CONVESSEL2!= null) ? obj.CONVESSEL2:""	,
                     (obj.CONVESSEL2VOY!= null) ? obj.CONVESSEL2VOY	:"",(obj.ETDPORT2!= null) ? obj.ETDPORT2:""	,(obj.ETA2!= null) ? obj.ETA2:""	,(obj.ONWARDTRANS!= null) ? obj.ONWARDTRANS:""	,
                     (obj.ONWARDTRANSBY!= null) ? obj.ONWARDTRANSBY	:"",(obj.ONWARDTRANSPORT!= null) ? obj.ONWARDTRANSPORT:""	,(obj.ONWARDTRANSCOST!= null) ? obj.ONWARDTRANSCOST	:"",(obj.ETA3!= null) ? obj.ETA3:""	,
                     (obj.FREIGHTCUR!= null) ? obj.FREIGHTCUR:""	,(obj.BAFCUR!= null) ? obj.BAFCUR:""	,(obj.OTHERNAME!= null) ? obj.OTHERNAME	:"",(obj.OTHERCUR!= null) ? obj.OTHERCUR:""	,
                     (obj.OTHERAMT!= null) ? obj.OTHERAMT	:"",(obj.OTHERNAME1!= null) ? obj.OTHERNAME1:""	,(obj.OTHERCUR1 != null) ? obj.OTHERCUR1:""	,(obj.OTHERAMT1!= null) ? obj.OTHERAMT1:""	,
                     (obj.SINGLESHPR!= null) ? obj.SINGLESHPR:""	,(obj.OCUR1!= null) ? obj.OCUR1:""	,(obj.OCURRATE1!= null) ? obj.OCURRATE1	:"",(obj.OCUR2!= null) ? obj.OCUR2:""	,(obj.OCURRATE2!= null) ? obj.OCURRATE2:""	,
                     (obj.DCUR1 != null) ? obj.DCUR1 : "", (obj.DCURRATE1 != null) ? obj.DCURRATE1 : "", (obj.DCUR2 != null) ? obj.DCUR2 : "", (obj.DCURRATE2 != null) ? obj.DCURRATE2 : "",
                     obj.CMPID, obj.CITYCODE, obj.CMPCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/consolecontainer_iu");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Perform console containerCLP records.</summary>
        /// <param name="consoleno">consoleno parameter.</param>
        /// <param name="containerno">containerno parameter.</param>
        /// <param name="vessel">vessel parameter.</param>
        /// <param name="userid">userid parameter.</param>
        /// <param name="vguid">Session GUID for temporary record management.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult console_containerCLP([FromUri]string consoleno, string containerno,string vessel,string userid, string vguid)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_GETCONT_CLP", consoleno, containerno,vessel,userid,vguid);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/console_containerCLP");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Insert or update consolecontainerCLP records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult consolecontainerCLP_iu([FromBody]ConsoleContainerCLP obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_CONTAINER1_CLP_IU",
                     obj.CONSOLENO, obj.CONTAINERNO, obj.CONTAINERSTR, 
                     obj.CMPID, obj.CMPCODE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/consolecontainerCLP_iu");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetContainerjobview records.</summary>
        /// <param name="containerno">containerno parameter.</param>
        /// <param name="consoleno">consoleno parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetContainerjobview([FromUri] string containerno, string consoleno)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_CONSOLE_CONTAINER_VIEW", containerno,consoleno);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetContainerjobview");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Retrieve GetConsolePrintCommonview records.</summary>
        /// <param name="searchtxt">Search text value.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult GetConsolePrintCommonview([FromUri]string searchtxt, string searchval, string citycode )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_IMPFRA_PRINT_COMMON_VIEW", searchtxt, searchval, citycode);
                
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "ImportFra/GetConsolePrintCommonview");
            }
            finally
            {
                objDal.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve GetConsolePrintCommonview report records.</summary>
        /// <param name="searchtxt">Search text value.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="jobstr">jobstr parameter.</param>
        /// <param name="custodoc">custodoc parameter.</param>
        /// <param name="supplier">Supplier code.</param>
        /// <param name="eta_flg">eta flg parameter.</param>
        /// <param name="dtsortie">dtsortie parameter.</param>
        /// <param name="locfrt">locfrt parameter.</param>
        /// <param name="tinull">tinull parameter.</param>
        /// <param name="nature">nature parameter.</param>
        /// <param name="tarifdouane">tarifdouane parameter.</param>
        /// <param name="fature">fature parameter.</param>
        /// <param name="colisage">colisage parameter.</param>
        /// <param name="certificate">certificate parameter.</param>
        /// <param name="forma">forma parameter.</param>
        /// <param name="licence">licence parameter.</param>
        /// <param name="agent">agent parameter.</param>
        /// <param name="dtrelaese">dtrelaese parameter.</param>
        /// <param name="nulllbl">nulllbl parameter.</param>
        /// <param name="transport">transport parameter.</param>
        /// <param name="Snature">Snature parameter.</param>
        /// <param name="starifdouane">starifdouane parameter.</param>
        /// <param name="verbl">verbl parameter.</param>
        /// <param name="lloyds">lloyds parameter.</param>
        /// <param name="dt126e">d t126 e parameter.</param>
        /// <param name="agtcode">agtcode parameter.</param>
        /// <param name="blnber">blnber parameter.</param>
        /// <param name="itemnber">itemnber parameter.</param>
        /// <param name="articlenum">articlenum parameter.</param>
        /// <param name="ecornum">ecornum parameter.</param>
        /// <param name="Artnom">Artnom parameter.</param>
        /// <param name="dt126A">d t126 A parameter.</param>
        /// <param name="T1numPlcdt">T1 n u m P l c d t parameter.</param>
        /// <param name="validity">validity parameter.</param>
        /// <param name="M71No">M71 N o parameter.</param>
        /// <param name="IM7cust">I M7 c u s t parameter.</param>
        /// <param name="warAddr">war Addr parameter.</param>
        /// <param name="laoding">laoding parameter.</param>
        /// <param name="nullIM4">null IM4 parameter.</param>
        /// <param name="issued">issued parameter.</param>
        /// <param name="strtno">strtno parameter.</param>
        /// <param name="nbrcrt">nbrcrt parameter.</param>
        /// <param name="weight">weight parameter.</param>
        /// <param name="nullIM42">null IM42 parameter.</param>
        /// <param name="issued2">issued2 parameter.</param>
        /// <param name="strtno2">strtno2 parameter.</param>
        /// <param name="nbrcrt2">nbrcrt2 parameter.</param>
        /// <param name="weight2">weight2 parameter.</param>
        /// <param name="nullIM43">null IM43 parameter.</param>
        /// <param name="issued3">issued3 parameter.</param>
        /// <param name="strtno3">strtno3 parameter.</param>
        /// <param name="nbrcrt3">nbrcrt3 parameter.</param>
        /// <param name="weight3">weight3 parameter.</param>
        /// <param name="nullIM44">null IM44 parameter.</param>
        /// <param name="issued4">issued4 parameter.</param>
        /// <param name="strtno4">strtno4 parameter.</param>
        /// <param name="nbrcrt4">nbrcrt4 parameter.</param>
        /// <param name="weight4">weight4 parameter.</param>
        /// <param name="dtheure">dtheure parameter.</param>
        /// <param name="username">username parameter.</param>
        /// <param name="supaddress">supaddress parameter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage GetConsolePrintCommonview_report([FromUri] string searchtxt, string searchval, string citycode, Int32 cntimporter, string jobstr, string custodoc, string supplier, string eta_flg, string dtsortie, string locfrt, string tinull, string nature, string tarifdouane, string fature, string colisage, string certificate, string forma, string licence, string agent, string dtrelaese, string nulllbl, string transport, string Snature, string starifdouane, string verbl, string lloyds, string dt126e, string agtcode, string blnber, string itemnber, string articlenum, string ecornum, string Artnom, string dt126A, string T1numPlcdt, string validity, string M71No, string IM7cust, string warAddr, string laoding, string nullIM4, string issued, string strtno, string nbrcrt, string weight, string nullIM42, string issued2, string strtno2, string nbrcrt2, string weight2, string nullIM43, string issued3, string strtno3, string nbrcrt3, string weight3, string nullIM44, string issued4, string strtno4, string nbrcrt4, string weight4, string dtheure, string username, string supaddress, string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            if (cntimporter > 1)
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_IMPFRA_PRINT_COMMON_VIEW_JOB", searchtxt, searchval, citycode, jobstr);

            }
            else
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                                CommandType.StoredProcedure,
                                "USP_IMPFRA_PRINT_COMMON_VIEW", searchtxt, searchval, citycode);
            }


            custodoc = (custodoc != null) ? custodoc : ""; supplier = (supplier != null) ? supplier : "";
            eta_flg = (eta_flg != null) ? eta_flg : "";
            dtsortie = (dtsortie != null) ? dtsortie : ""; locfrt = (locfrt != null) ? locfrt : "";
            tinull = (tinull != null) ? tinull : "";
            nature = (nature != null) ? nature : "";
            tarifdouane = (tarifdouane != null) ? tarifdouane : ""; fature = (fature != null) ? fature : ""; colisage = (colisage != null) ? colisage : "";
            certificate = (certificate != null) ? certificate : ""; forma = (forma != null) ? forma : "";
            licence = (licence != null) ? licence : ""; agent = (agent != null) ? agent : ""; dtrelaese = (dtrelaese != null) ? dtrelaese : "";
            nulllbl = (nulllbl != null) ? nulllbl : ""; transport = (transport != null) ? transport : ""; Snature = (Snature != null) ? Snature : "";
            starifdouane = (starifdouane != null) ? starifdouane : ""; verbl = (verbl != null) ? verbl : "";
            lloyds = (lloyds != null) ? lloyds : ""; dt126e = (dt126e != null) ? dt126e : ""; agtcode = (agtcode != null) ? agtcode : "";
            blnber = (blnber != null) ? blnber : ""; itemnber = (itemnber != null) ? itemnber : ""; articlenum = (articlenum != null) ? articlenum : "";

            ecornum = (ecornum != null) ? ecornum : ""; Artnom = (Artnom != null) ? Artnom : ""; dt126A = (dt126A != null) ? dt126A : "";
            T1numPlcdt = (T1numPlcdt != null) ? T1numPlcdt : ""; validity = (validity != null) ? validity : "";
            M71No = (M71No != null) ? M71No : ""; IM7cust = (IM7cust != null) ? IM7cust : ""; warAddr = (warAddr != null) ? warAddr : ""; laoding = (laoding != null) ? laoding : "";
            nullIM4 = (nullIM4 != null) ? nullIM4 : ""; issued = (issued != null) ? issued : ""; strtno = (strtno != null) ? strtno : ""; nbrcrt = (nbrcrt != null) ? nbrcrt : "";
            weight = (weight != null) ? weight : ""; nullIM42 = (nullIM42 != null) ? nullIM42 : "";
            issued2 = (issued2 != null) ? issued2 : ""; strtno2 = (strtno2 != null) ? strtno2 : ""; nbrcrt2 = (nbrcrt2 != null) ? nbrcrt2 : ""; weight2 = (weight2 != null) ? weight2 : "";
            nullIM43 = (nullIM43 != null) ? nullIM43 : ""; issued3 = (issued3 != null) ? issued3 : "";
            strtno3 = (strtno3 != null) ? strtno3 : ""; nbrcrt3 = (nbrcrt3 != null) ? nbrcrt3 : ""; weight3 = (weight3 != null) ? weight3 : ""; nullIM44 = (nullIM44 != null) ? nullIM44 : "";
            issued4 = (issued4 != null) ? issued4 : ""; strtno4 = (strtno4 != null) ? strtno4 : "";
            nbrcrt4 = (nbrcrt4 != null) ? nbrcrt4 : ""; weight4 = (weight4 != null) ? weight4 : ""; dtheure = (dtheure != null) ? dtheure : "";
            supaddress = (supaddress != null) ? supaddress : "";
            int countDtColumn = ds.Tables[0].Columns.Count;

            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head><body>");
            stringBuilder.Append("<table width='100%' border='1' cellspacing='3' cellpadding='3'> <tr> <td><table width='100%' border='0' cellspacing='0' cellpadding='0'> ");
            stringBuilder.Append("<tr><td width='23%' height='84'> <div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td> ");
            stringBuilder.Append("<td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0'>");
            stringBuilder.Append("<tr><td colspan='2'><font size='6' face='Arial'><strong>" + Convert.ToString(ds.Tables[0].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr> ");
            stringBuilder.Append("<tr> <td width='48%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ADDRS"]) + "</font></td>");
            stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_TELNO"]) + "<br>");
            stringBuilder.Append("FAX : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_FAXNO"]) + "<br> E-MAIL : " + Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]) + "<br>");
            stringBuilder.Append("<B>EORI : " + Convert.ToString(ds.Tables[0].Rows[0]["EORI_NUMBER"]) + "</B></font></td> </tr> </table></td> </tr></table></td>    </tr>");
            stringBuilder.Append("<tr><td><table width='100%' border='1' cellpadding='2' cellspacing='2'> <tr> <td width='41%'>");
            stringBuilder.Append("<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><strong>DESTINATAIRE</strong></font></td>");
            stringBuilder.Append("<td width='59%'> <font size='2' face='Verdana, Arial, Helvetica, sans-serif'> <b><font size='2' face='Arial'>" + supplier + "<br>");
            stringBuilder.Append("</font></b><font size='2' face='Arial'>" + supaddress + "&nbsp;</font></font></td> </tr>");
            stringBuilder.Append("</table></td> </tr><tr><td> <div align='center'><strong><font size='4' face='Arial'><strong>");


            stringBuilder.Append("INSTRUCTIONS DOUANE </strong></font></strong></div></td></tr> ");
            stringBuilder.Append("<tr><td>");
            stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");

            stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>REF A RAPPELER</span></strong></td>");
            stringBuilder.Append("<td width='58%' ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["JOBNO"]) + "</span></td> </tr> ");
            if (mode == "air")
            {
                stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>MAWB </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["MAWBNO"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>HAWB </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["HAWBNO"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CDE </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CDE"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DOUANE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["DDMSG"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>" + eta_flg + " </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA1"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE DE SORTIE </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + dtsortie + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LOCALISATION DU FRET </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + locfrt + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td  colspan='2'  > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'> VOUS TROUVEREZ CI-JOINT LES DOCUMENTS NECESSAIRES A L'ETABLISSEMENT DE</span></p></td></tr>");

                stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> </span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + tinull + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CLIENT</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["IMPORTER"]) + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NATURE </span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nature + "</font></p></td></tr>");

                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TARIF DOUANIER </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + tarifdouane + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>FACTURE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + fature + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>COLISAGE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + colisage + "</font></p></td></tr>");
                stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CERTIFICATE D'ORIGINE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + certificate + "</font></p></td></tr>");
                stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>FORM A </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + forma + "</font></p></td></tr>");
                stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LICENCE EXPORT</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + licence + "</font></p></td></tr>");
                stringBuilder.Append("</table></tr></td>");

                stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'>MERCI           DE BIEN VOULOIR FAIRE LE NECESSAIRE<br>          <br>          Salutations,</font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong>" + username + "&nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");

            }
            if (mode == "sea")
            {
                stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VSL NAME </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VSLNAME"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>P.O.L.  </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POL"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ETA  " + Convert.ToString(ds.Tables[4].Rows[0]["DESTINATION"]) + "</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CONTENEUR</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CONTAINERDET"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS  </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CARRIER</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CARRIER"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>AGENT NAME</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + agent + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>RELEASE DATE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + dtrelaese + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td  colspan='2'  > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'> VOUS TROUVEREZ CI-JOINT LES DOCUMENTS NECESSAIRES A L'ETABLISSEMENT DE</span></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'></span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + nulllbl + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TRANSPORT</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + transport + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NATURE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + nature + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TARIF DOUANIER</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + starifdouane + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'>INFORMATION ON CUSTOMS DOC</span></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + custodoc + "</font></p></td></tr>");

                stringBuilder.Append("<tr>");
                if (custodoc == "126 E")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VERBLIJFS NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + verbl + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LLOYDS NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + lloyds + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE OF 126E </span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + dt126e + "</font></p></td></tr>");

                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>AGENT CODE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + agtcode + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>BL NBER GIVEN BY AGENT</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + blnber + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ITEM NBER</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + itemnber + "</font></p></td></tr>");
                    stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ARTICLE NBR</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + articlenum + "</font></p></td></tr>");

                }

                if (custodoc == "126 A")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ECOR NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + ecornum + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ARTICLE NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + Artnom + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE OF 126A</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + dt126A + "</font></p></td></tr> ");

                }
                if (custodoc == "T1")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>T1 NBER+PLACE+DATE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + T1numPlcdt + "</font></p></td></tr>");
                    stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VALIDITY</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + validity + "</font></p></td></tr> ");
                }
                if (custodoc == "IM7T1")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>IM7T1 NUMBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + M71No + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CUSTOMS OFFICE FOR IM7T1</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + IM7cust + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>WAREHOUSE ADDRESS</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + warAddr + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>REF. OF LOADING</span></strong></p></td>");
                    stringBuilder.Append("<td colspan='2'> <p class=MsoNormal><font size='2' face='Arial'>" + laoding + "</font></p></td></tr> ");
                }
                stringBuilder.Append("</tr></table></td></tr><tr><td>");
                stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");
                stringBuilder.Append("<tr ><td colspan='5'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DETAILS OF T1 OR IM4 TO BE ISSUED </span></strong></p></td></tr>");
                stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'></span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TO BE ISSUED ON</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>SIRET NO</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NBR CTNS</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>WEIGHT</span></strong></p></td></tr>");

                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + nullIM4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno + "</font></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight + "</font></p></td></tr> ");

                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + nullIM42 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued2 + "</font></p></td ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno2 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt2 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight2 + "</font></p></td></tr> ");

                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + nullIM43 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued3 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno3 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt3 + "</font></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight3 + "</font></p></td></tr> ");

                stringBuilder.Append("<tr><td><p class=MsoNormal><font size='2' face='Arial'>" + nullIM44 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight4 + "</font></p></td></tr> </table>");
                stringBuilder.Append(" </td></tr>");
                stringBuilder.Append("  <tr><td><table border=1 cessspacing=1 cellpadding=1 width='100%'><tr><td><font face=arial size=2><strong>Date et heure a laquelle le T1 doit etre disponible sure le terminal</strong></font></td><td><font face=arial size=2>" + dtheure + "</font></td></tr></table></td></tr>");
                stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'>MERCI           DE BIEN VOULOIR FAIRE LE NECESSAIRE<br>          <br>          Salutations,</font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong>" + username + "&nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");
            }
            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_PrintInstuctiondouane.doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }
        /// <summary>Retrieve GetConsolePrintCommonview reportold records.</summary>
        /// <param name="searchtxt">Search text value.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="custodoc">custodoc parameter.</param>
        /// <param name="supplier">Supplier code.</param>
        /// <param name="eta_flg">eta flg parameter.</param>
        /// <param name="dtsortie">dtsortie parameter.</param>
        /// <param name="locfrt">locfrt parameter.</param>
        /// <param name="tinull">tinull parameter.</param>
        /// <param name="nature">nature parameter.</param>
        /// <param name="tarifdouane">tarifdouane parameter.</param>
        /// <param name="fature">fature parameter.</param>
        /// <param name="colisage">colisage parameter.</param>
        /// <param name="certificate">certificate parameter.</param>
        /// <param name="forma">forma parameter.</param>
        /// <param name="licence">licence parameter.</param>
        /// <param name="agent">agent parameter.</param>
        /// <param name="dtrelaese">dtrelaese parameter.</param>
        /// <param name="nulllbl">nulllbl parameter.</param>
        /// <param name="transport">transport parameter.</param>
        /// <param name="Snature">Snature parameter.</param>
        /// <param name="starifdouane">starifdouane parameter.</param>
        /// <param name="verbl">verbl parameter.</param>
        /// <param name="lloyds">lloyds parameter.</param>
        /// <param name="dt126e">d t126 e parameter.</param>
        /// <param name="agtcode">agtcode parameter.</param>
        /// <param name="blnber">blnber parameter.</param>
        /// <param name="itemnber">itemnber parameter.</param>
        /// <param name="articlenum">articlenum parameter.</param>
        /// <param name="ecornum">ecornum parameter.</param>
        /// <param name="Artnom">Artnom parameter.</param>
        /// <param name="dt126A">d t126 A parameter.</param>
        /// <param name="T1numPlcdt">T1 n u m P l c d t parameter.</param>
        /// <param name="validity">validity parameter.</param>
        /// <param name="M71No">M71 N o parameter.</param>
        /// <param name="IM7cust">I M7 c u s t parameter.</param>
        /// <param name="warAddr">war Addr parameter.</param>
        /// <param name="laoding">laoding parameter.</param>
        /// <param name="nullIM4">null IM4 parameter.</param>
        /// <param name="issued">issued parameter.</param>
        /// <param name="strtno">strtno parameter.</param>
        /// <param name="nbrcrt">nbrcrt parameter.</param>
        /// <param name="weight">weight parameter.</param>
        /// <param name="nullIM42">null IM42 parameter.</param>
        /// <param name="issued2">issued2 parameter.</param>
        /// <param name="strtno2">strtno2 parameter.</param>
        /// <param name="nbrcrt2">nbrcrt2 parameter.</param>
        /// <param name="weight2">weight2 parameter.</param>
        /// <param name="nullIM43">null IM43 parameter.</param>
        /// <param name="issued3">issued3 parameter.</param>
        /// <param name="strtno3">strtno3 parameter.</param>
        /// <param name="nbrcrt3">nbrcrt3 parameter.</param>
        /// <param name="weight3">weight3 parameter.</param>
        /// <param name="nullIM44">null IM44 parameter.</param>
        /// <param name="issued4">issued4 parameter.</param>
        /// <param name="strtno4">strtno4 parameter.</param>
        /// <param name="nbrcrt4">nbrcrt4 parameter.</param>
        /// <param name="weight4">weight4 parameter.</param>
        /// <param name="dtheure">dtheure parameter.</param>
        /// <param name="username">username parameter.</param>
        /// <param name="supaddress">supaddress parameter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage GetConsolePrintCommonview_reportold([FromUri]string searchtxt, string searchval, string citycode, string custodoc, string supplier, string eta_flg, string dtsortie, string locfrt, string tinull, string nature, string tarifdouane, string fature, string colisage, string certificate, string forma, string licence, string agent, string dtrelaese, string nulllbl, string transport, string Snature, string starifdouane, string verbl, string lloyds, string dt126e, string agtcode, string blnber, string itemnber, string articlenum, string ecornum, string Artnom, string dt126A, string T1numPlcdt, string validity, string M71No, string IM7cust, string warAddr, string laoding, string nullIM4, string issued, string strtno, string nbrcrt, string weight, string nullIM42, string issued2, string strtno2, string nbrcrt2, string weight2, string nullIM43, string issued3, string strtno3, string nbrcrt3, string weight3, string nullIM44, string issued4, string strtno4, string nbrcrt4, string weight4 , string dtheure, string username,string supaddress,string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_IMPFRA_PRINT_COMMON_VIEW", searchtxt, searchval, citycode) ;

            custodoc=   (custodoc != null) ? custodoc : "";   supplier=(supplier != null) ? supplier : ""; 
            eta_flg= (eta_flg != null) ? eta_flg : ""; 
            dtsortie= (dtsortie != null) ? dtsortie : ""; locfrt=(locfrt != null) ? locfrt : "";
            tinull= (tinull != null) ? tinull : "";
            nature= (nature != null) ? nature : "";
            tarifdouane= (tarifdouane != null) ? tarifdouane : ""; fature=(fature != null) ? fature : ""; colisage=(colisage != null) ? colisage : "";
            certificate=(certificate != null) ? certificate : ""; forma=(forma != null) ? forma : ""; 
            licence=(licence != null) ? licence : ""; agent=(agent != null) ? agent : ""; dtrelaese=(dtrelaese != null) ? dtrelaese : "";
            nulllbl=(nulllbl != null) ? nulllbl : "";transport= (transport != null) ? transport : ""; Snature=(Snature != null) ? Snature : ""; 
            starifdouane=(starifdouane != null) ? starifdouane : ""; verbl=(verbl != null) ? verbl : "";
            lloyds=(lloyds != null) ? lloyds : "";dt126e=(dt126e != null) ? dt126e : ""; agtcode=(agtcode != null) ? agtcode : "";
            blnber=(blnber != null) ? blnber : ""; itemnber=(itemnber != null) ? itemnber : "";articlenum= (articlenum != null) ? articlenum : "";
					
            ecornum=(ecornum != null) ? ecornum : ""; Artnom=(Artnom != null) ? Artnom : ""; dt126A=(dt126A != null) ? dt126A : ""; 
            T1numPlcdt=(T1numPlcdt != null) ? T1numPlcdt : ""; validity=(validity != null) ? validity : "";
            M71No= (M71No != null) ? M71No : ""; IM7cust=(IM7cust != null) ? IM7cust : ""; warAddr=(warAddr != null) ? warAddr : ""; laoding=(laoding != null) ? laoding : "";
            nullIM4= (nullIM4 != null) ? nullIM4 : ""; issued=(issued != null) ? issued : "";strtno= (strtno != null) ? strtno : ""; nbrcrt=(nbrcrt != null) ? nbrcrt : "";
            weight=(weight != null) ? weight : ""; nullIM42=(nullIM42 != null) ? nullIM42 : "";
            issued2= (issued2 != null) ? issued2 : ""; strtno2=(strtno2 != null) ? strtno2 : ""; nbrcrt2=(nbrcrt2 != null) ? nbrcrt2 : ""; weight2=(weight2 != null) ? weight2 : ""; 
            nullIM43=(nullIM43 != null) ? nullIM43 : ""; issued3=(issued3 != null) ? issued3 : "";
            strtno3= (strtno3 != null) ? strtno3 : ""; nbrcrt3=(nbrcrt3 != null) ? nbrcrt3 : ""; weight3=(weight3 != null) ? weight3 : ""; nullIM44=(nullIM44 != null) ? nullIM44 : "";
            issued4=(issued4 != null) ? issued4 : ""; strtno4=(strtno4 != null) ? strtno4 : "";
            nbrcrt4 = (nbrcrt4 != null) ? nbrcrt4 : ""; weight4 = (weight4 != null) ? weight4 : ""; dtheure = (dtheure != null) ? dtheure : "";
            supaddress = (supaddress != null) ? supaddress : "";
            int countDtColumn = ds.Tables[0].Columns.Count;

            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head><body>");
            stringBuilder.Append("<table width='100%' border='1' cellspacing='3' cellpadding='3'> <tr> <td><table width='100%' border='0' cellspacing='0' cellpadding='0'> ");
            stringBuilder.Append("<tr><td width='23%' height='84'> <div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td> ");
            stringBuilder.Append("<td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0'>");
            stringBuilder.Append("<tr><td colspan='2'><font size='6' face='Arial'><strong>" + Convert.ToString(ds.Tables[0].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr> ");
            stringBuilder.Append("<tr> <td width='48%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ADDRS"]) + "</font></td>");
            stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_TELNO"]) + "<br>");
            //stringBuilder.Append("FAX : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_FAXNO"]) + "<br> E-MAIL : " + Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]) + "<br>");
            stringBuilder.Append("<B>EORI : " + Convert.ToString(ds.Tables[0].Rows[0]["EORI_NUMBER"]) + "</B></font></td> </tr> </table></td> </tr></table></td>    </tr>");
            stringBuilder.Append("<tr><td><table width='100%' border='1' cellpadding='2' cellspacing='2'> <tr> <td width='41%'>");
            stringBuilder.Append("<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><strong>DESTINATAIRE</strong></font></td>");
            stringBuilder.Append("<td width='59%'> <font size='2' face='Verdana, Arial, Helvetica, sans-serif'> <b><font size='2' face='Arial'>" + supplier + "<br>");
            stringBuilder.Append("</font></b><font size='2' face='Arial'>" + supaddress + "&nbsp;</font></font></td> </tr>");
            stringBuilder.Append("</table></td> </tr><tr><td> <div align='center'><strong><font size='4' face='Arial'><strong>");
 

            stringBuilder.Append("INSTRUCTIONS DOUANE </strong></font></strong></div></td></tr> ");
            stringBuilder.Append("<tr><td>");
            stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");
               
            stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>REF A RAPPELER</span></strong></td>");
            stringBuilder.Append("<td width='58%' ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["JOBNO"]) + "</span></td> </tr> ");
            if (mode == "air") {
                stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>MAWB </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["MAWBNO"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>HAWB </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["HAWBNO"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CDE </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CDE"]) + "</font></p></td></tr>");
 
                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DOUANE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["DDMSG"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>" + eta_flg + " </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA1"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE DE SORTIE </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + dtsortie + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LOCALISATION DU FRET </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + locfrt + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td  colspan='2'  > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'> VOUS TROUVEREZ CI-JOINT LES DOCUMENTS NECESSAIRES A L'ETABLISSEMENT DE</span></p></td></tr>");

                stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> </span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + tinull + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CLIENT</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["IMPORTER"]) + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NATURE </span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nature + "</font></p></td></tr>");

                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TARIF DOUANIER </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + tarifdouane + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>FACTURE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + fature + "</font></p></td></tr>");
                stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>COLISAGE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + colisage + "</font></p></td></tr>");
                stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CERTIFICATE D'ORIGINE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + certificate + "</font></p></td></tr>");
                stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>FORM A </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + forma + "</font></p></td></tr>");
                stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LICENCE EXPORT</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + licence + "</font></p></td></tr>");
                stringBuilder.Append("</table></tr></td>");
               
                stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'>MERCI           DE BIEN VOULOIR FAIRE LE NECESSAIRE<br>          <br>          Salutations,</font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong>" + username + "&nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");

            }
            if (mode == "sea")
            {
                stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VSL NAME </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VSLNAME"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>P.O.L.  </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POL"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ETA  " + Convert.ToString(ds.Tables[4].Rows[0]["DESTINATION"]) + "</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CONTENEUR</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CONTAINERDET"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS  </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CARRIER</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CARRIER"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>AGENT NAME</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + agent + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>RELEASE DATE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + dtrelaese + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td  colspan='2'  > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'> VOUS TROUVEREZ CI-JOINT LES DOCUMENTS NECESSAIRES A L'ETABLISSEMENT DE</span></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'></span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + nulllbl + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TRANSPORT</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + transport + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NATURE</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + nature + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TARIF DOUANIER</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + starifdouane + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'>INFORMATION ON CUSTOMS DOC</span></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + custodoc + "</font></p></td></tr>");

                stringBuilder.Append("<tr>");
                if (custodoc == "126 E")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VERBLIJFS NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + verbl + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>LLOYDS NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + lloyds + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE OF 126E </span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + dt126e + "</font></p></td></tr>");

                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>AGENT CODE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + agtcode + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>BL NBER GIVEN BY AGENT</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + blnber + "</font></p></td></tr>");
                    stringBuilder.Append("<tr  ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ITEM NBER</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + itemnber + "</font></p></td></tr>");
                    stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ARTICLE NBR</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + articlenum + "</font></p></td></tr>");

                }

                if (custodoc == "126 A")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ECOR NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + ecornum + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ARTICLE NBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + Artnom + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE OF 126A</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + dt126A + "</font></p></td></tr> ");

                }
                if (custodoc == "T1")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>T1 NBER+PLACE+DATE</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + T1numPlcdt + "</font></p></td></tr>");
                    stringBuilder.Append("<tr ><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VALIDITY</span></strong></p></td>");
                    stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + validity + "</font></p></td></tr> ");
                }
                if (custodoc == "IM7T1")
                {
                    stringBuilder.Append("<td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>IM7T1 NUMBER</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + M71No + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CUSTOMS OFFICE FOR IM7T1</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + IM7cust + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>WAREHOUSE ADDRESS</span></strong></p></td>");
                    stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + warAddr + "</font></p></td></tr>");
                    stringBuilder.Append("<tr><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>REF. OF LOADING</span></strong></p></td>");
                    stringBuilder.Append("<td colspan='2'> <p class=MsoNormal><font size='2' face='Arial'>" + laoding + "</font></p></td></tr> ");
                }
                stringBuilder.Append("</tr></table></td></tr><tr><td>");
                stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");
                stringBuilder.Append("<tr ><td colspan='5'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DETAILS OF T1 OR IM4 TO BE ISSUED </span></strong></p></td></tr>");
                stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'></span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TO BE ISSUED ON</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>SIRET NO</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NBR CTNS</span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>WEIGHT</span></strong></p></td></tr>");

                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + nullIM4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno + "</font></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight + "</font></p></td></tr> ");

                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + nullIM42 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued2 + "</font></p></td ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno2 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt2 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight2 + "</font></p></td></tr> ");

                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + nullIM43 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued3 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno3 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt3 + "</font></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight3 + "</font></p></td></tr> ");

                stringBuilder.Append("<tr><td><p class=MsoNormal><font size='2' face='Arial'>" + nullIM44 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + issued4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + strtno4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + nbrcrt4 + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + weight4 + "</font></p></td></tr> </table>");
                stringBuilder.Append(" </td></tr>");
                stringBuilder.Append("  <tr><td><table border=1 cessspacing=1 cellpadding=1 width='100%'><tr><td><font face=arial size=2><strong>Date et heure a laquelle le T1 doit etre disponible sure le terminal</strong></font></td><td><font face=arial size=2>" + dtheure + "</font></td></tr></table></td></tr>");
                stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'>MERCI           DE BIEN VOULOIR FAIRE LE NECESSAIRE<br>          <br>          Salutations,</font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong>" + username + "&nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");
            }
            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_PrintInstuctiondouane.doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }



        /// <summary>Retrieve GetConsolePrintRelache records.</summary>
        /// <param name="searchtxt">Search text value.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="supplier">Supplier code.</param>
        /// <param name="ccsupplier">Supplier code.</param>
        /// <param name="supaddress">supaddress parameter.</param>
        /// <param name="ccsupaddress">ccsupaddress parameter.</param>
        /// <param name="agent">agent parameter.</param>
        /// <param name="dtrelaese">dtrelaese parameter.</param>
        /// <param name="merci">merci parameter.</param>
        /// <param name="bl">bl parameter.</param>
        /// <param name="dcontract">dcontract parameter.</param>
        /// <param name="contstatus">contstatus parameter.</param>
        /// <param name="statusmsg">statusmsg parameter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage GetConsolePrintRelache([FromUri]string searchtxt, string searchval, string citycode, string supplier, string ccsupplier, string supaddress, string ccsupaddress, string agent, string dtrelaese, string merci, string  bl  , string dcontract, string contstatus, string statusmsg )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_IMPFRA_PRINT_COMMON_VIEW", searchtxt, searchval, citycode);

            ccsupplier = (ccsupplier != null) ? ccsupplier : ""; supplier = (supplier != null) ? supplier : "";
            ccsupaddress = (ccsupaddress != null) ? ccsupaddress : "";
            agent = (agent != null) ? agent : ""; dtrelaese = (dtrelaese != null) ? dtrelaese : "";
            merci = (merci != null) ? merci : ""; bl = (bl != null) ? bl : ""; dcontract = (dcontract != null) ? dcontract : "";
            contstatus = (contstatus != null) ? contstatus : ""; statusmsg = (statusmsg != null) ? statusmsg : "";            
            supaddress = (supaddress != null) ? supaddress : "";
            int countDtColumn = ds.Tables[0].Columns.Count;

            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head><body>");
            stringBuilder.Append("<table width='100%' border='1' cellspacing='3' cellpadding='3'> <tr> <td><table width='100%' border='0' cellspacing='0' cellpadding='0'> ");
            stringBuilder.Append("<tr><td width='23%' height='84'> <div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td> ");
            stringBuilder.Append("<td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0'>");
            stringBuilder.Append("<tr><td colspan='2'><font size='6' face='Arial'><strong>" + Convert.ToString(ds.Tables[0].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr> ");
            stringBuilder.Append("<tr> <td width='48%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ADDRS"]) + "</font></td>");
            stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_TELNO"]) + "<br>");
            //stringBuilder.Append("FAX : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_FAXNO"]) + "<br> E-MAIL : " + Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]) + "<br>");
            stringBuilder.Append("<B>EORI : " + Convert.ToString(ds.Tables[0].Rows[0]["EORI_NUMBER"]) + "</B></font></td> </tr> </table></td> </tr></table></td>    </tr>");
            stringBuilder.Append("<tr><td><table width='100%' border='1' cellpadding='2' cellspacing='2'> <tr> <td width='41%'>");
            stringBuilder.Append("<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><strong>DESTINATAIRE</strong></font></td>");
            stringBuilder.Append("<td width='59%'> <font size='2' face='Verdana, Arial, Helvetica, sans-serif'> <b><font size='2' face='Arial'>" + supplier + "<br>");
            stringBuilder.Append("</font></b><font size='2' face='Arial'>" + supaddress + "&nbsp;</font></font></td> </tr>");

            stringBuilder.Append("<tr> <td width='41%'><font size='2' face='Verdana, Arial, Helvetica, sans-serif'><strong>CC</strong></font></td>");
            stringBuilder.Append("<td width='59%'> <font size='2' face='Verdana, Arial, Helvetica, sans-serif'> <b><font size='2' face='Arial'>" + ccsupplier + "<br>");
            stringBuilder.Append("</font></b><font size='2' face='Arial'>" + ccsupaddress + "&nbsp;</font></font></td> </tr>");

            stringBuilder.Append("</table></td> </tr><tr><td> <div align='center'><strong><font size='4' face='Arial'><strong>");


            stringBuilder.Append(" DEMANDE DE RELACHE</strong></font></strong></div></td></tr> ");
            stringBuilder.Append("<tr><td>");
            stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");

            stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>REF A RAPPELER</span></strong></td>");
            stringBuilder.Append("<td width='58%' ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["JOBNO"]) + "</span></td> </tr> ");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CONSIGNEE'S ORDER NUMBER </span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CDE"]) + "</font></p></td></tr>");

            stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VSL NAME </span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VSLNAME"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>P.O.L.  </span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POL"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ETA  " + Convert.ToString(ds.Tables[4].Rows[0]["DESTINATION"]) + "</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CONTENEUR</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CONTAINERDET"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS  </span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CARRIER</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CARRIER"]) + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>AGENT NAME</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + agent + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>RELEASE DATE</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + dtrelaese + "</font></p></td></tr>");
 
            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>MERCI DE BIEN VOULOIR CEDER LE LAISSER SUIVRE EN FAVEUR DE :</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + merci + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>3/3 B/L :</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + bl + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DIRECT CONTRACT :</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + dcontract + "</font></p></td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>CONT.STATUS :</span></strong></p></td>");
            stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + contstatus + "</font></p></td></tr>");             
            stringBuilder.Append(" </td></tr>");

            stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'></font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong> &nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div><div> " + statusmsg + " </div></body></html>");
             
            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_printRelache.doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        /// <summary>Retrieve Fill deliverylist records.</summary>
        /// <param name="concode">concode parameter.</param>
        /// <param name="searchType">Search type/column identifier.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Fill_deliverylist(string concode, string searchType, string searchval, string mode )
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                //ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_LIST", concode, searchType, searchval, mode );
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_ACTUALDELIVERY_EDITLIST", concode, searchType, searchval, mode);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Fill_deliverylist");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Retrieve GetConsolePrint ordredrtrasport records.</summary>
        /// <param name="searchtxt">Search text value.</param>
        /// <param name="searchval">Search field/column identifier.</param>
        /// <param name="citycode">City/branch code.</param>
        /// <param name="supplier">Supplier code.</param>
        /// <param name="supaddrs">supaddrs parameter.</param>
        /// <param name="warehouse">warehouse parameter.</param>
        /// <param name="warehouseaddress">warehouseaddress parameter.</param>
        /// <param name="dtelevnt">dtelevnt parameter.</param>
        /// <param name="statut">statut parameter.</param>
        /// <param name="documents">documents parameter.</param>
        /// <param name="lieu">lieu parameter.</param>
        /// <param name="dtheure">dtheure parameter.</param>
        /// <param name="Tderef">Tderef parameter.</param>
        /// <param name="conteneur">conteneur parameter.</param>
        /// <param name="tarif">tarif parameter.</param>
        /// <param name="username">username parameter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage GetConsolePrint_ordredrtrasport([FromUri]string searchtxt, string searchval, string citycode, string supplier, string supaddrs, string warehouse , string warehouseaddress, string dtelevnt, string statut, string documents, string lieu, string dtheure, string Tderef, string conteneur, string tarif ,string username,string mode)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            StringBuilder stringBuilder = new StringBuilder();
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                CommandType.StoredProcedure,
                "USP_IMPFRA_PRINT_COMMON_VIEW", searchtxt, searchval, citycode);

            warehouse = (warehouse != null) ? warehouse : ""; supplier = (supplier != null) ? supplier : "";
            warehouseaddress = (warehouseaddress != null) ? warehouseaddress : "";
            dtelevnt = (dtelevnt != null) ? dtelevnt : ""; statut = (statut != null) ? statut : "";
            documents = (documents != null) ? documents : "";
            lieu = (lieu != null) ? lieu : "";
            dtheure = (dtheure != null) ? dtheure : ""; Tderef = (Tderef != null) ? Tderef : ""; Tderef = (Tderef != null) ? Tderef : "";
            conteneur = (conteneur != null) ? conteneur : ""; tarif = (tarif != null) ? tarif : "";

            supaddrs = (supaddrs != null) ? supaddrs : "";
            int countDtColumn = ds.Tables[0].Columns.Count;

            stringBuilder.Append("<html><head><title>MANILAL PATEL GROUP</title><meta http-equiv='Content-Type' content='text/html; charset=iso-8859-1'></head><body>");
            stringBuilder.Append("<table width='100%' border='1' cellspacing='3' cellpadding='3'> <tr> <td><table width='100%' border='0' cellspacing='0' cellpadding='0'> ");
            stringBuilder.Append("<tr><td width='23%' height='84'> <div align='center'><img src='http://www.manilal.com/import/MPLOGO003.jpg' width='134' height='84'></div></td> ");
            stringBuilder.Append("<td width='77%'><table width='95%' border='0' align='center' cellpadding='1' cellspacing='0'>");
            stringBuilder.Append("<tr><td colspan='2'><font size='6' face='Arial'><strong>" + Convert.ToString(ds.Tables[0].Rows[0]["CMP_NAME"]) + "</strong></font></td> </tr> ");
            stringBuilder.Append("<tr> <td width='48%'><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[0].Rows[0]["ADDRS"]) + "</font></td>");
            stringBuilder.Append("<td width='52%'><font size='2' face='Arial'>TEL : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_TELNO"]) + "<br>");
            //stringBuilder.Append("FAX : " + Convert.ToString(ds.Tables[0].Rows[0]["CMP_FAXNO"]) + "<br> E-MAIL : " + Convert.ToString(ds.Tables[0].Rows[0]["EMAIL"]) + "<br>");
            stringBuilder.Append("<B>EORI : " + Convert.ToString(ds.Tables[0].Rows[0]["EORI_NUMBER"]) + "</B></font></td> </tr> </table></td> </tr></table></td>    </tr>");
            stringBuilder.Append("<tr><td><table width='100%' border='1' cellpadding='2' cellspacing='2'> <tr> <td width='41%'>");
            stringBuilder.Append("<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><strong>DESTINATAIRE</strong></font></td>");
            stringBuilder.Append("<td width='59%'> <font size='2' face='Verdana, Arial, Helvetica, sans-serif'> <b><font size='2' face='Arial'>" + supplier + "<br>");
            stringBuilder.Append("</font></b><font size='2' face='Arial'>" + supaddrs + "&nbsp;</font></font></td> </tr>");
            stringBuilder.Append("</table></td> </tr><tr><td> <div align='center'><strong><font size='4' face='Arial'><strong>");


            stringBuilder.Append("ORDRE DE TRANSPORT(INDIVIDUAL SHIPMENT)</strong></font></strong></div></td></tr> ");
            stringBuilder.Append("<tr><td>");
            stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");

            stringBuilder.Append("<tr style='mso-yfti-irow:0'>  <td width='42%' ><strong><span style='font-size:10.0pt;font-family:Arial'>OUR REF</span></strong></td>");
            stringBuilder.Append("<td width='58%' ><span style='font-size:10.0pt;font-family:Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["JOBNO"]) + "</span></td> </tr> ");
           
          
                stringBuilder.Append(" <tr style='mso-yfti-irow:0'> <td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>MBL </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["MBLNO"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>P.O.L.  </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POL"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>SHIPPING LINE </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CARRIER"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ORDER NO. </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["CDE"]) + "</font></p></td></tr>");


                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>NB DE COLIS</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["COLIS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POIDS  </span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POIDS"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>VOLUME</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["VOLUME"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>POD</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["POD"]) + "</font></p></td></tr>");

                stringBuilder.Append("<tr style='mso-yfti-irow:1'><td width='42%' > <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ETA</span></strong></p></td>");
                stringBuilder.Append("<td > <p class=MsoNormal><font size='2' face='Arial'>" + Convert.ToString(ds.Tables[4].Rows[0]["ETA1"]) + "</font></p></td></tr>");
                
                 
                stringBuilder.Append("</tr></table></td></tr><tr><td>");
                stringBuilder.Append("<table width='100%' border=1 cellpadding=2 cellspacing='2' class=MsoNormalTable style='width:100.0%;mso-cellspacing:1.5pt;mso-padding-alt:1.5pt 1.5pt 1.5pt 1.5pt'>");
                stringBuilder.Append("<tr ><td colspan='5'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>ADRESSE D'ENLEVEMENT - QUAI D'ENLEVEMENT    </span></strong></p></td></tr>");
                stringBuilder.Append("<tr><td colspan='5'> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>" + warehouse + "</span></strong> <BR> " + warehouseaddress + "</p></td></tr>");
                stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> DATE ENLEVEMENT </span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>STATUT DOUANE / TRANSITAIRE </strong></p></td></tr>");
                 

                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + dtelevnt + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + statut + "</font></p></td></tr> ");
                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'> <strong>DOCUMENTS A JOINDRE A LA LIVRAISON :</strong></font></p></td>  ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + documents + "</font></p></td> </tr>");

                stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> LIEU DE LIVRAISON  </span></strong></p></td>");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>DATE ET HEURE / REFERENCES DE LIVRAISON </strong></p></td></tr>");


                stringBuilder.Append("<tr><td> <p class=MsoNormal><font size='2' face='Arial'>" + lieu + "</font></p></td> ");
                stringBuilder.Append("<td> <p class=MsoNormal><font size='2' face='Arial'>" + dtheure + "</font></p></td </tr>");


                stringBuilder.Append("<tr><td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'>TERMINAL DE RESTITUTION + REF </span></strong></p></td>");
                stringBuilder.Append(" <td> <p class=MsoNormal><font size='2' face='Arial'>" + Tderef + "</font></p></td></tr> ");

                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> CONTENEUR A RESTITUER LE :  </strong></p></td> ");
                stringBuilder.Append(" <td> <p class=MsoNormal><font size='2' face='Arial'>" + conteneur + "</font></p></td></tr> ");
                stringBuilder.Append("<td> <p class=MsoNormal><strong><span style='font-size:10.0pt;font-family:Arial'> TARIF    </strong></p></td> ");
                stringBuilder.Append(" <td> <p class=MsoNormal><font size='2' face='Arial'>" + tarif + "</font></p></td></tr> ");

               
                stringBuilder.Append("  </table>");
                stringBuilder.Append(" </td></tr>");
                //stringBuilder.Append("  <tr><td> </td></tr>");
                stringBuilder.Append("<tr style='mso-yfti-irow:8'>       <td style='padding:2.25pt 2.25pt 2.25pt 2.25pt'> <p class=MsoNormal><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'> " + Convert.ToString(ds.Tables[7].Rows[0]["ENCLOSURE"]) + "</font></span><strong><span style='font-size:10.0pt;font-family:Arial'><font size='2' face='Arial'><strong><br>          <br>          </strong></font><font size='3' face='Arial'><strong>" + username + "&nbsp;           </strong></font><br>          </span></strong></p></td>    </tr>  </table><p class=MsoNormal><o:p>&nbsp;</o:p></p></div></body></html>");
            
            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(stringBuilder));
            stringBuilder.Clear();
            var dataStream = new MemoryStream(byteArray);
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(dataStream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("inline");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_Orderdetransport.doc";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return httpResponseMessage;
        }

        /// <summary>Perform Impfra transit time rpt records.</summary>
        /// <param name="concode">concode parameter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="FROMDT">Start date for the date range filter.</param>
        /// <param name="TODAT">TODAT parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Impfra_transit_time_rpt(string concode, string mode, string FROMDT, string TODAT)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_TRANSIT_TIME_RPT", concode, mode,"0", FROMDT, TODAT);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_transit_time_rpt");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }


        /// <summary>Perform Rpt ClientTransitTime records.</summary>
        /// <param name="client">Client/exporter code.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="frmdt">Start date for the date range filter.</param>
        /// <param name="todt">End date for the date range filter.</param>
        /// <returns>File download (Excel or similar) containing the report data.</returns>
        [HttpGet]
        public HttpResponseMessage Rpt_ClientTransitTime([FromUri]string client, string mode, string frmdt, string todt)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            
            string strSpName = string.Empty, strXslFilename = string.Empty;
            string strData = string.Empty;
            strXslFilename ="xsl_Impfra_clientTransitime.xsl";
            ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_ACCFRA_CLIENT_SHIPMENT_TRANSIT_TIME", client, mode, frmdt,todt);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(ds.GetXml());

            strData = CommonFunction.ConvertToExcel_open("Importfra", strXslFilename, xmlDoc);
           

            byte[] byteArray = Encoding.UTF8.GetBytes(Convert.ToString(strData));
            MemoryStream stream = new MemoryStream(byteArray);
            stream.WriteTo(HttpContext.Current.Response.OutputStream);

            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
            httpResponseMessage.Content = new StreamContent(stream);
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            httpResponseMessage.Content.Headers.ContentDisposition.FileName = "RPT_CLIENT_TRANSIPMENT_REPORT.xls";
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

            return httpResponseMessage;
        }

        /// <summary>Retrieve list of Impfra rpt records.</summary>
        /// <param name="fromdt">Start date for the date range filter.</param>
        /// <param name="Todt">End date for the date range filter.</param>
        /// <param name="mode">Operation mode or filter type.</param>
        /// <param name="CITYCODE">City/branch code.</param>
        /// <param name="RPT_TYPE">RPT TYPE parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult Impfra_rpt_Register(string fromdt, string Todt, string mode, string CITYCODE, string RPT_TYPE)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();

            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_CONSOLE_REGISETR", fromdt, Todt, mode, CITYCODE, RPT_TYPE);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Import/Impfra_rpt_Register");
            }
            finally
            {
                objDal.Dispose();

            }
            return Ok(ds);
        }

        /// <summary>Perform MST EXPORT HAWB VIEWMPCGO records.</summary>
        /// <param name="Type1">Type1 parameter.</param>
        /// <param name="Type2">Type2 parameter.</param>
        /// <param name="Type3">Type3 parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult EXP_MST_EXPORT_HAWB_VIEWMPCGO(string Type1, string Type2, string Type3)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_HAWB_VIEW_MPCGO",
                    Type1, Type2, Type3);
            }
            catch (Exception ex)
            {
                ds = ErrorLog.Error(ex, "Export/EXP_MST_EXPORT_HAWB_VIEWMPCGO");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }

        /// <summary>Perform MST EXPORT HAWB FRT UPDATEMPCGO records.</summary>
        /// <param name="obj">Request body model containing the record fields.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpPost]
        public IHttpActionResult EXP_MST_EXPORT_HAWB_FRT_UPDATEMPCGO([FromBody]HawbRatingMPCGO obj)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {
                ds = objDal.ExecuteDataset(ConnectionString.getConnString(),
                    CommandType.StoredProcedure,
                    "USP_EXP_MST_EXPORT_HAWB_UPDATE_MPCGO",
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
                ds = ErrorLog.Error(ex, "Export/EXP_MST_EXPORT_HAWB_FRT_UPDATE_MPCGO");
            }
            finally
            {
                objDal.Dispose();
                ds.Dispose();
            }
            return Ok(ds);
        }
        /// <summary>Retrieve print/view data for IMPFRA CONSOLE MULTIJOB records.</summary>
        /// <param name="fcr_no">fcr no parameter.</param>
        /// <returns>DataSet with the requested data serialized as JSON.</returns>
        [HttpGet]
        public IHttpActionResult IMPFRA_CONSOLE_MULTIJOB_VIEW(string fcr_no)
        {
            DataSet ds = new DataSet();
            DAL objDal = new DAL();
            try
            {

                ds = objDal.ExecuteDataset(ConnectionString.getConnString(), CommandType.StoredProcedure, "USP_IMPFRA_CONSOLE_MULTIJOB_VIEW", fcr_no);

            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "importfra/IMPFRA_CONSOLE_MULTIJOB_VIEW");
            }
            return Ok(ds);
        }
    }



}
