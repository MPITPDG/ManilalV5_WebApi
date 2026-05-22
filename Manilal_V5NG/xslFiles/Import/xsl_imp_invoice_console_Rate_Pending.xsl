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
				<xsl:attribute name="ss:Name">Pending_Rate_List</xsl:attribute>
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
					<xsl:for-each select="Table">
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">
									<xsl:value-of select="HEADER" />
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
					<xsl:if test="count(Table1/*)>0">
						<Row ss:AutoFitHeight="0" ss:Height="25.5">
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONSIGNEE NAME</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONSOLENO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONSOLEDT</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">JOBNO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">NO OF PKGS</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">WEIGHT</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">VOLUME</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ACTUAL ARRAIVAL DT</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">ACTUAL DELIVERY DT</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ETA</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ETD</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CONTAINERNO</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">ORIGIN</Data>
							</Cell>
						</Row>
						<xsl:for-each select="Table1">
							<Row ss:AutoFitHeight="1">
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONNAME"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONSOLENO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONSOLEDT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="JOB_NO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="NO_OF_PKGS"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="WEIGHT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="VOLUME"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="ACTUAL_ARRIVAL_DT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24_3">
									<Data ss:Type="String">
										<xsl:value-of select="ACTUAL_DELIVERY_DT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="ETA"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="SEA_ETD"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="CONTAINER_NO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="ORIGINE"/>
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
				<xsl:attribute name="ss:Name">Complete_Rate_List</xsl:attribute>
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
					<xsl:for-each select="Table">
						<Row>
							<Cell ss:MergeAcross="27" ss:StyleID="s01">
								<Data ss:Type="String">
									<xsl:value-of select="HEADER1" />
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
					<xsl:if test="count(Table2/*)>0">
						<Row ss:AutoFitHeight="0" ss:Height="25.5">
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONSIGNEE NAME</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">INVOICE NO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONSOLENO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">CONSOLEDT</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">JOBNO</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">NO OF PKGS</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">WEIGHT</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">VOLUME</Data>
							</Cell>
							<Cell ss:StyleID="s1010">
								<Data ss:Type="String">ACTUAL ARRAIVAL DT</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">ACTUAL DELIVERY DT</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">ETA</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">ETD</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">CONTAINERNO</Data>
							</Cell>
							<Cell ss:StyleID="s1011">
								<Data ss:Type="String">ORIGIN</Data>
							</Cell>
						</Row>
						<xsl:for-each select="Table2">
							<Row ss:AutoFitHeight="1">
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONNAME"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="INVOICENO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONSOLENO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="CONSOLEDT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="JOB_NO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="NO_OF_PKGS"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s25">
									<Data ss:Type="Number">
										<xsl:value-of select="WEIGHT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="Number">
										<xsl:value-of select="VOLUME"/>
									</Data>
								</Cell>
								
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="ACTUAL_ARRIVAL_DT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="ACTUAL_DELIVERY_DT"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="ETA"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s25">
									<Data ss:Type="String">
										<xsl:value-of select="SEA_ETD"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="CONTAINER_NO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s24">
									<Data ss:Type="String">
										<xsl:value-of select="ORIGINE"/>
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
