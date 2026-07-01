<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="100%">
      <xsl:for-each select="//NewDataSet/Table">
        <tr class="DataGridFixedHeader">
          <td colspan="20">
            <xsl:value-of select="HEADER"/>
          </td>
        </tr>
      </xsl:for-each>
			<tr class="DataGridFixedHeader">			 
				<!--<td nowrap="1" width="100px" class="header">CODE </td>-->
				<td nowrap="1" width="100px" class="header">CLIENT NAME </td>
				<td nowrap="1" width="150px" class="header">CLIENT STATUS </td>
				<td nowrap="1" width="100px" class="header">FOLLOW UP ASSIGNED TO</td>
				<td nowrap="1" width="100px" class="header">ASSIGNED ON</td>
				<td nowrap="1" width="100px" class="header">RECEIVABLE AS ON</td>
				<td nowrap="1" width="100px" class="header">LESS THAN 30 DAYS</td>
				<td nowrap="1" width="150px" class="header">31 TO 60 DAYS</td>
				<td nowrap="1" width="100px" class="header"> 61 TO 90 DAYS</td>
				<td nowrap="1" width="100px" class="header">91 TO 120 DAYS</td>
      	<td nowrap="1" width="100px" class="header">120 TO 180 DAYS</td>
				<td nowrap="1" width="100px" class="header">181 to 365 Days</td>
				<td nowrap="1" width="150px" class="header">1 TO 2 Years</td>
				<td nowrap="1" width="100px" class="header">2 TO 3 Years</td>
				<td nowrap="1" width="100px" class="header">MORE THAN 3 Year</td>
         
				<td nowrap="1" width="100px" class="header">TOTAL OF ALL INVOICES OUTSTANDING</td>
				<td nowrap="1" width="150px" class="header">LESS : UNADJUSTED RECEIPTS</td>
			 
				<td nowrap="1" width="100px" class="header">ADVANCE PAID ON BEHALF</td>
         <td nowrap="1" width="100px" class="header">INVOICE CITY</td>
				 
			</tr>

			<xsl:for-each select="//NewDataSet/Table1">
				<tr class="summaryDetail">			
					<!--<td class="summaryDetail" NOWRAP="" align="right">
					 <xsl:value-of select="ACCTCODE"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>-->
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="ACCTNAME"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					 	<td class="summaryDetail" NOWRAP="" align="left">
						  <xsl:value-of select="CLIENT_STATUS"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						  <xsl:value-of select="FOLLOW_ASSIGNED_TO"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">

					 <xsl:value-of select="ASSIGNED_ON"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td> 
					<td class="summaryDetail" NOWRAP="" align="left">
						  <xsl:value-of select="RECEIVABLE_AS_ON"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>          
        <td class="summaryDetail" NOWRAP="" align="right">
					 <xsl:value-of select="DAYS_000_030"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="DAYS_031_060"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						  <xsl:value-of select="DAYS_061_090"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						  <xsl:value-of select="DAYS_091_120"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">

					 <xsl:value-of select="DAYS_121_180"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						  <xsl:value-of select="DAYS_181_365"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>

        
      <td class="summaryDetail" NOWRAP="" align="right">
					 <xsl:value-of select="DAYS_366_730"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="right">
						<xsl:value-of select="DAYS_731_1095"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						  <xsl:value-of select="DAYS_1096_9999"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						  <xsl:value-of select="INVOICES_OUTSTANDING"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">

					 <xsl:value-of select="ADVANCE"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
					<td class="summaryDetail" NOWRAP="" align="left">
						  <xsl:value-of select="ADVANCE_PAIDBYUS"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
        <td class="summaryDetail" NOWRAP="" align="left">
						  <xsl:value-of select="CITYNAME"/>
						<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
					</td>
				</tr>
			</xsl:for-each>
			<tr valign="top">
				<td colspan="20" class="foot">
					<xsl:if test="count(//NewDataSet/Table1)!=1">
						<xsl:value-of select="count(//NewDataSet/Table1)"/> Records
					</xsl:if>
					<xsl:if test="count(//NewDataSet/Table1)=1">
						1 Record
					</xsl:if>
				</td>
			</tr>
		</table>
	</xsl:template>
</xsl:stylesheet>
