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
				<xsl:attribute name="ss:Name">HAWB_CC_FRT</xsl:attribute>
				<Table ss:DefaultColumnWidth="100.5">
					<Column ss:Index="1" ss:Width="40"/>
					<Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="65"/>
					<Column ss:Index="3" ss:Width="55"/>
					<Column ss:Index="4" ss:Width="60"/>
					<Column ss:Index="5" ss:Width="50"/>
					<Column ss:Index="6" ss:Width="50"/>
					<Column ss:Index="7" ss:Width="30"/>
					<Column ss:Index="8" ss:Width="50"/>
					<Column ss:Index="9" ss:Width="50"/>
					<Column ss:Index="10" ss:Width="200"/>
					<Column ss:Index="11" ss:Width="60"/>
					<Column ss:Index="12" ss:Width="85"/>
					<Column ss:Index="13" ss:Width="50"/>
					<Column ss:Index="14" ss:Width="75"/>
					<Column ss:Index="15" ss:Width="80"/>

					<xsl:apply-templates select="NewDataSet"/>
					<xsl:for-each select="Table">
						<Row>
							<Cell ss:MergeAcross="15" ss:StyleID="s01">
								<Data ss:Type="String">MANILAL PATEL CLEARING FORWARDING  </Data>
							</Cell>
						</Row>
						<Row>
							<Cell ss:MergeAcross="15" ss:StyleID="s01">
								<Data ss:Type="String">
									PLANING FLIGHT DATE FROM
									<xsl:value-of select="PERIOD" />
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
					<Row ss:AutoFitHeight="0" ss:Height="25.5">
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">CITY</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">MAWBNO</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">MAWBDT</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">FLIGHTDT</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">HAWBNO</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">HAWBDT</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">FRT</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">CHBLWT</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">GR WT</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">HAWB RATE</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">EX-RATE</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">INVOICENO</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">HAWB FRT RATE</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">INVOICE AMT</Data>
						</Cell>
						<Cell ss:StyleID="s1010">
							<Data ss:Type="String">YET TO INVOICE AMT</Data>
						</Cell>
					</Row>
					<xsl:for-each select="Table1">
						<Row ss:AutoFitHeight="1">
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="CITY_NAME"/>
								</Data>
							</Cell>
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="MAWBNO"/>
								</Data>
							</Cell>
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="MAWBDT"/>
								</Data>
							</Cell>
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="FLIGHTDT" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="HAWBNO" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="HAWBDT" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="FRT" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="CHBLWT" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="GR_WT" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="FRT_RATE" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="EX_RATE" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="FRT_INVOICENO" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s24_3">
								<Data ss:Type="Number">
									<xsl:value-of select="HAWB_FRT_RATE" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s24_3">
								<Data ss:Type="Number">
									<xsl:value-of select="FRT_INV_AMT" />
								</Data>
							</Cell>
							<Cell ss:StyleID="s24_3">
								<Data ss:Type="Number">
									<xsl:value-of select="YET_TO_FRT_AMT" />
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
				</Table>
				<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
					<Selected/>
					<FreezePanes/>
					<FrozenNoSplit/>
					<SplitHorizontal>3</SplitHorizontal>
					<TopRowBottomPane>14</TopRowBottomPane>
					<ActivePane>2</ActivePane>
					<Panes>
						<Pane>
							<Number>3</Number>
						</Pane>
						<Pane>
							<Number>2</Number>
							<ActiveRow>2</ActiveRow>
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