<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
        <style>
          .expanded
          {
          color: black
          }
          .collapsed
          {
          DISPLAY: none
          }
        </style>
        <script language="javascript">
          function outliner () {
          oMe = window.event.srcElement
          //get child element
          var child = document.all[event.srcElement.getAttribute("child",false)];
          //if child element exists, expand or collapse it.
          if (null != child)
          {
          child.className = child.className == "collapsed" ? "expanded" : "collapsed";
          }
          }

          function changepic() {
          uMe = window.event.srcElement;
          var check = uMe.src.toLowerCase();
          if(check.lastIndexOf("img_plus.gif") != -1)
          uMe.src = "../../include/img/img_Minus.gif"
          else
          uMe.src = "../../include/img/img_Plus.gif"
          }
          function fnClickNo(No)
          {
          parent.fnClick_ConsoleNo(No)
          return false;
          }
        </script>
      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" onclick="outliner();">
        <div id="tableContainer" class="divSpace" style="width:100%" >
          <input type="hidden" runat="server" id="hdConsoleID" />
          <input type="hidden" runat="server" id="hdPrevID" />
          <input type="hidden" runat="server" id="hdCurrentID" />
          <table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
            <xsl:for-each select="//NewDataSet/Table">
              <xsl:variable name="MODE" select="MODE"></xsl:variable>
              <tr class="DataGridFixedHeader">
                <td colspan="3" class="header">
                  Console NR/Job No
                </td>
                <td class="header">
                  <xsl:choose>
                    <xsl:when test="$MODE='A'">
                      Chbl.Wt.
                    </xsl:when>
                    <xsl:otherwise>
                      Volume
                    </xsl:otherwise>
                  </xsl:choose>
                </td>
                <td class="header">
                  Importer
                </td>
                <td class="header">
                  Payment
                </td>
                <td class="header">
                  Recovery
                </td>
                <td class="header">
                  Diff Euro
                </td>
                <td>
                  Origin
                </td>
                <td>
                  Destination
                </td>
              </tr>
              <tr height="0">
                <td width="10px">
                </td>
                <td width="10px">
                </td>
                <td width="120px">
                </td>
                <td width="60px">
                </td>
                <td width="150px">
                </td>
                <td width="80px">
                </td>
                <td width="80px">
                </td>
                <td width="80px">
                </td>
                <td width="80px">
                </td>
                <td width="120px">
                </td>
              </tr>
              <xsl:for-each select="//NewDataSet/Table1">
                <xsl:variable name="ID" select="CONSOLENO"></xsl:variable>
                <xsl:variable name="SENTFROM" select="SENTFROM"></xsl:variable>
                <tr>
                  <td class="summaryDetail">
                    <IMG border="0" alt="expand/collapse section" id="src{CONSOLENO}p" child="src{CONSOLENO}" name="{CONSOLENO}" class="expandable" height="11" onclick="changepic('{CONSOLENO}','c')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                  </td>
                  <td colspan="2" class="summaryDetail">
                    <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="return fnClickNo('{$ID}')">
                      <xsl:value-of select="$ID" />
                    </label>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="VOLUME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    Total
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="PAYMENT_EURO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="RECOVERY_EURO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="DIFF_EURO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="$SENTFROM" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="DESTINATION" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr>
                  <td>
                  </td>
                  <td colspan="9">
                    <table class="collapsed" bgcolor="#ffffff" id="src{CONSOLENO}" width="100%">
                      <tr class="formHeading">
                        <td width="10px" class="summaryDetail">
                          <IMG border="0" alt="expand/collapse section" id="con_sum{CONSOLENO}p" child="con_sum{CONSOLENO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                        </td>
                        <td colspan="8" width="730px" class="summaryDetail">
                          SUMMARY PROFIT Of CONSOLE
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          [<xsl:value-of select="$ID" />]
                        </td>
                      </tr>
                      <tr class="collapsed" bgcolor="#ffffff" id="con_sum{CONSOLENO}">
                        <td class="summaryDetail">
                        </td>
                        <td colspan="8" class="summaryDetail">
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr class="formHeading">
                              <td class="header">VOUCHER NO.</td>
                              <td class="header">DATE</td>
                              <td class="header">CHARGE TYPE</td>
                              <td class="header">PAYMENT EURO</td>
                              <td class="header">RECOVERY EURO</td>
                              <td class="header">DIFF EURO.</td>
                            </tr>
                            <xsl:for-each select="//NewDataSet/Table3">
								
                              <xsl:if test="$ID = CONSOLENO_CS">
                                <tr>
                                  <td class="summaryDetail">
									  <xsl:variable name="TRANS_T" select="TRANTYPE"></xsl:variable>									  
                                    <!--<xsl:value-of select="VOUCHER_NO" disable-output-escaping="yes" />-->
									  <xsl:if test="$TRANS_T = ''">
										  <xsl:value-of select="VOUCHER_NO" disable-output-escaping="yes" />
									  </xsl:if>
									  <xsl:if test="$TRANS_T != ''">
										  <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_Voucher('{VOUCHER_NO}','{TRANTYPE}')">
											  <xsl:value-of select="VOUCHER_NO" />
										  </label>
									  </xsl:if>
                                  </td>
                                  <td class="summaryDetail">
                                    <xsl:value-of select="TRAN_DATE" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </td>
                                  <td class="summaryDetail">
                                    <xsl:value-of select="CHRGDESC" disable-output-escaping="yes" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </td>
                                  <td class="summaryDetail">
                                    <xsl:value-of select="PAYMENT_EURO" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </td>
                                  <td class="summaryDetail">
                                    <xsl:value-of select="RECOVERY_EURO" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </td>
                                  <td class="summaryDetail">
                                    <xsl:value-of select="DIFF_EURO" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </td>
                                </tr>
                              </xsl:if>
                            </xsl:for-each>
                          </table>
                        </td>
                      </tr>
                      <xsl:for-each select="//NewDataSet/Table2">
                        <xsl:variable name="ID_JOB" select="JOBNO"></xsl:variable>
                        <xsl:if test="$ID = CONSOLENO_JOB">
                          <tr class="formHeading">
                            <td class="summaryDetail" width="10px">
                              <IMG border="0" alt="expand/collapse section" id="job{JOBNO}p" child="job{JOBNO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                            </td>
                            <td class="summaryDetail" width="120px">
                              <label style="color: #0000FF;text-decoration:underline;cursor:hand;width:80px" onclick="javascript:return parent.fnClick_JobNo('{$ID}','{JOBNO}')">
                                <xsl:value-of select="JOBNO" />
                              </label>[<xsl:value-of select="FREIGHT" />]
                            </td>
                            <td class="summaryDetail" width="60">
                              <xsl:value-of select="VOLUME" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetailImp" width="150">
                              <xsl:value-of select="IMPORTER_NAME" disable-output-escaping ="yes"/>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="80px">
                              <xsl:value-of select="PAYMENT_EURO" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="80px">
                              <xsl:value-of select="RECOVERY_EURO" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="80px">
                              <xsl:value-of select="DIFF_EURO" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="80px">
                              <xsl:value-of select="$SENTFROM" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="120px">
                              <xsl:value-of select="DESTINATION" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                          </tr>
                          <tr class="collapsed" bgcolor="#ffffff" id="job{JOBNO}">
                            <td class="summaryDetail">
                            </td>
                            <td colspan="8" class="summaryDetail">
                              <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr class="formHeading">
                                  <td class="header">VOUCHER NO.</td>
                                  <td class="header">DATE</td>
                                  <td class="header">CHARGE TYPE</td>
                                  <td class="header">PAYMENT EURO</td>
                                  <td class="header">RECOVERY EURO</td>
                                  <td class="header">DIFF EURO.</td>
                                </tr>
                                <xsl:for-each select="//NewDataSet/Table4">
									<xsl:variable name="TRANS_T" select="TRANTYPE"></xsl:variable>
                                  <xsl:if test="$ID = CONSOLENO_JS and JOBNO_JS=$ID_JOB">
                                    <tr>
                                      <td class="summaryDetail">
                                        <!--<xsl:value-of select="VOUCHER_NO" disable-output-escaping="yes"/>
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>-->
										  <xsl:if test="$TRANS_T = ''">
											  <xsl:value-of select="VOUCHER_NO" disable-output-escaping="yes"/>
											  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										  </xsl:if>
										  <xsl:if test="$TRANS_T != ''">
											  <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_Voucher('{VOUCHER_NO}','{TRANTYPE}')">
												  <xsl:value-of select="VOUCHER_NO" />
											  </label>
										  </xsl:if>
                                      </td>
                                      <td class="summaryDetail">
                                        <xsl:value-of select="TRAN_DATE" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                      <td class="summaryDetail">
                                        <xsl:value-of select="CHRGDESC" disable-output-escaping="yes"/>
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                      <td class="summaryDetail">
                                        <xsl:value-of select="PAYMENT_EURO" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                      <td class="summaryDetail">
                                        <xsl:value-of select="RECOVERY_EURO" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                      <td class="summaryDetail">
                                        <xsl:value-of select="DIFF_EURO" />
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
              </xsl:for-each>
            </xsl:for-each>
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>