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
        <Style ss:ID="s62" ss:Name="Normal 2 2">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37074260" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Size="30"
           ss:Color="#0000FF" ss:Bold="1"/>
          <Interior ss:Color="#FFFFCC" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37074280" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37074300" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37074320" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37074340" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37074380" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37075828" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Size="30"
           ss:Color="#0000FF" ss:Bold="1"/>
          <Interior ss:Color="#FFFFCC" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37075848" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37075868">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37075888">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37075908">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37075928">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37075948">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37076500" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Size="30"
           ss:Color="#0000FF" ss:Bold="1"/>
          <Interior ss:Color="#FFFFCC" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37076540">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37076560">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37076580">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37076600">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="m37076620" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s63">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s65" ss:Parent="s62">
          <Interior/>
        </Style>
        <Style ss:ID="s74" ss:Parent="s62">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Size="8" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s75" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders/>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Size="30"
           ss:Color="#0000FF" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s76" ss:Parent="s62">
          <Alignment ss:Vertical="Center"/>
          <Borders/>
          <Font ss:FontName="Tahoma" x:CharSet="1" x:Family="Swiss" ss:Size="12"
           ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s77" ss:Parent="s62">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Size="9"
           ss:Color="#FF0000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s78" ss:Parent="s62">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Size="9"
           ss:Color="#339966" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s79" ss:Parent="s62">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Borders/>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Size="9"
           ss:Color="#339966" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s80" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders/>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Size="9"
           ss:Color="#0000FF" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s81" ss:Parent="s62">
          <Alignment ss:Horizontal="Left" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Size="9"
           ss:Color="#339966" ss:Bold="1"/>
          <Interior ss:Color="#FFFF00" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s91" ss:Parent="s62">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2"
             ss:Color="#000000"/>
          </Borders>
          <Font ss:FontName="Arial" x:CharSet="1" x:Family="Swiss" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s101">
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
        <Style ss:ID="s102">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s103">
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
        <Style ss:ID="s105">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s106">
          <Interior/>
        </Style>
        <Style ss:ID="s114">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
        </Style>
        <Style ss:ID="s118">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s119">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Verdana" x:Family="Swiss" ss:Size="8" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
          <NumberFormat/>
          <Protection/>
        </Style>
        <Style ss:ID="s120">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
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
      </Styles>
      <Worksheet>
        <xsl:attribute name="ss:Name">Shipment Approval</xsl:attribute>
        <Table ss:ExpandedColumnCount="33" x:FullColumns="1" x:FullRows="1" ss:DefaultColumnWidth="100.5" ss:DefaultRowHeight="15">
          <Column ss:Width="54.75"/>
          <Column ss:AutoFitWidth="0" ss:Width="75"/>
          <Column ss:Width="50.25" ss:Span="1"/>
          <Column ss:Index="5" ss:Width="70.5"/>
          <Column ss:Width="42.75"/>
          <Column ss:Width="54.75"/>
          <Column ss:Width="61.5"/>
          <Column ss:Width="52.5"/>
          <Column ss:Width="54.75"/>
          <Column ss:Width="75"/>
          <Column ss:AutoFitWidth="0" ss:Width="67.5"/>
          <Column ss:Width="81"/>
          <Column ss:AutoFitWidth="0" ss:Width="62.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="57.75"/>
          <Column ss:Index="18" ss:Width="92.25"/>
          <Column ss:Width="75"/>
          <Column ss:Width="60"/>
          <Column ss:Width="47.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="99.75"/>
          <Column ss:AutoFitWidth="0" ss:Width="70.5"/>
          <Column ss:Width="54.75" ss:Span="1"/>
          <Column ss:Index="26" ss:Width="88.5"/>
          <Column ss:Width="98.25"/>
          <Column ss:Index="29" ss:Width="69.75"/>
          <Column ss:AutoFitWidth="0" ss:Width="78"/>
          <Column ss:AutoFitWidth="0" ss:Width="121.5"/>
          <Column ss:Width="149.25"/>
          <Column ss:Width="101.25"/>
			
			<xsl:apply-templates select="NewDataSet"/>
			<Row ss:AutoFitHeight="0" ss:Height="19.5">
				<xsl:if test="count(//NewDataSet/Table)!=''">
					<xsl:for-each select="//NewDataSet/Table">
						<xsl:variable name="COLHEADER" select="PERIOD"></xsl:variable>
						<Cell ss:MergeAcross="32" ss:StyleID="s63">
							<Data ss:Type="String">
								<xsl:value-of select="$COLHEADER"/>
							</Data>
						</Cell>
					</xsl:for-each>
				</xsl:if>
			</Row>
          
          <Row ss:AutoFitHeight="0" ss:Height="25.5">
            <Cell ss:MergeAcross="27" ss:StyleID="m37074260">
              <Data ss:Type="String">HAPPYCHIC ORDER FOLLOW UP STATUS </Data>
            </Cell>
          </Row>
          
          <Row ss:AutoFitHeight="0" ss:Height="15.75">
            <Cell ss:MergeAcross="11" ss:StyleID="m37074280">
              <Data ss:Type="String"> ORDERS (INFORMATION FROM EDI FILES RAR (INCOMING)) </Data>
            </Cell>
            <Cell ss:MergeAcross="5" ss:StyleID="m37074320">
              <Data ss:Type="String"> BOOKING </Data>
            </Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="m37074340">
              <Data ss:Type="String"> QUALITY CONTROL </Data>
            </Cell>
            <Cell ss:MergeAcross="6" ss:StyleID="s91">
              <Data ss:Type="String"> SHIPMENT And EDI STATUS TO HYC </Data>
            </Cell>
          </Row>

          <xsl:apply-templates select="NewDataSet"/>
          <Row ss:AutoFitHeight="0" ss:Height="25.5">
            
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Client</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Supplier</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Incoterm City</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Order Incoterm</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">DO Transport Mode</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Product Family</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Client Reference</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Art./Color</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Order Qty</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">DATE ORDER To MP</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">MAD(LRD)</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">FDD(MDD)</Data>
            </Cell>
            
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Qty Expected</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Cargo Expected</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Booking Dt</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Booking City</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Approval Date</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Approval By</Data>
            </Cell>
            
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Planned QC</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">QC Date</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Cut-Off Date of QC</Data>
            </Cell>
            
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">JOB NO</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">BKD SENTON</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">OKGL SENTON</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">REMTR SENTON</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">C2 SENTON</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">CARGO RECEIPT</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">BKAUTHORISED ON</Data>
            </Cell>
            
          </Row>
          <xsl:if test="count(Table1/*)>0">
            <xsl:for-each select="Table1">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CLIENT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="SUPPLIER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="INCOT_CITY"/>

                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORD_INCOTERM" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="MODE" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="PROD_FAMILY" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORDERNO" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="STYLENO" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORD_QTY" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="DATE_ORDER" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="LRD" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="FDD" />
                  </Data>
                </Cell>
                
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="QTY_EXPECT" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CARGO_EXPECTED" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="BOOKING_DT" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="BK_CITY" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPTAPPDT" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPTAPPBY" />
                  </Data>
                </Cell>
                
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="QC_PERFORM"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="QC_PERFORMDT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="QC_OKDT"/>
                  </Data>
                </Cell>
                
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="JOBNO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="BKD_SENTON"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="OKGL_SENTON"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="REMTR_SENTON"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="C2_SENTON"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CARGO_RECEIPT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="BKAUTHORISED_ON"/>
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
          <SplitHorizontal>8</SplitHorizontal>
          <TopRowBottomPane>8</TopRowBottomPane>
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
