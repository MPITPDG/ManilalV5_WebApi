<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<div id="tableContainer" class="divSpace" style="width:500px" >
			<table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
				<tr class="DataGridFixedHeader">
					<td class="header">
						For
					</td>
					<td class="header">
						From Date
					</td>
					<td class="header">
						To Date
					</td>
					<td class="header" align="right" >
						Exch.Rate ( = Euro 1.00)
					</td>
				</tr>
				<tr height="0">
					<td width="100px">
					</td>
					<td width="100px">
					</td>
					<td width="100px">
					</td>
					<td width="200px">
					</td>
				</tr>
				<xsl:for-each select="//NewDataSet/Table1">
					<tr style="cursor:hand;" onclick="fnPopulate_ExchRate('{PK_ID}','{CUR_CODE}','{FROM_DATE}','{TO_DATE}','{EXCHANGE_RATE}')">
						<td width="100px">
							<xsl:value-of select="CUR_CODE" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td width="100px">
							<xsl:value-of select="FROM_DATE" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td width="100px">
							<xsl:value-of select="TO_DATE" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td width="200px" align="right" >
							<xsl:value-of select="EXCHANGE_RATE" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
					</tr>
				</xsl:for-each>
				<tr valign="top">
					<td colspan="4" class="foot">
						<xsl:if test="count(//NewDataSet/Table1)!=1">
							<xsl:value-of select="count(//NewDataSet/Table1)"/> Records
						</xsl:if>
						<xsl:if test="count(//NewDataSet/Table1)=1">
							1 Record
						</xsl:if>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
</xsl:stylesheet>
