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
                <Style ss:ID="s16" ss:Name="Comma">
                    <NumberFormat ss:Format="_(* #,##0.00_);_(* \(#,##0.00\);_(* &quot;-&quot;??_);_(@_)"/>
                </Style>
                <Style ss:ID="m228745324">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="m228745720">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                    <NumberFormat ss:Format="mmm\-yy"/>
                </Style>
                <Style ss:ID="m228745740">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s63">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s65">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s66">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                    <NumberFormat ss:Format="mmm\-yy"/>
                </Style>
                <Style ss:ID="s67">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Bold="1"/>
                    <Interior/>
                </Style>
                <Style ss:ID="s69" ss:Parent="s16">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
                </Style>
                <Style ss:ID="s70" ss:Parent="s16">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Bold="1"/>
                    <Interior/>
                </Style>
                <Style ss:ID="s77" ss:Parent="s16">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s78">
                    <NumberFormat ss:Format="mmm\-yy"/>
                </Style>
                <Style ss:ID="s80">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Top" ss:WrapText="1"/>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s81">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Top" ss:WrapText="1"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s82">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s83">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                    <NumberFormat ss:Format="mmm\-yy"/>
                </Style>
                <Style ss:ID="s84">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#538DD5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s85">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                </Style>
                <Style ss:ID="s86" ss:Parent="s16">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
                     ss:Bold="1"/>
                </Style>
                <Style ss:ID="s96" ss:Parent="s16">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11"/>
                    <Interior/>
                </Style>
                <Style ss:ID="s97">
                    <NumberFormat ss:Format="_(* #,##0.00_);_(* \(#,##0.00\);_(* &quot;-&quot;??_);_(@_)"/>
                </Style>
                <Style ss:ID="s119">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
                    <Interior/>
                </Style>

            </Styles>

            <xsl:for-each select="//NewDataSet/Table">
                <xsl:variable name="CNTR_OUT" select="CNT"></xsl:variable>
                <xsl:variable name="S_TYPE" select="S_TYPE"></xsl:variable>

                <xsl:if test="$S_TYPE= 'SUMMARY'">
                    <Worksheet ss:Name="TURNOVER SUMMARY">
                        <Table>
                            <Column ss:Width="66"/>
                            <Column ss:Width="57"/>
                            <Column ss:Width="60.75" ss:Span="11"/>
                            <Column ss:Index="15" ss:Width="69.75"/>

                            <Row ss:AutoFitHeight="0">
                                <Cell ss:MergeAcross="14" ss:StyleID="s63">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="HEADER" />
                                    </Data>
                                </Cell>
                            </Row>
                            <Row ss:AutoFitHeight="0">
                                <Cell ss:StyleID="s65">
                                    <Data ss:Type="String">ORIGIN</Data>
                                </Cell>
                                <Cell ss:StyleID="s65">
                                    <Data ss:Type="String">TRANS TYPE</Data>
                                </Cell>
                                <xsl:for-each select="//NewDataSet/Table1">
                                    <Cell ss:StyleID="s65">
                                        <Data ss:Type="String">
                                            <xsl:value-of select="COLNAME" />
                                        </Data>
                                    </Cell>
                                </xsl:for-each>
                                <Cell ss:StyleID="s65">
                                    <Data ss:Type="String">TOTAL</Data>
                                </Cell>
                            </Row>

                            <xsl:for-each select="//NewDataSet/Table2">
                                <Row>
                                    <Cell ss:StyleID="s67">
                                        <Data ss:Type="String">
                                            <xsl:value-of select="ORIGIN"/>
                                        </Data>
                                    </Cell>
                                    <Cell ss:StyleID="s67">
                                        <Data ss:Type="String">
                                            <xsl:value-of select="CLIENT"/>
                                        </Data>
                                    </Cell>
                                    <xsl:if test="'1'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_1" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'2'&lt; $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_2" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'3'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_3" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>

                                    <xsl:if test="'4'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_4" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'5'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_5" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'6'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_6" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>

                                    <xsl:if test="'7'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_7" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'8'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_8" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'9'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_9" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'10'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_10" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'11'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_11" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'12'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_12" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <Cell ss:StyleID="s119">
                                        <Data ss:Type="Number">
                                            <xsl:value-of select="TOTAL" />
                                        </Data>
                                    </Cell>
                                </Row>
                            </xsl:for-each>

                            <xsl:for-each select="//NewDataSet/Table3">
                                <xsl:variable name="CNTR_OUT_PRV" select="CNT"></xsl:variable>
                                <Row ss:Index="10">
                                    <Cell ss:MergeAcross="14" ss:StyleID="s63">
                                        <Data ss:Type="String">
                                            <xsl:value-of select="HEADER" />
                                        </Data>
                                    </Cell>
                                </Row>
                                <Row ss:AutoFitHeight="0">
                                    <Cell ss:StyleID="s65">
                                        <Data ss:Type="String">ORIGIN</Data>
                                    </Cell>
                                    <Cell ss:StyleID="s65">
                                        <Data ss:Type="String">TRANS TYPE</Data>
                                    </Cell>
                                    <xsl:for-each select="//NewDataSet/Table4">
                                        <Cell ss:StyleID="s65">
                                            <Data ss:Type="String">
                                                <xsl:value-of select="COLNAME" />
                                            </Data>
                                        </Cell>
                                    </xsl:for-each>
                                    <Cell ss:StyleID="s65">
                                        <Data ss:Type="String">TOTAL</Data>
                                    </Cell>
                                </Row>
                                <xsl:for-each select="//NewDataSet/Table5">
                                    <Row>
                                        <Cell ss:StyleID="s67">
                                            <Data ss:Type="String">
                                                <xsl:value-of select="ORIGIN"/>
                                            </Data>
                                        </Cell>
                                        <Cell ss:StyleID="s67">
                                            <Data ss:Type="String">
                                                <xsl:value-of select="CLIENT"/>
                                            </Data>
                                        </Cell>
                                        <xsl:if test="'1'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_1" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'2'&lt; $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_2" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'3'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_3" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'4'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_4" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'5'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_5" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'6'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_6" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'7'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_7" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'8'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_8" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'9'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_9" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'10'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_10" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'11'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_11" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'12'&lt;= $CNTR_OUT_PRV">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_12" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="TOTAL" />
                                            </Data>
                                        </Cell>
                                    </Row>
                                </xsl:for-each>
                            </xsl:for-each>

                        </Table>

                    </Worksheet>
                    <Worksheet ss:Name="ORIGIN TURNOVER SUMMARY">
                        <xsl:for-each select="//NewDataSet/Table6">
                            <xsl:variable name="CNTR_OUT1" select="CNT"></xsl:variable>
                            <Table >
                                <Column ss:Width="66"/>
                                <Column ss:Width="57"/>
                                <Column ss:Width="60.75" ss:Span="11"/>
                                <Column ss:Index="15" ss:Width="69.75"/>

                                <Row ss:AutoFitHeight="0">
                                    <Cell ss:MergeAcross="13" ss:StyleID="s63">
                                        <Data ss:Type="String">
                                            <xsl:value-of select="HEADER" />

                                        </Data>
                                    </Cell>
                                </Row>

                                <Row ss:AutoFitHeight="0">
                                    <Cell ss:StyleID="s65">
                                        <Data ss:Type="String">ORIGIN</Data>
                                    </Cell>

                                    <xsl:for-each select="//NewDataSet/Table7">
                                        <Cell ss:StyleID="s65">
                                            <Data ss:Type="String">
                                                <xsl:value-of select="COLNAME" />
                                            </Data>
                                        </Cell>
                                    </xsl:for-each>
                                    <Cell ss:StyleID="s65">
                                        <Data ss:Type="String">TOTAL</Data>
                                    </Cell>

                                </Row>

                                <xsl:for-each select="//NewDataSet/Table8">
                                    <Row>
                                        <Cell ss:StyleID="s67">
                                            <Data ss:Type="String">
                                                <xsl:value-of select="ORIGIN"/>
                                            </Data>
                                        </Cell>

                                        <xsl:if test="'1'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_1" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'2'&lt; $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_2" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'3'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_3" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'4'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_4" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'5'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_5" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'6'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_6" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'7'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_7" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'8'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_8" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'9'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_9" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'10'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_10" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'11'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_11" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'12'&lt;= $CNTR_OUT1">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_12" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="TOTAL"/>
                                            </Data>
                                        </Cell>
                                    </Row>
                                </xsl:for-each>
                            </Table>
                        </xsl:for-each>

                    </Worksheet>
                    <Worksheet ss:Name="CLIENT TURNOVER SUMMARY">
                        <xsl:for-each select="//NewDataSet/Table9">
                            <xsl:variable name="CNTR_OUT2" select="CNT"></xsl:variable>
                            <Table>
                                <Column ss:Width="66"/>
                                <Column ss:Width="57"/>
                                <Column ss:Width="60.75" ss:Span="11"/>
                                <Column ss:Index="15" ss:Width="69.75"/>

                                <Row ss:AutoFitHeight="0">
                                    <Cell ss:MergeAcross="13" ss:StyleID="s63">
                                        <Data ss:Type="String">
                                            <xsl:value-of select="HEADER" />
                                        </Data>
                                    </Cell>
                                </Row>

                                <Row ss:AutoFitHeight="0">
                                    <Cell ss:StyleID="s65">
                                        <Data ss:Type="String">CLIENT</Data>
                                    </Cell>

                                    <xsl:for-each select="//NewDataSet/Table10">
                                        <Cell ss:StyleID="s65">
                                            <Data ss:Type="String">
                                                <xsl:value-of select="COLNAME" />
                                            </Data>
                                        </Cell>
                                    </xsl:for-each>
                                    <Cell ss:StyleID="s65">
                                        <Data ss:Type="String">TOTAL</Data>
                                    </Cell>

                                </Row>

                                <xsl:for-each select="//NewDataSet/Table11">
                                    <Row>

                                        <Cell ss:StyleID="s67">
                                            <Data ss:Type="String">
                                                <xsl:value-of select="CLIENT"/>
                                            </Data>
                                        </Cell>
                                        <xsl:if test="'1'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_1" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'2'&lt; $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_2" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <xsl:if test="'3'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="String">
                                                    <xsl:value-of select="H_3" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'4'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_4" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'5'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_5" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>


                                        <xsl:if test="'6'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_6" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'7'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_7" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'8'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_8" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'9'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_9" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'10'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_10" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'11'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_11" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>

                                        <xsl:if test="'12'&lt;= $CNTR_OUT2">
                                            <Cell ss:StyleID="s119">
                                                <Data ss:Type="Number">
                                                    <xsl:value-of select="H_12" />
                                                </Data>
                                            </Cell>
                                        </xsl:if>
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="TOTAL"/>
                                            </Data>
                                        </Cell>
                                    </Row>
                                </xsl:for-each>
                            </Table>
                        </xsl:for-each>

                    </Worksheet>
                </xsl:if>
            </xsl:for-each>

            <xsl:for-each select="//NewDataSet/Table">
                <xsl:variable name="CNTR_OUT" select="CNT"></xsl:variable>

                <xsl:variable name="S_TYPE" select="S_TYPE"></xsl:variable>

                <xsl:if test="$S_TYPE= 'CLIENT'">

                    <Worksheet ss:Name="CLIENT TURNOVER SUMMARY">
                        <Table>
                            <Column ss:Width="66"/>
                            <Column ss:Width="57"/>
                            <Column ss:Width="60.75" ss:Span="11"/>
                            <Column ss:Index="15" ss:Width="69.75"/>

                            <Row ss:AutoFitHeight="0">
                                <Cell ss:MergeAcross="14" ss:StyleID="s63">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="HEADER" />

                                    </Data>
                                </Cell>
                            </Row>

                            <Row ss:AutoFitHeight="0">
                                <Cell ss:StyleID="s65">
                                    <Data ss:Type="String">CLIENT</Data>
                                </Cell>
                                <Cell ss:StyleID="s65">
                                    <Data ss:Type="String">ORIGIN</Data>
                                </Cell>

                                <xsl:for-each select="//NewDataSet/Table1">
                                    <Cell ss:StyleID="s65">
                                        <Data ss:Type="String">
                                            <xsl:value-of select="COLNAME" />
                                        </Data>
                                    </Cell>
                                </xsl:for-each>
                                <Cell ss:StyleID="s65">
                                    <Data ss:Type="String">TOTAL</Data>
                                </Cell>

                            </Row>

                            <xsl:for-each select="//NewDataSet/Table2">
                                <Row>
                                    <Cell ss:StyleID="s67">
                                        <Data ss:Type="String">
                                            <xsl:value-of select="CLIENT"/>
                                        </Data>
                                    </Cell>
                                    <Cell ss:StyleID="s67">
                                        <Data ss:Type="String">
                                            <xsl:value-of select="ORIGIN"/>
                                        </Data>
                                    </Cell>

                                    <xsl:if test="'1'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_1" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'2'&lt; $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_2" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'3'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_3" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>

                                    <xsl:if test="'4'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_4" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'5'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_5" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'6'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_6" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>

                                    <xsl:if test="'7'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s69">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_7" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'8'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_8" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'9'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_9" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'10'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_10" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'11'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_11" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <xsl:if test="'12'&lt;= $CNTR_OUT">
                                        <Cell ss:StyleID="s119">
                                            <Data ss:Type="Number">
                                                <xsl:value-of select="H_12" />
                                            </Data>
                                        </Cell>
                                    </xsl:if>
                                    <Cell ss:StyleID="s119">
                                        <Data ss:Type="Number">
                                            <xsl:value-of select="TOTAL"/>
                                        </Data>
                                    </Cell>
                                </Row>
                            </xsl:for-each>
                        </Table>
                    </Worksheet>
                </xsl:if>
            </xsl:for-each>

        </Workbook>
    </xsl:template>
</xsl:stylesheet>
