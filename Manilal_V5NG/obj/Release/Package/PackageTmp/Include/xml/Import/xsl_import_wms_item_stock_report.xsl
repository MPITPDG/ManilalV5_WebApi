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
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12"
        ss:Bold="1"/>
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

        <Style ss:ID="sGreenStyle">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <!--<Font ss:Color="#00FF00"/>-->
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#046307" ss:Bold="1"/>
          <!-- Green color -->

        </Style>
        <Style ss:ID="sRedStyle">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FF0000" ss:Bold="1"/>

        </Style>
        <Style ss:ID="sYellowStyle">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFCC00" ss:Bold="1"/>

        </Style>
        <Style ss:ID="sDefaultStyle">
          <Font ss:Color="#000000"/>

        </Style>
      </Styles>
      <Worksheet ss:Name="ItemStockReport">
        <xsl:for-each select="//NewDataSet/Table4">
          <Table>
            <Column ss:Width="90"/>
            <Column ss:Width="90"/>
            <Column ss:Width="275"/>
            <!--<Column ss:Width="40"/>
                        <Column ss:Width="80"/>
                        <Column ss:Width="170"/>-->
            <Column ss:Width="60"/>
            <Column ss:Width="50"/>
            <Column ss:Width="50"/>
            <Column ss:Width="50"/>
            <Column ss:Width="50"/>
            <Column ss:Width="50"/>
            <Column ss:Width="50"/>
            <Column ss:Width="50"/>
            <Column ss:Width="100"/>
            <Column ss:Width="50"/>
            <Column ss:Width="50"/>
            <Column ss:Width="50"/>
            <Column ss:Width="100"/>
            <Column ss:Width="60"/>


            <Row ss:AutoFitHeight="0">
              <Cell ss:MergeAcross="10" ss:StyleID="m226816136">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER" />
                </Data>
              </Cell>
            </Row>
            <Row ss:AutoFitHeight="0">
              <Cell ss:MergeAcross="10">
                <Data ss:Type="String">

                </Data>
              </Cell>
            </Row>


            <Row ss:AutoFitHeight="0" ss:StyleID="s67">
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">Tot Shipment Qty</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">Total Receipt Qty</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">Total Issue Qty</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">Balance Qty</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">FP</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">RFD</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">INPROCESS</Data>
              </Cell>

              <Cell ss:StyleID="s68">
                <Data ss:Type="String">PENDING</Data>
              </Cell>
            </Row>

            <xsl:for-each select="//NewDataSet/Table5">
              <Row>

                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="SHIPPEDQTY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="RECPTQTY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="ISSUEQTY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="BALQTY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="sGreenStyle" >
                  <Data ss:Type="Number">
                    <xsl:value-of select="FP" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="sGreenStyle" >
                  <Data ss:Type="Number">
                    <xsl:value-of select="RFD" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="sYellowStyle">
                  <Data ss:Type="Number">
                    <xsl:value-of select="INPROCESS"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="sRedStyle">
                  <Data ss:Type="Number">
                    <xsl:value-of select="PENDING"/>
                  </Data>
                </Cell>
              </Row>
              <Row ss:AutoFitHeight="0">
                <Cell ss:MergeAcross="9">
                  <Data ss:Type="String">

                  </Data>
                </Cell>
              </Row>

            </xsl:for-each>

            <!--<Row ss:AutoFitHeight="0" ss:StyleID="s67">
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">RFD</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">INPROCESS</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">PENDING</Data>
                        </Cell>
                     
                      </Row>

                      <xsl:for-each select="//NewDataSet/Table6">
                        <Row>

                          <Cell ss:StyleID="sGreenStyle" >
                            <Data ss:Type="Number">
                              <xsl:value-of select="RFD" /> 
                            </Data>
                          </Cell>
                          <Cell ss:StyleID="sYellowStyle">
                            <Data ss:Type="Number">
                              <xsl:value-of select="INPROCESS"/>
                            </Data>
                          </Cell>
                          <Cell ss:StyleID="sRedStyle">
                            <Data ss:Type="Number">
                              <xsl:value-of select="PENDING"/>
                            </Data>
                          </Cell>
                        

                        </Row>
                        <Row ss:AutoFitHeight="0">
                          <Cell ss:MergeAcross="9">
                            <Data ss:Type="String">

                            </Data>
                          </Cell>
                        </Row>

                      </xsl:for-each>-->

            <Row ss:AutoFitHeight="0" ss:StyleID="s67">
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">SKU</Data>
              </Cell>

              <Cell ss:StyleID="s68">
                <Data ss:Type="String">EAN</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">Item Name</Data>
              </Cell>
              <!--<Cell ss:StyleID="s68">
                                <Data ss:Type="String">Size</Data>
                            </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Item Group</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Short Product Desc</Data>
                          </Cell>-->
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">Shipped Qty</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">Opening</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">Recpt Qty</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">Issue Qty</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">Closing</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">FP</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">RFD</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">INPROC</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">PENDING</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">BOX NO</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">RFD BOX </Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">INPROC BOX</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">PENDING BOX</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">ORIGIN COUNTRY</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">RACK SHELF NO</Data>
              </Cell>
            </Row>
            <xsl:for-each select="//NewDataSet/Table">
              <Row>

                <Cell ss:StyleID="s69">
                  <Data ss:Type="String">
                    <xsl:value-of select="SKU"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="String">
                    <xsl:value-of select="EAN"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="String">
                    <xsl:value-of select="ItemName"/>
                  </Data>
                </Cell>
                <!--<Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="Size"/>
                                    </Data>
                                </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ItemGroup"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="Shortprouctdesc"/>
                                </Data>
                              </Cell>-->
                <Cell ss:StyleID="s69">
                  <Data ss:Type="Number">
                    <xsl:value-of select="ShippedQty"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="Number">
                    <xsl:value-of select="Opening"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="Number">
                    <xsl:value-of select="Receivedqty"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="Number">
                    <xsl:value-of select="Issueqty"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="Number">
                    <xsl:value-of select="CL"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="Number">
                    <xsl:value-of select="FP"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="Number">
                    <xsl:value-of select="RFD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="Number">
                    <xsl:value-of select="Inproc"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="Number">
                    <xsl:value-of select="Pending"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="String">
                    <xsl:value-of select="BOXNO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="String">
                    <xsl:value-of select="rfdboxno"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="String">
                    <xsl:value-of select="inprocboxno"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="String">
                    <xsl:value-of select="pendingboxno"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="String">
                    <xsl:value-of select="countryorigin"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s69">
                  <Data ss:Type="String">
                    <xsl:value-of select="RSNO"/>
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