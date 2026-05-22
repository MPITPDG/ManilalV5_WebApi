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
        <td nowrap="1" class="ColumnHead">ITC Code</td>
        <td nowrap="1" class="ColumnHead">FOB INR</td>
        <td nowrap="1" class="ColumnHead">Drawback Sub Sr.No</td>
        <td nowrap="1" class="ColumnHead">Unit1</td>
        <td nowrap="1" class="ColumnHead">Type1</td>
        <td nowrap="1" class="ColumnHead">Group Code</td>
        <td nowrap="1" class="ColumnHead">Appendix of public notice</td>
        <td nowrap="1" class="ColumnHead">Condition No.</td>
        <td nowrap="1" class="ColumnHead">Unit2</td>
        <td nowrap="1" class="ColumnHead">Type2</td>
        <td nowrap="1" class="ColumnHead">% of Drawback</td>
        <td nowrap="1" class="ColumnHead">Rate per Unit</td>
        <td nowrap="1" class="ColumnHead">Description</td>
      </tr>
      <xsl:for-each select="//NewDataSet/TblITC">
        <tr>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="ITCCODE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="FOBINR" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="DBKSUBSRNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="UNIT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="TPE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="EXP_ITCGROUPCODE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="APPENDIXNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="CONDITIONNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="UNITA" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="TPEA" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="DBKPERCENT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="RATEPERUNIT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="ColumnSummary" NOWRAP="" align="left">
            <xsl:value-of select="DESCRIPTION" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="14" class="ColumnSummary">
          <xsl:if test="count(//NewDataSet/TblITC)!=1">
            <xsl:value-of select="count(//NewDataSet/TblITC)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/TblITC)=1">
            1 Record
          </xsl:if>
        </td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>
