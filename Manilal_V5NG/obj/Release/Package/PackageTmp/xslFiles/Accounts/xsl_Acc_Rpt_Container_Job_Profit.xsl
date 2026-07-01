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
			function changepic(ID) {
				new_id=ID+"p";
				sorc_src=document.getElementById(new_id).src;
				ImgArr=document.getElementById(new_id).src.split("/");
				img_src=ImgArr[5];
			if (img_src=="img_Plus.gif")
			{
				rep_str=/img_Plus/gi;
				chg_src= sorc_src.replace(rep_str, "img_Minus");

				document.getElementById(new_id).src= chg_src;
			}
			else
			{
				rep_str=/img_Minus/gi;
				chg_src= sorc_src.replace(rep_str, "img_Plus");
				document.getElementById(new_id).src= chg_src;
			}
			var Cont = document.getElementById(ID).attributes.class.value;
			if (Cont == "expanded")
				document.getElementById(ID).setAttribute("class", "collapsed");
			else
				document.getElementById(ID).setAttribute("class", "expanded");
			}
		</script>
      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0"  >
        <div id="tableContainer" class="divSpace" style="width:100%" >
          <table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
            <xsl:for-each select="//NewDataSet/Table">
              <xsl:variable name="MODE" select="MODE"></xsl:variable>
              <tr class="DataGridFixedHeader">
                <td class="header" width="10px"></td>
                <td class="header" width="150px">
                  <xsl:choose>
                    <xsl:when test="$MODE='MAWB'">
                      MAWB No.
                    </xsl:when>
                    <xsl:otherwise>
                      Container No. 
                    </xsl:otherwise>
                  </xsl:choose>
                </td>
                <td width="40%">
                </td>
                <td width="130px" style="text-align:right;">
                  Expense
                </td>
                <td width="130px" style="text-align:right;">
                  Recovery
                </td>
                <td width="130px"  style="text-align:right;">
                  Difference
                </td>
                <td width="150px" >
                  Remarks
                </td>
              </tr>
              <xsl:for-each select="//NewDataSet/Table1">
                <xsl:variable name="ID" select="CTR_MAWBNO"></xsl:variable>
                <xsl:variable name="SENTFROM" select="SENTFROM"></xsl:variable>
                <tr class="formHeading">
                  <td class="summaryDetail" width="10px">
                    <IMG border="0" alt="expand/collapse section" child="src{$ID}" name="{CONSOLENO}" class="expandable" height="11" id="src{$ID}p" onclick="changepic('src{$ID}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                  </td>
                  <td class="summaryDetail">
                    <!--label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="return fnClickNo('{$ID}')"-->
                      <xsl:value-of select="$ID" />
                    <!--/label-->
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail" >
                    <!--xsl:value-of select="IMPORTER_NAME" disable-output-escaping="yes"/-->
                    <xsl:value-of select="JOBNO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail"  style="text-align:right;">
                    <xsl:value-of select="DRAMT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail"  style="text-align:right;">
                    <xsl:value-of select="CRAMT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail"  style="text-align:right;">
                    <xsl:value-of select="GRANDVALUE_TOTAL" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="GRANDVALUE" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr id="src{CONSOLENO}">
                  <td colspan="9" >
                    <table  border="0" cellpadding="0" cellspacing="0" class="collapsed" bgcolor="#ffffff" id="src{$ID}" width="100%">

                      <tr class="header" height="0px">
                        <td class="header" width="10px"></td>
                        <td class="header" width="10px"></td>
                        <td class="header" width="130px"></td>
                        <td >

                        </td>
                        <td width="130px">

                        </td>
                        <td width="130px">

                        </td>
                        <td width="130px">

                        </td>
                        <td width="130px">

                        </td>
                      </tr>
                      <tr class="formHeading">
                        <td class="formHeading" width="10px">
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;&amp;nbsp;&amp;nbsp;</xsl:text>

                        </td>
                        <td width="10px" class="header">
                          <IMG border="0" alt="expand/collapse section" id="con_sum{CONSOLENO}p" child="con_sum{CONSOLENO}" class="expandable" height="11" onclick="changepic('con_sum{CONSOLENO}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                        </td>
                        <td colspan="8" width="99%" class="summaryDetail">
                          SUMMARY PROFIT 
                           <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          [<xsl:value-of select="$ID" />]
                        </td>
                      </tr>
                      <tr class="collapsed" bgcolor="#ffffff" id="con_sum{CONSOLENO}">

                        <td class="summaryDetail" width="10px"></td>
                        <td class="summaryDetail">
                        </td>
                        <td colspan="7" class="summaryDetail">
                          <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr class="formHeading" height="0px">
                              <td class="header" width="130px"></td>
                              <td class="header" width="80px"></td>
                              <td class="header"></td>
                              <td class="header" align="right" width="130px"></td>
                            </tr>
                            <tr class="formHeading">
                              <td class="header">Voucher No.</td>
                              <td class="header">Date</td>
                              <td class="header" align="right">Expense </td>
                              <td class="header" align="right">Recovery </td>
                            </tr>
                            <xsl:for-each select="//NewDataSet/Table3">
                              <xsl:if test="$ID = MAWB_CONTINAER_CS">
                                <tr>
                                  <td class="summaryDetail">
                                    <xsl:value-of select="VOUCHER_NO" disable-output-escaping="yes" />
                                  </td>
                                  <td class="summaryDetail">
                                    <xsl:value-of select="TRAN_DATE" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </td>
                                  <td class="summaryDetail" align="right">
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    <xsl:value-of select="PAYMENT_EURO" />

                                  </td>
                                  <td class="summaryDetail" align="right">
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    <xsl:value-of select="RECOVERY_EURO" />

                                  </td>
                                </tr>
                              </xsl:if>
                            </xsl:for-each>
                          </table>
                        </td>
                      </tr>
                      <tr class="formHeading" >
                        <td class="header" width="10px"></td>
                        <td class="header" width="10px"></td>
                        <td class="header" width="130px">
                          Job No.
                        </td>
                        <td >
                          Client
                        </td>
                        <td width="130px" style="text-align:right;">
                          Expense
                        </td>
                        <td width="130px" style="text-align:right;">
                          Recovery
                        </td>
                        <td width="130px" style="text-align:right;">
                          Difference
                        </td>
                        <td width="130px">
                          Remarks
                        </td>
                      </tr>
                      <xsl:for-each select="//NewDataSet/Table2">
                        <xsl:variable name="ID_JOB" select="JOBNO"></xsl:variable>
                        <xsl:if test="$ID = CTR_MAWBNO_JOB">
                          <tr>
                            <td class="header" width="10px"></td>
                            <td class="summaryDetail" >
                              <IMG border="0" alt="expand/collapse section" id="job{JOBNO}p" child="job{JOBNO}" class="expandable" height="11" onclick="changepic('job{JOBNO}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                            </td>
                            <td class="summaryDetail" >
                              <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="return parent.fnClickNo('{JOBNO}')">
                                <xsl:value-of select="JOBNO" />
                              </label>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" >
                              <xsl:value-of select="CLIENT_NAME" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" style="text-align:right;">
                              <xsl:value-of select="DRAMT" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" style="text-align:right;">
                              <xsl:value-of select="CRAMT" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" style="text-align:right;">
                              <xsl:value-of select="GRANDVALUE_TOTAL" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" >
                              <xsl:value-of select="GRANDVALUE" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                          </tr>
                          <tr class="collapsed" bgcolor="#ffffff" id="job{JOBNO}">
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
                          </tr>
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