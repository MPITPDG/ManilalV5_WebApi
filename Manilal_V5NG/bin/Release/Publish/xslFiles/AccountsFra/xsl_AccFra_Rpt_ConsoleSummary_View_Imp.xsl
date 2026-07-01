<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet.css" type="text/css" rel="stylesheet" />
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
        <div id="tableContainer" class="divSpace" style="width:770px" >
          <input type="hidden" runat="server" id="hdConsoleID" />
          <input type="hidden" runat="server" id="hdPrevID" />
          <input type="hidden" runat="server" id="hdCurrentID" />
          <table cellpadding="0" cellspacing="0" width="750px" border="0" bordercolor="white" class="infotable">
            <xsl:for-each select="//NewDataSet/Table">
              <xsl:variable name="MODE" select="MODE"></xsl:variable>
              <tr class="DataGridFixedHeader">
                <td colspan="2" class="header">
                  Job No
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
              <xsl:for-each select="//NewDataSet/Table6">
                <xsl:variable name="ID_JOB" select="JOBNO"></xsl:variable>
                <tr class="formHeading">
                  <td class="summaryDetail" width="10px">
                    <xsl:if test="JOBNO!='TOTAL'">
                      <IMG border="0" alt="expand/collapse section" id="job{JOBNO}p" child="job{JOBNO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                    </xsl:if>
                  </td>
                  <td class="summaryDetail" width="120px">
                    <xsl:choose>
                      <xsl:when test="JOBNO!='TOTAL'">
                        <label style="color: #0000FF;text-decoration:underline;cursor:hand;width:80px" onclick="javascript:return parent.fnClick_JobNo('{CONSOLENO_JOB}','{JOBNO}')">
                          <xsl:value-of select="JOBNO" />
                        </label>[<xsl:value-of select="FREIGHT" />]
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:value-of select="JOBNO" />
                      </xsl:otherwise>
                    </xsl:choose>
                  </td>
                  <td class="summaryDetail" width="60">
                    <xsl:value-of select="VOLUME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetailImp" width="150">
                    <xsl:value-of select="IMPORTER_NAME" disable-output-escaping ="yes"/>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail" width="80px" style="text-align:right">
                    <xsl:value-of select="PAYMENT_EURO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail" width="80px" style="text-align:right">
                    <xsl:value-of select="RECOVERY_EURO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail" width="80px" style="text-align:right">
                    <xsl:value-of select="DIFF_EURO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail" width="80px">
                    <xsl:value-of select="SENTFROM" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail" width="120px">
                    <xsl:value-of select="DESTINATION" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <xsl:if test="JOBNO!='TOTAL'">
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
                          <xsl:if test="JOBNO_JS=$ID_JOB">
                            <tr>
                              <td class="summaryDetail">
                                <xsl:value-of select="VOUCHER_NO" disable-output-escaping="yes"/>
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
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
            </xsl:for-each>
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>