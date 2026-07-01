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
        <Style ss:ID="m46588372">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s226">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="16" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s01">
          <Font ss:FontName="Verdana" ss:Color="Black" x:Family="Swiss" ss:Size="10" ss:Bold="1"/>
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Interior/>
        </Style>
        <Style ss:ID="s97">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s98">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
          <NumberFormat ss:Format="#,##0"/>
        </Style>
        <Style ss:ID="s99">
          <Alignment ss:Horizontal="Right" ss:Vertical="Center" ss:WrapText="0"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="0"/>
          <NumberFormat ss:Format="0"/>
        </Style>
        <Style ss:ID="s100">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1"/>
          <NumberFormat ss:Format="#,##0.0000"/>
        </Style>
        <Style ss:ID="s102">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Size="11" ss:Bold="1"/>
          <NumberFormat ss:Format="#,##0"/>
        </Style>
        <Style ss:ID="s103">
          <Alignment ss:Horizontal="Right" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="0"/>
          <NumberFormat ss:Format="0.0000"/>
        </Style>
        <Style ss:ID="s104">
          <Alignment ss:Horizontal="Right" ss:Vertical="Center" ss:WrapText="0"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="0" ss:Color="#FF0000"/>
          <NumberFormat ss:Format="0"/>
        </Style>
        <Style ss:ID="s105">
          <Alignment ss:Horizontal="Right" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="0" ss:Color="#FF0000"/>
          <NumberFormat ss:Format="0.0000"/>
        </Style>
        <Style ss:ID="s106">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="0"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="0" ss:Color="#000000"/>
          <NumberFormat ss:Format="0"/>
        </Style>
        <Style ss:ID="s107">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="0"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="0" ss:Color="#FF0000"/>
          <NumberFormat ss:Format="0"/>
        </Style>
        <Style ss:ID="s109">
          <Alignment ss:Horizontal="Right" ss:Vertical="Center" ss:WrapText="0"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1" ss:Color="#000000"/>
          <NumberFormat ss:Format="0"/>
        </Style>
        <Style ss:ID="s108">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center" ss:WrapText="0"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1" ss:Color="#000000"/>
          <NumberFormat ss:Format="0"/>
        </Style>
        <Style ss:ID="s110">
          <Alignment ss:Horizontal="Right" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:Family="Swiss" ss:Bold="1" ss:Color="#000000"/>
          <NumberFormat ss:Format="0.0000"/>
        </Style>
        <Style ss:ID="Default" ss:Name="Normal">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
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
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
      </Styles>
      <Worksheet>
        <xsl:attribute name="ss:Name">Airshipment</xsl:attribute>
        <Table>
          <Column ss:Width="150"/>
          <Column ss:Width="48.75" ss:Span="2"/>
          <Column ss:Index="5" ss:Width="50.25"/>
          <Column ss:Width="48.75" ss:Span="3"/>
          <Column ss:Index="10" ss:Width="50.25"/>
          <Column ss:Width="48.75" ss:Span="3"/>
          <Column ss:Index="15" ss:Width="50.25"/>
          <Column ss:Width="48.75"/>
          <xsl:apply-templates select="NewDataSet"/>
          <xsl:variable name="CNT_HEADER_TOT" select="Table1[1]/CNT_HEADER"></xsl:variable>
          <Row ss:Height="19.5">
            <Cell ss:MergeAcross="{$CNT_HEADER_TOT}" ss:StyleID="s226">
              <Data ss:Type="String">AIR TONNAGE</Data>
            </Cell>
          </Row>
          <xsl:for-each select="Table">
          <Row ss:AutoFitHeight="0">
            <Cell ss:MergeAcross="{$CNT_HEADER_TOT}" ss:StyleID="s01">
              <Data ss:Type="String">
                <xsl:value-of select="HEADER"/>
              </Data>
            </Cell>
          </Row>
          </xsl:for-each>
          <xsl:for-each select="Table1">
            <xsl:variable name="ID" select="CON_CODE"></xsl:variable>
            <xsl:variable name="IS_NO_OF_SHIP" select="ISNUMBEROFSHIPMENTS"></xsl:variable>
            <xsl:variable name="IS_TOT_PKG" select="ISTOTAL_PACKAGES"></xsl:variable>
            <xsl:variable name="IS_GROSS_WGT" select="ISGROSS_WEIGHT_KGS"></xsl:variable>
            <xsl:variable name="IS_CBM" select="ISCBM"></xsl:variable>
            <xsl:variable name="IS_VOLUME" select="ISVOLUME_WEIGHT_KGS"></xsl:variable>
            <xsl:variable name="CNT_HEADER" select="CNT_HEADER"></xsl:variable>
            <xsl:variable name="CNT_SUBHEADER" select="CNT_SUBHEADER"></xsl:variable>
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="{$CNT_HEADER}" ss:StyleID="s97">
                <Data ss:Type="String">
                  <xsl:choose>
                    <xsl:when test="CON_NAME='ZZZZZZZZZZ'">
                      GRAND TOTAL
                    </xsl:when>
                    <xsl:otherwise>
                      <xsl:value-of select="CON_NAME"/>
                    </xsl:otherwise>
                  </xsl:choose>
                </Data>
              </Cell>
            </Row >
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell  ss:StyleID="m46588372">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:MergeAcross="{$CNT_SUBHEADER}" ss:StyleID="s102">
                <Data ss:Type="String">PREPAID</Data>
              </Cell>
              <Cell ss:MergeAcross="{$CNT_SUBHEADER}" ss:StyleID="s102">
                <Data ss:Type="String">COLLECT</Data>
              </Cell>
              <Cell ss:MergeAcross="{$CNT_SUBHEADER}" ss:StyleID="s102">
                <Data ss:Type="String">TOTAL</Data>
              </Cell>
            </Row>

            <Row ss:AutoFitHeight="0" ss:Height="39">
              <Cell  ss:StyleID="m46588372">
                <Data ss:Type="String">Origin</Data>
              </Cell>
              <xsl:if test="$IS_NO_OF_SHIP=1">
                <Cell ss:Index="2" ss:StyleID="s98">
                  <Data ss:Type="String">Number of shipments</Data>
                </Cell>
              </xsl:if>
              <xsl:if test="$IS_TOT_PKG=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">Total Packages</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_GROSS_WGT=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">Gross Weight kgs.</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_CBM=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">CBM</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_VOLUME=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">Volume Weight kgs</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_NO_OF_SHIP=1">
                <Cell ss:StyleID="s98">
                  <Data ss:Type="String">Number of shipments</Data>
                </Cell>
              </xsl:if>
              <xsl:if test="$IS_TOT_PKG=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">Total Packages</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_GROSS_WGT=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">Gross Weight kgs.</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_CBM=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">CBM</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_VOLUME=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">Volume Weight kgs</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_NO_OF_SHIP=1">
                <Cell ss:StyleID="s98">
                  <Data ss:Type="String">Number of shipments</Data>
                </Cell>
              </xsl:if>
              <xsl:if test="$IS_TOT_PKG=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">Total Packages</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_GROSS_WGT=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">Gross Weight kgs.</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_CBM=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">CBM</Data>
              </Cell>
              </xsl:if>
              <xsl:if test="$IS_VOLUME=1">
              <Cell ss:StyleID="s98">
                <Data ss:Type="String">Volume Weight kgs</Data>
              </Cell>
              </xsl:if>
            </Row>
            <xsl:for-each select="//NewDataSet/Table2">
              <xsl:if test="$ID = CON_CODE_DTLS">
                <xsl:choose>
                  <xsl:when test="ISZERO != 'Y'">
                    <Row ss:AutoFitHeight="0" ss:Height="15.75">
                      <xsl:choose>
                        <xsl:when test="ORIGIN='TOTAL - ' or ORIGIN='GRAND TOTAL - '">
                          <Cell ss:StyleID="s108">
                            <Data ss:Type="String">
                              <xsl:value-of select="ORIGIN"/>
                            </Data>
                          </Cell>
                          <xsl:if test="$IS_NO_OF_SHIP=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="PP_NUMSHIPMENTS"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_TOT_PKG=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="PP_NUMPKGS"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_GROSS_WGT=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="PP_WTKG"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_CBM=1">
                            <Cell ss:StyleID="s110">
                              <Data ss:Type="Number">
                                <xsl:value-of select="PP_VOLCBM"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_VOLUME=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="PP_CHBLKG"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_NO_OF_SHIP=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="CC_NUMSHIPMENTS"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_TOT_PKG=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="CC_NUMPKGS"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_GROSS_WGT=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="CC_WTKG"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_CBM=1">
                            <Cell ss:StyleID="s110">
                              <Data ss:Type="Number">
                                <xsl:value-of select="CC_VOLCBM"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_VOLUME=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="CC_CHBLKG"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_NO_OF_SHIP=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="TOT_NUMSHIPMENTS"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_TOT_PKG=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="TOT_NUMPKGS"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_GROSS_WGT=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="TOT_WTKG"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_CBM=1">
                            <Cell ss:StyleID="s110">
                              <Data ss:Type="Number">
                                <xsl:value-of select="TOT_VOLCBM"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_VOLUME=1">
                            <Cell ss:StyleID="s109">
                              <Data ss:Type="Number">
                                <xsl:value-of select="TOT_CHBLKG"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                        </xsl:when>
                        <xsl:otherwise>
                          <Cell ss:StyleID="s106">
                            <Data ss:Type="String">
                              <xsl:value-of select="ORIGIN"/>
                            </Data>
                          </Cell>
                          <xsl:if test="$IS_NO_OF_SHIP=1">
                            <Cell ss:StyleID="s99">
                              <Data ss:Type="Number">
                                <xsl:value-of select="PP_NUMSHIPMENTS"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_TOT_PKG=1">
                          <Cell ss:StyleID="s99">
                            <Data ss:Type="Number">
                              <xsl:value-of select="PP_NUMPKGS"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_GROSS_WGT=1">
                          <Cell ss:StyleID="s99">
                            <Data ss:Type="Number">
                              <xsl:value-of select="PP_WTKG"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_CBM=1">
                          <Cell ss:StyleID="s103">
                            <Data ss:Type="Number">
                              <xsl:value-of select="PP_VOLCBM"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_VOLUME=1">
                          <Cell ss:StyleID="s99">
                            <Data ss:Type="Number">
                              <xsl:value-of select="PP_CHBLKG"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_NO_OF_SHIP=1">
                            <Cell ss:StyleID="s99">
                              <Data ss:Type="Number">
                                <xsl:value-of select="CC_NUMSHIPMENTS"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_TOT_PKG=1">
                          <Cell ss:StyleID="s99">
                            <Data ss:Type="Number">
                              <xsl:value-of select="CC_NUMPKGS"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_GROSS_WGT=1">
                          <Cell ss:StyleID="s99">
                            <Data ss:Type="Number">
                              <xsl:value-of select="CC_WTKG"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_CBM=1">
                          <Cell ss:StyleID="s103">
                            <Data ss:Type="Number">
                              <xsl:value-of select="CC_VOLCBM"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_VOLUME=1">
                          <Cell ss:StyleID="s99">
                            <Data ss:Type="Number">
                              <xsl:value-of select="CC_CHBLKG"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_NO_OF_SHIP=1">
                            <Cell ss:StyleID="s99">
                              <Data ss:Type="Number">
                                <xsl:value-of select="TOT_NUMSHIPMENTS"/>
                              </Data>
                            </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_TOT_PKG=1">
                          <Cell ss:StyleID="s99">
                            <Data ss:Type="Number">
                              <xsl:value-of select="TOT_NUMPKGS"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_GROSS_WGT=1">
                          <Cell ss:StyleID="s99">
                            <Data ss:Type="Number">
                              <xsl:value-of select="TOT_WTKG"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_CBM=1">
                          <Cell ss:StyleID="s103">
                            <Data ss:Type="Number">
                              <xsl:value-of select="TOT_VOLCBM"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                          <xsl:if test="$IS_VOLUME=1">
                          <Cell ss:StyleID="s99">
                            <Data ss:Type="Number">
                              <xsl:value-of select="TOT_CHBLKG"/>
                            </Data>
                          </Cell>
                          </xsl:if>
                        </xsl:otherwise>
                      </xsl:choose>
                    </Row>
                  </xsl:when>
                  <xsl:otherwise>
                    <Row ss:AutoFitHeight="0" ss:Height="15.75">
                      <Cell ss:StyleID="s107">
                        <Data ss:Type="String">
                          <xsl:value-of select="ORIGIN"/>
                        </Data>
                      </Cell>
                      <xsl:if test="$IS_NO_OF_SHIP=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="PP_NUMSHIPMENTS"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_TOT_PKG=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="PP_NUMPKGS"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_GROSS_WGT=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="PP_WTKG"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_CBM=1">
                      <Cell ss:StyleID="s105">
                        <Data ss:Type="Number">
                          <xsl:value-of select="PP_VOLCBM"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_VOLUME=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="PP_CHBLKG"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_NO_OF_SHIP=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="CC_NUMSHIPMENTS"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_TOT_PKG=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="CC_NUMPKGS"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_GROSS_WGT=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="CC_WTKG"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_CBM=1">
                      <Cell ss:StyleID="s105">
                        <Data ss:Type="Number">
                          <xsl:value-of select="CC_VOLCBM"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_VOLUME=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="CC_CHBLKG"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_NO_OF_SHIP=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="TOT_NUMSHIPMENTS"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_TOT_PKG=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="TOT_NUMPKGS"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_GROSS_WGT=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="TOT_WTKG"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_CBM=1">
                      <Cell ss:StyleID="s105">
                        <Data ss:Type="Number">
                          <xsl:value-of select="TOT_VOLCBM"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                      <xsl:if test="$IS_VOLUME=1">
                      <Cell ss:StyleID="s104">
                        <Data ss:Type="Number">
                          <xsl:value-of select="TOT_CHBLKG"/>
                        </Data>
                      </Cell>
                      </xsl:if>
                    </Row>
                  </xsl:otherwise>
                </xsl:choose>
              </xsl:if>
            </xsl:for-each>
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="15">
                <Data ss:Type="String">

                </Data>
              </Cell>
            </Row >
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="15">
                <Data ss:Type="String">

                </Data>
              </Cell>
            </Row >
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="15">
                <Data ss:Type="String">

                </Data>
              </Cell>
            </Row >
          </xsl:for-each >
        </Table>
      </Worksheet>
      <Worksheet>
        <xsl:attribute name="ss:Name">Importer</xsl:attribute>
        <Table>
          <Column ss:Width="57"/>
          <Column ss:Width="60"/>
          <Column ss:Width="50.25"/>
          <Column ss:Width="228"/>
          <Column ss:Width="53.25"/>
          <Column ss:Width="228"/>
          <Row ss:AutoFitHeight="0">
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">CON_CODE</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">CONSIGNEE</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">AGTCODE</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">AGENT_NAME</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">EXP_CODE</Data>
            </Cell>
            <Cell ss:StyleID="s64">
              <Data ss:Type="String">IMPORTER</Data>
            </Cell>
          </Row>
          <xsl:apply-templates select="NewDataSet"/>
          <xsl:for-each select="Table3">
            <Row >
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">
                  <xsl:value-of select="CON_CODE"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">
                  <xsl:value-of select="CONSIGNEE"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">
                  <xsl:value-of select="AGTCODE"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">
                  <xsl:value-of select="AGENT_NAME"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">
                  <xsl:value-of select="EXP_CODE"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s63">
                <Data ss:Type="String">
                  <xsl:value-of select="IMPORTER"/>
                </Data>
              </Cell>
            </Row >
          </xsl:for-each >
        </Table>
      </Worksheet>
    </Workbook>
  </xsl:template>
</xsl:stylesheet>