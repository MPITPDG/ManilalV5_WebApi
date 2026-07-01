<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="1" border="1" WIDTH="100%">
      <tr class="FixedHeaderAsp">
        <td nowrap="1" class="ColumnHead">Export No.</td>
        <td nowrap="1" class="ColumnHead">Shipper</td>
        <td nowrap="1" class="ColumnHead">Consignee</td>
        <td nowrap="0" class="ColumnHead">No.Of Pcs</td>
        <td nowrap="0" class="ColumnHead">No.Of Pkgs</td>
        <td nowrap="0" class="ColumnHead">Gr. Wt.</td>
        <td nowrap="0" class="ColumnHead">Net Wt.</td>
        <td nowrap="0" class="ColumnHead">CBM</td>
        <td nowrap="0" class="ColumnHead">Order No</td>
        <td nowrap="0" class="ColumnHead">CLP Seq.</td>
      </tr>
      <xsl:for-each select="//NewDataSet/Table1">
        <xsl:choose>
          <xsl:when test="IS_SAME_JOB='Y'">
            <tr bgcolor="#99CCCC">
              <td class="ColumnSummary" NOWRAP="" align="left" rowspan="3">
                <xsl:value-of select="EXPTNO" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="EXPORTER" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="CONSIGNEE" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="PCS" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="NOOFPKGS" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="GRWT" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="NETWT" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="CBM" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="ORDERNO" disable-output-escaping="yes" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="CLPSEQUENCE" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
            <tr bgcolor="#99CCCC">
              <td class="ColumnHead" NOWRAP="" align="left">
                Description
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left" colspan="8">
                <xsl:value-of select="ITC_DESC" disable-output-escaping="yes" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
            <tr bgcolor="#99CCCC">
              <td class="ColumnHead" NOWRAP="" align="left">
                FCR No.
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="FCR_NO" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnHead" NOWRAP="" align="left">
                FCR Date.
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left" colspan="6">
                <xsl:value-of select="FCR_DATE" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
          </xsl:when>
          <xsl:otherwise>
            <tr>
              <td class="ColumnSummary" NOWRAP="" align="left" rowspan="3">
                <xsl:value-of select="EXPTNO" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="EXPORTER" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="CONSIGNEE" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="PCS" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="NOOFPKGS" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="GRWT" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="NETWT" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="CBM" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="ORDERNO" disable-output-escaping="yes" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="CLPSEQUENCE" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
            <tr>
              <td class="ColumnHead" NOWRAP="" align="left">
                Description
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left" colspan="8">
                <xsl:value-of select="ITC_DESC" disable-output-escaping="yes" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
            <tr>
              <td class="ColumnHead" NOWRAP="" align="left">
                FCR No.
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left">
                <xsl:value-of select="FCR_NO" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="ColumnHead" NOWRAP="" align="left">
                FCR Date.
              </td>
              <td class="ColumnSummary" NOWRAP="" align="left" colspan="6">
                <xsl:value-of select="FCR_DATE" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>
