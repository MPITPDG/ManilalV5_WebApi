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
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s63">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s64">
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
        <Style ss:ID="s65">
          <Alignment ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s66">
          <Alignment ss:Horizontal="Right" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat ss:Format="Standard"/>
          <Protection/>
        </Style>
      </Styles>
      <Worksheet>
        <xsl:attribute name="ss:Name">CARGO_RECVD</xsl:attribute>
        <Table ss:DefaultColumnWidth="100.5">
          <Column ss:Width="40.5"/>
          <Column ss:Width="273"/>
          <Column ss:Index="9" ss:Width="87"/>
          <Column ss:Width="98.25"/>

          <xsl:apply-templates select="NewDataSet"/>
          <xsl:for-each select="Table">
            <Row>
              <Cell ss:MergeAcross="9" ss:StyleID="s63">
                <Data ss:Type="String">MANILAL PATEL CLEARING FORWARDING  </Data>
              </Cell>
            </Row>
            <Row>
              <Cell ss:MergeAcross="9" ss:StyleID="s63">
                <Data ss:Type="String">
                  <xsl:value-of select="PERIOD" />
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <Row ss:AutoFitHeight="0" ss:Height="25.5">
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">ORIGIN</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">ORDERNO</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">EXPTNO</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">PKGS</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">PCS</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">SHIPPER</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">CONSINEE</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">PKGS RECVD</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">CARGO RECVD ON</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">ENTERED IN SYSTEM DATETIME</Data>
            </Cell>
          </Row>
          <xsl:for-each select="Table1">
			  <xsl:variable name="ORDNO" select="ORDERNO"></xsl:variable>
            <Row ss:AutoFitHeight="1">
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">
                  <xsl:value-of select="ORIGIN"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">
					<xsl:value-of disable-output-escaping="yes" select="$ORDNO" />
                </Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">
                  <xsl:value-of select="EXPTNO"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">
                  <xsl:value-of select="NO_PKGS" />
                </Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">
                  <xsl:value-of select="NO_PCS" />
                </Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">
                  <xsl:value-of select="SHIPPER" />
                </Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">
                  <xsl:value-of select="CONSIGNEE" />
                </Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">
                  <xsl:value-of select="PKGS_RECVD" />
                </Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">
                  <xsl:value-of select="RECVD_DATE" />
                </Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">
                  <xsl:value-of select="SYS_RECVD" />
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
        </Table>
        <Selected/>
        <!--<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
          <FreezePanes/>
          <FrozenNoSplit/>
          <SplitHorizontal>10</SplitHorizontal>
          <TopRowBottomPane>10</TopRowBottomPane>
          <ActivePane>0</ActivePane>
          <Panes>
            <Pane>
              <Number>2</Number>
            </Pane>
            <Pane>
              <Number>2</Number>
              <ActiveRow>2</ActiveRow>
              <ActiveCol>2</ActiveCol>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>-->
      </Worksheet>
    </Workbook>
  </xsl:template>
</xsl:stylesheet>