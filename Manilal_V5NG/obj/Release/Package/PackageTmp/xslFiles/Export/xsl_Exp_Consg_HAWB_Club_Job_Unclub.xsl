<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div id="tableContainer" class="divSpace">
      <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
        <tr class="DataGridFixedHeader">
          <td nowrap="1" class="header"> </td>
          <td nowrap="1" class="header">Job No.</td>
          <td nowrap="1" class="header">Exporter/Shipper</td>
          <td nowrap="1" class="header">Consignee/Importer</td>
          <td nowrap="1" class="header">No.of Pkgs</td>
          <td nowrap="1" class="header">Gross Weight</td>
          <td nowrap="1" class="header">Volume</td>
          <td nowrap="1" class="header">Chbl Wt.</td>
        </tr>
        <xsl:for-each select="//NewDataSet/Table2">
          <tr class="summaryDetail">
            <td class="summaryDetail" NOWRAP="" align="left">
              <img src="../../INCLUDE/img/post2.gif" class="cur"  onclick="parent.fnUpdate_HAWBNO('{UNCLUB_ID}','{JOB_NO}')" alt="Club this JobNo.{JOB_NO}"/>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="JOB_NO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="EXPORTER_SHIPPER" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CONSIGNEE_IMPORTER" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="NOOFPKGS" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="GROSS_WEIGHT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="VOLUME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CHBL_WT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
          </tr>
        </xsl:for-each>
        <tr valign="top">
          <td colspan="8" class="foot">
            <xsl:if test="count(//NewDataSet/Table2)!=1">
              <xsl:value-of select="count(//NewDataSet/Table2)"/> Records
            </xsl:if>
            <xsl:if test="count(//NewDataSet/Table2)=1">
              1 Record
            </xsl:if>
          </td>
        </tr>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
