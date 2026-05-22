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
        <!-- Styles definitions here -->
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

      <Worksheet ss:Name="StockStatus">
        <Table>
          <Column ss:Width="100"/>
          <Column ss:Width="80"/>
          <Column ss:Width="100"/>
          <Column ss:Width="300"/>
          <Column ss:Width="80"/>
          <Column ss:Width="80"/>
          <Column ss:Width="80"/>
          <Column ss:Width="60"/>
          <Column ss:Width="80"/>
          <Column ss:Width="100"/>

          <xsl:for-each select="//NewDataSet/Table">
            <Row ss:AutoFitHeight="0" ss:StyleID="s67">
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">INVOICE NO</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">INVOICE DATE</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">INV AMT</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">AIR FREIGHT 706200</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">BROKERAGE 706500</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">HANDLING CHARGES</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">INTERVENTION</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">OCEAN FREIGHT</Data>
              </Cell>
              <Cell ss:StyleID="s68">
                <Data ss:Type="String">TRANSPORT</Data>
              </Cell>
            </Row>

            <xsl:for-each select="//NewDataSet/Table">
              <Row>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="String">
                    <xsl:value-of select="INVOICENO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="String">
                    <xsl:value-of select="INVDATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="INVAMOUNT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="*[name()='AIR FREIGHT 706200']"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="*[name()='BROKERAGE 706500']"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="*[name()='HANDLING CHARGES']"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="*[name()='INTERVENTION DOUANE - PRESTATIONS']"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="*[name()='OCEAN FREIGHT']"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s71">
                  <Data ss:Type="Number">
                    <xsl:value-of select="TRANSPORT"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>
          </xsl:for-each>
        </Table>
      </Worksheet>
    </Workbook>
  </xsl:template>
</xsl:stylesheet>
