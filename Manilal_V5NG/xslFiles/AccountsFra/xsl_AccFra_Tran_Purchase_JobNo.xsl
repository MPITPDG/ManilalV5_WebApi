<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
      <xsl:for-each select="//NewDataSet/Table">
        <xsl:variable name="TYPE" select="SEARCH_TYPE"></xsl:variable>
        <tr class="DataGridFixedHeader">
          <td nowrap="1" class="header">CONSOLE NO</td>
          <xsl:if test="$TYPE='HB' or $TYPE='HA' or $TYPE='O' or $TYPE='HB' or $TYPE='N'">
            <td nowrap="1" class="header">JOB NO</td>
          </xsl:if>
        </tr>
      <xsl:for-each select="//NewDataSet/Table1">
        <tr class="summaryDetail">
          <td class="summaryDetail" NOWRAP="" align="left">
            <a href="javascript:SetValue('{CONSOLENO}')">
            <xsl:value-of select="CONSOLENO" />
            </a>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <xsl:if test="$TYPE='HB' or $TYPE='HA' or $TYPE='O' or $TYPE='HB' or $TYPE='N'">
            <td class="summaryDetail" NOWRAP="" align="left">
              <a href="javascript:SetValue('{JOBNO}')">
              <xsl:value-of select="JOBNO" />
              </a>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>  
          </xsl:if>
        </tr>
      </xsl:for-each>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>
