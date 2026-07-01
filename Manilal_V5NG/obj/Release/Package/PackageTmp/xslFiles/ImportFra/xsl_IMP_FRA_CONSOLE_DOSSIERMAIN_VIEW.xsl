<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <html>
      <head>       
      </head>

      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" >
       <div id="tableContainer" class="divSpace" align="center" style="width:100%" >
          <table width="100%" border="1" cellspacing="3" cellpadding="3" align="center">
            <xsl:for-each select="//NewDataSet/Table1">
              <xsl:variable name="Mode" select="MODE"/>
              <tr>
                <td>
                  <div align="center">
                    <font size="5" face="Arial">
                      <strong>
                        <xsl:if test="$Mode='s'">
                          DOSSIER IMPORT MARITIME
                        </xsl:if>
                        <xsl:if test="$Mode='a'">
                          DOSSIER IMPORT AEIREN
                        </xsl:if>
                      </strong>
                    </font>
                  </div>
                </td>
              </tr>
              <xsl:variable name="REMARK" select="REMARK"/>

              <tr>
                <td>
                  <table width="100%" border="1" cellspacing="1" cellpadding="3">
                    <tr>
                      <td colspan="2">
                        <div align="center">
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CONSOLE</font>
                          </strong>
                        </div>
                      </td>
                      <td width="15%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            NO
                            DOSSIER
                          </font>
                        </strong>
                      </td>
                      <td width="33%">
                        <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                          <strong>
                            <strong>
                              <xsl:value-of select="CONSOLENO" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </strong>
                          </strong>
                        </font>
                      </td>
                    </tr>
                    <xsl:if test="$Mode='s'">
                      <tr>
                        <td width="18%">
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              N B/L
                            </font>
                          </strong>
                        </td>
                        <td width="34%">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="MBLNO" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              POL
                            </font>
                          </strong>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="SENTFROM" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              SHIPPING LINE

                            </font>
                          </strong>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="SHIPLINE" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              POD
                            </font>
                          </strong>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="DESTINATION" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">VESSEL</font>
                          </strong>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="VESSEL" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              CONTAINER
                              #
                            </font>
                          </strong>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>

                      <tr>
                        <td>
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              MOTHER
                              VESSEL
                            </font>
                          </strong>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="MOTHERVSL" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td height="2" valign="top">
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <strong>
                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                  TRANSHIPMENT
                                  VESSEL
                                </font>
                              </strong>
                            </font>
                          </b>
                        </td>
                        <td height="2">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="TRANSVSL" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                    </xsl:if>
                    <xsl:if test="$Mode='a'">
                      <tr>
                        <tr>
                          <td width="18%">
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                MAWB
                              </font>
                            </strong>
                          </td>
                          <td width="34%">
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="MAWBNO" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                AIRPORT DEP
                              </font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="SENTFROM" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                AIR LINE
                              </font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="AIRLINE" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                AIRPORT ARR
                              </font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="DESTINATION" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </tr>
                      </tr>
                    </xsl:if>
                    <tr>
                      <td>
                        <strong>
                          <b>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Freight</font>
                          </b>
                        </strong>
                      </td>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="FREIGHT" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td height="2" valign="top">
                        <b></b>
                      </td>
                      <td height="2"></td>
                    </tr>
                  </table>
                </td>
                <tr>
                  <td>
                    <div align="center">
                      <font size="3" face="Arial">
                        <strong>ARRIVEE</strong>
                      </font>
                    </div>
                  </td>
                </tr>
              </tr>
              <tr>
                <td>
                  <table width="100%" border="1" cellspacing="1" cellpadding="3">
                    <tr>
                      <td width="5%" rowspan="3"> </td>
                      <xsl:if test="$Mode='a'">
                        <td width="10%">
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              FLT NO
                            </font>
                          </strong>
                        </td>
                        <td colspan="3">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="ACTUALFLIGHTNO" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </xsl:if>
                      <xsl:if test="$Mode='s'">
                        <td width="10%">
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              VOLUME
                            </font>
                          </strong>
                        </td>
                        <td colspan="3">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </xsl:if>
                      <td width="12%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">COLIS</font>
                        </strong>
                      </td>
                      <td colspan="3">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="NOOFPKGS" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">E.T.D.</font>
                        </strong>
                      </td>
                      <td width="24%">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:if test="$Mode='a'">
                            <xsl:value-of select="FLIGHTDAT" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </xsl:if>
                          <xsl:if test="$Mode='s'">
                            <xsl:value-of select="ETD" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </xsl:if>
                        </font>
                      </td>
                      <td width="7%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">E.T.A.</font>
                        </strong>
                      </td>
                      <td width="12%">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="ETA" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td>
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">POIDS</font>
                        </strong>
                      </td>
                      <td colspan="3">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <xsl:if test="$Mode='a'">
                      <tr>
                        <td>
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">D/D</font>
                          </strong>
                        </td>
                        <td colspan="3">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="DOUANENO" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">M3</font>
                          </strong>
                        </td>
                        <td width="7%">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td width="10%">
                          <strong>
                            <font face="Verdana, Arial, Helvetica, sans-serif">Chbl.Wt.</font>
                          </strong>
                        </td>
                        <td width="7%">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="CHBLWT" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                    </xsl:if>
                  </table>
                </td>
              </tr>
              <tr>
                <td>
                  <div align="center">
                    <font size="3" face="Arial">
                      <strong> CARGO MANIFEST</strong>
                    </font>
                  </div>
                </td>
              </tr>
              <tr>
                <td height="59">
                  <table width="100%" border="1" cellspacing="1" cellpadding="2">
                    <tr>
                      <td width="5%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            JOB NO.
                          </font>
                        </strong>
                      </td>
                      <xsl:if test="$Mode='a'">
                        <td width="5%">
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                             HAWB NO.
                            </font>
                          </strong>
                        </td>
                      </xsl:if>
                      <xsl:if test="$Mode='s'">
                        <td width="5%">
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              HBL NO.
                            </font>
                          </strong>
                        </td>
                      </xsl:if>
                      <td width="15%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            SHPR
                          </font>
                        </strong>
                      </td>
                      <td width="15%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CNEE</font>
                        </strong>
                      </td>
                      <td width="11%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">P/O</font>
                        </strong>
                      </td>
                      <td width="8%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            PCS
                          </font>
                        </strong>
                      </td>
                      <td width="8%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CTNS</font>
                        </strong>
                      </td>
                      <td width="8%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">PDS</font>
                        </strong>
                      </td>
                      <td width="8%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">VOL</font>
                        </strong>
                      </td>
                      <xsl:if test="$Mode='a'">
                        <td width="5%">
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              WEB
                            </font>
                          </strong>
                        </td>
                      </xsl:if>
                    </tr>
                    <xsl:for-each select="//NewDataSet/Table2">
                      <tr>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="JOBNO" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="HAWBNO" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="SHPR" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="IMPR" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="ORDERNO" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>

                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="NOOFPCS" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="NOOFPKG" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                        <xsl:if test="$Mode='a'">
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </xsl:if>
                      </tr>
                    </xsl:for-each>
                  </table>
                </td>
              </tr>
              <xsl:if test="$Mode='s'">
                <tr>
                  <td>
                    <div align="center">
                      <font size="3" face="Arial">
                        <strong>LIVRAISON</strong>
                      </font>
                    </div>
                  </td>
                </tr>
                <tr>
                  <td>
                    <table width="66%" border="1" cellspacing="1" cellpadding="3">
                      <tr>
                        <td width="9%" rowspan="2"></td>
                        <td width="17%">
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              L.E
                            </font>
                          </strong>
                        </td>
                        <td width="74%">
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <strong>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CHEZ</font>
                          </strong>
                        </td>
                        <td>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </font>
                        </td>
                      </tr>
                    </table>
                  </td>
                </tr>                
              </xsl:if>
              <tr>
                <td>
                  <div align="center">
                    <font size="3" face="Arial">
                      <strong>OBSERVATIONS</strong>
                    </font>
                  </div>
                </td>
              </tr>
              <tr>                 
                <td>
                  <table width="100%" height="180" border="1" cellpadding="3" cellspacing="1">
                    <tr>
                      <td width="100%" height="176">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                          <tr>
                            <td height="172" valign="top">
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                <xsl:value-of select="$REMARK" disable-output-escaping="yes"/>
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                              </font>
                            </td>
                          </tr>

                          <tr>
                            <td>
                              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                  <td width="50%" height="21">
                                    <table width="50%" border="1" cellspacing="1" cellpadding="2">
                                      <tr>
                                        <td colspan="2">
                                          <strong>
                                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">WEB</font>
                                          </strong>
                                        </td>
                                      </tr>
                                      <tr>
                                        <td width="38%">
                                          <strong>
                                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">ARV</font>
                                          </strong>
                                        </td>
                                        <td width="62%">
                                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                        </td>
                                      </tr>
                                      <tr>
                                        <td>
                                          <strong>
                                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">DLV</font>
                                          </strong>
                                        </td>
                                        <td>
                                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                  <td width="50%" align="right">
                                    <div aligh="right">
                                      <xsl:if test="$Mode='s'">

                                        <table width="50%" border="1" align="right" cellpadding="2" cellspacing="1">
                                          <tr>
                                            <td colspan="2">
                                              <div align="center">
                                                <strong>
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                                    Exchange
                                                    Rate
                                                  </font>
                                                </strong>
                                              </div>
                                            </td>
                                          </tr>
                                          <tr>
                                            <td width="38%">
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Buy</font>
                                              </strong>
                                            </td>
                                            <td width="62%">
                                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                            </td>
                                          </tr>
                                          <tr>
                                            <td>
                                              <strong>
                                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">Sell</font>
                                              </strong>
                                            </td>
                                            <td>
                                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                            </td>
                                          </tr>
                                        </table>
                                      </xsl:if>
                                      <xsl:if test="$Mode='a'">
                                        <table width="50%" border="1" align="right" cellpadding="2" cellspacing="1">
                                          <tr>
                                            <td colspan="2">
                                              <div align="center">
                                                <strong>
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">TAUX</font>
                                                </strong>
                                              </div>
                                            </td>
                                          </tr>
                                          <tr>
                                            <td width="38%">
                                              <div align="center">
                                                <strong>
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">A</font>
                                                </strong>
                                              </div>
                                            </td>
                                            <td width="62%">
                                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                            </td>
                                          </tr>
                                          <tr>
                                            <td>
                                              <div align="center">
                                                <strong>
                                                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">V</font>
                                                </strong>
                                              </div>
                                            </td>
                                            <td>
                                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                            </td>
                                          </tr>
                                        </table>
                                      </xsl:if>
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
            </xsl:for-each>
          </table>          
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
