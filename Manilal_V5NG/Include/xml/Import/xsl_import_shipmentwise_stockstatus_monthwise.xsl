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
            </Styles>
          <!--<xsl:variable name="clientName" select="//NewDataSet/Table2[CLIENTNAME]" />-->
          <!--<Worksheet ss:Name="{//NewDataSet/Table2[CLIENTNAME = $clientName]/CLIENTNAME}">-->
          <Worksheet ss:Name="StockStatus">
        
                  <Table>
                    <Column ss:Width="100"/>
                    <Column ss:Width="80"/>
                    <Column ss:Width="100"/>
                    
                    <Column ss:Width="60"/>
                    <Column ss:Width="60"/>
                    <Column ss:Width="60"/>                    
                    <Column ss:Width="60"/>
                    <Column ss:Width="60"/>
                    
                    <Column ss:Width="150"/>
                    <Column ss:Width="60"/>
                    <Column ss:Width="60"/>
                    <Column ss:Width="100"/>
                    
                    <Column ss:Width="80"/>                    
                    <Column ss:Width="80"/>
                    <Column ss:Width="80"/>
                    <Column ss:Width="80"/>
                    <Column ss:Width="80"/>
                    <Column ss:Width="80"/>
                    
                    <Column ss:Width="100"/>
                    <Column ss:Width="100"/>
                    <Column ss:Width="100"/>

                    <xsl:for-each select="//NewDataSet/Table2">
                      <Row ss:AutoFitHeight="0">
                        <Cell ss:MergeAcross="8" ss:StyleID="m226816136">
                          <Data ss:Type="String">
                            <xsl:value-of select="HEADER" />
                          </Data>
                        </Cell>
                      </Row>
                      <Row ss:AutoFitHeight="0">
                        <Cell ss:MergeAcross="6">
                          <Data ss:Type="String">

                          </Data>
                        </Cell>
                      </Row>
                    </xsl:for-each>
                    
                    <xsl:for-each select="//NewDataSet/Table">
                      <Row ss:AutoFitHeight="0" ss:StyleID="s67">

                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">OP QTY</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">RCPT QTY</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">ISUE QTY</Data>
                        </Cell>
                         <Cell ss:StyleID="s68">
                          <Data ss:Type="String">RTRN QTY</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">BAL QTY</Data>
                        </Cell>
                 
                      </Row>

                      <xsl:for-each select="//NewDataSet/Table">
                        <Row>

                          <Cell ss:StyleID="s71">
                            <Data ss:Type="Number">
                              <xsl:value-of select="OPSTOCK"/>
                            </Data>
                          </Cell>
                          <Cell ss:StyleID="s71">
                            <Data ss:Type="Number">
                              <xsl:value-of select="RECEIPTQTY"/>
                            </Data>
                          </Cell>
                          <Cell ss:StyleID="s71">
                            <Data ss:Type="Number">
                              <xsl:value-of select="ISSUEQTY"/>
                            </Data>
                          </Cell>
                          <Cell ss:StyleID="s71">
                            <Data ss:Type="Number">
                              <xsl:value-of select="RETURNQTY"/>
                            </Data>
                          </Cell>
                          <Cell ss:StyleID="s71">
                            <Data ss:Type="Number">
                              <xsl:value-of select="CL"/>
                            </Data>
                          </Cell>
                 
                        </Row>

                      </xsl:for-each>
                      
                      <!--<Row ss:AutoFitHeight="0">
                        <Cell ss:MergeAcross="10">
                          <Data ss:Type="String">

                          </Data>
                        </Cell>
                      </Row>-->
                      
                     <Row >
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
         
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>                      

                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                      <Cell ss:StyleID="s69">
                        <Data ss:Type="String"></Data>
                      </Cell>
                   
                    </Row>
                      
                    </xsl:for-each>
                    <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">VENDOR ART CODE</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">EAN</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">KIABI SKU CODE</Data>
                      </Cell>

                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">OP QTY</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">RCPT QTY</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">ISUE QTY</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">RTRN QTY</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">BAL QTY</Data>
                      </Cell>
         
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">ITEM NAME</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">HSN</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Style Id</Data>
                      </Cell>                      
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Container Wise Balance</Data>
                      </Cell>
                      
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">[SEA-2401-MRP]</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">[AIR-2405-MRP]</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">[SEA-2406-MRP]</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">[SEA-2401-BALQTY]</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">[AIR-2405-BALQTY]</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">[SEA-2406-BALQTY]</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">RACK/SHELF</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">BOX NO</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">RFD BOX NO</Data>
                      </Cell>
                      
                   
                    </Row>

                    <xsl:for-each select="//NewDataSet/Table1">
                      <Row>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="VENDORARTCODE"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="EAN"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="KIABISKUCODE"/>
                          </Data>
                        </Cell>

                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="OPSTOCK"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="RECEIPTQTY"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="ISSUEQTY"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="RETURNQTY"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="CL"/>
                          </Data>
                        </Cell>
                                                
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="ITEMNAME"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="HSN"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="STYLEID"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="CONTAINERNO"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="*[local-name()='SEA-2401-MRP']"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="*[local-name()='AIR-2405-MRP']"/>

                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="*[local-name()='SEA-2406-MRP']"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="*[local-name()='SEA-2401-BALQTY']"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="*[local-name()='AIR-2405-BALQTY']"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="*[local-name()='SEA-2406-BALQTY']"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="RSNO"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="BOXNO"/>
                          </Data>
                        </Cell>
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="RFDBOXNO"/>
                          </Data>
                        </Cell>
                        
                      </Row>
                    </xsl:for-each>
                  </Table>
      
          
            </Worksheet> 
          
        </Workbook>
    </xsl:template>
</xsl:stylesheet>