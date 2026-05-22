<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
			<tr class="DataGridFixedHeader">
				<!--<td nowrap="1" class="header"></td>-->
				<td nowrap="1" class="header">ORDERNO</td>
				<td nowrap="1" class="header">PIECES</td>
				<td nowrap="1" class="header">TYPE OF PCS</td>
				<td nowrap="1" class="header">PKGS</td>
				<td nowrap="1" class="header">GRWT</td>
				<td nowrap="1" class="header">VOLUME</td>
				<td nowrap="1" class="header">CHBLWT</td>
			</tr>
			<xsl:for-each select="//NewDataSet/Table">
				<tr class="summaryDetail">

					<td class="summaryDetail" NOWRAP="" align="left">
						<a onclick="javascript:parent.fnDimenssion('{EXPTNO}','{ID}','{ORDERNO}','{PKGS}')">
							<b style="cursor:hand;color:blue;text-decoration:none;"></b>
								<xsl:value-of select="ORDERNO" />
								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
							
						</a>
					</td>
					<!--<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="ORDERNO" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>-->
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="PIECES" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="TYPEOFPCS" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="PKGS" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="GRWT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="VOLUME" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="CHBLWT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
				</tr>
			</xsl:for-each>
			<tr valign="top">
				<td colspan="11" class="foot">
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
