<?xml version="1.0"?>
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

			 function outliner ()
			 {
			 oMe = window.event.srcElement
			 //get child element
			 var child = document.all[event.srcElement.getAttribute("child",false)];
			 //if child element exists, expand or collapse it.
			 if (null != child)
			 child.className = child.className == "collapsed" ? "expanded" : "collapsed";
			 }



			 function changepic(ID) {

			 new_id=ID+"p";

			 sorc_src=document.getElementById(new_id).src;

			 ImgArr=document.getElementById(new_id).src.split("/");
			 img_src=ImgArr[6];
			 
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

      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
        <div id="tableContainer" class="divSpace" style="width:100%" >

          <table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
            <xsl:for-each select="//NewDataSet/Table1">
              <xsl:variable name="ID" select="ID_ORDERNOSTYLENO"></xsl:variable>
              <tr>
                <td class="formHeading">
                  <IMG border="0" alt="expand/collapse section" id="src{ID_ORDERNOSTYLENO}p" child="src{ID_ORDERNOSTYLENO}" name="{ID_ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic('src{ID_ORDERNOSTYLENO}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                  <label  style="color: #0000FF" >
                    <xsl:value-of select="ORDERNOSTYLENO" disable-output-escaping="yes"/>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </label>
                </td>
              </tr>
              <tr>
                <td colspan="9">
                  <table class="collapsed" bgcolor="#ffffff" id="src{ID_ORDERNOSTYLENO}" width="100%">
                    <tr class="formHeading">
                      <td width="10px" class="summaryDetail">
                        <IMG border="0" alt="expand/collapse section" id="con_sum{ID_ORDERNOSTYLENO}p" child="con_sum{ID_ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic('con_sum{ID_ORDERNOSTYLENO}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                      </td>
                      <td colspan="9" width="730px" class="summaryDetail">
                        [INCOMING DETAILS]
                      </td>
                    </tr>
                    <tr class="collapsed" bgcolor="#ffffff" id="con_sum{ID_ORDERNOSTYLENO}">
                      <td class="summaryDetail">
                      </td>
                      <td colspan="9" class="summaryDetail">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                          <tr class="formHeading">
                            <td></td>
                            <td width="80px" class="formHeading"> Origin</td>
                            <td width="85px"  class="formHeading">Mode</td>
                            <td width="150px" class="formHeading">Shipper</td>
                            <td width="150px" class="formHeading">Pod</td>
                            <td width="75px" class="formHeading"> Incoterm</td>
                            <td width="150px" class="formHeading">FORCAST_SHIP_NO</td>
                            <td width="75px" class="formHeading"> LRD</td>
                            <td width="80px" class="formHeading"> LRD_UPDATE</td>
                            <td width="75px" class="formHeading"> MDD</td>
                            <td width="150px" class="formHeading">MDD_UPDATE </td>
                            <td width="80px" class="formHeading"> QTY</td>
                            <td width="75px" class="formHeading"> Cartons</td>
                            <td width="75px" class="formHeading"> Volume</td>
                            <td width="75px" class="formHeading"> INC_RECIED_DT </td>
                             <td width="75px" class="formHeading"> HS CODE </td>
                          </tr>
                          <xsl:for-each select="//NewDataSet/Table1">
                            <xsl:variable name="IN_ORDERNOSTYLENO" select="ID_ORDERNOSTYLENO"></xsl:variable>
                            <xsl:if test="$ID = ID_ORDERNOSTYLENO">
                              <tr>
                                <td></td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="POL" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="MODE" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="SHIPPER" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="POD" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="BUYING_INCOTERM" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="FORCAST_SHIP_NO" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="LRD_INT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="LRD_UPDATE" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>

                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="MDD_INT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="MDD_UPDATE" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="QTY" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="CARTON" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="VOLUMN"/>
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="INC_RECIED_DT"/>
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                  <td class="summaryDetail" style="text-align:left;">
                                      <label style="color: #0000FF" >
                                          <xsl:value-of select="HS_CODE"/>
                                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </label>
                                  </td>
                              </tr>
                              <!--<tr>
                                <td></td>

                                <td colspan="3"  class="formHeading">PRODUCT COLOUR</td>
                                <td colspan="3"  class="formHeading">SIZE</td>
                                <td colspan="2"  class="formHeading">PICES</td>
                                <td colspan="2" width="150px" class="formHeading">TYPE</td>
                                <td colspan="2"   class="formHeading">ACTUAL SHIPPED</td>
                                <td colspan="3"  class="formHeading">BALANCE</td>

                              </tr>
                              <tr>
                                <xsl:for-each select="//NewDataSet/Table2">
                                  <xsl:variable name="BKD_ORDERNOSTYLENO" select="ORDERNOSTYLENO"></xsl:variable>
                                  <xsl:if test="ORDERNOSTYLENO = $IN_ORDERNOSTYLENO">
                                    <tr>
                                      <td></td>
                                      <td colspan="3" class="summaryDetail" style="text-align:left;">
                                        <label style="color: #0000FF" >
                                          <xsl:value-of select="COL_CODE" />
                                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                        </label>
                                      </td>
                                      <td colspan="3" class="summaryDetail" style="text-align:left;">
                                        <label style="color: #0000FF" >
                                          <xsl:value-of select="SIZE_DET" />
                                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                        </label>
                                      </td>
                                      <td colspan="2" class="summaryDetail" style="text-align:left;">
                                        <label style="color: #0000FF" >
                                          <xsl:value-of select="PICES" />
                                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                        </label>
                                      </td>
                                      <td colspan="2" class="summaryDetail" style="text-align:left;">
                                        <label style="color: #0000FF" >
                                          <xsl:value-of select="TYPE_OFPCS" />
                                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                        </label>
                                      </td>
                                      <td colspan="2" class="summaryDetail" style="text-align:left;">
                                        <label style="color: #0000FF" >
                                          <xsl:value-of select="ACTUALSHIPPED" />
                                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                        </label>
                                      </td>
                                      <td colspan="3" class="summaryDetail" style="text-align:left;">
                                        <label style="color: #0000FF" >
                                          <xsl:value-of select="BALANCE" />
                                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                        </label>
                                      </td>

                                    </tr>
                                  </xsl:if>
                                </xsl:for-each>
                              </tr>-->

                            </xsl:if>
                          </xsl:for-each>
                        </table>
                      </td>
                    </tr>

                    <tr>
                      <td width="10px" class="summaryDetail">
                        <IMG border="0" alt="expand/collapse section" id="book_sum{ID_ORDERNOSTYLENO}p" child="book_sum{ID_ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic('book_sum{ID_ORDERNOSTYLENO}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                      </td>
                      <td colspan="9" width="730px" class="formHeading">
                        [BOOKING DETAILS]
                      </td>
                    </tr>
                    <tr class="collapsed" bgcolor="#ffffff" id="book_sum{ID_ORDERNOSTYLENO}">

                      <td class="summaryDetail">
                      </td>
                      <td colspan="9" class="summaryDetail">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                          <tr class="formHeading">
                            <td></td>
                            <td width="150px" class="formHeading"> Booking Dt</td>
                            <td width="150px" class="formHeading"> Mode</td>
                            <td width="150px" class="formHeading"> Origin</td>
                            <td width="150px" class="formHeading"> Pieces</td>
                            <td width="150px" class="formHeading"> Consignee</td>
                            <td width="150px" class="formHeading"> Cargo Expt</td>
                            <td width="150px" class="formHeading"> Doc Expt</td>
                            <td width="150px" class="formHeading"> Appr Expt</td>
                            <td width="150px" class="formHeading"> ETD</td>
                            <td width="150px" class="formHeading"> ETA</td>
                          </tr>
                          <xsl:for-each select="//NewDataSet/Table2">
                            <xsl:variable name="BK_ORDERNOSTYLENO" select="ID_ORDERNOSTYLENO"></xsl:variable>
                            <xsl:if test="$ID = ID_ORDERNOSTYLENO">
                              <tr>
                                <td></td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="BOOKING_DT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="MODE" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="ORIGIN" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="PIECES" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="CONS_NAME" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="CARG_EXPT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="DOC_EXPT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="APPR_EXPT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="ETD" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="ETA" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                              </tr>
                            </xsl:if>
                          </xsl:for-each>
                        </table>
                      </td>

                    </tr>

                    <tr>
                      <td width="10px" class="summaryDetail">
                        <IMG border="0" alt="expand/collapse section" id="edi_sum{ID_ORDERNOSTYLENO}p" child="edi_sum{ID_ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic('edi_sum{ID_ORDERNOSTYLENO}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                      </td>
                      <td colspan="9" width="730px" class="formHeading">
                        [EDI STATUS]
                      </td>
                    </tr>
                    <tr class="collapsed" bgcolor="#ffffff" id="edi_sum{ID_ORDERNOSTYLENO}">

                      <td class="summaryDetail">
                      </td>
                      <td colspan="9" class="summaryDetail">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                          <tr class="formHeading">
                            <td></td>
                            <td width="150px" class="formHeading"> Exptno</td>
                            <td width="150px" class="formHeading"> Pieces</td>
                            <td width="150px" class="formHeading"> Remark</td>
                          </tr>
                          <xsl:for-each select="//NewDataSet/Table3">
                            <xsl:variable name="ORD_ORDERNOSTYLENO" select="ID_ORDERNOSTYLENO"></xsl:variable>
                            <xsl:variable name="REMARK" select="REMARK"></xsl:variable>
                            <xsl:if test="$ID = ID_ORDERNOSTYLENO">
                              <tr>
                                <td ></td>
                                <td  class="summaryDetail"  style="text-align:top;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="EXPTNO" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:top;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="PIECES" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:left;"  >
                                  <!--<label style="color: #0000FF" >
                                    <xsl:value-of select="REMARK" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>-->
                                  <label style="color: #0000FF" >
                                   <xsl:variable name="newlist" select="concat(normalize-space($REMARK), ',')" />
                                    <xsl:variable name="first" select="substring-before($newlist, ', ')" />
                                    <xsl:variable name="remaining" select="substring-after($newlist, ', ')" />
                                    <xsl:value-of select="$first" />
                                    <br/>
                                    <!--<xsl:variable name="second" select="substring-before($remaining, ', ')" />-->
                                    <xsl:variable name="second" select="substring-after($remaining, ', ')" />
                                    <xsl:value-of select="$second" />
                                   <!-- <br/>
                                    <xsl:variable name="Third" select="substring-before($second1, ', ')" />
                                    <xsl:variable name="Third1" select="substring-after($second1, ', ')" />
                                    <xsl:value-of select="$Third" />
                                    <br/>
                                    <xsl:variable name="Four" select="substring-before($Third1, ', ')" />
                                    <xsl:variable name="Four1" select="substring-after($Third1, ', ')" />
                                    <xsl:value-of select="$Four" />
                                    <br/>
                                    <xsl:variable name="Five" select="substring-before($Four1, ', ')" />
                                    <xsl:variable name="Five1" select="substring-after($Four1, ', ')" />
                                    <xsl:value-of select="$Five" />
                                    <br/>
                                    <xsl:variable name="Six" select="substring-before($Five1, ', ')" />
                                    <xsl:variable name="Six1" select="substring-after($Five1, ', ')" />
                                    <xsl:value-of select="$Six" />
                                    <br/>
                                    <xsl:variable name="Seven" select="substring-before($Six1, ', ')" />
                                    <xsl:variable name="Seven1" select="substring-after($Six1, ', ')" />
                                    <xsl:value-of select="$Seven" />
                                    <br/>

                                    <xsl:variable name="Eight1" select="substring-after($Seven1, ', ')" />
                                    <xsl:value-of select="$Seven1" />--> 
                                  </label>
                                </td>
                              </tr>
                            </xsl:if>
                          </xsl:for-each>
                        </table>
                      </td>

                    </tr>
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
