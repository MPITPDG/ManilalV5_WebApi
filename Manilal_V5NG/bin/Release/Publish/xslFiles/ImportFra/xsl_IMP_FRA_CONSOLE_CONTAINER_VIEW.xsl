<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
	<xsl:template match='/'>
		<html>
			<head>
				<link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
			</head>

			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" >
				<div id="tableContainer" class="divSpace" align="center" style="width:100%" >
					<table border='0' cellpadding='1' cellspacing='1' width='698px'>
						<xsl:for-each select="//NewDataSet/Table1">
							<xsl:variable name="OTHERCUR_NAME" select="OTHERCUR_NAME"></xsl:variable>
							<xsl:variable name="OTHERCUR_NAME1" select="OTHERCUR_NAME1"></xsl:variable>
							<xsl:variable name="DIRECTVSL" select="DIRECTVSL"></xsl:variable>
							<tr>
								<td class="lblNormal_xslt" width="200px">
									Container No
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px">
									Container Size
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="CONTAINERSIZE" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px">
									Status Of Container
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="CONTAINERSTATUS" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px">
									Destination Port
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="DESTPORT" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px">
									Steamer Agent Steal No.
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="AGTSEALNO" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px">
									Custom Seal No.
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="CUSTSEALNO" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px">
									Freight
								</td>
								<td class="summaryDetail_xslt"  >
									<xsl:value-of select="FREIGHTUSD" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px">
									BAF
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="BAFCUR" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px" >
									Remarks
								</td>
								<td class="summaryDetail_xslt"  colspan="3">
									<xsl:value-of select="REMARK" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>

							</tr>
							<xsl:if test="OTHERCUR_NAME!=' '">
								<tr>
									<td class="summaryDetail_xslt"  coslspan="4">
										OTHER CHARGES
									</td>
								</tr>
								<tr>
									<td class="summaryDetail_xslt"   clospan="1">
										<xsl:value-of select="OTHERNAME" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>

								</tr>
							</xsl:if>
							<xsl:if test="OTHERCUR_NAME1!=' '">
								<tr>
									<td class="summaryDetail_xslt"  coslspan="4">
										OTHER CHARGES
									</td>
								</tr>
								<tr>
									<td class="summaryDetail_xslt"   clospan="1">
										<xsl:value-of select="OTHERCUR_NAME1" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail_xslt" width="200px"  clospan="1">
										<xsl:value-of select="OTHERAMT1" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
							</xsl:if>
							
								<tr>
									<xsl:if test="DIRECTVSL='DIRECT'">
									<td class="lblNormal_Cont_view"  colspan="4" >
										<xsl:value-of select="DIRECTVSL" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									</xsl:if>
								</tr>
							
							<xsl:if test="DIRECTVSL='TRANSHIPMENT'">
								<tr>
									<td class="lblNormal_Cont_view"   colspan="3">
										<xsl:value-of select="DIRECTVSL" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_xslt" width="200px">
										Transhipment Port1
									</td>
									<td class="summaryDetail_xslt" width="200px">
										<xsl:value-of select="TRANSHIPMENTPORT1" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="lblNormal_xslt" width="200px">
										Connecting Vessel1
									</td>
									<td class="summaryDetail_xslt" width="200px">
										<xsl:value-of select="CONVESSEL1" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>

								</tr>
								<tr>
									<td class="lblNormal_xslt" width="200px">
										Voyage No
									</td>
									<td class="summaryDetail_xslt" width="200px">
										<xsl:value-of select="CONVESSEL1VOY1" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="lblNormal_xslt" width="200px">
										ETD(at transhipment port1)
									</td>
									<td class="summaryDetail_xslt" width="200px">
										<xsl:value-of select="ETDPORT1" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>

								</tr>
								<tr>
									<td class="lblNormal_xslt" width="200px">
										ETA
									</td>
									<td class="summaryDetail_xslt" width="200px">
										<xsl:value-of select="ETA1" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>


								</tr>
								<tr>
									<td class="lblNormal_xslt" width="200px">
										Transhipment Port2
									</td>
									<td class="summaryDetail_xslt" width="200px">
										<xsl:value-of select="TRANSHIPMENTPORT2" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="lblNormal_xslt" width="200px">
										Connecting Vessel2
									</td>
									<td class="summaryDetail_xslt" width="200px">
										<xsl:value-of select="CONVESSEL2" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>

								</tr>
								<tr>
									<td class="lblNormal_xslt" width="200px">
										Voyage No
									</td>
									<td class="summaryDetail_xslt" width="200px">
										<xsl:value-of select="CONVESSEL1VOY2" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="lblNormal_xslt" width="200px">
										ETD(at transhipment port2)
									</td>
									<td class="summaryDetail_xslt" width="200px">
										<xsl:value-of select="ETDPORT2" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>

								</tr>
								<tr>
									<td class="lblNormal_xslt" width="200px">
										ETA
									</td>
									<td class="summaryDetail_xslt" width="200px">
										<xsl:value-of select="ETA2" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
							</xsl:if>
							<tr>
								<td class="lblNormal_Cont_view" colspan="4">
									EXCHANGE RATES
								</td>

							</tr>
							<tr>
								<td colspan="4">
									<table border='0' cellpadding='1' cellspacing='1' width='100%'>

										<tr class="DataGridFixedHeader">
											<td class="header"> </td>
											<td class="header">Currency</td>
											<td class="header">Value</td>

											<td class="header">Currency</td>
											<td class="header">Value</td>

										</tr>
										<tr>
											<td class="lblNormal_xslt">Origin Port</td>

											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="OGN_CURR_NAME1" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="OCURRATE1" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>

											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="OGN_CURR_NAME2" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="OCURRATE2" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<tr>
											<td class="lblNormal_xslt">Destination Port</td>

											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="DEST_CURR_NAME1" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="DCURRATE1" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>

											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="DEST_CURR_NAME2" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="DCURRATE2" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>

									</table>

								</td>

							</tr>
						</xsl:for-each>
						<tr>
							<td colspan="4">
								<table border='0' cellpadding='1' cellspacing='1' width='100%'>

									<tr class="DataGridFixedHeader">

										<td class="header">JOBNO</td>
										<td class="header">NOOFPKGS</td>

										<td class="header">CBM</td>
										<td class="header">CLPSEQUENCE</td>

									</tr>
									<xsl:for-each select="//NewDataSet/Table2">
										<TR>

											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="JOBNO" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="NOOFPKGS" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>

											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="CBM" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="CLPSEQUENCE" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</TR>
									</xsl:for-each>
								</table>
							</td>

						</tr>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>

