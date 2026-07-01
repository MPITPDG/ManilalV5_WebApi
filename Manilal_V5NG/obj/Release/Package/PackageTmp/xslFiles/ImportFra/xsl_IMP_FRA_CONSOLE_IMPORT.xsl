<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<head>
				<link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />

				<script language="javascript">
					function fnOpenV(_url) {
					if (_url != 'TOTAL:') {
					var oWin = window.open(_url, 'OP', 'toolbar=no,menubar=yes,width=790,height=450,top=100,left=300,scrollbars=yes');
					oWin.focus();
					if (oWin == null || typeof (oWin) == "undefined") alert("window failed to open");
					}
					return false;
					}

				</script>
				<script src="../jsFiles/ImportFra/js_Imp_Fra_Console_Import.js" type="text/javascript"></script>
			</head>
			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0"  >
				<div id="tableContainer" class="divSpace" style="width:750px" >
					<table cellpadding="0" cellspacing="0" width="748px" border="0" bordercolor="white" class="infotable">
						<xsl:for-each select="//NewDataSet/Table">
							<xsl:variable name="Mode" select="MODE"></xsl:variable>


							<xsl:if test ="$Mode='Sea'">
								<tr class="DataGridFixedHeader">
									<td width="40px" style="text-align:center" >
										ContainerNo
									</td>
									<td width="20px" style="text-align:center;">
										OriginCity
									</td>
									<td width="80px"  style="text-align:center;">
										Rotation No
									</td>
									<td width="90px"  style="text-align:center;">
										Vessel Name
									</td>
									<td width="25px" style="text-align:center;">
										Voyage No
									</td>
									<td width="25px" style="text-align:center;">
										Etd
									</td>
									<td width="25px" style="text-align:center;">
										Sailing
									</td>
									<td width="100px" style="text-align:center;">
										Agent_Name
									</td>
								</tr>
								<xsl:for-each select="//NewDataSet/Table1">

									<xsl:variable name="STATUS" select="STATUS"></xsl:variable>
									<tr>
										<td class="summaryDetail" width="40px">
											<xsl:if test="$STATUS = '100'">
												<a onclick="javascript:parent.SEA_Console_Generation('{CONTAINERNO}','{VSL_RTNO}','{ORIGINCITY}');" style="color:Blue;cursor:hand;Font-Underline=True;">

													<xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</a>
											</xsl:if>
											<xsl:if test="$STATUS = '103'">
												<xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</xsl:if>
										</td>
										<td class="summaryDetail" width="20px">
											<xsl:value-of select="ORIGINCITY" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<td class="summaryDetail" width="40px">
											<xsl:value-of select="VSL_RTNO" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<td class="summaryDetail" width="90px">
											<xsl:value-of select="VSL_NAME" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<td class="summaryDetail" width="25px">
											<xsl:value-of select="VSL_VOYNO" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<td class="summaryDetail" width="25px">
											<xsl:value-of select="ETD" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<td class="summaryDetail" width="25px">
											<xsl:value-of select="SAILING" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<td class="summaryDetail" width="100px">
											<xsl:value-of select="AGT_NAME" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
									</tr>
								</xsl:for-each>
							</xsl:if>
							<xsl:if test="$Mode='Air'">
								<tr class="DataGridFixedHeader">
									<td width="50px" style="text-align:center" >
										MAWBNO
									</td>
									<td width="40px" style="text-align:center;">
										HAWBNO
									</td>
									<td width="80px"  style="text-align:center;">
										PKGS
									</td>
									<td width="90px"  style="text-align:center;">
										WEIGHT
									</td>
									<td width="40px" style="text-align:center;">
										VOLUME/WT.
									</td>
								</tr>
								<xsl:for-each select="//NewDataSet/Table1">
									<tr>
										<td class="summaryDetail" width="40px">
											<a onclick="javascript:parent.AIR_Console_Generation('{AEROBILLNO}');" style="color:Blue;cursor:hand;Font-Underline=True;">
												<xsl:value-of select="AEROBILLNO" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</a>
										</td>
										<td class="summaryDetail" width="20px">
											<xsl:value-of select="HOUSEBILLNO" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<!--<td class="summaryDetail" width="20px">
											<xsl:value-of select="HOUSEBILLDT" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>-->
										<td class="summaryDetail" width="20px">
											<xsl:value-of select="EXPT_NOOFPKGS" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<td class="summaryDetail" width="20px">
											<xsl:value-of select="EXPT_GRWT" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<td class="summaryDetail" width="20px">
											<xsl:value-of select="EXPT_VOLUME" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
									</tr>
								</xsl:for-each>
							</xsl:if>
						</xsl:for-each>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
