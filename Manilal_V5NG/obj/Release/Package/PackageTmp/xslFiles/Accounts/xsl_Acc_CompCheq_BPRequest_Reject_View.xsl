<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="100%">
			<tr class="DataGridFixedHeader">
				<td nowrap="1" width="100px" class="header">ENTRYNO</td>
				<td nowrap="1" width="100px" class="header">CREATED BY</td>
				<td nowrap="1" width="80px" class="header">ENTRY DATE</td>
				<td nowrap="1" width="80px" class="header">PAYBY DATE</td>
				<td nowrap="1" width="100px" class="header">PAYEE NAME</td>
				<td nowrap="1" width="80px" class="header">AMOUNT</td>
				<td nowrap="1" width="150px" class="header">REJECTED BY</td>
				<td nowrap="1" width="120px" class="header">REJECTED ON</td>
				<td nowrap="1" width="60px" class="header">TYPE</td>
			</tr>

			<xsl:for-each select="//NewDataSet/Table">
				<tr class="summaryDetail">
					<td class="summaryDetail" NOWRAP="" align="left">
						<label runat="server" class="cur" onclick="parent.fnView_BP_Request('{ENTRYNO}','{ENTRYDT}')" title="View BP Request {REQCODE}" >
							<a href="#{ENTRYNO}">
								<xsl:value-of select="ENTRYNO" />
							</a>
						</label>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="CREATEDBY" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="ENTRYDT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>

					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="PAYBYDATE" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="PAYEENAME" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="AMOUNT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="REJECTEDBY" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="REJECTIONDATE" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="TYPE" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					
				</tr>
			</xsl:for-each>
			<tr valign="top">
				<td colspan="10" class="foot">
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
