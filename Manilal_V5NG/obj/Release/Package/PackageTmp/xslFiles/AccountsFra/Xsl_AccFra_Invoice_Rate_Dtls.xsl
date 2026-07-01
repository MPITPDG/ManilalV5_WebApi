<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <HEAD>
      <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
    </HEAD>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
      <tr class="DataGridFixedRow">
        <td nowrap="1" class="header" >Account Name</td>
        <td nowrap="1" class="header" >Chrg Cond Unit1</td>
        <td nowrap="1"  class="header" width="100px">Chrg Cond Unit2</td>
        <td nowrap="1"  class="header" width="80px">Invoce Rate</td>
        <td nowrap="1"  class="header" width="100px">Type Unit</td>        
      </tr>
      <xsl:for-each select="//NewDataSet/Table1">
        <tr class="summaryDetail">
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="NAME1" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="CHRG_COND_UNIT1" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="CHRG_COND_UNIT2" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right">
            <xsl:value-of select="INV_RATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right">
            <xsl:value-of select="UNIT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>           
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="8" class="foot">
          <xsl:if test="count(//NewDataSet/Table1)!=1">
            <xsl:value-of select="count(//NewDataSet/Table)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/Table1)=1">
            1 Record
          </xsl:if>
        </td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>
