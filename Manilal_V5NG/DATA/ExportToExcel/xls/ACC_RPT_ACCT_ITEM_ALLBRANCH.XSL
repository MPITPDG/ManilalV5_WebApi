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
        <xsl:attribute name="ss:Name">Account_Statement</xsl:attribute>
        <Table>
          <Column ss:Width="18"/>
          <Column ss:Width="84.75"/>
          <Column ss:AutoFitWidth="0" ss:Width="77.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="299.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="56.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="58.5"/>
          <xsl:apply-templates select="NewDataSet"/>
          <xsl:for-each select="Table">
            <Row >
              <Cell ss:MergeAcross="5" ss:StyleID="s01">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER"/>
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <Row >
            <Cell ss:MergeAcross="5" ss:StyleID="s01">
              <Data ss:Type="String">Item Statement</Data>
            </Cell>
          </Row>
          <Row  ss:AutoFitHeight="0" ss:Height="22.5">
            <Cell ss:StyleID="s21">
              <Data ss:Type="String"></Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Number</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Date</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Particulars</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Debit</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Credit</Data>
            </Cell>
          </Row>

          <xsl:for-each select="Table1">
            <Row ss:AutoFitHeight="1">
              <Cell ss:StyleID="s25">
                <Data ss:Type="String">
                  <xsl:value-of select="TRANSTYPE"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s25">
                <Data ss:Type="String">
                  <xsl:value-of select="TRANSCODE"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s25">
                <Data ss:Type="String">
                  <xsl:value-of select="DATE1"/>
                </Data>
              </Cell>

              <Cell  ss:StyleID="s25">
                <Data ss:Type="String">
                  <xsl:value-of select="NARR"/>
                  <xsl:value-of select="SUP_SNAME"/>
                  <xsl:value-of select="EXP_SNAME"/>
                  <xsl:value-of select="ACCTNAME"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="DRAMT"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="CRAMT"/>
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <Row >
            <Cell ss:MergeAcross="4" ss:StyleID="s01">
              <Data ss:Type="String">Advance</Data>
            </Cell>
          </Row>
          <Row  ss:AutoFitHeight="0" ss:Height="22.5">
            <Cell ss:StyleID="s21">
              <Data ss:Type="String"></Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Number</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Particulars</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String">Amount</Data>
            </Cell>
          </Row>
          <xsl:for-each select="Table2">
            <Row ss:AutoFitHeight="1">
              <Cell ss:StyleID="s25">
                <Data ss:Type="String">
                  <xsl:value-of select="TRANSTYPE"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s25">
                <Data ss:Type="String">
                  <xsl:value-of select="TRANSCODE"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s25">
                <Data ss:Type="String">
                  <xsl:value-of select="EXP_SNAME"/>
                  <xsl:value-of select="SUP_SNAME"/>
                  <xsl:value-of select="ACCTNAME"/>
                </Data>
              </Cell>
              <Cell  ss:StyleID="s24">
                <Data ss:Type="Number">
                  <xsl:value-of select="ADCRAMT"/>
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
        </Table>
      </Worksheet>
    </Workbook>
  </xsl:template>
</xsl:stylesheet>
