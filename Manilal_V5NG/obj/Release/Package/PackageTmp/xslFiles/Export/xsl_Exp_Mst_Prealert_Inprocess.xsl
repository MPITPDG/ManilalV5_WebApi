<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="100%">
      <tr>
        <td class="LableTimeHeader">
          <xsl:for-each select="//NewDataSet/Table">
            <xsl:value-of select="REPORTHEADER" />
          </xsl:for-each>
        </td>
      </tr>
    </table>
    <table cellpadding="2" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="100%">
      <xsl:for-each select="//NewDataSet/Table1">
        <tr class="row">
          <td class="LableTime" align="left" width="180px">
            <xsl:value-of select="DATETIMEST" />
          </td>
          <td class="LableTime" align="left">
            <xsl:value-of select="STEPNAME" />
            <xsl:value-of select="REMARKS" />
          </td>
        </tr>
      </xsl:for-each>
    </table>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">
    </table>
  </xsl:template>
</xsl:stylesheet>
