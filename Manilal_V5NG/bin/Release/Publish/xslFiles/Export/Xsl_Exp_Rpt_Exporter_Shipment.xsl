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
        <xsl:attribute name="ss:Name">EXPORTER SHIPMENT</xsl:attribute>
        <Table ss:DefaultColumnWidth="1400">
          <Column ss:Index="1" ss:Width="85"/>
          <Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="250"/>
          <Column  ss:Index="3" ss:Width="250"/>
          <Column ss:Index="4" ss:Width="70"/>
          <Column ss:Index="5" ss:Width="70"/>
          <Column ss:Index="6" ss:Width="70"/>
          <Column ss:Index="7" ss:Width="70"/>
          <Column ss:Index="8" ss:Width="150"/>
          <Column ss:Index="9" ss:Width="70"/>
          <Column ss:Index="10" ss:Width="150"/>
          <xsl:apply-templates select="NewDataSet"/>
          <xsl:for-each select="//NewDataSet/Table">
            <xsl:variable name="MODE" select="MODE"></xsl:variable>
            <Row>
              <Cell ss:MergeAcross="27" ss:StyleID="s01">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER" />
                </Data>
              </Cell>
            </Row>
            <!--<Row>
              <Cell ss:MergeAcross="27" ss:StyleID="s01">
                <Data ss:Type="String">
                  <Data ss:Type="String">MODE :- </Data>
                  <xsl:value-of select="MODE" />
                </Data>
              </Cell>
            </Row>-->
            <Row>
              <Cell ss:MergeAcross="27" ss:StyleID="s01">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER1" />
                </Data>
              </Cell>
            </Row>
            <!--<Row>
              <Cell ss:MergeAcross="27" ss:StyleID="s01">
                <Data ss:Type="String">EXPORTER SHIPMENT</Data>
              </Cell>
            </Row>-->
            <Row ss:AutoFitHeight="0" ss:Height="25.5">
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">EXPTNO</Data>
              </Cell>
             
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">CONSIGNEE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">AGENT</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">DOC RECVD DATE</Data>
              </Cell>
              
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">NOOFPKGS</Data>
              </Cell>
              <xsl:if test="$MODE='SEA'">
                <Cell ss:StyleID="s1011">
                  <Data ss:Type="String">GRWT</Data>
                </Cell>
              </xsl:if>
              <xsl:if test="$MODE='AIR'">
                <Cell ss:StyleID="s1011">
                  <Data ss:Type="String">CHBLWT</Data>
                </Cell>
              </xsl:if>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">VOLUME</Data>
              </Cell>
              <xsl:if test="$MODE='SEA'">
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">VESSEL NAME</Data>
                </Cell>
              </xsl:if>
              <xsl:if test="$MODE='AIR'">
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">FLIGHT NO</Data>
                </Cell>
              </xsl:if>
              <xsl:if test="$MODE='SEA'">
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">ETD</Data>
                </Cell>
              </xsl:if>
              <xsl:if test="$MODE='AIR'">
                <Cell ss:StyleID="s1010">
                  <Data ss:Type="String">ACTUAL FLIGHT DT</Data>
                </Cell>
              </xsl:if>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">INVOICE NO</Data>
              </Cell>
            </Row>
            <xsl:for-each select="//NewDataSet/Table1">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPTNO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="CONS_NAME"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="AGENT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPT_DOCRECD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPT_NOOFPKGS"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPT_GRWT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPT_VOLUME"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="VSL_NAME"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="INVOIVENO"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>
          </xsl:for-each>
        </Table>
        <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
          <Selected/>
          <FreezePanes/>
          <FrozenNoSplit/>
          <SplitHorizontal>3</SplitHorizontal>
          <TopRowBottomPane>3</TopRowBottomPane>
          <ActivePane>2</ActivePane>
          <Panes>
            <Pane>
              <Number>3</Number>
            </Pane>
            <Pane>
              <Number>3</Number>
              <ActiveRow>10</ActiveRow>
              <ActiveCol>3</ActiveCol>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>
      </Worksheet>
    </Workbook>
  </xsl:template>
</xsl:stylesheet>
