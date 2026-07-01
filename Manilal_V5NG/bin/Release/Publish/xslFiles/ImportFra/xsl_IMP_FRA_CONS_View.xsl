<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <html>
      <head>
        <script language="javascript" type="text/javascript">

        </script>
        <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
        <link href="../../include/css/ManilalStyleSheet.css" type="text/css" rel="stylesheet" />
        <!--<link href="../../include/jsCommon/ToolTip.js" type="text/javascript"/>-->
      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" background-color="#F3F8FE">
        <div id="tableContainer" class="divSpace" style="width:100%" >
          <table border='0' cellpadding='1' cellspacing='1' width='100%' class="subTbl">
            <xsl:for-each select="//NewDataSet/Table">
              <xsl:variable name="ID" select="CONSOLENO"></xsl:variable>
              <xsl:variable name="IMPORTED" select="IMPORTED"></xsl:variable>
              <xsl:variable name="ACTUALARDT" select="ACTUALARRIVALDT"></xsl:variable>
              <xsl:variable name="MODE" select="MODE"></xsl:variable>
              <xsl:variable name="RATE_FLG" select="RATE"></xsl:variable>
              <xsl:variable name="INVNO" select="INVNO"></xsl:variable>
              <xsl:variable name="IMPORTERS" select="IMPORTERS"></xsl:variable>
              <xsl:variable name="FULL_CONS" select="FULLNO"></xsl:variable>
              <xsl:variable name="INV_CONS" select="INV_CONSOLE"></xsl:variable>
              <xsl:variable name="MAWB_NO" select ="MAWBNO"/>
              <tr bgcolor="#99CCCC">
                <td height="2" colspan="2" align="center">
                  <div align="center">
                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                      <b>
                        <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.Exp_View_Edoc('{FULLNO}')">E-Document - View/Upload File</label>
                      </b>
                    </font>
                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    </font>

                  </div>
                </td>
              </tr>
              <tr bgcolor="#99CCCC">
                <td height="2" colspan="2" align="center">
                  <div align="left">
                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                      <b>
                        Console No :
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        <xsl:value-of select="CONSOLENO" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;&amp;nbsp;</xsl:text>
                         
                        <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fnClick_Dossier('{CONSOLENO}')">PRINT DOSSIER</label>
                      </b>
                    </font>
                  </div>
                </td>
              </tr>
              <xsl:if test="IMPORTED='Y'">
                <tr>
                  <td colspan='2' style="color: red;text-align: center;font-style: normal;background: yellow;border-top: 1.0pt solid white;border-bottom: 1.0pt solid white;border-right: 0pt solid windowtext;border-left: 0pt solid windowtext;font-weight: bold;font-size: 11px;font-family: Verdana, Calibri;" class='HiLight_Yellow'>
                    DATA IS DIRECTLY IMPORTED FROM INDIA
                  </td>
                </tr>
              </xsl:if>
              <tr class="DataGridHeader_xslt">
                <td colspan ='2' class="header">
                  General Details
                </td>
              </tr>
              <!-- GENERAL DETAILS-->
              <tr bgcolor="#99CCCC">
                <td  colspan="2">
                  <table width="100%" cellspacing="1" cellpadding="3" border="1">
                    <tr>
                      <td width="29%" valign="top" height="2">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Date</font>
                        </b>
                      </td>
                      <td width="17%" height="2">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="CONSOLEDT"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td width="13%" height="2">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Mode</font>
                        </b>
                      </td>
                      <td height="2">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:if test="MODE='s'">
                            Sea
                          </xsl:if>
                          <xsl:if test="MODE='a'">
                            Air
                          </xsl:if>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td width="29%" height="2" valign="top">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            Consolidation Sent From
                          </font>
                        </b>
                      </td>
                      <td width="17%" height="2">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="SENT_CITY_NAME" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td width="13%" height="2">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            Agent
                          </font>
                        </b>
                      </td>
                      <td height="2">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="SUP_NAME" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <tr >
                      <td width="29%" valign="top" height="2">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Destination</font>
                        </b>
                      </td>
                      <td     height="2" colspan="6"  >
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="DESTINATION" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>

                    </tr>
                  </table>
                </td>
              </tr>
              <!-- VESSEL DETAILS-->
              <xsl:if test="$MODE='s'">

                <tr bgcolor="#99CCCC">
                  <td colspan="2">
                    <table width="100%" border="1" cellspacing="1" cellpadding="3">
                      <tr>
                        <td width="18%" valign="top" height="21">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <b>Shipping Line</b>
                            </font>
                          </b>
                        </td>
                        <td width="18%" valign="top" height="21">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="SHIPLINE_NAME" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>

                        <td width="18%" valign="top" height="21">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Vessel
                            </font>
                          </b>
                        </td>
                        <td width="18%" valign="top" height="21">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="VSL_NAME" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td width="18%" valign="top" height="21">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Voyage
                            </font>
                          </b>
                        </td>
                        <td width="18%" valign="top" height="21">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="VSL_VOYNO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td width="18%" valign="top" height="21">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Sailed On
                            </font>
                          </b>
                        </td>
                        <td width="18%" valign="top" height="21">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="SAILING" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td width="18%" valign="top" height="21">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              M B/L No.
                            </font>
                          </b>
                        </td>
                        <td width="18%" valign="top" height="21">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="MBLNO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td width="18%" valign="top" height="21">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Date
                            </font>
                          </b>
                        </td>
                        <td width="18%" valign="top" height="21">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="MBLDT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </xsl:if>

              <!-- AIR LINE DETAILS-->
              <xsl:if test="$MODE='a'">
                <tr bgcolor="#99CCCC">
                  <td height="2" colspan="2">
                    <table width="100%" border="1" cellspacing="1" cellpadding="3">
                      <tr>
                        <td width="23%" height="14" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Airline Name
                            </font>
                          </b>
                        </td>
                        <td height="14" colspan="5" valign="top">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="AIRLINE" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td width="23%" height="14" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Planned Flight No
                            </font>
                          </b>
                        </td>
                        <td height="2" valign="top">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="FLIGHTNO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td width="23%" height="14" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Date
                            </font>
                          </b>
                        </td>
                        <td height="2" valign="top">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="FLIGHTDT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td width="23%" height="14" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Actual Flight No
                            </font>
                          </b>
                        </td>
                        <td height="2" valign="top">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="ACTUALFLIGHTNO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td width="23%" height="14" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Date
                            </font>
                          </b>
                        </td>
                        <td height="2" valign="top">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="ACTUALFLIGHTDT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td width="23%" height="14" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              MAWB No
                            </font>
                          </b>
                        </td>
                        <td height="2" valign="top">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="MAWBNO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td width="23%" height="14" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Date
                            </font>
                          </b>
                        </td>
                        <td height="2" valign="top">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="MAWBDT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td width="23%" height="14" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              CO2 Emition Level
                            </font>
                          </b>
                        </td>
                        <td height="2" valign="top" colspan="5">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="CO2_EMITION_LVL" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td width="23%" height="14" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              DOSSIER/D
                            </font>
                          </b>
                        </td>
                        <td height="2" valign="top"  colspan="5">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="DOUANENO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </xsl:if>
              <!-- End Air Details-->
              <!-- GOODS DETAILS-->
              <tr bgcolor="#99CCCC">
                <td colspan="2">
                  <table width="100%" border="1" cellspacing="1" cellpadding="3">
                    <tr>
                      <td width="19%" valign="top">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Packages</font>
                        </b>
                      </td>
                      <td width="30%">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="NOOFPKGS" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td width="28%">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Type of pkgs </font>
                        </b>
                      </td>
                      <td width="23%">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="TYPEOFPKGS" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td width="19%" height="14" valign="top">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Weight Kgs</font>
                        </b>
                      </td>
                      <td height="14" width="30%">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="WEIGHT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td height="14" width="28%">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            Volume
                          </font>
                        </b>
                      </td>
                      <td width="23%" height="14">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="VOLUME" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <xsl:if test="$MODE='a'">
                      <tr>
                        <td height="14" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CHBL WT. </font>
                          </b>
                        </td>
                        <td  height="14" width="25%" >
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="CHBLWT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                      </tr>
                    </xsl:if>
                    <tr>
                      <td width="19%" height="2" valign="top">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">ETA</font>
                        </b>
                      </td>
                      <td height="2" width="30%">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="ETA" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td height="2" width="28%">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            VIA
                          </font>
                        </b>
                      </td>
                      <td width="23%" height="2">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:if test="VIA='v'">
                            <xsl:value-of select="TRANS_CITY_NAME" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </xsl:if>
                          <xsl:if test="VIA='d'">
                            DIRECT
                          </xsl:if>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td height="2" valign="top" width="19%">
                        <b>
                          <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                            House B/L Issued
                          </font>
                        </b>
                      </td>
                      <td height="2" valign="top" width="30%">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:if test="HOUSEBL='y'" >
                            Yes
                          </xsl:if>
                          <xsl:if test="HOUSEBL!='y'" >
                            No
                          </xsl:if>
                        </font>
                      </td>
                      <td height="2" valign="top" width="28%">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Freight </font>
                        </b>
                      </td>
                      <td width="23%" height="2">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="FREIGHT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>

                  </table>
                </td>
              </tr>
              <xsl:if test="$MODE='s'">
                <tr bgcolor="#99CCCC">
                  <td colspan="2">
                    <table width="100%" border="1" cellspacing="1" cellpadding="1">
                      <tr bgcolor="#99CCCC">
                        <td>
                          <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                            <b>CONTAINER NO.</b>
                          </font>
                        </td>
                        <td   width="75%"  >
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_containerview('{CONTAINERNO}','{CONSOLENO}')">
                              <xsl:value-of select="CONTAINERNO" />
                            </label>
                            <label>-</label>
                            <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_containerExgview('{CONTAINERNO}','{CONSOLENO}')">EDIT DESTINATION EXCHANGE RATE</label>
                          </font>
                          <xsl:if test="SINGLESHPR='y'">
                            SINGLE SHIPPER
                          </xsl:if>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>
              </xsl:if>
              <tr bgcolor="#99CCCC">
                <xsl:if test="IMPORTED='Y'">
                  <td  height="25" colspan="4">
                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                      <label   style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('GENREM','{CONTAINERNO}','{CONSOLENO}','')">
                        REMARK
                      </label>
                      <td></td>
                    </font>
                  </td>
                </xsl:if>
                <xsl:if test="IMPORTED!='Y'">
                  <td  >
                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                      <B>REMARK</B>
                    </font>
                  </td>
                  <td>
                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                      <xsl:value-of select="REMARK" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </font>
                  </td>
                </xsl:if>
              </tr>
              <xsl:if test="$MODE='s'">
                <tr bgcolor="#99CCCC">
                  <td colspan="2">
                    <table width="100%" border="1" cellspacing="1" cellpadding="1">
                      <tr>
                        <td>
                          <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                            <b>CONTAINER NO.</b>
                          </font>
                        </td>
                        <td >
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Quai D'enlevement
                            </font>
                          </strong>
                        </td>
                        <td >
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Quai De Restitution
                            </font>
                          </strong>

                        </td>
                        <td>
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              Last free date
                            </font>
                          </strong>
                        </td>
                      </tr>
                      <xsl:for-each select="//NewDataSet/Table1">
                        <tr bgcolor="#99CCCC">
                          <td >
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('CONT','{CONTAINERNO}','{CONSOLENO}','')">
                                <xsl:value-of select="CONTAINERNO" />
                              </label>
                            </font>
                          </td>
                          <td >
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="ENLEVEMENT" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          <td >
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="RESTITUTION" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          <td >
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="FREEDATE" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </tr>
                      </xsl:for-each>
                    </table>
                  </td>
                </tr>
              </xsl:if>
              <!--<xsl:if test="$RATE_FLG='S'"  >
                <tr>
                  <td colspan='2' style="color: red;text-align: center;font-style: normal;background: yellow;border-top: 1.0pt solid white;border-bottom: 1.0pt solid white;border-right: 0pt solid windowtext;border-left: 0pt solid windowtext;font-weight: bold;font-size: 11px;font-family: Verdana, Calibri;" class='HiLight_Yellow'>
                    <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fn_SeaRates('{$FULL_CONS}','{$IMPORTERS}','{$INVNO}','{$INV_CONS}')" >
                      JULES/BIZZBEE AND BRICE- UPDATE - SEA MONTHLY INVOICE - RATE
                    </label>
                  </td>
                </tr>
              </xsl:if>-->
              <tr bgcolor="#33FFFF">
                <td colspan="2" bgcolor="#33FFFF">
                  <table width="100%" border="1" cellspacing="2" cellpadding="2">
                    <tr  >

                      <td colspan ='11' >
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            Job Details
                          </font>
                        </strong>
                      </td>
                    </tr>
                    <tr bgcolor="#33FFFF">
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">JOB NO</font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:choose>
                              <xsl:when test="$MODE='s'">
                                HBL NO.
                              </xsl:when>
                              <xsl:otherwise>
                                HAWB NO.
                              </xsl:otherwise>
                            </xsl:choose>
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            DATE
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            DESTINATION
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            INCOTERM
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            SHIPPER
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            IMPORTER
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            PKGS
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            WEIGHT
                          </font>
                        </strong>
                      </td>

                      <xsl:if test="$MODE='a'">
                        <td>
                          <strong>
                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                              CHBL WT
                            </font>
                          </strong>
                        </td>
                      </xsl:if>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            VOLUME
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            FREIGHT
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            SURREND ERED DATE
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                            RELEASE RECD DATE
                          </font>
                        </strong>
                      </td>
                    </tr>
                    <xsl:for-each select="//NewDataSet/Table2">
                      <xsl:variable name="JOBID" select="JOBNO"></xsl:variable>
                      <tr>
                        <td rowspan="14">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <b>
                              <xsl:value-of select="$JOBID" />
                              <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_Dossier_Job('{$JOBID}')" >
                                Print Dossier
                              </label>
                            </b>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td  width="16%" height="9">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:choose>
                              <xsl:when  test="$IMPORTED='Y'">
                                <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_HawbNo('{HAWBNO}','{$MAWB_NO}')">
                                  <xsl:value-of select="HAWBNO" />
                                </label>
                              </xsl:when>
                              <xsl:otherwise>
                                <xsl:value-of select="HAWBNO" />
                              </xsl:otherwise>
                            </xsl:choose>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td width="13%"    height="9">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="HAWBDT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td  width="6%">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="CITY_NAME" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td  width="6%">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="INCOTERM" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td >
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="EXPORTER_NAME" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td >
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="IMPORTER_NAME" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="NOOFPKGS" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td width="2%" >
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="WEIGHT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <xsl:if test="$MODE='a'">
                          <td width="2%">
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="CHBLWT" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </xsl:if>
                        <td width="2%">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="VOLUME" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td width="2%">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="FREIGHT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td width="2%">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <label  style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('SURDT','{CONTAINERNO}','{CONSOLENO}','{$JOBID}')">
                              EDIT
                            </label>
                          </font>
                        </td>
                        <td >
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <label   style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('SURDT','{CONTAINERNO}','{CONSOLENO}','{$JOBID}')">
                              EDIT
                            </label>
                          </font>
                        </td>
                      </tr>
                      <tr bgcolor="#33FFFF">
                        <td colspan="13">
                          <table  width="60%" border="1" cellspacing="2" cellpadding="2" align="center">
                            <tr >
                              <th>
                                <div align="center">
                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                    Importer's Reference
                                  </font>
                                </div>
                              </th>
                              <th>
                                <div align="center">
                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                    Pieces
                                  </font>
                                </div>
                              </th>
                              <th>
                                <div align="center">
                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                    Type of Pieces
                                  </font>
                                </div>
                              </th>
                              <th>
                                <div align="center">
                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                    LSD (Last date of shiment)
                                  </font>
                                </div>
                              </th>

                            </tr>
                            <xsl:for-each select="//NewDataSet/Table3">
                              <xsl:if test="FK_JOB_ORDER=$JOBID">
                                <tr>
                                  <td>
                                    <div align="center">
                                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <xsl:value-of select="IMPORTERS_REFERENCE" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </font>
                                    </div>
                                  </td>
                                  <td >
                                    <div align="center">
                                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <xsl:value-of select="PIECES" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </font>
                                    </div>
                                  </td>
                                  <td>
                                    <div align="center">
                                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <xsl:value-of select="TYPE_OF_PIECES" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </font>
                                    </div>
                                  </td>
                                  <td  >
                                    <div align="center">
                                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <xsl:value-of select="LSD" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </font>
                                    </div>
                                  </td>

                                </tr>
                              </xsl:if>
                            </xsl:for-each>
                          </table>
                        </td>
                      </tr>
                      <xsl:if test ="IMPORTED!='Y'">
                        <!--DOCUMET -->
                        <tr bgcolor="#33FFFF">
                          <td colspan="13">
                            <table     width="100%" border="1" cellspacing="2" cellpadding="2">
                              <tr bgcolor="#33FFFF">
                                <td width="22%">
                                  <strong>
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                      DESTINATION-DOCUMENTS
                                      <a href="">EDIT</a>
                                    </font>
                                  </strong>

                                </td>
                                <td width="78%">
                                  <table  width="100%" border="1" cellspacing="2" cellpadding="2">
                                    <tr>
                                      <td width="90%">
                                        <table width="100%" border="1" cellspacing="2" cellpadding="2">
                                          <tr>
                                            <td width="69%" colspan="2">
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  LIST OF DOCUMENTS
                                                </font>
                                              </strong>
                                            </td>
                                            <td   width="25%">
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <div align="center">
                                                    RECD. DATE
                                                  </div>
                                                </font>
                                              </strong>
                                            </td>
                                          </tr>
                                          <xsl:for-each select="//NewDataSet/Table4">
                                            <xsl:if test="FK_JOB_DOCUMENT=$JOBID">
                                              <tr>
                                                <td width="6%">
                                                  <div align="center">

                                                  </div>
                                                </td>
                                                <td   width="69%">
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                    <xsl:value-of select="DOCUMENT" />
                                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                  </font>
                                                </td>
                                                <td  >
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                    <div align="center">
                                                      <xsl:value-of select="RECDDT" />
                                                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                    </div>
                                                  </font>
                                                </td>
                                              </tr>
                                            </xsl:if>
                                          </xsl:for-each>
                                        </table>
                                      </td>
                                    </tr>
                                  </table>
                                </td>
                              </tr>
                            </table>
                          </td>
                        </tr>
                        <!-- END DOCUMET -->
                      </xsl:if>
                      <tr bgcolor="#33FFFF">
                        <td colspan="13">
                          <table  width="100%" border="1" cellspacing="2" cellpadding="2">
                            <tr  >
                              <td   width="22%">
                                <strong>
                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                    DESTINATION DOCUMENTS
                                  </font>
                                </strong>
                              </td>
                              <td width="78%">
                                <table   width="100%" border="1" cellspacing="2" cellpadding="2">
                                  <tr bgcolor="#33FFFF">
                                    <td width="90%">
                                      <table    width="100%" border="1" cellspacing="2" cellpadding="2">
                                        <tr>
                                          <td   width="69%">
                                            <strong>
                                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                LIST OF DOCUMENTS
                                              </font>
                                            </strong>
                                          </td>
                                          <td   width="25%">
                                            <div align="center">
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  RECD.DATE
                                                </font>
                                              </strong>
                                            </div>
                                          </td>
                                        </tr>
                                        <xsl:for-each select="//NewDataSet/Table5">
                                          <xsl:if test="EXPT_JOB_DEST=$JOBID">
                                            <tr>

                                              <td  width="69%">
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <xsl:value-of select="DOCUMENT" />
                                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                </font>
                                              </td>
                                              <td>
                                                <div align="center">
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                    <xsl:value-of select="RECDDT" />
                                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                  </font>
                                                </div>
                                              </td>
                                            </tr>
                                          </xsl:if>
                                        </xsl:for-each>
                                      </table>
                                    </td>
                                  </tr>
                                </table>
                              </td>
                            </tr>
                          </table>
                        </td>
                      </tr>
                      <tr bgcolor="#33FFFF">
                        <td colspan="13"></td>
                      </tr>
                      <!-- END DOCUMET -->
                      <!--CONSIGNEE DOCUMENT-->
                      <xsl:if test ="IMPORTED!='Y'">
                        <tr bgcolor="#33FFFF">
                          <td colspan="13">
                            <table   width="100%" border="1" cellspacing="2" cellpadding="2">
                              <tr>
                                <td width="27%">
                                  <strong>
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                      DOCUMENT SENT TO CONSIGNEE
                                    </font>
                                  </strong>
                                  <a href="">EDIT</a>
                                </td>
                                <td width="73%">
                                  <table width="100%" border="1" cellspacing="2" cellpadding="2">
                                    <tr>
                                      <td width="90%">
                                        <table width="100%" border="1" cellspacing="2" cellpadding="2">
                                          <tr>
                                            <td   width="12%">
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  DATE
                                                </font>
                                              </strong>
                                            </td>
                                            <td   width="25%">
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  COURIER NO.
                                                </font>
                                              </strong>
                                            </td>
                                            <td width="63%" >
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <div align="center">
                                                    REMARKS
                                                  </div>
                                                </font>
                                              </strong>
                                            </td>
                                          </tr>
                                          <tr>
                                            <xsl:if test ="DOCSENTDT!=''">
                                              <td  width="12%">
                                                <div align="center">
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                    <xsl:value-of select="DOCSENTDT" />
                                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                  </font>
                                                </div>
                                              </td>
                                              <td width="15%">
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <xsl:value-of select="COURIERNO" />
                                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                </font>
                                              </td>
                                              <td   width="73%">
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <div align="center">
                                                    <xsl:value-of select="DESTDOCRMK" />
                                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                  </div>
                                                </font>
                                              </td>
                                            </xsl:if>
                                          </tr>
                                        </table>
                                      </td>
                                    </tr>
                                  </table>
                                </td>
                              </tr>
                            </table>
                          </td>
                        </tr>
                      </xsl:if>
                      <tr bgcolor="#33FFFF">
                        <td colspan="13">
                          <table width="100%" border="1" cellspacing="2" cellpadding="2">
                            <tr>
                              <td width="27%">
                                <strong>
                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                    DOCUMENT SENT TO CONSIGNEE
                                  </font>
                                </strong>
                              </td>
                              <td width="73%">
                                <table   width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td width="90%">
                                      <table   width="100%" border="1" cellspacing="2" cellpadding="2">
                                        <tr>
                                          <td  width="12%">
                                            <strong>
                                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                DATE
                                              </font>
                                            </strong>
                                          </td>
                                          <td width="25%">
                                            <strong>
                                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                COURIER NO.
                                              </font>
                                            </strong>
                                          </td>
                                          <td width="63%">
                                            <div align="center">
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  REMARKS
                                                </font>
                                              </strong>
                                            </div>
                                          </td>
                                        </tr>
                                        <xsl:for-each select="//NewDataSet/Table6">
                                          <xsl:if test="EXPT_JOB=$JOBID">
                                            <tr>
                                              <xsl:if test ="DOCSENTDT!=''">
                                                <td  width="12%">
                                                  <div align="center">
                                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                      <xsl:value-of select="DOCSENTDT" />
                                                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                    </font>
                                                  </div>
                                                </td>
                                                <td  width="15%">
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                    <xsl:value-of select="COURIERNO" />
                                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                  </font>
                                                </td>
                                                <td width="73%">
                                                  <div align="center">
                                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                      <xsl:value-of select="DESTDOCRMK" />
                                                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                    </font>
                                                  </div>
                                                </td>
                                              </xsl:if>
                                            </tr>
                                          </xsl:if>
                                        </xsl:for-each>
                                      </table>
                                    </td>
                                  </tr>
                                </table>
                              </td>
                            </tr>
                          </table>

                        </td>
                      </tr>

                      <!--END CONSIGNEE-->
                      <tr bgcolor="#33FFFF">
                        <td colspan="13"></td>
                      </tr>
                      <!--RECEIPT OF CARGO-->
                      <xsl:if test ="IMPORTED!='Y'">
                        <tr bgcolor="#33FFFF">
                          <td colspan="13">
                            <table    width="100%" border="1" cellspacing="2" cellpadding="2">
                              <tr>
                                <td width="20%">
                                  <strong>
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                      RECEIPT OF CARGO
                                      <a href="">EDIT</a>
                                    </font>
                                  </strong>
                                </td>
                                <td width="80%">
                                  <table width="100%" border="1" cellspacing="2" cellpadding="2">
                                    <tr>
                                      <td width="90%">
                                        <table width="100%" border="1" cellspacing="2" cellpadding="2">
                                          <tr>
                                            <td  width="15%">
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  NO OF PKGS
                                                </font>
                                              </strong>
                                            </td>
                                            <td  width="15%">
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  RECD DATE
                                                </font>
                                              </strong>
                                            </td>
                                            <td   width="50%">
                                              <div align="center">
                                                <strong>
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                    RECD WHERE
                                                  </font>
                                                </strong>
                                              </div>
                                            </td>
                                            <td  width="20%">
                                              <div align="center">
                                                <strong>
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                    RECD LOCALLY
                                                  </font>
                                                </strong>
                                              </div>
                                            </td>
                                          </tr>
                                          <tr>
                                            <td  width="15%">
                                              <div align="center">
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <xsl:value-of select="NOOFPKGS" />
                                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                </font>
                                              </div>
                                            </td>
                                            <td  width="15%">
                                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                <xsl:value-of select="RECDDATE" />
                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                              </font>
                                            </td>
                                            <td   width="50%">
                                              <div align="center">
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <xsl:value-of select="RECDWHERE" />
                                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                </font>
                                              </div>
                                            </td>
                                            <td  width="20%">
                                              <div align="center">
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <xsl:value-of select="RECDLOCAL" />
                                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                </font>
                                              </div>
                                            </td>
                                          </tr>
                                        </table>
                                      </td>
                                    </tr>
                                  </table>
                                </td>
                              </tr>
                            </table>
                          </td>
                        </tr>
                      </xsl:if>
                      <tr bgcolor="#33FFFF">
                        <td colspan="13">
                          <table  width="100%" border="1" cellspacing="2" cellpadding="2">
                            <tr>
                              <td width="17%" >
                                <strong>
                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                    RECEIPT OF CARGO
                                  </font>
                                </strong>
                              </td>
                              <td width="83%">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                  <tr>
                                    <td width="90%">
                                      <table width="100%" border="1" cellspacing="2" cellpadding="2">
                                        <tr>
                                          <td  width="15%">
                                            <strong>
                                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                NO OF PKGS
                                              </font>
                                            </strong>
                                          </td>
                                          <td   width="15%">
                                            <strong>
                                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                RECD DATE
                                              </font>
                                            </strong>
                                          </td>
                                          <td   width="50%">
                                            <strong>
                                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                <div align="center">
                                                  RECD WHERE
                                                </div>
                                              </font>
                                            </strong>
                                          </td>
                                          <td  width="20%">
                                            <strong>
                                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                <div align="center">
                                                  RECD LOCALLY
                                                </div>
                                              </font>
                                            </strong>
                                          </td>
                                        </tr>
                                        <xsl:for-each select="//NewDataSet/Table6">
                                          <xsl:if test="EXPT_JOB=$JOBID">
                                            <tr>
                                              <td    width="15%">
                                                <div align="center">
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                    <xsl:value-of select="NOOFPKGS" />
                                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                  </font>
                                                </div>
                                              </td>
                                              <td    width="15%">
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <xsl:value-of select="RECDDATE" />
                                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                </font>
                                              </td>
                                              <td  width="50%">
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <div align="center">
                                                    <xsl:value-of select="RECDWHERE" />
                                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                  </div>
                                                </font>
                                              </td>
                                              <td   width="20%">
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                  <div align="center">
                                                    <xsl:value-of select="RECDLOCAL" />
                                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                  </div>
                                                </font>
                                              </td>
                                            </tr>
                                          </xsl:if>
                                        </xsl:for-each>
                                      </table>
                                    </td>
                                  </tr>
                                </table>

                              </td>
                            </tr>
                          </table>

                        </td>
                      </tr>
                      <!--END OF RECEIPT OF CARGO-->
                      <tr bgcolor="#33FFFF">
                        <td colspan="13"> </td>
                      </tr>
                      <tr bgcolor="#33FFFF">
                        <td colspan="13">
                          <table   width="100%" border="1" cellspacing="2" cellpadding="2">
                            <tr>
                              <td  width="20%">
                                <strong>
                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                    ACTUAL ARRIVAL
                                  </font>
                                </strong>

                              </td>
                              <td   width="80%">
                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                  <xsl:value-of select="$ACTUALARDT" />
                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </font>
                              </td>
                            </tr>
                            <xsl:for-each select="//NewDataSet/Table7">
                              <xsl:if test="EXPT_JOB1=$JOBID">
                                <tr>
                                  <td  width="20%">
                                    <strong>
                                      <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                                        ACTUAL DELIVERY
                                      </font>
                                    </strong>
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </td>
                                  <td   width="80%" >
                                    <strong>
                                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        <xsl:value-of select="PKGS_DEL"/>-
                                        <xsl:value-of select= "ACTUALDT" />-
                                        <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_DelNo('{DELIVERYNO}')">
                                          <b> DELIVERY DETAILS </b>
                                        </label>
                                        <br/>
                                      </font>
                                    </strong>
                                  </td>
                                </tr>
                              </xsl:if>
                            </xsl:for-each>
                          </table>
                        </td>
                      </tr>
                      <tr bgcolor="#33FFFF">
                        <td colspan="13">
                          <tr bgcolor="#33FFFF">
                            <td colspan="13">
                              <table  width="100%" border="1" cellspacing="2" cellpadding="2">
                                <tr>
                                  <td   width="14%">
                                    <b>
                                      <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                                        <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('CONREM','','{JOBNO_CONSOLE}','{$JOBID}')">
                                          REMARK
                                        </label>
                                      </font>
                                    </b>
                                  </td>
                                  <td>
                                    <table width="100%" border="1" cellspacing="2" cellpadding="2">
                                      <tr>
                                        <td width="20%">
                                          <strong>
                                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                                              CONSIGNEE REMARKS:
                                            </font>
                                          </strong>
                                        </td>
                                        <td  width="80%" >
                                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                            <xsl:value-of select="REMARK" />
                                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                          </font>
                                        </td>
                                      </tr>
                                      <tr>
                                        <td   width="20%">
                                          <strong>
                                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                                              MP-INTERNAL REMARKS :
                                            </font>
                                          </strong>
                                        </td>
                                        <td   width="80%" >
                                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                            <xsl:value-of select="MP_INTERNAL_REMARK" />
                                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                          </font>
                                        </td>
                                      </tr>
                                    </table>
                                  </td>

                                </tr>
                                <tr bgcolor="#33FFFF">
                                  <td  width="14%">
                                    <strong>
                                      <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                                        <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('CUSTOM','','{JOBNO_CONSOLE}','{$JOBID}')">
                                          CUSTOM CLR AND PALLET DET
                                        </label>
                                      </font>
                                    </strong>
                                  </td>
                                  <td>
                                    <table   width="100%" border="1" cellspacing="2" cellpadding="2">
                                      <tr>
                                        <td   width="20%">
                                          <strong>
                                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                                              CUSTOM CLEAR NO :
                                            </font>
                                          </strong>
                                        </td>
                                        <td   width="80%" >
                                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                            <xsl:value-of select="CUSTOM_CLEAR_NO" />
                                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                          </font>
                                        </td>
                                      </tr>
                                      <tr>
                                        <td width="20%">
                                          <strong>
                                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                                              CUSTOM CLEAR DATE :
                                            </font>
                                          </strong>
                                        </td>
                                        <td  width="80%" >
                                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                            <xsl:value-of select="CUSTOM_CLEAR_DT" />
                                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                          </font>
                                        </td>
                                      </tr>
                                      <tr>
                                        <td  width="20%">
                                          <strong>
                                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                                              NO OF PALLET:
                                            </font>
                                          </strong>
                                        </td>
                                        <td width="80%" >
                                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                            <xsl:value-of select="NO_OF_PALLET" />
                                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                          </font>
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </td>
                      </tr>
                      <tr bgcolor="#33FFFF">
                        <td colspan="13">
                          <tr>
                            <td colspan="13">
                              <table   width="100%" border="1" cellspacing="2" cellpadding="2">
                                <tr>
                                  <td   width="30%">
                                    <strong>
                                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                        PREPAID FREIGHT APPROVED BY SHIPPER
                                      </font>
                                    </strong>
                                  </td>
                                  <td   width="48%">
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                      <xsl:value-of select="PPFRTAPPDT" />
                                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    </font>
                                  </td>

                                </tr>
                                <tr>
                                  <td  width="30%">
                                    <strong>
                                      <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                                        APPROVAL
                                      </font>
                                    </strong>

                                  </td>
                                  <td  width="48%">
                                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                      <xsl:value-of select="APPDT" /> -
                                      <xsl:value-of select="APPWM" />
                                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    </font>
                                  </td>
                                </tr>

                              </table>
                            </td>
                          </tr>
                        </td>
                      </tr>
                    </xsl:for-each>
                  </table>
                </td>
              </tr>
              <xsl:if test="$MODE='s'">

                <tr bgcolor="#33FFFF">
                  <td colspan="13">
                    <table   width="100%"  border="1" cellpadding="2" cellspacing="2">
                      <tr  bgcolor="#33FFFF">
                        <td colspan ='3' >
                          <strong>
                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                              No. Of Pallets Details
                            </font>
                          </strong>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <strong>
                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                              Containerno
                            </font>
                          </strong>
                        </td>
                        <td>
                          <strong>
                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                              Importer
                            </font>
                          </strong>
                        </td>
                        <td>
                          <strong>
                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                              No. Of Pallets
                            </font>
                          </strong>
                        </td>
                      </tr>

                      <xsl:for-each select="//NewDataSet/Table8">
                        <tr >
                          <td  height="9">
                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="CONTAINERNO" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          <td   height="9">
                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="EXP_NAME" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          <td   height="9">
                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="NO_OF_PALLETS" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </tr>
                      </xsl:for-each>

                    </table>
                  </td>
                </tr>
              </xsl:if>
            </xsl:for-each>
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
