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
            <Worksheet ss:Name="RECONCILLED">
                <xsl:for-each select="//NewDataSet/Table">
                    <Table>
                        <Column ss:Width="100"/>
                        <Column ss:Width="56.25"/>
                        <Column ss:Width="87"/>
                        <Column ss:Width="79.5"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="90"/>
                        <Column ss:Width="69"/>
                        <Column ss:Width="52.5"/>
                        <Column ss:Width="60"/>
                        <Column ss:Width="69.75"/>
                        <Column ss:Width="87.75"/>

                       <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="11" ss:StyleID="m226816136">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER1" />
                                </Data>
                            </Cell>
                        </Row>
                      <!--  <Row ss:AutoFitHeight="0">
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
                        </Row>-->
                        <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Bank Ref No</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Deposit</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Withdrawal</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Clearance Dt</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Sys.Bank Ref No</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Entry No</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Entry Date</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Entry Type</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Amount</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Deduction</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Clearance Dt</Data>
                            </Cell>
						
                        </Row>
                        <xsl:for-each select="//NewDataSet/Table1">
                            <Row>

                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="BANKREFNO"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s24">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="DEPOSIT"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s24">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="WITHDRAWAL"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CLEARANCEDT"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="USERBANKREFNO"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENTRYNO"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENTRYDT"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENTRYTYPE"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s24">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="AMOUNT"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s24">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="DEDUCTION"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CLEARANCEDT"/>
                                    </Data>
                                </Cell>
							
                            </Row>
                        </xsl:for-each>
                    </Table>
                </xsl:for-each>
              
            </Worksheet>
          <Worksheet ss:Name="UNRECONCILLED">
                <xsl:for-each select="//NewDataSet/Table">
                    <Table>
                      <Column ss:Width="100"/>
                      <Column ss:Width="56.25"/>
                      <Column ss:Width="87"/>
                      <Column ss:Width="79.5"/>
                      <Column ss:Width="100"/>
                      <Column ss:Width="90"/>
                      <Column ss:Width="69"/>
                      <Column ss:Width="52.5"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="69.75"/>
                      <Column ss:Width="87.75"/>
                      <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="11" ss:StyleID="m226815720">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER1" />
                                </Data>
                            </Cell>
                        </Row>
                        <!--<Row ss:AutoFitHeight="0">
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
                        </Row>-->
                        <Row ss:AutoFitHeight="0" ss:Height="30">
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Bank Ref No</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Deposit</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Withdrawal</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Clearance Date</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Bank Ref No</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Entry No</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Entry Date</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Entry Type</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Amount</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Deduction</Data>
                            </Cell>
                            <Cell ss:StyleID="s71">
                                <Data ss:Type="String">Clearance Date</Data>
                            </Cell>
						
                        </Row>
                        <xsl:for-each select="//NewDataSet/Table2">
                            <Row ss:AutoFitHeight="0">
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="BANKREFNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s24">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="DEPOSIT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s24">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="WITHDRAWAL" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CLEARANCEDT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="USERBANKREFNO" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENTRYNO" />
                                    </Data>
                                </Cell>

                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENTRYDT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENTRYTYPE" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s24">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="AMOUNT" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s24">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="DEDUCTION" />
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s73">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="CLEARANCEDT" />
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