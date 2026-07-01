<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <style type="text/css">
      .Heading
      {
      font-size: 14;
      font-family: Verdana, Arial, Helvetica, sans-serif;
      font-weight: bold;
      }
      .ColumnHead
      {
      font-size: 12;
      font-family: Verdana, Arial, Helvetica, sans-serif;
      font-weight: bold;
      }
      .ColumnSummary
      {
      font-size: 12;
      font-family: Verdana, Arial, Helvetica, sans-serif;
      }
      .FixedHeaderAsp
      {
      position: relative;
      top: expression(this.offsetParent.scrollTop-2);
      font-family: verdana;
      font-weight: bold;
      font-size: 11px;
      background-color:White;
      }
    </style>
    <table cellpadding="2" cellspacing="1" border="1" WIDTH="100%">
      <tr class="FixedHeaderAsp">
        <td nowrap="1" class="ColumnHead">Order No.</td>
        <td nowrap="1" class="ColumnHead">Reference No</td>
        <td nowrap="1" class="ColumnHead">Pieces</td>
        <td nowrap="1" class="ColumnHead">Type of Pieces</td>
        <td nowrap="1" class="ColumnHead">Warehouse</td>
        <td nowrap="1" class="ColumnHead">Item Description</td>
        <td nowrap="1" class="ColumnHead">Pkgs</td>
        <td nowrap="1" class="ColumnHead">Gr. Wt</td>
        <td nowrap="1" class="ColumnHead">Net Wt</td>
        <td nowrap="1" class="ColumnHead">Volume</td>
        <td nowrap="1" class="ColumnHead">Chbl. Wt.</td>
        <td nowrap="1" class="ColumnHead">LSD Date</td>
        <td nowrap="1" class="ColumnHead">DRN Date</td>
        <td nowrap="1" class="ColumnHead">FOB Value</td>
        <td nowrap="1" class="ColumnHead">Currency </td>
        <td nowrap="1" class="ColumnHead">Cnee Dept (Rayon)</td>
        <td nowrap="1" class="ColumnHead">Container No</td>
      </tr>
      <xsl:for-each select="//NewDataSet/TblOrderNo">
        <tr>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="ORDERNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="STYLENO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="PIECES" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="TYPEOFPCS" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="WAREHOUSE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="ITEMDESC" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="PKGS" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="GRWT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="VOLUME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="NETWT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="CHBLWT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="LSD" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="DRNDATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="FOBVALUE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="CURENCY" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="CNEEDEPT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="CONTAINERNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="17" class="ColumnSummary">
          <xsl:if test="count(//NewDataSet/TblOrderNo)!=1">
            <xsl:value-of select="count(//NewDataSet/TblOrderNo)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/TblOrderNo)=1">
            1 Record
          </xsl:if>
        </td>
      </tr>
    </table>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

    </table>

  </xsl:template>
</xsl:stylesheet>
