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
				<xsl:attribute name="ss:Name">MP_Cargo_Format</xsl:attribute>
				<Table ss:DefaultColumnWidth="100.5">
					<Column ss:Index="1" ss:Width="55"/>
					<Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="150"/>
					<Column ss:Width="60"/>
					<!--<Column ss:Index="4" ss:Width="75"/>-->
					<Column ss:Index="5" ss:Width="55"/>
					<Column ss:Index="6" ss:Width="200"/>
					<Column ss:Index="7" ss:Width="75"/>
					<Column ss:Index="8" ss:Width="50"/>
					<Column ss:Index="9" ss:Width="65"/>
					<Column ss:Index="10" ss:Width="70"/>
					<Column ss:Index="11" ss:Width="75"/>
					<Column ss:Index="12" ss:Width="50"/>
					<Column ss:Width="50"/>
					<xsl:apply-templates select="NewDataSet"/>
					<xsl:for-each select="Table">
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">MP CARGO </Data>
							</Cell>
						</Row>
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">
									<xsl:value-of select="DIVISION" />
								</Data>
							</Cell>
						</Row>
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">
									<xsl:value-of select="ETA_TIME" />
								</Data>
							</Cell>
						</Row>

					</xsl:for-each>
					<xsl:if test="count(Table2/*)>0">
						<Row ss:AutoFitHeight="0" ss:Height="25.5">
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">DIVISION</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">COMMANDES</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONTAINER NO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONSOLENO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ETA</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">JOB NO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ORIGIN</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">DESTINATION</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CBM</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">EXCHANGE RATE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONSOLE RATE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONSOLE FEE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">T1</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">FREIGHT</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">BAF</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CAF</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">DECHARGEMENT</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">TRANSPORT</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">PEAGE DOUANE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">THC</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">LS</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">BL</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ISPS</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">TRACTION</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">MULTI STOP</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">TRUCKING</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">FABRICATION</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">DEMONTAGE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">SCAN</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">INSPECTION PHISIQUE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">HEURE DATTENTE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">MESURE GAZ</Data>
							</Cell>
						</Row>
						<xsl:for-each select="Table2">
							<Row ss:AutoFitHeight="1">
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="DIVISION"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="COMMANDES"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONTAINERNO"/>

									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONSOLENO" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ETA" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="JOBNO" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ORIGIN" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="DESTINATION" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CBM" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="EXCHANGERATE" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONSOLERATE" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONSOLEFEE" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="T1" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="FREIGHT" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="BAF" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CAF" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="DECHARGEMENT" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="TRANSPORT" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="PEAGEDOUANE" />
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="THC"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="LS"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="BL"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ISPS"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="TRACTION"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="MULTISTOP"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="TRUCKING"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="FABRICATION"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="DEMONTAGE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="SCAN"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="INSPECTIONPHYSIQUE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="HEUREDATTENTE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="MESUREGAZ"/>
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
					<SplitHorizontal>20</SplitHorizontal>
					<TopRowBottomPane>20</TopRowBottomPane>
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
				<xsl:attribute name="ss:Name">Happychic_Format</xsl:attribute>
				<Table ss:DefaultColumnWidth="100.5">
					<Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="80"/>
					<Column ss:Index="3" ss:Width="150"/>
					<Column ss:Width="70"/>
					<!--<Column ss:Index="4" ss:Width="65"/>-->
					<Column ss:Index="5" ss:Width="150"/>
					<Column ss:Index="6" ss:Width="200"/>
					<Column ss:Index="7" ss:Width="70"/>
					<Column ss:Index="8" ss:Width="70"/>
					<Column ss:Index="9" ss:Width="55"/>
					<Column ss:Index="10" ss:Width="55"/>
					<Column ss:Index="11" ss:Width="75"/>
					<Column ss:Index="12" ss:Width="50"/>
					<xsl:apply-templates select="NewDataSet"/>
					<xsl:for-each select="Table">
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">MP CARGO </Data>
							</Cell>
						</Row>
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">
									<xsl:value-of select="DIVISION" />
								</Data>
							</Cell>
						</Row>
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">
									<xsl:value-of select="ETA_TIME" />
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
					<xsl:if test="count(Table3/*)>0">
						<Row ss:AutoFitHeight="0" ss:Height="25.5">
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONTAINER NO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ORIGIN</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">REF DOSSIER TRANSITAIRE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">PREFACTRATION TRANSITAIRE</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">BL NO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">NUMEROS DES COMMANDES</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ENSEIGNE</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">NB COLIS</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">POIDS (GW)</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">VOLUME</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">MANAGMENT FEES</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">LIVRAISON</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">T1</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">FRET</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">THC</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">FRAIS ARRIVEE GROUPAGE</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">SCAN</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">ISPS</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">FRAIS DE BL</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">TVA</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">TOTAL</Data>
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
										<xsl:value-of select="ORIGIN"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="REFDOSSIERTRANSITAIRE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="PREFACTRATIONTRANSITAIRE"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="BLNO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="NUMEROSDESCOMMANDES"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ENSEIGNE"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="NBCOLIS"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="POIDS"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="VOLUME"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="MANAGMENTFEES"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="LIVRAISON"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="T1"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="FRET"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="THC"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="FRAISARRIVEEGROUPAGE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="SCAN"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ISPS"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="FRAISDEBL"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="TVA"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="TOTAL"/>
									</Data>
								</Cell>
							</Row>
						</xsl:for-each>
					</xsl:if>
				</Table>
			</Worksheet>
			<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
				<Selected/>
				<FreezePanes/>
				<FrozenNoSplit/>
				<SplitHorizontal>21</SplitHorizontal>
				<TopRowBottomPane>21</TopRowBottomPane>
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

		</Workbook>
	</xsl:template>
</xsl:stylesheet>
