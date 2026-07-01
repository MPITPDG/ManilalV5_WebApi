<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
      </head>

      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" >
        <div id="tableContainer" class="divSpace" align="center" style="width:100%" >
          <table border='0' cellpadding='1' cellspacing='1' width='750px'>

            <tr class="DataGridHeader_xslt">
              <td colspan ='4' class="header">
                General Details
              </td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table">
              <xsl:variable name="PayeeName" select="PAYEENAME"></xsl:variable>
              <tr>
                <td class="lblNormal_xslt" width="150px">
                  Entry No
                </td>
                <td class="summaryDetail_xslt" width="225px">
                  <xsl:value-of select="ENTRYNO" disable-output-escaping="yes"/>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="lblNormal_xslt" width="125px">
                  Entry Date
                </td>
                <td class="summaryDetail_xslt" width="250px">
                  <xsl:value-of select="ENTRYDT" disable-output-escaping="yes"/>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr class="DataGridHeader_xslt">
                <td colspan ='4' class="header">
                  Bank/Cash Details :
                </td>

              </tr>

              <tr>
                <td class="lblNormal_xslt" width="150px">
                  cheque Type
                </td>
                <td class="summaryDetail_xslt" width="225px">
                  <xsl:value-of select="CHEQUETYPE" disable-output-escaping="yes"/>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="lblNormal_xslt" width="125px">
                  Cheque No
                </td>
                <td class="summaryDetail_xslt" width="250px">
                  <xsl:value-of select="CHEQUENO" disable-output-escaping="yes"/>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr>
                <td class="lblNormal_xslt" width="150px">
                  Bank
                </td>
                <td class="summaryDetail_xslt" width="225px">
                  <xsl:value-of select="BANK" disable-output-escaping="yes"/>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="lblNormal_xslt" width="125px">
                  Our Bank
                </td>
                <td class="summaryDetail_xslt" width="250px">
                  <xsl:value-of select="BANKNAME" disable-output-escaping="yes"/>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr>
                <td class="lblNormal_xslt" width="150px">
                  Chq.Pay By Dt.
                </td>
                <td class="summaryDetail_xslt" width="600px" colspan="3">
                  <xsl:value-of select="CHEQUEDT" disable-output-escaping="yes"/>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>

              </tr>
              <tr>
                <td class="lblNormal_xslt" width="150px">Narration . </td>
                <td class="summaryDetail_xslt" width="600px" colspan="3">
                  <xsl:value-of select="NARRATION" disable-output-escaping="yes"/>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
              <tr class="DataGridHeader_xslt">
                <td colspan ='4' class="header">
                  Details :
                </td>

              </tr>
              <tr>
                <td colspan="4">
                  <table border='0' cellpadding='1' cellspacing='1' width='100%'>
                    <xsl:for-each select="//NewDataSet/Table2">
                      <tr>
                        <td class="formheading_xslt" colspan="2" ></td>
                        <td class="formheading_xslt" width="200px" >
                          Tot Amount
                        </td>
                        <td class="formheading_xslt"  align="right">
                          <xsl:value-of select="TOTAMOUNT" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="formheading_xslt" width="200px" colspan="2" >
                          Tot Deduction
                        </td>
                        <td class="formheading_xslt"  align="right">
                          <xsl:value-of select="TOTDEDUCTION" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="formheading_xslt"  width="200px" >
                          Net Amount
                        </td>
                        <td class="formheading_xslt"  align="right">
                          <xsl:value-of select="NETTOTAL" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>

                      </tr>
                    </xsl:for-each>
                    <tr>
                      <td colspan="9" height="3px">

                      </td>
                    </tr>
                    <tr>
                      <td class="lblNormal_xslt" width="200px">
                        Payee Name
                      </td>
                      <td class="summaryDetail_xslt"   colspan="8">
                        <xsl:value-of select="$PayeeName" disable-output-escaping="yes"/>
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>

                    </tr>
                    <tr>
                      <td colspan="9" height="3px">

                      </td>
                    </tr >
                    <tr class="DataGridHeader_xslt">
                      <td class="header" width="300px">
                        Account Name
                      </td>
                      <td class="header" width="120px">
                        Job
                      </td>
                      <td class="header" width="120px">
                        Job No
                      </td>
                      <td class="header" width="120px">
                        Bill No
                      </td>
                      <td class="header" width="20px">
                        Bill
                      </td>
                      <td class="header" width="70px">
                        Deduction
                      </td>
                      <td class="header" width="70px">
                        Amount
                      </td>
                      <td class="header" width="200px">
                        Narration
                      </td>
                      <td class="header" width="100px">
                        Entry Type
                      </td>
                    </tr>
                    <xsl:for-each select="//NewDataSet/Table1">
                      <tr>
                        <td class="summaryDetail_xslt"  >
                          <xsl:value-of select="CLIENT" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt"  >
                          <label style="color: #0000FF;text-decoration:underline;cursor:hand" tooltip="View Job Adv" onclick="javascript:return parent.fnJobAdv_Preview('{JOBNO}')">
                            <xsl:value-of select="JOBADV" disable-output-escaping="yes"/>
                          </label>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt" >
                          <label style="color: #0000FF;text-decoration:underline;cursor:hand" tooltip="View Job Profit" onclick="javascript:return parent.fnJobProfit_Print('{JOBNO}')">
                            <xsl:value-of select="JOBNO" disable-output-escaping="yes"/>
                          </label>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt"  >
                          <label style="color: #0000FF;text-decoration:underline;cursor:hand" tooltip="View PI" onclick="javascript:return parent.fnpur_Print('{BILLNO}')">
                            <xsl:value-of select="BILLNO" disable-output-escaping="yes"/>
                          </label>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt"  >
                          <label style="color: #0000FF;text-decoration:underline;cursor:hand" tooltip="View RBP or PI" onclick="javascript:return parent.fnpur_Tran_Preview('{BILLNO}')">
                            <xsl:value-of select="BILLLIST" />
                          </label>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt"  >
                          <xsl:value-of select="DEDUCTION" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt"  >
                          <xsl:value-of select="AMOUNT" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt"  >
                          <xsl:value-of select="NARRATION" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt"  >
                          <xsl:value-of select="ENTRYTYPE" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                      </tr>
                    </xsl:for-each>
                  </table>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
