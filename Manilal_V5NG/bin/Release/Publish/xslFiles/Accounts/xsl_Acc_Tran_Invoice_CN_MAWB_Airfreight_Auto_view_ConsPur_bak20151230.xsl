<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<head>
				<link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
				<style>
					.expanded
					{
					color: black
					}
					.collapsed
					{
					DISPLAY: none
					}
				</style>
				<script language="javascript">


					function outliner () {
					oMe = window.event.srcElement
					//get child element
					var child = document.all[event.srcElement.getAttribute("child",false)];
					//if child element exists, expand or collapse it.
					if (null != child)
					child.className = child.className == "collapsed" ? "expanded" : "collapsed";
					}

					function changepic() {
					uMe = window.event.srcElement;
					var check = uMe.src.toLowerCase();
					if(check.lastIndexOf("img_plus.gif") != -1)
					uMe.src = "../../include/img/img_Minus.gif"
					else
					uMe.src = "../../include/img/img_Plus.gif"
					}

				</script>
			</head>
			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" onclick="outliner();">

				<div id="tableContainer" class="divSpace" style="width:820px" >
					<table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
						<xsl:for-each select="//NewDataSet/Table1">
							<xsl:variable name="FRT" select="FREIGHT"></xsl:variable>
							<tr class="formHeading">
								<td class="summaryDetail" width="10px">
									<IMG border="0" alt="expand/collapse section" child="src{$FRT}" id="src{FREIGHT}p"   class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
									<label style="color: #0000FF" >
										<td colspan ='4' class="header">
											Purchase Details Against MP India Airfreight Invoice
										</td>
									</label>
								</td>
							</tr>
							<tr class="DataGridHeader_xslt" >
								<td colspan ='4'   class="summaryDetail">
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>

							</tr>
							<tr id="src{ID}">
								<td class="summaryDetail" width="1px"></td>
								<td colspan="4">
									<table  class="expanded"  border="0"    cellpadding="0" cellspacing="0" bgcolor="#ffffff" id="src{$FRT}" width="100%">
										<tr >

											<td class="lblNormal_xslt" width="200px">
												Entry No
											</td>
											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="ENTRYNO" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="lblNormal_xslt" width="200px">
												Entry Date
											</td>
											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="ENTRYDT" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<tr class="DataGridHeader_xslt">
											<td colspan ='4' class="header">
												Main Details
											</td>
										</tr>
										<tr>
											<td height="4px"></td>
										</tr>
										<tr>
											<td class="lblNormal_xslt" width="200px">
												Supplier
											</td>
											<td class="summaryDetail_xslt"    colspan="3">
												<xsl:value-of select="SUPPLIER_NAME" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<tr>
											<td class="lblNormal_xslt" width="200px">
												Bill No
											</td>
											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="BILLNO" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="lblNormal_xslt" width="200px">
												To Be Paid On
											</td>
											<td class="summaryDetail_xslt" width="200px">
												<xsl:value-of select="PAIDDT" disable-output-escaping="yes"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<tr class="DataGridHeader_xslt">
											<td colspan ='4' class="header">
												Account Details
											</td>
										</tr>
										<tr>
											<td colspan ='4' align="left">
												<table border='0' cellpadding='0'  cellspacing='0' width='100%' >
													<tr class="DataGridHeader_xslt">
														<td  width="100px">
															Account Code
														</td>
														<td class="header">
															Account Name
														</td>
														<td class="header">
															MawbNo
														</td>
														<td class="header">
															Job No
														</td>
														<td class="header">
															Payable Euro
														</td>
                            <td class="header">
                              Deduction Euro
                            </td>
														<td class="header">
															Short Narration
														</td>
													</tr>

													<xsl:for-each select="//NewDataSet/Table2">
														<xsl:variable name="ACCOUNT" select="totalamt"></xsl:variable>
														<tr>
															<td class="summaryDetail_xslt">
																<xsl:value-of select="ACCOUNT" disable-output-escaping="yes"/>
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</td>
															<td class="summaryDetail_xslt">
																<xsl:value-of select="ACC_NAME" disable-output-escaping="yes"/>
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</td>
															<td class="summaryDetail_xslt">
																<xsl:value-of select="MAWBMBL" disable-output-escaping="yes"/>
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</td>
															<td class="summaryDetail_xslt">
																<xsl:value-of select="JOBNO" disable-output-escaping="yes"/>
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</td>
															<td class="summaryDetail_Number_xslt">
																<xsl:value-of select="INVOICEEURO" disable-output-escaping="yes"/>
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</td>
                               <td class="summaryDetail_Number_xslt">
                                <xsl:value-of select="DEDUCTIONEURO" disable-output-escaping="yes"/>
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                              </td> 
															<td class="summaryDetail_xslt">
																<xsl:value-of select="NARRATION" disable-output-escaping="yes"/>
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</td>
														</tr>
														
													</xsl:for-each>
													<TR>
														<xsl:for-each select="//NewDataSet/Table3">
															<td class="lblNumber_xslt" colspan="5" >
																Payable Euro
															</td>
															<td class="lblNumber_xslt">
																<xsl:value-of select="INVOICEEURO" disable-output-escaping="yes"/>
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</td>
														</xsl:for-each>
														<td class="summaryDetail_Number_xslt">
															 
															<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
														</td>
													</TR>
												</table>
											</td>
											<tr height="5px"></tr>
										</tr>

									</table>
								</td>
							</tr>
						 
						</xsl:for-each>
						<xsl:for-each select="//NewDataSet/Table4">
							<xsl:variable name="FRT1" select="FREIGHT"></xsl:variable>
							<tr class="formHeading">
								<td class="summaryDetail" width="10px">
									<IMG border="0" alt="expand/collapse section" child="src{$FRT1}" id="src{FREIGHT}p"   class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Minus.gif" width="9" ></IMG>
									<label style="color: #0000FF" >
										<td colspan ='4' class="header">
											Purchase Details Against MP India Share of Profit Credit Note Details
										</td>
									</label>
								</td>
							</tr>
							<tr class="DataGridHeader_xslt" >
								<td colspan ='4'   class="summaryDetail">
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>

							</tr>

								<tr id="src{ID}">
									<td class="summaryDetail" width="1px"></td>
									<td colspan="4" >
										<table  class="expanded"  border="0"    cellpadding="0" cellspacing="0" bgcolor="#ffffff" id="src{$FRT1}" width="100%">
											<tr >

												<td class="lblNormal_xslt" width="200px">
													Entry No
												</td>
												<td class="summaryDetail_xslt" width="200px">
													<xsl:value-of select="ENTRYNO" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="lblNormal_xslt" width="200px">
													Entry Date
												</td>
												<td class="summaryDetail_xslt" width="200px">
													<xsl:value-of select="ENTRYDT" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
											<tr class="DataGridHeader_xslt">
												<td colspan ='4' class="header">
													Main Details
												</td>
											</tr>
											<tr>
												<td height="4px"></td>
											</tr>
											<tr>
												<td class="lblNormal_xslt" width="200px">
													Supplier
												</td>
												<td class="summaryDetail_xslt"    colspan="3">
													<xsl:value-of select="SUPPLIER_NAME" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
											<tr>
												<td class="lblNormal_xslt" width="200px">
													Bill No
												</td>
												<td class="summaryDetail_xslt" width="200px">
													<xsl:value-of select="BILLNO" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="lblNormal_xslt" width="200px">
													To Be Paid On
												</td>
												<td class="summaryDetail_xslt" width="200px">
													<xsl:value-of select="PAIDDT" disable-output-escaping="yes"/>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
											<tr class="DataGridHeader_xslt">
												<td colspan ='4' class="header">
													Account Details
												</td>
											</tr>
											<tr>
												<td colspan ='4' align="left">
													<table border='0' cellpadding='0'  cellspacing='0' width='100%' >
														<tr class="DataGridHeader_xslt">
															<td  width="100px">
																Account Code
															</td>
															<td class="header">
																Account Name
															</td>
															<td class="header">
																MawbNo
															</td>
															<td class="header">
																Job No
															</td>
															<td class="header">
																Deduction Euro
															</td>
															<td class="header">
																Short Narration
															</td>
														</tr>

														<xsl:for-each select="//NewDataSet/Table5">
															<xsl:variable name="ACCOUNT" select="totalamt"></xsl:variable>
															<tr>
																<td class="summaryDetail_xslt">
																	<xsl:value-of select="ACCOUNT" disable-output-escaping="yes"/>
																	<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																</td>
																<td class="summaryDetail_xslt">
																	<xsl:value-of select="ACC_NAME" disable-output-escaping="yes"/>
																	<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																</td>
																<td class="summaryDetail_xslt">
																	<xsl:value-of select="MAWBMBL" disable-output-escaping="yes"/>
																	<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																</td>
																<td class="summaryDetail_xslt">
																	<xsl:value-of select="JOBNO" disable-output-escaping="yes"/>
																	<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																</td>
																<td class="summaryDetail_Number_xslt">
																	<xsl:value-of select="DEDUCTIONEURO" disable-output-escaping="yes"/>
																	<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																</td>
																<td class="summaryDetail_xslt">
																	<xsl:value-of select="NARRATION" disable-output-escaping="yes"/>
																	<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																</td>
															</tr>
														</xsl:for-each>
														<TR>
															<xsl:for-each select="//NewDataSet/Table6">
																<td class="lblNumber_xslt" colspan="4" >
																	Receivable Euro
																</td>
																<td class="lblNumber_xslt">
																	<xsl:value-of select="DEDUCTIONEURO" disable-output-escaping="yes"/>
																	<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																</td>
															</xsl:for-each>
															<td class="summaryDetail_Number_xslt">

																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</td>
														</TR>
													</table>
												</td>
												<tr height="5px"></tr>
											</tr>

										</table>
									</td>
								</tr>
							 
						</xsl:for-each>


					</table>
				</div>
				 
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>

