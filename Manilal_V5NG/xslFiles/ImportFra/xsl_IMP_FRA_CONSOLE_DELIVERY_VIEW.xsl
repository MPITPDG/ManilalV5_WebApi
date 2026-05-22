<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
	<xsl:template match='/'>
		<html>
			<head>
				<link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
			</head>

			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" >
				<div id="tableContainer" class="divSpace" align="center" style="width:100%" >
					<table border='0' cellpadding='1' cellspacing='1' width='750px'>
						<xsl:for-each select="//NewDataSet/Table1">
							<xsl:variable name="KEYFIELD" select="KEYFIELD"></xsl:variable>
							<xsl:variable name="DEORDER" select="DORDER"></xsl:variable>
							<tr>
								<td class="lblNormal_xslt" >
									Delivery No.
								</td>
								<td class="summaryDetail_xslt" colspan="3">
									<xsl:value-of select="DELIVERYNO" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>

							</tr>
							<tr>
								<td class="lblNormal_xslt" >
									Client
								</td>
								<td class="summaryDetail_xslt"   colspan="3">
									<xsl:value-of select="CON_NAME" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>

						</xsl:for-each>
						<tr>
							<td class="lblNormal_xslt" colspan="4">
								<table border='0' cellpadding='1' cellspacing='1' width='100%'>
									<xsl:if test="KEYFIELD='containerno'">

										<tr>
											<td class="lblNormal_xslt" width="50px">
												Container No.
											</td>
											<td class="lblNormal_xslt" width="20px">
												Size
											</td>
											<td class="lblNormal_xslt" width="30px">
												Pkgs
											</td>
											<td class="lblNormal_xslt" width="30px">
												CBM
											</td>
											<td class="lblNormal_xslt" width="70px">
												Vessel
											</td>
											<td class="lblNormal_xslt" width="100px">
												Liner
											</td>
										</tr>
										<xsl:for-each select="//NewDataSet/Table2">
											<tr>
												<td class="summaryDetail_xslt"   >
													<xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"  >
													<xsl:value-of select="CONTSIZE" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"  >
													<xsl:value-of select="NOOFPKGS" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"  >
													<xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"  >
													<xsl:value-of select="VESSEL" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt" >
													<xsl:value-of select="LINER" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
										</xsl:for-each>
									</xsl:if>
									<xsl:if test="KEYFIELD='MAWBNO'">

										<tr>
											<td class="lblNormal_xslt" width="50px">
												Mawbno
											</td>
											<td class="lblNormal_xslt" width="20px">
												Pkgs
											</td>
											<td class="lblNormal_xslt" width="30px">
												Weight
											</td>
											<td class="lblNormal_xslt" width="30px">
												HawbNo
											</td>
											<td class="lblNormal_xslt" width="50px">
												OrderNo
											</td>
										</tr>
										<xsl:for-each select="//NewDataSet/Table2">
											<tr>
												<td class="summaryDetail_xslt"  >
													<xsl:value-of select="MAWBNO" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"   >
													<xsl:value-of select="NOOFPKGS" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"    >
													<xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"   >
													<xsl:value-of select="HAWBNO" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"    >
													<xsl:value-of select="ORDERNO" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
										</xsl:for-each>
									</xsl:if>
									<xsl:if test="KEYFIELD ='JOBNO'or'FCRNO'or'HAWBNO'">

										<tr>
											<td class="lblNormal_xslt" width="30px">
												JobNo
											</td>
											<td class="lblNormal_xslt" width="30px">
												HBL/HawbNo
											</td>
											<td class="lblNormal_xslt" width="30px">
												Date
											</td>
											<td class="lblNormal_xslt" width="40px">
												Pkgs
											</td>
											<td class="lblNormal_xslt" width="40px">
												Weight
											</td>
											<td class="lblNormal_xslt" width="40px">
												Volume
											</td>
											<td class="lblNormal_xslt" width="40px">
												Freight
											</td>
										</tr>
										<xsl:for-each select="//NewDataSet/Table2">
											<tr>
												<td class="summaryDetail_xslt"  >
													<xsl:value-of select="JOBNO" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt" >
													<xsl:value-of select="HAWBNO" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"    >
													<xsl:value-of select="HAWBDT" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"    >
													<xsl:value-of select="PKGS" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"   >
													<xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt"   >
													<xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt" >
													<xsl:value-of select="FREIGHT" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>

											</tr>
										</xsl:for-each>
									</xsl:if>
								</table>
							</td>
						</tr>
						<xsl:for-each select="//NewDataSet/Table1">
							<xsl:if test="DEORDER='agt'">
								<tr>
									<td class="lblNormal_xslt"  colspan="2">
										D/O GIVEN TO CONSIGNEE'S AGENT :
									</td>
									<td class="summaryDetail_xslt"   colspan="2">
										<xsl:value-of select="AGTNAME" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
							</xsl:if>
							
							<xsl:if test="DEORDER='consg'">
								<tr>
									<td class="lblNormal_xslt" colspan="2">
										CARGO COLLECTED BY CONSIGNEE (PLACE FROM WHERE THEY COLLECTED THE
										CARGO) :
									</td>
								</tr>
								<tr>
									<td class="summaryDetail_xslt" colspan="2">
										<xsl:value-of select="CONSGPLACE" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_xslt"   colspan="2">
										TRANSPORTER
									</td>
									<td class="summaryDetail_xslt" colspan="2">
										<xsl:value-of select="AGTNAME" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
							</xsl:if>
							<xsl:if test="DEORDER!='consg'or'agt'">
								<tr>
									<td class="lblNormal_xslt"   colspan="2">
										DELIVERED TO CONSINGEE :
									</td>
								</tr>
								<tr>
									<td class="summaryDetail_xslt"   colspan="2">
										<xsl:value-of select="CONSGPLACE" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_xslt"   colspan="2">
										TRANSPORTER
									</td>
									<td class="summaryDetail_xslt"  colspan="2">
										<xsl:value-of select="AGTNAME" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
								<tr>
									<td class="lblNormal_xslt"   colspan="2">
										Delivery Address
									</td>
									<td class="summaryDetail_xslt" colspan="2">

										<xsl:value-of select="ADD1" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										<br></br>
										<xsl:value-of select="ADD2" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										<br></br>
										<xsl:value-of select="ADD3" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										<br></br>
										<xsl:value-of select="PINCODE" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										<br></br>
										<xsl:value-of select="CITY" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										<br></br>
										<xsl:value-of select="COUNTRY" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										<br></br>
										<xsl:value-of select="TELEPHONE" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										<br></br>
										<xsl:value-of select="FAX" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										<br></br>
										<xsl:value-of select="CONTACTPERSON" disable-output-escaping="yes"/>
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>

									</td>
								</tr>
							</xsl:if>
						</xsl:for-each>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
