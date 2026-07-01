<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet.css" type="text/css" rel="stylesheet" />
        <script language="javascript">
          function fnClickNo(No)
          {
          parent.fnClick_ConsoleNo(No)
          return false;
          }
        </script>
      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
        <div id="tableContainer" class="divSpace" style="width:770px" >
          <table cellpadding="0" cellspacing="0" width="750px" border="0" bordercolor="white" class="infotable">
            <xsl:for-each select="//NewDataSet/Table">
              <xsl:variable name="MODE" select="MODE"></xsl:variable>
            <tr class="DataGridFixedHeader">
              <td class="header">
                Console NR
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
                <xsl:choose>
                  <xsl:when test="$MODE='A'">
                    Chbl Weight
                  </xsl:when>
                  <xsl:otherwise>
                    Volume
                  </xsl:otherwise>
                </xsl:choose>
              </td>
              <td class="header">
                Total/Importer
              </td>
              <td>
                Origin
              </td>
              <td>
                Destination
              </td>
            </tr>
            <tr height="0">
              <td width="80px">
              </td>
              <td width="80px">
              </td>
              <td width="80px">
              </td>
              <td width="80px">
              </td>
              <td width="80px">
              </td>
              <td width="150px">
              </td>
              <td width="100px">
              </td>
              <td width="120px">
              </td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table1">
              <xsl:variable name="ID" select="CONSOLENO"></xsl:variable>
              <tr style="font-weight: bold;">
                <td class="summaryDetail">
                  <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="return fnClickNo('{$ID}')">
                    <xsl:value-of select="CONSOLENO" />
                  </label>
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
                  <xsl:value-of select="VOLUME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="summaryDetail">
                  Total
                  <!--xsl:value-of select="IMPORTER_NAME" disable-output-escaping="yes" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text-->
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
              <xsl:for-each select="//NewDataSet/Table5">
                <xsl:if test="CONSOLENO_IMP=$ID">
                <tr>
                  <td class="summaryDetail">
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetailImp">
                    <xsl:value-of select="VOLUME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetailImp">
                    <xsl:value-of select="IMPORTER_NAME" disable-output-escaping="yes" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetailImp">
                    <xsl:value-of select="SENTFROM" disable-output-escaping="yes" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetailImp">
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