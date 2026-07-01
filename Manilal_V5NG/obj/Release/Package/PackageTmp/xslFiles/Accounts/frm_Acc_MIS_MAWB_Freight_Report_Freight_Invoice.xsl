<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div class="divSpace" id="tableContainer">
      <table cellpadding="0" cellspacing="0" border="1" bordercolor="white" width="100%">
        <tr height="25px">
          <th class="locked" valign="top" width="100px">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>
          <th class="locked" valign="top" width="100px">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>          
          <th colspan="3" align="center">TOTAL</th>
          <xsl:for-each select="//NewDataSet/Table">
            <th colspan="3" align="center" nowrap="1">
              <xsl:value-of select="ACCTNAME"/>
            </th>
          </xsl:for-each>
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
        <tr height="25px">
          <th class="locked" width="100px">MAWBNO</th>
          <th class="locked" width="100px">MAWBDT</th>
          <th nowrap="1"  align="center" width="90px">Expense</th>
          <th nowrap="1"  align="center" width="90px">Recovery</th>
          <th nowrap="1"  align="center" width="90px">Difference</th>
          <xsl:for-each select="//NewDataSet/Table">
            <th nowrap="1"  align="center" width="90px">Expense</th>
            <th nowrap="1"  align="center" width="90px">Recovery</th>
            <th nowrap="1"  align="center" width="90px">Difference</th>
          </xsl:for-each>
          <th nowrap="1" align="center" width="150px">Invoice No.</th>
          <th nowrap="1" align="center" width="90px">Invoice Date</th>
          <th nowrap="1" align="center" width="80px">Client Code</th>
          <th nowrap="1" align="center" width="480px">Client Name</th>
          <th nowrap="1" align="right" width="120px">Invoice Freight Total</th>
          <th nowrap="1" align="right" width="110px">Invoice Total (a)</th>
          <th nowrap="1" align="right" width="100px">Debit</th>
          <th nowrap="1" align="right" width="100px">Credit</th>
          <th nowrap="1" align="right" width="100px">Difference (b)</th>
          <th nowrap="1" align="center" width="60px">Details</th>
          <th nowrap="1" align="right" width="100px">Balance (a-b)</th>
        </tr>
        <xsl:for-each select="//NewDataSet/Table1">
          <xsl:variable name="MAWBNO" select="MAWBNO"></xsl:variable>
          <xsl:variable name="MAWBDT" select="MAWBDT"></xsl:variable>
          <tr>
            <xsl:for-each select="*">
              <xsl:if test="local-name(.)!='TBL'">
                <xsl:choose>
                  <xsl:when test="local-name(.)='MAWBNO'">
                    <td class="locked" valign="top">
                      <b>
                        <xsl:value-of select="current()"/>
                      </b>
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                  </xsl:when>
                  <xsl:when test="local-name(.)='MAWBDT'">
                    <td class="locked" valign="top">
                      <b>
                        <xsl:value-of select="current()"/>
                      </b>
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                  </xsl:when>
                  <xsl:otherwise>
                    <td valign="top" style="text-align:right;">
                      <xsl:value-of select="current()"/>
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                  </xsl:otherwise>
                </xsl:choose>
              </xsl:if>
            </xsl:for-each>
            <td colspan="13">
              <table cellpadding="0" cellspacing="0" border="2" bordercolor="white" class="infotable" WIDTH="100%">
                <xsl:for-each select="//NewDataSet/Table3">
                  <xsl:if test="MAWBNO=$MAWBNO">
                    <tr>
                      <xsl:choose>
                        <xsl:when test="CLIENT_NAME='TOTAL'">
                          <td width="150px" NOWRAP="">
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="90px" NOWRAP="">
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="80px" NOWRAP="">
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="480px" NOWRAP="">
                            <b>
                              <xsl:value-of select="CLIENT_NAME" />
                            </b>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="120px" NOWRAP="" style="text-align:right;">
                            <b>
                              <xsl:value-of select="FREIGHT_DIFF" />
                            </b>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="110px" NOWRAP="" style="text-align:right;">
                            <b>
                              <xsl:value-of select="INV_TOTAL" />
                            </b>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="100px" NOWRAP="" style="text-align:right;">
                            <b>
                              <xsl:value-of select="PAYMENT_RECEIVED_DRAMT" />
                            </b>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="100px" NOWRAP="" style="text-align:right;">
                            <b>
                              <xsl:value-of select="PAYMENT_RECEIVED_CRAMT" />
                            </b>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="100px" NOWRAP="" style="text-align:right;">
                            <b>
                              <xsl:value-of select="PAYMENT_RECEIVED_DIFF" />
                            </b>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="60px" NOWRAP="" style="text-align:center;">
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="100px" NOWRAP="" style="text-align:right;">
                            <b>
                              <xsl:value-of select="BALANCE" />
                            </b>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                        </xsl:when>
                        <xsl:otherwise>
                          <td width="150px" NOWRAP="">
                            <a onclick="javascript:parent.fn_Populate_Print('{URLLINK}');" style="color:Blue;cursor:hand;">
                              <b>
                                <xsl:value-of select="INV_NO" />
                              </b>
                            </a>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="90px" NOWRAP="">
                            <xsl:value-of select="INV_DATE" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="80px" NOWRAP="">
                            <xsl:value-of select="INV_CLIENT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="480px" NOWRAP="">
                            <xsl:value-of select="CLIENT_NAME" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="120px" NOWRAP="" style="text-align:right;">
                            <xsl:value-of select="FREIGHT_DIFF" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="110px" NOWRAP="" style="text-align:right;">
                            <xsl:value-of select="INV_TOTAL" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>

                          <td width="100px" NOWRAP="" style="text-align:right;">
                            <xsl:value-of select="PAYMENT_RECEIVED_DRAMT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="100px" NOWRAP="" style="text-align:right;">
                            <xsl:value-of select="PAYMENT_RECEIVED_CRAMT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="100px" NOWRAP="" style="text-align:right;">
                            <xsl:value-of select="PAYMENT_RECEIVED_DIFF" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td width="60px" NOWRAP="" style="text-align:center;">
                            <a onclick="javascript:parent.fn_Populate_Inv_PaymentRecd_details('{INV_NO}','{PAY_COUNT}');" style="color:Blue;cursor:hand;">
                              <b>VIEW</b>
                            </a>
                          </td>
                          <td width="100px" NOWRAP="" style="text-align:right;">
                            <xsl:value-of select="BALANCE" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                        </xsl:otherwise>
                      </xsl:choose>
                    </tr>
                  </xsl:if>
                </xsl:for-each>
              </table>
            </td>
          </tr>
        </xsl:for-each>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
