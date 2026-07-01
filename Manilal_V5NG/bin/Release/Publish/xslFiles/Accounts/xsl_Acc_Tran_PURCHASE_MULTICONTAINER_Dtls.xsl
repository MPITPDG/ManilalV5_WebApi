<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
			<tr class="DataGridFixedHeader">
				<td nowrap="1" width="60px" class="header" ></td>
				<td nowrap="1" width="100px" class="header">Account Name</td>
				<td nowrap="1" width="80px" class="header">Amount</td>
				<!--<td nowrap="1" width="80px" class="header">Deduction</td>-->
				<td nowrap="1" width="80px" class="header">Item</td>
				<td nowrap="1" width="120px" class="header">Container No</td>
				<td nowrap="1" width="80px" class="header">Narration</td>

			</tr>
			<xsl:for-each select="//NewDataSet/Table">

				<tr class="summaryDetail">
					<td class="summaryDetail"  align="center" >
						<img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_PURCHASE_MultiContainer_Dtls('{ID}','{CLIENT}','{JOBNO}','{AMOUNT}','{DEDUCTION}','{NARRATION}','{ITEMCODE}','{VGUID}','{ACCOUNT_NAME}','{ITEM}','{ITEM_DATAVALUE}','{ACC_PUR_MCONT_ID}','{ISJOBREPORT}')" alt="Edit Details {ACCOUNT_NAME}"/>
						<img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fnDelete_PURCHASE_MultiContainer_Dtls('{ID}','{VGUID}','{ACC_PUR_MCONT_ID}')" alt="Delete Details {ACCOUNT_NAME}" />
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="ACCOUNT_NAME" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="AMOUNT" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<!--<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="DEDUCTION" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>-->
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="ITEM" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="JOBNO" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="NARRATION" />
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
