<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:user="urn:my-scripts"
    xmlns:o="urn:schemas-microsoft-com:office:office"
    xmlns:x="urn:schemas-microsoft-com:office:excel"
    xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet" >

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
        <Style ss:ID="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s63">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF" />
          <Interior ss:Color="#538ED5" ss:Pattern="Solid" />
        </Style>
        <Style ss:ID="s64">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s65">
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <NumberFormat ss:Format="Fixed"/>
        </Style>
        <Style ss:ID="s66">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="s67">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="s68">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="0.0000"/>
        </Style>
        <Style ss:ID="s69">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="0.0000"/>
        </Style>
        <Style ss:ID="s70">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="0.0000"/>
        </Style>
        <Style ss:ID="s71">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s72">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s73">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="Fixed"/>
        </Style>
        <Style ss:ID="s74">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s77">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="0"/>
        </Style>
        <Style ss:ID="s75">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="0.0000"/>
          <Font ss:Bold="1"/>
        </Style>
        <Style ss:ID="s76">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="Fixed"/>
        </Style>
        <Style ss:ID="s79">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s80">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="0"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="0"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="0"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000" ss:Bold="1"/>
          <NumberFormat ss:Format="Fixed"/>
        </Style>
        <Style ss:ID="s95">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
      </Styles>
      <Worksheet>
        <xsl:attribute name="ss:Name">SHIPMENT STATUS</xsl:attribute>
        <Table >
          <Column ss:Width="76.5"/>
          <Column ss:Width="124.5"/>
          <Column ss:Width="214.5"/>
          <Column ss:Width="198"/>
          <Column ss:Width="57.75"/>
          <Column ss:Width="58.5" ss:Span="1"/>
          <Column ss:Index="8" ss:Width="75.75"/>
          <Column ss:Width="87"/>
          <Column ss:Width="123"/>
          <Column ss:Width="183"/>
          <Column ss:Width="201.75"/>
          <Column ss:Width="34.5"/>
          <Column ss:Width="23.25"/>
          <Column ss:Width="39.75"/>
          <Column ss:Index="17" ss:Width="65.25"/>
          <Column ss:Width="74.25"/>
          <Column ss:Width="67.5"/>
          <Column ss:Width="56.25"/>
          <Column ss:Width="55.5"/>
          <Column ss:AutoFitWidth="0" ss:Width="60"/>
          <xsl:for-each select="//NewDataSet/Table2">
            <!--<Row ss:Height="16.5">
              <Cell ss:MergeAcross="21" ss:StyleID="s95">
                <Data ss:Type="String">SHIPMENT STATUS - SEA</Data>
              </Cell>
            </Row>-->
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="20" ss:StyleID="s80">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER"/>
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>

          <Row ss:Height="16.5">
            <Cell ss:MergeAcross="20" ss:StyleID="s80">
              <Data ss:Type="String"></Data>
            </Cell>
          </Row>

          <Row ss:AutoFitHeight="0">
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">ORIGIN</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">MAWB</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">FLTDTLS</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">TRNSSHPT</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">HAWBNO</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">ETD</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">ETA</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">DESTINATION</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">MP REF</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">SHIPPER</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">CONSIGNEE</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">ORDER DETAILS</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">CTNS.</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">FRT</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">GR.WT</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">CHBLWT</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">DOCS.RECD.</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">CARGO RECD.</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">APRVL RECD</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">CLRCE</Data>
            </Cell>
            <Cell ss:StyleID="s95">
              <Data ss:Type="String">REMARKS</Data>
            </Cell>
          </Row>
          <xsl:for-each select="//NewDataSet/Table">              
                <Row>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="ORIGIN"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="MAWB"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="FLTDTLS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="TRNSSHPT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="HAWBNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="ETD"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="ETA" />
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="DESTINATION"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="MPREF"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="SHIPPER"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="CONSIGNEE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="ORDERDETAILS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="CTNS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="FRT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="GRWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="CHBLWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="DOCSRECD"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="CARGORECD"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="APRVLRECD"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="CLRCE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="REMARK"/>
                    </Data>
                  </Cell>
                </Row>
              
          </xsl:for-each>
        </Table>
        <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
          <Selected/>
          <FreezePanes/>
          <FrozenNoSplit/>
          <SplitHorizontal>5</SplitHorizontal>
          <TopRowBottomPane>5</TopRowBottomPane>
          <ActivePane>2</ActivePane>
          <Panes>
            <Pane>
              <Number>3</Number>
            </Pane>
            <Pane>
              <Number>2</Number>
              <ActiveRow>2</ActiveRow>
              <ActiveCol>1</ActiveCol>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>
      </Worksheet>
    </Workbook>
  </xsl:template>
</xsl:stylesheet>


