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
      
              <Style ss:ID="sDefaultStyle">
                <Font ss:Color="#000000"/>
               
              </Style>
            </Styles>
            <Worksheet ss:Name="returnlist">
                <xsl:for-each select="//NewDataSet/Table1">
                    <Table>
                      <Column ss:Width="100"/>
                      <Column ss:Width="80"/>
                      <Column ss:Width="100"/>
                      <Column ss:Width="100"/>
                      <Column ss:Width="100"/>
                      <Column ss:Width="100"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="90"/>
                   

                       <Row ss:AutoFitHeight="0">
                            <Cell ss:MergeAcross="8" ss:StyleID="s24">
                                <Data ss:Type="String">
                                    <xsl:value-of select="HEADER" />
                                </Data>
                            </Cell>
                        </Row>
                      <Row ss:AutoFitHeight="0">
                        <Cell ss:MergeAcross="8">
                          <Data ss:Type="String">
                           
                          </Data>
                        </Cell>
                      </Row>

                      <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">GRTN NO</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">GRTN DATE</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">RETURN NO</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">CLIENT INVNO</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">RETURN DATE</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">EAN</Data>
                        </Cell>
                      <Cell ss:StyleID="s68">
                          <Data ss:Type="String">KIABI CODE</Data>
                        </Cell>
                        <Cell ss:StyleID="s68">
                          <Data ss:Type="String">BOX NO</Data>
                        </Cell>
                            <Cell ss:StyleID="s68">
                          <Data ss:Type="String">RETURN QTY</Data>
                        </Cell>
                      
                      </Row>

                     <xsl:for-each select="//NewDataSet/Table2">
                        <Row>


                          <Cell ss:StyleID="s69">
                            <Data ss:Type="String">
                              <xsl:value-of select="GRTNNO"/>
                            </Data>
                          </Cell>
                          <Cell ss:StyleID="s69">
                            <Data ss:Type="String">
                              <xsl:value-of select="GRTNDATE"/>
                            </Data>
                          </Cell>
                          <Cell ss:StyleID="s69">
                            <Data ss:Type="String">
                              <xsl:value-of select="RETURNNO"/>
                            </Data>
                          </Cell>
                           <Cell ss:StyleID="s69">
                            <Data ss:Type="String">
                              <xsl:value-of select="CLIENTINVNO"/>
                            </Data>
                          </Cell>
                       <Cell ss:StyleID="s69">
                            <Data ss:Type="String">
                              <xsl:value-of select="RETURNDATE"/>
                            </Data>
                          </Cell>
                       <Cell ss:StyleID="s69">
                            <Data ss:Type="String">
                              <xsl:value-of select="EAN"/>
                            </Data>
                          </Cell>
                       <Cell ss:StyleID="s69">
                            <Data ss:Type="String">
                              <xsl:value-of select="MSKUCODE"/>
                            </Data>
                          </Cell>
                          <Cell ss:StyleID="s69">
                            <Data ss:Type="String">
                              <xsl:value-of select="BOXNO"/>
                            </Data>
                          </Cell>
                         <Cell ss:StyleID="s69">
                            <Data ss:Type="String">
                              <xsl:value-of select="RETURNQTY"/>
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