<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
		<html>
			<head>
				<link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
			</head>

			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
				<div id="tableContainer" class="divSpace" style="width:100%" >
					<table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
						<tr class="DataGridFixedHeader">
							<td nowrap="1" width="50px" class="header" ></td>
							<td nowrap="1" width="40px" class="header" ></td>
							<td nowrap="1" width="100px" class="header">Job No</td>
							<td nowrap="1" width="100px" class="header">HBL No</td>
							<td nowrap="1" width="100px" class="header">Date</td>
							<td nowrap="1" width="100px" class="header">Icoterms</td>
							<td nowrap="1" width="100px" class="header">Shipper</td>
							<td nowrap="1" width="100px" class="header">Importer</td>
							<td nowrap="1" width="100px" class="header">Destination</td>
							<td nowrap="1" width="100px" class="header">Pkgs</td>
							<td nowrap="1" width="100px" class="header">Weight</td>
							<td nowrap="1" width="100px" class="header">CHBL Wt</td>
							<td nowrap="1" width="100px" class="header">Volume</td>
							<td nowrap="1" width="100px" class="header">Freight</td>
							<td nowrap="1" width="100px" class="header">Surr Date</td>
							<td nowrap="1" width="100px" class="header">Rel Rec. Date</td>
						</tr>
						<xsl:if test="count(//NewDataSet/Table1)!=''">
							<xsl:for-each select="//NewDataSet/Table1">
								<tr class="summaryDetail">
									<td class="summaryDetail"  align="center" >
										<img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_Job('{ID}','{JOBNO}','{HAWBNO}','{HAWBDATE}','{EXPORTER}','{IMPORTER}','{DESTINATION}','{NOOFPKGS}','{WEIGHT}','{CHBLWT}','{VOLUME}','{FREIGHT}','{FCRSDT}','{RELEASEDT}','{INCOTERM}')" alt="Edit Details {JOBNO}"/>
										<img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fnDelete_Job_Det('{CONSOLENO}','{JOBNO}')" alt="Delete Details {JOBNO}" />

									</td>
									<td class="summaryDetail"  align="center" >
										<img src="../../include/img/Order1.JPG" class="cur"  onclick="parent.fnenter_Order('{JOBNO}','{HAWBNO}', '{NOOFPKGS}','{WEIGHT}')" alt="Enter Order Details {JOBNO}"/>
										<!--<img src="../../include/img/Remark.JPG" class="cur"   />-->
										<!--onclick="parent.fnDelete_Job_Det('{CONSOLENO}','{JOBNO} )" alt="Delete Details {JOBNO}"-->
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="JOBNO" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="HAWBNO" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="HAWBDATE" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="INCOTERM" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="EXPORTER_NAME" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="IMPORTER_NAME" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="DESTINATION" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="NOOFPKGS" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="WEIGHT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="CHBLWT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="VOLUME" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="FREIGHT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="FCRSDT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="RELEASEDT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<!--<td class="summaryDetail"  align="center" >
									<img src="../../include/img/Order.JPG" class="cur"  onclick="parent.fnenter_Order('{JOBNO}','{HAWBNO}', '{NOOFPKGS}','{WEIGHT}')" alt="Enter Order Details {JOBNO}"/>
									-->
									<!--<img src="../../include/img/Remark.JPG" class="cur"   />-->
									<!-- 
									-->
									<!--onclick="parent.fnDelete_Job_Det('{CONSOLENO}','{JOBNO} )" alt="Delete Details {JOBNO}"-->
									<!--
								</td>-->
								</tr>
							</xsl:for-each>
						</xsl:if>
						<xsl:if test="count(//NewDataSet/Table2)!=''">
							<xsl:for-each select="//NewDataSet/Table2">
								<tr class="summaryDetail">
									<td class="summaryDetail"  align="center" >
										<img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_Job('{ID}','{JOBNO}','{HAWBNO}','{HAWBDATE}','{EXPORTER}','{IMPORTER}','{DESTINATION}','{NOOFPKGS}','{WEIGHT}','{CHBLWT}','{VOLUME}','{FREIGHT}','{FCRSDT}','{RELEASEDT}','{INCOTERM}')" alt="Edit Details {JOBNO}"/>
										<img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fnDelete_Job_Det('{CONSOLENO}','{JOBNO}')" alt="Delete Details {JOBNO}" />

									</td>
									<td class="summaryDetail"  align="center" >
										<img src="../../include/img/Order1.JPG" class="cur"  onclick="parent.fnenter_Order('{JOBNO}','{HAWBNO}', '{NOOFPKGS}','{WEIGHT}')" alt="Enter Order Details {JOBNO}"/>
										<!--<img src="../../include/img/Remark.JPG" class="cur"   />-->
										<!--onclick="parent.fnDelete_Job_Det('{CONSOLENO}','{JOBNO} )" alt="Delete Details {JOBNO}"-->
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="JOBNO" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="HAWBNO" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="HAWBDATE" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="INCOTERM" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="EXPORTER_NAME" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="IMPORTER_NAME" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="DESTINATION" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="NOOFPKGS" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="WEIGHT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="CHBLWT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="VOLUME" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="FREIGHT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="FCRSDT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="RELEASEDT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<!--<td class="summaryDetail"  align="center" >
									<img src="../../include/img/Order.JPG" class="cur"  onclick="parent.fnenter_Order('{JOBNO}','{HAWBNO}', '{NOOFPKGS}','{WEIGHT}')" alt="Enter Order Details {JOBNO}"/>
									-->
									<!--<img src="../../include/img/Remark.JPG" class="cur"   />-->
									<!-- 
									-->
									<!--onclick="parent.fnDelete_Job_Det('{CONSOLENO}','{JOBNO} )" alt="Delete Details {JOBNO}"-->
									<!--
								</td>-->
								</tr>
							</xsl:for-each>
						</xsl:if>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
