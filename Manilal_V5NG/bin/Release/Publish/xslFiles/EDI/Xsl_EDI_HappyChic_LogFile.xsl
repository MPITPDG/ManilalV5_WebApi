<xsl:stylesheet version="1.0"
    xmlns="urn:schemas-microsoft-com:office:spreadsheet"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	xmlns:user="urn:my-scripts"
	xmlns:o="urn:schemas-microsoft-com:office:office"
	xmlns:x="urn:schemas-microsoft-com:office:excel"
	xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet" >


	<xsl:template match="NewDataSet">
		<Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
		 xmlns:o="urn:schemas-microsoft-com:office:office"
		 xmlns:x="urn:schemas-microsoft-com:office:excel"
		 xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
		 xmlns:html="http://www.w3.org/TR/REC-html40">
			<Styles>
				<Style ss:ID="s01">
					<Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="10" ss:Bold="1"/>
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
					<Interior/>
				</Style>
				<Style ss:ID="s010">
					<Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="12" ss:Bold="1"/>
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
					<Interior/>
				</Style>
				<Style ss:ID="s100">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="s1000">
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="s1001">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="s101">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat/>
					<Protection/>
				</Style>

				<Style ss:ID="s1010">
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="s1011">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="s1011_2">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat ss:Format="Standard"/>
					<Protection/>
				</Style>
				<Style ss:ID="s1011_3">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat ss:Format="0.000"/>
					<Protection/>
				</Style>
				<Style ss:ID="s1011_4">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat ss:Format="0.0000"/>
					<Protection/>
				</Style>
				<Style ss:ID="s25">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
				</Style>
				<Style ss:ID="s250">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000" ss:Bold="1"/>
				</Style>
				<Style ss:ID="s24">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
					<NumberFormat ss:Format="Standard"/>
				</Style>
				<Style ss:ID="s240">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000" ss:Bold="1"/>
					<NumberFormat ss:Format="Standard"/>
				</Style>
				<Style ss:ID="s24_3">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
					<NumberFormat ss:Format="0.000"/>
				</Style>
				<Style ss:ID="s24_30">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000" ss:Bold="1"/>
					<NumberFormat ss:Format="0.000"/>
				</Style>
				<Style ss:ID="s24_4">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
					<NumberFormat ss:Format="0.0000"/>
				</Style>
				<Style ss:ID="s24_40">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000" ss:Bold="1"/>
					<NumberFormat ss:Format="0.0000"/>
				</Style>
				<Style ss:ID="s24_2">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
					<NumberFormat ss:Format="0.00"/>
				</Style>
				<Style ss:ID="s24_20">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000" ss:Bold="1"/>
					<NumberFormat ss:Format="0.00"/>
				</Style>
			</Styles>
			<Worksheet>
				<xsl:attribute name="ss:Name">LOG FILE</xsl:attribute>
				<Table ss:DefaultColumnWidth="82.5">
					<Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="70"/>
					<Column ss:Width="70"/>
					<Column ss:Index="4" ss:Width="65"/>
					<Column ss:Index="5" ss:Width="50"/>
					<Column ss:Index="6" ss:Width="50"/>
					<Column ss:Index="7" ss:Width="70"/>
					<Column ss:Index="8" ss:Width="70"/>
					<Column ss:Index="9" ss:Width="55"/>
					<Column ss:Index="10" ss:Width="55"/>
					<Column ss:Index="11" ss:Width="75"/>
					<Column ss:Index="12" ss:Width="50"/>

					<xsl:apply-templates select="NewDataSet"/>
					<!--<xsl:for-each select="Table">-->
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">
									HAPPYCHIC LOGFILE
									<!--<xsl:value-of select="HEADER" />-->
								</Data>
							</Cell>
						</Row>
					<!--</xsl:for-each>-->
					<xsl:if test="count(Table3/*)>0">
						<Row ss:AutoFitHeight="0" ss:Height="25.5">
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONTAINERNO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">EXPTNO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ORDERNO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">STYLENO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">PKGS</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">GRWT</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">NETWT</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">PIECES</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">VOLUME</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">SHIPLINLINE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ORIGIN</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">SAILING DATE</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">REMARK</Data>
							</Cell>
						</Row>
						<xsl:for-each select="Table3">
							<Row ss:AutoFitHeight="1">
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONTAINERNO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="EXPTNO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ORDERNO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="STYLENO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="PKGS"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="GRWT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="NETWT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="PIECES"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24_3">
									<Data ss:Type="String">
										<xsl:value-of select="VOLUME"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="SHIPLINE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ORIGIN"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="SAILINGDATE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="REMARK"/>
									</Data>
								</Cell>
							</Row>
						</xsl:for-each>
					</xsl:if>
				</Table>
				<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
					<Selected/>
					<FreezePanes/>
					<FrozenNoSplit/>
					<SplitHorizontal>3</SplitHorizontal>
					<TopRowBottomPane>3</TopRowBottomPane>
					<ActivePane>2</ActivePane>
					<Panes>
						<Pane>
							<Number>3</Number>
						</Pane>
						<Pane>
							<Number>2</Number>
							<ActiveRow>5</ActiveRow>
							<ActiveCol>2</ActiveCol>
						</Pane>
					</Panes>
					<ProtectObjects>False</ProtectObjects>
					<ProtectScenarios>False</ProtectScenarios>
				</WorksheetOptions>
			</Worksheet>

			<Worksheet>
				<xsl:attribute name="ss:Name">LOG FILE 2</xsl:attribute>
				<Table ss:DefaultColumnWidth="82.5">
					<Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="70"/>
					<Column ss:Width="70"/>
					<Column ss:Index="4" ss:Width="65"/>
					<Column ss:Index="5" ss:Width="50"/>
					<Column ss:Index="6" ss:Width="50"/>
					<Column ss:Index="7" ss:Width="70"/>
					<Column ss:Index="8" ss:Width="70"/>
					<Column ss:Index="9" ss:Width="55"/>
					<Column ss:Index="10" ss:Width="55"/>
					<Column ss:Index="11" ss:Width="75"/>
					<Column ss:Index="12" ss:Width="50"/>
					<xsl:apply-templates select="NewDataSet"/>
					<!--<xsl:for-each select="Table">-->
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">
									HAPPYCHIC ALERT MASTER DATA
									<!--<xsl:value-of select="HEADER1" />-->
								</Data>
							</Cell>
						</Row>
					<!--</xsl:for-each>-->
					<xsl:if test="count(Table4/*)>0">
						<Row ss:AutoFitHeight="0" ss:Height="25.5">
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">STYLE NO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">VAR1</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">SHIPLINE CODE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">DEP CODE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">DEP SOUC CODE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">DOC RECD</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">MODE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">PKGS</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ORDERNO</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">LINER NAME</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">GRWT</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">NETWT</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">PIECES</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">ORIGIN PORT</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">DEST PORT</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">ORIGIN CITY</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">DEST CITY</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CBM</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">TOT VOLUME</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">PART ORDER</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CONTAINERNO</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CBM</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">TOT VOLUME</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">PART ORDER</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CONTAINERNO</Data>
							</Cell>

							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CONTEINER TYPE</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CIE DIRECT</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CODE CDT</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">TYPE ORDER</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CODE ASS</Data>
							</Cell>
						</Row>
						<xsl:for-each select="Table4">
							<Row ss:AutoFitHeight="1">
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ART_CODE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ART_VAR1"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CIE_TRANSPORT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="DEP_CODE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="DEP_SOC_CODE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="DT_DOC"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s25">
									<Data ss:Type="Number">
										<xsl:value-of select="NB_COLIS"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="Number">
										<xsl:value-of select="NO_DOC"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="NOM"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="PDS_BRUT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="PDS_NET"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="QTE_RECEP"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="VIL_CODE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="VIL_CODE2"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="VILLE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="VILLE_LIV"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="VOL"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="VOL_TOTAL"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="NO_LIGNE_CMDE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="NO_CONTENANT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="TYPE_CONTAINER"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="CIE_DIRECT"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CODE_CDT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="TYP_ORDER"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="CODE_ASS"/>
									</Data>
								</Cell>
							</Row>
						</xsl:for-each>
					</xsl:if>
				</Table>
				<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
					<Selected/>
					<FreezePanes/>
					<FrozenNoSplit/>
					<SplitHorizontal>3</SplitHorizontal>
					<TopRowBottomPane>3</TopRowBottomPane>
					<ActivePane>2</ActivePane>
					<Panes>
						<Pane>
							<Number>3</Number>
						</Pane>
						<Pane>
							<Number>2</Number>
							<ActiveRow>5</ActiveRow>
							<ActiveCol>2</ActiveCol>
						</Pane>
					</Panes>
					<ProtectObjects>False</ProtectObjects>
					<ProtectScenarios>False</ProtectScenarios>
				</WorksheetOptions>
			</Worksheet>

			<Worksheet>
				<xsl:attribute name="ss:Name">LOG FILE 3</xsl:attribute>
				<Table ss:DefaultColumnWidth="82.5">
					<Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="70"/>
					<Column ss:Width="70"/>
					<Column ss:Index="4" ss:Width="65"/>
					<Column ss:Index="5" ss:Width="50"/>
					<Column ss:Index="6" ss:Width="50"/>
					<Column ss:Index="7" ss:Width="70"/>
					<Column ss:Index="8" ss:Width="70"/>
					<Column ss:Index="9" ss:Width="55"/>
					<Column ss:Index="10" ss:Width="55"/>
					<Column ss:Index="11" ss:Width="75"/>
					<Column ss:Index="12" ss:Width="50"/>
					<xsl:apply-templates select="NewDataSet"/>
					<!--<xsl:for-each select="Table">-->
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">
									HAPPYCHIC ALERT CHILD DATA
									<!--<xsl:value-of select="HEADER1" />-->
								</Data>
							</Cell>
						</Row>
					<!--</xsl:for-each>-->
					<xsl:if test="count(Table5/*)>0">
						<Row ss:AutoFitHeight="0" ss:Height="25.5">						 
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">DEP SOUC CODE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ORDERNO</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">PART ORDER</Data>
							</Cell>							
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">STYLENO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">VAR1</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">PIECES</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">TYPE ORDER</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CODE SIZE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CODE DIM</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CODE ASS</Data>
							</Cell>							
						</Row>
						<xsl:for-each select="Table5">
							<Row ss:AutoFitHeight="1">
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="DEP_SOC_CODE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="NO_DOC"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="NO_LIGNE_CMDE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ART_CODE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ART_VAR1"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="QTE_RECEP"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s25">
									<Data ss:Type="Number">
										<xsl:value-of select="TYP_ORDER"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="Number">
										<xsl:value-of select="CODE_SIZE"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="CODE_DIM"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="CODE_ASS"/>
									</Data>
								</Cell>
								 
							</Row>
						</xsl:for-each>
					</xsl:if>
				</Table>
				<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
					<Selected/>
					<FreezePanes/>
					<FrozenNoSplit/>
					<SplitHorizontal>3</SplitHorizontal>
					<TopRowBottomPane>3</TopRowBottomPane>
					<ActivePane>2</ActivePane>
					<Panes>
						<Pane>
							<Number>3</Number>
						</Pane>
						<Pane>
							<Number>2</Number>
							<ActiveRow>5</ActiveRow>
							<ActiveCol>2</ActiveCol>
						</Pane>
					</Panes>
					<ProtectObjects>False</ProtectObjects>
					<ProtectScenarios>False</ProtectScenarios>
				</WorksheetOptions>
			</Worksheet>
		</Workbook>
	</xsl:template>
</xsl:stylesheet>
