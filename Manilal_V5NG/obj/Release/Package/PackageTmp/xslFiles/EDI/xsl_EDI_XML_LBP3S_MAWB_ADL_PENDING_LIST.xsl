<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
        <style>
          .expanded
          {
          color: black
          }
          .collapsed
          {
          DISPLAY: none
          }
        </style>
        <script language="javascript">
          function fnOpenV(_url) {
          if (_url != 'TOTAL:') {
          var oWin = window.open(_url, 'OP', 'toolbar=no,menubar=yes,width=790,height=450,top=100,left=300,scrollbars=yes');
          oWin.focus();
          if (oWin == null || typeof (oWin) == "undefined") alert("window failed to open");
          }
          return false;
          }

          function outliner () {
          oMe = window.event.srcElement
          //get child element
          var child = document.all[event.srcElement.getAttribute("child",false)];
          //if child element exists, expand or collapse it.
          if (null != child)
          child.className = child.className == "collapsed" ? "expanded" : "collapsed";
          }

          function changepic() {
          uMe = window.event.srcElement;
          var check = uMe.src.toLowerCase();
          if(check.lastIndexOf("img_plus.gif") != -1)
          uMe.src = "../../include/img/img_Minus.gif"
          else
          uMe.src = "../../include/img/img_Plus.gif"
          }
          function fnClickNo(No)
          {
          parent.fnViewJobProfit(No)
          return false;
          }
        </script>
      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" onclick="outliner();" >
        <div id="tableContainer" class="divSpace" style="width:100%" >
          <table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
            <xsl:for-each select="//NewDataSet/Table">
              <xsl:variable name="MODE" select="MODE"></xsl:variable>

              <tr class="DataGridFixedHeader">
                <td class="header" width="10px"></td>
                <td  class="header" width="150px">
                  <xsl:choose>
                    <xsl:when test="$MODE='AIR'">
                      MAWB No.
                    </xsl:when>
                    <xsl:otherwise>
                      Container No.
                    </xsl:otherwise>
                  </xsl:choose>
                </td>
                <td width="80px" style="text-align:left;">
                  <xsl:choose>
                    <xsl:when test="$MODE='AIR'">
                      AFlight Dt
                    </xsl:when>
                    <xsl:otherwise>
                      Sail Dt.
                    </xsl:otherwise>
                  </xsl:choose>

                </td>
                <xsl:if test="$MODE='SEA'">
                  <td width="80px" style="text-align:left;">
                    Verified
                  </td>
                  <td width="80px" style="text-align:left;">
                    Load Dt
                  </td>
                </xsl:if>
                <td width="70px"  style="text-align:left;">
                  DPort
                </td>
                <td width="70px"  style="text-align:left;">
                  OPort
                </td>
                <td width="80px" style="text-align:left;">
                  PS-ADL
                </td>
                <td width="150px" style="text-align:left;">
                  PS-ADL Dt
                </td>
                <td width="150px"  style="text-align:left;">
                  PS-EVENT
                </td>
                <td width="150px"  style="text-align:left;">
                  PS-EVENT Dt
                </td>
                <td width="150px" style="text-align:left;">
                  REMARKS
                </td>
              </tr>

              <xsl:for-each select="//NewDataSet/Table1">
                <xsl:variable name="ID" select="CTR_MAWBNO"></xsl:variable>
                <xsl:variable name="ADL" select="PSADL"></xsl:variable>
                <xsl:variable name="VERIFY" select="VERIFIED"></xsl:variable>
                <xsl:variable name="LOAD" select="LOADDT"></xsl:variable>
                <xsl:variable name="SAIL" select="AFLIGHTDT"></xsl:variable>
                
                <xsl:if test="$ADL = ''">
                  <tr class="formheading">
                    <td class="summaryDetail" width="9px">
                      <IMG border="0" alt="expand/collapse section" child="src{$ID}" name="{CTR_MAWBNO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                    </td>
                    <td class="summaryDetail">
                      <label style="color: #0000FF" >
                        <!--;text-decoration:underline;cursor:hand" onclick="return fnClickNo('{$ID}')">-->
                        <xsl:value-of select="$ID" />
                      </label>
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                      <td class="summaryDetail" style="text-align:left;">
                        <xsl:choose>
                          <xsl:when test="$SAIL='N'">
                            <label style="color: Red" >
                              Pending!
                            </label>
                          </xsl:when>
                          <xsl:otherwise>
                            <label style="color: #0000FF" >
                              <xsl:value-of select="AFLIGHTDT" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </label>
                          </xsl:otherwise>
                        </xsl:choose>
                      </td>
                      
                    <xsl:if test="$MODE='SEA'">
                      <td class="summaryDetail" style="text-align:left;">
                        <xsl:choose>
                          <xsl:when test="$VERIFY='N'">
                            <label style="color: Red" >
                              Pending!
                            </label>
                          </xsl:when>
                          <xsl:otherwise>
                            <label style="color: #0000FF" >
                              <xsl:value-of select="VERIFIED" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </label>
                          </xsl:otherwise>
                        </xsl:choose>
                      </td>
                      <td class="summaryDetail" style="text-align:left;">
                        <xsl:choose>
                          <xsl:when test="$LOAD='N'">
                            <label style="color: Red" >
                              Pending!
                            </label>
                          </xsl:when>
                          <xsl:otherwise>
                            <label style="color: #0000FF" >
                              <xsl:value-of select="LOADDT" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </label>
                          </xsl:otherwise>
                        </xsl:choose>
                      </td>
                    </xsl:if>

                    <td class="summaryDetail"  style="text-align:left;">
                      <label style="color: #0000FF" >
                        <xsl:value-of select="FFDESTPORT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </label>
                    </td>
                    <td class="summaryDetail"  style="text-align:left;">
                      <label style="color: #0000FF" >
                        <xsl:value-of select="FFORIGINPORT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </label>
                    </td>
                    <td class="summaryDetail"  style="text-align:left;">
                      <label style="color: #0000FF" >
                        <xsl:value-of select="PSADL" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </label>
                    </td>
                    <td class="summaryDetail"  style="text-align:left;">
                      <label style="color: #0000FF" >
                        <xsl:value-of select="PSADLSENTON" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </label>
                    </td>
                    <td class="summaryDetail"  style="text-align:left;">
                      <label style="color: #0000FF" >
                        <xsl:value-of select="PSEVENT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </label>
                    </td>
                    <td class="summaryDetail" style="text-align:left;">
                      <label style="color: #0000FF" >
                        <xsl:value-of select="PSEVENTSENTON" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </label>
                    </td>
                    <td class="summaryDetail" style="text-align:left;">
                      <label style="color: #0000FF" >
                        <xsl:value-of select="REMARKS" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </label>
                    </td>
                  </tr>
                </xsl:if>

                <tr id="src{CONSOLENO}">
                  <td colspan="12" >
                    <table  border="0" cellpadding="0" cellspacing="0" class="collapsed" bgcolor="#ffffff" id="src{$ID}" width="100%">
                      <tr class="formHeading" >
                        <td class="header" width="10px"></td>
                        <!--<td class="header" width="10px"></td>-->
                        <td class="header" width="130px">
                          Job No.
                        </td>
                        <td width="200px" style="text-align:left;">
                          Shipper
                        </td>

                        <td width="80px" style="text-align:left;">
                          Shipp Bill
                        </td>
                        <td width="90px" style="text-align:left;">
                          Custom Dt.
                        </td>
                        <td width="80px" style="text-align:left;">
                          Con Job
                        </td>
                        <td width="70px" style="text-align:left;">
                          EEM No.
                        </td>
                        <td width="80px" style="text-align:left;">
                          Order No.
                        </td>
                        <td width="60px" style="text-align:left;">
                          Pkgs
                        </td>
                        <td width="70px" style="text-align:left;">
                          PSR
                        </td>
                        <td width="70px" style="text-align:left;">
                          PSR PKGS
                        </td>
                        <td width="200px" style="text-align:left;">
                          Remarks
                        </td>
                      </tr>
                      <xsl:for-each select="//NewDataSet/Table2">
                        <xsl:variable name="ID_JOB" select="JOBNO"></xsl:variable>
                        <xsl:variable name="SHIPCUST" select="SHIPCUSTOM"></xsl:variable>
                        <xsl:variable name="CON_JOB" select="CONSOLE_JOB"></xsl:variable>
                        <xsl:variable name="PSR" select="MP_PSRCODE"></xsl:variable>
                        <xsl:variable name="PSADL" select="PS"></xsl:variable>

                        <xsl:if test="$ID = CTR_MAWBNO_JOB">
                          <xsl:if test="($PSADL='')">
                            <tr>
                              <td class="summaryDetail" width="10px"></td>
                              <!--<td class="summaryDetail" >
                              <IMG border="0" alt="expand/collapse section" id="job{JOBNO}p" child="job{JOBNO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                            </td>-->
                              <td class="summaryDetail" >
                                <label style="color: #0000FF">
                                  <!--;text-decoration:underline;cursor:hand" onclick="return fnClickNo('{JOBNO}')">-->
                                  <xsl:value-of select="JOBNO" />
                                </label>
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                              </td>
                              <td class="summaryDetail" >
                                <label style="color: #0000FF" >
                                  <xsl:value-of select="SHIPPERNAME" />
                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </label>
                              </td>

                              <td class="summaryDetail" style="text-align:left;">
                                <label style="color: #0000FF" >
                                  <xsl:value-of select="SHIPBILLNO" />
                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </label>
                              </td>
                              <td class="summaryDetail" style="text-align:left;">
                                <xsl:choose>
                                  <xsl:when test="$SHIPCUST='N'">
                                    <label style="color: Red" >
                                      Not Entered!
                                    </label>
                                  </xsl:when>
                                  <xsl:otherwise>
                                    <label style="color: #0000FF" >
                                      <xsl:value-of select="SHIPCUSTOM" />
                                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    </label>
                                  </xsl:otherwise>
                                </xsl:choose>

                              </td>
                              <td class="summaryDetail" >
                                <xsl:choose>
                                  <xsl:when test="$CON_JOB='N'">
                                    <label style="color:Red" >
                                      Console Job Pending!
                                    </label>
                                  </xsl:when>
                                  <xsl:otherwise>
                                    <label style="color: #0000FF" >
                                      <xsl:value-of select="CONSOLE_JOB" />
                                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    </label>
                                  </xsl:otherwise>
                                </xsl:choose>

                              </td>
                              <td class="summaryDetail" >
                                <label style="color: #0000FF" >
                                  <xsl:value-of select="SHIPID" />
                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </label>
                              </td>
                              <td class="summaryDetail" style="text-align:left;">
                                <label style="color: #0000FF" >
                                  <xsl:value-of select="ORDERNO" />
                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </label>
                              </td>
                              <td class="summaryDetail" style="text-align:left;">
                                <label style="color: #0000FF" >
                                  <xsl:value-of select="PKGS" />
                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </label>
                              </td>
                              <td class="summaryDetail" style="text-align:left;">
                                <label style="color: #0000FF" >
                                  <xsl:value-of select="MP_PSRCODE" />
                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </label>
                              </td>
                              <td class="summaryDetail" >
                                <label style="color: #0000FF" >
                                  <xsl:value-of select="PSRPKGS" />
                                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </label>
                              </td>
                              <td class="summaryDetail" >
                                <xsl:choose>
                                  <xsl:when test="$PSR=''">
                                    <label style="color: Red" >
                                      <xsl:value-of select="REMARK"/>
                                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    </label>
                                  </xsl:when>
                                  <xsl:otherwise>
                                    <label style="color: #0000FF" >
                                      <xsl:value-of select="REMARK"/>
                                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    </label>
                                  </xsl:otherwise>
                                </xsl:choose>

                              </td>
                            </tr>
                            <!--<tr class="collapsed" bgcolor="#ffffff" id="job{JOBNO}">
                            <td class="summaryDetail" width="10px"></td>
                            <td class="summaryDetail" width="10px"></td>
                            <td colspan="10" class="summaryDetail">
                              <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr class="formHeading">
                                  <td class="header">Voucher No.</td>
                                  <td class="header">Date</td>
                                  <td class="header" style="text-align:right;">Expense </td>
                                  <td class="header" style="text-align:right;">Recovery </td>
                                </tr>
                                <xsl:for-each select="//NewDataSet/Table4">
                                  <xsl:if test="$ID = MAWB_CONTINAER_JS and JOBNO_JS=$ID_JOB">
                                    <tr>
                                      <td class="summaryDetail">
                                        <xsl:value-of select="VOUCHER_NO" disable-output-escaping="yes"/>
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                      <td class="summaryDetail">
                                        <xsl:value-of select="TRAN_DATE" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                      <td class="summaryDetail" style="text-align:right;">
                                        <xsl:value-of select="PAYMENT_EURO" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                      <td class="summaryDetail" style="text-align:right;">
                                        <xsl:value-of select="RECOVERY_EURO" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </td>
                                    </tr>
                                  </xsl:if>
                                </xsl:for-each>
                              </table>
                            </td>
                          </tr>-->
                          </xsl:if>
                        </xsl:if>
                      </xsl:for-each>
                    </table>
                  </td>
                </tr>
              </xsl:for-each>
            </xsl:for-each>
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>