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
					<Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="9" ss:Bold="1"/>
					<Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
					<Interior/>
				</Style>
				<Style ss:ID="s21">
					<Font ss:FontName="Verdana" ss:Color="White" x:Family="Swiss" ss:Size="8" ss:Bold="1"/>
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Interior  ss:Color="#000066" ss:Pattern="Solid"/>
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
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
				</Style>
				<Style ss:ID="s29">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
					<Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
					<Interior ss:Color="#000080" ss:Pattern="Solid"/>
				</Style>
			</Styles>
			<Worksheet>
				<xsl:attribute name="ss:Name">Client</xsl:attribute>
				<Table>
					<Column ss:Width="16.5"/>
					<Column ss:Width="84.75"/>
					<Column ss:Width="60.75"/>
					<Column ss:AutoFitWidth="0" ss:Width="76.5"/>
					<Column ss:AutoFitWidth="0" ss:Width="78"/>
					<Column ss:AutoFitWidth="0" ss:Width="83.25"/>
					<Column ss:AutoFitWidth="0" ss:Width="68.25"/>
					<Column ss:AutoFitWidth="0" ss:Width="57.75"/>
					<Column ss:AutoFitWidth="0" ss:Width="68.25"/>
					<Column ss:AutoFitWidth="0" ss:Width="57.75"/>
					<Column ss:Width="63"/>
					<Column ss:AutoFitWidth="0" ss:Width="68.25"/>

					<xsl:variable name="CLIENT" select="//NewDataSet/Table/CLIENTCODE"></xsl:variable>
					<xsl:apply-templates select="NewDataSet"/>
					<xsl:for-each select="Table">
						<!--<xsl:variable name="CLIENT" select="CLIENTCODE"></xsl:variable>-->
						<Row >
							<Cell ss:MergeAcross="5" ss:StyleID="s01">
								<Data ss:Type="String">
									<xsl:value-of select="SUBHEADER"/>
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
					<Row >
						<Cell ss:MergeAcross="5" ss:StyleID="s01">
							<Data ss:Type="String">PENDING INVOICES</Data>
						</Cell>
					</Row>

					<xsl:choose>
						<xsl:when test="$CLIENT=''">
							<Row  ss:AutoFitHeight="0" ss:Height="34.5">
								<Cell ss:StyleID="s21">
									<Data ss:Type="String"></Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Bill No</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Date</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">InvoiceAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">ReceivedAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">PendingAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Narration</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Currency</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Exchange Rate</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Amount</Data>
								</Cell>
								<!--<Cell ss:StyleID="s21">
                  <Data ss:Type="String">MP-Cargo Purchase</Data>
                </Cell>
                <Cell ss:StyleID="s21">
                  <Data ss:Type="String">MP-Cargo Purchase EURO</Data>
                </Cell>
                <Cell ss:StyleID="s21">
                  <Data ss:Type="String">Console No</Data>
                </Cell>-->
							</Row>
							<xsl:for-each select="Table1">
								<Row ss:AutoFitHeight="1">
									<Cell ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="BILLTYPE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="TRANSCODE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="BILLDATE"/>
										</Data>
									</Cell>

									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="INVOICEAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="RECEIVEDAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="PENDINGAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="NARRATION"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="CURRENCY"/>
										</Data>
									</Cell>
									<xsl:choose>
										<xsl:when test="CURRENCY_RATE=0.00">
											<Cell  ss:StyleID="s24">
												<Data ss:Type="String">
												</Data>
											</Cell>
										</xsl:when>
										<xsl:otherwise>
											<Cell  ss:StyleID="s24">
												<Data ss:Type="Number">
													<xsl:value-of select="CURRENCY_RATE"/>
												</Data>
											</Cell>
										</xsl:otherwise>
									</xsl:choose>
									<xsl:choose>
										<xsl:when test="CURRENCY_AMOUNT=0.00">
											<Cell  ss:StyleID="s24">
												<Data ss:Type="String">
												</Data>
											</Cell>
										</xsl:when>
										<xsl:otherwise>
											<Cell  ss:StyleID="s24">
												<Data ss:Type="Number">
													<xsl:value-of select="CURRENCY_AMOUNT"/>
												</Data>
											</Cell>
										</xsl:otherwise>
									</xsl:choose>
									<!--<Cell  ss:StyleID="s24">
                    <Data ss:Type="String">
                      <xsl:value-of select="MP_CONSOLE_PURCHASE"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s24">
                    <Data ss:Type="Number">
                      <xsl:value-of select="MP_CONSOLE_PURCHASE_EURO"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s24">
                    <Data ss:Type="String">
                      <xsl:value-of select="MP_CONSOLENO"/>
                    </Data>
                  </Cell>-->
								</Row>
							</xsl:for-each>
						</xsl:when>
						<xsl:otherwise>
							<Row  ss:AutoFitHeight="0" ss:Height="34.5">
								<Cell ss:StyleID="s21">
									<Data ss:Type="String"></Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Bill No</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Date</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">InvoiceAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">ReceivedAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">PendingAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Narration</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Currency</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Exchange Rate</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Amount</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">MP-Cargo Purchase</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">MP-Cargo Purchase EURO</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Console No</Data>
								</Cell>
							</Row>
							<xsl:for-each select="Table1">
								<Row ss:AutoFitHeight="1">
									<Cell ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="BILLTYPE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="TRANSCODE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="BILLDATE"/>
										</Data>
									</Cell>

									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="INVOICEAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="RECEIVEDAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="PENDINGAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="NARRATION"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="CURRENCY"/>
										</Data>
									</Cell>
									<xsl:choose>
										<xsl:when test="CURRENCY_RATE=0.00">
											<Cell  ss:StyleID="s24">
												<Data ss:Type="String">
												</Data>
											</Cell>
										</xsl:when>
										<xsl:otherwise>
											<Cell  ss:StyleID="s24">
												<Data ss:Type="Number">
													<xsl:value-of select="CURRENCY_RATE"/>
												</Data>
											</Cell>
										</xsl:otherwise>
									</xsl:choose>
									<xsl:choose>
										<xsl:when test="CURRENCY_AMOUNT=0.00">
											<Cell  ss:StyleID="s24">
												<Data ss:Type="String">
												</Data>
											</Cell>
										</xsl:when>
										<xsl:otherwise>
											<Cell  ss:StyleID="s24">
												<Data ss:Type="Number">
													<xsl:value-of select="CURRENCY_AMOUNT"/>
												</Data>
											</Cell>
										</xsl:otherwise>
									</xsl:choose>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="MP_CONSOLE_PURCHASE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="MP_CONSOLE_PURCHASE_EURO"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="MP_CONSOLENO"/>
										</Data>
									</Cell>
								</Row>
							</xsl:for-each>
						</xsl:otherwise>
					</xsl:choose>


					<xsl:for-each select="Table2">
						<Row ss:AutoFitHeight="1">
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="BILLTYPE"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="TRANSCODE"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="BILLDATE"/>
								</Data>
							</Cell>

							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="INVOICEAMT"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="ADJUSTEDAMT"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="TOTALPENDINGAMT"/>
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
					<Row >
						<Cell ss:MergeAcross="5" ss:StyleID="s01">
							<Data ss:Type="String">

							</Data>
						</Cell>
					</Row>
					<Row >
						<Cell ss:MergeAcross="5" ss:StyleID="s01">
							<Data ss:Type="String"></Data>
						</Cell>
					</Row>
					<Row >
						<Cell ss:MergeAcross="5" ss:StyleID="s01">
							<Data ss:Type="String">LESS : UN ADJUSTED RECEIPTS</Data>
						</Cell>
					</Row>
					<xsl:choose>
						<xsl:when test="$CLIENT=''">
							<Row  ss:AutoFitHeight="0" ss:Height="34.5">
								<Cell ss:StyleID="s21">
									<Data ss:Type="String"></Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Bill No</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Date</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">ReceiptAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">AdjustedAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">UnAdjustedAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Narration</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Currency</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Exchange Rate</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Amount</Data>
								</Cell>
								<!--<Cell ss:StyleID="s21">
                  <Data ss:Type="String">MP-Cargo Purchase</Data>
                </Cell>
                <Cell ss:StyleID="s21">
                  <Data ss:Type="String">MP-Cargo Purchase EURO</Data>
                </Cell>
                <Cell ss:StyleID="s21">
                  <Data ss:Type="String">Console No</Data>
                </Cell>-->
							</Row>

							<xsl:for-each select="Table3">
								<Row ss:AutoFitHeight="1">
									<Cell ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="BILLTYPE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="TRANSCODE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="BILLDATE"/>
										</Data>
									</Cell>

									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="RECEIPTAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="ADJUSTEDAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="UNADJUSTEDAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="NARRATION"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="CURRENCY"/>
										</Data>
									</Cell>
									<xsl:choose>
										<xsl:when test="CURRENCY_RATE=0.00">
											<Cell  ss:StyleID="s24">
												<Data ss:Type="String">
												</Data>
											</Cell>
										</xsl:when>
										<xsl:otherwise>
											<Cell  ss:StyleID="s24">
												<Data ss:Type="Number">
													<xsl:value-of select="CURRENCY_RATE"/>
												</Data>
											</Cell>
										</xsl:otherwise>
									</xsl:choose>
									<xsl:choose>
										<xsl:when test="CURRENCY_AMOUNT=0.00">
											<Cell  ss:StyleID="s24">
												<Data ss:Type="String">
												</Data>
											</Cell>
										</xsl:when>
										<xsl:otherwise>
											<Cell  ss:StyleID="s24">
												<Data ss:Type="Number">
													<xsl:value-of select="CURRENCY_AMOUNT"/>
												</Data>
											</Cell>
										</xsl:otherwise>
									</xsl:choose>

									<!--<Cell  ss:StyleID="s24">
                    <Data ss:Type="String">
                      <xsl:value-of select="MP_CONSOLE_PURCHASE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s24">
                    <Data ss:Type="Number">
                      <xsl:value-of select="MP_CONSOLE_PURCHASE_EURO"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s24">
                    <Data ss:Type="String">
                      <xsl:value-of select="MP_CONSOLENO"/>
                    </Data>
                  </Cell>-->
								</Row>
							</xsl:for-each>
						</xsl:when>
						<xsl:otherwise>
							<Row  ss:AutoFitHeight="0" ss:Height="34.5">
								<Cell ss:StyleID="s21">
									<Data ss:Type="String"></Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Bill No</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Date</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">ReceiptAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">AdjustedAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">UnAdjustedAmt</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Narration</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Currency</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Exchange Rate</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Amount</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">MP-Cargo Purchase</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">MP-Cargo Purchase EURO</Data>
								</Cell>
								<Cell ss:StyleID="s21">
									<Data ss:Type="String">Console No</Data>
								</Cell>
							</Row>

							<xsl:for-each select="Table3">
								<Row ss:AutoFitHeight="1">
									<Cell ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="BILLTYPE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="TRANSCODE"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="BILLDATE"/>
										</Data>
									</Cell>

									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="RECEIPTAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="ADJUSTEDAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="UNADJUSTEDAMT"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="NARRATION"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s25">
										<Data ss:Type="String">
											<xsl:value-of select="CURRENCY"/>
										</Data>
									</Cell>
									<xsl:choose>
										<xsl:when test="CURRENCY_RATE=0.00">
											<Cell  ss:StyleID="s24">
												<Data ss:Type="String">
												</Data>
											</Cell>
										</xsl:when>
										<xsl:otherwise>
											<Cell  ss:StyleID="s24">
												<Data ss:Type="Number">
													<xsl:value-of select="CURRENCY_RATE"/>
												</Data>
											</Cell>
										</xsl:otherwise>
									</xsl:choose>
									<xsl:choose>
										<xsl:when test="CURRENCY_AMOUNT=0.00">
											<Cell  ss:StyleID="s24">
												<Data ss:Type="String">
												</Data>
											</Cell>
										</xsl:when>
										<xsl:otherwise>
											<Cell  ss:StyleID="s24">
												<Data ss:Type="Number">
													<xsl:value-of select="CURRENCY_AMOUNT"/>
												</Data>
											</Cell>
										</xsl:otherwise>
									</xsl:choose>

									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="MP_CONSOLE_PURCHASE"/>
										</Data>
									</Cell>
									<Cell ss:StyleID="s24">
										<Data ss:Type="Number">
											<xsl:value-of select="MP_CONSOLE_PURCHASE_EURO"/>
										</Data>
									</Cell>
									<Cell  ss:StyleID="s24">
										<Data ss:Type="String">
											<xsl:value-of select="MP_CONSOLENO"/>
										</Data>
									</Cell>
								</Row>
							</xsl:for-each>
						</xsl:otherwise>
					</xsl:choose>

					<xsl:for-each select="Table4">
						<Row ss:AutoFitHeight="1">
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="BILLTYPE"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="TRANSCODE"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="BILLDATE"/>
								</Data>
							</Cell>

							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="RECEIPTAMT"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="ADJUSTEDAMT"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="TOTALUNADJUSTEDAMT"/>
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
					<Row >
						<Cell ss:MergeAcross="5" ss:StyleID="s01">
							<Data ss:Type="String">

							</Data>
						</Cell>
					</Row>
					<Row >
						<Cell ss:MergeAcross="5" ss:StyleID="s01">
							<Data ss:Type="String"></Data>
						</Cell>
					</Row>
					<xsl:for-each select="Table5">
						<Row ss:AutoFitHeight="1">
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="BILLTYPE"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">

								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">

								</Data>
							</Cell>

							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">

								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="ADJUSTEDAMT"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="TOTALNetOutAMT"/>
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
					<Row >
						<Cell ss:MergeAcross="5" ss:StyleID="s01">
							<Data ss:Type="String">

							</Data>
						</Cell>
					</Row>
					<Row >
						<Cell ss:MergeAcross="3" ss:StyleID="s01">
							<Data ss:Type="String">Advances</Data>
						</Cell>
					</Row>
					<Row  ss:AutoFitHeight="1">
						<Cell ss:StyleID="s21">
							<Data ss:Type="String"></Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">Bill No</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">Date</Data>
						</Cell>
						<Cell ss:StyleID="s21">
							<Data ss:Type="String">AdvanceAmt</Data>
						</Cell>
					</Row>
					<xsl:for-each select="Table6">
						<Row ss:AutoFitHeight="1">
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="BILLTYPE"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="BILLNO"/>
								</Data>
							</Cell>
							<Cell  ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="BILLDATE"/>
								</Data>
							</Cell>

							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="ADCRAMT"/>
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>
					<xsl:for-each select="Table7">
						<Row ss:AutoFitHeight="1">
							<Cell ss:StyleID="s25">
								<Data ss:Type="String">
									<xsl:value-of select="BILLTYPE"/>
								</Data>
							</Cell>
							<Cell ss:MergeAcross="1" ss:StyleID="s24">
								<Data ss:Type="String">
									<xsl:value-of select="ADDRAMT"/>
								</Data>
							</Cell>

							<Cell  ss:StyleID="s24">
								<Data ss:Type="Number">
									<xsl:value-of select="TOTALADVAMT"/>
								</Data>
							</Cell>
						</Row>
					</xsl:for-each>

				</Table>
			</Worksheet>
		</Workbook>
	</xsl:template>
</xsl:stylesheet>
