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
        <Style ss:ID="m2143045333844">
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="m2143045333884">
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
        <Style ss:ID="m2143045333944">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2143045323692">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2143045323732">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2143045329040">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2143045329140">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2143045322840">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2143045322900">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#538ED5" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="m2143045322920">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="m2143045321344">
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
        <Style ss:ID="s69">
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="s70">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
        </Style>
        <Style ss:ID="s74">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders/>
        </Style>
        <Style ss:ID="s76">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
        </Style>
        <Style ss:ID="s77">
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="s78">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s80">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s81">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s84">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
        </Style>
        <Style ss:ID="s85">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s90" ss:Parent="s18">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s95">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s97">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s99">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s108">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s109">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#4472C4" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s110">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#4472C4" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s111">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#4472C4" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s112">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
           ss:Bold="1"/>
          <Interior ss:Color="#4472C4" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s117">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s120">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s122">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s124">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s126">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s130">
          <Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s132">
          <Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s134">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s140">
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
        <Style ss:ID="s141">
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
        <Style ss:ID="s142">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Avenir Book" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s144">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Avenir Book" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s145">
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
        <Style ss:ID="s153">
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
        <Style ss:ID="s154">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s162">
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
        <Style ss:ID="s163">
          <Alignment ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Avenir Book" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s165">
          <Alignment ss:Horizontal="Center" ss:Vertical="Center" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Avenir Book" x:Family="Swiss" ss:Color="#000000" ss:Bold="1"/>
          <Interior/>
        </Style>
        <Style ss:ID="s173">
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s174">
          <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
        </Style>
        <Style ss:ID="s191">
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
        <Style ss:ID="s192">
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
        <Style ss:ID="s193">
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
        <Style ss:ID="s195">
          <Alignment ss:Horizontal="Center" ss:Vertical="Top"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="Fixed"/>
        </Style>
        <Style ss:ID="s196">
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
        <Style ss:ID="s197">
          <Alignment ss:Horizontal="Left" ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s199">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s200">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s201">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s202">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="s203" ss:Parent="s18">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s205">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Interior/>
        </Style>
        <Style ss:ID="s212">
          <Alignment ss:Horizontal="Left" ss:Vertical="Bottom"/>
          <Borders/>
          <Interior/>
        </Style>
        <Style ss:ID="s216" ss:Parent="s18">
          <Alignment ss:Vertical="Bottom"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior/>
        </Style>
        <Style ss:ID="s245">
          <Borders>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s246">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s247">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s248">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s249" ss:Parent="s18">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
          <Borders>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s250" ss:Parent="s18">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"/>
          <Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s251" ss:Parent="s18">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders/>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
           ss:Bold="1"/>
          <Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/>
        </Style>
        <Style ss:ID="s253">
          <Alignment ss:Horizontal="Center" ss:Vertical="Bottom" ss:WrapText="1"/>
          <Borders/>
          <Interior/>
        </Style>
      </Styles>
      <Worksheet>
        <!--<xsl:for-each select="//NewDataSet/Table">-->
          <xsl:attribute name="ss:Name">DOSSIER IMPORT AERIEN</xsl:attribute>
          <Table ss:ExpandedColumnCount="22" ss:ExpandedRowCount="36" x:FullColumns="1"
               x:FullRows="1" ss:DefaultRowHeight="15">
            <Column ss:Width="122.25"/>
            <Column ss:Width="99.75"/>
            <Column ss:Width="98.25"/>
            <Column ss:Width="99"/>
            <Column ss:Width="167.25"/>
            <Column ss:Width="78.75"/>
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

            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="9" ss:StyleID="m2143045321344">
                <Data ss:Type="String">DOSSIER IMPORT AERIEN</Data>
              </Cell>
            </Row>

            <xsl:for-each select="//NewDataSet/Table1">
              <xsl:variable name="MODE" select="MODE"></xsl:variable>
              <Row ss:AutoFitHeight="0" ss:Height="15.75">
                <Cell ss:StyleID="s69"/>
                <Cell ss:StyleID="s70">
                  <Data ss:Type="String">CONSOLE</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s70">
                  <Data ss:Type="String">NO DOSSIER</Data>
                </Cell>
                <Cell ss:StyleID="s202">
                  <Data ss:Type="String">
                    <xsl:value-of select="CONSOLENO" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s74"/>
                <Cell ss:MergeAcross="2" ss:StyleID="s76"/>
              </Row>

              <xsl:choose>
                <xsl:when test="$MODE='a'">
                  <Row>
                    <Cell ss:StyleID="s77"/>
                    <Cell ss:StyleID="s78">
                      <Data ss:Type="String">Mawb No.</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s80">
                      <Data ss:Type="String">
                        <xsl:value-of select="MAWBNO" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:StyleID="s78">
                      <Data ss:Type="String">Airport Dep.</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s81">
                      <Data ss:Type="String">
                        <xsl:value-of select="SENTFROM" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:MergeAcross="2" ss:StyleID="s84"/>
                  </Row>
                  <Row>
                    <Cell ss:StyleID="s77"/>
                    <Cell ss:StyleID="s78">
                      <Data ss:Type="String">Air Line</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s80">
                      <Data ss:Type="String">
                        <xsl:value-of select="AIRLINE"/>
                      </Data>
                    </Cell>
                    <Cell ss:StyleID="s78">
                      <Data ss:Type="String">Airport Arr.</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s81">
                      <Data ss:Type="String">
                        <xsl:value-of select="DESTINATION" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:MergeAcross="2" ss:StyleID="s84"/>
                  </Row>
                </xsl:when>
                <xsl:otherwise>
                  <Row>
                    <Cell ss:StyleID="s77"/>
                    <Cell ss:StyleID="s85">
                      <Data ss:Type="String">MBL No.</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s247">
                      <Data ss:Type="String">
                        <xsl:value-of select="MBLNO" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:StyleID="s85">
                      <Data ss:Type="String">POL</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s247">
                      <Data ss:Type="String">
                        <xsl:value-of select="SENTFROM" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:MergeAcross="2" ss:StyleID="s84"/>
                  </Row>
                  <Row ss:AutoFitHeight="0" ss:Height="15.75">
                    <Cell ss:StyleID="s77"/>
                    <Cell ss:StyleID="s85">
                      <Data ss:Type="String">SHIPPING LINE</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s247">
                      <Data ss:Type="String">
                        <xsl:value-of select="SHIPLINE" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:StyleID="s85">
                      <Data ss:Type="String">POD</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s247">
                      <Data ss:Type="String">
                        <xsl:value-of select="DESTINATION" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:MergeAcross="2" ss:StyleID="s90"/>
                  </Row>
                  <Row ss:AutoFitHeight="0" ss:Height="15.75">
                    <Cell ss:StyleID="s77"/>
                    <Cell ss:StyleID="s85">
                      <Data ss:Type="String">VESSEL</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s247">
                      <Data ss:Type="String">
                        <xsl:value-of select="VESSEL" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:StyleID="s85">
                      <Data ss:Type="String">CONTAINER #</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s247">
                      <Data ss:Type="String">
                        <xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:MergeAcross="2" ss:StyleID="s90"/>
                  </Row>
                  <Row ss:AutoFitHeight="0" ss:Height="15.75">
                    <Cell ss:StyleID="s77"/>
                    <Cell ss:StyleID="s85">
                      <Data ss:Type="String">MOTHER VESSEL</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s250">
                      <Data ss:Type="String">
                        <xsl:value-of select="MOTHERVSL" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:StyleID="s85">
                      <Data ss:Type="String">TRANSHIPMENT VESSEL</Data>
                    </Cell>
                    <Cell ss:MergeAcross="1" ss:StyleID="s250">
                      <Data ss:Type="String">
                        <xsl:value-of select="MOTHERVSL" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                    <Cell ss:MergeAcross="2" ss:StyleID="s90"/>
                  </Row>
                </xsl:otherwise>
              </xsl:choose>

              <Row ss:AutoFitHeight="0" ss:Height="15.75">
                <Cell ss:StyleID="s77"/>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">Freight</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s95">
                  <Data ss:Type="String">
                    <xsl:value-of select="FREIGHT" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s97"/>
                <Cell ss:MergeAcross="1" ss:StyleID="s99"/>
                <Cell ss:MergeAcross="2" ss:StyleID="s90"/>
              </Row>
              <Row ss:AutoFitHeight="0" ss:Height="68.25">
                <Cell ss:StyleID="s77"/>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">Remark</Data>
                </Cell>
                <Cell ss:MergeAcross="4" ss:StyleID="s203">
                  <Data ss:Type="String">
                    <xsl:value-of select="REMARK" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:MergeAcross="2" ss:StyleID="s90"/>
              </Row>

            </xsl:for-each>

            <!--<start ARRIVE="" />-->

            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="9" ss:StyleID="m2143045322840">
                <Data ss:Type="String">ARRIVEE</Data>
              </Cell>
            </Row>

            <xsl:for-each select="//NewDataSet/Table1">
              <xsl:variable name="MODE1" select="MODE"></xsl:variable>
              <Row>
                <Cell ss:StyleID="s77"/>
                <Cell ss:StyleID="s78">
                  <Data ss:Type="String">E.T.D.</Data>
                </Cell>
                <xsl:choose>
                  <xsl:when test="$MODE1='a'">
                    <Cell ss:StyleID="s205">
                      <Data ss:Type="String">
                        <xsl:value-of select="FLIGHTDAT" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                  </xsl:when>
                  <xsl:otherwise>
                    <Cell ss:StyleID="s205">
                      <Data ss:Type="String">
                        <xsl:value-of select="ETD" disable-output-escaping="yes"/>
                      </Data>
                    </Cell>
                  </xsl:otherwise>
                </xsl:choose>
                <Cell ss:StyleID="s78">
                  <Data ss:Type="String">E.T.A.</Data>
                </Cell>
                <Cell ss:StyleID="s81">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETA" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s78">
                  <Data ss:Type="String">Act.Arrival Date</Data>
                </Cell>
                <Cell ss:StyleID="s81">
                  <Data ss:Type="String">
                    <xsl:value-of select="ETA" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:MergeAcross="2" ss:StyleID="s84"/>
              </Row>

              <Row ss:AutoFitHeight="0" ss:Height="15.75">
                <Cell ss:StyleID="s77"/>
                <Cell ss:StyleID="s78">
                  <Data ss:Type="String">PKGS.</Data>
                </Cell>
                <Cell ss:StyleID="s205">
                  <Data ss:Type="Number">
                    <xsl:value-of select="NOOFPKGS" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s78">
                  <Data ss:Type="String">Grwt.</Data>
                </Cell>
                <Cell ss:StyleID="s212">
                  <Data ss:Type="String">
                    <xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s78">
                  <Data ss:Type="String">Volume</Data>
                </Cell>
                <Cell ss:StyleID="s108">
                  <Data ss:Type="Number">
                    <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:MergeAcross="2" ss:StyleID="s84"/>
              </Row>

              <xsl:if test="$MODE1='a'">
                <Row ss:AutoFitHeight="0" ss:Height="15.75">
                  <Cell ss:StyleID="s77"/>
                  <Cell ss:StyleID="s78">
                    <Data ss:Type="String">chbl wt.</Data>
                  </Cell>
                  <Cell ss:StyleID="s212">
                    <Data ss:Type="Number">
                      <xsl:value-of select="CHBLWT" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s78">
                    <Data ss:Type="String">M3</Data>
                  </Cell>
                  <Cell ss:StyleID="s212">
                    <Data ss:Type="String">
                      <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:StyleID="s78"/>
                  <Cell ss:StyleID="s108"/>
                  <Cell ss:MergeAcross="2" ss:StyleID="m2143045322920"/>
                </Row>
                <Row ss:AutoFitHeight="0" ss:Height="15.75">
                  <Cell ss:StyleID="s77"/>
                  <Cell ss:StyleID="s78">
                    <Data ss:Type="String">D/D</Data>
                  </Cell>
                  <Cell ss:MergeAcross="4" ss:StyleID="s253">
                    <Data ss:Type="String">
                      <xsl:value-of select="DOUANENO" disable-output-escaping="yes"/>
                    </Data>
                  </Cell>
                  <Cell ss:MergeAcross="2" ss:StyleID="m2143045333944"/>
                </Row>

              </xsl:if>
            </xsl:for-each>

            <!--< START CARGO MANIFEST="" >-->
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="9" ss:StyleID="m2143045322900">
                <Data ss:Type="String">CARGO MANIFEST</Data>
              </Cell>
            </Row>
            <Row>
              <Cell ss:StyleID="s109">
                <Data ss:Type="String">JOB NO</Data>
              </Cell>
              <Cell ss:StyleID="s110">
                <Data ss:Type="String">HAWB NO</Data>
              </Cell>
              <Cell ss:StyleID="s111">
                <Data ss:Type="String">SHPR</Data>
              </Cell>
              <Cell ss:StyleID="s110">
                <Data ss:Type="String">CNEE</Data>
              </Cell>
              <Cell ss:StyleID="s110">
                <Data ss:Type="String">P/O</Data>
              </Cell>
              <Cell ss:StyleID="s110">
                <Data ss:Type="String">PCS</Data>
              </Cell>
              <Cell ss:StyleID="s110">
                <Data ss:Type="String">CTNS</Data>
              </Cell>
              <Cell ss:StyleID="s110">
                <Data ss:Type="String">GRWT</Data>
              </Cell>
              <Cell ss:StyleID="s110">
                <Data ss:Type="String">VOL</Data>
              </Cell>
              <Cell ss:StyleID="s112">
                <Data ss:Type="String">CHBL.WT</Data>
              </Cell>
            </Row>
            <xsl:for-each select="//NewDataSet/Table2">
              <Row ss:Height="30">
                <Cell ss:StyleID="s191">
                  <Data ss:Type="String">
                    <xsl:value-of select="JOBNO" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s192">
                  <Data ss:Type="String">
                    <xsl:value-of select="HAWBNO" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s193">
                  <Data ss:Type="String">
                    <xsl:value-of select="SHPR" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s192">
                  <Data ss:Type="String">
                    <xsl:value-of select="IMPR" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s192">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORDERNO" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s196">
                  <Data ss:Type="String">
                    <xsl:value-of select="NOOFPCS" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s196">
                  <Data ss:Type="String">
                    <xsl:value-of select="NOOFPKG" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s195">
                  <Data ss:Type="String">
                    <xsl:value-of select="WEIGHT" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s195">
                  <Data ss:Type="String">
                    <xsl:value-of select="VOLUME" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s195">
                  <Data ss:Type="String">
                    <xsl:value-of select="CHBLWT" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
              </Row>
            </xsl:for-each>

            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="9" ss:StyleID="m2143045329040">
                <Data ss:Type="String">LIVRAISON</Data>
              </Cell>
            </Row>
            <xsl:for-each select="//NewDataSet/Table1">
              <Row ss:AutoFitHeight="0" ss:Height="15.75">
                <Cell ss:StyleID="s77"/>
                <Cell ss:StyleID="s117">
                  <Data ss:Type="String">L.E.</Data>
                </Cell>
                <Cell ss:MergeAcross="4" ss:StyleID="s216">
                  <Data ss:Type="String"></Data>
                </Cell>
                <Cell ss:MergeAcross="2" ss:StyleID="s90"/>
              </Row>
              <Row ss:AutoFitHeight="0" ss:Height="15.75">
                <Cell ss:StyleID="s77"/>
                <Cell ss:StyleID="s117">
                  <Data ss:Type="String">CHEZ</Data>
                </Cell>
                <Cell ss:MergeAcross="4" ss:StyleID="s216">
                  <Data ss:Type="String"></Data>
                </Cell>
                <Cell ss:MergeAcross="2" ss:StyleID="s90"/>
              </Row>
            </xsl:for-each>

            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="9" ss:StyleID="m2143045329140">
                <Data ss:Type="String">OBSERVATIONS</Data>
              </Cell>
            </Row>

            <xsl:for-each select="//NewDataSet/Table1">
              <Row>
                <Cell ss:StyleID="s120">
                  <Data ss:Type="String">Verification ETA 1</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="V_ETA1"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">New ETA 1</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s122">
                  <Data ss:Type="String">
                    <xsl:value-of select="NEW_ETA1"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">Orginal Doc. Handover</Data>
                </Cell>
                <Cell ss:MergeAcross="2" ss:StyleID="s199">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORG_DOC"/>
                  </Data>
                </Cell>
              </Row>
              <Row>
                <Cell ss:StyleID="s120">
                  <Data ss:Type="String">Verification ETA 2</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="V_ETA2"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">New ETA 2</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s122">
                  <Data ss:Type="String">
                    <xsl:value-of select="NEW_ETA2"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">T1 Received</Data>
                </Cell>
                <Cell ss:MergeAcross="2" ss:StyleID="s200">
                  <Data ss:Type="String">
                    <xsl:value-of select="T1_RECVD"/>
                  </Data>
                </Cell>
              </Row>
              <Row>
                <Cell ss:StyleID="s120">
                  <Data ss:Type="String">Verification ETA3</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="V_ETA3"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">New ETA 3</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s122">
                  <Data ss:Type="String">
                    <xsl:value-of select="NEW_ETA3"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">T1 Sent</Data>
                </Cell>
                <Cell ss:MergeAcross="2" ss:StyleID="s201">
                  <Data ss:Type="String">
                    <xsl:value-of select="T1_SENT"/>
                  </Data>
                </Cell>
              </Row>
              <Row>
                <Cell ss:StyleID="s120">
                  <Data ss:Type="String">Release Print</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="REL_PRINT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">Release Sent</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="REL_SENT"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s81"/>
                <Cell ss:MergeAcross="2" ss:StyleID="s126"/>
              </Row>
              <Row>
                <Cell ss:StyleID="s120">
                  <Data ss:Type="String">Request RDV</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="REQ_RDV"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">Confirm RDV</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="CONF_RDV"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s81"/>
                <Cell ss:MergeAcross="2" ss:StyleID="s126"/>
              </Row>

              <Row>
                <Cell ss:StyleID="s120">
                  <Data ss:Type="String">Actual Delivery Dt</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String"></Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">Cargo Arrival Notice</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="CAN_DT" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s81"/>
                <Cell ss:MergeAcross="2" ss:StyleID="s126"/>
              </Row>
              <Row>
                <Cell ss:StyleID="s120">
                  <Data ss:Type="String">Pincode</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="PINCODE" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">Order de Transport</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="ORD_DE_TRANS" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s81"/>
                <Cell ss:MergeAcross="2" ss:StyleID="s126"/>
              </Row>
              <Row ss:AutoFitHeight="0" ss:Height="30">
                <Cell ss:StyleID="s120">
                  <Data ss:Type="String">DO/ Pincode sent to transporter</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s197">
                  <Data ss:Type="String">
                    <xsl:value-of select="DO_PIN_TRANS" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s85">
                  <Data ss:Type="String">Instruction Douane</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s130">
                  <Data ss:Type="String">
                    <xsl:value-of select="DO_PIN_TRANS" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s81"/>
                <Cell ss:MergeAcross="2" ss:StyleID="s126"/>
              </Row>
              <Row ss:AutoFitHeight="0" ss:Height="15.75">
                <Cell ss:StyleID="s120">
                  <Data ss:Type="String">Copy des Document mail</Data>
                </Cell>
                <Cell ss:MergeAcross="1" ss:StyleID="s130">
                  <Data ss:Type="String">
                    <xsl:value-of select="COPY_DOC_MAIL" disable-output-escaping="yes"/>
                  </Data>
                </Cell>
                <Cell ss:StyleID="s95"/>
                <Cell ss:MergeAcross="1" ss:StyleID="s132"/>
                <Cell ss:StyleID="s81"/>
                <Cell ss:MergeAcross="2" ss:StyleID="s134"/>
              </Row>            

            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="9" ss:StyleID="m2143045323692"/>
            </Row>
            <Row>
              <Cell ss:StyleID="s140">
                <Data ss:Type="String">WEB</Data>
              </Cell>
              <Cell ss:StyleID="s141"/>
              <Cell ss:StyleID="s142"/>
              <Cell ss:StyleID="s142"/>
              <Cell ss:MergeAcross="1" ss:StyleID="s144"/>
              <Cell ss:StyleID="s145">
                <Data ss:Type="String">TAUX</Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2143045323732"/>
            </Row>
            <Row>
              <Cell ss:StyleID="s145">
                <Data ss:Type="String">ARV</Data>
              </Cell>
              <Cell ss:StyleID="s153">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s154"/>
              <Cell ss:StyleID="s142"/>
              <Cell ss:MergeAcross="1" ss:StyleID="s124">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s145">
                <Data ss:Type="String">A</Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2143045333844">
                <Data ss:Type="String"></Data>
              </Cell>
            </Row>
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:StyleID="s145">
                <Data ss:Type="String">DLV</Data>
              </Cell>
              <Cell ss:StyleID="s162"/>
              <Cell ss:StyleID="s163"/>
              <Cell ss:StyleID="s163"/>
              <Cell ss:MergeAcross="1" ss:StyleID="s165"/>
              <Cell ss:StyleID="s145">
                <Data ss:Type="String">V</Data>
              </Cell>
              <Cell ss:MergeAcross="2" ss:StyleID="m2143045333884"/>
            </Row>
            <Row>
              <Cell ss:StyleID="s173">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s173">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s174">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s173">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:StyleID="s173">
                <Data ss:Type="String"></Data>
              </Cell>
              <Cell ss:MergeAcross="4" ss:StyleID="s173">
                <Data ss:Type="String"></Data>
              </Cell>
            </Row>
			</xsl:for-each>
			  
          </Table>
		  
        <!--</xsl:for-each>-->

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

