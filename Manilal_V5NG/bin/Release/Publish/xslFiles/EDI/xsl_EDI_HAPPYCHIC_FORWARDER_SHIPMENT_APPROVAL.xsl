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
          <Column ss:Width="192.75"/>
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
          <Row ss:AutoFitHeight="0" ss:Height="19.5">
            <Cell ss:MergeAcross="32" ss:StyleID="s63">
              <Data ss:Type="String">MP CARGO </Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="25.5">
            <Cell ss:MergeAcross="32" ss:StyleID="m37074260">
              <Data ss:Type="String">SHIPMENT APPROVAL               </Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:StyleID="s65">
            <Cell ss:StyleID="s74">
              <Data ss:Type="String"> LINE COLOR CODE :</Data>
            </Cell>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:StyleID="s65">
            <Cell ss:StyleID="s77">
              <Data ss:Type="String">Not ok to ship</Data>
            </Cell>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="11.25" ss:StyleID="s65">
            <Cell ss:StyleID="s78">
              <Data ss:Type="String">Ok to ship</Data>
            </Cell>
            <Cell ss:StyleID="s79"/>
            <Cell ss:Index="4" ss:StyleID="s80"/>
            <Cell ss:StyleID="s80"/>
            <Cell ss:StyleID="s80"/>
            <Cell ss:StyleID="s80"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="14.25" ss:StyleID="s65">
            <Cell ss:StyleID="s81">
              <Data ss:Type="String">Schedule ok + waiting QC GL</Data>
            </Cell>
            <Cell ss:StyleID="s79"/>
            <Cell ss:Index="4" ss:StyleID="s80"/>
            <Cell ss:StyleID="s80"/>
            <Cell ss:StyleID="s80"/>
            <Cell ss:StyleID="s80"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
            <Cell ss:StyleID="s76"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75">
            <Cell ss:MergeAcross="10" ss:StyleID="m37074280">
              <Data ss:Type="String"> ORDERS (INFORMATION FROM EDI FILES RAR) </Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37074300">
              <Data ss:Type="String"> BOOKING SUPPLIER PLAN STUFFING </Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37074320">
              <Data ss:Type="String"> BOOKING </Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37074340">
              <Data ss:Type="String"> QUALITY CONTROL </Data>
            </Cell>
            <Cell ss:MergeAcross="6" ss:StyleID="s91">
              <Data ss:Type="String"> SHIPMENT </Data>
            </Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="m37074380">
              <Data ss:Type="String"> ALERT AND APPROVAL HYC </Data>
            </Cell>
          </Row>

          <xsl:apply-templates select="NewDataSet"/>

          <Row ss:AutoFitHeight="0" ss:Height="25.5">
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Supplier</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Client</Data>
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
              <Data ss:Type="String">MAD(LRD)</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">FDD(MDD)</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Quantity espected</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Number of cartons or bars</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Espected  Volume</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Espected Weight</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Cargo received date expected</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Date of booking from supplier</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">OK Approval Date</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Approval user</Data>
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
              <Data ss:Type="String">GL Date</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">ETD</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">ETA</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">EFDD(ECPT MDD)</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">POD</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Carrier</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">Service Type (LCL or FCL)</Data>
            </Cell>
            <Cell ss:StyleID="s101">
              <Data ss:Type="String">BL N°</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Forwarder Alert</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">HYC Transport approval date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Comm to forwarder from Client alert</Data>
            </Cell>
          </Row>
          <xsl:if test="count(Table1/*)>0">
            <xsl:for-each select="Table1">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="SUPPLIER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CLIENT"/>
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
                    <xsl:value-of select="MAD" />
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
                    <xsl:value-of select="NO_OF_CRTNS" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPECT_VOL" />
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPECT_WT" />
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
                    <xsl:value-of select="PLANED_QC"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="DATE_CQE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="DATE_CQR"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="GL_DATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETA"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EFDD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="POD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CARRIER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="SERVICE_TYPE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="BL_NO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="MP_ALERT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="HYC_APPROVALDT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="HYC_ALERT"/>
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
      <Worksheet>
        <xsl:attribute name="ss:Name">Revised not COB</xsl:attribute>
        <Table ss:ExpandedColumnCount="33" x:FullColumns="1" x:FullRows="1" ss:DefaultColumnWidth="100.5" ss:DefaultRowHeight="15">
          <Column ss:Width="43.5"/>
          <Column ss:Width="50.25" ss:Span="1"/>
          <Column ss:Index="4" ss:Width="70.5"/>
          <Column ss:Width="192.75"/>
          <Column ss:Width="42.75"/>
          <Column ss:Width="69.75" ss:Span="1"/>
          <Column ss:Index="9" ss:Width="54.75" ss:Span="1"/>
          <Column ss:Index="11" ss:Width="75"/>
          <Column ss:Width="50.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="85.5"/>
          <Column ss:Width="49.5" ss:Span="1"/>
          <Column ss:Index="16" ss:Width="81"/>
          <Column ss:Width="64.5"/>
          <Column ss:Width="92.25"/>
          <Column ss:Width="75"/>
          <Column ss:Width="60"/>
          <Column ss:Width="47.25"/>
          <Column ss:Width="65.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="49.5"/>
          <Column ss:Width="54.75" ss:Span="2"/>
          <Column ss:Index="27" ss:Width="98.25"/>
          <Column ss:Index="29" ss:Width="69.75"/>
          <Column ss:Width="42"/>
          <Column ss:Width="104.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="150"/>
          <Column ss:Width="101.25"/>

          <Row ss:AutoFitHeight="0">
            <Cell ss:MergeAcross="32" ss:StyleID="s63">
              <Data ss:Type="String">MP CARGO</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="37.5">
            <Cell ss:MergeAcross="32" ss:StyleID="m37075828">
              <Data ss:Type="String">EFDD INFOS</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="11.25" ss:StyleID="s106">
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
          </Row>
          <Row ss:AutoFitHeight="0">
            <Cell ss:MergeAcross="10" ss:StyleID="m37075848">
              <Data ss:Type="String"> ORDERS </Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37075868">
              <Data ss:Type="String"> PLAN STUFFING </Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37075888">
              <Data ss:Type="String"> BOOKING </Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37075908">
              <Data ss:Type="String"> QUALITY CONTROL </Data>
            </Cell>
            <Cell ss:MergeAcross="6" ss:StyleID="m37075928">
              <Data ss:Type="String"> SHIPMENT </Data>
            </Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="m37075948">
              <Data ss:Type="String"> ALERT AND REMARK </Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="25.5" ss:StyleID="s114">
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Client</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Incoterm City</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Order Incoterm</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">DO Transport Mode</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Supplier</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Product Family</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Client Reference</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Art./Color</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Order Qty</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">MAD</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">FDD</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Received Quantity</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Number of cartons or bars</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Received Volume</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Received Weight</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Espected cargo receipt</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Real cargo receipt date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">OK Approval Date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Approval user </Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Planned QC</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">QC Date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Cut-Off Date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">GL Date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">ETD</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">ETA</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">EFDD</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">POD</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Carrier</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Service Type (LCL or FCL)</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">BL N°</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Forwarder Alert</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">HYC Transport approval date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Comm to forwarder from Client alert</Data>
            </Cell>
          </Row>
          <xsl:if test="count(Table2/*)>0">
            <xsl:for-each select="Table2">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="SUPPLIER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CLIENT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="BOOKING_CITY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORD_INCOTERM"/>
                  </Data>
                </Cell>

                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="MODE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="PROD_FAMILY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORDERNO"/>
                  </Data>
                </Cell>

                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="STYLENO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORD_QTY"/>
                  </Data>
                </Cell>

                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="MAD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="FDD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="QTY_EXPECT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="NO_OF_CRTNS"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPECT_VOL"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPECT_WT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CARGO_EXPECTED"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CARGO_RECEIPT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPTAPPDT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPTAPPBY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="PLANED_QC"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="DATE_CQE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="DATE_CQR"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="GL_DATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETA"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EFDD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="POD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CARRIER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="SERVICE_TYPE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="BL_NO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="MP_ALERT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="HYC_APPROVALDT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="HYC_ALERT"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>
          </xsl:if>
        </Table>
      </Worksheet>
      <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
        <Selected/>
        <FreezePanes/>
        <FrozenNoSplit/>
        <SplitHorizontal>5</SplitHorizontal>
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
      <Worksheet>
        <xsl:attribute name="ss:Name">Approved not COB</xsl:attribute>
        <Table ss:ExpandedColumnCount="33" x:FullColumns="1" x:FullRows="1" ss:DefaultColumnWidth="100.5" ss:DefaultRowHeight="15">
          <Column ss:Width="43.5"/>
          <Column ss:Width="50.25" ss:Span="1"/>
          <Column ss:Index="4" ss:Width="70.5"/>
          <Column ss:Width="192.75"/>
          <Column ss:Width="42.75"/>
          <Column ss:Width="69.75" ss:Span="1"/>
          <Column ss:Index="9" ss:Width="54.75" ss:Span="1"/>
          <Column ss:Index="11" ss:Width="75"/>
          <Column ss:Width="50.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="85.5"/>
          <Column ss:Width="49.5" ss:Span="1"/>
          <Column ss:Index="16" ss:Width="81"/>
          <Column ss:Width="64.5"/>
          <Column ss:Width="92.25"/>
          <Column ss:Width="75"/>
          <Column ss:Width="60"/>
          <Column ss:Width="47.25"/>
          <Column ss:Width="65.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="49.5"/>
          <Column ss:Width="54.75" ss:Span="2"/>
          <Column ss:Index="27" ss:Width="98.25"/>
          <Column ss:Index="29" ss:Width="69.75"/>
          <Column ss:Width="42"/>
          <Column ss:Width="104.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="150"/>
          <Column ss:Width="101.25"/>
          <Row ss:AutoFitHeight="0">
            <Cell ss:MergeAcross="32" ss:StyleID="s63">
              <Data ss:Type="String">MP CARGO</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="37.5">
            <Cell ss:MergeAcross="32" ss:StyleID="m37075828">
              <Data ss:Type="String">APPROVED</Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="11.25" ss:StyleID="s106">
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
          </Row>
          <Row ss:AutoFitHeight="0">
            <Cell ss:MergeAcross="10" ss:StyleID="m37075848">
              <Data ss:Type="String"> ORDERS </Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37075868">
              <Data ss:Type="String"> PLAN STUFFING </Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37075888">
              <Data ss:Type="String"> BOOKING </Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37075908">
              <Data ss:Type="String"> QUALITY CONTROL </Data>
            </Cell>
            <Cell ss:MergeAcross="6" ss:StyleID="m37075928">
              <Data ss:Type="String"> SHIPMENT </Data>
            </Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="m37075948">
              <Data ss:Type="String"> ALERT AND REMARK </Data>
            </Cell>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="25.5" ss:StyleID="s114">
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Client</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Incoterm City</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Order Incoterm</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">DO Transport Mode</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Supplier</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Product Family</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Client Reference</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Art./Color</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Order Qty</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">MAD</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">FDD</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Received Quantity</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Number of cartons or bars</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Received Volume</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Received Weight</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Espected cargo receipt</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Real cargo receipt date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">OK Approval Date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Approval user </Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Planned QC</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">QC Date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Cut-Off Date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">GL Date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">ETD</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">ETA</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">EFDD</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">POD</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Carrier</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Service Type (LCL or FCL)</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">BL N°</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Forwarder Alert</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">HYC Transport approval date</Data>
            </Cell>
            <Cell ss:StyleID="s102">
              <Data ss:Type="String">Comm to forwarder from Client alert</Data>
            </Cell>
          </Row>
          <xsl:if test="count(Table3/*)>0">
            <xsl:for-each select="Table3">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CLIENT"/>
                  </Data>
                </Cell>

                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="BOOKING_CITY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORD_INCOTERM"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="MODE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="SUPPLIER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="PROD_FAMILY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORDERNO"/>
                  </Data>
                </Cell>

                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="STYLENO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORD_QTY"/>
                  </Data>
                </Cell>

                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="MAD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="FDD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="QTY_EXPECT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="NO_OF_CRTNS"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPECT_VOL"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPECT_WT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CARGO_EXPECTED"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CARGO_RECEIPT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPTAPPDT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPTAPPBY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="PLANED_QC"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="DATE_CQE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="DATE_CQR"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="GL_DATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETA"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EFDD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="POD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CARRIER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="SERVICE_TYPE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="BL_NO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="MP_ALERT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="HYC_APPROVALDT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="HYC_ALERT"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>
          </xsl:if>
        </Table>
      </Worksheet>
      <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
        <Selected/>
        <FreezePanes/>
        <FrozenNoSplit/>
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
      <Worksheet>
        <xsl:attribute name="ss:Name">Volume not stuffed</xsl:attribute>
        <Table ss:ExpandedColumnCount="33" x:FullColumns="1" x:FullRows="1" ss:DefaultColumnWidth="100.5" ss:DefaultRowHeight="15">
          <Column ss:AutoFitWidth="0" ss:Width="51.75"/>
          <Column ss:Width="54.75" ss:Span="2"/>
          <Column ss:Index="5" ss:Width="50.25" ss:Span="1"/>
          <Column ss:Index="7" ss:Width="69.75"/>
          <Column ss:Width="192.75"/>
          <Column ss:Width="54.75" ss:Span="1"/>
          <Column ss:Index="11" ss:Width="75"/>
          <Column ss:Width="50.25"/>
          <Column ss:Width="69.75"/>
          <Column ss:Width="54.75"/>
          <Column ss:Width="65.25"/>
          <Column ss:Width="54.75"/>
          <Column ss:Width="60"/>
          <Column ss:Width="43.5"/>
          <Column ss:Width="65.25"/>
          <Column ss:Width="47.25"/>
          <Column ss:AutoFitWidth="0" ss:Width="101.25"/>
          <Column ss:Width="49.5"/>
          <Column ss:AutoFitWidth="0" ss:Width="57.75"/>
          <Row ss:AutoFitHeight="0">
            <Cell ss:MergeAcross="22" ss:StyleID="s63">
              <Data ss:Type="String">MP CARGO</Data>
            </Cell>
            <Cell ss:StyleID="s63"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="37.5">
            <Cell ss:MergeAcross="22" ss:StyleID="m37076500">
              <Data ss:Type="String">VOLUME NOT STUFFED (approved or not)</Data>
            </Cell>
            <Cell ss:MergeAcross="9" ss:StyleID="s75"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="14.25" ss:StyleID="s106">
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
            <Cell ss:StyleID="s75"/>
          </Row>
          <Row ss:AutoFitHeight="0" ss:Height="15.75">
            <Cell ss:MergeAcross="3" ss:StyleID="m37076540">
              <Data ss:Type="String">Shipment</Data>
            </Cell>
            <Cell ss:MergeAcross="7" ss:StyleID="m37076560">
              <Data ss:Type="String">ORDERS</Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37076580">
              <Data ss:Type="String">BOOKING</Data>
            </Cell>
            <Cell ss:MergeAcross="3" ss:StyleID="m37076600">
              <Data ss:Type="String">QUALITY CONTROL</Data>
            </Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="m37076620">
              <Data ss:Type="String">PLAN STUFFING</Data>
            </Cell>
            <Cell ss:StyleID="s118"/>
            <Cell ss:StyleID="s118"/>
            <Cell ss:StyleID="s118"/>
            <Cell ss:StyleID="s118"/>
          </Row>

          <Row ss:AutoFitHeight="0" ss:Height="25.5">
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">Client</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">ETD</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">ETA</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">EFDD </Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">Incoterm City</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">Order Incoterm</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">DO Transport Mode</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">Supplier</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">Product Family</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">Client Reference</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">UDD</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">FDD</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">UDD Supplier</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">Receiving Date</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">OK Approval Date</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">DLA Alert</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">Planned QC</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">QC Date</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">Cut-Off Date</Data>
            </Cell>
            <Cell ss:StyleID="s119">
              <Data ss:Type="String">GL Date</Data>
            </Cell>
            <Cell ss:StyleID="s120">
              <Data ss:Type="String">Expected volume not received</Data>
            </Cell>
            <Cell ss:StyleID="s120">
              <Data ss:Type="String">Volume Received</Data>
            </Cell>
            <Cell ss:StyleID="s120">
              <Data ss:Type="String"> Total</Data>
            </Cell>
          </Row>
          <xsl:if test="count(Table4/*)>0">
            <xsl:for-each select="Table4">
              <Row ss:AutoFitHeight="1">
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="CLIENT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETA"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EFDD"/>
                  </Data>
                </Cell>

                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="BOOKING_CITY"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORD_INCOTERM"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="MODE"/>
                  </Data>
                </Cell>

                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="SUPPLIER"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="PROD_FAMILY"/>
                  </Data>
                </Cell>

                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORDERNO"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="UDD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="FDD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="UDD_SUPPLIER"/>
                  </Data>
                </Cell>
				  <Cell ss:StyleID="s103">
					  <Data ss:Type="String">
						  <xsl:value-of select="CARGO_RECEIPT"/>
					  </Data>
				  </Cell>
				  
				  <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPTAPPDT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="DLA_ALERT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="PLANED_QC"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="DATE_CQE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="DATE_CQR"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="GL_DATE"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="EXPECT_VOL"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="VOL_RECVD"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s103">
                  <Data ss:Type="String">
                    <xsl:value-of select="TOTAL"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>
          </xsl:if>
        </Table>
      </Worksheet>
      <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
        <Selected/>
        <FreezePanes/>
        <FrozenNoSplit/>
        <SplitHorizontal>5</SplitHorizontal>
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
    </Workbook>
      <!--<WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
        <Selected/>
        <FreezePanes/>
        <FrozenNoSplit/>
        <SplitHorizontal>22</SplitHorizontal>
        <TopRowBottomPane>22</TopRowBottomPane>
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
    </Workbook>-->
  </xsl:template>
</xsl:stylesheet>
