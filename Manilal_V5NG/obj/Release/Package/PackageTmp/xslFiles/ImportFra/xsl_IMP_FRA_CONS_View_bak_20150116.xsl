<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
	<xsl:template match='/'>
		<html>
			<head>
				<script language="javascript" type="text/javascript">

				</script>
				<link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
				<!--<link href="../../include/jsCommon/ToolTip.js" type="text/javascript"/>-->
			</head>
			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" background-color="#F3F8FE">
				<div id="tableContainer" class="divSpace" style="width:100%" >
					<table border='0' cellpadding='1' cellspacing='1' width='950px' style="border-right: 1px solid #C7E3FE;  background-color:#F3F8FE" >
						<xsl:for-each select="//NewDataSet/Table">
							<xsl:variable name="ID" select="CONSOLENO"></xsl:variable>
							<xsl:variable name="IMPORTED" select="IMPORTED"></xsl:variable>
							<xsl:variable name="ACTUALARDT" select="ACTUALARRIVALDT"></xsl:variable>
							<xsl:variable name="MODE" select="MODE"></xsl:variable>
							<xsl:variable name="MAWB_NO" select ="MAWBNO"/>
							<tr>
								<td height="2" colspan="2" align="center">
									<div align="center">
										<b>
											<font size="3" face="Verdana, Arial, Helvetica, sans-serif" color="navy">
												<!--<a>E-Document - View/Upload File </a>-->
												<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.Exp_View_Edoc('{FULLNO}')">E-Document - View/Upload File</label>
											</font>
											<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
											</font>
										</b>
									</div>
								</td>
							</tr>
							<tr>
								<td class="lblNormal_xslt" width="100%" >
									Console No :
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									<xsl:value-of select="CONSOLENO" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;&amp;nbsp;</xsl:text>
									<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fnClick_Dossier('{CONSOLENO}')">PRINT DOSSIER</label>
								</td>
							</tr>
							<xsl:if test="IMPORTED='Y'">
								<tr>
									<td colspan='2' style="color: red;text-align: center;font-style: normal;background: yellow;border-top: 1.0pt solid white;border-bottom: 1.0pt solid white;border-right: 0pt solid windowtext;border-left: 0pt solid windowtext;font-weight: bold;font-size: 11px;font-family: Verdana, Calibri;" class='HiLight_Yellow'>
										DATA IS DIRECTLY IMPORTED FROM INDIA
									</td>
								</tr>
							</xsl:if>
							<tr class="DataGridHeader_xslt">
								<td colspan ='2' class="header">
									General Details
								</td>
							</tr>
							<!-- GENERAL DETAILS-->
							<tr >
								<td  colspan="2">
									<table   style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="1" cellpadding="1" >
										<tr>
											<td class="lblNormal_xslt" width="20%" valign="top" height="2">
												Date
											</td>
											<td class="summaryDetail_xslt" width="20%" height="2">
												<xsl:value-of select="CONSOLEDT"/>
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="lblNormal_xslt" width="20%" valign="top" height="2">
												Mode
											</td>
											<td class="summaryDetail_xslt" height="2" width="20%" colspan="3">
												<xsl:if test="MODE='s'">
													Sea
												</xsl:if>
												<xsl:if test="MODE='a'">
													Air
												</xsl:if>
											</td>
										</tr>
										<tr>
											<td class="lblNormal_xslt" width="20%" height="2" valign="top">
												Consolidation Sent From
											</td>
											<td width="20%" height="2" class="summaryDetail_xslt" >
												<xsl:value-of select="SENT_CITY_NAME" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td width="20%" height="2" class="lblNormal_xslt" >
												Agent
											</td>
											<td height="2" width="20%"  class="summaryDetail_xslt" >
												<xsl:value-of select="SUP_NAME" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<tr >
											<td class="lblNormal_xslt" width="20%" valign="top" height="2">
												Destination
											</td>
											<td class="summaryDetail_xslt" width="20%"  height="2" colspan="6" >
												<xsl:value-of select="DESTINATION" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>

										</tr>
									</table>
								</td>
							</tr>
							<!-- VESSEL DETAILS-->
							<xsl:if test="$MODE='s'">

								<tr>
									<td colspan="2">
										<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="1" cellpadding="1">
											<tr>
												<td class="lblNormal_xslt" width="25%" valign="top" height="21">
													Shipping Line
												</td>
												<td class="summaryDetail_xslt"  width="25%" valign="top" height="21">
													<xsl:value-of select="SHIPLINE_NAME" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>

												<td class="lblNormal_xslt" width="25%" valign="top" height="21">
													Vessel
												</td>
												<td class="summaryDetail_xslt"  width="25%" valign="top" height="21">
													<xsl:value-of select="VSL_NAME" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
											<tr>
												<td class="lblNormal_xslt" width="25%" valign="top" height="21">
													Voyage
												</td>
												<td class="summaryDetail_xslt" width="25%" valign="top" height="21">
													<xsl:value-of select="VSL_VOYNO" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="lblNormal_xslt" width="25%" height="2" valign="top">
													Sailed On
												</td>
												<td class="summaryDetail_xslt" width="25%" height="2" valign="top">
													<xsl:value-of select="SAILING" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
											<tr>
												<td  class="lblNormal_xslt" width="25%" valign="top" height="2">
													M B/L No.
												</td>
												<td class="summaryDetail_xslt" width="25%" height="2" valign="top">
													<xsl:value-of select="MBLNO" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td  class="lblNormal_xslt" height="2" valign="top" width="25%">
													Date
												</td>
												<td  class="summaryDetail_xslt" height="2" valign="top" width="25%">
													<xsl:value-of select="MBLDT" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</xsl:if>

							<!-- AIR LINE DETAILS-->
							<xsl:if test="$MODE='a'">
								<tr>
									<td height="2" colspan="2">
										<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="1" cellpadding="1">
											<tr>
												<td  class="lblNormal_xslt" width="25%" height="14" valign="top">
													Airline Name
												</td>
												<td class="summaryDetail_xslt" height="14" colspan="5" valign="top" width="25%">
													<xsl:value-of select="AIRLINE" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
											<tr>
												<td class="lblNormal_xslt"  height="2" valign="top" width="25%">
													Planned Flight No
												</td>
												<td class="summaryDetail_xslt" height="2" valign="top" width="25%" >
													<xsl:value-of select="FLIGHTNO" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="lblNormal_xslt"   height="2" valign="top" width="25%">
													Date
												</td>
												<td class="summaryDetail_xslt" width="25%" height="2" colspan="3">
													<xsl:value-of select="FLIGHTDT" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
											<tr>
												<td class="lblNormal_xslt" height="2" valign="top" width="25%">
													Actual Flight No
												</td>
												<td class="summaryDetail_xslt" height="2" valign="top" width="25%">
													<xsl:value-of select="ACTUALFLIGHTNO" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td  class="lblNormal_xslt" height="2" valign="top" width="25%">
													Date
												</td>
												<td class="summaryDetail_xslt" height="2" colspan="3" width="25%">
													<xsl:value-of select="ACTUALFLIGHTDT" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
											<tr>
												<td class="lblNormal_xslt" width="25%" height="2" valign="top">
													MAWB No
												</td>
												<td class="summaryDetail_xslt" width="25%" height="2" valign="top">
													<xsl:value-of select="MAWBNO" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="lblNormal_xslt" width="25%" height="2" valign="top">
													Date
												</td>
												<td class="summaryDetail_xslt" height="2" colspan="3" width="25%">
													<xsl:value-of select="MAWBDT" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
											<tr>
												<td class="lblNormal_xslt" height="2" valign="top" width="25%">
													CO2 Emition Level
												</td>
												<td class="summaryDetail_xslt"  height="2" colspan="6" valign="top" width="25%">
													<xsl:value-of select="CO2_EMITION_LVL" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
											</tr>
											<tr>
												<td class="lblNormal_xslt" height="2" valign="top" width="25%">
													DOSSIER/D
												</td>
												<td class="summaryDetail_xslt"  height="2" colspan="6" valign="top" width="25%">
													<xsl:value-of select="DOUANENO" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>


												</td>
											</tr>
										</table>
									</td>
								</tr>
							</xsl:if>
							<!-- End Air Details-->
							<!-- GOODS DETAILS-->
							<tr>
								<td colspan="2">
									<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="1" cellpadding="1">
										<tr>
											<td class="lblNormal_xslt" width="25%" valign="top">
												Packages
											</td>
											<td class="summaryDetail_xslt" width="25%">
												<xsl:value-of select="NOOFPKGS" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td width="25%" class="lblNormal_xslt" >
												Type of pkgs
											</td>
											<td class="summaryDetail_xslt" width="25%">
												<xsl:value-of select="TYPEOFPKGS" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<tr>
											<td class="lblNormal_xslt" width="25%" height="14" valign="top">
												Weight Kgs
											</td>
											<td class="summaryDetail_xslt" height="14" width="25%">
												<xsl:value-of select="WEIGHT" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="lblNormal_xslt" height="14" width="25%">
												Volume
											</td>
											<td class="summaryDetail_xslt" width="25%" height="14">
												<xsl:value-of select="VOLUME" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>
										<xsl:if test="MODE_VALUE='AIR'">
											<tr>
												<td class="lblNormal_xslt" height="14" valign="top" width="25%">
													CHBL WT.
												</td>
												<td  class="summaryDetail_xslt" height="14" width="25%" >
													<xsl:value-of select="CHBLWT" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td>
												</td>
												<td>
												</td>
											</tr>
										</xsl:if>
										<tr>
											<td class="lblNormal_xslt" width="25%" height="2" valign="top">
												ETA
											</td>
											<td  class="summaryDetail_xslt" height="2" width="25%">
												<xsl:value-of select="ETA" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
											<td class="lblNormal_xslt" height="2" width="25%">
												VIA
											</td>
											<td  class="summaryDetail_xslt" width="25%" height="2">

												<xsl:if test="VIA='v'">
													<xsl:value-of select="TRANS_CITY_NAME" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</xsl:if>
												<xsl:if test="VIA='d'">
													DIRECT
												</xsl:if>
											</td>
										</tr>
										<tr>
											<td class="lblNormal_xslt" height="2" valign="top" width="25%">
												House B/L Issued
											</td>
											<td  class="summaryDetail_xslt" height="2" valign="top" width="25%">
												<xsl:if test="HOUSEBL='y'" >
													Yes
												</xsl:if>
												<xsl:if test="HOUSEBL!='y'" >
													No
												</xsl:if>
											</td>
											<td class="lblNormal_xslt" height="2" valign="top" width="25%">
												Freight
											</td>
											<td class="summaryDetail_xslt" width="23%" height="2">
												<xsl:value-of select="FREIGHT" />
												<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
											</td>
										</tr>

									</table>
								</td>
							</tr>
							<xsl:if test="$MODE='s'">
								<tr>
									<td height="2" colspan="2">
										<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="1" cellpadding="1">

											<tr>
												<td class="lblNormal_xslt" width="25%" height="25">
													CONTAINER NO.
													<!--<xsl:if test="IMPORTED!='Y'">
											<a href=" ">EDIT CONTAINER</a>
										</xsl:if>-->
												</td>
												<td class="lblNormal_xslt" width="75%"  >
													<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_containerview('{CONTAINERNO}','{CONSOLENO}')">
														<xsl:value-of select="CONTAINERNO" />
													</label>
													<label>-</label>
													<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_containerExgview('{CONTAINERNO}','{CONSOLENO}')">EDIT DESTINATION EXCHANGE RATE</label>


													<xsl:if test="SINGLESHPR='y'">
														SINGLE SHIPPER
													</xsl:if>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</xsl:if>
							<tr>
								<xsl:if test="IMPORTED='Y'">
									<td class="lblNormal_xslt" height="25" colspan="4">
										<label   style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('GENREM','{CONTAINERNO}','{CONSOLENO}','')">
											REMARK
										</label>
										<td></td>
									</td>
								</xsl:if>
								<xsl:if test="IMPORTED!='Y'">
									<td class="lblNormal_xslt ">
										<B>REMARK</B>
									</td>
									<td class="summaryDetail_xslt"   >
										<xsl:value-of select="REMARK" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</xsl:if>
							</tr>
							<xsl:if test="$MODE='s'">
								<tr>
									<td colspan="2">
										<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td class="lblNormal_xslt">
													CONTAINER NO.
												</td>
												<td class="lblNormal_xslt">
													Quai D'enlevement
												</td>
												<td class="lblNormal_xslt">
													Quai De Restitution
												</td>
												<td class="lblNormal_xslt">
													Last free date
												</td>
											</tr>
											<xsl:for-each select="//NewDataSet/Table1">
												<tr>
													<td class="summaryDetail_xslt" >
														<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('CONT','{CONTAINERNO}','{CONSOLENO}','')">
															<xsl:value-of select="CONTAINERNO" />
														</label>
													</td>
													<td class="summaryDetail_xslt" >
														<xsl:value-of select="ENLEVEMENT" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail_xslt" >
														<xsl:value-of select="RESTITUTION" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail_xslt" >
														<xsl:value-of select="FREEDATE" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
												</tr>
											</xsl:for-each>
										</table>
									</td>
								</tr>
							</xsl:if>
							<tr>
								<td colspan="2">
									<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr class="DataGridHeader_xslt">
											<td colspan ='11' class="header">
												Job Details
											</td>
										</tr>
										<tr>
											<td class="lblNormal_xslt">
												JOB NO
											</td>
											<td class="lblNormal_xslt">
												<xsl:choose>
													<xsl:when test="MODE_VALUE='SEA'">
														HBL NO.
													</xsl:when>
													<xsl:otherwise>
														HAWB NO.
													</xsl:otherwise>
												</xsl:choose>

											</td>
											<td class="lblNormal_xslt">
												DATE
											</td>
											<td class="lblNormal_xslt">
												DESTINATION
											</td>
											<td class="lblNormal_xslt">
												INCOTERM
											</td>
											<td class="lblNormal_xslt">
												SHIPPER
											</td>
											<td class="lblNormal_xslt">
												IMPORTER
											</td>
											<td class="lblNormal_xslt">
												PKGS
											</td>
											<td class="lblNormal_xslt">
												WEIGHT
											</td>

											<xsl:if test="MODE_VALUE='AIR'">
												<td class="lblNormal_xslt">
													CHBL WT
												</td>
											</xsl:if>
											<td class="lblNormal_xslt">
												VOLUME
											</td>
											<td class="lblNormal_xslt">
												FREIGHT
											</td>
											<td class="lblNormal_xslt">
												SURREND ERED DATE
											</td>
											<td class="lblNormal_xslt">
												RELEASE RECD DATE
											</td>
										</tr>
										<xsl:for-each select="//NewDataSet/Table2">
											<xsl:variable name="JOBID" select="JOBNO"></xsl:variable>
											<tr>
												<td rowspan="14" class="lblNormal_xslt">
													<xsl:value-of select="$JOBID" />
													<!--<a href ="" onmouseover="javascript:return parent.tooltip.show('Testing  123 ', 200)">-->
													<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_Dossier_Job('{$JOBID}')" >
														Print Dossier
													</label>
													<!--</a>-->


												</td>
											</tr>
											<tr>
												<td class="summaryDetail_xslt" height="9">
													<xsl:choose>
														<xsl:when  test="$IMPORTED='Y'">
															<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_HawbNo('{HAWBNO}','{$MAWB_NO}')">
																<xsl:value-of select="HAWBNO" />
															</label>
														</xsl:when>
														<xsl:otherwise>
															<xsl:value-of select="HAWBNO" />
														</xsl:otherwise>
													</xsl:choose>
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>

												</td>
												<td class="summaryDetail_xslt" height="9">
													<xsl:value-of select="HAWBDT" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt" width="6%">
													<xsl:value-of select="CITY_NAME" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>

												</td>
												<td class="summaryDetail_xslt">
													<xsl:value-of select="INCOTERM" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt">
													<xsl:value-of select="EXPORTER_NAME" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt">
													<xsl:value-of select="IMPORTER_NAME" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt">
													<xsl:value-of select="NOOFPKGS" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="summaryDetail_xslt">
													<xsl:value-of select="WEIGHT" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<xsl:if test="MODE_VALUE='AIR'">
													<td class="summaryDetail_xslt">
														<xsl:value-of select="CHBLWT" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
												</xsl:if>
												<td class="summaryDetail_xslt">
													<xsl:value-of select="VOLUME" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td  class="summaryDetail_xslt">
													<xsl:value-of select="FREIGHT" />
													<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
												</td>
												<td class="lblNormal_xslt">
													<label  style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('SURDT','{CONTAINERNO}','{CONSOLENO}','{$JOBID}')">
														EDIT
													</label>

												</td>
												<td class="lblNormal_xslt">
													<label   style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('SURDT','{CONTAINERNO}','{CONSOLENO}','{$JOBID}')">
														EDIT
													</label>

												</td>

											</tr>

											<tr>
												<td colspan="11">
													<table style="border-right: 1px solid #C7E3FE;" width="60%" border="0" cellspacing="0" cellpadding="0" align="center">
														<tr >
															<th class="lblNormal_xslt">
																<div align="center">
																	Importer's Reference
																</div>
															</th>
															<th class="lblNormal_xslt">
																<div align="center">
																	Pieces
																</div>
															</th>
															<th class="lblNormal_xslt">
																<div align="center">
																	Type of Pieces
																</div>
															</th>
															<th class="lblNormal_xslt">
																<div align="center">
																	LSD (Last date of shiment)
																</div>
															</th>

														</tr>
														<xsl:for-each select="//NewDataSet/Table3">
															<xsl:if test="FK_JOB_ORDER=$JOBID">
																<tr>
																	<td class="summaryDetail_xslt">
																		<div align="center">
																			<xsl:value-of select="IMPORTERS_REFERENCE" />
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</div>
																	</td>
																	<td class="summaryDetail_xslt">
																		<div align="center">
																			<xsl:value-of select="PIECES" />
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</div>
																	</td>
																	<td class="summaryDetail_xslt">
																		<div align="center">
																			<xsl:value-of select="TYPE_OF_PIECES" />
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</div>
																	</td>
																	<td class="summaryDetail_xslt">
																		<div align="center">
																			<xsl:value-of select="LSD" />
																			<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																		</div>
																	</td>

																</tr>
															</xsl:if>
														</xsl:for-each>
													</table>
												</td>
											</tr>
											<xsl:if test ="IMPORTED!='Y'">
												<!--DOCUMET -->
												<tr class="lblNormal_Cons_xslt">
													<td colspan="11">
														<table  style="border-right: 1px solid #C7E3FE;"  width="100%" border="0" cellspacing="0" cellpadding="0">
															<tr>
																<td class="lblNormal_xslt" width="22%">
																	DESTINATION-DOCUMENTS
																	<a href="">EDIT</a>
																</td>
																<td width="78%">
																	<table  width="100%" border="0" cellspacing="0" cellpadding="0">
																		<tr>
																			<td width="90%">
																				<table width="100%" border="0" cellspacing="0" cellpadding="0">
																					<tr>
																						<td class="lblNormal_xslt" width="69%" colspan="2">
																							List of Documents
																						</td>
																						<td class="lblNormal_xslt" width="25%">
																							<div align="center">
																								Recd. Date
																							</div>
																						</td>
																					</tr>
																					<xsl:for-each select="//NewDataSet/Table4">
																						<xsl:if test="FK_JOB_DOCUMENT=$JOBID">
																							<tr>
																								<td width="6%">
																									<div align="center">

																									</div>
																								</td>
																								<td class="summaryDetail_xslt" width="69%">
																									<xsl:value-of select="DOCUMENT" />
																									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																								</td>
																								<td class="summaryDetail_xslt">
																									<div align="center">
																										<xsl:value-of select="RECDDT" />
																										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																									</div>
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
														</table>
													</td>
												</tr>
												<!-- END DOCUMET -->
											</xsl:if>
											<tr>
												<td colspan="11">
													<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="0" cellpadding="0">
														<tr class="lblNormal_Cons_xslt">
															<td class="lblNormal_xslt" width="22%">
																DESTINATION DOCUMENTS
															</td>
															<td width="78%">
																<table   width="100%" border="0" cellspacing="1" cellpadding="1">
																	<tr>
																		<td width="90%">
																			<table    width="100%" border="0" cellspacing="1" cellpadding="1">
																				<tr>

																					<td class="lblNormal_xslt" width="69%">
																						List of Documents
																					</td>
																					<td class="lblNormal_xslt" width="25%">
																						<div align="center">
																							Recd.Date
																						</div>
																					</td>
																				</tr>
																				<xsl:for-each select="//NewDataSet/Table5">
																					<xsl:if test="EXPT_JOB_DEST=$JOBID">
																						<tr>
																							<!--<td width="6%">
																								<div align="center">

																								</div>
																							</td>-->
																							<td class="summaryDetail_xslt" width="69%">
																								<xsl:value-of select="DOCUMENT" />
																								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																							</td>
																							<td class="summaryDetail_xslt">
																								<div align="center">
																									<xsl:value-of select="RECDDT" />
																									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																								</div>
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
													</table>
												</td>
											</tr>
											<tr>
												<td colspan="11"></td>
											</tr>
											<!-- END DOCUMET -->
											<!--CONSIGNEE DOCUMENT-->
											<xsl:if test ="IMPORTED!='Y'">
												<tr>
													<td colspan="11">
														<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="0" cellpadding="0">
															<tr>
																<td class="lblNormal_xslt" width="27%">
																	DOCUMENT SENT TO CONSIGNEE
																	<a href="">EDIT</a>
																</td>
																<td width="73%">
																	<table   width="100%" border="0" cellspacing="0" cellpadding="0">
																		<tr>

																			<td width="90%">
																				<table width="100%" border="0" cellspacing="1" cellpadding="1">
																					<tr>
																						<td class="lblNormal_xslt" width="12%">
																							Date
																						</td>
																						<td class="lblNormal_xslt" width="25%">
																							Courier No.
																						</td>
																						<td width="63%" class="lblNormal_xslt">
																							<div align="center">
																								Remarks
																							</div>
																						</td>
																					</tr>

																					<tr>
																						<td class="summaryDetail_xslt" width="12%">
																							<div align="center">
																								<xsl:value-of select="DOCSENTDT" />
																								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																							</div>
																						</td>
																						<td class="summaryDetail_xslt" width="15%">
																							<xsl:value-of select="COURIERNO" />
																							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																						</td>
																						<td class="summaryDetail_xslt" width="73%">
																							<div align="center">
																								<xsl:value-of select="DESTDOCRMK" />
																								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																							</div>
																						</td>
																					</tr>

																				</table>
																			</td>
																		</tr>
																	</table>
																</td>
															</tr>
														</table>

													</td>
												</tr>
											</xsl:if>
											<tr>
												<td colspan="11">
													<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="0" cellpadding="0">
														<tr>
															<td class="lblNormal_xslt" width="27%">
																DOCUMENT SENT TO CONSIGNEE
															</td>
															<td width="73%">

																<table   width="100%" border="0" cellspacing="0" cellpadding="0">
																	<tr>

																		<td width="90%">
																			<table   width="100%" border="0" cellspacing="0" cellpadding="0">
																				<tr>
																					<td class="lblNormal_xslt" width="12%">
																						Date
																					</td>
																					<td class="lblNormal_xslt" width="25%">
																						Courier No.
																					</td>
																					<td class="lblNormal_xslt" width="63%">
																						<div align="center">
																							Remarks
																						</div>
																					</td>
																				</tr>
																				<xsl:for-each select="//NewDataSet/Table6">
																					<xsl:if test="EXPT_JOB=$JOBID">
																						<tr>
																							<td class="summaryDetail_xslt" width="12%">
																								<div align="center">
																									<xsl:value-of select="DOCSENTDT" />
																									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																								</div>
																							</td>
																							<td class="summaryDetail_xslt"  width="15%">
																								<xsl:value-of select="COURIERNO" />
																								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																							</td>
																							<td class="summaryDetail_xslt" width="73%">
																								<div align="center">
																									<xsl:value-of select="DESTDOCRMK" />
																									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																								</div>
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
													</table>

												</td>
											</tr>

											<!--END CONSIGNEE-->
											<tr>
												<td colspan="12"></td>
											</tr>
											<!--RECEIPT OF CARGO-->
											<xsl:if test ="IMPORTED!='Y'">
												<tr>
													<td colspan="11">
														<table style="border-right: 1px solid #C7E3FE;"  width="100%" border="0" cellspacing="0" cellpadding="0">
															<tr>
																<td width="20%">
																	RECEIPT OF CARGO
																	<a href="">EDIT</a>
																</td>
																<td width="80%">
																	<table width="100%" border="0" cellspacing="0" cellpadding="0">
																		<tr>
																			<td width="90%">
																				<table width="100%" border="0" cellspacing="1" cellpadding="1">
																					<tr>
																						<td class="lblNormal_xslt" width="15%">
																							No Of Pkgs
																						</td>
																						<td class="lblNormal_xslt" width="15%">
																							Recd Date
																						</td>
																						<td class="lblNormal_xslt" width="50%">
																							<div align="center">
																								Recd Where
																							</div>
																						</td>
																						<td class="lblNormal_xslt" width="20%">
																							<div align="center">
																								Recd Locally
																							</div>
																						</td>
																					</tr>

																					<tr>
																						<td class="summaryDetail_xslt" width="15%">
																							<div align="center">
																								<xsl:value-of select="NOOFPKGS" />
																								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																							</div>
																						</td>
																						<td class="summaryDetail_xslt" width="15%">
																							<xsl:value-of select="RECDDATE" />
																							<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																						</td>
																						<td class="summaryDetail_xslt" width="50%">
																							<div align="center">
																								<xsl:value-of select="RECDWHERE" />
																								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																							</div>
																						</td>
																						<td class="summaryDetail_xslt" width="20%">
																							<div align="center">
																								<xsl:value-of select="RECDLOCAL" />
																								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																							</div>
																						</td>
																					</tr>

																				</table>
																			</td>
																		</tr>
																	</table>

																</td>
															</tr>
														</table>

													</td>
												</tr>
											</xsl:if>
											<tr>
												<td colspan="11">
													<table style="border-right: 1px solid #C7E3FE;"  width="100%" border="0" cellspacing="0" cellpadding="0">
														<tr>
															<td width="17%" class="lblNormal_xslt" >
																RECEIPT OF CARGO
															</td>
															<td width="83%">
																<table width="100%" border="0" cellspacing="0" cellpadding="0">
																	<tr>
																		<td width="90%">
																			<table width="100%" border="0" cellspacing="0" cellpadding="0">
																				<tr>
																					<td class="lblNormal_xslt" width="15%">
																						No Of Pkgs
																					</td>
																					<td class="lblNormal_xslt" width="15%">
																						Recd Date
																					</td>
																					<td class="lblNormal_xslt" width="50%">
																						<div align="center">
																							Recd Where
																						</div>
																					</td>
																					<td class="lblNormal_xslt" width="20%">
																						<div align="center">
																							Recd Locally
																						</div>
																					</td>
																				</tr>
																				<xsl:for-each select="//NewDataSet/Table6">
																					<xsl:if test="EXPT_JOB=$JOBID">
																						<tr>
																							<td  class="summaryDetail_xslt" width="15%">
																								<div align="center">
																									<xsl:value-of select="NOOFPKGS" />
																									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																								</div>
																							</td>
																							<td  class="summaryDetail_xslt" width="15%">
																								<xsl:value-of select="RECDDATE" />
																								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																							</td>
																							<td  class="summaryDetail_xslt" width="50%">
																								<div align="center">
																									<xsl:value-of select="RECDWHERE" />
																									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																								</div>
																							</td>
																							<td  class="summaryDetail_xslt" width="20%">
																								<div align="center">
																									<xsl:value-of select="RECDLOCAL" />
																									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																								</div>
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
													</table>

												</td>
											</tr>
											<!--END OF RECEIPT OF CARGO-->
											<tr>
												<td colspan="11"> </td>
											</tr>
											<tr>
												<td colspan="11">
													<table style="border-right: 1px solid #C7E3FE;"  width="100%" border="0" cellspacing="0" cellpadding="0">
														<tr>
															<td class="lblNormal_xslt" width="20%">
																ACTUAL ARRIVAL
															</td>
															<td class="summaryDetail_xslt" width="80%">
																<xsl:value-of select="$ACTUALARDT" />
																<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
															</td>
														</tr>
														<xsl:for-each select="//NewDataSet/Table7">
															<xsl:if test="EXPT_JOB1=$JOBID">

																<tr>
																	<td class="lblNormal_xslt" width="20%">
																		ACTUAL DELIVERY
																		<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>

																	</td>
																	<td class="summaryDetail_xslt" width="80%" >
																		<xsl:value-of select="PKGS_DEL"/>-
																		<xsl:value-of select= "ACTUALDT" />-
																		<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_DelNo('{DELIVERYNO}')">
																			<b> DELIVERY DETAILS </b>
																		</label>
																		<br/>
																	</td>
																</tr>
															</xsl:if>
														</xsl:for-each>
													</table>
												</td>
											</tr>
											<tr>
												<td colspan="11">
													<tr>
														<td colspan="11">
															<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="0" cellpadding="0">
																<tr>
																	<td class="lblNormal_xslt"  width="14%">
																		<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Remarkview('CONREM','','','{$JOBID}')">
																			REMARK
																		</label>

																	</td>
																	<td   class="lblNormal_xslt" width="86%">

																		Consignee Remarks:
																		<xsl:value-of select="REMARK" />
																		<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>

																		<br />
																		MP-Internal Remarks:
																		<xsl:value-of select="MP_INTERNAL_REMARK" />
																		<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>


																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</td>
											</tr>
											<tr>
												<td colspan="11">
													<tr>
														<td colspan="11">
															<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="1" cellpadding="1">
																<!--<xsl:for-each select="//NewDataSet/Table8">
																		<xslif test="JOB_1=$JOBID">-->
																<tr>

																	<td  class="lblNormal_xslt" width="30%">
																		PREPAID FREIGHT APPROVED BY SHIPPER
																	</td>
																	<td  class="summaryDetail_xslt" width="48%">
																		<xsl:value-of select="PPFRTAPPDT" />
																		<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																	</td>

																</tr>
																<tr>
																	<td  class="lblNormal_xslt" width="30%">
																		APPROVAL
																	</td>
																	<td class="summaryDetail_xslt" width="48%">
																		<xsl:value-of select="APPDT" /> -
																		<xsl:value-of select="APPWM" />
																		<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
																	</td>
																</tr>
																<!--</xsl:if>
																	</xsl:for-each>-->
															</table>
														</td>
													</tr>
												</td>
											</tr>
										</xsl:for-each>
									</table>
								</td>
							</tr>
							<xsl:if test="$MODE='s'">

								<tr>
									<td colspan="11">
										<table style="border-right: 1px solid #C7E3FE;" width="100%" border="0" cellspacing="1" cellpadding="1">
											<tr class="DataGridHeader_xslt">
												<td colspan ='3' class="header">
													No. Of Pallets Details
												</td>
											</tr>
											<tr>
												<td class="lblNormal_xslt">
													Containerno
												</td>
												<td class="lblNormal_xslt">
													Importer
												</td>
												<td class="lblNormal_xslt">
													No. Of Pallets
												</td>
											</tr>

											<xsl:for-each select="//NewDataSet/Table8">
												<tr>
													<td class="summaryDetail_xslt" height="9">
														<xsl:value-of select="CONTAINERNO" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail_xslt" height="9">
														<xsl:value-of select="EXP_NAME" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
													<td class="summaryDetail_xslt" height="9">
														<xsl:value-of select="NO_OF_PALLETS" />
														<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
													</td>
												</tr>
											</xsl:for-each>

										</table>
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
