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
				<Style ss:ID="Default" ss:Name="Normal">
					<Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="8" />
					<Alignment ss:Vertical="Bottom"/>
					<Borders/>
					<NumberFormat  ss:Format="Fixed"/>
					<Protection/>
				</Style>
				<Style ss:ID="s01">
					<Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="8" ss:Bold="1"/>
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
					<Interior/>
				</Style>
				<Style ss:ID="s21">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"
						 ss:Color="#FFFFFF"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"
						 ss:Color="#FFFFFF"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"
						 ss:Color="#FFFFFF"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#000080" ss:Pattern="Solid"/>
				</Style>
				<Style ss:ID="s24">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="0"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<NumberFormat ss:Format="Standard"/>
				</Style>
				<Style ss:ID="s25">
					<Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
				</Style>
				<Style ss:ID="s26">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"
						 ss:Color="#FFFFFF"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"
						 ss:Color="#FFFFFF"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"
						 ss:Color="#FFFFFF"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#000080" ss:Pattern="Solid"/>
				</Style>
				<Style ss:ID="s29">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#000080" ss:Pattern="Solid"/>
				</Style>
				<Style ss:ID="s68">
					<Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
				</Style>
				<Style ss:ID="s69">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
					<NumberFormat ss:Format="Standard"/>
				</Style>
				<Style ss:ID="s39">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
					 ss:Bold="1"/>
					<Interior/>
				</Style>
			</Styles>


			<Worksheet>
				
				<xsl:attribute name="ss:Name">Cient_Ledger_Statement</xsl:attribute>
				<Table>
					<Column ss:AutoFitWidth="0" ss:Width="29.25"/>
					<Column ss:AutoFitWidth="0" ss:Width="98.25"/>
					<Column ss:AutoFitWidth="0" ss:Width="89.25"/>
					<Column ss:AutoFitWidth="0" ss:Width="314.25"/>
					<Column ss:Width="79.5" ss:Span="1"/>
					<Column ss:Index="7" ss:Width="54"/>
					<xsl:apply-templates select="NewDataSet"/>					
					<xsl:for-each select="Table1">
						<xsl:choose >
							<xsl:when test="ISHEADER=1 and CLIENT !=''" >
								<xsl:for-each select="//NewDataSet/Table">
									<Row>
										<Cell ss:MergeAcross="5" ss:StyleID="s39">
											<Data ss:Type="String">
												<xsl:value-of select="HEADER"/>
											</Data>
										</Cell>
									</Row>
								</xsl:for-each>
								<Row  ss:AutoFitHeight="0" ss:Height="22.5">
									<Cell ss:StyleID="s21">
										<Data ss:Type="String"></Data>
									</Cell>
									<Cell ss:StyleID="s21">
										<Data ss:Type="String">Number</Data>
									</Cell>
									<Cell ss:StyleID="s21">
										<Data ss:Type="String">Date</Data>
									</Cell>
									<Cell ss:StyleID="s21">
										<Data ss:Type="String">Particulars</Data>
									</Cell>
									<Cell ss:StyleID="s21">
										<Data ss:Type="String">Debit</Data>
									</Cell>
									<Cell ss:StyleID="s21">
										<Data ss:Type="String">Credit</Data>
									</Cell>
								</Row>
								<Row ss:AutoFitHeight="1">
									<Cell ss:MergeAcross="5" ss:StyleID="s68">
										<Data ss:Type="String">
											<xsl:value-of select="CLIENT"/>
										</Data>
									</Cell>
								</Row>
							</xsl:when>

							<xsl:when test="ISHEADER=1 and CLIENT =''" >

								<Row ss:AutoFitHeight="1">
									<Cell ss:StyleID="s25">
										<Data ss:Type="String">

										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">

										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">

										</Data>
									</Cell>

									<Cell  ss:StyleID="s68">
										<Data ss:Type="String">
											<xsl:value-of select="NARR"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s69">
										<Data ss:Type="Number">
											<xsl:value-of select="DRAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s69">
										<Data ss:Type="Number">
											<xsl:value-of select="CRAMT"/>
										</Data>
									</Cell>
								</Row>
							</xsl:when>
							<xsl:otherwise>
								<Row ss:AutoFitHeight="1">
									<Cell ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="TRANSTYPE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="TRANSCODE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="TRANSDATE"/>
										</Data>
									</Cell>

									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="NARR"/>
											<xsl:value-of select="SUP_SNAME"/>
											<xsl:value-of select="EXP_SNAME"/>
											<xsl:value-of select="ACCTNAME"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="DRAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="CRAMT"/>
										</Data>
									</Cell>
								</Row>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:for-each>
				</Table>
				<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
					<PageSetup>
						<Layout x:Orientation="Landscape"/>
					</PageSetup>
					<Unsynced/>
					<Print>
						<ValidPrinterInfo/>
						<HorizontalResolution>600</HorizontalResolution>
						<VerticalResolution>600</VerticalResolution>
					</Print>
					<Selected/>
					<Panes>
						<Pane>
							<Number>3</Number>
							<ActiveRow>13</ActiveRow>
							<ActiveCol>1</ActiveCol>
						</Pane>
					</Panes>
					<ProtectObjects>False</ProtectObjects>
					<ProtectScenarios>False</ProtectScenarios>
				</WorksheetOptions>
				<PageBreaks xmlns="urn:schemas-microsoft-com:office:excel">
					<RowBreaks>
						<xsl:for-each select="//NewDataSet/Table2">
							<RowBreak>
								<Row>
									<xsl:value-of select="PAGEBRKID"/>
								</Row>
							</RowBreak>
						</xsl:for-each>
					</RowBreaks>
				</PageBreaks>
			</Worksheet>
		</Workbook>
	</xsl:template>
</xsl:stylesheet>
