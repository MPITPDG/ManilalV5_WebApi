<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<div id="tableContainer" class="divSpace">
			<table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
				<tr class="DataGridFixedHeader">
					<td nowrap="1" width="60px" class="header" ></td>
					<td nowrap="1" class="header">POL</td>
					<td nowrap="1" class="header">POD</td>
					<td nowrap="1" class="header">Liner Name</td>
					<td nowrap="1" class="header">Carrier Split </td>
					<td nowrap="1" class="header">Transit Time</td>
					<td nowrap="1" class="header">From Date</td>
					<td nowrap="1" class="header">To Date</td>					 
				</tr>
				<xsl:for-each select="//NewDataSet/Table1">
					<tr class="summaryDetail">
						<td class="summaryDetail"  align="center" >
							<img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_Carrier('{ID}','{POL}','{POD}','{LINER_CODE}','{CARRIER_SPLIT}','{NOOF_DAY}','{FROM_DATE}','{TO_DATE}')" alt="Edit Details {id}"/>
							 
						</td>
						<td class="summaryDetail" NOWRAP="" align="left">
							<xsl:value-of select="POL_CITY" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td class="summaryDetail" NOWRAP="" align="left">
							<xsl:value-of select="POD_CITY" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td class="summaryDetail" NOWRAP="" align="left">
							<xsl:value-of select="LINER_NAME" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td class="summaryDetail" NOWRAP="" align="left">
							<xsl:value-of select="CARRIER_SPLIT" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td class="summaryDetail" NOWRAP="" align="left">
							<xsl:value-of select="NOOF_DAY" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td class="summaryDetail" NOWRAP="" align="left">
							<xsl:value-of select="FROM_DATE" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td class="summaryDetail" NOWRAP="" align="left">
							<xsl:value-of select="TO_DATE" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						 
					</tr>
				</xsl:for-each>
			</table>
		</div>
    </xsl:template>
</xsl:stylesheet>
