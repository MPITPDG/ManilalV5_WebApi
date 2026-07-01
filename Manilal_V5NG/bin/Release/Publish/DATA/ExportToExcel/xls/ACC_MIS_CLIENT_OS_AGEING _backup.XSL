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
					<Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="12" ss:Bold="1"/>
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
					<Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<NumberFormat ss:Format="Standard"/>
				</Style>
				<Style ss:ID="s25">
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
			</Styles>


			<Worksheet>
				<xsl:attribute name="ss:Name">Client_Ageing</xsl:attribute>
				<Table>
					<Column ss:Width="98.25"/>
					<Column ss:Width="294.75"/>
					<!--<Column ss:Width="98.25"/>
					<Column ss:Width="98.25"/>
					<Column ss:Width="98.25"/>-->
					<Column ss:Width="98.25"/>
					<Column ss:Width="103.5"/>
					<Column ss:Width="77.25" ss:Span="1"/>
					<Column ss:Index="7" ss:Width="84"/>
					<Column ss:Width="90"/>
					<Column ss:Width="112.5"/>
					<Column ss:AutoFitWidth="0" ss:Width="124.5"/>
					<Column ss:AutoFitWidth="0" ss:Width="114"/>
					<Column ss:AutoFitWidth="0" ss:Width="101.25"/>
					<Column ss:AutoFitWidth="0" ss:Width="96.75"/>
					<Column ss:AutoFitWidth="0" ss:Width="75"/>
					<Column ss:AutoFitWidth="0" ss:Width="67.5"/>
					<Column ss:Width="48.75"/>
					<Column ss:AutoFitWidth="0" ss:Width="66.75"/>
					<xsl:apply-templates select="NewDataSet"/>
					<xsl:for-each select="Table">
						<Row >
							<Cell ss:MergeAcross="16" ss:StyleID="s01">
								<Data ss:Type="String">
									<xsl:value-of select="HEADER"/>
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
					<Row  ss:AutoFitHeight="0" ss:Height="22.5">
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">CODE</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">CLIENT NAME</Data>
						</Cell>
						<!--<Cell ss:StyleID="s21">
							<Data ss:Type="String">CLIENT STATUS</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">FOLLOW UP ASSIGNED TO</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">ASSIGNED ON</Data>
						</Cell>-->
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">RECEIVABLE AS ON</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">LESS THAN 30 DAYS</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">31 TO 60 DAYS</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">61 TO 90 DAYS</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">91 TO 120 DAYS</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">120 TO 180 DAYS</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">181 to 365 Days</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">1 TO 2 Years</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">2 TO 3 Years</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">MORE THAN 3 Year</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">TOTAL OF ALL INVOICES OUTSTANDING</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">LESS : UNADJUSTED RECEIPTS</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">ADVANCE</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">ADVANCE PAID ON BEHALF</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">INVOICE CITY</Data>
						</Cell>
					</Row>
					<xsl:for-each select="Table1">
						<Row ss:AutoFitHeight="1">
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="ACCTCODE"/>
								</Data>
							</Cell>
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="ACCTNAME"/>
								</Data>
							</Cell>
							<!--<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="CLIENT_STATUS"/>
								</Data>
							</Cell>
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="FOLLOW_ASSIGNED_TO"/>
								</Data>
							</Cell>
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="ASSIGNED_ON"/>
								</Data>
							</Cell>-->
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="RECEIVABLE_AS_ON"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="DAYS_000_030"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="DAYS_031_060"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="DAYS_061_090"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="DAYS_091_120"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="DAYS_121_180"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="DAYS_181_365"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="DAYS_366_730"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="DAYS_731_1095"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="DAYS_1096_9999"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="INVOICES_OUTSTANDING"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="UNADJUSTED_RECEIPTS"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="ADVANCE"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="ADVANCE_PAIDBYUS"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="CITYNAME"/>
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
				</Table>
			</Worksheet>
		</Workbook>
	</xsl:template>
</xsl:stylesheet>
