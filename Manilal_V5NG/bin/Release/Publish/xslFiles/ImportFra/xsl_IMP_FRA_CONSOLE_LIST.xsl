<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
		<html>
			<head>
				<link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />

				 
			</head>

			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
				<div id="tableContainer" class="divSpace" style="width:100%" >
					<table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
						<tr class="DataGridFixedHeader">
							<td nowrap="1" width="100px" class="header">Console No</td>
							<td nowrap="1" width="100px" class="header">Date</td>
							<td nowrap="1" width="100px" class="header">Mode</td>
							<td nowrap="1" width="100px" class="header">Sent From</td>
							<td nowrap="1" width="100px" class="header">Destination</td>
							<td nowrap="1" width="100px" class="header">ETA</td>
							<td nowrap="1" width="100px" class="header">NoofPkgs</td>
							<td nowrap="1" width="100px" class="header">Type Of Pkgs</td>
							<td nowrap="1" width="100px" class="header">Weight</td>
							<td nowrap="1" width="100px" class="header">Volumet</td>
							<td nowrap="1" width="100px" class="header">Shipping Line</td>
							<td nowrap="1" width="100px" class="header">MAWB No</td>
							<td nowrap="1" width="100px" class="header">MAWB Date</td>
						</tr>
						<xsl:for-each select="//NewDataSet/Table1">
							<tr class="summaryDetail">

								<td class="summaryDetail" NOWRAP="" align="left">
									<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Consolelist('{CONSOLENO}')">
										<xsl:value-of select="CONSOLENO" />
									</label>
									<!--<xsl:value-of select="CONSOLENO"  onclick="parent.fnDelete_Job_Det('{CONSOLENO}')"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>-->
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="CONSOLEDT" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="MODE" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="SENTFROM" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="DESTINATION" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="ETA" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="NOOFPKGS" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="TYPEOFPKGS" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="WEIGHT" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="VOLUME" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="SUP_NAME" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="MAWBNO" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail" NOWRAP="" align="left">
									<xsl:value-of select="MAWBDT" />
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


