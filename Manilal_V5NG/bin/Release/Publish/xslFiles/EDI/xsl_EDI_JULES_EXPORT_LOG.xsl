<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" width="100%">
      <tr class="DataGridFixedHeader">
        <td nowrap="1" width="150px" class="header">ACTUAL FILENAME</td>
        <td nowrap="1" width="150px" class="header">EXPORTED BY</td>
        <td nowrap="1" width="150px" class="header">EXPORTED ON</td>
        <td nowrap="1" width="150px" class="header">EXPORTED IP</td>
      </tr>

      <xsl:for-each select="//NewDataSet/Table">
        <tr class="summaryDetail">
          <td class="summaryDetail" NOWRAP="" align="left">
            <label runat="server" class="cur" onclick="parent.fn_Open('{D_FTP}')" title="Download  {ACTUALFILENAME}" >
              <a href="#{ACTUALFILENAME}" style="text-decoration:none;">
                <xsl:value-of select="ACTUALFILENAME" />
              </a>
            </label>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="CMP_USERNAME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" style="text-align:left;">
            <xsl:value-of select="EXPORTED_DT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="EXPORTED_IP" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="4" class="foot">
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
