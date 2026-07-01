<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="100%">
      <tr class="DataGridFixedHeader">
        <xsl:if test="count(//NewDataSet/Table1)!=0">
          <xsl:for-each select="//NewDataSet/Table1">
            <xsl:choose>
              <xsl:when test="AUTHORISATIONSTATUS='V'">
                <!--<td nowrap="1" width="70px" class="header" >GENERATE</td>-->
                <td nowrap="1" width="70px" class="header" >VIEW</td>
              </xsl:when>
            </xsl:choose>
          </xsl:for-each>
        </xsl:if>
        <td nowrap="1" width="100px" class="header">STATUS</td>
        <td nowrap="1" width="80px" class="header">MAWB NO</td>
        <td nowrap="1" width="80px" class="header">MAWB DATE</td>
        <td nowrap="1" width="100px" class="header">SUPPLIER</td>
        <td nowrap="1" width="80px" class="header">FRT AMT</td>
        <td nowrap="1" width="90px" class="header">SURCHARGES</td>
        <td nowrap="1" width="100px" class="header">AIR FRT COMM</td>
        <td nowrap="1" width="90px" class="header">FRT REBATE</td>
        <td nowrap="1" width="90px" class="header">AMOUNT</td>
      </tr>

      <xsl:for-each select="//NewDataSet/Table">
        <tr class="summaryDetail">
          <xsl:choose>
            <xsl:when test="AUTHORISATIONSTATUS='V'">
              <xsl:choose>
                <xsl:when test="PSTATUS='MREQ'">
                  <!--<td class="summaryDetail"  align="center" >
										<img src="../../include/img/generate.gif" class="cur"  onclick="parent.fnGenerate_PURCHASE_MAWB_Code_MANUALLY('{MAWBNO}','{PSTATUS}','{AUTHORISATIONSTATUS}','{ACCESSFROMDT}','{ENDDATE}','{FORMID}','{FREIGHTAMT}','{SURCHARGES}','{SUP_CODE}')" alt="Generate Purchase from MAWB No. {MAWBNO}"/>
									</td>-->
                  <td class="summaryDetail"  align="center" >
                    <img src="../../include/img/view-mo.gif" class="cur"  onclick="parent.fnView_MAWB_Purchase_Request_Cal('{ID}','{MAWBNO}','{PSTATUS}','{ISVALIDATE}','{MSG}')" alt="View Purchase from MAWB No. {MAWBNO}"/>
                  </td>
                </xsl:when>
              </xsl:choose>
            </xsl:when>
          </xsl:choose>

          <td class="summaryDetail" NOWRAP="" align="right">
            <xsl:value-of select="AUTHORISESTATUS" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>

          <td class="summaryDetail" NOWRAP="" align="left">
            <label runat="server" class="cur" onclick="parent.fnView_MAWB_Request('{ID}','{MAWBNO}','{EXPTNO}','{PSTATUS}')" title="View MAWB Purchase Request {MAWBNO}" >
              <a href="#{MAWBNO}">
                <xsl:value-of select="MAWBNO" />
              </a>
            </label>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" style="text-align:left;">
            <xsl:value-of select="MAWBDATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" style="text-align:left;">
            <xsl:value-of select="SUP_NAME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" style="text-align:right;">
            <xsl:value-of select="FREIGHTAMT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" style="text-align:right;">
            <xsl:value-of select="SURCHARGES" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" style="text-align:right;">
            <xsl:value-of select="AIRFREIGHTCOMMISSION" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" style="text-align:right;">
            <xsl:value-of select="FREIGHTREBATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" style="text-align:right;">
            <xsl:value-of select="AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>

        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="10" class="foot">
          <xsl:if test="count(//NewDataSet/Table)!=1">
            <xsl:value-of select="count(//NewDataSet/Table)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/Table)=1">
            1 Record
          </xsl:if>
        </td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>
