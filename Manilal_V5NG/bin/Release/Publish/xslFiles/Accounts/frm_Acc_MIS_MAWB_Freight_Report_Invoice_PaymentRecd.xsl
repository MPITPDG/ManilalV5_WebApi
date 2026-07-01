<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div class="divSpace" id="tableContainer">
      <table cellpadding="0" cellspacing="0" border="1" bordercolor="white" class="infotable">
        <tr class="DataGridFixedHeader" height="20px" valign="top">
          <td nowrap="1" width="10px" align="center">Type</td>
          <td nowrap="1" width="100px" align="center">Entry No.</td>
          <td nowrap="1" width="128px" align="right">Debit</td>
          <td nowrap="1" width="130px" align="right">Credit</td>
        </tr>
        <xsl:for-each select="//NewDataSet/Table4">
          <tr class="summaryDetail">
            <td class="summaryDetail" NOWRAP="">
              <xsl:value-of select="TTYPE" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="">
              <a onclick="javascript:parent.fn_Populate_Print('{URLLINK}');" style="color:Blue;cursor:hand;">
                <b>
                  <xsl:value-of select="TCODE" />
                </b>
              </a>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" style="text-align:right;">
              <xsl:value-of select="DRAMT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" style="text-align:right;">
              <xsl:value-of select="CRAMT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
          </tr>
        </xsl:for-each>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
