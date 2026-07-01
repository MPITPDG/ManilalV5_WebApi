<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="100%">
			<tr class="DataGridFixedHeader">
				<!--<xsl:if test="count(//NewDataSet/Table)!=0">
					<xsl:for-each select="//NewDataSet/Table">
						<xsl:choose>
							<xsl:when test="AUTHORISATIONSTATUS='U'">-->
								<td nowrap="1" width="40px" class="header" >Verified</td>
								<td nowrap="1" width="40px" class="header" >Rejected</td>
							<!--</xsl:when>
						</xsl:choose>
					</xsl:for-each>
				</xsl:if>-->
				<td nowrap="1" width="100px" class="header">JOBNO</td>
				<td nowrap="1" width="150px" class="header">Account Name</td>
				<td nowrap="1" width="80px" class="header">Amount</td>
				<td nowrap="1" width="60px" class="header">Type</td>
				<td nowrap="1" width="100px" class="header">Supplier</td>
				<td nowrap="1" width="100px" class="header">Our Truck</td>
				<td nowrap="1" width="100px" class="header">Remarks</td>
				<!--<td nowrap="1" width="150px" class="header">AUTHORISED BY</td>
				<td nowrap="1" width="120px" class="header">AUTHORISED ON</td>-->
				<!--<td nowrap="1" width="150px" class="header">IP ADDRESS</td>-->
			</tr>

			<xsl:for-each select="//NewDataSet/Table">
				<tr class="summaryDetail">
					<!--<xsl:choose>
						<xsl:when test="AUTHORISATIONSTATUS='U'">-->
							<td class="summaryDetail"  align="center" >
								<!--<img src="../../include/img/verified-mo.gif" class="cur"  onclick="parent.fnUpdate_Provision_Authorisation('{ID}','{PRO_JOBNO}')" alt="Authorise Job no. {PRO_JOBNO}"/>-->
                						<input type="button" value="Verify"  onclick="parent.fnUpdate_Provision_Authorisation('{ID}','{PRO_JOBNO}')" title="Authorise Job no. {PRO_JOBNO}"></input>
							</td>
							<td class="summaryDetail"  align="center" >
								<!--<img src="../../include/img/rejected.gif" class="cur"  onclick="parent.fnReject_Provision_Authorisation('{ID}','{PRO_JOBNO}')" alt="Reject Job no. {ID}" />-->
                						<input type="button" value="Reject"  onclick="parent.fnReject_Provision_Authorisation('{ID}','{PRO_JOBNO}')" title="Reject Job no. {PRO_JOBNO}"></input>
							</td>
						<!--</xsl:when>
					</xsl:choose>-->
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="PRO_JOBNO" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="ACCOUNT_NAME" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" style="text-align:right;">
						<xsl:value-of select="AMOUNT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="PRO_TYPE" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="SUPPLIER_NAME" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" style="text-align:right;">
						<xsl:value-of select="OUR_TRUCK" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="REMARK" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>

					<!--<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="AUTHOSISEDBY" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="AUTHOSISEDON" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>-->
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
