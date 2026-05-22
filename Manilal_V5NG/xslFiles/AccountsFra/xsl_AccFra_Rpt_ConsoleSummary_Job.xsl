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
          child.className = child.className == "collapsed" ? "expanded" : "collapsed";
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
          <table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
            <xsl:for-each select="//NewDataSet/Table">
              <xsl:variable name="MODE" select="MODE"></xsl:variable>
              <tr class="DataGridFixedHeader">
                <td colspan="2" class="header">
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
                <td width="130px">
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
                <tr class="formHeading">
                  <td class="summaryDetail">
                    <IMG border="0" alt="expand/collapse section" child="src{$ID}" name="{CONSOLENO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                  </td>
                  <td class="summaryDetail">
                    <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="return fnClickNo('{$ID}')">
                      <xsl:value-of select="$ID" />
                    </label>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail" width="90">
                    <xsl:value-of select="VOLUME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail" width="150">
                    <!--xsl:value-of select="IMPORTER_NAME" disable-output-escaping="yes"/-->
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
                  <td colspan="9">
                    <table class="collapsed" bgcolor="#ffffff" id="src{$ID}" width="100%">
                      <xsl:for-each select="//NewDataSet/Table2">
                        <xsl:if test="$ID = CONSOLENO_JOB">
                          <tr>
                            <td width="10px">
                            </td>
                            <td class="summaryDetail" width="120px">
                              <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_JobNo('{$ID}','{JOBNO}')">
                                <xsl:value-of select="JOBNO" />
                              </label>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="90">
                              <xsl:value-of select="VOLUME" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetailImp" width="150">
                              <xsl:value-of select="IMPORTER_NAME" disable-output-escaping="yes" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="60px">
                              <xsl:value-of select="PAYMENT_EURO" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="60px">
                              <xsl:value-of select="RECOVERY_EURO" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="60px">
                              <xsl:value-of select="DIFF_EURO" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="100px">
                              <xsl:value-of select="$SENTFROM" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="100px">
                              <xsl:value-of select="DESTINATION" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
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