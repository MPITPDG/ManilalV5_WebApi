<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>
			<head>
				<link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />


			</head>
			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
				<div id="tableContainer" class="divSpace" style="width:100%" >
					<table cellpadding="0" cellspacing="0" border="0"   class="infotable" WIDTH="100%">
						<tr class="DataGridFixedHeader">
							<td nowrap="1" width="50px" class="header"> </td>
							<td nowrap="1" width="100px" class="header">MAWBNO</td>
							<td nowrap="1" width="50px" class="header">MAWB DATE</td>
							<td nowrap="1" width="100px" class="header">EX-JOBNO</td>
							<td nowrap="1" width="70px" class="header">HAWBNO</td>
							<td nowrap="1" width="50px" class="header">HAWB DATE</td>
							<td nowrap="1" width="150px" class="header">CONSIGNEE</td>
							<td nowrap="1" width="30px" class="header">PKGS</td>
							<!--<td nowrap="1" width="50px" class="header">TYPE OF PKGS</td>-->
							<td nowrap="1" width="30px" class="header">GRWT</td>
							<td nowrap="1" width="30px" class="header">cbm</td>
							<!--<td nowrap="1" width="150px" class="header">AIRLINE NAME</td>-->
							<td nowrap="1" width="150px" class="header">FLIGHT DETAILS</td>
							<!--<td nowrap="1" width="50px" class="header">FLIGHT DATE</td>-->
							<td nowrap="1" width="30px" class="header">FREIGHT </td>							 
							<td nowrap="1" width="20px" class="header">INVOICE TYPE</td>
						</tr>
						<xsl:for-each select="//NewDataSet/Table">
							<tr class="summaryDetail">
								<xsl:variable name="MAWB_NO" select="MAWBNO"></xsl:variable>
								<xsl:if test="$MAWB_NO!=''">
								<td class="summaryDetail"  align="center" >
									<img src="../../include/img/generate.gif" class="cur" onclick="parent.fnPopulate_Console('{MAWBNO}')"  alt="Send Auto Prealert {MAWBNO}"/>
								</td>
								</xsl:if>
								<xsl:if test="$MAWB_NO =''">
									<td class="summaryDetail"  align="center" >
										<!--<img src="../../include/img/generate.gif" class="cur" onclick="parent.fnPopulate_Console('{MAWBNO}')"  alt="Send Auto Prealert {MAWBNO}"/>-->
									</td>
								</xsl:if>
								<td class="summaryDetail" width="150px" align="left">
									<xsl:value-of select="MAWBNO" />
								</td>
								<td  class="summaryDetail" width="50px" align="left">
									<xsl:value-of select="AEROBILLDT" />
								</td>
								<td class="summaryDetail" width="150px" align="left">
									<xsl:value-of select="EXPTNO" />
								</td>
								<!--<td>
									 
										<table cellpadding="0" cellspacing="0" border="0"   class="infotable" WIDTH="150px">
											<tr>
												<td class="summaryDetail" width="150px" align="left">
													<xsl:value-of select="EXPTNO" />
												</td>
											</tr>
										</table>
									 
								</td>-->
								<td class="summaryDetail" width="100px" align="left">
									<xsl:value-of select="HOUSEBILLNO" />
								</td>
								<td class="summaryDetail" width="50px" align="left">
									<xsl:value-of select="HOUSEBILLDT" />
								</td>
								<td class="summaryDetail" width="150px" align="left">
									<xsl:value-of select="CONS_NAME" />
								</td>
								<td class="summaryDetail" width="30px" align="left">
									<xsl:value-of select="EXPT_NOOFPGS" />
								</td>
								<!--<td class="summaryDetail" width="30px" align="left">
									<xsl:value-of select="EXPT_TYPEOFPKGS" />
								</td>-->
								<td class="summaryDetail" width="30px" align="left">
									<xsl:value-of select="EXPT_GRWT" />
								</td>
								<td class="summaryDetail" width="30px" align="left">
									<xsl:value-of select="EXPT_VOLUME" />
								</td>
								<!--<td class="summaryDetail" width="150px" align="left">
									<xsl:value-of select="AIRLINENAME" />
								</td>-->
								<td class="summaryDetail" width="150px" align="left">
									<xsl:value-of select="FLIGHTDET" />
								</td>
								<!--<td class="summaryDetail" width="50px" align="left">
									<xsl:value-of select="FLIGHTDT" />
								</td>-->
								<td class="summaryDetail" width="30px" align="left">
									<xsl:value-of select="MAWBFRT" />
								</td>
								<td class="summaryDetail" width="20px" align="left">
									<xsl:value-of select="EXPT_INVTYPE" />
								</td>
							</tr>
						</xsl:for-each>
						<tr valign="top">
							<td colspan="17" class="summaryDetail">
								<xsl:if test="count(//NewDataSet/Table)!=1">
									<xsl:value-of select="count(//NewDataSet/Table)"/> Records
								</xsl:if>
								<xsl:if test="count(//NewDataSet/Table)=1">
									1 Record
								</xsl:if>
							</td>
						</tr>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>

