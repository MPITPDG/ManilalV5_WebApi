<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div id="tableContainer" class="divSpace" width="100%">
      <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
        <tr class="DataGridFixedHeader">
          <td colspan="4" class="header">Consignment Details</td>
        </tr>
        <tr class="DataGridFixedHeader">
          <td nowrap="1" width="130px" class="header">Container No</td>
          <td nowrap="1" width="130px" class="header">Export No</td>
          <td nowrap="1" width="150px" class="header">Total No Of Pkgs</td>
          <td nowrap="1" width="100px" class="header">Total CBM</td>
        </tr>
        <xsl:for-each select="//NewDataSet/Table">
          <tr class="summaryDetail">
            <xsl:if test="CONTAINERNO!=''">
              <td class="summaryDetail"  align="center" rowspan="{TOTAL_COUNT}">
                <xsl:value-of select="CONTAINERNO" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>  
            </xsl:if>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="EXPTNO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="NOOFPKGS" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CBM" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
          </tr>
        </xsl:for-each>
        <tr valign="top">
          <td colspan="5" class="foot">
            <xsl:if test="count(//NewDataSet/Table)!=1">
              <xsl:value-of select="count(//NewDataSet/Table)"/> Records
            </xsl:if>
            <xsl:if test="count(//NewDataSet/Table)=1">
              1 Record
            </xsl:if>
          </td>
        </tr>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
