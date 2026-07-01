<xsl:stylesheet version="1.0"
    xmlns="urn:schemas-microsoft-com:office:spreadsheet"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
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
          <Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="8" />
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <NumberFormat  ss:Format="Fixed"/>
          <Protection/>
        </Style>
        <Style ss:ID="s01">
          <Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="8" ss:Bold="1"/>
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Interior/>
        </Style>
        <Style ss:ID="s21">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"
             ss:Color="#FFFFFF"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"
             ss:Color="#FFFFFF"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"
             ss:Color="#FFFFFF"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#000080" ss:Pattern="Solid"/>
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
        <Style ss:ID="s25">
          <Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s26">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"
             ss:Color="#FFFFFF"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"
             ss:Color="#FFFFFF"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"
             ss:Color="#FFFFFF"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#000080" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s29">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#000080" ss:Pattern="Solid"/>
        </Style>
      </Styles>


      <Worksheet>
        <xsl:attribute name="ss:Name">Trial_Balance</xsl:attribute>
        <Table>
          <Column ss:AutoFitWidth="0" ss:Width="76.5"/>
          <Column ss:AutoFitWidth="0" ss:Width="47.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="284.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="72" ss:Span="7"/>
          <xsl:apply-templates select="NewDataSet"/>
          <xsl:for-each select="Table">
            <Row >
              <Cell ss:MergeAcross="11" ss:StyleID="s01">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER"/>
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <Row >
            <Cell ss:MergeAcross="11" ss:StyleID="s01">
              <Data ss:Type="String">Trial Balance</Data>
            </Cell>
          </Row>
          <Row  ss:AutoFitHeight="0" ss:Height="22.5">
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Group</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Code</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Particular</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Opening Bal. Dr.</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Opening Bal. Cr.</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Previous Dr.</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Previous Cr.</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Current Dr.</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Current Cr.</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Closing Bal. Dr.</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Closing Bal. Cr.</Data>
            </Cell>
          </Row>

          <xsl:for-each select="Table1">
            <Row ss:AutoFitHeight="1">
              <Cell ss:StyleID="s25">
                <Data ss:Type="String">
                  <xsl:value-of select="GROUP"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s25">
                <Data ss:Type="String">
                  <xsl:value-of select="CODE"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s25">
                <Data ss:Type="String">
                  <xsl:value-of select="PARTICULAR"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="OpeningBalDr"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="OpeningBalCr"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="PreviousDr"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="PreviousCr"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="CurrentDr"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="CurrentCr"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="ClosingBalDr"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="ClosingBalCr"/>
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
        </Table>
      </Worksheet>
    </Workbook>
  </xsl:template>
</xsl:stylesheet>
