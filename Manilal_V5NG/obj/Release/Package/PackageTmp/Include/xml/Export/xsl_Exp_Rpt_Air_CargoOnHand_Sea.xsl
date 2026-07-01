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
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
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
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="s72">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="Fixed"/>
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
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FF0000"/>
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
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FF0000"/>
        </Style>
        <Style ss:ID="s80">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FF0000"/>
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
        <xsl:attribute name="ss:Name">Under Process</xsl:attribute>
        <Table>
          <Column ss:Width="84.75"/>
          <Column ss:Width="189.75"/>
          <Column ss:Width="176.25"/>
          <Column ss:Width="60"/>
          <Column ss:Width="54"/>
          <Column ss:Width="60"/>
          <Column ss:Width="128.25"/>
          <Column ss:Width="49.5"/>
          <Column ss:Width="45"/>
          <Column ss:Width="100.5"/>
          <Column ss:Width="84"/>
          <Column ss:Width="180.75"/>
          <Column ss:Width="88.5"/>
          <Column ss:Width="207.75"/>
          <Column ss:Width="88.5"/>
          <Column ss:Width="88.5"/>
          <Column ss:AutoFitWidth="0" ss:Width="107.25"/>
          <xsl:for-each select="//NewDataSet/Table3">
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">CARGO ON HAND - SEA</Data>
              </Cell>
            </Row>
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">
                  <xsl:value-of select="CMP_NAME"/>
                </Data>
              </Cell>
            </Row>
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">CITY : <xsl:value-of select="CITYNAME"/></Data>
              </Cell>
            </Row>
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">CONSIGNEE : <xsl:value-of select="CLIENT"/></Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <Row ss:AutoFitHeight="0">
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Export No.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Shipper</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Consignee</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">No. of Pkgs.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">No. of Pcs.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Type of Pcs.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">PO - Style</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Gross Wt.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Volume</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Docs Recd Dt.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Cargo Recd. Date</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Recd. Where</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">MDD</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Vessel Name</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">HBL No.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">HBl Date</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Remarks</Data>
            </Cell>
          </Row>
          <xsl:for-each select="//NewDataSet/Table">
            <xsl:choose>
              <xsl:when test="MDD_FLAG='1'">
                <Row>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPTNO"/>
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
                  <Cell ss:StyleID="s80">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPKGS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s80">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_TYPEOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="PO_STYLE" />
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s74">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_GRWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s74">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_CHBLWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="DOCS_RECD_DT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="CARGO_RECD_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="RECDWHERE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="MDD"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="VSL_NAME"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLDT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="REMARKS"/>
                    </Data>
                  </Cell>
                </Row>
              </xsl:when>
              <xsl:otherwise>
                <Row>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPTNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="SHIPPER"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="CONSIGNEE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s72">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPKGS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s72">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_TYPEOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="PO_STYLE" />
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s73">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_GRWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s73">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_CHBLWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="DOCS_RECD_DT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="CARGO_RECD_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="RECDWHERE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="MDD"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="VSL_NAME"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLDT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="REMARKS"/>
                    </Data>
                  </Cell>
                </Row>
              </xsl:otherwise>
            </xsl:choose>
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

      <Worksheet>
        <xsl:attribute name="ss:Name">Doc. Not Received</xsl:attribute>
        <Table>
          <Column ss:Width="84.75"/>
          <Column ss:Width="189.75"/>
          <Column ss:Width="176.25"/>
          <Column ss:Width="60"/>
          <Column ss:Width="54"/>
          <Column ss:Width="60"/>
          <Column ss:Width="128.25"/>
          <Column ss:Width="49.5"/>
          <Column ss:Width="45"/>
          <Column ss:Width="100.5"/>
          <Column ss:Width="84"/>
          <Column ss:Width="180.75"/>
          <Column ss:Width="88.5"/>
          <Column ss:Width="207.75"/>
          <Column ss:Width="88.5"/>
          <Column ss:Width="88.5"/>
          <Column ss:AutoFitWidth="0" ss:Width="107.25"/>
          <xsl:for-each select="//NewDataSet/Table3">
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">CARGO ON HAND - SEA</Data>
              </Cell>
            </Row>
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">
                  <xsl:value-of select="CMP_NAME"/>
                </Data>
              </Cell>
            </Row>
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">CITY : <xsl:value-of select="CITYNAME"/></Data>
              </Cell>
            </Row>
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">CONSIGNEE : <xsl:value-of select="CLIENT"/></Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <Row ss:AutoFitHeight="0">
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Export No.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Shipper</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Consignee</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">No. of Pkgs.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">No. of Pcs.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Type of Pcs.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">PO - Style</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Gross Wt.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Volume</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Docs Recd Dt.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Cargo Recd. Date</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Recd. Where</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">MDD</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Vessel Name</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">HBL No.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">HBl Date</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Remarks</Data>
            </Cell>
          </Row>
          <xsl:for-each select="//NewDataSet/Table1">
            <xsl:choose>
              <xsl:when test="MDD_FLAG='1'">
                <Row>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPTNO"/>
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
                  <Cell ss:StyleID="s80">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPKGS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s80">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_TYPEOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="PO_STYLE" />
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s74">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_GRWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s74">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_CHBLWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="DOCS_RECD_DT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="CARGO_RECD_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="RECDWHERE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="MDD"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="VSL_NAME"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLDT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="REMARKS"/>
                    </Data>
                  </Cell>
                </Row>
              </xsl:when>
              <xsl:otherwise>
                <Row>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPTNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="SHIPPER"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="CONSIGNEE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s72">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPKGS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s72">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_TYPEOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="PO_STYLE" />
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s73">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_GRWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s73">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_CHBLWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="DOCS_RECD_DT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="CARGO_RECD_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="RECDWHERE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="MDD"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="VSL_NAME"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLDT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="REMARKS"/>
                    </Data>
                  </Cell>
                </Row>
              </xsl:otherwise>
            </xsl:choose>
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

      <Worksheet>
        <xsl:attribute name="ss:Name">MAWB Assigned</xsl:attribute>
        <Table>
          <Column ss:Width="84.75"/>
          <Column ss:Width="189.75"/>
          <Column ss:Width="176.25"/>
          <Column ss:Width="60"/>
          <Column ss:Width="54"/>
          <Column ss:Width="60"/>
          <Column ss:Width="128.25"/>
          <Column ss:Width="49.5"/>
          <Column ss:Width="45"/>
          <Column ss:Width="100.5"/>
          <Column ss:Width="84"/>
          <Column ss:Width="180.75"/>
          <Column ss:Width="88.5"/>
          <Column ss:Width="207.75"/>
          <Column ss:Width="88.5"/>
          <Column ss:Width="88.5"/>
          <Column ss:AutoFitWidth="0" ss:Width="107.25"/>
          <xsl:for-each select="//NewDataSet/Table3">
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">CARGO ON HAND - SEA</Data>
              </Cell>
            </Row>
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">
                  <xsl:value-of select="CMP_NAME"/>
                </Data>
              </Cell>
            </Row>
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">CITY : <xsl:value-of select="CITYNAME"/></Data>
              </Cell>
            </Row>
            <Row ss:Height="16.5">
              <Cell ss:MergeAcross="16" ss:StyleID="s95">
                <Data ss:Type="String">CONSIGNEE : <xsl:value-of select="CLIENT"/></Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <Row ss:AutoFitHeight="0">
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Export No.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Shipper</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Consignee</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">No. of Pkgs.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">No. of Pcs.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Type of Pcs.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">PO - Style</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Gross Wt.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Volume</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Docs Recd Dt.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Cargo Recd. Date</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Recd. Where</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">MDD</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Vessel Name</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">HBL No.</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">HBl Date</Data>
            </Cell>
            <Cell ss:StyleID="s63">
              <Data ss:Type="String">Remarks</Data>
            </Cell>
          </Row>
          <xsl:for-each select="//NewDataSet/Table2">
            <xsl:choose>
              <xsl:when test="MDD_FLAG='1'">
                <Row>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPTNO"/>
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
                  <Cell ss:StyleID="s80">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPKGS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s80">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_TYPEOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="PO_STYLE" />
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s74">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_GRWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s74">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_CHBLWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="DOCS_RECD_DT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="CARGO_RECD_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="RECDWHERE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="MDD"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="VSL_NAME"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLDT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s79">
                    <Data ss:Type="String">
                      <xsl:value-of select="REMARKS"/>
                    </Data>
                  </Cell>
                </Row>
              </xsl:when>
              <xsl:otherwise>
                <Row>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPTNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="SHIPPER"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="CONSIGNEE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s72">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPKGS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s72">
                    <Data ss:Type="Number">
                      <xsl:value-of select="NOOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_TYPEOFPCS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="PO_STYLE" />
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s73">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_GRWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s73">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_CHBLWT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="DOCS_RECD_DT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="CARGO_RECD_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="RECDWHERE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="MDD"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="VSL_NAME"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="EXPT_HBLDT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s71">
                    <Data ss:Type="String">
                      <xsl:value-of select="REMARKS"/>
                    </Data>
                  </Cell>
                </Row>
              </xsl:otherwise>
            </xsl:choose>
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
