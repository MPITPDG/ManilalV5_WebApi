<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <html>
      <head>
        <script language="javascript" type="text/javascript">
          function fnScrool(jn)
          {
          //alert(jn)
          window.location.href='#' + jn;
          document.getElementById(jn).style.backgroundColor = 'Yellow'
          }
        </script>
      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
        <table border='0' cellpadding='1' cellspacing='1' width='100%' class="subTbl">
          <xsl:for-each select="//NewDataSet/Table">
            <xsl:variable name="ID" select="CONSOLENO"></xsl:variable>
            <xsl:variable name="IMPORTED" select="IMPORTED"></xsl:variable>
            <tr bgcolor="#99CCCC">
              <td height="2" colspan="2" align="center">
                <div align="left">
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    <b>
                      Console No :
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      <xsl:value-of select="CONSOLENO" />
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
            <!-- GENERAL DETAILS-->
            <tr bgcolor="#99CCCC">
              <td colspan="2">
                <table width="100%" cellspacing="1" cellpadding="3" border="1">
                  <tr>
                    <td width="29%" valign="top" height="2">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Date</font>
                      </b>
                    </td>
                    <td width="17%" height="2">
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        <xsl:value-of select="CONSOLEDT" />
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
                        <xsl:value-of select="MODE_VALUE" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </font>
                    </td>
                  </tr>
                  <tr>
                    <td width="29%" height="2" valign="top">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Consolidation Sent From</font>
                      </b>
                    </td>
                    <td width="17%" height="2">
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        <xsl:value-of select="SENT_FROM_CITY" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </font>
                    </td>
                    <td width="13%" height="2">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Agent</font>
                      </b>
                    </td>
                    <td height="2">
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        <xsl:value-of select="AGENT_NAME" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </font>
                    </td>
                  </tr>
                  <tr>
                    <td width="29%" valign="top" height="2">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Destination</font>
                      </b>
                    </td>
                    <td width="17%" height="2">
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        <xsl:value-of select="DESTINATION" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </font>
                    </td>
                    <td width="13%" height="2">
                      <b></b>
                    </td>
                    <td height="2">
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
            <!-- VESSEL DETAILS-->
            <xsl:if test="MODE_VALUE='SEA'">
              <tr bgcolor="#99CCCC">
                <td colspan="2">
                  <table width="100%" border="1" cellspacing="1" cellpadding="3">
                    <tr>
                      <td width="18%" valign="top" height="21">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>Shipping Line</b>
                        </font>
                      </td>
                      <td width="18%" valign="top" height="21">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="SHIPLINE_NAME" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td width="13%" valign="top" height="21">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>Vessel</b>
                        </font>
                      </td>
                      <td width="20%" valign="top" height="21">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="VESSELNAME" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td width="9%" valign="top" height="21">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>Voyage</b>
                        </font>
                      </td>
                      <td width="26%" valign="top" height="21">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="VOYAGE" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td width="18%" height="2" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>Sailed On</b>
                        </font>
                      </td>
                      <td width="14%" height="2" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="VESSELETD" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td width="13%" valign="top" height="2">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>M B/L No.</b>
                        </font>
                      </td>
                      <td width="20%" height="2" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="MBLNO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td height="2" valign="top" width="9%">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>Date</b>
                        </font>
                      </td>
                      <td height="2" valign="top" width="26%">
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
            <xsl:if test="MODE_VALUE='AIR'">
              <tr bgcolor="#99CCCC">
                <td height="2" colspan="2">
                  <table width="100%" border="1" cellspacing="1" cellpadding="3">
                    <tr>
                      <td width="23%" height="14" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>Airline Name</b>
                        </font>
                      </td>
                      <td height="14" colspan="5" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="AIRLINE" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td height="2" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>Planned Flight No</b>
                        </font>
                      </td>
                      <td height="2" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="FLIGHTNO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td height="2" valign="top">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Date</font>
                        </b>
                      </td>
                      <td width="35%" height="2" colspan="3">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="FLIGHTDT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td height="2" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>Actual Flight No</b>
                        </font>
                      </td>
                      <td height="2" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="ACTUALFLIGHTNO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td height="2" valign="top">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Date</font>
                        </b>
                      </td>
                      <td height="2" colspan="3">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="ACTUALFLIGHTDT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td width="23%" height="2" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>MAWB No</b>
                        </font>
                      </td>
                      <td width="28%" height="2" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="MAWBNO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td width="14%" height="2" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>Date</b>
                        </font>
                      </td>
                      <td height="2" colspan="3">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="MAWBDT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td height="2" valign="top">
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                          <b>
                            DOSSIER/D
                          </b>
                        </font>
                      </td>
                      <td height="2" colspan="5" valign="top">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="DDMSG" />
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
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Volume </font>
                      </b>
                    </td>
                    <td width="23%" height="14">
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        <xsl:value-of select="VOLUME" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </font>
                    </td>
                  </tr>
                  <xsl:if test="MODE_VALUE='AIR'">
                    <tr>
                      <td height="14" valign="top">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CHBL WT. </font>
                        </b>
                      </td>
                      <td height="14">
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
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">VIA</font>
                      </b>
                    </td>
                    <td width="23%" height="2">
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        <xsl:value-of select="TRANS" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </font>
                    </td>
                  </tr>
                  <tr>
                    <td height="2" valign="top" width="19%">
                      <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                        <b>House B/L Issued</b>
                      </font>
                    </td>
                    <td height="2" valign="top" width="30%">
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        <xsl:value-of select="BL" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
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
            <tr bgcolor="#99CCCC">
              <td height="25">
                <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                  <b>
                    <a href="consoleremarkedit.asp?consoleno=20201106024300">
                      REMARK
                    </a>
                  </b>
                </font>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="CONSOLEREMARK" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <xsl:if test="MODE_VALUE='SEA'">
            <tr bgcolor="#99CCCC">
              <td colspan="2">
                <table width="100%" border="1" cellspacing="1" cellpadding="1">
                  <tr>
                    <td>
                      <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                        <b>CONTAINER NO.</b>
                      </font>
                    </td>
                    <td>
                      <strong>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Quai D'enlevement</font>
                      </strong>
                    </td>
                    <td>
                      <strong>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Quai De Restitution</font>
                      </strong>
                    </td>
                    <td>
                      <strong>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Last free date</font>
                      </strong>
                    </td>
                  </tr>
                  <xsl:for-each select="//NewDataSet/Table1">
                    <tr>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="CONTAINERNO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="ENLEVEMENT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="RESTITUTION" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td>
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
            <!-- Job No SUB TABLES START-->
            <xsl:for-each select="//NewDataSet/Table2">
              <xsl:variable name="JOBID" select="JOBNO"></xsl:variable>
              <tr bgcolor="#33FFFF">
                <td colspan="2" bgcolor="#33FFFF">
                  <table width="100%" id="J{$JOBID}" border="1" cellpadding="2" cellspacing="2">
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
                              <xsl:when test="MODE_VALUE='SEA'">
                                HBL NO. :
                              </xsl:when>
                              <xsl:otherwise>
                                HAWB NO. :
                              </xsl:otherwise>
                            </xsl:choose>
                          </font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">DATE</font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">DESTINATION</font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">INCOTERM</font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">SHIPPER</font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">IMPORTER</font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">PKGS</font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">WEIGHT</font>
                        </strong>
                      </td>
                      <xsl:if test="MODE_VALUE='AIR'">
                        <td>
                          <strong>
                            <font size="1" face="Verdana, Arial, Helvetica, sans-serif">CHBL WT </font>
                          </strong>
                        </td>
                      </xsl:if>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">VOLUME</font>
                        </strong>
                      </td>
                      <td>
                        <strong>
                          <font size="1" face="Verdana, Arial, Helvetica, sans-serif">FREIGHT</font>
                        </strong>
                      </td>
                    </tr>
                    <tr>
                      <td rowspan="5">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <b>

                            <xsl:value-of select="$JOBID" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            <br/>
                            <center>
                              <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_JobNo('{$JOBID}')">PRINT DOSSIER</label>
                            </center>
                          </b>
                        </font>
                      </td>
                      <td width="16%" height="9">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:choose>
                            <xsl:when  test="$IMPORTED='Y'">
                            <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_HawbNo('{HAWBNO}')">
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
                      <td width="13%" height="9">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="HAWBDT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td width="6%">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="DESTINATION_CITY" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="INCOTERM" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="SHIPPER" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td>
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
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="WEIGHT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <xsl:if test="MODE_VALUE='AIR'">
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="CHBLWT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </xsl:if>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="VOLUME" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="FREIGHT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="11">
                        <table width="60%" border="1" cellspacing="2" cellpadding="2" align="center">
                          <tr>
                            <th>
                              <div align="center">
                                <font size="1">Importer's Reference</font>
                              </div>
                            </th>
                            <th>
                              <div align="center">
                                <font size="1">Pieces</font>
                              </div>
                            </th>
                            <th>
                              <div align="center">
                                <font size="1">Type of Pieces</font>
                              </div>
                            </th>
                            <th>
                              <div align="center">
                                <font size="1">LSD (Last date of shiment)</font>
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
                                <td>
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
                                <td>
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
                    <tr>
                      <td colspan="11"></td>
                    </tr>
                    <tr>
                      <td colspan="11">
                        <table width="100%" border="1" cellspacing="1" cellpadding="3">
                          <tr>
                            <td>
                              <strong>
                                <font size="1" face="Verdana, Arial, Helvetica, sans-serif">ACTUAL ARRIVAL </font>
                              </strong>
                            </td>
                            <td>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                <xsl:value-of select="ACTUALARRIVALDT" />
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                              </font>
                            </td>
                          </tr>
                          <!-- DELIVERY DETAILS-->
                          <xsl:for-each select="//NewDataSet/Table5">
                            <xsl:if test="FK_JOB_DELIVERY=$JOBID">
                              <xsl:variable name="DELIVERYID" select="DELIVERYNO"></xsl:variable>
                              <tr>
                                <td>
                                  <strong>
                                    <font size="1" face="Verdana, Arial, Helvetica, sans-serif">
                                      ACTUAL DELIVERY
                                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    </font>
                                  </strong>
                                </td>
                                <td>
                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                    <b>PKGS :</b>
                                    <xsl:value-of select="PKGS" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_DelNo('{DELIVERYNO}')">
                                      <b>DELIVERY DETAILS</b>
                                    </label>
                                    <br/>
                                    <table cellspacing="2" cellpadding="2" border="1">
                                      <tr>
                                        <th>
                                        </th>
                                        <th>
                                          <font face="verdana" size="2">DATE</font>
                                        </th>
                                        <th>
                                          <font face="verdana" size="2">TIME</font>
                                        </th>
                                        <th>
                                          <font face="verdana" size="2">REMARK</font>
                                        </th>
                                      </tr>
                                      <xsl:for-each select="//NewDataSet/Table6">
                                        <xsl:if test="FK_DELIVERY=$DELIVERYID">
                                          <tr>
                                            <td>
                                              <font face="verdana" size="2">
                                                <b>APPOINTMENT</b>
                                              </font>
                                            </td>
                                            <td>
                                              <font face="verdana" size="2">
                                                <xsl:value-of select="APPTDT" />
                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                              </font>
                                            </td>
                                            <td>
                                              <font face="verdana" size="2">
                                                <xsl:value-of select="APPTTIME" />
                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                              </font>
                                            </td>
                                            <td>
                                              <font face="verdana" size="2">
                                                <xsl:value-of select="APPTRMRK" />
                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                              </font>
                                            </td>
                                          </tr>
                                        </xsl:if>
                                      </xsl:for-each>
                                    </table>
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
            </xsl:for-each>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>