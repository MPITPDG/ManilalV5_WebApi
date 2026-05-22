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

				<Style ss:ID="Default" ss:Name="Normal">
					<Alignment ss:Vertical="Bottom"/>
					<Borders/>
					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
					<Interior/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="s62">
					<Alignment ss:Vertical="Bottom"/>
				</Style>
				<Style ss:ID="s63">
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
				<Style ss:ID="s64">
					<Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
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
				<Style ss:ID="s65">
					<Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
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
				<Style ss:ID="s66">
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
					<Interior/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="s67">
					<Alignment ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
					<Interior/>
					<NumberFormat/>
					<Protection/>
				</Style>
				<Style ss:ID="s68">
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
					<Interior/>
					<NumberFormat ss:Format="Standard"/>
					<Protection/>
				</Style>
				<Style ss:ID="s69">
					<Alignment ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
					<Interior/>
					<NumberFormat ss:Format="Standard"/>
					<Protection/>
				</Style>
				<Style ss:ID="s70">
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FF0000"/>
					<Interior/>
					<NumberFormat ss:Format="Standard"/>
					<Protection/>
				</Style>
				<Style ss:ID="s71">
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
					<Interior/>
					<NumberFormat ss:Format="Standard"/>
					<Protection/>
				</Style>
				<Style ss:ID="s73">
					<Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
					<Borders>
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
				<Style ss:ID="s75">
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FF0000"/>
					<Interior/>
					<NumberFormat ss:Format="Standard"/>
					<Protection/>
				</Style>
			</Styles>

			<xsl:apply-templates select="NewDataSet"/>
			<!--<xsl:for-each select="Table">
				<xsl:variable name="CONNAME" select="CONNAME"></xsl:variable>
			</xsl:for-each>-->

			<xsl:for-each select="//NewDataSet/Table">
				<xsl:variable name="ORIGIN_ID" select="ORIGIN"></xsl:variable>
				<Worksheet>
					<xsl:attribute name="ss:Name">
						<xsl:value-of select="$ORIGIN_ID" />
					</xsl:attribute>

					<Table ss:DefaultColumnWidth="82.5" ss:DefaultRowHeight="15">
						<Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="108.75"/>
						<Column ss:StyleID="s62" ss:Width="42.75"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="71.25"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="70.5"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="102.75"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="110.25"/>
						<Column ss:StyleID="s62" ss:Width="135.75"/>
						<Column ss:StyleID="s62" ss:Width="124.5"/>
						<Column ss:StyleID="s62" ss:Width="117.75"/>
						<Column ss:StyleID="s62" ss:Width="105.75"/>
						<Column ss:StyleID="s62" ss:Width="93"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="70.5"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="63.75"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="99"/>
						<Column ss:StyleID="s62" ss:Width="30"/>
						<Column ss:StyleID="s62" ss:Width="60"/>
						<Column ss:StyleID="s62" ss:Width="91.5"/>
						<Column ss:StyleID="s62" ss:Width="60"/>
						<Column ss:StyleID="s62" ss:Width="101.25"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="59.25"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="75.75"/>
						<Column ss:StyleID="s62" ss:Width="54.75"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="142.5"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="121.5"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="156.75"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="99.75"/>
						<Column ss:StyleID="s62" ss:AutoFitWidth="0" ss:Width="186"/>

						<!--<xsl:for-each select="//NewDataSet/Table1">
							<Row >
								<Cell ss:MergeAcross="25" ss:StyleID="s01">
									<Data ss:Type="String">
										<xsl:value-of select="HEADER" disable-output-escaping="yes"/>
									</Data>
								</Cell>
							</Row>
							</xsl:for-each>-->

						<!--<xsl:when test="$CONNAME='KIABI'">-->
							<Row ss:AutoFitHeight="0" ss:Height="25.5">
								<Cell ss:StyleID="s63">
									<Data ss:Type="String">origin</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">SHIPPER</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">PO NR</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">QUANTITY</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">PARCELS</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">GR WEIGHT</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">CBM</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">PMA</Data>
								</Cell>
								<Cell ss:StyleID="s63">
									<Data ss:Type="String">EPCD</Data>
								</Cell>
								<Cell ss:StyleID="s63">
									<Data ss:Type="String">MDD</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">STATUS</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">AWB</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">ETD</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">ETA</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">DELAY ETA /MDD</Data>
								</Cell>
								<Cell ss:StyleID="s64">
									<Data ss:Type="String">RATEAS</Data>
								</Cell>
								<!--<Cell ss:StyleID="s64">
									<Data ss:Type="String">Remarks</Data>
								</Cell>-->
							</Row>
							<xsl:for-each select="//NewDataSet/Table1">
								<xsl:variable name="ORIGIN_F" select="ORIGIN"></xsl:variable>
								<xsl:variable name="BKNGECVDON" select="BOOKINGRECEIVEDON"></xsl:variable>
								<xsl:if test="$ORIGIN_ID = $ORIGIN_F">
									<Row ss:AutoFitHeight="1">
										<Cell ss:StyleID="s66">
											<Data ss:Type="String">
												<xsl:value-of select="ORIGIN"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s69">
											<Data ss:Type="String">
												<xsl:value-of select="SHIPPER"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s67">
											<Data ss:Type="String">
												<xsl:value-of select="PONR"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s67">
											<Data ss:Type="String">
												<xsl:value-of select="QUANTITY"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s67">
											<Data ss:Type="String">
												<xsl:value-of select="PARCELS"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s68">
											<Data ss:Type="String">
												<xsl:value-of select="GRWEIGHT"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s71">
											<Data ss:Type="String">
												<xsl:value-of select="CBM"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s68">
											<Data ss:Type="String">
												<xsl:value-of select="PMA"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s68">
											<Data ss:Type="String">
												<xsl:value-of select="EPCD"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s67">
											<Data ss:Type="String">
												<xsl:value-of select="MDD"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s71">
											<Data ss:Type="String">
												<xsl:value-of select="STATUS"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s69">
											<Data ss:Type="String">
												<xsl:value-of select="AWB"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s69">
											<Data ss:Type="String">
												<xsl:value-of select="ETD"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s71">
											<Data ss:Type="String">
												<xsl:value-of select="ETA"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s69">
											<Data ss:Type="String">
												<xsl:value-of select="Delay_ETA_MDD"/>
											</Data>
										</Cell>
										<Cell ss:StyleID="s69">
											<Data ss:Type="String">
												<xsl:value-of select="RATEAS"/>
											</Data>
										</Cell>

										<!--<Cell ss:StyleID="s69">
											<Data ss:Type="String">
												<xsl:value-of select="Remarks"/>
											</Data>
										</Cell>-->
									</Row>
								</xsl:if>
							</xsl:for-each>
						<!--</xsl:when>-->
					</Table>
					<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
						<Selected/>
						<FreezePanes/>
						<FrozenNoSplit/>
						<SplitHorizontal>0</SplitHorizontal>
						<TopRowBottomPane>0</TopRowBottomPane>
						<ActivePane>3</ActivePane>
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

			</xsl:for-each>
			<!--</xsl:for-each>-->

		</Workbook>
	</xsl:template>
</xsl:stylesheet>
