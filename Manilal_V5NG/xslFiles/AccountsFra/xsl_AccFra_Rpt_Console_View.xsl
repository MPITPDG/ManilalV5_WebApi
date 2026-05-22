<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <table border='0' cellpadding='1' cellspacing='1' width='711px' class="subTbl">
      <xsl:for-each select="//NewDataSet/Table">
        <xsl:variable name="ID" select="CONSOLENO"></xsl:variable>
        <xsl:variable name="IMPORTED" select="IMPORTED"></xsl:variable>
        <xsl:if test="IMPORTED='Y'">
          <tr>
            <td colspan='4' class='HiLight_Yellow'>
              DATA IS DIRECTLY IMPORTED FROM INDIA
            </td>
          </tr>
        </xsl:if>
        <tr>
          <td colspan='4' class='trHeader'>
            <IMG border="0" alt="expand/collapse section" child="src{$ID}" name="{CONSOLENO}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            GENERAL DETAILS:
          </td>
        </tr>
        <tr class="expanded" id="src{$ID}">
          <td colspan='4'>
            <table border='0' cellpadding='0' cellspacing='0' width='705px'>
              <tr>
                <td class='tdHeaderLeft' width='165px'>
                  Console No. :
                </td>
                <td class='tdNormal' width='200px'>
                  <xsl:value-of select="$ID" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class='tdHeader' width='135px'>
                  Mode :
                </td>
                <td class='tdNormalRight' width='200px'>
                  <xsl:value-of select="MODE_VALUE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr>
                <td class='tdHeaderLeft'>
                  Date :
                </td>
                <td class='tdNormal'>
                  <xsl:value-of select="CONSOLEDT" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class='tdHeader'>
                  Agent :
                </td>
                <td class='tdNormalRight'>
                  <xsl:value-of select="AGENT_NAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr>
                <td class='tdHeaderLeft'>
                  Consolidation Sent From :
                </td>
                <td class='tdNormal'>
                  <xsl:value-of select="SENT_FROM_CITY" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class='tdHeader'>
                  Destination :
                </td>
                <td class='tdNormalRight'>
                  <xsl:value-of select="DESTINATION" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <xsl:if test="MODE_VALUE='SEA'">
          <tr>
            <td colspan='4' class='trHeader'>
              <IMG border="0" alt="expand/collapse section" child="vsl{$ID}" name="{CONSOLENO}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              VESSEL DETAILS:
            </td>
          </tr>
          <tr class="expanded" id="vsl{$ID}">
            <td colspan='4'>
              <table border='0' cellpadding='0' cellspacing='0' width='705px'>
                <tr>
                  <td class='tdHeaderLeft' width='165px'>
                    Shipping Line :
                  </td>
                  <td class='tdNormal' width='200px'>
                    <xsl:value-of select="SHIPLINE_NAME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader' width='135px'>
                    Vessel :
                  </td>
                  <td class='tdNormalRight' width='200px'>
                    <xsl:value-of select="VESSELNAME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr>
                  <td class='tdHeaderLeft'>
                    Sailed On :
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="VESSELETD" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader'>
                    Voyage :
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:value-of select="VOYAGE" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr>
                  <td class='tdHeaderLeft'>
                    M B/L No. :
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="MBLNO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader'>
                    Date :
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:value-of select="MBLDT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
        </xsl:if>
        <xsl:if test="MODE_VALUE='AIR'">
          <tr>
            <td colspan='4' class='trHeader'>
              <IMG border="0" alt="expand/collapse section" child="air{$ID}" name="{CONSOLENO}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              AIRLINE DETAILS:
            </td>
          </tr>
          <tr class="expanded" id="air{$ID}">
            <td colspan='4'>
              <table border='0' cellpadding='0' cellspacing='0' width='705px'>
                <tr>
                  <td class='tdHeaderLeft' width='165px'>
                    Planned Flight No :
                  </td>
                  <td class='tdNormal' width='200px'>
                    <xsl:value-of select="FLIGHTNO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader' width='135px'>
                    Date :
                  </td>
                  <td class='tdNormalRight' width='200px'>
                    <xsl:value-of select="FLIGHTDT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr>
                  <td class='tdHeaderLeft'>
                    Actual Flight No :
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="ACTUALFLIGHTNO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader'>
                    Date :
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:value-of select="ACTUALFLIGHTDT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr>
                  <td class='tdHeaderLeft'>
                    MAWB No :
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="MAWBNO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader'>
                    Date :
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:value-of select="MAWBDT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr>
                  <td class='tdHeaderLeft'>
                    DOSSIER/D :
                  </td>
                  <td colspan='3' class='tdNormalRight'>
                    <xsl:value-of select="DDMSG" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
        </xsl:if>
        <tr>
          <td class='trHeader' colspan='4'>
            <IMG border="0" alt="expand/collapse section" child="other{$ID}" name="{CONSOLENO}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            OTHER DETAILS:
          </td>
        </tr>
        <tr class="expanded" id="other{$ID}">
          <td colspan='4'>
            <table border='0' cellpadding='0' cellspacing='0' width='705px'>
              <tr>
                <td class='tdHeaderLeft'>
                  By :
                </td>
                <td colspan='3' class='tdNormalRight'>
                  <xsl:value-of select="TRANSPORTBY_NAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr>
                <td class='tdHeaderLeft'>
                  Transporter :
                </td>
                <td colspan='3' class='tdNormalRight'>
                  <xsl:value-of select="TRANSPORTER_VALUE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr>
                <td class='tdHeaderLeft' width='165px'>
                  Cargo Note number :
                </td>
                <td class='tdNormal' width='200px'>
                  <xsl:value-of select="CARGONOTE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>

                </td>
                <td class='tdHeader' width='135px'>
                  Date :
                </td>
                <td class='tdNormalRight' width='200px'>
                  <xsl:value-of select="CARGONOTEDT" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>

                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td class='trHeader' colspan='4'>
            <IMG border="0" alt="expand/collapse section" child="goods{$ID}" name="{CONSOLENO}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            GOOD DETAILS:
          </td>
        </tr>
        <tr class="expanded" id="goods{$ID}">
          <td colspan='4'>
            <table border='0' cellpadding='0' cellspacing='0' width='705px'>
              <tr>
                <td class='tdHeaderLeft' width='165px'>
                  Packages :
                </td>
                <td class='tdNormal' width='200px'>
                  <xsl:value-of select="NOOFPKGS" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class='tdHeader' width='135px'>
                  Type of pkgs:
                </td>
                <td class='tdNormalRight' width='200px'>
                  <xsl:value-of select="TYPEOFPKGS" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr>
                <td class='tdHeaderLeft'>
                  Weight Kgs :
                </td>
                <td class='tdNormal'>
                  <xsl:value-of select="WEIGHT" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class='tdHeader'>
                  Volume:
                </td>
                <td class='tdNormalRight'>
                  <xsl:value-of select="VOLUME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <xsl:if test="MODE_VALUE='AIR'">
                <tr>
                  <td class='tdHeaderLeft'>
                    CHBL WT.:
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="CHBLWT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader'>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
              </xsl:if>
              <tr>
                <td class='tdHeaderLeft'>
                  ETA :
                </td>
                <td class='tdNormal'>
                  <xsl:value-of select="ETA" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class='tdHeader'>
                  VIA :
                </td>
                <td class='tdNormalRight'>
                  <xsl:value-of select="TRANS" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr>
                <td class='tdHeaderLeft'>
                  House B/L Issued :
                </td>
                <td class='tdNormal'>
                  <xsl:value-of select="BL" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class='tdHeader'>
                  Freight :
                </td>
                <td class='tdNormalRight'>
                  <xsl:value-of select="FREIGHT" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr>
                <td class='tdHeaderLeft'>
                  REMARK:
                </td>
                <td class='tdNormalRight' colspan='3'>
                  <xsl:value-of select="CONSOLEREMARK" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <xsl:if test="MODE_VALUE='SEA'">
          <tr>
            <td colspan='4' class='trHeader'>
              <IMG border="0" alt="expand/collapse section" child="cont{$ID}" name="{CONSOLENO}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              CONTAINER DETAILS: (SINGLE SHIPPER) SINGLESHPR
            </td>
          </tr>
          <tr class="expanded" id="cont{$ID}">
            <td colspan='4'>
              <table border='0' cellpadding='0' cellspacing='0' width='705px'>
                <tr>
                  <td class='tdHeaderLeft' width='165px'>
                    CONTAINER NO.
                  </td>
                  <td class='tdHeader' width='200px'>
s                    Quai D'enlevement
                  </td>
                  <td class='tdHeader' width='135px'>
                    Quai De Restitution
                  </td>
                  <td class='tdHeader' width='200px'>
                    Last free date
                  </td>
                </tr>
                <xsl:for-each select="//NewDataSet/Table1">
                  <tr>
                    <td class='tdNormalLeft'>
                      <xsl:value-of select="CONTAINERNO" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class='tdNormal'>
                      <xsl:value-of select="ENLEVEMENT" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class='tdNormal'>
                      <xsl:value-of select="RESTITUTION" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class='tdNormalRight'>
                      <xsl:value-of select="FREEDATE" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                  </tr>
                </xsl:for-each>
              </table>
            </td>
          </tr>
        </xsl:if>
        <xsl:for-each select="//NewDataSet/Table2">
          <xsl:variable name="JOBID" select="JOBNO"></xsl:variable>
          <tr>
            <td colspan='4' class='pageHeader' style='text-align: left;'>
              <IMG border="0" alt="expand/collapse section" child="main{$JOBID}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              VIEW JOB DETAILS
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              <xsl:value-of select="JOBNO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              <span class="linkLable">[PRINT DOSSIER]</span>
            </td>
          </tr>
          <tr class="expanded" id="main{$JOBID}">
            <td colspan='4'>
              <table border='0' cellpadding='0' cellspacing='0' width='705px'>
                <tr>
                  <td class='tdHeaderLeft' width='165px'>
                    JOB NO :
                  </td>
                  <td class='tdNormal' width='200px'>
                    <xsl:value-of select="JOBNO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader' width='135px'>
                    INCOTERM :
                  </td>
                  <td class='tdNormalRight' width='200px'>
                    <xsl:value-of select="INCOTERM" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr>
                  <td class='tdHeaderLeft'>
                    <xsl:choose>
                      <xsl:when test="MODE_VALUE='SEA'">
                        HBL NO. :
                      </xsl:when>
                      <xsl:otherwise>
                        HAWB NO. :
                      </xsl:otherwise>
                    </xsl:choose>
                  </td>
                  <td class='tdNormal'>
                    <xsl:choose>
                      <xsl:when test="$IMPORTED='Y'">
                        <span class="linkLable">
                          <xsl:value-of select="HAWBNO" />
                        </span>
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:value-of select="HAWBNO" />
                      </xsl:otherwise>
                    </xsl:choose>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader'>
                    DATE :
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:value-of select="HAWBDT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    HAWBDT
                  </td>
                </tr>
                <tr>
                  <td class='tdHeaderLeft'>
                    SHIPPER :
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="SHIPPER" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    SHIPPER
                  </td>
                  <td class='tdHeader'>
                    IMPORTER :
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:value-of select="IMPORTER_NAME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    IMPORTER_NAME
                  </td>
                </tr>
                <tr>
                  <td class='tdHeaderLeft'>
                    DESTINATION :
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="DESTINATION_CITY" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader'>
                    PKGS :
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:value-of select="NOOFPKGS" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr>
                  <td class='tdHeaderLeft'>
                    WEIGHT :
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="WEIGHT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader'>
                    VOLUME :
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:value-of select="VOLUME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <xsl:if test="MODE_VALUE='AIR'">
                  <tr>
                    <td class='tdHeaderLeft'>
                      CHBLWT :
                    </td>
                    <td class='tdNormal'>
                      <xsl:value-of select="CHBLWT" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class='tdHeader'>
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class='tdNormalRight'>
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                  </tr>
                </xsl:if>
                <tr>
                  <td class='tdHeaderLeft'>
                    ACTUAL ARRIVAL :
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="ACTUALARRIVALDT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader'>
                    FREIGHT
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:value-of select="FREIGHT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>

                </tr>
                <tr>
                  <td colspan='4' class='trHeader'>
                    <IMG border="0" alt="expand/collapse section" child="order{$JOBID}" name="{CONSOLENO}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    ORDER DETAILS:
                  </td>
                </tr>
                <tr class="expanded" id="order{$JOBID}">
                  <td colspan='4'>
                    <table border='0' cellpadding='0' cellspacing='0' width='705px'>
                      <tr>
                        <td class='tdHeaderLeft' width='165px'>
                          Importer's Reference
                        </td>
                        <td class='tdHeader' width='200px'>
                          Pieces
                        </td>
                        <td class='tdHeader' width='135px'>
                          Type of Pieces
                        </td>
                        <td class='tdHeader' width='200px'>
                          LSD (Last date of shiment)
                        </td>
                      </tr>
                      <xsl:for-each select="//NewDataSet/Table3">
                        <xsl:if test="FK_JOB_ORDER=$JOBID">
                          <tr>
                            <td class='tdNormalLeft'>
                              <xsl:value-of select="IMPORTERS_REFERENCE" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class='tdNormal'>
                              <xsl:value-of select="PIECES" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class='tdNormal'>
                              <xsl:value-of select="TYPE_OF_PIECES" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class='tdNormalRight'>
                              <xsl:value-of select="LSD" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                          </tr>
                        </xsl:if>
                      </xsl:for-each>
                    </table>
                  </td>
                </tr>
                <tr>
                  <td colspan='4' class='trHeader'>
                    <IMG border="0" alt="expand/collapse section" child="desc{$JOBID}" name="{CONSOLENO}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    DESTINATION DOCUMENTS
                  </td>
                </tr>
                <tr class="expanded" id="desc{$JOBID}">
                  <td colspan='4'>
                    <table border='0' cellpadding='0' cellspacing='0' width='705px'>
                      <tr>
                        <td class='tdHeaderLeft' width='165px'>
                          EXPORT NO - NO OF PKGS
                        </td>
                        <td class='tdHeader' width='200px'>
                          SR. NO.
                        </td>
                        <td class='tdHeader' width='135px'>
                          LIST OF DOCUMENTS
                        </td>
                        <td class='tdHeader' width='200px'>
                          RECD. Date
                        </td>
                      </tr>
                      <xsl:for-each select="//NewDataSet/Table4">
                        <xsl:if test="FK_JOB_DOCUMENT=$JOBID">
                          <tr>
                            <td class='tdNormalLeft'>
                              <xsl:value-of select="EXPT_NOOFPKGS" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class='tdNormal'>
                              <xsl:value-of select="SRNO" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class='tdNormal'>
                              <xsl:value-of select="DOCUMENT" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class='tdNormalRight'>
                              <xsl:value-of select="RECDDT" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                          </tr>
                        </xsl:if>
                      </xsl:for-each>
                    </table>
                  </td>
                </tr>
                <tr>
                  <td colspan='4' class='trHeader'>
                    <IMG border="0" alt="expand/collapse section" child="del{$JOBID}" name="{CONSOLENO}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    ACTUAL DELIVERY
                  </td>
                </tr>
                <tr class="expanded" id="del{$JOBID}">
                  <td colspan='4'>
                    <table border='0' cellpadding='0' cellspacing='0' width='705px'>
                      <tr>
                        <td class='tdHeaderLeft' width='165px'>
                          Sr. No.
                        </td>
                        <td class='tdHeader' width='200px'>
                          Delivery No.
                        </td>
                        <td class='tdHeader' width='135px'>
                          Actual Delivery Date
                        </td>
                        <td class='tdHeader' width='200px'>
                          Packages
                        </td>
                      </tr>
                      <xsl:for-each select="//NewDataSet/Table5">
                        <xsl:if test="FK_JOB_DELIVERY=$JOBID">
                          <xsl:variable name="DELIVERYID" select="DELIVERYNO"></xsl:variable>
                          <tr>
                            <td class='tdNormalLeft'>
                              <IMG border="0" alt="expand/collapse section" child="job{FK_JOB_DELIVERY}{$DELIVERYID}" name="{CONSOLENO}" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                              <xsl:value-of select="SRNO" />
                            </td>
                            <td class='tdNormal'>
                              <span class='linkLable'>
                              <xsl:value-of select="DELIVERYNO" />
                              </span>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class='tdNormal'>
                              <xsl:value-of select="ACTUALDTTIME" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class='tdNormalRight'>
                              <xsl:value-of select="PKGS" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                          </tr>
                          <tr class="expanded" id="job{FK_JOB_DELIVERY}{$DELIVERYID}">
                            <td colspan='4'>
                              <table border='0' cellpadding='0' cellspacing='0' width='705px'>
                                <tr>
                                  <td class='tdHeaderLeft' width='165px'>
                                    APPOINTMENT
                                  </td>
                                  <td class='tdHeader' width='200px'>
                                    DATE
                                  </td>
                                  <td class='tdHeader' width='135px'>
                                    TIME
                                  </td>
                                  <td class='tdHeader' width='200px'>
                                    REMARK
                                  </td>
                                </tr>
                                <xsl:for-each select="//NewDataSet/Table6">
                                  <xsl:if test="FK_DELIVERY=$DELIVERYID">
                                    <tr>
                                      <td class='tdNormalLeft' width='165px'>
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                      <td class='tdNormal' width='200px'>
                                        <xsl:value-of select="APPTDT" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                      <td class='tdNormal' width='135px'>
                                        <xsl:value-of select="APPTTIME" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                      <td class='tdNormalRight' width='200px'>
                                        <xsl:value-of select="APPTRMRK" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                    </tr>
                                  </xsl:if>
                                </xsl:for-each>
                              </table>
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
  </xsl:template>
</xsl:stylesheet>