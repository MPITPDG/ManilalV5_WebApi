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
          <Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="9" ss:Bold="1"/>
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
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="Standard"/>
        </Style>
        <Style ss:ID="s25">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
          <NumberFormat ss:Format="Standard"/>
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
        <xsl:attribute name="ss:Name">CLIENT_JOB_PROFIT</xsl:attribute>
        <Table>
          <xsl:apply-templates select="NewDataSet"/>
          <xsl:choose>
            <xsl:when test="Table/SEARCH_TYPE[1]='DATEWISE'">
              <xsl:for-each select="Table2[1]/*">
                <Column ss:AutoFitWidth="0" ss:Width="95"/>
              </xsl:for-each>
            </xsl:when>
            <xsl:otherwise>
              <xsl:for-each select="Table3[1]/*">
                <Column ss:AutoFitWidth="0" ss:Width="95"/>
              </xsl:for-each>
            </xsl:otherwise>
          </xsl:choose>
          <xsl:for-each select="Table1">
            <Row>
              <Cell ss:MergeAcross="11" ss:StyleID="s01">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER"/>
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <Row >
            <Cell ss:MergeAcross="3" ss:StyleID="s21">
              <Data ss:Type="String">[G100179],[G100190],[G100222],[G100243] AGENCY</Data>
            </Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="s21">
              <Data ss:Type="String">[G100236] CUSTOM DUTY</Data>
            </Cell>
            <Cell ss:StyleID="s21">
              <Data ss:Type="String"></Data>
            </Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="s21">
              <Data ss:Type="String">TOTAL</Data>
            </Cell>
            <xsl:if test="Table/SEARCH_TYPE[1]='DATEWISE'">
              <Cell ss:StyleID="s21">
                <Data ss:Type="String"></Data>
              </Cell>
            </xsl:if>
            <xsl:for-each select="Table6">
              <Cell ss:MergeAcross="2" ss:StyleID="s21">
                <Data ss:Type="String">
                  <xsl:value-of select="ACCTCODENAME"/>
                </Data>
              </Cell>
            </xsl:for-each>
          </Row>
          <xsl:choose>
            <xsl:when test="Table/SEARCH_TYPE[1]='DATEWISE'">
              <Row>
                <xsl:for-each select="Table2[1]/*">
                  <Cell ss:StyleID="s21">
                    <Data ss:Type="String">
                      <xsl:value-of select="local-name(.)"/>
                    </Data>
                  </Cell>
                </xsl:for-each>
              </Row>
              <xsl:for-each select="Table2">
                <Row>
                  <xsl:for-each select="*">
                    <Cell ss:StyleID="s25">
                      <xsl:choose>
                        <xsl:when test="local-name(.)='CLIENT'">
                          <Data ss:Type="String">
                            <xsl:value-of select="current()"/>
                          </Data>
                        </xsl:when>
                        <xsl:otherwise>
                          <Data ss:Type="Number">
                            <xsl:value-of select="current()"/>
                          </Data>
                        </xsl:otherwise>
                      </xsl:choose>
                    </Cell>
                  </xsl:for-each>
                </Row>
              </xsl:for-each>
            </xsl:when>
            <xsl:when test="Table/SEARCH_TYPE[1]='JOBWISE'">
              <Row>
                <xsl:for-each select="Table3[1]/*">
                  <Cell ss:StyleID="s21">
                    <Data ss:Type="String">
                      <xsl:value-of select="local-name(.)"/>
                    </Data>
                  </Cell>
                </xsl:for-each>
              </Row>
              <xsl:for-each select="Table3">
                <Row>
                  <xsl:for-each select="*">
                    <Cell ss:StyleID="s25">
                      <xsl:choose>
                        <xsl:when test="local-name(.)='JOBNO'">
                          <Data ss:Type="String">
                            <xsl:value-of select="current()"/>
                          </Data>
                        </xsl:when>
                        <xsl:otherwise>
                          <Data ss:Type="Number">
                            <xsl:value-of select="current()"/>
                          </Data>
                        </xsl:otherwise>
                      </xsl:choose>
                    </Cell>
                  </xsl:for-each>
                </Row>
              </xsl:for-each>
            </xsl:when>
          </xsl:choose>
        </Table>
        <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
          <Selected/>
          <FreezePanes/>
          <FrozenNoSplit/>
          <SplitHorizontal>4</SplitHorizontal>
          <TopRowBottomPane>4</TopRowBottomPane>
          <ActivePane>2</ActivePane>
          <Panes>
            <Pane>
              <Number>3</Number>
            </Pane>
            <Pane>
              <Number>2</Number>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>
      </Worksheet>
    </Workbook>
  </xsl:template>
</xsl:stylesheet>
