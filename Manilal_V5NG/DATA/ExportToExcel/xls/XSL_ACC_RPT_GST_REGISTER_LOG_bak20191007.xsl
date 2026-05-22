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
        <Style ss:ID="s43" ss:Name="Comma">
          <NumberFormat ss:Format="_(* #,##0.00_);_(* \(#,##0.00\);_(* &quot;-&quot;??_);_(@_)"/>
        </Style>
        <Style ss:ID="s62">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
        </Style>
        <Style ss:ID="s63">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="s64">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="Short Date"/>
        </Style>
        <Style ss:ID="s65">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s66">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"/>
          <Interior ss:Color="#F8CBAD" ss:Pattern="Solid"/>
          <Protection/>
        </Style>
        <Style ss:ID="s67">
          <Alignment ss:Horizontal="Right" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"/>
          <Interior ss:Color="#F8CBAD" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="Fixed"/>
          <Protection/>
        </Style>
        <Style ss:ID="s68">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"
           ss:Color="#000000"/>
          <Protection ss:Protected="0"/>
        </Style>
        <Style ss:ID="s69">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Times New Roman" x:Family="Roman" ss:Size="11"
           ss:Color="#000000"/>
          <NumberFormat ss:Format="Fixed"/>
          <Protection ss:Protected="0"/>
        </Style>
        <Style ss:ID="s70">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior ss:Color="#00B0F0" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s71">
          <Borders/>
        </Style>
        <Style ss:ID="s72">
          <Borders/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s73">
          <Borders/>
          <NumberFormat ss:Format="Short Date"/>
        </Style>
        <Style ss:ID="s81">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s82">
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s90">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="10.5" ss:Bold="1"/>
          <Interior ss:Color="#00B0F0" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s91">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="10.5" ss:Bold="1"/>
          <Interior ss:Color="#92D050" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s92">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="10.5" ss:Bold="1"/>
          <Interior ss:Color="#00B0F0" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s93">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="10.5" ss:Bold="1"/>
          <Interior ss:Color="#92D050" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s95">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="10.5" ss:Bold="1"/>
          <Interior ss:Color="#70AD47" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s96" ss:Parent="s43">
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s106">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="10.5" ss:Bold="1"/>
          <Interior ss:Color="#00B0F0" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s107">
          <Alignment ss:Vertical="Top"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s108">
          <Alignment ss:Vertical="Top"/>
          <Borders/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s114">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
        </Style>
        <Style ss:ID="s122">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s131">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s188">
          <Alignment ss:Horizontal="Right" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="10.5" ss:Bold="1"/>
          <Interior ss:Color="#92D050" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
      </Styles>
      <xsl:apply-templates select="NewDataSet"/>
      <!--<xsl:for-each select="Table">
				<xsl:variable name="CONNAME" select="CONNAME"></xsl:variable>-->

      <!--</xsl:for-each>-->
      <xsl:for-each select="//NewDataSet/Table1">
        <xsl:variable name="ORIGIN_ID" select="CITYCODE"></xsl:variable>
        <!-- FOR INVOICE REPORT START HERE-->
        <Worksheet>
          <xsl:attribute name="ss:Name">
            <xsl:value-of select="concat('II ', $ORIGIN_ID)" />
          </xsl:attribute>
          <Table ss:ExpandedColumnCount="19"  x:FullColumns="1"
   x:FullRows="1" ss:StyleID="s71" ss:DefaultRowHeight="15">
            <Column ss:StyleID="s71" ss:Width="97.5"/>
            <Column ss:StyleID="s72" ss:Width="84.75"/>
            <Column ss:StyleID="s71" ss:Width="66.75"/>
            <Column ss:StyleID="s71" ss:Width="268.5"/>
            <Column ss:StyleID="s71" ss:Width="99"/>
            <Column ss:StyleID="s71" ss:Width="75"/>
            <Column ss:StyleID="s71" ss:Width="108"/>
            <Column ss:StyleID="s71" ss:Width="102.75" ss:Span="1"/>
            <Column ss:Index="10" ss:StyleID="s71" ss:Width="61.5"/>
            <Column ss:StyleID="s71" ss:Width="76.5"/>
            <Column ss:StyleID="s71" ss:Width="77.25"/>
            <Column ss:StyleID="s71" ss:Width="101.25"/>
            <Column ss:StyleID="s71" ss:Width="98.25"/>
            <Column ss:StyleID="s71" ss:Width="97.5"/>
            <Column ss:StyleID="s71" ss:Width="96"/>
            <Column ss:StyleID="s71" ss:Width="106.5"/>
            <Column ss:StyleID="s71" ss:Width="105.75"/>
            <Column ss:StyleID="s71" ss:Width="110.25"/>
            <xsl:for-each select="//NewDataSet/Table">
              <Row ss:Height="15.75" ss:StyleID="s114">
                <Cell ss:MergeAcross="18" ss:StyleID="s122">
                  <Data ss:Type="String">
                    <xsl:value-of select="HEADER1"/>
                  </Data>
                </Cell>
              </Row>
              <Row ss:Height="15.75">
                <Cell ss:MergeAcross="18" ss:StyleID="s122">
                  <Data ss:Type="String">
                    <xsl:value-of select="HEADER2"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>
            <Row ss:AutoFitHeight="0" ss:Height="26.25" ss:StyleID="s81">
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">GSTIN OF CUSTOMER</Data>
              </Cell>
              <Cell ss:StyleID="s91">
                <Data ss:Type="String">INVOICE NUMBER</Data>
              </Cell>
              <Cell ss:StyleID="s92">
                <Data ss:Type="String">INVOICE DATE</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">CLIENT_NAME</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">INVOICE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">NON-TAXABLE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">TAXABLE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">TAXABLE VALUE @ 18%</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">TAXABLE VALUE @ 5%</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">PLACE OF SUPPLY</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">BLTOSTCODE</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">BLFROMSTCODE</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">COUNTRY_CODE</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">IGST AMOUNT @ 18%</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">CGST AMOUNT @ 9%</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">SGST AMOUNT @ 9%</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">IGST AMOUNT @ 5%</Data>
              </Cell>
              <Cell ss:StyleID="s95">
                <Data ss:Type="String">CGST AMOUNT @ 2.5%</Data>
              </Cell>
              <Cell ss:StyleID="s95">
                <Data ss:Type="String">SGST AMOUNT @ 2.5%</Data>
              </Cell>
            </Row>
            <Row>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">GSTIN OF CUSTOMER</Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">INVOICE NUMBER</Data>
              </Cell>
              <Cell ss:StyleID="s64">
                <Data ss:Type="String">INVOICE DATE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">CLIENT_NAME</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">INVOICE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">NON-TAXABLE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">TAXABLE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">TAXABLE VALUE @ 18%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">TAXABLE VALUE @ 5%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">PLACE OF SUPPLY</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">BLTOSTCODE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">BLFROMSTCODE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">COUNTRY_CODE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">IGST AMOUNT @ 18%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">CGST AMOUNT @ 9%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">SGST AMOUNT @ 9%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">IGST AMOUNT @ 5%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">CGST AMOUNT @ 2.5%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">SGST AMOUNT @ 2.5%</Data>
              </Cell>
            </Row>
            <xsl:for-each select="//NewDataSet/Table2">
              <xsl:variable name="ORIGIN_II" select="CITYCODE"></xsl:variable>
              <xsl:variable name="TYPE_II" select="TYPE"></xsl:variable>
              <xsl:if test="$ORIGIN_ID = $ORIGIN_II and $TYPE_II='II'">
                <Row ss:AutoFitHeight="1">
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="GSTNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s65">
                    <Data ss:Type="String">
                      <xsl:value-of select="INVOICE_NO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s64">
                    <Data ss:Type="String">
                      <xsl:value-of select="INV_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="CLIENT_NAME"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TOTAL_AMT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TOTAL_NONTAXABLEAMT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXABLE_VALUE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXAMT_18"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXAMT_5"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="PLACE_OF_SUPPLY"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="BLTOSTCODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="BLFROMSTCODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="COUNTRY_CODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="IGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="SGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="IGST_2"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CGST_2"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="SGST_2"/>
                    </Data>
                  </Cell>

                </Row>
              </xsl:if>
            </xsl:for-each>
            <xsl:for-each select="//NewDataSet/Table3">
              <xsl:variable name="ORIGIN_III" select="CITYCODE"></xsl:variable>
              <xsl:variable name="TYPE_III" select="TYPE"></xsl:variable>
              <xsl:if test="$ORIGIN_ID = $ORIGIN_III and $TYPE_III='II'">
                <Row ss:AutoFitHeight="1">
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="GSTNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="INVOICE_NO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="INV_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="CLIENT_NAME"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TOTAL_AMT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TOTAL_NONTAXABLEAMT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXABLE_VALUE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXAMT_18"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXAMT_5"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="PLACE_OF_SUPPLY"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="BLTOSTCODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="BLFROMSTCODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="COUNTRY_CODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="IGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="SGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="IGST_2"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CGST_2"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="SGST_2"/>
                    </Data>
                  </Cell>

                </Row>
              </xsl:if>
            </xsl:for-each>
            <!--</xsl:otherwise>-->
            <!--</xsl:choose>-->

          </Table>
        </Worksheet>
        <!-- FOR INVOICE REPORT END HERE-->

        <Worksheet>
          <xsl:attribute name="ss:Name">
            <xsl:value-of select="concat('CN ', $ORIGIN_ID)" />
          </xsl:attribute>
          <Table ss:ExpandedColumnCount="22"  x:FullColumns="1"
   x:FullRows="1" ss:StyleID="s71" ss:DefaultRowHeight="15">
            <Column ss:StyleID="s71" ss:Width="102.75"/>
            <Column ss:StyleID="s72" ss:Width="87.75"/>
            <Column ss:StyleID="s71" ss:Width="71.25"/>
            <Column ss:StyleID="s71" ss:Width="177.75"/>
            <Column ss:StyleID="s71" ss:Width="105.75"/>
            <Column ss:StyleID="s71" ss:Width="78.75"/>
            <Column ss:StyleID="s71" ss:Width="113.25"/>
            <Column ss:StyleID="s71" ss:Width="107.25"/>
            <Column ss:StyleID="s71" ss:Width="95.25"/>
            <Column ss:StyleID="s71" ss:Width="85.5"/>
            <Column ss:StyleID="s71" ss:Width="80.25"/>
            <Column ss:StyleID="s71" ss:Width="81"/>
            <Column ss:StyleID="s71" ss:Width="105"/>
            <Column ss:StyleID="s71" ss:Width="102.75"/>
            <Column ss:StyleID="s71" ss:Width="102"/>
            <Column ss:StyleID="s71" ss:Width="99.75"/>
            <Column ss:StyleID="s71" ss:Width="111"/>
            <Column ss:StyleID="s71" ss:Width="110.25"/>
            <Column ss:StyleID="s72" ss:Width="102"/>
            <Column ss:StyleID="s108" ss:Width="102"/>
            <Column ss:StyleID="s71" ss:Width="105"/>
            <Column ss:StyleID="s71" ss:AutoFitWidth="0" ss:Width="72.75"/>
            <xsl:for-each select="//NewDataSet/Table">
              <Row ss:Height="15.75">
                <Cell ss:MergeAcross="21" ss:StyleID="s122">
                  <Data ss:Type="String">
                    <xsl:value-of select="HEADER1"/>
                  </Data>
                </Cell>
              </Row>
              <Row ss:Height="15.75">
                <Cell ss:MergeAcross="21" ss:StyleID="s122">
                  <Data ss:Type="String">
                    <xsl:value-of select="HEADER2"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>
            <Row ss:AutoFitHeight="0" ss:Height="28.5" ss:StyleID="s82">
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">GSTIN OF CUSTOMER</Data>
              </Cell>
              <Cell ss:StyleID="s91">
                <Data ss:Type="String">INVOICE NUMBER</Data>
              </Cell>
              <Cell ss:StyleID="s92">
                <Data ss:Type="String">INVOICE DATE</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">CLIENT_NAME</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">INVOICE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">NON-TAXABLE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">TAXABLE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">TAXABLE VALUE @ 18%</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">TAXABLE VALUE @ 5%</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">PLACE OF SUPPLY</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">BLTOSTCODE</Data>
              </Cell>
              <Cell ss:StyleID="s90">
                <Data ss:Type="String">BLFROMSTCODE</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">COUNTRY_CODE</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">IGST AMOUNT @ 18%</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">CGST AMOUNT @ 9%</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">SGST AMOUNT @ 9%</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">IGST AMOUNT @ 5%</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">CGST AMOUNT @ 2.5%</Data>
              </Cell>
              <Cell ss:StyleID="s92">
                <Data ss:Type="String">SGST AMOUNT @ 2.5%</Data>
              </Cell>
              <Cell ss:StyleID="s106">
                <Data ss:Type="String">CORSPOND. INV NO.</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">CORSPOND. INV DATE</Data>
              </Cell>
              <Cell ss:StyleID="s93">
                <Data ss:Type="String">CORSPOND. INV AMT</Data>
              </Cell>
            </Row>
            <Row>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">GSTIN OF CUSTOMER</Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">INVOICE NUMBER</Data>
              </Cell>
              <Cell ss:StyleID="s64">
                <Data ss:Type="String">INVOICE DATE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">CLIENT_NAME</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">INVOICE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">NON-TAXABLE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">TAXABLE VALUE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">TAXABLE VALUE @ 18%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">TAXABLE VALUE @ 5%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">PLACE OF SUPPLY</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">BLTOSTCODE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">BLFROMSTCODE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">COUNTRY_CODE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">IGST AMOUNT @ 18%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">CGST AMOUNT @ 9%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">SGST AMOUNT @ 9%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">IGST AMOUNT @ 5%</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">CGST AMOUNT @ 2.5%</Data>
              </Cell>
              <Cell ss:StyleID="s65">
                <Data ss:Type="String">SGST AMOUNT @ 2.5%</Data>
              </Cell>
              <Cell ss:StyleID="s107">
                <Data ss:Type="String">CORSPOND. INV NO.</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">CORSPOND. INV DATE</Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">CORSPOND. INV AMT</Data>
              </Cell>
            </Row>
            <xsl:for-each select="//NewDataSet/Table2">
              <xsl:variable name="ORIGIN_CN" select="CITYCODE"></xsl:variable>
              <xsl:variable name="TYPE_CN" select="TYPE"></xsl:variable>
              <xsl:if test="$ORIGIN_ID = $ORIGIN_CN and $TYPE_CN='CN'">
                <Row>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="GSTNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s65">
                    <Data ss:Type="String">
                      <xsl:value-of select="INVOICE_NO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s64">
                    <Data ss:Type="String">
                      <xsl:value-of select="INV_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="CLIENT_NAME"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TOTAL_AMT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TOTAL_NONTAXABLEAMT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXABLE_VALUE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXAMT_18"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXAMT_5"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="PLACE_OF_SUPPLY"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="BLTOSTCODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="BLFROMSTCODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="String">
                      <xsl:value-of select="COUNTRY_CODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="IGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="SGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="IGST_2"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CGST_2"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s65">
                    <Data ss:Type="Number">
                      <xsl:value-of select="SGST_2"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s107">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CORSPOND_INV_NO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s64">
                    <Data ss:Type="String">
                      <xsl:value-of select="CORSPOND_INV_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s63">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CORSPOND_INV_AMT"/>
                    </Data>
                  </Cell>
                </Row>
              </xsl:if>
            </xsl:for-each>
            <xsl:for-each select="//NewDataSet/Table3">
              <xsl:variable name="ORIGIN_CNN" select="CITYCODE"></xsl:variable>
              <xsl:variable name="TYPE_CNN" select="TYPE"></xsl:variable>
              <xsl:if test="$ORIGIN_ID = $ORIGIN_CNN and $TYPE_CNN='CN'">
                <Row>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="GSTNO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="INVOICE_NO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="INV_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="CLIENT_NAME"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TOTAL_AMT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TOTAL_NONTAXABLEAMT"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXABLE_VALUE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXAMT_18"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="TAXAMT_5"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="PLACE_OF_SUPPLY"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="BLTOSTCODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="BLFROMSTCODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="COUNTRY_CODE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="IGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="SGST_1"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="IGST_2"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CGST_2"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="SGST_2"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CORSPOND_INV_NO"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s91">
                    <Data ss:Type="String">
                      <xsl:value-of select="CORSPOND_INV_DATE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s188">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CORSPOND_INV_AMT"/>
                    </Data>
                  </Cell>
                </Row>
              </xsl:if>
            </xsl:for-each>
          </Table>
        </Worksheet>

      </xsl:for-each>
      <!--</xsl:for-each>-->

      <Worksheet ss:Name="SAC Codewise">
        <Table ss:ExpandedColumnCount="6"  x:FullColumns="1"
         x:FullRows="1" ss:DefaultColumnWidth="96" ss:DefaultRowHeight="15">
          <Column ss:Width="73.5"/>
          <Column ss:Width="57"/>
          <Column ss:Width="70.5"/>
          <Column ss:Width="71.25"/>
          <Column ss:Width="57.75"/>
          <Column ss:Width="66"/>
          <Row ss:Height="30" ss:StyleID="s62">
            <Cell ss:StyleID="s66">
              <Data ss:Type="String">SAC Code No.</Data>
            </Cell>
            <Cell ss:StyleID="s67">
              <Data ss:Type="String">Total Value</Data>
            </Cell>
            <Cell ss:StyleID="s67">
              <Data ss:Type="String">Taxable Value</Data>
            </Cell>
            <Cell ss:StyleID="s67">
              <Data ss:Type="String">Integrated Tax Amount</Data>
            </Cell>
            <Cell ss:StyleID="s67">
              <Data ss:Type="String">Central Tax Amount</Data>
            </Cell>
            <Cell ss:StyleID="s67">
              <Data ss:Type="String">State/UT Tax Amount</Data>
            </Cell>
          </Row>
          <Row>
            <Cell ss:StyleID="s68"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s68"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s68"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s68"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s68"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
            <Cell ss:StyleID="s69"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
        </Table>
        <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
          <PageSetup>
            <Header x:Margin="0.3"/>
            <Footer x:Margin="0.3"/>
            <PageMargins x:Bottom="0.75" x:Left="0.7" x:Right="0.7" x:Top="0.75"/>
          </PageSetup>
          <TabColorIndex>10</TabColorIndex>
          <Panes>
            <Pane>
              <Number>3</Number>
              <ActiveRow>18</ActiveRow>
              <ActiveCol>8</ActiveCol>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>
      </Worksheet>
      <Worksheet ss:Name="Statistics">
        <Table ss:ExpandedColumnCount="5" x:FullColumns="1"
         x:FullRows="1" ss:DefaultRowHeight="15">
          <Column ss:Width="134.25"/>
          <Column ss:Width="62.25"/>
          <Column ss:Width="49.5"/>
          <Column ss:Width="69.75"/>
          <Column ss:Width="51"/>
          <Row>
            <Cell ss:StyleID="s70">
              <Data ss:Type="String">Nature  of Document</Data>
            </Cell>
            <Cell ss:StyleID="s70">
              <Data ss:Type="String">Sr. No. From</Data>
            </Cell>
            <Cell ss:StyleID="s70">
              <Data ss:Type="String">Sr. No. To</Data>
            </Cell>
            <Cell ss:StyleID="s70">
              <Data ss:Type="String">Total Number</Data>
            </Cell>
            <Cell ss:StyleID="s70">
              <Data ss:Type="String">Cancelled</Data>
            </Cell>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
            <Cell ss:StyleID="s63"/>
          </Row>
        </Table>
        <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
          <PageSetup>
            <Header x:Margin="0.3"/>
            <Footer x:Margin="0.3"/>
            <PageMargins x:Bottom="0.75" x:Left="0.7" x:Right="0.7" x:Top="0.75"/>
          </PageSetup>
          <TabColorIndex>10</TabColorIndex>
          <Panes>
            <Pane>
              <Number>3</Number>
              <ActiveRow>18</ActiveRow>
              <ActiveCol>6</ActiveCol>
            </Pane>
          </Panes>
          <ProtectObjects>False</ProtectObjects>
          <ProtectScenarios>False</ProtectScenarios>
        </WorksheetOptions>
      </Worksheet>


    </Workbook>
  </xsl:template>
</xsl:stylesheet>
