<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
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
        <Style ss:ID="s18" ss:Name="Currency">
          <NumberFormat
           ss:Format="_ &quot;₹&quot;\ * #,##0.00_ ;_ &quot;₹&quot;\ * \-#,##0.00_ ;_ &quot;₹&quot;\ * &quot;-&quot;??_ ;_ @_ "/>
        </Style>
        <Style ss:ID="m2142900963748">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2142900963808">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2142719795744" ss:Parent="s18">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142900913848">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2142900913868" ss:Parent="s18">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142900913888" ss:Parent="s18">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142900913908" ss:Parent="s18">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890308616">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890302168">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890302228">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890315480">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890315540">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890315064">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890315124">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890316688">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2142890316708">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2142890316768">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890316828">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890316272">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2142890316292">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890316312">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890316332">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890316372">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890316064">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2142890316084">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="m2142890316104">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890316124">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2142890316164" ss:Parent="s18">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s123">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="0"/>
        </Style>
        <Style ss:ID="s124">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="0.000"/>
        </Style>

        <Style ss:ID="s70">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s72">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s77">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s78">
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s93">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#4472C4" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s94">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#4472C4" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s116">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>

        <Style ss:ID="s120">
          <Alignment ss:Vertical="Top"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s121">
          <Alignment ss:Vertical="Top"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s122">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
        </Style>

        <Style ss:ID="s125">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s127">
          <Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s129">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s140">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s142">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s143">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
        </Style>
        <Style ss:ID="s144">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Interior/>
        </Style>
        <Style ss:ID="s145" ss:Parent="s18">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s146" ss:Parent="s18">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s148" ss:Parent="s18">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>

        <Style ss:ID="s515">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s516">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s517" ss:Parent="s18">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s519">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s575">
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s576">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s618">
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s619">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s920">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s921">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s922">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s924">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s925">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s926">
          <Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s927">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s928">
          <Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1013">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Avenir Book" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1015">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Avenir Book" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1016">
          <Borders/>
          <Interior/>
        </Style>
        <Style ss:ID="s1181">
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="s1189">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#4472C4" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s1190">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#4472C4" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s1191">
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s1192">
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s1292">
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="s1294">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Interior/>
        </Style>
        <Style ss:ID="s1296" ss:Parent="s18">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1300">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1301" ss:Parent="s18">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1302">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Interior/>
        </Style>
        <Style ss:ID="s1303">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1304">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1305">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Interior/>
        </Style>
        <Style ss:ID="s1307">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1309">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s1341">
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1342">
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1343">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1344">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1345">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1346">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="s1347">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1348">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1349">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Avenir Book" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1350">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Avenir Book" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1351">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Avenir Book" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s1352">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s192">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
          <NumberFormat/>
        </Style>
      </Styles>
      <Worksheet>
        <xsl:attribute name="ss:Name">DOSSIER IMPORT AERIEN</xsl:attribute>
        <Table>
          <Column ss:Width="122.25"/>
          <Column ss:Width="99.75"/>
          <Column ss:Width="98.25"/>
          <Column ss:Width="99"/>
          <Column ss:Width="87.75"/>
          <Column ss:Width="93.75"/>
          <Column ss:Width="110.25"/>
          <Column ss:Width="46.5"/>
          <Column ss:Width="43.5"/>
          <Column ss:Width="47.25"/>
          <Column ss:Width="140.25"/>
          <Column ss:Width="80.25" ss:Span="1"/>
          <Column ss:Index="14" ss:Width="140.25"/>
          <Column ss:Width="39.75" ss:Span="1"/>
          <Column ss:Index="17" ss:Width="54"/>
          <Column ss:Width="60"/>
          <Column ss:Width="69.75" ss:Span="2"/>
          <Column ss:Index="22" ss:AutoFitWidth="0" ss:Width="60"/>

          <Row ss:Height="15.75">
            <Cell ss:MergeAcross="9" ss:StyleID="m2142890316064">
              <Data ss:Type="String">DOSSIER IMPORT AERIEN</Data>
            </Cell>
          </Row>

          <xsl:for-each select="//NewDataSet/Table1">
            <xsl:variable name="MODE" select="MODE"></xsl:variable>

            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:StyleID="s1181"/>
              <Cell ss:StyleID="s70">
                <Data ss:Type="String">CONSOLE</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s70">
                <Data ss:Type="String">NO DOSSIER</Data>
              </Cell>
              <Cell ss:StyleID="s72">
                <Data ss:Type="String">
                  <xsl:value-of select="CONSOLENO" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s120"/>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890316164"/>
            </Row>

            <xsl:choose>
              <xsl:when test="$MODE='a'">
                <Row>
                  <Cell ss:StyleID="s1292"/>
                  <Cell ss:StyleID="s515">
                    <Data ss:Type="String">Mawb No.</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s1300">
                    <Data ss:Type="String">
                      <xsl:value-of select="MAWBNO" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s515">
                    <Data ss:Type="String">Airport Dep.</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s924">
                    <Data ss:Type="String">
                      <xsl:value-of select="SENTFROM" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:MergeAcross="2" ss:StyleID="m2142890316104"/>
                </Row>
                <Row>
                  <Cell ss:StyleID="s1292"/>
                  <Cell ss:StyleID="s515">
                    <Data ss:Type="String">Air Line</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s1300">
                    <Data ss:Type="String">
                      <xsl:value-of select="AIRLINE"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s515">
                    <Data ss:Type="String">Airport Arr.</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s924">
                    <Data ss:Type="String">
                      <xsl:value-of select="DESTINATION" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:MergeAcross="2" ss:StyleID="m2142890316124"/>
                </Row>
              </xsl:when>
              <xsl:otherwise>
                <Row>
                  <Cell ss:StyleID="s1292"/>
                  <Cell ss:StyleID="s116">
                    <Data ss:Type="String">MBL No.</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s144">
                    <Data ss:Type="String">
                      <xsl:value-of select="MBLNO" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s116">
                    <Data ss:Type="String">POL</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s144">
                    <Data ss:Type="String">
                      <xsl:value-of select="SENTFROM" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:MergeAcross="2" ss:StyleID="m2142900913848"/>
                </Row>
                <Row ss:AutoFitHeight="0" ss:Height="15.75">
                  <Cell ss:StyleID="s1292"/>
                  <Cell ss:StyleID="s116">
                    <Data ss:Type="String">SHIPPING LINE</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s144">
                    <Data ss:Type="String">
                      <xsl:value-of select="SHIPLINE" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s116">
                    <Data ss:Type="String">POD</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s144">
                    <Data ss:Type="String">
                      <xsl:value-of select="DESTINATION" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:MergeAcross="2" ss:StyleID="m2142890316164"/>
                </Row>
                <Row ss:AutoFitHeight="0" ss:Height="15.75">
                  <Cell ss:StyleID="s1292"/>
                  <Cell ss:StyleID="s116">
                    <Data ss:Type="String">VESSEL</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s144">
                    <Data ss:Type="String">
                      <xsl:value-of select="VESSEL" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s116">
                    <Data ss:Type="String">CONTAINER #</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s144">
                    <Data ss:Type="String">
                      <xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:MergeAcross="2" ss:StyleID="m2142900913868"/>
                </Row>
                <Row ss:AutoFitHeight="0" ss:Height="15.75">
                  <Cell ss:StyleID="s1292"/>
                  <Cell ss:StyleID="s116">
                    <Data ss:Type="String">MOTHER VESSEL</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s145">
                    <Data ss:Type="String">
                      <xsl:value-of select="MOTHERVSL" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s116">
                    <Data ss:Type="String">TRANSHIPMENT VESSEL</Data>
                  </Cell>
                  <Cell ss:MergeAcross="1" ss:StyleID="s146">
                    <Data ss:Type="String">
                      <xsl:value-of select="MOTHERVSL" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:MergeAcross="2" ss:StyleID="m2142900913888"/>
                </Row>
              </xsl:otherwise>
            </xsl:choose>
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:StyleID="s1292"/>
              <Cell ss:StyleID="s116">
                <Data ss:Type="String">Freight</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s125">
                <Data ss:Type="String">
                  <xsl:value-of select="FREIGHT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s1307"/>
              <Cell ss:MergeAcross="1" ss:StyleID="s516"/>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142900913908"/>
            </Row>
            <Row ss:AutoFitHeight="0" ss:Height="50">
              <Cell ss:StyleID="s1292"/>
              <Cell ss:StyleID="s116">
                <Data ss:Type="String">Remark</Data>
              </Cell>
              <Cell ss:MergeAcross="4" ss:StyleID="s148">
                <Data ss:Type="String">
                  <xsl:value-of select="REMARK"/>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142719795744"/>
            </Row>

            <!--<start ARRIVE="" />-->
            <Row ss:Height="15.75">
              <Cell ss:MergeAcross="9" ss:StyleID="m2142890316272">
                <Data ss:Type="String">ARRIVEE</Data>
              </Cell>
            </Row>

            <!--<xsl:for-each select="//NewDataSet/Table1">-->
            <!--<xsl:variable name="MODE1" select="MODE"></xsl:variable>-->
            <Row>
              <Cell ss:StyleID="s1292"/>
              <Cell ss:StyleID="s515">
                <Data ss:Type="String">E.T.D.</Data>
              </Cell>
              <xsl:choose>
                <xsl:when test="$MODE='a'">
                  <Cell ss:StyleID="s1302">
                    <Data ss:Type="String">
                      <xsl:value-of select="FLIGHTDAT" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                </xsl:when>
                <xsl:otherwise>
                  <Cell ss:StyleID="s1302">
                    <Data ss:Type="String">
                      <xsl:value-of select="ETD" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                </xsl:otherwise>
              </xsl:choose>

              <Cell ss:StyleID="s515">
                <Data ss:Type="String">E.T.A.</Data>
              </Cell>
              <Cell ss:StyleID="s618">
                <Data ss:Type="String">
                  <xsl:value-of select="ETA" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s515">
                <Data ss:Type="String">Act.Arrival Date</Data>
              </Cell>
              <Cell ss:StyleID="s618">
                <Data ss:Type="String">
                  <xsl:value-of select="ETA" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890316292"/>
            </Row>
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:StyleID="s1292"/>
              <Cell ss:StyleID="s515">
                <Data ss:Type="String">PKGS.</Data>
              </Cell>
              <Cell ss:StyleID="s1304">
                <Data ss:Type="Number">
                  <xsl:value-of select="NOOFPKGS" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s515">
                <Data ss:Type="String">Grwt.</Data>
              </Cell>
              <Cell ss:StyleID="s1304">
                <Data ss:Type="Number">
                  <xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s515">
                <Data ss:Type="String">Volume</Data>
              </Cell>
              <Cell ss:StyleID="s1304">
                <Data ss:Type="Number">
                  <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                </Data>2
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890316312"/>
            </Row>

            <xsl:if test="$MODE='a'">
              <Row ss:AutoFitHeight="0" ss:Height="15.75">
                <Cell ss:StyleID="s1292"/>
                <Cell ss:StyleID="s519">
                  <Data ss:Type="String">Chbl.Wt.</Data>
                </Cell>
                <Cell ss:StyleID="s1304">
                  <Data ss:Type="Number">
                    <xsl:value-of select="CHBLWT" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:Index="6" ss:StyleID="s515">
                  <Data ss:Type="String">M3</Data>
                </Cell>
                <Cell ss:StyleID="s1304">
                  <Data ss:Type="Number">
                    <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:MergeAcross="2" ss:StyleID="m2142890316332"/>
              </Row>
              <Row>
                <Cell ss:StyleID="s1292"/>
                <Cell ss:StyleID="s515">
                  <Data ss:Type="String">D/D</Data>
                </Cell>
                <Cell ss:MergeAcross="4" ss:StyleID="s1305">
                  <Data ss:Type="String">
                    <xsl:value-of select="DOUANENO" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:MergeAcross="2" ss:StyleID="m2142890316372"/>
              </Row>
            </xsl:if>
          </xsl:for-each>


          <!--< START CARGO MANIFEST="" >-->
          <Row ss:Height="15.75">
            <Cell ss:MergeAcross="9" ss:StyleID="m2142890316688">
              <Data ss:Type="String">CARGO MANIFEST</Data>
            </Cell>
          </Row>
          <Row>
            <Cell ss:StyleID="s1189">
              <Data ss:Type="String">JOB NO</Data>
            </Cell>
            <Cell ss:StyleID="s93">
              <Data ss:Type="String">HAWB NO</Data>
            </Cell>
            <Cell ss:StyleID="s94">
              <Data ss:Type="String">SHPR</Data>
            </Cell>
            <Cell ss:StyleID="s93">
              <Data ss:Type="String">CNEE</Data>
            </Cell>
            <Cell ss:StyleID="s93">
              <Data ss:Type="String">P/O</Data>
            </Cell>
            <Cell ss:StyleID="s93">
              <Data ss:Type="String">PCS</Data>
            </Cell>
            <Cell ss:StyleID="s93">
              <Data ss:Type="String">CTNS</Data>
            </Cell>
            <Cell ss:StyleID="s93">
              <Data ss:Type="String">GRWT</Data>
            </Cell>
            <Cell ss:StyleID="s93">
              <Data ss:Type="String">VOL</Data>
            </Cell>
            <Cell ss:StyleID="s1190">
              <Data ss:Type="String">CHBL.WT</Data>
            </Cell>
          </Row>
          <xsl:for-each select="//NewDataSet/Table2">
            <Row ss:AutoFitHeight="0" ss:Height="30">
              <Cell ss:StyleID="s120">
                <Data ss:Type="String">
                  <xsl:value-of select="JOBNO" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s121">
                <Data ss:Type="String">
                  <xsl:value-of select="HAWBNO" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s122">
                <Data ss:Type="String">
                  <xsl:value-of select="SHPR" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s121">
                <Data ss:Type="String">
                  <xsl:value-of select="IMPR" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s121">
                <Data ss:Type="String">
                  <xsl:value-of select="ORDERNO" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s123">
                <Data ss:Type="String">
                  <xsl:value-of select="NOOFPCS" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s123">
                <Data ss:Type="String">
                  <xsl:value-of select="NOOFPKG" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s192">
                <Data ss:Type="String">
                  <xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s192">
                <Data ss:Type="String">
                  <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s192">
                <Data ss:Type="String">
                  <xsl:value-of select="CHBLWT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
            </Row>
            <!--<Row>
              <Cell ss:StyleID="s1191">
                <Data ss:Type="String">
                  <xsl:value-of select="JOBNO" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s575">
                <Data ss:Type="String">
                  <xsl:value-of select="HAWBNO" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s576">
                <Data ss:Type="String">
                  <xsl:value-of select="SHPR" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s575">
                <Data ss:Type="String">
                  <xsl:value-of select="IMPR" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s575">
                <Data ss:Type="String">
                  <xsl:value-of select="ORDERNO" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s123">
                <Data ss:Type="Number">
                  <xsl:value-of select="NOOFPCS" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s123">
                <Data ss:Type="Number">
                  <xsl:value-of select="NOOFPKG" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s124">
                <Data ss:Type="Number">
                  <xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s124">
                <Data ss:Type="Number">
                  <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s124">
                <Data ss:Type="Number">
                  <xsl:value-of select="CHBLWT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
            </Row>-->
          </xsl:for-each>

          <Row ss:Height="15.75">
            <Cell ss:MergeAcross="9" ss:StyleID="m2142900963748">
              <Data ss:Type="String">LIVRAISON</Data>
            </Cell>
          </Row>

          <xsl:for-each select="//NewDataSet/Table1">

            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:StyleID="s1292"/>
              <Cell ss:StyleID="s519">
                <Data ss:Type="String">L.E.</Data>
              </Cell>
              <Cell ss:MergeAcross="4" ss:StyleID="s517">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142719795744"/>
            </Row>
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:StyleID="s1292"/>
              <Cell ss:StyleID="s519">
                <Data ss:Type="String">CHEZ</Data>
              </Cell>
              <Cell ss:MergeAcross="4" ss:StyleID="s517">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142719795744"/>
            </Row>
          </xsl:for-each>

          <Row ss:Height="15.75">
            <Cell ss:MergeAcross="9" ss:StyleID="m2142890316708">
              <Data ss:Type="String">OBSERVATIONS</Data>
            </Cell>
          </Row>

          <xsl:for-each select="//NewDataSet/Table1">

            <Row>
              <Cell ss:StyleID="s1309">
                <Data ss:Type="String">Verification ETA 1</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s920">
                <Data ss:Type="String">
                  <xsl:value-of select="V_ETA1" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">New ETA 1</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s922">
                <Data ss:Type="String">
                  <xsl:value-of select="NEW_ETA1" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">Orginal Doc. Handover</Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890316768">
                <Data ss:Type="String">
                  <xsl:value-of select="ORG_DOC" disable-output-escaping="yes"/>
                </Data>
              </Cell>
            </Row>
            <Row>
              <Cell ss:StyleID="s1309">
                <Data ss:Type="String">Verification ETA 2</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s920">
                <Data ss:Type="String">
                  <xsl:value-of select="V_ETA2" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">New ETA 2</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s922">
                <Data ss:Type="String">
                  <xsl:value-of select="NEW_ETA2" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">T1 Received</Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890316828">
                <Data ss:Type="String">
                  <xsl:value-of select="T1_RECVD" disable-output-escaping="yes"/>
                </Data>
              </Cell>
            </Row>
            <Row>
              <Cell ss:StyleID="s1309">
                <Data ss:Type="String">Verification ETA3</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s920">
                <Data ss:Type="String">
                  <xsl:value-of select="V_ETA3" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">New ETA 3</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s922">
                <Data ss:Type="String">
                  <xsl:value-of select="NEW_ETA3" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">T1 Sent</Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890315064">
                <Data ss:Type="String">
                  <xsl:value-of select="T1_SENT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
            </Row>
            <Row>
              <Cell ss:StyleID="s1309">
                <Data ss:Type="String">Release Print</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s920">
                <Data ss:Type="String">
                  <xsl:value-of select="REL_PRINT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">Release Sent</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s922">
                <Data ss:Type="String">
                  <xsl:value-of select="REL_SENT" disable-output-escaping="yes"/>

                </Data>
              </Cell>
              <Cell ss:StyleID="s924"/>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890315124"/>
            </Row>
            <Row>
              <Cell ss:StyleID="s1309">
                <Data ss:Type="String">Request RDV</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s920">
                <Data ss:Type="String">
                  <xsl:value-of select="REQ_RDV" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">Confirm RDV</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s922">
                <Data ss:Type="String">
                  <xsl:value-of select="CONF_RDV" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s924"/>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890315480"/>
            </Row>
            <Row>
              <Cell ss:StyleID="s1309">
                <Data ss:Type="String">Actual Delivery Dt</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s920">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">Cargo Arrival Notice</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s922">
                <Data ss:Type="String">
                  <xsl:value-of select="CAN_DT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s924"/>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890315540"/>
            </Row>
            <Row>
              <Cell ss:StyleID="s1309">
                <Data ss:Type="String">Pincode</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s920">
                <Data ss:Type="String">
                  <xsl:value-of select="PINCODE" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">Order de Transport</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s922">
                <Data ss:Type="String">
                  <xsl:value-of select="ORD_DE_TRANS" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s924"/>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890302168"/>
            </Row>
            <Row ss:AutoFitHeight="0" ss:Height="30">
              <Cell ss:StyleID="s1309">
                <Data ss:Type="String">DO/ Pincode sent to transporter</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s920">
                <Data ss:Type="String">
                  <xsl:value-of select="DO_PIN_TRANS" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s921">
                <Data ss:Type="String">Instruction Douane</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s925">
                <Data ss:Type="String">
                  <xsl:value-of select="DO_PIN_TRANS" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s924"/>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890302228"/>
            </Row>
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:StyleID="s1309">
                <Data ss:Type="String">Copy des Document mail</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s926">
                <Data ss:Type="String">
                  <xsl:value-of select="COPY_DOC_MAIL" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s927"/>
              <Cell ss:MergeAcross="1" ss:StyleID="s928"/>
              <Cell ss:StyleID="s924"/>
              <Cell ss:MergeAcross="2" ss:StyleID="m2142890308616"/>
            </Row>



            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="9" ss:StyleID="m2142900963808"/>
            </Row>

            <Row>
              <Cell ss:StyleID="s1343">
                <Data ss:Type="String">WEB</Data>
              </Cell>
              <Cell ss:StyleID="s1344"/>
              <Cell ss:StyleID="s1013"/>
              <Cell ss:StyleID="s1013"/>
              <Cell ss:MergeAcross="1" ss:StyleID="s1015"/>
              <Cell ss:StyleID="s1345">
                <Data ss:Type="String">TAUX</Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="s1346"/>
            </Row>
            <Row>
              <Cell ss:StyleID="s1345">
                <Data ss:Type="String">ARV</Data>
              </Cell>
              <Cell ss:StyleID="s1347">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s619"/>
              <Cell ss:StyleID="s1013"/>
              <Cell ss:MergeAcross="1" ss:StyleID="s922">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s1345">
                <Data ss:Type="String">A</Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="s1348">
                <Data ss:Type="String"></Data>
              </Cell>
            </Row>
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:StyleID="s1345">
                <Data ss:Type="String">DLV</Data>
              </Cell>
              <Cell ss:StyleID="s1349"/>
              <Cell ss:StyleID="s1350"/>
              <Cell ss:StyleID="s1350"/>
              <Cell ss:MergeAcross="1" ss:StyleID="s1351"/>
              <Cell ss:StyleID="s1345">
                <Data ss:Type="String">V</Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="s1352"/>
            </Row>
            <Row>
              <Cell ss:StyleID="s78">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s78">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s77">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s78">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s78">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:MergeAcross="4" ss:StyleID="s78">
                <Data ss:Type="String"></Data>
              </Cell>
            </Row>
          </xsl:for-each>
        </Table>

        <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
          <Selected/>
          <Panes>
            <Pane>
              <Number>3</Number>
            </Pane>
            <Pane>
              <ActiveRow>18</ActiveRow>
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

