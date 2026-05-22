<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
		<html>
			<head>
				<link href="../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
			</head>

			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
				<div id="tableContainer" class="divSpace" style="width:100%" >
					<table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
						<tr class="DataGridFixedHeader">
							 
							<td nowrap="1" width="200px" class="header">Shipper</td>
							<td nowrap="1" width="200px" class="header">Consignee</td>
							
							<td nowrap="1" width="100px" class="header">Exp.Cargo Recd</td>
							<td nowrap="1" width="100px" class="header">Invoice No</td>
							<td nowrap="1" width="250px" class="header">Port Of Discharge</td>
							<td nowrap="1" width="250px" class="header">Destination</td>
							<td nowrap="1" width="100px" class="header">Freight</td>
							 
						</tr>
						 
							<xsl:for-each select="//NewDataSet/Table1">
								<tr class="summaryDetail">
									 
									<td class="summaryDetail" NOWRAP="" align="left">
										<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Viewlist('{ID}')">
											<xsl:value-of select="SHIPPER" />
										</label>
										
										<!--<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>-->
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="CON_NAME" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="CARGORECD" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="INVNO" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="POD" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="DESTINATION" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="FREIGHT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
							</xsl:for-each>						 
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
