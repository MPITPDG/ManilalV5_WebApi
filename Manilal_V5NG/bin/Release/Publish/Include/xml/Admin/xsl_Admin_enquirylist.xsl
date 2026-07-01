<xsl:stylesheet version="1.0"

  xmlns="urn:schemas-microsoft-com:office:spreadsheet"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:xs="http://www.w3.org/2001/XMLSchema"
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
            <Worksheet ss:Name="enquirylist">
                <xsl:for-each select="//NewDataSet/Table1">
                    <Table>
                        <Column ss:Width="100"/>
                        <Column ss:Width="80"/>
                        <Column ss:Width="80"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="150"/>
                        <Column ss:Width="150"/>
                        <Column ss:Width="150"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="150"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="225"/>
                        <Column ss:Width="150"/>
                        <Column ss:Width="150"/>
                        <Column ss:Width="200"/>
                        <Column ss:Width="100"/>
                        <Column ss:Width="100"/>

                       <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="20" ss:StyleID="m226816136">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER" />
                                </Data>
                            </Cell>
                        </Row>
                              
                  
                      <Row ss:AutoFitHeight="0">
                        <Cell ss:MergeAcross="20">
                          <Data ss:Type="String">

                          </Data>
                        </Cell>
                      </Row>

                      <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                                                  
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Enquiry No</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Enquiry Date</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                              <Data ss:Type="String">Mode</Data>
                            </Cell>
                         
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Enquiry Type</Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Exim</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Sales Person</Data>
                            </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Agent Name</Data>
                          </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Country</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Branch</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Network</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Pol</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Pod</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Incoterm</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Dimension</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Status</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Email Subject Line</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Shipper</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Consignee</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Remark</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Created By</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">Created On</Data>
                        </Cell>
                      
						
                        </Row>
                        <xsl:for-each select="//NewDataSet/Table">
                            <Row>
                           
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ENQREFNO"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENQRECPTDT"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="MODE"/>
                                    </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ENQTYPENM"/>
                                    </Data>
                                </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EXIM"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SALESPERSON"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="AGENT_NAME"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="COUNTRYNM"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="BRANCHNM"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="NETWORKNM"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="POLNM"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="PODNM"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="INCOTERM"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="DIMENSIONNM"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ENQSTATUS"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EMAIL"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SHIPPER"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="CONSIGNEE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="REMARK"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="CREATEDBY"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="CREATEDDATE"/>
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