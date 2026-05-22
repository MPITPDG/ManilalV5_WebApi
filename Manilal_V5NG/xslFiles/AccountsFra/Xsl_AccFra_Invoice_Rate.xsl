<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <HEAD>
      <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
    </HEAD>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
      <xsl:for-each select="//NewDataSet/Table ">
        <xsl:variable name="CONCODE" select="CONCODE"></xsl:variable>
        <tr class="DataGridFixedHeader">
          <td nowrap="1" class="header">Account Name</td>
          <td nowrap="1" class="header">Invoice Currency</td>
          <td nowrap="1" class="header">Multi Rate</td>
          <td nowrap="1" class="header">Invoice Rate</td>
          <td nowrap="1" class="header">Inv Min Amt</td>

          <td nowrap="1" class="header" width="100px">Invoice Unit</td>
          <td nowrap="1" class="header" width="80px">Taxable</td>
          <td nowrap="1" class="header" width="100px">Applicable</td>
          <!--<xsl:if  test ="$CONCODE='C100024'">
            <td nowrap="1" class="header" width="100px">App. Country</td>
          </xsl:if>-->
          <td nowrap="1" class="header" width="80px">Effective From</td>
          <td nowrap="1" class="header" width="100px">Effective To</td>
          <td nowrap="1" class="header">Is min CW App</td>
          <td nowrap="1" class="header">Min CW</td>
        </tr>

        <xsl:for-each select="//NewDataSet/Table1">
          <xsl:variable name="PK_ID" select="PK_ID"></xsl:variable>
          <xsl:variable name="IS_MULTI_RATE" select="IS_MULTI_RATE"></xsl:variable>
          <tr class="summaryDetail">
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="ACCNAME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="INVOICE_CUR" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td>
              <xsl:if  test ="$IS_MULTI_RATE='1'">
                <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
                  <tr class="DataGridFixedHeader">
                    <td nowrap="1" class="header">Chrg Cond unit1</td>
                    <td nowrap="1" class="header">Chrg Cond unit2</td>
                    <td nowrap="1" class="header">Inv Rate</td>
                    <td nowrap="1" class="header">Unit</td>
                  </tr>
                  <xsl:for-each select="//NewDataSet/Table2">
                    <xsl:if  test ="$PK_ID=FK_ID">
                      <tr class="summaryDetail">
                        <td class="summaryDetail" NOWRAP="" align="left">
                          <xsl:value-of select="CHRG_COND_UNIT1" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail" NOWRAP="" align="left">
                          <xsl:value-of select="CHRG_COND_UNIT2" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail" NOWRAP="" align="left">
                          <xsl:value-of select="INVOICE_RATE" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail" NOWRAP="" align="left">
                          <xsl:value-of select="UNIT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                      </tr>
                    </xsl:if>
                  </xsl:for-each>
                </table>
              </xsl:if>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="INVOICE_RATE" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="INV_MIN_AMT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="INVOICE_UNIT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="right">
              <xsl:value-of select="TAXABLE" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="right">
              <xsl:value-of select="APPLICABLE" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <!--<xsl:if  test ="$CONCODE='C100024'">
              <td class="summaryDetail" NOWRAP="" align="right">
                <xsl:value-of select="COUNTRY_NAME1" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </xsl:if>-->
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="EFFECT_FRM_DT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="EFFECT_TO_DT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="IS_MIN_WT_APP" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="MIN_CW" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
          </tr>
        </xsl:for-each>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="12" class="foot">
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
