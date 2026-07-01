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
          <Worksheet ss:Name="Delivery Challan">
                <xsl:for-each select="//NewDataSet/Table1">
                
                    <Table>
                      <Column ss:Width="30"/>
                      <Column ss:Width="90"/>
                      <Column ss:Width="35"/>
                      <Column ss:Width="275"/>
                      <Column ss:Width="30"/>
                      <Column ss:Width="120"/>
                      <Column ss:Width="80"/>
                      <Column ss:Width="80"/>
                      <Column ss:Width="80"/>
                      <Column ss:Width="80"/>
                      <Column ss:Width="80"/>
                      <Column ss:Width="80"/>
                      <Column ss:Width="120"/>
                      <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                        <!--<Cell ss:StyleID="s68">
                          <Data ss:Type="String">Issue No</Data>
                        </Cell>

                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Issue Date</Data>
                        </Cell>-->
                        <!--<Cell ss:StyleID="s68">
                          <Data ss:Type="String"></Data>
                        </Cell>-->
                        <!--<Cell ss:StyleID="s68"  ss:MergeAcross="1">
                          <Data ss:Type="String">Client</Data>
                        </Cell>-->
                        <Cell ss:StyleID="s69"  ss:MergeAcross="3">
                          <Data ss:Type="String">
                            <xsl:value-of select="CLIENTNAME"/>
                          </Data>
                        </Cell>

                      </Row>
                      <Row>

                        <!--<Cell ss:StyleID="s68" ss:MergeAcross="1">
                          <Data ss:Type="String">Address</Data>
                        </Cell>-->
                        <!--<Cell ss:StyleID="s69"  ss:MergeAcross="2">
                          <Data ss:Type="String">
                            <xsl:value-of select="concat(EXP_INVADD1, ' ', EXP_INVADD2)"/>
                          </Data>
                        </Cell>-->
                        <Cell ss:StyleID="s69" ss:MergeAcross="3">
                          <Data ss:Type="String">
                            <xsl:value-of select="CLIENTADDR"/>
                          </Data>
                        </Cell>
                      </Row>
                      <Row>
                        <!--<Cell ss:StyleID="s68" ss:MergeAcross="1">
                          <Data ss:Type="String">Issue No</Data>
                        </Cell>-->
                        <Cell ss:StyleID="s69" ss:MergeAcross="3">
                          <Data ss:Type="String">
                            <xsl:value-of select="ISSUENO"/>
                          </Data>
                        </Cell>
                     
                      </Row>
                 
                      <Row>

                        <Cell ss:StyleID="s69" ss:MergeAcross="2">
                          <Data ss:Type="String">
                            <xsl:value-of select="PONO"/>
                          </Data>
                        </Cell>
                      </Row>
                      <Row></Row>              
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
                            <Data ss:Type="String">Shipment No</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Cargo Rcpt Date</Data>
                          </Cell>

                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Grn Date</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Rtn Date</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Act Rtn Date</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">GI Date</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Dispatch Date</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Storage Duration(Days) </Data>
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
                                        <xsl:value-of select="ISSUEQTY"/>
                                    </Data>
                                </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SHIPMENTNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="CARGORCTDATE"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="GRNDATE"/>
                                    </Data>
                                </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="RTNDATE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ACTRTNDATE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ISSUEDATE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="LRDATE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="NOOFDAYS"/>
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