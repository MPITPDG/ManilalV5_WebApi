<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
      <tr class="DataGridFixedHeader">
        <td nowrap="1" width="100px" class="header">Account Name</td>
        <td nowrap="1" width="100px" class="header" >Amount Total</td>
        <td nowrap="1" width="100px" class="header" >Deduction Total</td>
        <td nowrap="1" width="100px" class="header" >Net Total</td>
      </tr>
      <xsl:for-each select="//NewDataSet/Table1">
        <tr class="summaryDetail">
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ACCOUNT_NAME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right" >
            <xsl:value-of select="TOT_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right" >
            <xsl:value-of select="TOT_DEDUCTION" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right" >
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            <xsl:value-of select="NET_AMOUNT" />
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="9" class="foot">
          <xsl:if test="count(//NewDataSet/Table1)!=1">
            <xsl:value-of select="count(//NewDataSet/Table1)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/Table1)=1">
            1 Record
          </xsl:if>
        </td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>
