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
              <Style ss:ID="StrikeThroughStyle">
                <Font ss:StrikeThrough="1"/>
              </Style>
                  <Style ss:ID="sDefaultStyle">
                  <Font ss:Color="#000000"/>
                  </Style>
            </Styles>
          <Worksheet ss:Name="{worksheetName}">
                  <Table>
                    <Column ss:Width="120"/>
                    <Column ss:Width="100"/>
                    <Column ss:Width="90"/>
                    <Column ss:Width="280"/>
                    <Column ss:Width="60"/>
                    <Column ss:Width="40"/>
                    <Column ss:Width="40"/>
                    <Column ss:Width="40"/>
                    <Column ss:Width="300"/>
                 

                    <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Po No</Data>
                      </Cell>
             
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Qty</Data>
                      </Cell>

                    </Row>
              

                    <xsl:for-each select="//NewDataSet/Table">
                      <Row>

                        <Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="PONO"/>
                          </Data>
                        </Cell>
                     
                        <Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="POQTY"/>
                          </Data>
                        </Cell>
                      </Row>
                    </xsl:for-each>
                    <Row ss:AutoFitHeight="0">
                      <Cell ss:MergeAcross="6">
                        <Data ss:Type="String">

                        </Data>
                      </Cell>
                    </Row>
                    <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Vendor Sku Code</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Sku</Data>
                      </Cell>
                      
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Ean</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Item Name</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Mrp</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Rack No.</Data>
                      </Cell>

                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Po Qty</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Cl Stock</Data>
                      </Cell>
                      <Cell ss:StyleID="s68">
                        <Data ss:Type="String">Container</Data>
                      </Cell>


                    </Row>
                    <xsl:for-each select="//NewDataSet/Table1">
                      <Row>
                        <xsl:choose>
                          <xsl:when test="FLAG = '0'">
                             <Cell ss:StyleID="StrikeThroughStyle"><Data ss:Type="String"><xsl:value-of select="VENDORSKUCODE"/></Data></Cell>
                            <Cell ss:StyleID="StrikeThroughStyle"><Data ss:Type="String"><xsl:value-of select="SKU"/></Data></Cell>
                            <Cell ss:StyleID="StrikeThroughStyle"><Data ss:Type="String"><xsl:value-of select="EAN"/></Data></Cell>
                            <Cell ss:StyleID="StrikeThroughStyle"><Data ss:Type="String"><xsl:value-of select="ITEMNAME"/></Data></Cell>
                            <Cell ss:StyleID="StrikeThroughStyle"><Data ss:Type="String"><xsl:value-of select="MRP"/></Data></Cell>
                            <Cell ss:StyleID="s69"><Data ss:Type="String"><xsl:value-of select="RACKNO"/></Data></Cell>
                            <Cell ss:StyleID="s69"><Data ss:Type="Number"><xsl:value-of select="PO_QTY"/></Data></Cell>
                            <Cell ss:StyleID="s69"><Data ss:Type="Number"><xsl:value-of select="CL_STOCK"/></Data></Cell>
                            <Cell ss:StyleID="s69"><Data ss:Type="String"><xsl:value-of select="CONTAINERNO"/></Data></Cell>
              
                        <!--<Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="VENDORSKUCODE"/>
                          </Data>
                        </Cell>-->
                        <!--<Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="SKU"/>
                          </Data>
                        </Cell>-->
                        <!--<Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="EAN"/>
                          </Data>
                        </Cell>-->
                        <!--<Cell>
                          <xsl:choose>
                            <xsl:when test="FLAG = '0'">
                              <xsl:attribute name="ss:StyleID">strikethroughStyle</xsl:attribute>
                            </xsl:when>
                            <xsl:otherwise>
                              <xsl:attribute name="ss:StyleID">s69</xsl:attribute>
                            </xsl:otherwise>
                          </xsl:choose>
                          <Data ss:Type="String">
                            <xsl:value-of select="EAN"/>
                          </Data>
                        </Cell>-->
                     
                        <!--<Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="ITEMNAME"/>
                          </Data>
                        </Cell>-->
                        <!--<Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="MRP"/>
                          </Data>
                        </Cell>-->
                        <!--<Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="RACKNO"/>
                          </Data>
                        </Cell>-->
                        <!--<Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="PO_QTY"/>
                          </Data>
                        </Cell>-->

                        <!--<Cell ss:StyleID="s69">
                          <Data ss:Type="Number">
                            <xsl:value-of select="CL_STOCK"/>
                          </Data>
                        </Cell>-->
                        <!--<Cell ss:StyleID="s69">
                          <Data ss:Type="String">
                            <xsl:value-of select="CONTAINERNO"/>
                          </Data>
                        </Cell>-->
                          </xsl:when>
                          <xsl:otherwise>
                             <Cell ss:StyleID="s69"><Data ss:Type="String"><xsl:value-of select="VENDORSKUCODE"/></Data></Cell>
                             <Cell ss:StyleID="s69"><Data ss:Type="String"><xsl:value-of select="SKU"/></Data></Cell>
                             <Cell ss:StyleID="s69"><Data ss:Type="String"><xsl:value-of select="EAN"/></Data></Cell>
                            <Cell ss:StyleID="s69"><Data ss:Type="String"><xsl:value-of select="ITEMNAME"/></Data></Cell>
                             <Cell ss:StyleID="s69"><Data ss:Type="String"><xsl:value-of select="MRP"/></Data></Cell>
                             <Cell ss:StyleID="s69"><Data ss:Type="String"><xsl:value-of select="RACKNO"/></Data></Cell>
                             <Cell ss:StyleID="s69"><Data ss:Type="Number"><xsl:value-of select="PO_QTY"/></Data></Cell>
                             <Cell ss:StyleID="s69"><Data ss:Type="Number"><xsl:value-of select="CL_STOCK"/></Data></Cell>
                             <Cell ss:StyleID="s69"><Data ss:Type="String"><xsl:value-of select="CONTAINERNO"/></Data></Cell>
                          </xsl:otherwise>
                        </xsl:choose>
                      </Row>
                    </xsl:for-each>
                  
                  </Table>
              
              <Styles>
        <Style ss:ID="bold">
            <Font ss:Bold="1"/>
        </Style>
    </Styles>
            </Worksheet> 
          
        </Workbook>
    </xsl:template>
</xsl:stylesheet>