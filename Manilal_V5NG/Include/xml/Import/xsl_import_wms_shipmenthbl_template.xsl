<xsl:stylesheet version="1.0"
    xmlns="urn:schemas-microsoft-com:office:spreadsheet"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	xmlns:user="urn:my-scripts"
	xmlns:o="urn:schemas-microsoft-com:office:office"
	xmlns:x="urn:schemas-microsoft-com:office:excel"
	xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet" >
    <ExcelWorkbook xmlns="urn:schemas-microsoft-com:office:excel">
        <WindowHeight>9630</WindowHeight>
        <WindowWidth>21600</WindowWidth>
        <WindowTopX>0</WindowTopX>
        <WindowTopY>0</WindowTopY>
        <ActiveSheet>2</ActiveSheet>
        <ProtectStructure>False</ProtectStructure>
        <ProtectWindows>False</ProtectWindows>
    </ExcelWorkbook>

    <xsl:template match="NewDataSet">
        <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
            xmlns:o="urn:schemas-microsoft-com:office:office"
            xmlns:x="urn:schemas-microsoft-com:office:excel"
            xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
            xmlns:html="http://www.w3.org/TR/REC-html150">


            <Styles>
                <Style ss:ID="Default" ss:Name="Normal">
                    <Alignment ss:Vertical="Bottom"/>
                    <Borders/>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
                    <Interior/>
                    <NumberFormat/>
                    <Protection/>
                </Style>
              <Style ss:ID="s24">
                <Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="0"/>
                <Borders>
                  <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                </Borders>
                <NumberFormat ss:Format="Standard"/>
              </Style>
          
          
                <Style ss:ID="s67">
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
                     ss:Bold="1"/>
                </Style>
                <Style ss:ID="s68">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s69">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    
                    </Borders>
                
                
                </Style>
                <Style ss:ID="s70">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <NumberFormat ss:Format="Short Date"/>
                </Style>
                <Style ss:ID="s71">
                    <Alignment ss:Vertical="Bottom" ss:WrapText="1"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                  <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="12"
                ss:Bold="1"/>
                </Style>
                <Style ss:ID="s72">
                  <Alignment ss:Horizontal="Right" ss:Vertical="Bottom" ss:WrapText="0"/>
                   <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
                     ss:Bold="1"/>
                </Style>
                <Style ss:ID="s73">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                </Style>
                <Style ss:ID="s74">
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <NumberFormat ss:Format="Short Date"/>
                </Style>
                <Style ss:ID="s150">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s82">
                    <Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
                    <Borders>
                        <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                        <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                    </Borders>
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
                    <Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
                </Style>
                <Style ss:ID="s84">
                    <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Bold="1"/>
                    <Interior/>
                </Style>
				<Style ss:ID="s86">
					<Alignment ss:Horizontal="Center" ss:Vertical="Bottom"/>
					<Borders>
						<Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
						<Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
					</Borders>
					<Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFFFFF"
                     ss:Bold="1"/>
					<Interior ss:Color="#2F75B5" ss:Pattern="Solid"/>
				</Style>

              <Style ss:ID="sGreenStyle">
                <Borders>
                  <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                </Borders>
                <!--<Font ss:Color="#00FF00"/>-->
                <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#046307" ss:Bold="1"/>
                <!-- Green color -->

              </Style>
              <Style ss:ID="sRedStyle">
                <Borders>
                  <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                </Borders>
                <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FF0000" ss:Bold="1"/>

              </Style>
              <Style ss:ID="sYellowStyle">
                <Borders>
                  <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1"/>
                  <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1"/>
                </Borders>
                <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#FFCC00" ss:Bold="1"/>

              </Style>
              <Style ss:ID="sDefaultStyle">
                <Font ss:Color="#000000"/>

              </Style>
              <Style ss:ID="sBlank">
                <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
              </Style>
            </Styles>
          <Worksheet ss:Name="{worksheetName}">
                <xsl:for-each select="//NewDataSet/Table">
                
                    <Table>
                      <Column ss:Width="100"/>
                      <Column ss:Width="40"/>
                      <Column ss:Width="300"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="60"/>
                     <Column ss:Width="60"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="60"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
                      <Column ss:Width="150"/>
               
                              
                        <Row ss:AutoFitHeight="0" ss:StyleID="s67">
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Invoice No.</Data>
                          </Cell>
                           
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Item No.</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Product Description</Data>
                            </Cell>
                       
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Qty</Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                                <Data ss:Type="String">Qty Unit</Data>
                            </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Unit Price</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Part No.</Data>
                          </Cell>

                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Item Type</Data>
                          </Cell>
                           <Cell ss:StyleID="s68">
                            <Data ss:Type="String">RITC</Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                            <Data ss:Type="String">CTH</Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                            <Data ss:Type="String">BCD Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">BCD Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Edu. Cess Notn.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Edu. Cess Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Sec &amp;  Higher Ed. Cess Notn.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Sec &amp;  Higher Ed. Cess Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">AID Cess Notn.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">AID Cess Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Social Welfare Surcharge Notn.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Social Welfare Surcharge Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Custom Health Cess Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Custom Health Cess Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">IGST Notn.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">IGST Notn Sr No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Compensation Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Compensation Sr No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">IGST Exemption Flag</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">IGST Exemption Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">IGST Exemption Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">GST Comp Cess Exmp Flag</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">GST Comp Cess Exmp Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">GST Comp Cess Exmp Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">CETH</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">MRP Status</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">RSP Notification No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">RSP Notification SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">MRP Amount</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">General Description</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Accessories</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Accessories Status</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Brand</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Model</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">End Use</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Country of Origin</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Policy Para No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Policy Para Year</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Manufacturer Name</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Manufacturer Address</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Manufacturer Country</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Exim Scheme</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Scheme Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Scheme Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Duty Exemption</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Licence Registration No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Licence Registration Date</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Licence No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Licence Date</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Licence Item SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Licence Port</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Licence CIF Value</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Licence Debit Duty Amt</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Aggregate Duty Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Aggregate Duty Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SAPTA Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SAPTA Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Excise GSI Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Excise GSI Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Excise SAD Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Excise SAD Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Excise TTA Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Excise TTA Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Road and Infra Cess Notn.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Road and Infra Cess SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Re-Import SB No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Re-Import SB Date</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Re-Import Port of Export</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Re-Import Invoice Sr. No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Re-Import Item Sr. No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Re-Import Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Re-Import Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Re-Import Export Freight Amt</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">ReRe-Import Export Insurance Amt</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Anti-Dumping Notn No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Anti-Dumping Notn SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Item Sr No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">CTH Sr No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Supplier SrNo.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Anti-Dumping Method</Data>
                          </Cell>
                        
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Duty</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Anti-Dumping Qty</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Anti-Dumping Unit</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Constituent Sr. No.</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Constituent Element Name</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Constituent Element Code</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Constituent Percentage</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Constituent Yield Percentage</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">Active Ingredient (Y/N)</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Type1</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qualifier1</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Code1</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Text1</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qty1</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-QtyUnit1</Data>
                          </Cell>
                          
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Type2</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qualifier2</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Code2</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Text2</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qty2</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-QtyUnit2</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Type3</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qualifier3</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Code3</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Text3</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qty3</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-QtyUnit3</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Type4</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qualifier4</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Code4</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Text4</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qty4</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-QtyUnit4</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Type5</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qualifier5</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Code5</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Text5</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qty5</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-QtyUnit5</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Type6</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qualifier6</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Code6</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Text6</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qty6</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-QtyUnit6</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Type7</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qualifier7</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Code7</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Text7</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qty7</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-QtyUnit7</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Type8</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qualifier8</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Code8</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Text8</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qty8</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-QtyUnit8</Data>
                          </Cell>
                            <Cell ss:StyleID="s68">
                              <Data ss:Type="String">SW-Type9</Data>
                            </Cell>

                            <Cell ss:StyleID="s68">
                              <Data ss:Type="String">SW-Qualifier9</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                              <Data ss:Type="String">SW-Code9</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                              <Data ss:Type="String">SW-Text9</Data>
                            </Cell>
                            <Cell ss:StyleID="s68">
                              <Data ss:Type="String">SW-Qty9</Data>
                            </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-QtyUnit9</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Type10</Data>
                          </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-Qualifier10</Data>
                               </Cell>
                            <Cell ss:StyleID="s68">
                              <Data ss:Type="String">SW-Code10</Data>
                            </Cell>
                              <Cell ss:StyleID="s68">
                                <Data ss:Type="String">SW-Text10</Data>
                              </Cell>
                                <Cell ss:StyleID="s68">
                                  <Data ss:Type="String">SW-Qty10</Data>
                                </Cell>
                          <Cell ss:StyleID="s68">
                            <Data ss:Type="String">SW-QtyUnit10</Data>
                          </Cell>
                      
                        </Row>
                        <xsl:for-each select="//NewDataSet/Table1">
                          <xsl:variable name="currentInvoice" select="INVOICENO"/>
                          <xsl:variable name="nextInvoice" select="following-sibling::Table1[1]/INVOICENO"/>
                            <Row>

                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="INVOICENO"/>
                                </Data>
                              </Cell>
                                <!--<Cell ss:StyleID="s69">
                                    <Data ss:Type="Number">
                                        <xsl:value-of select="ID"/>
                                    </Data>
                                </Cell>-->
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="count(preceding-sibling::Table1[INVOICENO = current()/INVOICENO]) + 1"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="PRODDESC"/>
                                    </Data>
                                </Cell>
                       
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="QTY"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="QTYUNIT"/>
                                    </Data>
                                </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="UNITPRICE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="PARTNO"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="ITEMTYPE"/>
                                    </Data>
                                </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="RITC"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="CTH"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="BCDNOTNNO"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                        <xsl:value-of select="BCDNOTNSRNO"/>
                                    </Data>
                                </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EDUCESSNOTN"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EDUCESSNOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SECHIGHEREDCESSNOTN"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SECHIGHEREDCESSNOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="AIDCESSNOTN"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="AIDCESSNOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SOCIALWELFARESURCHARGENOTN"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SOCIALWELFARESURCHARGENOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="CUSTOMHEALTHCESSNOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="CUSTOMHEALTHCESSNOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="IGSTNOTN"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="IGSTNOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="COMPENSATIONNOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="COMPENSATIONSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="IGSTEXEMPTIONFLAG"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="IGSTEXEMPTIONNOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="IGSTEXEMPTIONNOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="GSTCOMPCESSEXMPFLAG"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="GSTCOMPCESSEXMPNOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="GSTCOMPCESSEXMPNOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="CETH"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="MRPSTATUS"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="RSPNOTIFICATIONNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="RSPNOTIFICATIONSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="MRPAMOUNT"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="GENERALDESCRIPTION"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ACCESSORIES"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="ACCESSORIESSTATUS"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="BRAND"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="MODEL"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ENDUSE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="COUNTRYOFORIGIN"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="POLICYPARANO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="POLICYPARAYEAR"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="MANUFACTURERNAME"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="MANUFACTURERADDRESS"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="MANUFACTURERCOUNTRY"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EXIMSCHEME"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SCHEMENOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SCHEMENOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="DUTYEXEMPTION"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="LICENCEREGISTRATIONNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="LICENCEREGISTRATIONDATE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="LICENCENO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="LICENCEDATE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="LICENCEITEMSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="LICENCEPORT"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="LICENCECIFVALUE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="LICENCEDEBITDUTYAMT"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="AGGREGATEDUTYNOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="AGGREGATEDUTYNOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SAPTANOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SAPTANOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EXCISEGSINOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EXCISEGSINOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EXCISESADNOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EXCISESADNOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EXCISETTANOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="EXCISETTANOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ROADANDINFRACESSNOTN"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ROADANDINFRACESSSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="REIMPORTSBNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="REIMPORTSBDATE"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="REIMPORTPORTOFEXPORT"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="REIMPORTINVOICESRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="REIMPORTITEMSRNO"/>
                                </Data>
                              </Cell>
                               <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="REIMPORTNOTNNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="REIMPORTNOTNSRNO"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="REIMPORTEXPORTFREIGHTAMT"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="Number">
                                  <xsl:value-of select="REIMPORTEXPORTINSURANCEAMT"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="ANTIDUMPINGNOTNNO"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                  <Data ss:Type="String">
                                    <xsl:value-of select="ANTIDUMPINGNOTNSRNO"/>
                                  </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                  <Data ss:Type="String">
                                    <xsl:value-of select="ITEMSRNO"/>
                                  </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                  <Data ss:Type="String">
                                    <xsl:value-of select="CTHSRNO"/>
                                  </Data>
                                </Cell>
                                  <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                      <xsl:value-of select="SUPPLIERSRNO"/>
                                    </Data>
                                  </Cell>
                                  <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                      <xsl:value-of select="ANTIDUMPINGMETHOD"/>
                                    </Data>
                                  </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="DUTY"/>
                                </Data>
                              </Cell>
                                  <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                      <xsl:value-of select="ANTIDUMPINGQTY"/>
                                    </Data>
                                  </Cell>
                                  <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                      <xsl:value-of select="ANTIDUMPINGUNIT"/>
                                    </Data>
                                  </Cell>
                                  <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                      <xsl:value-of select="CONSTITUENTSRNO"/>
                                    </Data>
                                  </Cell>
                                  <Cell ss:StyleID="s69">
                                    <Data ss:Type="String">
                                      <xsl:value-of select="CONSTITUENTELEMENTNAME"/>
                                    </Data>
                                  </Cell>
                                    <Cell ss:StyleID="s69">
                                      <Data ss:Type="String">
                                        <xsl:value-of select="CONSTITUENTELEMENTCODE"/>
                                      </Data>
                                    </Cell>
                                      <Cell ss:StyleID="s69">
                                        <Data ss:Type="String">
                                          <xsl:value-of select="CONSTITUENT"/>
                                        </Data>
                                      </Cell>
                                        <Cell ss:StyleID="s69">
                                          <Data ss:Type="String">
                                            <xsl:value-of select="CONSTITUENTYIELD"/>
                                          </Data>
                                        </Cell>
                                          <Cell ss:StyleID="s69">
                                            <Data ss:Type="String">
                                              <xsl:value-of select="ACTIVEINGREDIENT"/>
                                            </Data>
                                          </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTYPE1"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQUALIFIER1"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWCODE1"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTEXT1"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTY1"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTYUNIT1"/>
                                </Data>
                              </Cell>
                                          <Cell ss:StyleID="s69">
                                            <Data ss:Type="String">
                                              <xsl:value-of select="SWTYPE2"/>
                                            </Data>
                                          </Cell>
                                          <Cell ss:StyleID="s69">
                                            <Data ss:Type="String">
                                              <xsl:value-of select="SWQUALIFIER2"/>
                                            </Data>
                                          </Cell>
                                          <Cell ss:StyleID="s69">
                                            <Data ss:Type="String">
                                              <xsl:value-of select="SWCODE2"/>
                                            </Data>
                                          </Cell>
                                            <Cell ss:StyleID="s69">
                                              <Data ss:Type="String">
                                                <xsl:value-of select="SWTEXT2"/>
                                              </Data>
                                            </Cell>
                                              <Cell ss:StyleID="s69">
                                                <Data ss:Type="String">
                                                  <xsl:value-of select="SWQTY2"/>
                                                </Data>
                                              </Cell>
                                              <Cell ss:StyleID="s69">
                                                <Data ss:Type="String">
                                                  <xsl:value-of select="SWQTYUNIT2"/>
                                                </Data>
                                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTYPE3"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQUALIFIER3"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWCODE3"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTEXT3"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTY3"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTYUNIT3"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTYPE4"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQUALIFIER4"/>
                                </Data>
                              </Cell>
                                <Cell ss:StyleID="s69">
                                  <Data ss:Type="String">
                                    <xsl:value-of select="SWCODE4"/>
                                  </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                  <Data ss:Type="String">
                                    <xsl:value-of select="SWTEXT4"/>
                                  </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                  <Data ss:Type="String">
                                    <xsl:value-of select="SWQTY4"/>
                                  </Data>
                                </Cell>
                                <Cell ss:StyleID="s69">
                                  <Data ss:Type="String">
                                    <xsl:value-of select="SWQTYUNIT4"/>
                                  </Data>
                                </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTYPE5"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQUALIFIER5"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWCODE5"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTEXT5"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTY5"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTYUNIT5"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTYPE6"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQUALIFIER6"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWCODE6"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTEXT6"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTY6"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTYUNIT6"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTYPE7"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQUALIFIER7"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWCODE7"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTEXT7"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTY7"/>
                                </Data>

                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTYUNIT7"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTYPE8"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQUALIFIER8"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWCODE8"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTEXT8"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTY8"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTYUNIT8"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTYPE9"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQUALIFIER9"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWCODE9"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTEXT9"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTY9"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTYUNIT9"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTYPE10"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQUALIFIER10"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWCODE10"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWTEXT10"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTY10"/>
                                </Data>
                              </Cell>
                              <Cell ss:StyleID="s69">
                                <Data ss:Type="String">
                                  <xsl:value-of select="SWQTYUNIT10"/>
                                </Data>
                              </Cell>
                                         
                            </Row>
                          <xsl:if test="$currentInvoice != $nextInvoice">
                            <Row>
                              <Cell ss:MergeAcross="3" ss:StyleID="sBlank">
                                <Data ss:Type="String"></Data>
                              </Cell>
                            </Row>
                          </xsl:if>
                        </xsl:for-each>
                    </Table>
                </xsl:for-each>
              
            </Worksheet>
      
          
        </Workbook>
    </xsl:template>
</xsl:stylesheet>