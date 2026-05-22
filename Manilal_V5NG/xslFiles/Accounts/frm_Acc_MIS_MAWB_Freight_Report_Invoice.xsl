<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div class="divSpace" id="tableContainer">
      <table cellpadding="0" cellspacing="0" border="1" bordercolor="white" width="100%">
        <tr height="20px" valign="top">
          <th nowrap="1" align="center" class="locked" width="100px">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>
          <th nowrap="1" align="center" class="locked" width="100px">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>          
          <th nowrap="1" align="center">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>
          <th nowrap="1" align="center">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>
          <th nowrap="1" align="center">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>
          <th nowrap="1" align="center">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>
          <th nowrap="1" align="center">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>
          <th nowrap="1" align="center">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>
          <th nowrap="1" align="center" colspan="4">Payment Received</th>
          <th nowrap="1" align="center">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>
        </tr>
        <tr height="20px">
          <th nowrap="1" align="center" class="locked" width="100px">MAWB No.</th>
          <th nowrap="1" align="center" class="locked" width="100px">MAWB No.</th>
          <th nowrap="1" align="center">Invoice No.</th>
          <th nowrap="1" align="center">Invoice Date</th>
          <th nowrap="1" align="center">Client Code</th>
          <th nowrap="1" align="center">Client Name</th>
          <th nowrap="1" align="right">Invoice Freight Total</th>
          <th nowrap="1" align="right">Invoice Total (a)</th>
          <th nowrap="1" align="right">Debit</th>
          <th nowrap="1" align="right">Credit</th>
          <th nowrap="1" align="right">Difference (b)</th>
          <th nowrap="1" align="center">Details</th>
          <th nowrap="1" align="right">Balance (a-b)</th>
        </tr>
        <xsl:for-each select="//NewDataSet/Table3">
          <tr>
            <xsl:choose>
              <xsl:when test="CLIENT_NAME='TOTAL'">
                <td NOWRAP="" class="locked">
                  <b>
                    <xsl:value-of select="MAWBNO" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" class="locked">
                  <b>
                    <xsl:value-of select="MAWBDT" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="">
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="">
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="">
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="">
                  <b>
                    <xsl:value-of select="CLIENT_NAME" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <b>
                    <xsl:value-of select="FREIGHT_DIFF" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <b>
                    <xsl:value-of select="INV_TOTAL" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <b>
                    <xsl:value-of select="PAYMENT_RECEIVED_DRAMT" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <b>
                    <xsl:value-of select="PAYMENT_RECEIVED_CRAMT" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <b>
                    <xsl:value-of select="PAYMENT_RECEIVED_DIFF" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:center;">
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <b>
                    <xsl:value-of select="BALANCE" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </xsl:when>
              <xsl:otherwise>
                <td NOWRAP="" class="locked">
                  <b>
                    <xsl:value-of select="MAWBNO" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" class="locked">
                  <b>
                    <xsl:value-of select="MAWBDT" />
                  </b>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>                
                <td NOWRAP="">
                  <a onclick="javascript:parent.fn_Populate_Print('{URLLINK}');" style="color:Blue;cursor:hand;">
                    <b>
                      <xsl:value-of select="INV_NO" />
                    </b>
                  </a>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="">
                  <xsl:value-of select="INV_DATE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="">
                  <xsl:value-of select="INV_CLIENT" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="">
                  <xsl:value-of select="CLIENT_NAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <xsl:value-of select="FREIGHT_DIFF" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <xsl:value-of select="INV_TOTAL" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <xsl:value-of select="PAYMENT_RECEIVED_DRAMT" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <xsl:value-of select="PAYMENT_RECEIVED_CRAMT" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <xsl:value-of select="PAYMENT_RECEIVED_DIFF" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td NOWRAP="" style="text-align:center;">
                  <a onclick="javascript:parent.fn_Populate_Inv_PaymentRecd_details('{INV_NO}','{PAY_COUNT}');" style="color:Blue;cursor:hand;">
                    <b>VIEW</b>
                  </a>
                </td>
                <td NOWRAP="" style="text-align:right;">
                  <xsl:value-of select="BALANCE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </xsl:otherwise>
            </xsl:choose>
          </tr>
        </xsl:for-each>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
