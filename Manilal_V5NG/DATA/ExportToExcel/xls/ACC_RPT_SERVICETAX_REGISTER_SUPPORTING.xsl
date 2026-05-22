<xsl:stylesheet version="1.0"
    xmlns="urn:schemas-microsoft-com:office:spreadsheet"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	xmlns:user="urn:my-scripts"
	xmlns:o="urn:schemas-microsoft-com:office:office"
	xmlns:x="urn:schemas-microsoft-com:office:excel"
	xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet" >
    <ExcelWorkbook xmlns="urn:schemas-microsoft-com:office:excel">
        <WindowHeight>9630</WindowHeight>
        <WindowWidth>21600</WindowWidth>
        <WindowTopX>0</WindowTopX>
        <WindowTopY>0</WindowTopY>
        <ActiveSheet>2</ActiveSheet>
        <ProtectStructure>False</ProtectStructure>
        <ProtectWindows>False</ProtectWindows>
    </ExcelWorkbook>

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
                <Style ss:ID="m226816136">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226816156">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226816176">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226815720">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226815740">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226815760">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226810104">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226816760">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226816780">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226816800">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226817176">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226817196">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m226817216">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s67">
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
                     ss:Bold="1"/>
                </Style>
                <Style ss:ID="s68">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s69">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                </Style>
                <Style ss:ID="s70">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <NumberFormat ss:Format="Short Date"/>
                </Style>
                <Style ss:ID="s71">
                    <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s72">
                    <Borders/>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
                     ss:Bold="1"/>
                </Style>
                <Style ss:ID="s73">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                </Style>
                <Style ss:ID="s74">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <NumberFormat ss:Format="Short Date"/>
                </Style>
                <Style ss:ID="s80">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s82">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s84">
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Bold="1"/>
                    <Interior/>
                </Style>
				<Style ss:ID="s86">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
					<Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
				</Style>
            </Styles>
            <Worksheet ss:Name="INVOICE">
                <xsl:for-each select="//NewDataSet/Table">
                    <Table>
                        <Column ss:Width="87"/>
                        <Column ss:Width="56.25"/>
                        <Column ss:Width="87"/>
                        <Column ss:Width="79.5"/>
                        <Column ss:Width="74.25"/>
                        <Column ss:Width="196.5"/>
                        <Column ss:Width="69"/>
                        <Column ss:Width="52.5"/>
                        <Column ss:Width="276"/>
                        <Column ss:Width="69.75"/>
                        <Column ss:Width="87.75"/>

                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="11" ss:StyleID="m226816136">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER1" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="11" ss:StyleID="m226816136">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER2" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="11" ss:StyleID="m226816136">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER3" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">INV_NO</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">INV_DATE</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">INV_JOBNO</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">INV_CHRGCODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">INV_ACCOUNT</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">INV_ACCOUNTNAME</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">INV_TAXABLE</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">INV_AMT</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">INV_CLIENTNAME</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">GROUP_CODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">GROUP_NAME</Data>
                            </Cell>
							<Cell ss:StyleID="s68">
								<Data ss:Type="String">GST NO</Data>
							</Cell>
                        </Row>
                        <xsl:for-each select="//NewDataSet/Table1">
                            <Row>

                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="INV_NO"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="INV_DATE"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="INV_JOBNO"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="INV_CHRGCODE"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="INV_ACCOUNT"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="INV_ACCOUNTNAME"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="INV_TAXABLE"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="INV_AMT"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="INV_CLIENTNAME"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GROUP_CODE"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GROUP_NAME"/>
                                    </Data>
                                </Cell>
								<Cell ss:StyleID="s69">
									<Data ss:Type="String">
										<xsl:value-of select="CLIENT_GSTNO"/>
									</Data>
								</Cell>
                            </Row>
                        </xsl:for-each>
                    </Table>
                </xsl:for-each>
                <!--<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
                    <PageSetup>
                        <Header x:Margin="0.3"/>
                        <Footer x:Margin="0.3"/>
                        <PageMargins x:Bottom="0.75" x:Left="0.7" x:Right="0.7" x:Top="0.75"/>
                    </PageSetup>
                    <Unsynced/>
                    <Print>
                        <ValidPrinterInfo/>
                        <HorizontalResolution>600</HorizontalResolution>
                        <VerticalResolution>600</VerticalResolution>
                    </Print>
                    <Panes>
                        <Pane>
                            <Number>3</Number>
                            <ActiveRow>17</ActiveRow>
                            <ActiveCol>8</ActiveCol>
                        </Pane>
                    </Panes>
                    <ProtectObjects>False</ProtectObjects>
                    <ProtectScenarios>False</ProtectScenarios>
                </WorksheetOptions>-->
            </Worksheet>
            <Worksheet ss:Name="CREDIT NOTE">
                <xsl:for-each select="//NewDataSet/Table2">
                    <Table>
                        <Column ss:Width="87"/>
                        <Column ss:Width="56.25"/>
                        <Column ss:Width="87"/>
                        <Column ss:Width="80.25"/>
                        <Column ss:Width="75"/>
                        <Column ss:Width="188.25"/>
                        <Column ss:AutoFitWidth="0" ss:Width="51"/>
                        <Column ss:Width="49.5"/>
                        <Column ss:Width="213"/>
                        <Column ss:Width="71.25"/>
                        <Column ss:Width="87.75"/>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="11" ss:StyleID="m226815720">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER1" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="11" ss:StyleID="m226815740">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER2" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="11" ss:StyleID="m226815760">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER3" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0" ss:Height="30">
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CRT_NO</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CRT_DATE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CRT_JOBNO</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CRT_CHRGCODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CRT_ACCOUNT</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CRT_ACCOUNTNAME</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CRT_TAXABLE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CRT_AMT</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CRT_CLIENTNAME</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">GROUP_CODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">GROUP_NAME</Data>
                            </Cell>
							<Cell ss:StyleID="s68">
								<Data ss:Type="String">GST NO</Data>
							</Cell>
                        </Row>
                        <xsl:for-each select="//NewDataSet/Table3">
                            <Row ss:AutoFitHeight="0">
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CRT_NO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CRT_DATE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CRT_JOBNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="CRT_CHRGCODE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CRT_ACCOUNT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CRT_ACCOUNTNAME" />
                                    </Data>
                                </Cell>

                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="CRT_TAXABLE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CRT_AMT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CRT_CLIENTNAME" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GROUP_CODE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GROUP_NAME" />
                                    </Data>
                                </Cell>
								<Cell ss:StyleID="s73">
									<Data ss:Type="String">
										<xsl:value-of select="CLIENT_GSTNO" />
									</Data>
								</Cell>
                            </Row>
                        </xsl:for-each>
                    </Table>
                </xsl:for-each>

            </Worksheet>
            <Worksheet ss:Name="PURCHASE">
                <xsl:for-each select="//NewDataSet/Table4">
                    <Table >
                        <Column ss:Width="87"/>
                        <Column ss:Width="56.25"/>
                        <Column ss:AutoFitWidth="0" ss:Width="147.75"/>
                        <Column ss:Width="77.25"/>
                        <Column ss:Width="218.25"/>
                        <Column ss:Width="61.5"/>
                        <Column ss:Width="137.25"/>
                        <Column ss:Width="65.25"/>
                        <Column ss:AutoFitWidth="0" ss:Width="72"/>
                        <Column ss:AutoFitWidth="0" ss:Width="69"/>
                        <Column ss:AutoFitWidth="0" ss:Width="77.25"/>
                        <Column ss:AutoFitWidth="0" ss:Width="63"/>
                        <Column ss:AutoFitWidth="0" ss:Width="60.75"/>
                        <Column ss:AutoFitWidth="0" ss:Width="66"/>
                        <Column ss:AutoFitWidth="0" ss:Width="84.75"/>
                        <Column ss:AutoFitWidth="0" ss:Width="57"/>
                        <Column ss:AutoFitWidth="0" ss:Width="63"/>
                        <Column ss:Width="55.5"/>
                        <Column ss:Width="51.75"/>
                        <Column ss:Width="71.25"/>
                        <Column ss:Width="87.75"/>
						<Column ss:Width="71.25"/>
						
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="21" ss:StyleID="m226810104">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER1" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="21" ss:StyleID="s86">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER2" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="21" ss:StyleID="s82">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER3" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0" ss:Height="30" >
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">PUR_CODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">PUR_DATE</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">SUP_NAME</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">PUR_ACCOUNT</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">ACCTNAME</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">PUR_DUEDT</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">PUR_INVNO</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">MAWBNO</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">FREIGHTG100235</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">SURCHARGEG101468</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">AIRFRTCOMMG100153</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">FRTREBATEG100186</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">PUR_SUPINVDATE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">PUR_SUPBILLDATE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">PUR_JOBNO</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">PUR_DEDUCTION</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">PUR_AMOUNT</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">ITEMCODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">ACCOUNT</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">GROUP_CODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">GROUP_NAME</Data>
                            </Cell>
							<Cell ss:StyleID="s71">
								<Data ss:Type="String">SUPPLIER GSTNO</Data>
							</Cell>
                        </Row>

                        <xsl:for-each select="//NewDataSet/Table5">
                            <Row ss:AutoFitHeight="0">
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="PUR_CODE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="PUR_DATE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="SUP_NAME" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="PUR_ACCOUNT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ACCTNAME" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="PUR_DUEDT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="PUR_INVNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="MAWBNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="FREIGHTG100235" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="SURCHARGEG101468" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="AIRFRTCOMMG100153" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="FRTREBATEG100186" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="PUR_SUPINVDATE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="PUR_SUPBILLDATE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="PUR_JOBNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="PUR_DEDUCTION" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="PUR_AMOUNT" />
                                    </Data>
                                </Cell>

                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ITEMCODE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ACCOUNT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GROUP_CODE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GROUP_NAME" />
                                    </Data>
                                </Cell>
								<Cell ss:StyleID="s69">
									<Data ss:Type="String">
										<xsl:value-of select="sup_GSTNO" />
									</Data>
								</Cell>
								
							</Row>
                        </xsl:for-each>
                    </Table>
                </xsl:for-each>

            </Worksheet>
            <Worksheet ss:Name="BRBPCRCP">
                <xsl:for-each select="//NewDataSet/Table6">
                    <Table>
                        <Column ss:Width="87"/>
                        <Column ss:Width="56.25"/>
                        <Column ss:Width="39.75"/>
                        <Column ss:AutoFitWidth="0" ss:Width="147"/>
                        <Column ss:Width="64.5"/>
                        <Column ss:Width="57.75"/>
                        <Column ss:Width="56.25"/>
                        <Column ss:Width="51.75"/>
                        <Column ss:Width="87.75"/>
                        <Column ss:Width="84.75"/>
                        <Column ss:AutoFitWidth="0" ss:Width="195.75"/>
                        <Column ss:AutoFitWidth="0" ss:Width="59.25"/>
                        <Column ss:AutoFitWidth="0" ss:Width="54"/>
                        <Column ss:AutoFitWidth="0" ss:Width="56.25"/>
                        <Column ss:AutoFitWidth="0" ss:Width="140.25"/>
                        <Column ss:Width="87" ss:Span="1"/>
                        <Column ss:Index="18" ss:Width="60"/>
                        <Column ss:Width="52.5"/>
                        <Column ss:Width="56.25"/>
                        <Column ss:AutoFitWidth="0" ss:Width="69.75"/>
                        <Column ss:Width="104.25"/>
                        <Column ss:Width="55.5"/>
                        <Column ss:AutoFitWidth="0" ss:Width="67.5"/>
                        <Column ss:Width="51"/>
                        <Column ss:Width="69.75"/>
                        <Column ss:AutoFitWidth="0" ss:Width="99.75"/>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="26" ss:StyleID="m226816760">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER1" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="26" ss:StyleID="m226816780">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER2" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="26" ss:StyleID="m226816800">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER3" />
                                </Data>
                            </Cell>
                        </Row>
                       <Row ss:AutoFitHeight="0" ss:Height="28.5"  ss:StyleID="s67">
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">ENTRYNO</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">ENTRYDT</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">STATUS</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">BANK</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">CHEQUETYPE</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">CHEQUENO</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CHEQUEDT</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">OURBANK</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">USERNAME</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">ACTUALAMOUNT</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">NARRATION</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">COMPUTERISEDCHEQUE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">PAYEENAME</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">NOTOVERFLAG</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">ACCOUNTNAME</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">JOBNO</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">BILLNO</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">DEDUCTION</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">AMOUNT</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">ENTRYTYPE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">CRPARENTENTRYNO</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">NARRATION</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">ITEMCODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">DEPTID</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">ACCOUNT</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">GROUP_CODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">GROUP_NAME</Data>
                            </Cell>
                        </Row>
                        <xsl:for-each select="//NewDataSet/Table7">
                            <Row ss:AutoFitHeight="0">
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENTRYNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENTRYDT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="STATUS" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="BANK" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CHEQUETYPE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CHEQUENO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CHEQUEDT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="OURBANK" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="USERNAME" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="ACTUALAMOUNT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="NARRATION" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="COMPUTERISEDCHEQUE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="PAYEENAME" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="NOTOVERFLAG" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ACCOUNTNAME" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="JOBNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="BILLNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="DEDUCTION" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="AMOUNT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENTRYTYPE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CRPARENTENTRYNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="NARRATION1" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ITEMCODE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="DEPTID" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ACCOUNT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GROUP_CODE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GROUP_NAME" />
                                    </Data>
                                </Cell>
                            </Row>
                        </xsl:for-each> 
                    </Table>
                </xsl:for-each>

            </Worksheet>

            <Worksheet ss:Name="JOURNEL">
                <xsl:for-each select="//NewDataSet/Table8">
                    <Table>
                        <Column ss:AutoFitWidth="0" ss:Width="90"/>
                        <Column ss:AutoFitWidth="0" ss:Width="65.25" ss:Span="11"/>
                        <Column ss:Index="14" ss:AutoFitWidth="0" ss:Width="108.75"/>
                        <Column ss:AutoFitWidth="0" ss:Width="65.25" ss:Span="241"/>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="12" ss:StyleID="m226817176">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER1" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="12" ss:StyleID="m226817196">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER2" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="12" ss:StyleID="m226817216">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER3" />
                                </Data>
                            </Cell>
                        </Row>
                        <Row ss:AutoFitHeight="0">
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">JVCODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">JV_DATE</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">JV_ACCOUNT</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">ACCTNAME</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">JV_JOBNO</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">JV_TRN</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">JV_DEBIT</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">JV_CREDIT</Data>
                            </Cell>
                             
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">DEPTID</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">JV_NARR</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">JV_DESC</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">GROUP_CODE</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">GROUP_NAME</Data>
                            </Cell>
                        </Row>
                        <xsl:for-each select="//NewDataSet/Table9">
                            <Row ss:AutoFitHeight="0">
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="JVCODE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="JV_DATE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="JV_ACCOUNT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ACCTNAME" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="JV_JOBNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="JV_TRN" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="JV_DEBIT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="JV_CREDIT" />
                                    </Data>
                                </Cell>
                              
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="DEPTID_N" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="JV_NARR" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="JV_DESC" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GROUP_CODE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GROUP_NAME" />
                                    </Data>
                                </Cell>
                            </Row>
                        </xsl:for-each>
                    </Table>
                </xsl:for-each>

            </Worksheet>
        </Workbook>
    </xsl:template>
</xsl:stylesheet>