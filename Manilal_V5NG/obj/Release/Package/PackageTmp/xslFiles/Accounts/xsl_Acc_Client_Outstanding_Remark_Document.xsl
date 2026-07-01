<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<script language="javascript" type="text/javascript">
			function fn_Open(FileName)
			{
			if(FileName != '')
			{
			url = '../../DATA/OUTSTANDING_REMARK/'+document.getElementById(FileName).value
			window.open(url)
			}
			}
		</script>
		<div id="tableContainer">
			<table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" style="width: 100%;">
				<tr class="DataGridFixedHeader">
					<xsl:variable name="ADMIN" select="//NewDataSet/Table/ISADMIN[1]"></xsl:variable>
					<xsl:variable name="PK_ID" select="//NewDataSet/Table/PK_ID[1]"></xsl:variable>
					<xsl:variable name="DOCUMENTNAME" select="//NewDataSet/Table/ACTUAL_FILE_NAME[1]"></xsl:variable>
					<xsl:variable name="CLIENT_CODE" select="//NewDataSet/Table/CLIENT_CODE[1]"></xsl:variable>
					<xsl:if test ="$ADMIN='Y'">
						<td nowrap="1" class="header">
							<img id="imgDel_{$PK_ID}" src="../../include/img/thrash.gif" alt="" width="12px" height="12px" onclick="javascript:parent.fnDleteAllRemarks('{PK_ID}','{$DOCUMENTNAME}','{$CLIENT_CODE}')" style="cursor:hand;" />
						</td>
					</xsl:if>
					<td nowrap="1" class="header">Remark</td>
					<td nowrap="1" class="header">File Name</td>
					<td nowrap="1" class="header">Actual File Name</td>
					<td nowrap="1" class="header">User Name</td>
					<td nowrap="1" class="header">Date Time</td>
				</tr>
				<xsl:for-each select="//NewDataSet/Table">
					<tr class="summaryDetail">
						<xsl:if test="ISADMIN='Y'">
							<td nowrap="1" class="header">
								<img id="imgDel_{PK_ID}" src="../../include/img/thrash.gif" alt="" width="12px" height="12px" onclick="javascript:parent.fnDleteRemark('{PK_ID}','{ACTUAL_FILE_NAME}','{CLIENT_CODE}')" style="cursor:hand;" />
							</td>
						</xsl:if>
						<td class="summaryDetail" NOWRAP="" align="left">
							<xsl:value-of select="REMARKS" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td nowrap="1" class="header">
							<xsl:value-of select="SYSTEM_FILE_NAME" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td class="summaryDetail" NOWRAP="" align="left">
							<A onclick="javascript:fn_Open('hd{PK_ID}');" style="color:blue;cursor:hand;text-decoration: underline;">
								<xsl:value-of select="ACTUAL_FILE_NAME" />
							</A>
							<input type="hidden" id="hd{PK_ID}" runat="server" value="{ACTUAL_FILE_NAME}"/>
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						
						<!--<td nowrap="1" class="header">
							<xsl:value-of select="ACTUAL_FILE_NAME" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>-->
						<td class="summaryDetail" NOWRAP="" align="left">
							<xsl:value-of select="USERNAME" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
						<td class="summaryDetail" NOWRAP="" align="left">
							<xsl:value-of select="MAKER_TIMESTAME" />
							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
						</td>
					</tr>
				</xsl:for-each>
				<tr valign="top">
					<td colspan="6" class="foot">
						<xsl:if test="count(//NewDataSet/Table)!=1">
							<xsl:value-of select="count(//NewDataSet/Table)"/> Files
						</xsl:if>
						<xsl:if test="count(//NewDataSet/Table)=1">
							1 File
						</xsl:if>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
</xsl:stylesheet>
