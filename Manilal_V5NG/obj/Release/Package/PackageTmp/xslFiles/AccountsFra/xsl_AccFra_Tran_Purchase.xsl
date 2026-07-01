<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="750px">
      <tr class="DataGridFixedHeader">
        <td nowrap="1" class="header"></td>
        <td nowrap="1" class="header">ACCOUNT</td>
        <td nowrap="1" class="header">MAWB/MBL</td>
        <td nowrap="1" class="header">CONSOLE/JOB#</td>
        <td nowrap="1" class="header" width="100px">PAYABLE </td>
        <td nowrap="1" class="header" width="80px">RECEIVABLE </td>
		<td nowrap="1" class="header" width="70px">PAY EURO </td>
		<td nowrap="1" class="header" width="70px">REC EURO </td>
        <!--<td nowrap="1" class="header">CURRENCY</td>
        <td nowrap="1" class="header">AMOUNT</td>
        <td nowrap="1" class="header">EXCHANGE RATE (EURO)</td>-->
        <td nowrap="1" class="header" width="100px">NARRATION</td>
      </tr>
      <xsl:for-each select="//NewDataSet/Table">
        <tr class="summaryDetail">
          <td class="summaryDetail"  align="center">
            <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fnEdit_Pur_Dtls('{TBL_INDEXID}','{ID}','{ENTRYNO}','{ACCOUNT}','{MAWBMBL}','{JOBNO}','{INVOICEEURO}','{DEDUCTIONEURO}','{NARRATION}','{INV_EURO}','{DED_EURO}')" alt="Edit Purchase Details({ACCTNAME})"/>
            <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="parent.fnDelete_Pur_Dtls('{TBL_INDEXID}','{ID}','{ENTRYNO}','{ACCTNAME}')" alt="Delete Purchase Details({ACCTNAME})"/>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ACCTNAME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="MAWBMBL" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="JOBNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right">
            <xsl:value-of select="INVOICEEURO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right">
            <xsl:value-of select="DEDUCTIONEURO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
			<td class="summaryDetail" NOWRAP="" align="right">
				<xsl:value-of select="INV_EURO" />
				<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
			</td>
			<td class="summaryDetail" NOWRAP="" align="right">
				<xsl:value-of select="DED_EURO" />
				<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
			</td>
          <!--<td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="CURNAME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right">
            <xsl:value-of select="PUR_CUR_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="right">
            <xsl:value-of select="PUR_EXCHANGE_EURO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>-->
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
