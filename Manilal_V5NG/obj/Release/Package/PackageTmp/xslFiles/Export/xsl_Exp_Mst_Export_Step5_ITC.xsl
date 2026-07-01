<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
      <tr class="DataGridFixedHeader">
        <td nowrap="1" width="5px" class="header" ></td>
        <td nowrap="1" width="100px" class="header">ITC Code</td>
        <td nowrap="1" width="100px" class="header">FOB INR</td>
        <td nowrap="1" width="100px" class="header">Drawback Sub Sr.No</td>
        <td nowrap="1" width="100px" class="header">Unit1</td>
        <td nowrap="1" width="100px" class="header">Type1</td>
        <td nowrap="1" width="100px" class="header">Group Code</td>
        <td nowrap="1" width="100px" class="header">Appendix of public notice</td>
        <td nowrap="1" width="100px" class="header">Condition No.</td>
        <td nowrap="1" width="100px" class="header">Unit2</td>
        <td nowrap="1" width="100px" class="header">Type2</td>
        <td nowrap="1" width="100px" class="header">% of Drawback</td>
        <td nowrap="1" width="100px" class="header">Rate per Unit</td>
        <td nowrap="1" width="100px" class="header">Description</td>
      </tr>
      <xsl:for-each select="//NewDataSet/Table">
        <tr class="summaryDetail">
          <td class="summaryDetail"  align="center">
            <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fnEdit_ITC_Dtls('{TBL_INDEXID}','{ITCCODEID}','{EXPTNO}','{ITCCODE}','{FOBINR}','{DBKSUBSRNO}','{UNIT}','{TPE}','{EXP_ITCGROUPCODE}','{APPENDIXNO}','{CONDITIONNO}','{UNITA}','{TPEA}','{DBKPERCENT}','{DBKPERCENTA}','{RATEPERUNIT}','{DESCRIPTION}','{ITCDESCID}')" alt="Edit ITC code Details {ITCCODE}"/>
            <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="parent.fnDelete_ITC_Dtls('{TBL_INDEXID}','{ITCCODEID}','{ITCCODE}','{EXPTNO}')" alt="Delete ITC code Details{ITCCODE}"/>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ITCCODE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="FOBINR" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="DBKSUBSRNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="UNIT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="TPE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="EXP_ITCGROUPCODE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="APPENDIXNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="CONDITIONNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="UNITA" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="TPEA" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="DBKPERCENT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="RATEPERUNIT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="DESCRIPTION" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="14" class="foot">
          <xsl:if test="count(//NewDataSet/Table)!=1">
            <xsl:value-of select="count(//NewDataSet/Table)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/Table)=1">
            1 Record
          </xsl:if>
        </td>
      </tr>
    </table>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

    </table>

  </xsl:template>
</xsl:stylesheet>
