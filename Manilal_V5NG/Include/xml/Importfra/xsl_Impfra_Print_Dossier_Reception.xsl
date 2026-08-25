<?xml version="1.0" encoding="utf-8"?>


<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
    xmlns:user="urn:my-scripts"
    xmlns:o="urn:schemas-microsoft-com:office:office"
    xmlns:x="urn:schemas-microsoft-com:office:excel"
    xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet" >
  
  <xsl:output
    method="xml"
    encoding="utf-8"
    indent="no"
    omit-xml-declaration="yes"/>

  <!--<link rel="stylesheet" type="text/css" href="xsltStyle.css" />-->
  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()"/>
    </xsl:copy>
  </xsl:template>

  <!-- Splits a comma-separated string into one value per line (CR/LF) for use inside a cell with WrapText -->
  <xsl:template name="SplitToLines">
    <xsl:param name="text"/>
    <xsl:choose>
      <xsl:when test="contains($text, ',')">
        <xsl:variable name="token" select="normalize-space(substring-before($text, ','))"/>
        <xsl:variable name="remainder" select="substring-after($text, ',')"/>
        <xsl:if test="string-length($token) &gt; 0">
          <xsl:value-of select="$token"/>
          <xsl:if test="string-length(normalize-space($remainder)) &gt; 0">
            <xsl:text>&#13;&#10;</xsl:text>
          </xsl:if>
        </xsl:if>
        <xsl:call-template name="SplitToLines">
          <xsl:with-param name="text" select="$remainder"/>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:variable name="token" select="normalize-space($text)"/>
        <xsl:if test="string-length($token) &gt; 0">
          <xsl:value-of select="$token"/>
        </xsl:if>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <xsl:template name="JoinLinesWithBreak">
    <xsl:param name="text"/>
    <xsl:param name="delim"/>
    <xsl:choose>
      <xsl:when test="contains($text, $delim)">
        <xsl:variable name="token" select="normalize-space(substring-before($text, $delim))"/>
        <xsl:variable name="remainder" select="substring-after($text, $delim)"/>
        <xsl:if test="string-length($token) &gt; 0">
          <xsl:value-of select="$token"/>
          <xsl:if test="string-length(normalize-space($remainder)) &gt; 0">
            <!-- CR+LF: the API post-process (CommonFunction.ConvertToExcel) converts "\r\n" to &#10; for Excel -->
            <xsl:text>&#13;&#10;</xsl:text>
          </xsl:if>
        </xsl:if>
        <xsl:call-template name="JoinLinesWithBreak">
          <xsl:with-param name="text" select="$remainder"/>
          <xsl:with-param name="delim" select="$delim"/>
        </xsl:call-template>
      </xsl:when>
      <xsl:otherwise>
        <xsl:variable name="token" select="normalize-space($text)"/>
        <xsl:if test="string-length($token) &gt; 0">
          <xsl:value-of select="$token"/>
        </xsl:if>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>
  <xsl:template match="NewDataSet">
    <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
			 xmlns:o="urn:schemas-microsoft-com:office:office"
			 xmlns:x="urn:schemas-microsoft-com:office:excel"
			 xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
			 xmlns:html="http://www.w3.org/TR/REC-html40">
      <!--<link rel="stylesheet" type="text/css" href="..\Include\css\xsltStyle.css" />-->
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

        <!--<yellow></yellow>-->
        <Style ss:ID="s120">
          <!-- Ensure Vertical is TOP -->
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FFFF99" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <Style ss:ID="m120">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
							   ss:Bold="1"/>
          <Interior ss:Color="#FFFF00" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <!--<yellow></yellow>-->

        <!--<lightred></lightred>-->
        <Style ss:ID="s121">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>

        <Style ss:ID="m121">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
					 ss:Bold="1"/>
          <Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <!--<lightred></lightred>-->

        <!--<blue Accent></blue Acent>-->
        <Style ss:ID="s122">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>

        <Style ss:ID="m122">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
					 ss:Bold="1"/>
          <Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <!--<blue Accent></blue Acent>-->

        <!--<orange></orange>-->
        <Style ss:ID="s123">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FFA500" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>

        <Style ss:ID="m123">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
					 ss:Bold="1"/>
          <Interior ss:Color="#FFA500" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <!--<orange></orange>-->

        <!--<green accent></green accent>-->
        <Style ss:ID="s124">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#C6E0B4" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>

        <Style ss:ID="m124">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
					 ss:Bold="1"/>
          <Interior ss:Color="#C6E0B4" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>

        <!--<green accent></green accent>-->

        <!--<gold Accent4></gold Accent4>-->
        <Style ss:ID="s126">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FFE699" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>

        <Style ss:ID="m126">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
					 ss:Bold="1"/>
          <Interior ss:Color="#FFE699" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <!--<gold Accent4></gold Accent4>-->

        <!--<lavender></lavender>-->
        <Style ss:ID="s128">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#D6BBEB" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>

        <Style ss:ID="m128">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000"
					 ss:Bold="1"/>
          <Interior ss:Color="#D6BBEB" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
        </Style>
        <!--<lavender></lavender>-->

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
          <!--<Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/>-->
          <NumberFormat/>
        </Style>
        <Style ss:ID="sOrderText">
          <Alignment ss:Vertical="Top" ss:WrapText="1"/>
          <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
          </Borders>
          <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
          <Interior ss:Color="#FFFF99" ss:Pattern="Solid"/>
          <NumberFormat ss:Format="@"/>
          <!-- This forces Excel to treat it as Text -->
        </Style>
        <Style ss:ID="rcpTitle"><Alignment ss:Vertical="Center" ss:Horizontal="Center"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="14" ss:Color="#FFFFFF" ss:Bold="1"/><Interior ss:Color="#1F3864" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpBand1"><Alignment ss:Vertical="Center" ss:Horizontal="Left"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF" ss:Bold="1"/><Interior ss:Color="#1F3864" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpBand2"><Alignment ss:Vertical="Center" ss:Horizontal="Left"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF" ss:Bold="1"/><Interior ss:Color="#C55A11" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpHdr1"><Alignment ss:Vertical="Center" ss:Horizontal="Center" ss:WrapText="1"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF" ss:Bold="1"/><Interior ss:Color="#2F5597" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpHdr2"><Alignment ss:Vertical="Center" ss:Horizontal="Center" ss:WrapText="1"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF" ss:Bold="1"/><Interior ss:Color="#ED7D31" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpRow1"><Alignment ss:Vertical="Center"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/><Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpRow1C"><Alignment ss:Vertical="Center" ss:Horizontal="Center"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/><Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpRow1N"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/><Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/><NumberFormat ss:Format="#,##0"/></Style>
        <Style ss:ID="rcpRow1D"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/><Interior ss:Color="#DDEBF7" ss:Pattern="Solid"/><NumberFormat ss:Format="#,##0.000"/></Style>
        <Style ss:ID="rcpRow2"><Alignment ss:Vertical="Center"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/><Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpRow2C"><Alignment ss:Vertical="Center" ss:Horizontal="Center"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/><Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpRow2N"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/><Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/><NumberFormat ss:Format="#,##0"/></Style>
        <Style ss:ID="rcpRow2D"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/><Interior ss:Color="#FCE4D6" ss:Pattern="Solid"/><NumberFormat ss:Format="#,##0.000"/></Style>
        <Style ss:ID="rcpSub"><Alignment ss:Vertical="Center"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000" ss:Bold="1"/><Interior ss:Color="#FFF2CC" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpSubL"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000" ss:Bold="1"/><Interior ss:Color="#FFF2CC" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpSubN"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000" ss:Bold="1"/><Interior ss:Color="#FFF2CC" ss:Pattern="Solid"/><NumberFormat ss:Format="#,##0"/></Style>
        <Style ss:ID="rcpSubD"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000" ss:Bold="1"/><Interior ss:Color="#FFF2CC" ss:Pattern="Solid"/><NumberFormat ss:Format="#,##0.000"/></Style>
        <Style ss:ID="rcpTot"><Alignment ss:Vertical="Center"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000" ss:Bold="1"/><Interior ss:Color="#FFD966" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpTotL"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000" ss:Bold="1"/><Interior ss:Color="#FFD966" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpTotN"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000" ss:Bold="1"/><Interior ss:Color="#FFD966" ss:Pattern="Solid"/><NumberFormat ss:Format="#,##0"/></Style>
        <Style ss:ID="rcpTotD"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#000000" ss:Bold="1"/><Interior ss:Color="#FFD966" ss:Pattern="Solid"/><NumberFormat ss:Format="#,##0.000"/></Style>
        <Style ss:ID="rcpEca"><Alignment ss:Vertical="Center"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#006100" ss:Bold="1"/><Interior ss:Color="#C6EFCE" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpEcaL"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#006100" ss:Bold="1"/><Interior ss:Color="#C6EFCE" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpEcaN"><Alignment ss:Vertical="Center" ss:Horizontal="Right"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#006100" ss:Bold="1"/><Interior ss:Color="#C6EFCE" ss:Pattern="Solid"/><NumberFormat ss:Format="#,##0"/></Style>
        <Style ss:ID="rcpHTitle"><Alignment ss:Vertical="Center" ss:Horizontal="Center"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="16" ss:Color="#FFFFFF" ss:Bold="1"/><Interior ss:Color="#1F3864" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpHSec"><Alignment ss:Vertical="Center" ss:Horizontal="Left"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12" ss:Color="#FFFFFF" ss:Bold="1"/><Interior ss:Color="#1F3864" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpHLbl"><Alignment ss:Vertical="Center" ss:Horizontal="Left"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#1F3864" ss:Bold="1"/><Interior ss:Color="#D9E1F2" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpHVal"><Alignment ss:Vertical="Center" ss:Horizontal="Left"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/><Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/></Style>
        <Style ss:ID="rcpHKey"><Alignment ss:Vertical="Center" ss:Horizontal="Center"/><Borders><Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/><Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#BFBFBF"/></Borders><Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="14" ss:Color="#000000" ss:Bold="1"/><Interior ss:Color="#E2EFDA" ss:Pattern="Solid"/></Style>
      </Styles>
      
      <Worksheet>
        <xsl:attribute name="ss:Name">DOSSIER IMPORT AERIEN</xsl:attribute>
        <Table>
          <Column ss:AutoFitWidth="0" ss:Width="80"/>
          <Column ss:AutoFitWidth="0" ss:Width="85"/>
          <Column ss:AutoFitWidth="0" ss:Width="200"/>
          <Column ss:AutoFitWidth="0" ss:Width="180"/>
          <Column ss:AutoFitWidth="0" ss:Width="110"/>
          <Column ss:AutoFitWidth="0" ss:Width="60"/>
          <Column ss:AutoFitWidth="0" ss:Width="55"/>
          <Column ss:AutoFitWidth="0" ss:Width="60"/>
          <Column ss:AutoFitWidth="0" ss:Width="60"/>
          <Column ss:AutoFitWidth="0" ss:Width="65"/>
          <Column ss:AutoFitWidth="0" ss:Width="70"/>
          <Column ss:AutoFitWidth="0" ss:Width="70"/>
          <Column ss:AutoFitWidth="0" ss:Width="45"/>
          <Column ss:AutoFitWidth="0" ss:Width="65"/>
          <Column ss:AutoFitWidth="0" ss:Width="90"/>
          <Column ss:AutoFitWidth="0" ss:Width="80"/>
          <Column ss:AutoFitWidth="0" ss:Width="75"/>
          <xsl:for-each select="//NewDataSet/TableHdr">
            <Row ss:Height="26">
              <Cell ss:MergeAcross="16" ss:StyleID="rcpHTitle"><Data ss:Type="String"><xsl:choose><xsl:when test="MODE = 'a' or MODE = 'A'">DOSSIER IMPORT AERIEN</xsl:when><xsl:otherwise>DOSSIER IMPORT MARITIME</xsl:otherwise></xsl:choose>   |   MP CARGO FRANCE - LILLE LESQUIN</Data></Cell>
            </Row>
            <Row ss:Height="6"/>
          <Row ss:Height="20">
            <Cell ss:StyleID="rcpHLbl"><Data ss:Type="String">CONSOLE No.</Data></Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="rcpHKey"><Data ss:Type="String"><xsl:value-of select="CONSOLENO"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String"><xsl:choose><xsl:when test="MODE = 'a' or MODE = 'A'">AIRLINE</xsl:when><xsl:otherwise>SHIPPING LINE</xsl:otherwise></xsl:choose></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:choose><xsl:when test="MODE = 'a' or MODE = 'A'"><xsl:value-of select="AIRLINE"/></xsl:when><xsl:otherwise><xsl:value-of select="SHIPLINE"/></xsl:otherwise></xsl:choose></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String"><xsl:choose><xsl:when test="MODE = 'a' or MODE = 'A'">VOL / FLIGHT</xsl:when><xsl:otherwise>VESSEL</xsl:otherwise></xsl:choose></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="FLIGHTNO"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">VIA</Data></Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="VIA"/></Data></Cell>
          </Row>
          <Row ss:Height="20">
            <Cell ss:StyleID="rcpHLbl"><Data ss:Type="String"><xsl:choose><xsl:when test="MODE = 'a' or MODE = 'A'">MAWB No.</xsl:when><xsl:otherwise>MBL No.</xsl:otherwise></xsl:choose></Data></Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="rcpHKey"><Data ss:Type="String"><xsl:choose><xsl:when test="MODE = 'a' or MODE = 'A'"><xsl:value-of select="MAWBNO"/></xsl:when><xsl:otherwise><xsl:value-of select="MBLNO"/></xsl:otherwise></xsl:choose></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">DEPART</Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="DEPART"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">ARRIVEE</Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="ARRIVEE"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">FREIGHT</Data></Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="FREIGHT"/></Data></Cell>
          </Row>
            <Row ss:Height="6"/>
            <Row ss:Height="20">
              <Cell ss:MergeAcross="16" ss:StyleID="rcpHSec"><Data ss:Type="String">ARRIVEE</Data></Cell>
            </Row>
          <Row ss:Height="20">
            <Cell ss:StyleID="rcpHLbl"><Data ss:Type="String">E.T.D.</Data></Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="ETD"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">E.T.A.</Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="ETA"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">ARRIVEE REELLE</Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="ARRIVEE_REELLE"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">MADT</Data></Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="MADT"/></Data></Cell>
          </Row>
          <Row ss:Height="20">
            <Cell ss:StyleID="rcpHLbl"><Data ss:Type="String">PKGS</Data></Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="PKGS"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">GRWT (kgs)</Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="GRWT"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">VOLUME (m3)</Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="VOLUME"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">CHBL.WT</Data></Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="CHBLWT"/></Data></Cell>
          </Row>
          <Row ss:Height="20">
            <Cell ss:StyleID="rcpHLbl"><Data ss:Type="String">DOSSIER DOUANE</Data></Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="DOSSIER_DOUANE"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">MAGASIN</Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="MAGASIN"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String">CNEE</Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHVal"><Data ss:Type="String"><xsl:value-of select="CNEE"/></Data></Cell>
            <Cell ss:MergeAcross="1" ss:StyleID="rcpHLbl"><Data ss:Type="String"></Data></Cell>
            <Cell ss:MergeAcross="2" ss:StyleID="rcpHVal"><Data ss:Type="String"></Data></Cell>
          </Row>
          </xsl:for-each>

          <!--< START CARGO MANIFEST="" >-->
          <Row ss:Height="18">
            <Cell ss:MergeAcross="16" ss:StyleID="rcpTitle">
              <Data ss:Type="String">CARGO MANIFEST - REGROUPE PAR SITE DE LIVRAISON</Data>
            </Cell>
          </Row>

          <xsl:for-each select="//NewDataSet/Table2">
            <!-- ROWTYPE: D detail, G group header, S sous-total, T total console,
                 E ecart. GROUPIDX is the 1-based delivery-site number and the
                 palette alternates on it. Both come from
                 ImportfraController.BuildReceptionManifest. -->
            <xsl:variable name="odd" select="(number(GROUPIDX) mod 2) = 1"/>
            <xsl:variable name="band"><xsl:choose><xsl:when test="$odd">rcpBand1</xsl:when><xsl:otherwise>rcpBand2</xsl:otherwise></xsl:choose></xsl:variable>
            <xsl:variable name="hs"><xsl:choose><xsl:when test="$odd">rcpHdr1</xsl:when><xsl:otherwise>rcpHdr2</xsl:otherwise></xsl:choose></xsl:variable>
            <xsl:variable name="rs"><xsl:choose><xsl:when test="$odd">rcpRow1</xsl:when><xsl:otherwise>rcpRow2</xsl:otherwise></xsl:choose></xsl:variable>
            <xsl:variable name="rc"><xsl:choose><xsl:when test="$odd">rcpRow1C</xsl:when><xsl:otherwise>rcpRow2C</xsl:otherwise></xsl:choose></xsl:variable>
            <xsl:variable name="rn"><xsl:choose><xsl:when test="$odd">rcpRow1N</xsl:when><xsl:otherwise>rcpRow2N</xsl:otherwise></xsl:choose></xsl:variable>
            <xsl:variable name="rd"><xsl:choose><xsl:when test="$odd">rcpRow1D</xsl:when><xsl:otherwise>rcpRow2D</xsl:otherwise></xsl:choose></xsl:variable>
            <xsl:choose>
              <xsl:when test="ROWTYPE = 'G'">
                <Row ss:Height="6"/>
                <Row ss:Height="20">
                  <Cell ss:MergeAcross="16" ss:StyleID="{$band}">
                    <Data ss:Type="String"><xsl:value-of select="GROUPLABEL"/></Data>
                  </Cell>
                </Row>
                <Row ss:Height="28">
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">JOB NO</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">HAWB NO</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">SHPR</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">CNEE</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">P/O</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">PCS</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">CTNS</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">GRWT</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">VOL</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">CHBL.WT</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">DELV.DT</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">CTNS RECUS</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">PAL</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">TYPE PAL</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">RESERVES</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">BON MAG DU</Data></Cell>
                  <Cell ss:StyleID="{$hs}"><Data ss:Type="String">PACK</Data></Cell>
                </Row>
              </xsl:when>
              <xsl:when test="ROWTYPE = 'S' or ROWTYPE = 'T'">
            <xsl:variable name="ls"><xsl:choose><xsl:when test="ROWTYPE = 'T'">rcpTotL</xsl:when><xsl:otherwise>rcpSubL</xsl:otherwise></xsl:choose></xsl:variable>
            <xsl:variable name="ns"><xsl:choose><xsl:when test="ROWTYPE = 'T'">rcpTotN</xsl:when><xsl:otherwise>rcpSubN</xsl:otherwise></xsl:choose></xsl:variable>
            <xsl:variable name="ds"><xsl:choose><xsl:when test="ROWTYPE = 'T'">rcpTotD</xsl:when><xsl:otherwise>rcpSubD</xsl:otherwise></xsl:choose></xsl:variable>
            <xsl:variable name="bs"><xsl:choose><xsl:when test="ROWTYPE = 'T'">rcpTot</xsl:when><xsl:otherwise>rcpSub</xsl:otherwise></xsl:choose></xsl:variable>
                <Row ss:Height="18">
                  <Cell ss:MergeAcross="4" ss:StyleID="{$ls}">
                    <Data ss:Type="String"><xsl:value-of select="GROUPLABEL"/></Data>
                  </Cell>
                  <Cell ss:StyleID="{$ns}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(NOOFPCS) != '' and string(number(normalize-space(NOOFPCS))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(NOOFPCS))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="NOOFPCS"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$ns}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(ORDERPKGS) != '' and string(number(normalize-space(ORDERPKGS))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(ORDERPKGS))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="ORDERPKGS"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$ns}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(WEIGHT) != '' and string(number(normalize-space(WEIGHT))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(WEIGHT))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="WEIGHT"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$ds}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(VOLUME) != '' and string(number(normalize-space(VOLUME))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(VOLUME))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="VOLUME"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$ns}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(CHBLWT) != '' and string(number(normalize-space(CHBLWT))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(CHBLWT))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="CHBLWT"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$bs}"><Data ss:Type="String"></Data></Cell>
                  <Cell ss:StyleID="{$ns}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(CTNS_RECUS) != '' and string(number(normalize-space(CTNS_RECUS))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(CTNS_RECUS))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="CTNS_RECUS"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$ns}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(PAL) != '' and string(number(normalize-space(PAL))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(PAL))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="PAL"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:MergeAcross="3" ss:StyleID="{$bs}"><Data ss:Type="String"></Data></Cell>
                </Row>
              </xsl:when>
              <xsl:when test="ROWTYPE = 'E'">
                <Row ss:Height="18">
                  <Cell ss:MergeAcross="5" ss:StyleID="rcpEcaL">
                    <Data ss:Type="String"><xsl:value-of select="GROUPLABEL"/></Data>
                  </Cell>
                  <Cell ss:StyleID="rcpEcaN">
                    <xsl:choose>
                      <xsl:when test="normalize-space(ORDERPKGS) != '' and string(number(normalize-space(ORDERPKGS))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(ORDERPKGS))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="ORDERPKGS"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:MergeAcross="9" ss:StyleID="rcpEca"><Data ss:Type="String"><xsl:value-of select="ECARTNOTE"/></Data></Cell>
                </Row>
              </xsl:when>
              <xsl:otherwise>
                <Row ss:AutoFitHeight="1">
                  <Cell ss:StyleID="{$rc}"><Data ss:Type="String"><xsl:value-of select="JOBNO"/></Data></Cell>
                  <Cell ss:StyleID="{$rc}"><Data ss:Type="String"><xsl:value-of select="HAWBNO"/></Data></Cell>
                  <Cell ss:StyleID="{$rs}"><Data ss:Type="String"><xsl:value-of select="SHPR"/></Data></Cell>
                  <Cell ss:StyleID="{$rs}"><Data ss:Type="String"><xsl:value-of select="IMPR"/></Data></Cell>
                  <Cell ss:StyleID="{$rs}"><Data ss:Type="String"><xsl:call-template name="JoinLinesWithBreak"><xsl:with-param name="text" select="normalize-space(ORDERNO)"/><xsl:with-param name="delim" select="' '"/></xsl:call-template></Data></Cell>
                  <Cell ss:StyleID="{$rn}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(NOOFPCS) != '' and string(number(normalize-space(NOOFPCS))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(NOOFPCS))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:call-template name="JoinLinesWithBreak"><xsl:with-param name="text" select="normalize-space(NOOFPCS)"/><xsl:with-param name="delim" select="' '"/></xsl:call-template></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$rn}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(ORDERPKGS) != '' and string(number(normalize-space(ORDERPKGS))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(ORDERPKGS))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:call-template name="JoinLinesWithBreak"><xsl:with-param name="text" select="normalize-space(ORDERPKGS)"/><xsl:with-param name="delim" select="' '"/></xsl:call-template></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$rn}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(WEIGHT) != '' and string(number(normalize-space(WEIGHT))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(WEIGHT))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="WEIGHT"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$rd}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(VOLUME) != '' and string(number(normalize-space(VOLUME))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(VOLUME))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="VOLUME"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$rn}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(CHBLWT) != '' and string(number(normalize-space(CHBLWT))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(CHBLWT))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="CHBLWT"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$rc}"><Data ss:Type="String"><xsl:value-of select="ACTDELVDT"/></Data></Cell>
                  <Cell ss:StyleID="{$rn}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(CTNS_RECUS) != '' and string(number(normalize-space(CTNS_RECUS))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(CTNS_RECUS))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="CTNS_RECUS"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$rn}">
                    <xsl:choose>
                      <xsl:when test="normalize-space(PAL) != '' and string(number(normalize-space(PAL))) != 'NaN'">
                        <Data ss:Type="Number"><xsl:value-of select="number(normalize-space(PAL))"/></Data>
                      </xsl:when>
                      <xsl:otherwise><Data ss:Type="String"><xsl:value-of select="PAL"/></Data></xsl:otherwise>
                    </xsl:choose>
                  </Cell>
                  <Cell ss:StyleID="{$rc}"><Data ss:Type="String"><xsl:value-of select="TYPE_PAL"/></Data></Cell>
                  <Cell ss:StyleID="{$rc}"><Data ss:Type="String"><xsl:value-of select="RESERVES"/></Data></Cell>
                  <Cell ss:StyleID="{$rc}"><Data ss:Type="String"><xsl:value-of select="BON_MAG_DU"/></Data></Cell>
                  <Cell ss:StyleID="{$rc}"><Data ss:Type="String"><xsl:value-of select="PACK"/></Data></Cell>
                </Row>
              </xsl:otherwise>
            </xsl:choose>
          </xsl:for-each>

          <Row ss:Height="15.75">
            <Cell ss:MergeAcross="10" ss:StyleID="m2142900963748">
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
              <Cell ss:MergeAcross="3" ss:StyleID="m2142719795744"/>
            </Row>
          </xsl:for-each>

          <Row ss:Height="15.75">
            <Cell ss:MergeAcross="10" ss:StyleID="m2142890316708">
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
              <Cell ss:MergeAcross="3" ss:StyleID="m2142890316768">
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
              <Cell ss:MergeAcross="3" ss:StyleID="m2142890316828">
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
              <Cell ss:MergeAcross="3" ss:StyleID="m2142890315064">
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
              <Cell ss:MergeAcross="3" ss:StyleID="m2142890315124"/>
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
              <Cell ss:MergeAcross="3" ss:StyleID="m2142890315480"/>
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
              <Cell ss:MergeAcross="3" ss:StyleID="m2142890315540"/>
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
              <Cell ss:MergeAcross="3" ss:StyleID="m2142890302168"/>
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
              <Cell ss:MergeAcross="3" ss:StyleID="m2142890302228"/>
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
              <Cell ss:StyleID="s927">
                <Data ss:Type="String">Shipping Line invoice</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s928">
                <Data ss:Type="String">
                  <xsl:value-of select="SHPLINE_INVDT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s924"/>
              <Cell ss:MergeAcross="3" ss:StyleID="m2142890308616"/>
            </Row>
            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:StyleID="s1309">
                <Data ss:Type="String">Payment of Shipping Line invoicel</Data>
              </Cell>
              <Cell ss:MergeAcross="1" ss:StyleID="s926">
                <Data ss:Type="String">
                  <xsl:value-of select="PAYMT_SHPLINE_INVDT" disable-output-escaping="yes"/>
                </Data>
              </Cell>
              <Cell ss:StyleID="s927"/>
              <Cell ss:MergeAcross="1" ss:StyleID="s928"/>
              <Cell ss:StyleID="s924"/>
              <Cell ss:MergeAcross="3" ss:StyleID="m2142890308616"/>
            </Row>


            <Row ss:AutoFitHeight="0" ss:Height="15.75">
              <Cell ss:MergeAcross="10" ss:StyleID="m2142900963808"/>
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
              <Cell ss:MergeAcross="3" ss:StyleID="s1346"/>
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
              <Cell ss:MergeAcross="3" ss:StyleID="s1348">
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
              <Cell ss:MergeAcross="3" ss:StyleID="s1352"/>
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
              <Cell ss:MergeAcross="5" ss:StyleID="s78">
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

