<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" >
        <table width="100%" border="0" align="center" cellpadding="2" cellspacing="2">
          <tr>
            <td>
              <div align="center">
                <strong>
                  <font size="5" face="verdana">
                    <u>
                      M P CARGO  FRANCE
                    </u>
                  </font>
                </strong>
              </div>
            </td>
          </tr>
          <tr>
            <td>
              <div align="center">
                <strong>
                  <font size="3" face="vardana">
                    LILLE LESQUIN
                  </font>
                </strong>
              </div>
            </td>
          </tr>
        </table>
        <table width="100%" border="1" cellspacing="3" cellpadding="3">
          <xsl:for-each select="//NewDataSet/Table">
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
            <xsl:for-each select="//NewDataSet/Table1">
              <tr>
                <td height="93">
                  <table width="100%" border="1" cellspacing="1" cellpadding="3">
                    <tr>
                      <td width="15%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">INCOTERM</font>
                        </strong>
                      </td>
                      <td width="39%">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="INCOTERM" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td width="14%">
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            N
                            DOSSIER
                          </font>
                        </strong>
                      </td>
                      <td width="32%">
                        <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                          <strong>
                            <xsl:value-of select="JOBNO" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </strong>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">SHIPPER</font>
                        </strong>
                      </td>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="SHPR" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td>
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">AGENT</font>
                        </strong>
                      </td>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="AGT_NAME" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <strong>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CONSIGNEE</font>
                        </strong>
                      </td>
                      <td>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="IMPR" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                      <td height="2" valign="top">
                        <b>
                          <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                            Freight
                          </font>
                        </b>
                      </td>
                      <td height="2">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="FREIGHT" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
              <tr>
                <td>
                  <div align="center">
                    <font size="3" face="Arial">
                      <strong>ARRIVEE</strong>
                    </font>
                  </div>
                </td>
              </tr>
              <tr>
                <td>
                  <table width="100%" border="1" cellspacing="1" cellpadding="3">
                    <tr>
                      <td width="6%" rowspan="9"> </td>
                      <xsl:if test="$Mode='s'">
                        <tr>
                          <td width="11%">
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                N B/L
                              </font>
                            </strong>
                          </td>
                          <td width="37%">
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="MBLNO" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          <td width="14%">
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                MBL
                              </font>
                            </strong>
                          </td>
                          <td width="32%">
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="HAWBNO" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">P.O.L.</font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <strong>
                                <xsl:value-of select="POL" disable-output-escaping="yes"/>
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                              </strong>
                            </font>
                          </td>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                NB
                                COLIS
                              </font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="NOOFPKG" disable-output-escaping="yes"/>
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
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="ETD" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">POIDS</font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CIE</font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="CIE" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">VOL</font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">E.T.A.</font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="ETA" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">NATURE</font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">P.O.D.</font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <strong>
                                <xsl:value-of select="ORDERNO" disable-output-escaping="yes"/>
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                              </strong>
                            </font>
                          </td>
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">REF</font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="ORDERNO" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </tr>
                      
                        <tr>
                          <xsl:if test="$Mode='s'">
                          <td>
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                FCR
                              </font>
                            </strong>
                          </td>
                          <td>
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          </xsl:if>

                          <xsl:if test="$Mode='a'">
                          <td rowspan="2">
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">	D/D</font>
                            </strong>
                          </td>
                          <td rowspan="2">
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                          </xsl:if>
                          <td rowspan="2">
                            <strong>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">AUTRES</font>
                            </strong>
                          </td>
                          <td rowspan="2">
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text> 
                            </font>
                          </td>
                        </tr>
                        <xsl:if test="$Mode='s'">
                          <tr>
                            <td>
                              <strong>
                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                  Navire
                                </font>
                              </strong>
                            </td>
                            <td rowspan="2">
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">                                
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
                                <xsl:value-of select="MOTH_VESSEL" disable-output-escaping="yes"/>
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                              </font> 
                            </td>
                            <td>
                              <strong>
                                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                  TRANS.
                                  VESSEL
                                </font>
                              </strong>
                            </td>
                            <td>
                              <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                                <xsl:value-of select="TRANS_VESSEL" disable-output-escaping="yes"/>
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                              </font> 
                            </td>
                          </tr>
                        </xsl:if>                       
                      </xsl:if>
                    </tr>

                  </table>
                </td>
              </tr>
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
                      <td width="9%" rowspan="2">
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
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
                  <table width="100%" height="186" border="1" cellpadding="3" cellspacing="1">
                    <tr>
                      <td width="6%">
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td width="94%">
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </xsl:for-each>
          </xsl:for-each>
        </table>
        <!--<table border='0' cellpadding='1' cellspacing='1' width='750px'>
						 
							 
							<xsl:if test="$Mode='s'">
								<tr>
									<td class="lblNormal_xslt" width="50px"  >
										Navire
									</td>
									<td class="summaryDetail_xslt"   colspan="3">
									 
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_xslt" width="100px"  >
										Mother Vessel
									</td>
									<td class="summaryDetail_xslt"    >
										<xsl:value-of select="MOTH_VESSEL" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="lblNormal_xslt" width="100px"  >
										Trans Vessel
									</td>
									<td class="summaryDetail_xslt"    >
										<xsl:value-of select="TRANS_VESSEL" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
							</xsl:if>
						</xsl:for-each>
					 
							<tr class="DataGridHeader_xslt">
								<td colspan ='4' class="header">
									LIVRAISON
								</td>
							</tr>
							<tr>
							 
								<td colspan ='4'>
									<table width="100%" border="0" cellspacing="0" cellpadding="3">
										<tr>
											<td  width="9" class="lblNormal_xslt"  rowspan="4">
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<tr>
											<td  width="30"   class="lblNormal_xslt">
												L.E
											</td>
											<td   class="lblNormal_xslt">
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<tr>
											<td width="30"  class="lblNormal_xslt">
												CHEZ
											</td>
											<td class="summaryDetail_xslt">
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr class="DataGridHeader_xslt">
								<td colspan ='4' class="header">
									OBSERVATIONS
								</td>
							</tr>
							<tr>
								<td class="summaryDetail_xslt" colspan="6" height="50px"  >
									<xsl:value-of select="REMARK" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
					
					 

					</table>-->

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
