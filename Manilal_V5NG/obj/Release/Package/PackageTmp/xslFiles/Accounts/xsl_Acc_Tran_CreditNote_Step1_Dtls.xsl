<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
			<tr>
				<td nowrap="1" width="5px" class="header" >Action</td>
				<td nowrap="1" width="250px" class="header">JobNo</td>
				<td nowrap="1" width="200px" class="header">Packages</td>
				<td nowrap="1" width="200px" class="header">PropWt</td>
			</tr>
			<xsl:for-each select="//NewDataSet/Table1">
				<tr class="row">
					<td class="summaryDetail"  align="left">
						<img src="../../include/img/edit_item.gif" class="cur"  onclick="fnEdit_Acc_CreditNoteJobno_Dtls('{pk_tblIndex}','{jobno}','{packages}','{propwt}')" alt="Edit Job no. Details {jobno}"/>
						<img src="../../include/img/thrash.gif" class="cur"  onclick="fnDelete_Acc_CreditNoteJobno_Dtls('{pk_tblIndex}','{jobno}')" alt="Delete Job no. Details {jobno}"/>
					</td>
					<td class="content" align="left">
						<xsl:value-of select="jobno" />
					</td>
					<td class="content" align="left">
						<xsl:value-of select="packages" />
					</td>
					<td class="content" align="left">
						<xsl:value-of select="propwt" />
					</td>

				</tr>
			</xsl:for-each>
			<tr valign="top">
				<td colspan="5" class="foot">
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
