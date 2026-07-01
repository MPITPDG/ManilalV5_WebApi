<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
			<tr class="DataGridFixedHeader">
				
				<td nowrap="1" width="100px" class="header">DELVERY NO</td>
				<td nowrap="1" width="80px" class="header">JOBNO</td>
				<td nowrap="1" width="80px" class="header">IMPORTER</td>
				<td nowrap="1" width="80px" class="header">MODE</td>
				<td nowrap="1" width="80px" class="header">ACTUAL ARRIVAL</td>
				<td nowrap="1" width="120px" class="header">DESTINATION</td>
				<td nowrap="1" width="120px" class="header">ACTUAL DELIVERY</td>

				<td nowrap="1" width="80px" class="header">DESTINATAIRE</td>
				<td nowrap="1" width="80px" class="header">STATUT DUANE</td>
        <td nowrap="1" width="80px" class="header">TARIF</td>
        <td nowrap="1" width="80px" class="header">DELIVERY BY</td>

			</tr>
			<xsl:for-each select="//NewDataSet/Table2">

				<tr class="summaryDetail">
					
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="DELIVERYNO" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="JOBNO" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="IMPORTER_NAME" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="MODE" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="ACTUAL_ARRIVAL" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">

						<xsl:value-of select="DESTINATION" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="RDV_ACTUAL" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>

					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="DESTINATAIRE" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="STATUT_DUANE" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
          <td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="TARIF" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
          <td class="summaryDetail" NOWRAP="" align="left">
						<xsl:value-of select="DELIVERY_By" />
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>

				</tr>
			</xsl:for-each>
			<tr valign="top">
				<td colspan="11" class="foot">
					<xsl:if test="count(//NewDataSet/Table2)!=1">
						<xsl:value-of select="count(//NewDataSet/Table2)"/> Records
					</xsl:if>
					<xsl:if test="count(//NewDataSet/Table2)=1">
						1 Record
					</xsl:if>
				</td>
			</tr>
		</table>
	</xsl:template>
</xsl:stylesheet>



