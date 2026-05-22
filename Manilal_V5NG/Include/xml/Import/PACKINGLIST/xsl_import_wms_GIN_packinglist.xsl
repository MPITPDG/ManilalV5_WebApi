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
                  <Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="0"/>
                   <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
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
          <Worksheet ss:Name="{worksheetName}">
                <xsl:for-each select="//NewDataSet/Table">
                    <Table>
                        <Column ss:Width="30"/>
                        <Column ss:Width="90"/>
                        <Column ss:Width="35"/>
                        <Column ss:Width="275"/>
                        <Column ss:Width="30"/>
                        <Column ss:Width="40"/>
                        <Column ss:Width="60"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="30"/>
                        <Column ss:Width="50"/>
                        <Column ss:Width="80"/>
                        <Column ss:Width="60"/>
                        <Column ss:Width="60"/>
                        <Column ss:Width="275"/>
                        <Column ss:Width="105"/>
                        <Column ss:Width="50"/>
                        <Column ss:Width="50"/>
                        <Column ss:Width="70"/>
                        <Column ss:Width="70"/>
                        <Column ss:Width="70"/>
                                         
                

                                        
                        <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Sr.No.</Data>
                          </Cell>
                           
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">EAN</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Box No</Data>
                            </Cell>
                       
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Item Name</Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Qty</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">PO Qty</Data>
                            </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Style Id</Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">SKU Code</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Vendor Article No</Data>
                            </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Vendor Article Name</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Size</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Gender</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Brand Name</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Article Type Name</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">HSN Code </Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Source WH</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Destination WH</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">MRP</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">List Price</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Landed Price</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">IGST Rate</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">IGST Amount</Data>
                          </Cell>
                        </Row>
                        <xsl:for-each select="//NewDataSet/Table1">
                            <Row>

                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SrNo"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="EAN"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="BOXNO"/>
                                    </Data>
                                </Cell>
                       
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ITEMNAME"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="QTY"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="POQTY"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="STYLEID"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="SKU"/>
                                    </Data>
                                </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="VENDORARTNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="VENDORARTNAME"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SIZE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="GENDER"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="BRANDNAME"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ARTICLETYPE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="HSNCODE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SOURCEWH"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="DESTWH"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="MRP"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="LISTPRICE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="LANDEDPRICE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="IGSTRATE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="IGSTPRICE"/>
                                </Data>
                              </Cell>
                            </Row>
                        </xsl:for-each>
                    </Table>
                </xsl:for-each>
              
            </Worksheet>
          <Worksheet ss:Name="Packing List">
                <xsl:for-each select="//NewDataSet/Table">
                    <Table>
                        <Column ss:Width="30"/>
                        <Column ss:Width="120"/>
                        <Column ss:Width="127"/>
                        <Column ss:Width="145"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="60"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="115"/>
                        <Column ss:Width="50"/>
                        <Column ss:Width="125"/>
                        <Column ss:Width="200"/>
                        <Column ss:Width="60"/>
                        <Column ss:Width="60"/>
                        <Column ss:Width="60"/>
                        <Column ss:Width="125"/>
                        <Column ss:Width="80"/>
                      
                                                    
                

                                        
                        <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                             <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Sr.No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Slot Date (yyyy-MM-dd)</Data>
                          </Cell>
                           
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">STR Barcode-(STR Number)</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Sender's GST Registration No</Data>
                            </Cell>
                       
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Myntra SKU Code</Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">HSN Code</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">STN Number</Data>
                            </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">STN Date (yyyy-MM-dd)</Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Quantity</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Unit Price Excluding Taxes</Data>
                            </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Total Cost Excluding Taxes [Qnty * Unit Price]</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">CGST Rate</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SGST Rate</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">IGST Rate</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Total Cost Including GST</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Carton Number</Data>
                          </Cell>
                      
                        </Row>
                        <xsl:for-each select="//NewDataSet/Table2">
                            <Row>

                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SrNo"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="SlotDate"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="client_pono"/>
                                    </Data>
                                </Cell>
                       
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SendersGST"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="MyntraSKUCode"/>
                                    </Data>
                                </Cell>
                                <!--<Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="HSNCODE"/>
                                    </Data>
                                </Cell>-->
                                   <xsl:choose>
                            <!-- If it's the last row, apply special formatting -->
                            <xsl:when test="position() = last()">
                                <Cell ss:StyleID="s72">
                                    <Data ss:Type="String">
                                         <xsl:value-of select="HSNCODE"/>
                                    </Data>
                                </Cell>
                            </xsl:when>
                            <!-- If it's not the last row, display the value as normal -->
                            <xsl:otherwise>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="HSNCODE"/>
                                    </Data>
                                </Cell>
                            </xsl:otherwise>
                        </xsl:choose>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="STNNumber"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="STNDate"/>
                                    </Data>
                                </Cell>
                              <!--<Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="QTY"/>
                                </Data>
                              </Cell>-->
                                 <xsl:choose>
                            <!-- If it's the last row, apply special formatting -->
                            <xsl:when test="position() = last()">
                                <Cell ss:StyleID="s72">
                                    <Data ss:Type="String">
                                         <xsl:value-of select="QTY"/>
                                    </Data>
                                </Cell>
                            </xsl:when>
                            <!-- If it's not the last row, display the value as normal -->
                            <xsl:otherwise>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="QTY"/>
                                    </Data>
                                </Cell>
                            </xsl:otherwise>
                        </xsl:choose>
                              <!--<Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="UnitPriceExclTax"/>
                                </Data>
                              </Cell>-->
                                 <xsl:choose>
                            <!-- If it's the last row, apply special formatting -->
                            <xsl:when test="position() = last()">
                                <Cell ss:StyleID="s72">
                                    <Data ss:Type="String">
                                         <xsl:value-of select="UnitPriceExclTax"/>
                                    </Data>
                                </Cell>
                            </xsl:when>
                            <!-- If it's not the last row, display the value as normal -->
                            <xsl:otherwise>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="UnitPriceExclTax"/>
                                    </Data>
                                </Cell>
                            </xsl:otherwise>
                        </xsl:choose>
                              <!--<Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="TotalCostExclTaxe"/>
                                </Data>
                              </Cell>-->
                                 <xsl:choose>
                            <!-- If it's the last row, apply special formatting -->
                            <xsl:when test="position() = last()">
                                <Cell ss:StyleID="s72">
                                    <Data ss:Type="Number">
                                         <xsl:value-of select="TotalCostExclTaxe"/>
                                    </Data>
                                </Cell>
                            </xsl:when>
                            <!-- If it's not the last row, display the value as normal -->
                            <xsl:otherwise>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="TotalCostExclTaxe"/>
                                    </Data>
                                </Cell>
                            </xsl:otherwise>
                        </xsl:choose>
                              <!--<Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="CGSTRate"/>
                                </Data>
                              </Cell>-->
                              <xsl:choose>
                            <!-- If it's the last row, apply special formatting -->
                            <xsl:when test="position() = last()">
                                <Cell ss:StyleID="s72">
                                    <Data ss:Type="String">
                                         <xsl:value-of select="CGSTRate"/>
                                    </Data>
                                </Cell>
                            </xsl:when>
                            <!-- If it's not the last row, display the value as normal -->
                            <xsl:otherwise>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="CGSTRate"/>
                                    </Data>
                                </Cell>
                            </xsl:otherwise>
                        </xsl:choose>
                              <!--<Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="SGSTRate"/>
                                </Data>
                              </Cell>-->
                                  <xsl:choose>
                            <!-- If it's the last row, apply special formatting -->
                            <xsl:when test="position() = last()">
                                <Cell ss:StyleID="s72">
                                    <Data ss:Type="String">
                                         <xsl:value-of select="SGSTRate"/>
                                    </Data>
                                </Cell>
                            </xsl:when>
                            <!-- If it's not the last row, display the value as normal -->
                            <xsl:otherwise>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="SGSTRate"/>
                                    </Data>
                                </Cell>
                            </xsl:otherwise>
                        </xsl:choose>
                              <!--<Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="IGSTRate"/>
                                </Data>
                              </Cell>-->
                                    <xsl:choose>
                            <!-- If it's the last row, apply special formatting -->
                            <xsl:when test="position() = last()">
                                <Cell ss:StyleID="s72">
                                    <Data ss:Type="String">
                                         <xsl:value-of select="IGSTRate"/>
                                    </Data>
                                </Cell>
                            </xsl:when>
                            <!-- If it's not the last row, display the value as normal -->
                            <xsl:otherwise>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="IGSTRate"/>
                                    </Data>
                                </Cell>
                            </xsl:otherwise>
                        </xsl:choose>
                              <!--<Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="TotalCostIncGST"/>
                                </Data>
                              </Cell>-->
                                <xsl:choose>
                            <!-- If it's the last row, apply special formatting -->
                            <xsl:when test="position() = last()">
                                <Cell ss:StyleID="s72">
                                    <Data ss:Type="Number">
                                         <xsl:value-of select="TotalCostIncGST"/>
                                    </Data>
                                </Cell>
                            </xsl:when>
                            <!-- If it's not the last row, display the value as normal -->
                            <xsl:otherwise>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="TotalCostIncGST"/>
                                    </Data>
                                </Cell>
                            </xsl:otherwise>
                        </xsl:choose>
                              <!--<Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="cartonno"/>
                                </Data>
                              </Cell>-->
                             <xsl:choose>
                            <!-- If it's the last row, apply special formatting -->
                            <xsl:when test="position() = last()">
                                <Cell ss:StyleID="s72">
                                    <Data ss:Type="String">
                                         <xsl:value-of select="cartonno"/>
                                    </Data>
                                </Cell>
                            </xsl:when>
                            <!-- If it's not the last row, display the value as normal -->
                            <xsl:otherwise>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="cartonno"/>
                                    </Data>
                                </Cell>
                            </xsl:otherwise>
                        </xsl:choose>
                           
                            </Row>
                        </xsl:for-each>
                       <!--<Row ss:AutoFitHeight="0" ss:StyleID="s67">
                             <Cell ss:StyleID="s68">
                            <Data ss:Type="String"></Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String"></Data>
                          </Cell>
                           
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String"></Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String"></Data>
                            </Cell>
                       
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String"></Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String"></Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String"></Data>
                            </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String"></Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String"></Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Total</Data>
                            </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String"></Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String"></Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String"></Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String"></Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String"></Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String"></Data>
                          </Cell>
                      
                        </Row>-->
                      <!--<xsl:for-each select="//NewDataSet/Table3">
                            <Row>

                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SrNo"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="SlotDate"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="client_pono"/>
                                    </Data>
                                </Cell>
                       
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SendersGST"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="MyntraSKUCode"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="HSNCODE"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="STNNumber"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="STNDate"/>
                                    </Data>
                                </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="QTY"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="UnitPriceExclTax"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="TotalCostExclTaxe"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="CGSTRate"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="SGSTRate"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="IGSTRate"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="TotalCostIncGST"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="cartonno"/>
                                </Data>
                              </Cell>
                           
                           
                            </Row>
                        </xsl:for-each>-->
                    </Table>
                </xsl:for-each>
              <Styles>
        <Style ss:ID="bold">
            <Font ss:Bold="1"/>
        </Style>
    </Styles>
            </Worksheet> 
          
        </Workbook>
    </xsl:template>
</xsl:stylesheet>