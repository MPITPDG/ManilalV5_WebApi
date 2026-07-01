<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <table border='0' cellpadding='0' cellspacing='0' width='711px' class="subTbl">
      <xsl:for-each select="//NewDataSet/Table">
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
                  <xsl:value-of select="HAWBNO" />
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
                    <xsl:for-each select="//NewDataSet/Table1">
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
                    <xsl:for-each select="//NewDataSet/Table2">
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
                    <xsl:for-each select="//NewDataSet/Table3">
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
                              <label onclick="javascript:return fnClick_DelNo('{DELIVERYNO}')">
                                <xsl:value-of select="DELIVERYNO" />
                              </label>
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
                              <xsl:for-each select="//NewDataSet/Table4">
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
    </table>
  </xsl:template>
</xsl:stylesheet>