<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
	<xsl:template match='/'>
		<html>
			<head>
				<link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
			</head>

			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
				<div id="tableContainer" class="divSpace" style="width:100%" >
					<table border='0' cellpadding='1' cellspacing='1' width='740px'>
						<xsl:for-each select="//NewDataSet/Table1">
							<xsl:variable name="Mode" select="MODE"></xsl:variable>
							<tr>
								<td class="lblNormal_console">
									Console No
								</td>

								<td  class="summaryDetail">
									<xsl:value-of select="CONSOLENO" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>

								<td class="lblNormal_console">
									Mode
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="MODE" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_console">
									Consolidation Sent From
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="SENTFROM" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_console">
									Agent
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="AGENT" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<xsl:if test="$Mode='SEA'">
								<tr>
									<td class="lblNormal_console">
										Shipping Line
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="SHIPPINGLINE" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="lblNormal_console">
										Vessel
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="VESSEL" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_console">
										Voyage
									</td>
									<td   class="summaryDetail">
										<xsl:value-of select="VOYAGENO" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>

									<td class="lblNormal_console">
										Sailed On
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="SAILING" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_console">
										MB/L No.
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="MBLNO" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								
									<td class="lblNormal_console">
										Date
									</td>
									<td  class="summaryDetail">
										<xsl:value-of select="MBLDT" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
							</xsl:if>
							<xsl:if test="$Mode='AIR'">
								<tr>
									<td class="lblNormal_console" >
										Airline Name
									</td>
									<td colspan="3" class="summaryDetail">
										<xsl:value-of select="AIRLINE" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_console" >
										Flight No
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="FLIGHTNO" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="lblNormal_console" >
										Flight Date
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="FLIGHTDT" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_console" >
										Actual Flight No
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="ACTUALFLIGHTNO" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="lblNormal_console" >
										Actual Flight Date
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="ACTUALFLIGHTDT" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_console" >
										MAWB No
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="MAWBNO" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="lblNormal_console" >
										Date
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="MAWBDT" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_console" >
										CO2 Emition Level
									</td>
									<td class="summaryDetail" colspan="3">
										<xsl:value-of select="CO2_EMITION_LVL" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
							</xsl:if>
							<xsl:if test="Mode='OTHER'">
								<tr>
									<td class="lblNormal_console" >
										By
									</td>
									<td colspan="2" class="summaryDetail">
										<xsl:value-of select="TRANSPORTBY" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_console" >
										Transporter
									</td>
									<td colspan="2" class="summaryDetail">
										<xsl:value-of select="TRANSPORTER" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_console" >
										Cargo Note
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="CARGONOTE" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="lblNormal_console" >
										Cargo Date
									</td>
									<td class="summaryDetail">
										<xsl:value-of select="CARGONOTEDT" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
							</xsl:if>
							<tr>
								<td class="lblNormal_console" >
									Packages
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="NOOFPKGS" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_console" >
									Type of pkgs
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="TYPEOFPKGS" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_console" >
									Weight kgs
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_console" >
									Volume
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_console" >
									CHBL Wt
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="CHBLWT" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_console" >
									ETA
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="ETA" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_console" >
									VIA
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="VIA" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_console" >
									House B/L Issued
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="HOUSEBL" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_console" >
									Freight
								</td>
								<td colspan="3" class="summaryDetail">
									<xsl:value-of select="FREIGHT" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_console" >
									Remark
								</td>
								<xsl:if test="$Mode='AIR'">
									<td colspan="3" class="summaryDetail">
										<xsl:value-of select="REMARK" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</xsl:if>
								<xsl:if test="$Mode='SEA'">
									<td colspan="2" class="summaryDetail">
										<xsl:value-of select="REMARK" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</xsl:if>

								<xsl:if test="$Mode='SEA'">
									<td class="summaryDetail" >
										<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_containerview('{CONSOLENO}')">
											EDIT CONTAINER
										</label>

									</td>
								</xsl:if>
							</tr>
							<tr>
								<td class="summaryDetail"  colspan="4">
									<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_MAIN('{CONSOLENO}','{$Mode}')">
										EDIT MAIN DETAIL
									</label>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
