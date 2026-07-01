<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
      <tr class="DataGridFixedHeader">
        <td nowrap="1" width="100px" class="header">Account Name</td>
        <td nowrap="1" width="80px" class="header">Amount</td>
        <td nowrap="1" width="80px" class="header">Deduction</td>        
        <td nowrap="1" width="80px" class="header">Item</td>
        <td nowrap="1" width="80px" class="header">Entry Type</td>
        <td nowrap="1" width="120px" class="header">Job No</td>
        <td nowrap="1" width="120px" class="header">Bill No</td>
        <td nowrap="1" width="80px" class="header">Department</td>
        <td nowrap="1" width="80px" class="header">Narration</td>

      </tr>
      <xsl:for-each select="//NewDataSet/Table">

        <tr class="summaryDetail">
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ACCOUNT_NAME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right">
            <xsl:value-of select="AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right">
            <xsl:value-of select="DEDUCTION" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ITEM" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ET" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">

            <xsl:value-of select="JOBNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="BILLNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="DEPARTMENT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="NARRATION" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>

        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="9" class="foot">
          <xsl:if test="count(//NewDataSet/Table)!=1">
            <xsl:value-of select="count(//NewDataSet/Table)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/Table)=1">
            1 Record
          </xsl:if>
        </td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>
