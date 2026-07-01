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
        <xsl:attribute name="ss:Name">PO HEADER</xsl:attribute>
        <Table ss:DefaultColumnWidth="200">
          <Column ss:Index="1" ss:Width="70"/>
          <Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="85"/>
          <Column ss:Index="3" ss:Width="80"/>
          <Column ss:Index="4" ss:Width="65"/>
          <Column ss:Index="5" ss:Width="80"/>
          <Column ss:Index="6" ss:Width="80"/>
          <Column ss:Index="7" ss:Width="50"/>
          <Column ss:Index="8" ss:Width="50"/>
          <Column ss:Index="9" ss:Width="50"/>
          <Column ss:Index="10" ss:Width="65"/>
          <Column ss:Index="11" ss:Width="150"/>
          <Column ss:Index="12" ss:Width="100"/>
          <Column ss:Index="13" ss:Width="80"/>
          <Column ss:Index="14" ss:Width="50"/>
          <Column ss:Index="15" ss:Width="80"/>
          <Column ss:Index="16" ss:Width="80"/>
          <Column ss:Index="17" ss:Width="80"/>
          <Column ss:Index="18" ss:Width="80"/>
          <Column ss:Index="19" ss:Width="155"/>
           
          <xsl:apply-templates select="NewDataSet"/>
          <xsl:for-each select="Table">
            <Row>
              <Cell ss:MergeAcross="27" ss:StyleID="s01">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER" />
                </Data>
              </Cell>
            </Row>
            <Row>
              <Cell ss:MergeAcross="27" ss:StyleID="s01">
                <Data ss:Type="String">
                  FILE NAME
                  <xsl:value-of select="RARFILENAME" />
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <xsl:for-each select="//NewDataSet/Table">
            <xsl:variable name="Status" select="STATUS"></xsl:variable>
            <Row ss:AutoFitHeight="0" ss:Height="25.5">
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">RECORD_MVT</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">RECORD_TYPE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">ORDER NO</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">LINE NO</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">STYLE NO</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">MODE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">QTY PCS</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">CARTON</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">VOLUME</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">VOL.CHILD</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">SUPPLIER_NAME</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">BUYING_INCOTERM</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">POL</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">POD</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">LRD INIT</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">LRD UPDATE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">MDD INIT</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">MDD UPDATE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">REMARK</Data>
              </Cell>
            </Row>
            <xsl:for-each select="//NewDataSet/Table1">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="RCDMOVT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="RCDTYPE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORDERNO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="String">
                    <xsl:value-of select="LINE_NO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="STYLENO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="MODE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_3">
                  <Data ss:Type="String">
                    <xsl:value-of select="QTY_PCS"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_3">
                  <Data ss:Type="String">
                    <xsl:value-of select="CARTON"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_3">
                  <Data ss:Type="String">
                    <xsl:value-of select="TOT_VOL"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_3">
                  <Data ss:Type="String">
                    <xsl:value-of select="VOL_CHILD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="SHIPPER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="INCOTERM"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="POL"/>
                  </Data>
                </Cell>

                <Cell ss:StyleID="s24">
                  <Data ss:Type="String">
                    <xsl:value-of select="POD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="LRD_INIT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="LRD_UPDATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="MDD_INIT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="MDD_UPDATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="REMARK"/>
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
          <SplitHorizontal>1</SplitHorizontal>
          <TopRowBottomPane>1</TopRowBottomPane>
          <ActivePane>2</ActivePane>
          <Panes>
            <Pane>
              <Number>3</Number>
            </Pane>
            <Pane>
              <Number>2</Number>
              <ActiveRow>5</ActiveRow>
              <ActiveCol>2</ActiveCol>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>
      </Worksheet>
       
      <!--<Worksheet>
        <xsl:attribute name="ss:Name">PO HEADER</xsl:attribute>
        <Table ss:DefaultColumnWidth="200">
          <Column ss:Index="1" ss:Width="70"/>
          <Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="85"/>
          <Column ss:Index="3" ss:Width="50"/>
          <Column ss:Index="4" ss:Width="65"/>
          <Column ss:Index="5" ss:Width="50"/>
          <Column ss:Index="6" ss:Width="50"/>
          <Column ss:Index="7" ss:Width="50"/>
          <Column ss:Index="8" ss:Width="50"/>
          <Column ss:Index="9" ss:Width="50"/>
          <Column ss:Index="10" ss:Width="50"/>
          <Column ss:Index="11" ss:Width="50"/>
          <Column ss:Index="12" ss:Width="155"/>
          <Column ss:Width="70"/>
          
          <xsl:apply-templates select="NewDataSet"/>
          <xsl:for-each select="Table">
            <Row>
              <Cell ss:MergeAcross="27" ss:StyleID="s01">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER" />
                </Data>
              </Cell>
            </Row>
            <Row>
              <Cell ss:MergeAcross="27" ss:StyleID="s01">
                <Data ss:Type="String">
                  FILE NAME
                  <xsl:value-of select="RARFILENAME" />
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>

          <xsl:for-each select="//NewDataSet/Table">            
            <xsl:variable name="Status" select="STATUS"></xsl:variable>
            <Row ss:AutoFitHeight="0" ss:Height="25.5">
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">RECORD_MVT</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">RECORD_TYPE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">AIE_ORDER_NBR</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">TRANSPORT_MODE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">SUPPLIER_NAME</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">SUPPLIER_PHONE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">BUYING_INCOTERM</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">POL</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">POD</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">CUSTOMER_ORDER_NBR</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">SUPPLIER_ORDER_NBR</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">SELLING_INCOTERM</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">REMARK</Data>
              </Cell>
            </Row>
          
            <xsl:for-each select="//NewDataSet/Table2">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="RECORD_MVT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="RECORD_TYPE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="AIE_ORDER_NBR"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="String">
                    <xsl:value-of select="TRANSPORT_MODE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="SUPPLIER_NAME"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="SUPPLIER_PHONE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="BUYING_INCOTERM"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="POL"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="String">
                    <xsl:value-of select="POD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="CUSTOMER_ORDER_NBR"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="SUPPLIER_ORDER_NBR"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="SELLING_INCOTERM"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="REMARK"/>
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
          <SplitHorizontal>1</SplitHorizontal>
          <TopRowBottomPane>1</TopRowBottomPane>
          <ActivePane>2</ActivePane>
          <Panes>
            <Pane>
              <Number>3</Number>
            </Pane>
            <Pane>
              <Number>2</Number>
              <ActiveRow>5</ActiveRow>
              <ActiveCol>2</ActiveCol>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>
      </Worksheet>
      <Worksheet>
        <xsl:attribute name="ss:Name">FORECASTED SHIPMENT</xsl:attribute>
        <Table ss:DefaultColumnWidth="100">
          <Column ss:Index="1" ss:Width="70"/>
          <Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="70"/>
          <Column ss:Index="3" ss:Width="90"/>

        
          <xsl:for-each select="//NewDataSet/Table">
            <xsl:variable name="Status1" select="STATUS"></xsl:variable>
            <Row ss:AutoFitHeight="0" ss:Height="25.5">
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">RECORD_MVT</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">RECORD_TYPE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">AIE_ORDER_NBR</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">TRANSPORT_MODE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">FORECASTED_SHIPMENT_NBR</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">VOLUME_40HC</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">VOLUME_40</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">VOLUME_20</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">VOLUME_M3</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">LRD_INIT</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">LRD_UPDATED</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">MDD_UPDATED</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">MDD_INIT</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">REMARK</Data>
              </Cell>
            </Row>        
              <xsl:for-each select="//NewDataSet/Table3">
                <Row ss:AutoFitHeight="1">
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="RECORD_MVT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="RECORD_TYPE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="AIE_ORDER_NBR"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="TRANSPORT_MODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="FORECASTED_SHIPMENT_NBR"/>
                    </Data>
                  </Cell>

                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="VOLUME_40HC"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="VOLUME_40"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="VOLUME_20"/>
                    </Data>
                  </Cell>

                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="VOLUME_M3"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="LRD_INIT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="LRD_UPDATED"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="MDD_UPDATED"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="MDD_INIT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="REMARK"/>
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
          <SplitHorizontal>1</SplitHorizontal>
          <TopRowBottomPane>1</TopRowBottomPane>
          <ActivePane>2</ActivePane>
          <Panes>
            <Pane>
              <Number>3</Number>
            </Pane>
            <Pane>
              <Number>2</Number>
              <ActiveRow>5</ActiveRow>
              <ActiveCol>2</ActiveCol>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>
      </Worksheet>
      <Worksheet>
        <xsl:attribute name="ss:Name">PO DETAIL </xsl:attribute>
        <Table ss:DefaultColumnWidth="100">
          <Column ss:Index="1" ss:Width="70"/>
          <Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="70"/>
          <Column ss:Index="3" ss:Width="90"/>
        
          <xsl:for-each select="//NewDataSet/Table">
            <xsl:variable name="Status1" select="STATUS"></xsl:variable>
            <Row ss:AutoFitHeight="0" ss:Height="25.5">
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">RECORD_MVT</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">RECORD_TYPE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">AIE_ORDER_NBR</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">TRANSPORT_MODE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">PO_LINE_NBR</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">CUSTOMER_ITEM_CODE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">QUANTITY_OF_PIECES</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">CARTONS</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">VOLUME_M3</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">FORECASTED_SHIPMENT_NBR</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">AIE_ITEM_CODE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">COLOR</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">SIZE RANGE</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">REMARK</Data>
              </Cell>
            </Row>          
              <xsl:for-each select="//NewDataSet/Table4">
                <Row ss:AutoFitHeight="1">
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="RECORD_MVT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="RECORD_TYPE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="AIE_ORDER_NBR"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="TRANSPORT_MODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="PO_LINE_NBR"/>
                    </Data>
                  </Cell>

                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="CUSTOMER_ITEM_CODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="QUANTITY_OF_PIECES"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="CARTONS"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="VOLUME_M3"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="FORECASTED_SHIPMENT_NBR"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="AIE_ITEM_CODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="COLOR"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="SIZE_RANGE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s25">
                    <Data ss:Type="String">
                      <xsl:value-of select="REMARK"/>
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
          <SplitHorizontal>1</SplitHorizontal>
          <TopRowBottomPane>1</TopRowBottomPane>
          <ActivePane>2</ActivePane>
          <Panes>
            <Pane>
              <Number>3</Number>
            </Pane>
            <Pane>
              <Number>2</Number>
              <ActiveRow>5</ActiveRow>
              <ActiveCol>2</ActiveCol>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>
      </Worksheet>-->
    </Workbook>
  </xsl:template>
</xsl:stylesheet>