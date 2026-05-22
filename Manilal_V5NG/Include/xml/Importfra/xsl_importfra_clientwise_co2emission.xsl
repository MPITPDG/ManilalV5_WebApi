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
                          <Style ss:ID="sDefaultStyle">
                <Font ss:Color="#000000"/>
              </Style>
              <Style ss:ID="bold">
                <Font ss:Bold="1"/>
              </Style>
            </Styles>
          <xsl:variable name="clientName" select="//NewDataSet/Table2[CLIENTNAME]" />
          <Worksheet ss:Name="{//NewDataSet/Table2[CLIENTNAME = $clientName]/CLIENTNAME}">
            <!--<xsl:for-each select="//NewDataSet/Table">
              <Table>
                <Column ss:Width="90"/>
                <Column ss:Width="100"/>
                <Column ss:Width="100"/>
                <Column ss:Width="60"/>
                <Column ss:Width="40"/>
                <Column ss:Width="40"/>
                <Column ss:Width="40"/>
                <Column ss:Width="40"/>
                <Column ss:Width="40"/>
                <Column ss:Width="40"/>
                <Column ss:Width="60"/>

                <Row ss:AutoFitHeight="0">
                  <Cell ss:MergeAcross="11" ss:StyleID="m226816136">
                    <Data ss:Type="String">
                      <xsl:value-of select="HEADER" />
                    </Data>
                  </Cell>
                </Row>
              </Table>
              </xsl:for-each>-->
        
                  <Table>
                    <Column ss:Width="80"/>
                    <Column ss:Width="80"/>
                    <Column ss:Width="60"/>
                    <Column ss:Width="60"/>
                    <Column ss:Width="100"/>
                    <Column ss:Width="40"/>
                    <Column ss:Width="70"/>
                    <Column ss:Width="50"/>
                    <Column ss:Width="50"/>
                    <Column ss:Width="60"/>
                    <Column ss:Width="80"/>
                    <Column ss:Width="100"/>
                    <Column ss:Width="70"/>
					<Column ss:Width="40"/>

                    <xsl:for-each select="//NewDataSet/Table">
                       <Row ss:AutoFitHeight="0">
                  <Cell ss:MergeAcross="12" ss:StyleID="m226816136">
                    <Data ss:Type="String">
                      <xsl:value-of select="HEADER" />
                    </Data>
                  </Cell>
                </Row>
                      <Row ss:AutoFitHeight="0">
                        <Cell ss:MergeAcross="12">
                          <Data ss:Type="String">

                          </Data>
                        </Cell>
                      </Row>
                    </xsl:for-each>
                    
                    <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">CONT_MAWB</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">HOUSEBILLNO</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">INCOTERM</Data>
                      </Cell>
					          <Cell ss:StyleID="s68">
						        <Data ss:Type="String">FRT</Data>
					          </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">ORDERNO</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">MODE</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">TOTAL GRWT</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">GRWT</Data>
                      </Cell>

                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">VOLUME</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">CHBLWT</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">CO2</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">CO2 PER ORDER</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">POL</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">POD</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">ATD</Data>
                      </Cell>

                    </Row>
                    <xsl:for-each select="//NewDataSet/Table1">
                      <Row>

                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="CONT_MAWB"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="HOUSEBILLNO"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="INCOTERM"/>
                          </Data>
                        </Cell>
						        <Cell ss:StyleID="s69">
							        <Data ss:Type="String">
								        <xsl:value-of select="FRT"/>
							        </Data>
						        </Cell>  
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="ORDERNO"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="MODE"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="CONSGRWT"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="GRWT"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="VOLUME"/>
                          </Data>
                        </Cell>

                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="CHBLWT"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="CO2"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="CO2_PER_ORDER"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="POL"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="POD"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="ATD"/>
                          </Data>
                        </Cell>


                      </Row>
                    </xsl:for-each>
                  </Table>
          
            </Worksheet> 
          
        </Workbook>
    </xsl:template>
</xsl:stylesheet>