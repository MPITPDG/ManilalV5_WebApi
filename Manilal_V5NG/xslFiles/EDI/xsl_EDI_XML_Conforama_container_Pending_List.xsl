<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
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
					function fnOpenV(_url) {
					if (_url != 'TOTAL:') {
					var oWin = window.open(_url, 'OP', 'toolbar=no,menubar=yes,width=790,height=450,top=100,left=300,scrollbars=yes');
					oWin.focus();
					if (oWin == null || typeof (oWin) == "undefined") alert("window failed to open");
					}
					return false;
					}

					function outliner () 
					{
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
					function fnClickNo(No)
					{
					parent.fnViewJobProfit(No)
					return false;
					}
				</script>
			</head>
			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" onclick="outliner();" >
				<div id="tableContainer" class="divSpace" style="width:100%" >
					<table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
						<tr>
							<tr class="DataGridFixedHeader">
								<td width="150px" style="text-align:left;"> Container</td>
								<td width="150px" style="text-align:left;"> Vessel</td>
								<td width="150px" style="text-align:left;"> ETD</td>
								<td width="150px" style="text-align:left;"> Sailing</td>
								<td width="150px" style="text-align:left;"> Size</td>
								<td width="150px" style="text-align:left;"> Port</td>
								<td width="70px"  style="text-align:center;"> Stuffcity</td>
								<td width="70px"  style="text-align:center;"> LoadDt</td>
								<td width="80px"  style="text-align:center;"> Console</td>
								<td width="150px" style="text-align:center;"> MoveType</td>
								<td width="150px" style="text-align:left;"> Handling</td>
								<td width="250px" style="text-align:left;"> Remark</td>
							</tr>

							<xsl:for-each select="//NewDataSet/Table1">
								<xsl:variable name="SAIL" select="SAILING"></xsl:variable>
								<xsl:variable name="ETD" select="ETD"></xsl:variable>
								<xsl:variable name="CONSOL" select="CONSOLIDATION"></xsl:variable>
								<xsl:variable name="LOAD" select="LOADDT"></xsl:variable>
								<xsl:variable name="CODE" select="FK_HANDLINGCODE"></xsl:variable>
								<xsl:variable name="move" select="MOVETYPE"></xsl:variable>
								<xsl:variable name="ID_CON" select="CONTAINERNO"></xsl:variable>
								<tr class="formHeading">
									<td class="summaryDetail" width="10px">
										<IMG border="0" alt="expand/collapse section" child="src{$ID_CON}" name="{CONTAINERNO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
										<label style="color: #0000FF" >
											<xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</label>
									</td>
									<td class="summaryDetail">
										<label style="color: #0000FF" >
											<xsl:value-of select="VESSELNAME" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</label>
									</td>
									<td class="summaryDetail" style="text-align:left;">
										<xsl:choose>
											<xsl:when test="$ETD=''">
												<label style="color: Red" >
													Pending!
												</label>
											</xsl:when>
											<xsl:otherwise>
												<label style="color: #0000FF" >
													<xsl:value-of select="ETD" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</label>
											</xsl:otherwise>
										</xsl:choose>
									</td>
									<td class="summaryDetail" style="text-align:left;">
										<xsl:choose>
											<xsl:when test="$SAIL=''">
												<label style="color: Red" >
													Pending!
												</label>
											</xsl:when>
											<xsl:otherwise>
												<label style="color: #0000FF" >
													<xsl:value-of select="SAILING" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</label>
											</xsl:otherwise>
										</xsl:choose>
									</td>
									<td class="summaryDetail">
										<label style="color: #0000FF" >
											<xsl:value-of select="CONATINERSIZE" disable-output-escaping="yes"/>
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</label>
									</td>
									<td class="summaryDetail"  style="text-align:center;">
										<label style="color: #0000FF" >
											<xsl:value-of select="PORT" />
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</label>
									</td>
									<td class="summaryDetail"  style="text-align:center;">
										<label style="color: #0000FF" >
											<xsl:value-of select="STUFFINGCITY" />
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</label>
									</td>
									<td class="summaryDetail" style="text-align:left;">
										<xsl:choose>
											<xsl:when test="$LOAD=' '">
												<label style="color: Red" >
													Pending!
												</label>
											</xsl:when>
											<xsl:otherwise>
												<label style="color: #0000FF" >
													<xsl:value-of select="LOADDT" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</label>
											</xsl:otherwise>
										</xsl:choose>
									</td>
									<td class="summaryDetail" style="text-align:center;">
										<xsl:choose>
											<xsl:when test="$CONSOL=' '">
												<label style="color: Red" >
													Pending!
												</label>
											</xsl:when>
											<xsl:otherwise>
												<label style="color: #0000FF" >
													<xsl:value-of select="CONSOLIDATION" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</label>
											</xsl:otherwise>
										</xsl:choose>
									</td>
									<td class="summaryDetail" style="text-align:left;">
										<xsl:choose>
											<xsl:when test="$move=''">
												<label style="color: Red" >
													Pending!
												</label>
											</xsl:when>
											<xsl:otherwise>
												<label style="color: #0000FF" >
													<xsl:value-of select="MOVETYPE" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</label>
											</xsl:otherwise>
										</xsl:choose>
									</td>
									<td class="summaryDetail" style="text-align:left;">
										<xsl:choose>
											<xsl:when test="$CODE='0'">
												<label style="color: Red" >
													Pending!
												</label>
											</xsl:when>
											<xsl:otherwise>
												<label style="color: #0000FF" >
													<xsl:value-of select="FK_HANDLINGCODE" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</label>
											</xsl:otherwise>
										</xsl:choose>
									</td>
									<td class="summaryDetail" style="text-align:left;">
										<label style="color: #0000FF" >
											<xsl:value-of select="REMARK" />
											<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
										</label>
									</td>
								</tr>

								<tr id="src{JOBNO}">
									<td class="summaryDetail" width="1px"></td>
									<td colspan="12" >
										<table  border="0" cellpadding="0" cellspacing="0" class="collapsed" bgcolor="#ffffff" id="src{$ID_CON}" width="100%">

											<tr class="formHeading" >
												<td>JobNo.</td>
												<td style="text-align:right;">Pkgs</td>
												<td style="text-align:right;">Pcs</td>
												<td style="text-align:right;">cbm</td>
												<td style="text-align:right;">Grwt</td>
												<td style="text-align:right;">Netwt</td>
											</tr>

											<xsl:for-each select="//NewDataSet/Table2">
												<xsl:variable name="ID_JOB" select="JOBNO"></xsl:variable>
												<xsl:variable name="ID_TYPE" select="TYPE"></xsl:variable>

												<xsl:if test="$ID_CON = CONTAINERNO_M">
													<tr>
														<td class="formHeading">
															<IMG border="0" alt="expand/collapse section" id="job{JOBNO}p" child="job{JOBNO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
															<label style="color: #0000FF" >
																<xsl:value-of select="JOBNO" />
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</label>
														</td>
														<td class="formHeading" style="text-align:right;">
															<label style="color: #0000FF" >
																<xsl:value-of select="PKGS" />
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</label>
														</td>
														<td class="formHeading" style="text-align:right;">
															<label style="color: #0000FF" >
																<xsl:value-of select="PCS" />
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</label>
														</td>
														<td class="formHeading" style="text-align:right;">
															<label style="color: #0000FF" >
																<xsl:value-of select="CBM" />
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</label>
														</td>
														<td class="formHeading" style="text-align:right;">
															<label style="color: #0000FF" >
																<xsl:value-of select="GRWT" />
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</label>
														</td>
														<td class="formHeading" style="text-align:right;">
															<label style="color: #0000FF" >
																<xsl:value-of select="NETWT" />
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</label>
														</td>
													</tr>

													<tr class="collapsed"   bgcolor="#ffffff" id="job{JOBNO}">
														<td class="summaryDetail" width="1px"></td>
														<td colspan="10" class="summaryDetail">
															<table border="0" cellpadding="0" cellspacing="0" width="100%">
																<tr class="formHeading">
																	<td>Type</td>
																	<td>OrderNo</td>
																	<td>StyleNo</td>
																	<td>Pcs</td>
																	<td>cbm</td>
																	<td>Grwt</td>
																</tr>
																<xsl:for-each select="//NewDataSet/Table3">
																	<xsl:variable name="TYPE_ID" select="TYPE_S"></xsl:variable>
																	<xsl:if test ="$ID_JOB=JOBNO ">
																		<tr>
																			<td class="summaryDetail" >
																				<xsl:if test="$TYPE_ID='EDI Data'">
																					<label style="color: #800000" >
																						<xsl:value-of select="TYPE_S" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																				<xsl:if test="$TYPE_ID='MP Web'">
																					<label style="color: #339966" >
																						<xsl:value-of select="TYPE_S" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																			</td>
																			<td class="summaryDetail" >
																				<xsl:if test="$TYPE_ID='EDI Data'">
																					<label style="color: #800000" >
																						<xsl:value-of select="ORDERNO" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																				<xsl:if test="$TYPE_ID='MP Web'">
																					<label style="color: #339966" >
																						<xsl:value-of select="ORDERNO" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																			</td>
																			<td class="summaryDetail" >
																				<xsl:if test="$TYPE_ID='EDI Data'">
																					<label style="color: #800000" >
																						<xsl:value-of select="STYLENO" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																				<xsl:if test="$TYPE_ID='MP Web'">
																					<label style="color: #339966" >
																						<xsl:value-of select="STYLENO" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																			</td>

																			<td class="summaryDetail">
																				<xsl:if test="$TYPE_ID='EDI Data'">
																					<label style="color: #800000" >
																						<xsl:value-of select="PCS" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																				<xsl:if test="$TYPE_ID='MP Web'">
																					<label style="color: #339966" >
																						<xsl:value-of select="PCS" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																			</td>
																			<td class="summaryDetail" >
																				<xsl:if test="$TYPE_ID='EDI Data'">
																					<label style="color: #800000" >
																						<xsl:value-of select="CBM" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																				<xsl:if test="$TYPE_ID='MP Web'">
																					<label style="color: #339966" >
																						<xsl:value-of select="CBM" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>

																			</td>
																			<td class="summaryDetail">
																				<xsl:if test="$TYPE_ID='EDI Data'">
																					<label style="color: #800000">
																						<xsl:value-of select="GRWT" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																				<xsl:if test="$TYPE_ID='MP Web'">
																					<label style="color: #339966" >
																						<xsl:value-of select="GRWT" />
																						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																					</label>
																				</xsl:if>
																			</td>
																		</tr>

																	</xsl:if>
																	<!--<xsl:variable name="Type_val"  select="Type_s"></xsl:variable>-->
																</xsl:for-each>
																<!--<xsl:if test="$Type_val='Master'">
																	 
																</xsl:if>-->
															</table>
														</td>
													</tr>

												</xsl:if>
											</xsl:for-each>
											<tr>
												<td colspan="12" class="summaryDetail">
													<table border="0" cellpadding="0" cellspacing="0" width="100%">
														<tr class="formHeading">
															<td>JobNo</td>
															<td>MissingOrderNo</td>
															<td>MissingLinerCode</td>
														</tr>
														<xsl:for-each select="//NewDataSet/Table4">
															<xsl:if test="$ID_CON = CONTAINERNO_O"   >
																<tr>
																	<td class="summaryDetail" >
																		<label style="color: #0000FF" >
																			<xsl:value-of select="JOBNO_O" />
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</label>
																	</td>
																	<td class="summaryDetail" >
																		<label style="color: #0000FF" >
																			<xsl:value-of select="MISSINGORDERNO" />
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</label>
																	</td>
																	<td class="summaryDetail" >
																		<label style="color: #0000FF" >
																			<xsl:value-of select="MISSINGLINERCODE" />
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</label>
																	</td>
																</tr>
															</xsl:if>

														</xsl:for-each>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</xsl:for-each>
						</tr>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>

