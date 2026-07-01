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
        <Style ss:ID="s01">
          <Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="10" ss:Bold="1"/>
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Interior/>
        </Style>
        <Style ss:ID="s010">
          <Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="12" ss:Bold="1"/>
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Interior/>
        </Style>
        <Style ss:ID="s100">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s1000">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s1001">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s101">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s1010">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s1011">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s1011_2">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="Standard"/>
          <Protection/>
        </Style>
        <Style ss:ID="s1011_3">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="0.000"/>
          <Protection/>
        </Style>
        <Style ss:ID="s1011_4">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
					 ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="0.0000"/>
          <Protection/>
        </Style>
        <Style ss:ID="s25">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s250">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000" ss:Bold="1"/>
        </Style>
        <Style ss:ID="s24">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
          <NumberFormat ss:Format="Standard"/>
        </Style>
        <Style ss:ID="s240">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000" ss:Bold="1"/>
          <NumberFormat ss:Format="Standard"/>
        </Style>
        <Style ss:ID="s24_3">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
          <NumberFormat ss:Format="0.000"/>
        </Style>
        <Style ss:ID="s24_30">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>

          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000" ss:Bold="1"/>
          <NumberFormat ss:Format="0.000"/>
        </Style>
        <Style ss:ID="s24_4">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
          <NumberFormat ss:Format="0.0000"/>
        </Style>
        <Style ss:ID="s24_40">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000" ss:Bold="1"/>
          <NumberFormat ss:Format="0.0000"/>
        </Style>
        <Style ss:ID="s24_2">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
          <NumberFormat ss:Format="0.00"/>
        </Style>
        <Style ss:ID="s24_20">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000" ss:Bold="1"/>
          <NumberFormat ss:Format="0.00"/>
        </Style>
      </Styles>
      <Worksheet>
        <xsl:attribute name="ss:Name">MP_Cargo</xsl:attribute>
        <Table ss:DefaultColumnWidth="700">
          <Column ss:Index="1" ss:Width="100"/>
          <Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="70"/>
          <Column  ss:Index="3" ss:Width="80"/>

          <Column ss:Index="4" ss:Width="70"/>
          <Column ss:Index="5" ss:Width="70"/>
          <Column ss:Index="6" ss:Width="70"/>
          <Column ss:Index="7" ss:Width="265"/>
          <xsl:apply-templates select="NewDataSet"/>
          <xsl:for-each select="//NewDataSet/Table">
            <xsl:variable name="CATE" select="CATEGORY"></xsl:variable>
            
            <xsl:if test="$CATE='2'">
            <Row>
              <Cell ss:MergeAcross="27" ss:StyleID="s01">
                <Data ss:Type="String">MP CARGO SWISS PORT INTGRATION  REPORT</Data>
              </Cell>
            </Row>
            <Row ss:AutoFitHeight="0" ss:Height="25.5">
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">MAWBNO</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">GRWT SW</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">GRWT MP WEB</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">DIFFERENCE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">TOTAL GROSS WEIGHT SWISS PORT HANDLED</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">PREVIOUS MONTH</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">REMARKS</Data>
              </Cell>
            </Row>
            <xsl:for-each select="//NewDataSet/Table1">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="MAWBNO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="GRWT_SW"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="GRWT_MP"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="DIFFERANCE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="TOT_SWISS_HANDLED"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="LAST_MON_HANDLED"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="REMARKS"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>
            </xsl:if>
            <xsl:if test="$CATE='4'">
              <Row>
                <Cell ss:MergeAcross="27" ss:StyleID="s01">
                  <Data ss:Type="String">MP CARGO FRANCE HANDLING INTGRATION  REPORT</Data>
                </Cell>
              </Row>
              <Row ss:AutoFitHeight="0" ss:Height="25.5">
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">MAWBNO</Data>
                </Cell>
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">CURRENT_WT</Data>
                </Cell>
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">PREV_USED_WT</Data>
                </Cell>
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">TOTAL_WT</Data>
                </Cell>
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">MP_GRWT</Data>
                </Cell>
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">DIFFERENCE</Data>
                </Cell>               
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">REMARKS</Data>
                </Cell>
              </Row>
              <xsl:for-each select="//NewDataSet/Table1">
                <Row ss:AutoFitHeight="1">
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="MAWBNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="CURRENT_WT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="PREV_USED_WT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="TOTAL_WT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="MP_GRWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="DEF_GRWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="REMARK"/>
                    </Data>
                  </Cell>
                </Row>
              </xsl:for-each>
            </xsl:if>
          </xsl:for-each>
        </Table>
        <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
          <Selected/>
          <FreezePanes/>
          <FrozenNoSplit/>
          <SplitHorizontal>2</SplitHorizontal>
          <TopRowBottomPane>2</TopRowBottomPane>
          <ActivePane>2</ActivePane>
          <Panes>
            <Pane>
              <Number>3</Number>
            </Pane>
            <Pane>
              <Number>2</Number>
              <ActiveRow>8</ActiveRow>
              <ActiveCol>2</ActiveCol>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>
      </Worksheet>
    </Workbook>
  </xsl:template>
</xsl:stylesheet>