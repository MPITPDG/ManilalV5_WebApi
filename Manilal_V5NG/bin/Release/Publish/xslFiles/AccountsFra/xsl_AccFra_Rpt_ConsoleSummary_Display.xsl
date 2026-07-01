<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet.css" type="text/css" rel="stylesheet" />
        <script language="javascript">
          function fnClickNo(No,Type)
          {
          parent.fnClick_ConsoleJob(No,Type)
          return false;
          }
        </script>
      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
        <div id="tableContainer" class="divSpace" style="width:100%">
          <table cellpadding="1" cellspacing="1" width="100%" border="0" bordercolor="white" class="infotable">
            <xsl:for-each select="//NewDataSet/Table">
              <xsl:variable name="MODE" select="MODE"></xsl:variable>
              <tr class="DataGridFixedHeader">
                <td colspan="2" class="header">

                </td>
                <td class="header">
                  
                </td>
                <td class="header" style="white-space:nowrap;">
                  Payment
                </td>
                <td class="header" style="white-space:nowrap;">
                  Recovery
                </td>
                <td class="header" style="white-space:nowrap;">
                  Diff Euro
                </td>
                <td style="white-space:nowrap;">
                  <xsl:choose>
                    <xsl:when test="$MODE='A'">
                      Chbl Weight
                    </xsl:when>
                    <xsl:otherwise>
                      Volume
                    </xsl:otherwise>
                  </xsl:choose>
                </td>
                <td class="header" style="white-space:nowrap;">
                  Total/Importer
                </td>
                <td style="white-space:nowrap;">
                  Origin
                </td>
                <td style="white-space:nowrap;">
                  Destination
                </td>
              </tr>
              <xsl:for-each select="//NewDataSet/Table1">
                <xsl:variable name="CONSOLE" select="CONSOLENO"></xsl:variable>
                <xsl:variable name="SENTFROM" select="SENTFROM"></xsl:variable>
                <tr class="formheading">
                  <td colspan="2" class="summaryDetail">
                    <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="return fnClickNo('{$CONSOLE}','C')">
                      <xsl:value-of select="CONSOLENO" />
                    </label>
                  </td>
                  <td class="summaryDetail">
                    <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="return parent.fnClick_ConsoleNo('{$CONSOLE}')">
                    View
                    </label>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="PAYMENT_EURO" />
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="RECOVERY_EURO" />
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="DIFF_EURO" />
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="VOLUME" />
                  </td>
                  <td class="summaryDetail">
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="SENTFROM" disable-output-escaping="yes" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="DESTINATION" disable-output-escaping="yes" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <xsl:for-each select="//NewDataSet/Table2">
                  <xsl:if test="CONSOLENO_JOB=$CONSOLE">
                    <tr>
                      <td width="15px" class="summaryDetail" style="white-space:nowrap;">
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class="summaryDetailDescriptionwhite">
                        <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="return fnClickNo('{JOBNO}','J')">
                          <xsl:value-of select="JOBNO" />
                        </label>
                      </td>
                      <td class="summaryDetailDescriptionwhite">
                        <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="return parent.fnClick_JobNo('{$CONSOLE}','{JOBNO}')">
                        View
                        </label>
                      </td>
                      <td class="summaryDetailDescriptionwhite" style="white-space:nowrap;">
                        <xsl:value-of select="PAYMENT_EURO" />
                      </td>
                      <td class="summaryDetailDescriptionwhite" style="white-space:nowrap;">
                        <xsl:value-of select="RECOVERY_EURO" />
                      </td>
                      <td class="summaryDetail" style="white-space:nowrap;">
                        <xsl:value-of select="DIFF_EURO" />
                      </td>
                      <td class="summaryDetailDescriptionwhite" style="white-space:nowrap;">
                        <xsl:value-of select="VOLUME" />
                      </td>
                      <td class="summaryDetailDescriptionwhite" style="white-space:nowrap;">
                        <xsl:value-of select="IMPORTER_NAME" disable-output-escaping="yes"/>
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class="summaryDetailDescriptionwhite" style="white-space:nowrap;">
                        <xsl:value-of select="$SENTFROM" disable-output-escaping="yes" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class="summaryDetailDescriptionwhite" style="white-space:nowrap;">
                        <xsl:value-of select="DESTINATION" disable-output-escaping="yes" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                    </tr>
                  </xsl:if>
                </xsl:for-each>
              </xsl:for-each>
            </xsl:for-each>
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
