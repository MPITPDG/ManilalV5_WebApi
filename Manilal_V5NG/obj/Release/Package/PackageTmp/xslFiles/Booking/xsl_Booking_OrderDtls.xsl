<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
		<html>
			<head>
				<link href="../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
			</head>

			<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
				<div id="tableContainer" class="divSpace" style="width:100%" >
					<table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
						<tr class="DataGridFixedHeader">
							<td nowrap="1" width="60px" class="header" ></td>
							<td nowrap="1" width="100px" class="header">Order No</td>
							<td nowrap="1" width="100px" class="header">Style/Ref #</td>
							<td nowrap="1" width="100px" class="header">PCS</td>
							<td nowrap="1" width="100px" class="header">Type Of Pcs</td>
							<td nowrap="1" width="100px" class="header">PKGS</td>
							<td nowrap="1" width="100px" class="header">Type Pkgs</td>
							<td nowrap="1" width="100px" class="header">CBM</td>
							<td nowrap="1" width="100px" class="header">GRWT</td>							 
						</tr>
						<xsl:if test="count(//NewDataSet/Table1)!=''">

							<xsl:for-each select="//NewDataSet/Table1">
								<tr class="summaryDetail">
									<td class="summaryDetail"  align="center" >
										<img src="../include/img/edit_item.gif" class="cur"  onclick="parent.fn_orderdtls_populate('{ID}','{ORDERNO}','{STYLENO}','{PCS}','{TYPEOFPCS}','{PKGS}','{TYPEOFPKGS}','{CBM}','{GRWT}')" alt="Edit Order No {id}"/>
										<img src="../include/img/thrash.gif" class="cur"  onclick="parent.fn_orderdtls_delete('{ID}')" alt="Remove Order No {ORDERNO}" />
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="ORDERNO" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="STYLENO" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="PCS" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="TYPEOFPCS" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="PKGS" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="TYPEOFPKGS" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="CBM" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="GRWT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>									 
								</tr>
							</xsl:for-each>
						</xsl:if>
						<xsl:if test="count(//NewDataSet/Table2)!=''">
							<xsl:for-each select="//NewDataSet/Table2">
								<tr class="summaryDetail">
									<td class="summaryDetail"  align="center" >
										<img src="../include/img/edit_item.gif" class="cur"  onclick="parent.fn_orderdtls_populate('{ID}','{ORDERNO}','{STYLENO}','{PCS}','{TYPEOFPCS}','{PKGS}','{TYPEOFPKGS}','{CBM}','{GRWT}')" alt="Edit Details {id}"/>
										<img src="../include/img/thrash.gif" class="cur"  onclick="parent.fn_orderdtls_delete('{ID}')" alt="Delete Details {ORDERNO}" />
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="ORDERNO" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="STYLENO" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="PCS" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="TYPEOFPCS" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="PKGS" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="TYPEOFPKGS" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="CBM" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
									<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="GRWT" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>
								</tr>
							</xsl:for-each>
						</xsl:if>
					</table>
				</div>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
