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
					<Alignment ss:Vertical="Bottom"/>
					<Borders/>
					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
					<Interior/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="m47186592">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="14" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
				</Style>
				<Style ss:ID="s62">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
				</Style>
				<Style ss:ID="s63">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
					</Borders>

					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF" ss:Bold="1" />
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"  />
				</Style>
				<Style ss:ID="s64">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
					</Borders>
					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
				</Style>
				<Style ss:ID="s66">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
				</Style>
				<Style ss:ID="s67">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
				</Style>
				<Style ss:ID="s68">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
					</Borders>
					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat ss:Format="0.0000"/>
				</Style>
				<Style ss:ID="s69">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<NumberFormat ss:Format="0.0000"/>
				</Style>
				<Style ss:ID="s70">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<NumberFormat ss:Format="0.0000"/>
				</Style>
				<Style ss:ID="s71">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:Bold="1"/>
				</Style>
				<Style ss:ID="s72">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<NumberFormat ss:Format="Fixed"/>
					<Font ss:Bold="1"/>
				</Style>
				<Style ss:ID="s75">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<NumberFormat ss:Format="0.0000"/>
					<Font ss:Bold="1"/>
				</Style>
				<Style ss:ID="s73">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<NumberFormat ss:Format="Fixed"/>
				</Style>
				<Style ss:ID="s74">
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<NumberFormat ss:Format="Fixed"/>
				</Style>
				<Style ss:ID="s76">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="2"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
					</Borders>
					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"/>
					<Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
					<NumberFormat ss:Format="Fixed"/>
				</Style>
			</Styles>
			<Worksheet>
				<xsl:attribute name="ss:Name">ETA WISE</xsl:attribute>
				<xsl:for-each select="//NewDataSet/Table">

					<Table>
						<Column ss:AutoFitWidth="0" ss:Width="75"/>
						<Column ss:AutoFitWidth="0" ss:Width="72"/>
						<Column  ss:AutoFitWidth="0" ss:Width="57"/>
						<Column ss:AutoFitWidth="0" ss:Width="35"/>
						<Column ss:Width="162"/>
						<Column ss:Width="19"/>
						<xsl:apply-templates select="NewDataSet"/>
						<Row ss:Height="18.75">
							<Cell ss:MergeAcross="4" ss:StyleID="m47186592">
								<Data ss:Type="String">ETA WISE INV JOB PENDING FOR INVOICING</Data>
							</Cell>
						</Row>
						<Row ss:AutoFitHeight="0">
							<Cell ss:StyleID="s63">
								<Data ss:Type="String">CONSOLE NO</Data>
							</Cell>
							<Cell ss:StyleID="s63">
								<Data ss:Type="String">JOBNO</Data>
							</Cell>
							<Cell ss:StyleID="s63">
								<Data ss:Type="String">ETA</Data>
							</Cell>
							<Cell ss:StyleID="s63">
								<Data ss:Type="String">MODE</Data>
							</Cell>

							<Cell ss:StyleID="s63">
								<Data ss:Type="String">IMPORTER</Data>
							</Cell>

						</Row>
						<xsl:for-each select="//NewDataSet/Table1">
							<xsl:variable name="ID" select="CONSOLENO"></xsl:variable>
							<Row>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="CONSOLENO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="JOBNO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="ETA"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="MODE"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="IMPORTER_NAME"/>
									</Data>
								</Cell>
							</Row>
						</xsl:for-each>
					</Table>
				</xsl:for-each>
				<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
					<Selected/>
					<FreezePanes/>
					<FrozenNoSplit/>
					<SplitHorizontal>1</SplitHorizontal>
					<TopRowBottomPane>1</TopRowBottomPane>
					<ActivePane>2</ActivePane>
					<Panes>
						<Pane>
							<Number>3</Number>
						</Pane>
						<Pane>
							<Number>2</Number>
							<ActiveRow>2</ActiveRow>
							<ActiveCol>1</ActiveCol>
						</Pane>
					</Panes>
					<ProtectObjects>False</ProtectObjects>
					<ProtectScenarios>False</ProtectScenarios>
				</WorksheetOptions>
			</Worksheet>
			<Worksheet>
				<xsl:attribute name="ss:Name">DELIVERY WISE</xsl:attribute>
				<xsl:for-each select="//NewDataSet/Table1">

					<Table>
						<Column ss:AutoFitWidth="0" ss:Width="63"/>
						<Column ss:AutoFitWidth="0" ss:Width="60"/>
						<Column  ss:AutoFitWidth="0" ss:Width="60"/>
						<Column  ss:Width="35"/>
						<Column ss:Width="144"/>
						<Column ss:Width="68"/>
						<Column ss:Width="129"/>

						<xsl:apply-templates select="NewDataSet"/>
						<Row ss:Height="18.75">
							<Cell ss:MergeAcross="11" ss:StyleID="m47186592">
								<Data ss:Type="String">DELIVERY WISE JOB PENDING FOR INVOICING</Data>
							</Cell>
						</Row>
						<Row ss:AutoFitHeight="0">
							<Cell ss:StyleID="s63">
								<Data ss:Type="String">DELVERY NO</Data>
							</Cell>
							<Cell ss:StyleID="s63">
								<Data ss:Type="String">JOBNO</Data>
							</Cell>

							<Cell ss:StyleID="s63">
								<Data ss:Type="String">IMPORTER </Data>
							</Cell>
							<Cell ss:StyleID="s63">
								<Data ss:Type="String">MODE</Data>
							</Cell>
							<Cell ss:StyleID="s63">
								<Data ss:Type="String">ACTUAL ARRIVAL </Data>
							</Cell>
							<Cell ss:StyleID="s63">
								<Data ss:Type="String">DESTINATION </Data>
							</Cell>

							<Cell ss:StyleID="s63">
								<Data ss:Type="String"> ACTUAL DELIVERY </Data>
							</Cell>

							<Cell ss:StyleID="s63">
								<Data ss:Type="String"> DESTINATAIRE </Data>
							</Cell>

							<Cell ss:StyleID="s63">
								<Data ss:Type="String"> STATUT_DUANE </Data>
							</Cell>
							<Cell ss:StyleID="s63">
								<Data ss:Type="String"> TARIF </Data>
							</Cell>
							<Cell ss:StyleID="s63">
								<Data ss:Type="String">DELIVERY BY</Data>
							</Cell>

						</Row>
						<xsl:for-each select="//NewDataSet/Table2">
							<Row >
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="DELIVERYNO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="JOBNO"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="IMPORTER_NAME"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="MODE"/>
									</Data>
								</Cell>


								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="ACTUAL_ARRIVAL"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="DESTINATION"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="RDV_ACTUAL"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="DESTINATAIRE"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="STATUT_DUANE"/>
									</Data>
								</Cell>

								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="TARIF"/>
									</Data>
								</Cell>
								<Cell ss:StyleID="s66">
									<Data ss:Type="String">
										<xsl:value-of select="DELIVERY_By"/>
									</Data>
								</Cell>
							</Row>
						</xsl:for-each>
					</Table>
				</xsl:for-each>
				<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
					<Selected/>
					<FreezePanes/>
					<FrozenNoSplit/>
					<SplitHorizontal>1</SplitHorizontal>
					<TopRowBottomPane>1</TopRowBottomPane>
					<ActivePane>2</ActivePane>
					<Panes>
						<Pane>
							<Number>3</Number>
						</Pane>
						<Pane>
							<Number>2</Number>
							<ActiveRow>2</ActiveRow>
							<ActiveCol>1</ActiveCol>
						</Pane>
					</Panes>
					<ProtectObjects>False</ProtectObjects>
					<ProtectScenarios>False</ProtectScenarios>
				</WorksheetOptions>
			</Worksheet>

		</Workbook>
	</xsl:template>
</xsl:stylesheet>

