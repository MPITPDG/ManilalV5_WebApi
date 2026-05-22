<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="100%">
			<tr class="DataGridFixedHeader">
				<xsl:if test="count(//NewDataSet/Table1)!=0">
					<xsl:for-each select="//NewDataSet/Table1">
						<xsl:choose>
							<xsl:when test="AUTHORISATIONSTATUS='U'">
								<td nowrap="1" width="70px" class="header" >VERIFIED</td>
								<td nowrap="1" width="70px" class="header" >REJECTED</td>
							</xsl:when>
						</xsl:choose>
					</xsl:for-each>
				</xsl:if>
				<td nowrap="1" width="100px" class="header">REQ JVNO</td>
				<td nowrap="1" width="100px" class="header">REQUESTED ON</td>
				<td nowrap="1" width="150px" class="header">REQUESTED BY</td>
				<td nowrap="1" width="100px" class="header">DEBIT</td>
				<td nowrap="1" width="100px" class="header">CREDIT</td>
				<td nowrap="1" width="150px" class="header">AUTHORISED BY</td>
				<td nowrap="1" width="150px" class="header">AUTHORISED ON</td>
			</tr>

			<xsl:for-each select="//NewDataSet/Table">
				<tr class="summaryDetail">
					<xsl:choose>
						<xsl:when test="AUTHORISATIONSTATUS='U'">
							<td class="summaryDetail"  align="center" >
								<img src="../../include/img/verified-mo.gif" class="cur"  onclick="parent.fnUpdate_JV_Authorisation('{ID}','{REQJVCODE}','{PSTATUS}')" alt="Authorise JV Request {REQJVCODE}"/>
							</td>
							<td class="summaryDetail"  align="center" >
								<img src="../../include/img/rejected.gif" class="cur"  onclick="parent.fnReject_JV_Authorisation('{ID}','{REQJVCODE}','{PSTATUS}')" alt="Cancel JV Request {REQJVCODE}" />
							</td>
						</xsl:when>
					</xsl:choose>
					<td class="summaryDetail" NOWRAP="" align="left">
						<label runat="server" class="cur" onclick="parent.fnView_JV_Request('{ID}','{REQJVCODE}','{PSTATUS}')" title="View JV Request {REQJVCODE}" >
							<xsl:value-of select="REQJVCODE" />
						</label>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="REQUESTEDON" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="REQUESTEDBY" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="DEBIT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="CREDIT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">

						<xsl:value-of select="AUTHORISEDBY" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="AUTHORISATIONDATE" />
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
