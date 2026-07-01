<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
			<tr>
				<td nowrap="1" width="150px" class="header">Account Name</td>
				<td nowrap="1" width="150px" class="header">Item Name</td>
				<td nowrap="1" width="150px" class="header">Container No</td>
				<td nowrap="1" width="150px" class="header">Amount</td>
				<td nowrap="1" width="150px" class="header" >Narration</td>
				<td nowrap="1" width="5px" class="header" ></td>
			</tr>
			<xsl:for-each select="//NewDataSet/Table1">
				<tr class="row">
					<td class="content" align="left">
						<xsl:value-of select="AcctName" />
					</td>
					<td class="content" align="left">
						<xsl:value-of select="ItemName" />
					</td>
					<td class="content" align="left">
						<xsl:value-of select="ContainerNo" />
					</td>
					<td class="content" align="left">
						<xsl:value-of select="Amount" />
					</td>
					<td class="content" align="left">
						<xsl:value-of select="Narration" />
					</td>
					<td class="content"  align="center">
						<img src="../../include/img/edit_item.gif" class="cur"  onclick="fnEdit_Account_Dtls('{pk_tblIndex}','{AcctCode}','{AcctName}','{ContainerNo}','{Amount}','{Narration}','{ItemCode}','{ItemDate}','{ItemName}')" alt="Edit Details {ContainerNo}"/>
						<img src="../../include/img/thrash.gif" class="cur"  onclick="fnDelete_Account_Dtls('{pk_tblIndex}','{ContainerNo}','{Amount}')" alt="Delete Details{ContainerNo}"/>
					</td>
				</tr>
			</xsl:for-each>
			<tr valign="top">
				<td colspan="6" class="foot">
					<xsl:if test="count(//NewDataSet/Table1)!=1">
						<xsl:value-of select="count(//NewDataSet/Table1)"/> Records
					</xsl:if>
					<xsl:if test="count(//NewDataSet/Table1)=1">
						1 Record
					</xsl:if>
				</td>
			</tr>
		</table>
		<table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

		</table>

	</xsl:template>
</xsl:stylesheet>
