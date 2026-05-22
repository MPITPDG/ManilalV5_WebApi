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
						<tr class="DataGridHeader_xslt">
							<td colspan ='4' class="header">
								General Details
							</td>
						</tr>
						<xsl:for-each select="//NewDataSet/Table2">
							<tr  >
								<td class="lblNormal_xslt" width="200px">
									Invoice No
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_no" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px">
									Invoice Date
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_date" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
						</xsl:for-each>
						<tr class="DataGridHeader_xslt">
							<td colspan ='4' class="header">
								Job Details
							</td>
						</tr>
						<tr>
							<td height="3px"></td>
						</tr>

						<tr class="DataGridHeader_xslt">
							<td colspan ='4' align="left">
								<table border='0' cellpadding='1'  cellspacing='1' width='750px' >
									<tr class="DataGridHeader_xslt">
										<td class="header">
											Job No
										</td>
										<td class="header">
											Packages
										</td>
										<td class="header">
											Prop.Weight
										</td>
									</tr>

									<xsl:for-each select="//NewDataSet/Table1">
										<xsl:variable name="TotalAmt" select="totalamt"></xsl:variable>
										<tr>
											<td class="summaryDetail_xslt">
												<xsl:value-of select="inv_jobno" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="summaryDetail_xslt">
												<xsl:value-of select="inv_pkgs" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="summaryDetail_xslt">
												<xsl:value-of select="inv_grwt" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
									</xsl:for-each>
								</table>
							</td>
						</tr>
						<tr class="DataGridHeader_xslt">
							<td colspan ='4' class="header" >
								Main Details
							</td>
						</tr>
						<xsl:for-each select="//NewDataSet/Table2">
							<tr>
								<td class="lblNormal_xslt" width="200px">
									Client Name
								</td>
								<td class="summaryDetail_xslt" colspan="3" width="200px">
									<xsl:value-of select="ClientName" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px" >
									Document Through
								</td>
								<td class="summaryDetail_xslt" colspan="3">
									<xsl:value-of select="ShipperName" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px">
									Bill Type
								</td>
								<td class="summaryDetail_xslt">
									<xsl:value-of select="inv_billtype" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px">
									Advanced Received
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_advance" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>

							<tr>
								<td class="lblNormal_xslt" width="200px">
									Number Of Packages
								</td>
								<td class="summaryDetail_xslt" width="200px" >
									<xsl:value-of select="inv_pkgs" disable-output-escaping="yes"/>- <xsl:value-of select="inv_typeofpkg" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px">
									Volume
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_vol" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px">
									Number Of Pieces
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_noofpcs" disable-output-escaping="yes"/>- <xsl:value-of select="inv_typeofpcs" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px" >
									Weight Kilo
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_wt" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px">
									Client Reference
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_clientref" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px">
									Carrier
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_carrier" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px">
									Goods
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_goods" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px">
									Service Tax Rate
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_tax" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px">
									HOUSE (A.W.B./B/L)
								</td>
								<td class="summaryDetail_xslt" width="200px">
									<xsl:value-of select="inv_hawbno" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="lblNormal_xslt" width="200px">
									Date
								</td>
								<td class="summaryDetail_xslt" width="200px" >
									<xsl:value-of select="inv_hawbdt" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr   >
								<td class="lblNormal_xslt" width="200px">
									Pay By Date
								</td>
								<td class="summaryDetail_xslt" colspan="3">
									<xsl:value-of select="PaybleByDt" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr>
								<td colspan ='4'></td>
							</tr>
							<tr class="DataGridHeader_xslt" width="200px">
								<td colspan ='4' class="header">
									Narration Details
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="200px">
									Narration
								</td>
								<td class="summaryDetail_xslt"  colspan="3" >
									<xsl:value-of select="narration" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>

							</tr>
							<tr class="DataGridHeader_xslt">
								<td colspan ='4' class="header">
									Currency Details
								</td>
							</tr>
							<tr>
								<td  class="lblNormal_xslt">
									Invoice Currency
								</td>

								<td  class="summaryDetail_xslt" colspan="3" >
									<xsl:value-of select="cur_name" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
							<tr class="lblNormal_xslt">
								<td class="lblNormal_xslt" colspan="4">
									Exchange Rate
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" >
									Rupees
								</td>


								<td  class="summaryDetail_xslt" >
									<xsl:value-of select="inv_currate" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td  class="summaryDetail_xslt" >
									<xsl:value-of select="cur_name" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>

								<td  class="summaryDetail_xslt" >
									<xsl:value-of select="inv_currate1" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>
						</xsl:for-each>
						<tr class="DataGridHeader_xslt">
							<td colspan ='4' class="header">
								Charges Details
							</td>
						</tr>
						<tr>
							<td height="3Px">

							</td>
						</tr>
						<tr class="DataGridHeader_xslt">
							<td colspan ='4' align="left">
								<table border='0' cellpadding='1'  cellspacing='1' width='750px' >
									<tr class="DataGridHeader_xslt">
										<td  class="Header"  align="left">
											Charg Code
										</td>
										<td  class="Header" align="left">
											Account Name
										</td>
										<td  class="Header" align="left">
											Description
										</td>
										<td  class="Header" align="left">
											Description
										</td>
										<td  class="Header" align="left">
											Tax
										</td>
										<td  class="Header" align="left">
											Amount
										</td>
										<td  class="Header" align="left">
											Taxable Amount
										</td>
									</tr>
									<xsl:for-each select="//NewDataSet/Table4">
										<tr>
											<td  class="summaryDetail_xslt" align="left" style="align:right">
												<xsl:value-of select="INV_CHRGCODE" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td  class="summaryDetail_xslt"  align="left">
												<xsl:value-of select="ACCTNAME" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td  class="summaryDetail_xslt" align="left">
												<xsl:value-of select="CHRG_DESC" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td  class="summaryDetail_xslt" align="left">
												<xsl:value-of select="INV_DESC" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td  class="summaryDetail_xslt" align="center" >
												<xsl:value-of select="INV_TAXABLE" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td  class="summaryDetail_Number_xslt"  >
												<xsl:value-of select="INV_AMOUNT" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td  class="summaryDetail_Number_xslt"   >
												<xsl:value-of select="TAXABLEAMT" disable-output-escaping="yes" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>

										</tr>
									</xsl:for-each>
									<xsl:for-each select="//NewDataSet/Table5">
										<tr>

											<td class="lblNumber_xslt" colspan="5">
												Total Taxable Amount
											</td>
											<td  class="lblNumber_xslt" align="right" >
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td  class="lblNumber_xslt" >
												<xsl:value-of select="TAXAMT" disable-output-escaping="yes" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<tr>
											<td class="lblNumber_xslt" colspan="5">
												Total Non Taxable Amount
											</td>
											<td  class="lblNumber_xslt" align="right" >
												<xsl:value-of select="NONTAXABLEAMT" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											
											<td  class="lblNumber_xslt" align="right">
												
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<tr>
											<td class="lblNumber_xslt" colspan="5">
												Total Invoice Amount
											</td>
											<td  class="lblNumber_xslt" align="right">
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td  class="lblNumber_xslt" >
												<xsl:value-of select="TOTALAMT" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
									</xsl:for-each>
								</table>
							</td>
						</tr>

						<tr>
							<td height="3Px">

							</td>
						</tr>

						<tr class="DataGridHeader_xslt">
							<td class="DataGridHeader_xslt" colspan="3" >
								Enclosure Details
							</td>
						</tr>
						<tr>
							<td height="3Px">

							</td>
						</tr>

						<tr class="DataGridHeader_xslt">
							<td colspan ='4' align="left">
								<table border='0' cellpadding='1'  cellspacing='1' width='750px' >
									<tr class="DataGridHeader_xslt">
										<td  class="Header" >
											Enclosure Code
										</td>
										<td  class="Header" >
											Description
										</td>
										<td  class="Header">
											Numbers
										</td>
									</tr>
									<xsl:for-each select="//NewDataSet/Table6">
										<tr>
											<td  class="summaryDetail_xslt" >
												<xsl:value-of select="inv_enclcode" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td  class="summaryDetail_xslt" >
												<xsl:value-of select="inv_desc" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td  class="summaryDetail_xslt" >
												<xsl:value-of select="inv_number" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
									</xsl:for-each>
								</table>
							</td>
						</tr>

						<tr>
							<td height="3Px">

							</td>
						</tr>
						<tr>
							<td class="DataGridHeader_xslt" colspan="4" >
								Despatch Details
							</td>
						</tr>
						<tr>
							<td height="3Px" colspan="4">

							</td>
						</tr>

						<tr class="DataGridHeader_xslt">
							<td colspan ='4' align="left">
								<table border='0' cellpadding='1'  cellspacing='1' width='750px' >
									<tr class="DataGridHeader_xslt">
										<td class="Header" >
											Despatch Code
										</td>
										<td class="Header" >
											Description
										</td>
										<td class="Header">
											Numbers
										</td>
									</tr>
									<xsl:for-each select="//NewDataSet/Table7">
										<td  class="summaryDetail_xslt" >
											<xsl:value-of select="inv_despcode" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<td  class="summaryDetail_xslt" >
											<xsl:value-of select="inv_desc" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
										<td  class="summaryDetail_xslt" >
											<xsl:value-of select="inv_number" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</td>
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
