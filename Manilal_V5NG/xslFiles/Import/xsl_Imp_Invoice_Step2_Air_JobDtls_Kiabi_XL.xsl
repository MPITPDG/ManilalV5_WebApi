<xsl:stylesheet version="1.0"
    xmlns="urn:schemas-microsoft-com:office:spreadsheet"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	xmlns:user="urn:my-scripts"
	xmlns:o="urn:schemas-microsoft-com:office:office"
	xmlns:x="urn:schemas-microsoft-com:office:excel"
	xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet" >

  <xsl:template name="string-replace-all">
    <xsl:param name="text" />
    <xsl:param name="replace" />
    <xsl:param name="by" />
    <xsl:choose>
      <xsl:when test="contains($text, $replace)">
        <xsl:value-of select="substring-before($text,$replace)" />
        <xsl:value-of select="$by" />
        <xsl:call-template name="string-replace-all">
          <xsl:with-param name="text"
          select="substring-after($text,$replace)" />
          <xsl:with-param name="replace" select="$replace" />
          <xsl:with-param name="by" select="$by" />
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$text" />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

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
          <NumberFormat ss:Format="0.00"/>
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
        <xsl:attribute name="ss:Name">Invoice_Job_Details</xsl:attribute>
        <Table ss:DefaultColumnWidth="82.5">
          <Column ss:Index="2" ss:AutoFitWidth="0" ss:Width="156"/>
          <Column ss:Width="223.5"/>
          <Column ss:AutoFitWidth="0" ss:Width="205.5"/>
          <Column ss:AutoFitWidth="0" ss:Width="113.25"/>
          <Column ss:Index="11" ss:AutoFitWidth="0" ss:Width="113.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="122.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="105.75"/>
          <Column ss:Index="20" ss:AutoFitWidth="0" ss:Width="124.5"/>
          <Column ss:Index="23" ss:AutoFitWidth="0" ss:Width="120.75"/>
          <Column ss:Index="26" ss:AutoFitWidth="0" ss:Width="141"/>
          <Column ss:Index="28" ss:AutoFitWidth="0" ss:Width="174"/>
          <xsl:apply-templates select="NewDataSet"/>
          <xsl:for-each select="Table">
            <Row>
              <Cell ss:MergeAcross="27" ss:StyleID="s01">
                <Data ss:Type="String">
                  <xsl:value-of select="HEADER" />
                </Data>
              </Cell>
            </Row>
          </xsl:for-each>
          <xsl:if test="count(Table1/*)>0">
            <Row ss:AutoFitHeight="0" ss:Height="22.5">
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">ORIGIN</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">PO NUMBER</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">SHIPPER</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">MAWB Number</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">HAWB Number</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">MP REF.</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">CTNS</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">GROSS WEIGHT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">VOLUME (CBM)</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">VOLUME (WEIGHT)</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">TAXABLE WEIGHT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">AIR FREIGHT RATE/KG</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">AIR FREIGHT AMT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">FSC RATE/KG</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">FSC AMT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">IRC RATE/KG</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">IRC AMT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">XRAY RATE/KG</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">XRAY AMT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">TOTAL SURCHARGES</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">TOTAL</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">EXCHANGE RATE</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">FREIGHT IN EURO</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">Transport</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">Paletisation</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">FORFAIT DOUANE IMPORT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">TOTAL EURO</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">FRIEGHT + DEST. CHARGES EURO</Data>
              </Cell>
            </Row>
            <xsl:for-each select="Table1">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORIGIN"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:call-template name="string-replace-all">
                      <xsl:with-param name="text" select="PO_NUMBER" />
                      <xsl:with-param name="replace" select="'&lt;br&gt;'" />
                      <xsl:with-param name="by" select="','" />
                    </xsl:call-template>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="SHIPPER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="MAWB_NUMBER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="HAWB_NUMBER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="MP_REF"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="Number">
                    <xsl:value-of select="CTNS"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="Number">
                    <xsl:value-of select="WEIGHT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_3">
                  <Data ss:Type="Number">
                    <xsl:value-of select="VOLUME"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="Number">
                    <xsl:value-of select="CBM"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="Number">
                    <xsl:value-of select="TAXABLE_WEIGHT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="Number">
                    <xsl:value-of select="AIR_FREIGHT_RATE_KG"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="AIR_FREIGHT_AMT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="FSC_RATE_KG"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="FSC_AMT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="IRC_RATE_KG"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="IRC_AMT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="X_RAY_RATE_KG"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="X_RAY_AMT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="TOTAL_SURCHARGES"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="TOTAL_INR"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_4">
                  <Data ss:Type="Number">
                    <xsl:value-of select="EXCHANGE_RATE_KG"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="FREIGHT_IN_EURO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="DELIVERY_RATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="PALETISATION_RATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="T1_RATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="CHARGES_EURO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="FRIEGHT_DEST_CHARGES_EURO"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>
          </xsl:if>
          <xsl:if test="count(Table2/*)>0">
            <Row >
              <Cell ss:MergeAcross="9" ss:StyleID="s01">
                <Data ss:Type="String"></Data>
              </Cell>
            </Row>
            <Row >
              <Cell ss:MergeAcross="9" ss:StyleID="s01">
                <Data ss:Type="String"></Data>
              </Cell>
            </Row>
            <Row ss:AutoFitHeight="0" ss:Height="22.5">
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">ORIGIN</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">PO NUMBER</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">SHIPPER</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">MAWB Number</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">HAWB Number</Data>
              </Cell>
              <Cell ss:StyleID="s1010">
                <Data ss:Type="String">MP REF.</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">CTNS</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">WEIGHT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">VOLUME</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">CBM</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">TAXABLE WEIGHT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">AIR FREIGHT RATE/KG</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">AIR FREIGHT AMT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">FSC RATE/KG</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">FSC AMT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">IRC RATE/KG</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">IRC AMT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">XRAY RATE/KG</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">XRAY AMT</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">TOTAL SURCHARGES</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">TOTAL</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">EXCHANGE RATE</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">FREIGHT IN EURO</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">Transport</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">Paletisation</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">T1</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">TOTAL EURO</Data>
              </Cell>
              <Cell ss:StyleID="s1011">
                <Data ss:Type="String">FRIEGHT + DEST. CHARGES EURO</Data>
              </Cell>
            </Row>
            <xsl:for-each select="Table2">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORIGIN"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:call-template name="string-replace-all">
                      <xsl:with-param name="text" select="PO_NUMBER" />
                      <xsl:with-param name="replace" select="'&lt;br&gt;'" />
                      <xsl:with-param name="by" select="','" />
                    </xsl:call-template>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="SHIPPER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="MAWB_NUMBER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="HAWB_NUMBER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="String">
                    <xsl:value-of select="MP_REF"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="Number">
                    <xsl:value-of select="CTNS"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="Number">
                    <xsl:value-of select="WEIGHT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="Number">
                    <xsl:value-of select="VOLUME"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_3">
                  <Data ss:Type="Number">
                    <xsl:value-of select="CBM"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24">
                  <Data ss:Type="Number">
                    <xsl:value-of select="TAXABLE_WEIGHT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s25">
                  <Data ss:Type="Number">
                    <xsl:value-of select="AIR_FREIGHT_RATE_KG"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="AIR_FREIGHT_AMT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="FSC_RATE_KG"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="FSC_AMT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="IRC_RATE_KG"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="IRC_AMT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="X_RAY_RATE_KG"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="X_RAY_AMT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="TOTAL_SURCHARGES"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="TOTAL_INR"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_4">
                  <Data ss:Type="Number">
                    <xsl:value-of select="EXCHANGE_RATE_KG"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="FREIGHT_IN_EURO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="DELIVERY_RATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="PALETISATION_RATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="T1_RATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="CHARGES_EURO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s24_2">
                  <Data ss:Type="Number">
                    <xsl:value-of select="FRIEGHT_DEST_CHARGES_EURO"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>
          </xsl:if>
        </Table>
        <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
          <Selected/>
          <FreezePanes/>
          <FrozenNoSplit/>
          <SplitHorizontal>6</SplitHorizontal>
          <TopRowBottomPane>6</TopRowBottomPane>
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
    </Workbook>
  </xsl:template>
</xsl:stylesheet>
