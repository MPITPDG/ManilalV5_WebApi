<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="SummaryDetail" WIDTH="100%">
      <tr class="DataGridFixedHeader">
        <th class="locked" nowrap="1" width="5px" ></th>
        <th class="locked" nowrap="1"></th>
        <th class="locked" nowrap="1"></th>
        <th class="locked" nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
        <th nowrap="1" colspan="3" align="center">AIRFREIGHT</th>
        <th nowrap="1" colspan="3" align="center">FSC</th>
        <th nowrap="1" colspan="3" align="center">IRC</th>
        <th nowrap="1" colspan="3" align="center">XRAY</th>
        <th nowrap="1" colspan="2" align="center">FREIGHT IN INR</th>
        <th nowrap="1" colspan="3" align="center">FREIGHT IN EURO</th>
        <th nowrap="1" colspan="4" align="center">DESTINATION CHARGES</th>
        <th nowrap="1"></th>
        <th nowrap="1"></th>
      </tr>
      <tr class="DataGridFixedHeader">
        <th class="locked" nowrap="1" width="5px"></th>
        <th class="locked" nowrap="1">INVOICED</th>
        <th class="locked" nowrap="1">PO NUMBER</th>
        <th class="locked" nowrap="1">HAWB NO</th>
        <th nowrap="1">ORIGIN</th>
        <th nowrap="1">MAWB NO</th>
        <th nowrap="1">JOB NO</th>
        <th nowrap="1">CONSOLE NO.</th>
        <th nowrap="1">CONSOLE DATE</th>
        <th nowrap="1">ETA DATE</th>
        <th nowrap="1">ETD</th>
        <th nowrap="1">DELIVERY DATE</th>
        <th nowrap="1">SHIPPER</th>
        <th nowrap="1">INCOTERM</th>
        <th nowrap="1">PKGS</th>
        <th nowrap="1">G.WGT.</th>
        <th nowrap="1">CHBL</th>
        <th nowrap="1">CBM</th>
        <th nowrap="1">TAXABLE WEIGHT</th>
        <th nowrap="1">PAYABLEON</th>
        <th nowrap="1">RATE/KG</th>
        <th nowrap="1">RATE</th>
        <th nowrap="1">PAYABLEON</th>
        <th nowrap="1">RATE/KG</th>
        <th nowrap="1">RATE</th>
        <th nowrap="1">PAYABLEON</th>
        <th nowrap="1">RATE/KG</th>
        <th nowrap="1">RATE</th>
        <th nowrap="1">PAYABLEON</th>
        <th nowrap="1">RATE/KG</th>
        <th nowrap="1">RATE</th>
        <th nowrap="1">TOTAL SURCHARGES</th>
        <th nowrap="1">TOTAL INR</th>
        <th nowrap="1">CUR. CODE</th>
        <th nowrap="1">EXCH. RATE</th>
        <th nowrap="1">TOTAL EURO</th>
        <th nowrap="1">DELIVERY CHARGES</th>
        <th nowrap="1">PALETISATION</th>
        <th nowrap="1">T1</th>
        <th nowrap="1">TOTAL EURO</th>
        <th nowrap="1">FRIGHT + DEST.CHARGES EURO</th>
        <th nowrap="1">REMARKS</th>
      </tr>
      <xsl:for-each select="//NewDataSet/Table4">
        <tr class="row">
          <td class="locked" align="left">
            <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fnEdit_Job('{PK_JOBDTLSID}','{FK_LOGID}')" alt="Edit Job Details" />
            <xsl:if test="INVOICED != ''">
              <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="parent.fnDelete_Job('{PK_JOBDTLSID}','{FK_LOGID}')" alt="Delete Job Details" />
            </xsl:if>
          </td>
          <td class="locked" nowrap="1" align="left">
            <xsl:value-of select="INVOICED" disable-output-escaping="yes"/>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="locked" nowrap="1" align="left">
            <xsl:value-of select="PO_NUMBER" disable-output-escaping="yes"/>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="locked" nowrap="1" align="left">
            <xsl:value-of select="HAWBNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="ORIGIN" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="MAWBNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="JOBNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="CONSOLENO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="CONSOLEDT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="ETA" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="AIR_ETD" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="ACTUAL_DELIVERYDT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="SHIPPER" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="INCOTERM" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="CTNS" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="WEIGHT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="CHBL_WGT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="VOLUME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="WEIGHT_FOR_INVOICING" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="AIR_FREIGHT_RATE_PAYABLEON" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="AIR_FREIGHT_RATE_KG" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="AIR_FREIGHT_RATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="FSC_RATE_PAYABLEON" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="FSC_RATE_KG" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="FSC_RATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="IRC_RATE_PAYABLEON" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="IRC_RATE_KG" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="IRC_RATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="X_RAY_RATE_PAYABLEON" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="X_RAY_RATE_KG" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="X_RAY_RATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="TOTAL_SURCHARGES" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="TOTAL_INR" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="CUR_CODE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="EXCHANGE_RATE_KG" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="FREIGHT_IN_EURO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="DELIVERY_RATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="PALETISATION_RATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="T1_RATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="CHARGES_EURO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="FRIEGHT_DEST_CHARGES_EURO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="REMARKS" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="42" class="foot">
          <xsl:if test="count(//NewDataSet/Table4)!=1">
            <xsl:value-of select="count(//NewDataSet/Table4)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/Table4)=1">
            1 Record
          </xsl:if>
        </td>
      </tr>
    </table>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

    </table>

  </xsl:template>
</xsl:stylesheet>
