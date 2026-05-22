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
				<td nowrap="1" width="100px" class="header">REQ CODE</td>
				<td nowrap="1" width="100px" class="header">REQUESTED ON</td>
				<td nowrap="1" width="150px" class="header">REQUESTED BY</td>
				<xsl:if test="count(//NewDataSet/Table1)!=0">
					<xsl:for-each select="//NewDataSet/Table1">
						<xsl:choose>
							<xsl:when test="PSTATUS='JVREQ'">
								<td nowrap="1" width="100px" class="header">DEBIT</td>
								<td nowrap="1" width="100px" class="header">CREDIT</td>
							</xsl:when>
							<xsl:otherwise>
								<td nowrap="1" width="100px" class="header">AMOUNT</td>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>
				</xsl:if>
				<td nowrap="1" width="150px" class="header">AUTHORISED BY</td>
				<td nowrap="1" width="150px" class="header">AUTHORISED ON</td>
			</tr>

			<xsl:for-each select="//NewDataSet/Table">
				<tr class="summaryDetail">
					<xsl:choose>
						<xsl:when test="AUTHORISATIONSTATUS='U'">
							<td class="summaryDetail"  align="center" >
								<img src="../../include/img/verified-mo.gif" class="cur"  onclick="parent.fnUpdate_CPJVPI_REQUEST_Authorisation('{ID}','{REQCODE}','{PSTATUS}')" alt="Authorise '{PSTATUS}' {REQCODE}"/>
							</td>
							<td class="summaryDetail"  align="center" >
								<img src="../../include/img/rejected.gif" class="cur"  onclick="parent.fnReject_CPJVPI_REQUEST_Authorisation('{ID}','{REQCODE}','{PSTATUS}')" alt="Cancel '{PSTATUS}' {REQCODE}" />
							</td>
						</xsl:when>
					</xsl:choose>
					
					<xsl:choose>
						<xsl:when test="PSTATUS='JVREQ'">
							<td class="summaryDetail" NOWRAP="" align="left">
								<label runat="server" class="cur" onclick="parent.fnView_JV_Request('{ID}','{REQCODE}','{PSTATUS}')" title="View JV Request {REQCODE}" >
									<a href="#{REQCODE}">
										<xsl:value-of select="REQCODE" />
									</a>
								</label>
								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
							</td>
						</xsl:when>
						<xsl:when test="PSTATUS='RCP'">
							<td class="summaryDetail" NOWRAP="" align="left">
								<label runat="server" class="cur" onclick="parent.fnView_JV_Request('{ID}','{REQCODE}','{PSTATUS}')" title="View CP Request {REQCODE}" >
									<a href="#{REQCODE}" style="text-decoration:none;">
										<xsl:value-of select="REQCODE" />
									</a>
								</label>
								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
							</td>
						</xsl:when>
						<xsl:otherwise>
							<td class="summaryDetail" NOWRAP="" align="left">
								<label runat="server" class="cur" onclick="parent.fnView_JV_Request('{ID}','{REQCODE}','{PSTATUS}')" title="View Purchase Request {REQCODE}" >
									<a href="#{REQCODE}">
										<xsl:value-of select="REQCODE" />
									</a>
								</label>
								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
							</td>
						</xsl:otherwise>
					</xsl:choose>
					
					<!--<td class="summaryDetail" NOWRAP="" align="left">
						<label runat="server" class="cur" onclick="parent.fnView_JV_Request('{ID}','{REQCODE}','{PSTATUS}')" title="View Request {REQCODE}" >
							<xsl:value-of select="REQCODE" />
						</label>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>-->
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="REQUESTEDON" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="REQUESTEDBY" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<xsl:choose>
						<xsl:when test="PSTATUS='JVREQ'">
							<td class="summaryDetail" NOWRAP="" align="left">
								<xsl:value-of select="DEBIT" />
								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
							</td>
							<td class="summaryDetail" NOWRAP="" align="left">
								<xsl:value-of select="CREDIT" />
								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
							</td>
						</xsl:when>
						<xsl:otherwise>
							<td class="summaryDetail" NOWRAP="" align="left">
								<xsl:value-of select="AMOUNT" />
								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
							</td>
						</xsl:otherwise>
					</xsl:choose>

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
