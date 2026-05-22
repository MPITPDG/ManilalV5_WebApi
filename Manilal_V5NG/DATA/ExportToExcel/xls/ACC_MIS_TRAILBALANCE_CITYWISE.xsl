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
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
          <NumberFormat ss:Format="Fixed"/>
          <Protection/>
        </Style>
        <Style ss:ID="s63">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s64">
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
        <Style ss:ID="s65">
          <Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s66">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="Standard"/>
        </Style>
        <Style ss:ID="s67">
          <Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s68">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"
           ss:Bold="1"/>
          <NumberFormat ss:Format="Standard"/>
        </Style>
      </Styles>


      <Worksheet>
        <xsl:attribute name="ss:Name">Trial_Balance</xsl:attribute>
        <Table>
          <Column ss:AutoFitWidth="0" ss:Width="76.5"/>
          <Column ss:AutoFitWidth="0" ss:Width="47.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="284.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="72" ss:Span="7"/>
          <xsl:apply-templates select="//NewDataSet/Table1"/>
          <xsl:for-each select="Table1">
            <Row >
              <Cell ss:MergeAcross="11" ss:StyleID="s63">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER_NAME"/>
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <Row >
            <Cell ss:MergeAcross="11" ss:StyleID="s63">
              <Data ss:Type="String">Trial Balance City Wise</Data>
            </Cell>
          </Row>
          <Row  ss:AutoFitHeight="0" ss:Height="22.5">
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">Group</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">Code</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">Particular</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">Opening Bal. Dr.</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">Opening Bal. Cr.</Data>
            </Cell>
            <!--<Cell ss:StyleID="s64">
              <Data ss:Type="String">Previous Dr.</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">Previous Cr.</Data>
            </Cell>-->
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">Current Dr.</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">Current Cr.</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">Closing Bal. Dr.</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">Closing Bal. Cr.</Data>
            </Cell>
          </Row>

          <xsl:for-each select="Table">
            <Row ss:AutoFitHeight="1">
              <xsl:choose >
                <xsl:when test="CODE='  Total' or PARTICULAR='GRAND TOTAL'" >
                  <Cell ss:StyleID="s67">
                    <Data ss:Type="String">
                      <xsl:value-of select="GROUP_NAME"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s67">
                    <Data ss:Type="String">
                      <xsl:value-of select="CODE"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s67">
                    <Data ss:Type="String">
                      <xsl:value-of select="PARTICULAR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s68">
                    <Data ss:Type="Number">
                      <xsl:value-of select="OPBLDR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s68">
                    <Data ss:Type="Number">
                      <xsl:value-of select="OPBLCR"/>
                    </Data>
                  </Cell>
                  <!--<Cell  ss:StyleID="s68">
                    <Data ss:Type="Number">
                      <xsl:value-of select="PREVDR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s68">
                    <Data ss:Type="Number">
                      <xsl:value-of select="PREVCR"/>
                    </Data>
                  </Cell>-->
                  <Cell  ss:StyleID="s68">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CURRDR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s68">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CURRCR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s68">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CLBLDR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s68">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CLBLCR"/>
                    </Data>
                  </Cell>
                </xsl:when>
                <xsl:otherwise>
                  <Cell ss:StyleID="s65">
                    <Data ss:Type="String">
                      <xsl:value-of select="GROUP_NAME"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s65">
                    <Data ss:Type="String">
                      <xsl:value-of select="CODE"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s65">
                    <Data ss:Type="String">
                      <xsl:value-of select="PARTICULAR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s66">
                    <Data ss:Type="Number">
                      <xsl:value-of select="OPBLDR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s66">
                    <Data ss:Type="Number">
                      <xsl:value-of select="OPBLCR"/>
                    </Data>
                  </Cell>
                  <!--<Cell  ss:StyleID="s66">
                    <Data ss:Type="Number">
                      <xsl:value-of select="PREVDR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s66">
                    <Data ss:Type="Number">
                      <xsl:value-of select="PREVCR"/>
                    </Data>
                  </Cell>-->
                  <Cell  ss:StyleID="s66">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CURRDR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s66">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CURRCR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s66">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CLBLDR"/>
                    </Data>
                  </Cell>
                  <Cell  ss:StyleID="s66">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CLBLCR"/>
                    </Data>
                  </Cell>
                </xsl:otherwise>
              </xsl:choose>
            </Row>
          </xsl:for-each>
        </Table>
      </Worksheet>
    </Workbook>
  </xsl:template>
</xsl:stylesheet>
