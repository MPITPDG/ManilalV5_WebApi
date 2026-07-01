<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div id="tablecontainer" class="divSpace">
      <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%" height="100%">
        <tr class="DataGridFixedHeader">
          <td nowrap="1" class="header">Export No.</td>
          <td nowrap="1" class="header">Shipper</td>
          <td nowrap="1" class="header">Consignee</td>
          <td nowrap="1" class="header">No. of Pcs</td>
          <td nowrap="1" class="header">No. of Pkgs</td>
          <td nowrap="1" class="header">Gr. Wt</td>
          <td nowrap="1" class="header">Net Wt</td>
          <td nowrap="1" class="header">CBM</td>
          <td nowrap="1" class="header">Order No</td>
          <td nowrap="1" class="header">Clp. Seq</td>
        </tr>
        <xsl:for-each select="//NewDataSet/Table2">
          <xsl:variable name="EXPTNO" select="EXPTNO"></xsl:variable>
          <tr class="summaryDetail">
            <td class="summaryDetail" NOWRAP="" align="left" rowspan="3">
              <xsl:value-of select="EXPTNO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="EXP_NAME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CON_NAME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="NOOFPCS" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="NOOFPKGS" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="GRWT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="NETWT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CBM" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <table border="0" cellpadding="0" cellspeacing="0">
                <tr height="0px">
                  <td></td>
                </tr>
                <xsl:for-each select="//NewDataSet/Table3">
                  <xsl:if test ="$EXPTNO=EXPTNO_O">
                    <tr>
                      <td class="summaryDetail" NOWRAP="" align="left">
                        <xsl:value-of select="ORDERNO" disable-output-escaping="yes" />
                      </td>
                    </tr>
                  </xsl:if>
                </xsl:for-each>
              </table>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CLP_SEQUENCE" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
          </tr>
          <tr>
            <th class="summaryDetail" NOWRAP="" align="left">Description</th>
            <td colspan="8" class="summaryDetail" >
              <xsl:value-of select="DESCRIPTION" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
          </tr>
          <tr>
            <th class="summaryDetail" NOWRAP="" align="left">FCR No</th>
            <td class="summaryDetail">
              <xsl:value-of select="FCR_NO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <th class="summaryDetail" NOWRAP="" align="right" colspan="2">FCR Date</th>
            <td colspan="5" class="summaryDetail" NOWRAP="">
              <xsl:value-of select="FCR_DATE"/>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
          </tr>
        </xsl:for-each>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
