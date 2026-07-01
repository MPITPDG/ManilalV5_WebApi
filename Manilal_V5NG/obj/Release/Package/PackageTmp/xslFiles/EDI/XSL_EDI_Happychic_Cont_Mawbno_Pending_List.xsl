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

		   function outliner(e)
		   {

		   var target = e.srcElement || e.target;// event.target || event.srcElement;

		   oMe = target;// window.event.srcElement

		   var child = target.getAttribute("child");

		   if (null != child) {

		   var Cont = document.getElementById(child).attributes.class.value;

		   if (Cont == "expanded")
		   document.getElementById(child).setAttribute("class", "collapsed");
		   else
		   document.getElementById(child).setAttribute("class", "expanded");
		   }

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
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" >
        <div id="tableContainer" class="divSpace" style="width:100%" >
          <table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
            <tr>
              <xsl:for-each select="//NewDataSet/Table">
                <xsl:variable name="MODE" select="MODE"></xsl:variable>
                <xsl:if test="$MODE='AIR'">
                  <tr class="DataGridFixedHeader">
                    <td width="150px" style="text-align:left;">MAWBNO</td>
                  </tr>
                  <xsl:for-each select="//NewDataSet/Table1">
                    <xsl:variable name="ID_MAWBNO" select="MAWBNO"></xsl:variable>
                    <tr >
                      <td class="formHeading"  colspan="12">
                        <IMG border="0" alt="expand/collapse section" child="src{$ID_MAWBNO}" id="src{$ID_MAWBNO}p" name="{MAWBNO}" class="expandable" height="11" onclick="changepic('src{$ID_MAWBNO}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                        <label style="color: #0000FF" >
                          <xsl:value-of select="MAWBNO" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </label>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="11" >
                        <table  border="0" cellpadding="0" cellspacing="0" class="collapsed" bgcolor="#ffffff" id="src{$ID_MAWBNO}" width="100%">
                          <tr >
                            <td class="summaryDetail"  width="20px"></td>
                            <td class="formHeading" >JobNo</td>
                            <td class="formHeading" style="text-align:center;">OrderNo</td>
                            <td class="formHeading" style="text-align:center;">StyleNo</td>
                            <td class="formHeading" style="text-align:center;">Pkgs</td>
                            <td class="formHeading" style="text-align:center;">Grwt</td>
                            <td class="formHeading" style="text-align:center;">Chblwt</td>
                            <td class="formHeading" style="text-align:center;">Pieces</td>
                            <td class="formHeading" style="text-align:center;">Volume</td>
                            <td class="formHeading" style="text-align:center;">FlightDt</td>
                            <td class="formHeading" style="text-align:center;">Custom Clr</td>
                            <!--<td class="formHeading" style="text-align:center;">Origin</td>-->
                            <td class="formHeading" style="text-align:center;">Remark</td>
                          </tr>
                          <xsl:for-each select="//NewDataSet/Table2">
                            <xsl:variable name="MAWBNO_ID" select="MAWBNO"></xsl:variable>
                            <xsl:variable name="FLTDT" select="FLIGHTDT"></xsl:variable>
                            <xsl:variable name="CUSTOMCLR" select="EXPT_SHIPCUSTOM"></xsl:variable>
                            <xsl:if test="$ID_MAWBNO = $MAWBNO_ID">
                              <tr>
                                <td  width="20px"></td>
                                <td class="summaryDetail">
                                  <!--<IMG border="0" alt="expand/collapse section" id="job{EXPTNO}p" child="job{EXPTNO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>-->
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="EXPTNO" />
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
                                    <xsl:value-of select="STYLENO" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="PKGS" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="GRWT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="CHBLWT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="PIECES" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="VOLUME" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:center;">
                                  <xsl:choose>
                                    <xsl:when test="$FLTDT=''">
                                      <label style="color: Red" >
                                        Pending!
                                      </label>
                                    </xsl:when>
                                    <xsl:otherwise>
                                      <label style="color: #0000FF" >
                                        <xsl:value-of select="FLIGHTDT" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </label>
                                    </xsl:otherwise>
                                  </xsl:choose>
                                </td>
                                <td class="summaryDetail" style="text-align:center;">
                                  <xsl:choose>
                                    <xsl:when test="$CUSTOMCLR=''">
                                      <label style="color: Red" >
                                        Pending!
                                      </label>
                                    </xsl:when>
                                    <xsl:otherwise>
                                      <label style="color: #0000FF" >
                                        <xsl:value-of select="EXPT_SHIPCUSTOM" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                      </label>
                                    </xsl:otherwise>
                                  </xsl:choose>
                                </td>
                                <!--<td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="ORIGIN" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>-->
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="REMARK" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                              </tr>
                            </xsl:if>
                          </xsl:for-each>
                        </table>
                      </td>
                    </tr>
                  </xsl:for-each>
                </xsl:if>
                <xsl:if test="$MODE='SEA'">
                  <tr class="DataGridFixedHeader">
                    <td width="150px" style="text-align:left;">CONTAINERNO</td>
                  </tr>
                  <xsl:for-each select="//NewDataSet/Table1">
                    <xsl:variable name="ID_CONTAINERNO" select="CONTAINERNO"></xsl:variable>
                    <tr >
                      <td class="formHeading"  colspan="12">
                        <IMG border="0" alt="expand/collapse section" child="src{$ID_CONTAINERNO}" name="{CONTAINERNO}" id="src{$ID_CONTAINERNO}p" class="expanded" height="11" onclick="changepic('src{$ID_CONTAINERNO}')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                        <label style="color: #0000FF" >
                          <xsl:value-of select="CONTAINERNO" disable-output-escaping="yes"/>
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </label>
                      </td>
                    </tr>
                    <tr id="src{JOBNO}">
                      <td colspan="11" >
                        <table  border="0" cellpadding="0" cellspacing="0" class="collapsed" bgcolor="#ffffff" id="src{$ID_CONTAINERNO}" width="100%">
                          <tr  >
                            <td class="summaryDetail" width="20px"></td>
                            <td class="formHeading">JobNo</td>
                            <td class="formHeading" style="text-align:center;">OrderNo</td>
                            <td class="formHeading" style="text-align:center;">StyleNo</td>
                            <td class="formHeading" style="text-align:center;">Pkgs</td>
                            <td class="formHeading" style="text-align:center;">Grwt</td>
                            <td class="formHeading" style="text-align:center;">NetWt</td>
                            <td class="formHeading" style="text-align:center;">Pcs</td>
                            <td class="formHeading" style="text-align:center;">Volume</td>
                            <td class="formHeading" style="text-align:center;">ShipLine</td>
                            <td class="formHeading" style="text-align:center;">Sailing</td>
                            <!--<td class="formHeading" style="text-align:center;">Origin</td>-->
                            <td class="formHeading" style="text-align:center;">Remark</td>
                          </tr>
                          <xsl:for-each select="//NewDataSet/Table2">
                            <xsl:variable name="CONTAINERNO_ID" select="CONTAINERNO"></xsl:variable>
                            <xsl:if test="$ID_CONTAINERNO = $CONTAINERNO_ID">
                              <tr>
                                <td  width="20px"></td>
                                <td class="summaryDetail">
                                  <!--<IMG border="0" alt="expand/collapse section" id="job{EXPTNO}p" child="job{EXPTNO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>-->
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="EXPTNO" />
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
                                    <xsl:value-of select="STYLENO" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="PKGS" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="GRWT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="NETWT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="PIECES" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="VOLUME" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="SHIPLINE" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <td class="summaryDetail" style="text-align:center;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="SAILINGDATE" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                                <!--<td class="summaryDetail" style="text-align:right;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="ORIGIN" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>-->
                                <td class="summaryDetail" style="text-align:left;">
                                  <label style="color: #0000FF" >
                                    <xsl:value-of select="REMARK" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                  </label>
                                </td>
                              </tr>
                            </xsl:if>
                          </xsl:for-each>
                        </table>
                      </td>
                    </tr>
                  </xsl:for-each>
                </xsl:if>
              </xsl:for-each>
            </tr>
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>


