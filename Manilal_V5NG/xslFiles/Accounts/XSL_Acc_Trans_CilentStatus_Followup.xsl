<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="750px">
			<tr class="DataGridFixedHeader">

				<td nowrap="1" class="header">CLIENT NAME</td>
				<td nowrap="1" class="header" width="180px">FOLLOW UP ASSIGNED TO</td>
				<td nowrap="1" class="header">CLIENT STATUS</td>
				<td nowrap="1" class="header" width="100px">ASSIGNED ON </td>
				<td nowrap="1" class="header" width="80px">ASSIGNED BY </td>				 
			</tr>
			<xsl:for-each select="//NewDataSet/Table1">
				<tr class="summaryDetail">
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="EXP_NAME" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="FOLLOW_ASSIGNTO" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="CLIENT_STATUS" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="ASSIGN_ON" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="ASSIGN_BY" />
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
	</xsl:template>
</xsl:stylesheet>
