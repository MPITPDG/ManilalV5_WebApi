<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="600px">
			<tr class="DataGridFixedHeader">
				
				<td nowrap="1" width="65px" class="header">Packages</td>
				<td nowrap="1" width="65px" class="header">Length</td>
				<td nowrap="1" width="67px" class="header">Breadth</td>
				<td nowrap="1" width="65px" class="header">Height</td>
				<td nowrap="1" width="80px" class="header"></td>
			</tr>
			<xsl:for-each select="//NewDataSet/Table">
				<tr class="summaryDetail">
					
					<td class="summaryDetail" NOWRAP="" align="left" >
						<xsl:value-of select="PKGS" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="LENGTH" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="BREADTH" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="HEIGHT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail"  align="center">
						<img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="parent.fnDelete_OrderDimenssion_Dtls('{ID}','{ORDERNO}','{EXPTNO}','{EXP_ORDERDTLS_ID}')" alt="Delete Order Dimenssion Details({ORDERNO})"/>
					</td>
				</tr>
			</xsl:for-each>
			<tr valign="top">
				<td colspan="5" class="foot">
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
