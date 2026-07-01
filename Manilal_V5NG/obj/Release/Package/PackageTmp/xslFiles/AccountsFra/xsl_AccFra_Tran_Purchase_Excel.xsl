<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>
			<head>
				<link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
			</head>
		<table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="750px">
			<tr class="DataGridFixedHeader">
				 
				<td nowrap="1" class="header">ACCOUNT</td>
				<td nowrap="1" class="header">MAWB/MBL</td>
				<td nowrap="1" class="header">CONSOLE/JOB#</td>
				<td nowrap="1" class="header" width="100px">PAYABLE </td>
				<td nowrap="1" class="header" width="80px">RECEIVABLE </td>
			 
				<td nowrap="1" class="header" width="100px">NARRATION</td>
			</tr>
			<xsl:for-each select="//NewDataSet/Table1">
				<tr class="summaryDetail">					 
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="ACCOUNT_NAME" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="MAWBNO" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="CONSOLENO" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="INVOICE_AMT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="DEDUCTION_AMT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
		 
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="SHORTNARRATION" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
				</tr>
			</xsl:for-each>
			<tr valign="top">
				<td colspan="7" class="foot">
					<xsl:if test="count(//NewDataSet/Table1)!=1">
						<xsl:value-of select="count(//NewDataSet/Table1)"/> Records
					</xsl:if>
					<xsl:if test="count(//NewDataSet/Table1)=1">
						1 Record
					</xsl:if>
				</td>
			</tr>
		</table>
		</html>
	</xsl:template>
</xsl:stylesheet>
