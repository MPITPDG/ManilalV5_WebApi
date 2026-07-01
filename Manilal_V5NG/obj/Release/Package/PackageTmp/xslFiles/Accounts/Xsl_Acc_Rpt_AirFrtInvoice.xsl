<?xml version="1.0" encoding="utf-8"?>
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
          parent.fnClick_ConsoleNo(No)
          return false;
          }
        </script>
      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" onclick="outliner();">
        <div id="tableContainer" class="divSpace" style="width:100%" >
          <table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
        
              <tr class="DataGridFixedHeader">
                <td colspan="2" class="header">
                  Mawbno.
                </td>
                
                <td class="header">
                  MawbDt.
                </td>
               
                <td class="header">
                  Freight
                </td>
                <td class="header">
                  Chblwt.
                </td>
                <td class="header">
                 Frt_Rate
                </td>
                <td>
                 Fsc_Rate
                </td>
                <td>
                  Irc_Rate
                </td>
                <td>
                  Xray_Rate
                </td>
                <td>
                  Bp_Rate
                </td>
                <td>
                  Tot_Rate
                </td>
              </tr>
              
              <xsl:for-each select="//NewDataSet/Table">
                <xsl:variable name="ID" select="MAWBNO"></xsl:variable>
               
                <tr class="formHeading">
                  <td class="summaryDetail">
                    <IMG border="0" alt="expand/collapse section" child="src{$ID}" name="{MAWBNO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                  </td>
                  <td class="summaryDetail">
                    <label style="color: #0000FF;"  >
                      <xsl:value-of select="$ID" />
                    </label>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail" width="90">
                    <xsl:value-of select="MAWBDT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>                  
                  
                  <td class="summaryDetail">
                    <xsl:value-of select="FREIGHT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="CHBL_WT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="FRT_RATE" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                   
                  <td class="summaryDetail">
                    <xsl:value-of select="FSC_RATE" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="IRC_RATE" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="XRAY_RATE" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="BP_RATE" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class="summaryDetail">
                    <xsl:value-of select="TOT_RATE" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>                
                  
                </tr>
                <tr>
                  <td colspan="11">
                    <table class="collapsed" bgcolor="#ffffff" id="src{$ID}" width="100%">
                      <tr class="formHeading">
                        <td width="10px">
                        </td>
                        <td class="header">HawbNo.</td>
                        <td class="header">Consignee</td>
                        <td class="header">Freight</td>
                        <td class="header">Chblwt</td>
                        <td class="header">Air Frt</td>
                        <td class="header">Fsc Rate</td>
                        <td class="header">Irc Frt</td>
                        <td class="header">X-Ray Rate</td>
                        <td class="header">PP frt Amt</td>
                        <td class="header">PP X-Ray</td>
                      </tr>
                      <xsl:for-each select="//NewDataSet/Table1">
                        
                        <xsl:if test="$ID = MAWBNO">
                          <tr>
                            <td width="10px">
                            </td>
                            <td class="summaryDetail" width="120px">
                              <label style="color: #0000FF;" >
                                <xsl:value-of select="HAWBNO" />
                              </label>
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="150">
                              <xsl:value-of select="CON_NAME" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetailImp" width="60">
                              <xsl:value-of select="FREIGHT" disable-output-escaping="yes" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="60px">
                              <xsl:value-of select="CHBL_WT" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="60px">
                              <xsl:value-of select="FRT_RATE" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="60px">
                              <xsl:value-of select="FSC_RATE" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="600px">
                              <xsl:value-of select="IRC_RATE" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="600px">
                              <xsl:value-of select="XRAY_RATE" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="100px">
                              <xsl:value-of select="PP_FRTAMT" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail" width="100px">
                              <xsl:value-of select="PP_XRAY_PREPAID" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            
                          </tr>
                        </xsl:if>
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
