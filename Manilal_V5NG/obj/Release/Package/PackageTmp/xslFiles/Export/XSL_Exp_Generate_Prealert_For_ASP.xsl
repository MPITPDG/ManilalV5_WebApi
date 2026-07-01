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
					function changepic(ID) {
						new_id = ID + "p";
						sorc_src = document.getElementById(new_id).src;
						ImgArr = document.getElementById(new_id).src.split("/");
						img_src = ImgArr[5];
						if (img_src == "img_Plus.gif") {
							rep_str = /img_Plus/gi;
							chg_src = sorc_src.replace(rep_str, "img_Minus");

							document.getElementById(new_id).src = chg_src;
						}
						else {
							rep_str = /img_Minus/gi;
							chg_src = sorc_src.replace(rep_str, "img_Plus");
							document.getElementById(new_id).src = chg_src;
						}
						var Cont = document.getElementById(ID).attributes.class.value;

						if (Cont == "expanded")
							document.getElementById(ID).setAttribute("class", "collapsed");
						else
							document.getElementById(ID).setAttribute("class", "expanded");
					}

				</script>
			</head>
			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" onclick="outliner();">
				<div id="tableContainer" class="divSpace" style="width:100%" >
					<table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
						<xsl:for-each select="//NewDataSet/Table1">
							<tr class="DataGridFixedHeader">

								<td width="40px" style="text-align:right;">
									ConsoleNo
								</td>
								<td width="20px" style="text-align:right;">
									ConsoleDate
								</td>

								<td width="80px"  style="text-align:left;">
									SentFrom
								</td>
								<td width="25px" style="text-align:left;">
									Pkgs
								</td>
								<td width="25px"  style="text-align:left;">
									Weight
								</td>
								<td width="25px"  style="text-align:left;">
									Volume
								</td>
								<td width="55px"  style="text-align:left;">
									CHBLWT
								</td>
								<td width="80px"  style="text-align:left;">
									Agent_Name
								</td>
							</tr>

							<xsl:variable name="ID_CON" select="CONSOLENO"></xsl:variable>
							<tr>
								<td class="summaryDetail" width="10px">
									<IMG border="0" alt="expand/collapse section" child="src{$ID_CON}" name="{CONSOLENO}"  id="src{$ID_CON}p" class="expandable" height="11" onclick="changepic('src{$ID_CON}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
									<xsl:value-of select="CONSOLENO" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>

								<td class="summaryDetail">
									<xsl:value-of select="CONSOLEDT" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>

								<td class="summaryDetail">
									<xsl:value-of select="SENTFROM" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="NOOFPKGS" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>

								<td class="summaryDetail">
									<xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="CHBLWT" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
								<td class="summaryDetail">
									<xsl:value-of select="SUP_NAME" disable-output-escaping="yes"/>
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</td>
							</tr>

							<tr id="src{JOBNO}"    >
								<td colspan="8" >
									<table  border="0" cellpadding="0" cellspacing="0" class="collapsed" bgcolor="#ffffff" id="src{$ID_CON}" width="100%">
										<tr class="formHeading" >
											<td class="summaryDetail" width="10px"></td>
											<td   width="60px" style="text-align:left;">
												JobNo.
											</td>
											<td   width="70px" style="text-align:left;">
												Hawbno
											</td>

											<td    width="40px" style="text-align:left;">
												Hawbdt
											</td>
											<td    width="45px" style="text-align:left;">
												Pkgs
											</td>
											<td    width="60px" style="text-align:left;">
												Weight
											</td>
											<td    width="60px" style="text-align:left;">
												Volume
											</td>
											<td    width="200px" style="text-align:left;">
												Impoter
											</td>
											<td    width="200px" style="text-align:left;">
												Expoter
											</td>
											<td   width="20px" style="text-align:left;">
												Export_JobNo
											</td>

										</tr>
										<xsl:for-each select="//NewDataSet/Table2">
											<xsl:variable name="ID_JOB" select="JOBNO"></xsl:variable>
											<xsl:if test="$ID_CON = JOB_CONSOLENO">
												<tr>
													<td class="summaryDetail" width="10px"></td>
													<td class="summaryDetail" width="10px">
														<IMG border="0" alt="expand/collapse section" id="job{JOBNO}p" child="job{JOBNO}" class="expandable" height="11" onclick="changepic('job{JOBNO}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
														<xsl:value-of select="JOBNO" />
													</td>
													<td class="summaryDetail" >
														<xsl:value-of select="HAWBNO" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail"  style="text-align:left;">
														<xsl:value-of select="HAWBDT" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail"  style="text-align:right;">
														<xsl:value-of select="NOOFPKGS" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail"  style="text-align:right;">
														<xsl:value-of select="WEIGHT" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail"  style="text-align:right;">
														<xsl:value-of select="VOLUME" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail"  style="text-align:left;">
														<xsl:value-of select="IMPOTER" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail"  style="text-align:left;">
														<xsl:value-of select="EXPOTER" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail"  style="text-align:left;">
														<xsl:value-of select="EXPTNO" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
												</tr>

												<!--<tr class="collapsed"   id="job{JOBNO}">
												<td colspan="8" >
													<table  border="0" cellpadding="0" cellspacing="0"   bgcolor="#ffffff" width="100%">
														<tr class="formHeading">															 
															<td  class="summaryDetail" width="10px"></td>
															 
															<td    width="60px" style="text-align:left;">
																OrderNo
															</td>
															<td   width="70px" style="text-align:left;">
																Pcs
															</td>
															<td    width="150px" style="text-align:left;">
																LSD
															</td>
															<td    width="150px" style="text-align:left;">
																Hscode
															</td>
															<td     width="100px" style="text-align:left;">
																Hscode_Desc
															</td>
															<td    width="100px" style="text-align:left;">
																
															</td>
															<td  colspan="4"   width="100px" style="text-align:left;">
																
															</td>
															<td    width="50px" style="text-align:left;">
																
															</td>

														</tr>
														<xsl:for-each select="//NewDataSet/Table3">
															<xsl:if test="$ID_JOB = ORDER_JOB">
																<tr>
																	 
																	<td class="summaryDetail" width="10px"></td>
																	 
																	<td class="summaryDetail"  >
																		<xsl:value-of select="ORDERNO" />
																	</td>
																	<td   class="summaryDetail" >
																		<xsl:value-of select="NOOFPCS" />
																		<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																	</td>
																	<td   class="summaryDetail" >
																		<xsl:value-of select="LAST_DATE_OFSHIMENT" />
																		<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																	</td>
																	<td   class="summaryDetail" >
																		<xsl:value-of select="HSCODE" />
																		<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																	</td>
																	<td   class="summaryDetail" >
																		<xsl:value-of select="HSCODE_DESC" />
																		<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																	</td>
																	<td    style="text-align:left;">

																	</td>
																	<td   colspan="4"   style="text-align:left;">

																	</td>
																	<td    style="text-align:left;">

																	</td>

																</tr>
															</xsl:if>
														</xsl:for-each>
													</table>
												</td>
											</tr>-->

												<tr class="collapsed" bgcolor="#ffffff" id="job{JOBNO}">
													<td class="summaryDetail" width="10px"></td>
													<td class="summaryDetail" width="10px"></td>
													<td colspan="10" class="summaryDetail">
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr class="formHeading">
																<td  >OrderNo</td>
																<td >Pcs</td>
																<!--<td class="header" style="text-align:right;">LSD </td>
																<td class="header" style="text-align:right;">Hscode </td>-->
															</tr>
															<xsl:for-each select="//NewDataSet/Table3">
																<xsl:if test="$ID_JOB = ORDER_JOB">
																	<tr>
																		<td class="summaryDetail">
																			<xsl:value-of select="ORDERNO" disable-output-escaping="yes"/>
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</td>
																		<td class="summaryDetail">
																			<xsl:value-of select="NOOFPCS" />
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</td>
																		<!--<td class="summaryDetail" style="text-align:right;">
																			<xsl:value-of select="LAST_DATE_OFSHIMENT" />
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</td>
																		<td class="summaryDetail" style="text-align:right;">
																			<xsl:value-of select="HSCODE" />
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</td>-->
																	</tr>
																</xsl:if>
															</xsl:for-each>
														</table>
													</td>
												</tr>
											</xsl:if>
										</xsl:for-each>
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
