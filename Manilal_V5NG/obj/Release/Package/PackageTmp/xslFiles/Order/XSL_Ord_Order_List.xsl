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

                    function changepic() {
                    uMe = window.event.srcElement;
                    var check = uMe.src.toLowerCase();
                    if(check.lastIndexOf("img_plus.gif") != -1)
                    uMe.src = "../../include/img/img_Minus.gif"
                    else
                    uMe.src = "../../include/img/img_Plus.gif"
                    }

                </script>
            </head>

            <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" onclick="outliner();">
                <div id="tableContainer" class="divSpace" style="width:100%" >

                    <table cellpadding="0" cellspacing="0" width="100%" border="0" bordercolor="white" class="infotable">
                        <xsl:for-each select="//NewDataSet/Table">
                            <xsl:variable name="GRID" select="GRPID"></xsl:variable>
                            <xsl:if test="$GRID ='1'">
                                <xsl:for-each select="//NewDataSet/Table1">
                                    <xsl:variable name="ID" select="ORDERNOSTYLENO"></xsl:variable>
                                    <tr>
                                        <td class="formHeading">
                                            <IMG border="0" alt="expand/collapse section" id="src{ORDERNOSTYLENO}p" child="src{ORDERNOSTYLENO}" name="{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic('{ORDERNOSTYLENO}','c')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                            <label  style="color: #0000FF" >
                                                <xsl:value-of select="ORDERNOSTYLENO" disable-output-escaping="yes"/>
                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <table class="collapsed" bgcolor="#ffffff" id="src{ORDERNOSTYLENO}" width="100%">
                                                <tr class="formHeading">
                                                    <td width="10px" class="summaryDetail">
                                                        <IMG border="0" alt="expand/collapse section" id="con_sum{ORDERNOSTYLENO}p" child="con_sum{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                                    </td>
                                                    <td colspan="9" width="730px" class="summaryDetail">
                                                        [INCOMING RAR DETAILS]
                                                    </td>
                                                </tr>
                                                <tr class="collapsed" bgcolor="#ffffff" id="con_sum{ORDERNOSTYLENO}">
                                                    <td class="summaryDetail">
                                                    </td>
                                                    <td colspan="9" class="summaryDetail">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr class="formHeading">
                                                                <td></td>
                                                                <td width="80px" class="formHeading"> Origin</td>
                                                                <td width="85px"  class="formHeading">Mode</td>
                                                                <td width="150px" class="formHeading">Shipper</td>
                                                                <td width="150px" class="formHeading">Consignee</td>
                                                                <td width="75px" class="formHeading"> Incoterm</td>
                                                                <td width="75px" class="formHeading"> LRD</td>
                                                                <td width="75px" class="formHeading"> MDD</td>
                                                                <td width="80px" class="formHeading"> Pcs</td>
                                                                <td width="150px" class="formHeading">RAR Recvd</td>
                                                            </tr>
                                                            <xsl:for-each select="//NewDataSet/Table1">
                                                                <xsl:variable name="IN_ORDERNOSTYLENO" select="ORDERNOSTYLENO"></xsl:variable>
                                                                <xsl:if test="$ID = ORDERNOSTYLENO">
                                                                    <tr>
                                                                        <td></td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="ORIGIN" />
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
                                                                                <xsl:value-of select="CONSIGNEE" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="INCOTERM" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="LRD" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="MDD" />
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
                                                                                <xsl:value-of select="RAR_RECEIVED"/>
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>

                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="2"  class="formHeading">PRODUCT COLOUR</td>
                                                                        <td   class="formHeading">SIZE</td>
                                                                        <td  class="formHeading">PICES</td>
                                                                        <td colspan="2" width="150px" class="formHeading">TYPE</td>                                                                        
                                                                        <td colspan="4"  class="formHeading">BALANCE</td>

                                                                    </tr>
                                                                    <tr>
                                                                        <xsl:for-each select="//NewDataSet/Table2">
                                                                            <xsl:variable name="BKD_ORDERNOSTYLENO" select="ORDERNOSTYLENO"></xsl:variable>
                                                                            <xsl:if test="ORDERNOSTYLENO = $IN_ORDERNOSTYLENO">
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="2" class="summaryDetail" style="text-align:left;">
                                                                                        <label style="color: #0000FF" >
                                                                                            <xsl:value-of select="COL_CODE" />
                                                                                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                                        </label>
                                                                                    </td>
                                                                                    <td   class="summaryDetail" style="text-align:left;">
                                                                                        <label style="color: #0000FF" >
                                                                                            <xsl:value-of select="SIZE_DET" />
                                                                                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                                        </label>
                                                                                    </td>
                                                                                    <td  class="summaryDetail" style="text-align:left;">
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
                                                                                   
                                                                                    <td colspan="4" class="summaryDetail" style="text-align:left;">
                                                                                        <label style="color: #0000FF" >
                                                                                            <xsl:value-of select="BALANCE" />
                                                                                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                                        </label>
                                                                                    </td>

                                                                                </tr>
                                                                            </xsl:if>
                                                                        </xsl:for-each>
                                                                    </tr>

                                                                </xsl:if>
                                                            </xsl:for-each>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="10px" class="summaryDetail">
                                                        <IMG border="0" alt="expand/collapse section" id="con_sum{ORDERNOSTYLENO}p" child="book_sum{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                                    </td>
                                                    <td colspan="9" width="730px" class="formHeading">
                                                        [BOOKING DETAILS]
                                                    </td>
                                                </tr>
                                                <tr class="collapsed" bgcolor="#ffffff" id="book_sum{ORDERNOSTYLENO}">

                                                    <td class="summaryDetail">
                                                    </td>
                                                    <td colspan="9" class="summaryDetail">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr class="formHeading">
                                                                <td></td>
                                                                <td width="150px" class="formHeading"> Booking Dt</td>
                                                                <td width="150px" class="formHeading"> Mode</td>
                                                                <td width="150px" class="formHeading"> Origin</td>
                                                                <td width="150px" class="formHeading"> Exptno</td>
                                                                <td width="150px" class="formHeading"> Pieces</td>
                                                                <td width="150px" class="formHeading"> Consignee</td>
                                                                <td width="150px" class="formHeading"> Cargo Expt</td>
                                                                <td width="150px" class="formHeading"> Doc Expt</td>
                                                                <td width="150px" class="formHeading"> Appr Expt</td>
                                                                <td width="150px" class="formHeading"> ETD</td>
                                                                <td width="150px" class="formHeading"> ETA</td>
                                                            </tr>
                                                            <xsl:for-each select="//NewDataSet/Table3">
                                                                <xsl:variable name="BK_ORDERNOSTYLENO" select="ORDERNOSTYLENO"></xsl:variable>
                                                                <xsl:if test="$ID = ORDERNOSTYLENO">
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
                                                                            <!--<label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_Voucher('{VOUCHER_NO}','{TRANTYPE}')">-->
                                                                            <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_JobView('{EXPTNO}')" >
                                                                                <xsl:value-of select="EXPTNO" />
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
                                            </table>
                                        </td>
                                    </tr>

                                </xsl:for-each>
                            </xsl:if>
                            <xsl:if test="$GRID ='2'">
                                <xsl:for-each select="//NewDataSet/Table1">
                                    <xsl:variable name="ID" select="ORDERNOSTYLENO"></xsl:variable>
                                    <tr>
                                        <td class="formHeading">
                                            <IMG border="0" alt="expand/collapse section" id="src{ORDERNOSTYLENO}p" child="src{ORDERNOSTYLENO}" name="{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic('{ORDERNOSTYLENO}','c')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                            <label  style="color: #0000FF" >
                                                <xsl:value-of select="ORDERNOSTYLENO" disable-output-escaping="yes"/>
                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <table class="collapsed" bgcolor="#ffffff" id="src{ORDERNOSTYLENO}" width="100%">
                                                <tr class="formHeading">
                                                    <td width="10px" class="summaryDetail">
                                                        <IMG border="0" alt="expand/collapse section" id="con_sum{ORDERNOSTYLENO}p" child="con_sum{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                                    </td>
                                                    <td colspan="9" width="730px" class="summaryDetail">
                                                        [INCOMING DETAILS]
                                                    </td>
                                                </tr>
                                                <tr class="collapsed" bgcolor="#ffffff" id="con_sum{ORDERNOSTYLENO}">
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

                                                                <td width="75px" class="formHeading"> LRD</td>

                                                                <td width="75px" class="formHeading"> MDD</td>

                                                                <td width="80px" class="formHeading"> QTY</td>
                                                                <td width="75px" class="formHeading"> Cartons</td>
                                                                <td width="75px" class="formHeading"> Volume</td>
                                                                <td width="75px" class="formHeading"> INC_RECIED_DT </td>

                                                            </tr>
                                                            <xsl:for-each select="//NewDataSet/Table1">
                                                                <xsl:variable name="IN_ORDERNOSTYLENO" select="ORDERNOSTYLENO"></xsl:variable>
                                                                <xsl:if test="$ID = ORDERNOSTYLENO">
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
                                                                                <xsl:value-of select="LRD_INT" />
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
                                                                    </tr>

                                                                </xsl:if>
                                                            </xsl:for-each>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="10px" class="summaryDetail">
                                                        <IMG border="0" alt="expand/collapse section" id="con_sum{ORDERNOSTYLENO}p" child="book_sum{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                                    </td>
                                                    <td colspan="9" width="730px" class="formHeading">
                                                        [BOOKING DETAILS]
                                                    </td>
                                                </tr>
                                                <tr class="collapsed" bgcolor="#ffffff" id="book_sum{ORDERNOSTYLENO}">

                                                    <td class="summaryDetail">
                                                    </td>
                                                    <td colspan="9" class="summaryDetail">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr class="formHeading">
                                                                <td></td>
                                                                <td width="150px" class="formHeading"> Booking Dt</td>
                                                                <td width="150px" class="formHeading"> Mode</td>
                                                                <td width="150px" class="formHeading"> Origin</td>
                                                                <td width="150px" class="formHeading">Exptno</td>
                                                                <td width="150px" class="formHeading"> Pieces</td>
                                                                <td width="150px" class="formHeading"> Consignee</td>
                                                                <td width="150px" class="formHeading"> Cargo Expt</td>
                                                                <td width="150px" class="formHeading"> Doc Expt</td>
                                                                <td width="150px" class="formHeading"> Appr Expt</td>
                                                                <td width="150px" class="formHeading"> ETD</td>
                                                                <td width="150px" class="formHeading"> ETA</td>
                                                            </tr>
                                                            <xsl:for-each select="//NewDataSet/Table2">
                                                                <xsl:variable name="BK_ORDERNOSTYLENO" select="ORDERNOSTYLENO"></xsl:variable>
                                                                <xsl:if test="$ID = ORDERNOSTYLENO">
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
                                                                            <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_JobView('{EXPTNO}')" >
                                                                                <xsl:value-of select="EXPTNO" />
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
                                            </table>
                                        </td>
                                    </tr>
                                </xsl:for-each>                                             
                            </xsl:if>
                            <xsl:if test="$GRID ='3'">
                                <xsl:for-each select="//NewDataSet/Table1">
                                    <xsl:variable name="ID" select="ORDERNOSTYLENO"></xsl:variable>
                                    <tr>
                                        <td class="formHeading">
                                            <IMG border="0" alt="expand/collapse section" id="src{ORDERNOSTYLENO}p" child="src{ORDERNOSTYLENO}" name="{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic('{ORDERNOSTYLENO}','c')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                            <label  style="color: #0000FF" >
                                                <xsl:value-of select="ORDERNOSTYLENO" disable-output-escaping="yes"/>
                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <table class="collapsed" bgcolor="#ffffff" id="src{ORDERNOSTYLENO}" width="100%">
                                                <tr class="formHeading">
                                                    <td width="10px" class="summaryDetail">
                                                        <IMG border="0" alt="expand/collapse section" id="con_sum{ORDERNOSTYLENO}p" child="con_sum{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                                    </td>
                                                    <td colspan="9" width="730px" class="summaryDetail">
                                                        [INCOMING DETAILS]
                                                    </td>
                                                </tr>
                                                <tr class="collapsed" bgcolor="#ffffff" id="con_sum{ORDERNOSTYLENO}">
                                                    <td class="summaryDetail">
                                                    </td>
                                                    <td colspan="9" class="summaryDetail">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr class="formHeading">
                                                                <td></td>
                                                                <td width="80px" class="formHeading"> Origin</td>
                                                                <td width="85px"  class="formHeading">Mode</td>
                                                                <td width="150px" class="formHeading">Shipper</td>                                                                 
                                                                <td width="75px" class="formHeading"> Incoterm</td>
                                                                <td width="75px" class="formHeading"> Shipment dt</td>
                                                                <td width="75px" class="formHeading"> MAD</td>
                                                                <td width="80px" class="formHeading"> QTY</td>
                                                                <td width="75px" class="formHeading"> QTY_GreenLight</td>
                                                                <td width="75px" class="formHeading"> GreenLight_ dt</td>
                                                                <td width="75px" class="formHeading"> INC_RECIED_DT </td>

                                                            </tr>
                                                            <xsl:for-each select="//NewDataSet/Table1">
                                                                <xsl:variable name="IN_ORDERNOSTYLENO" select="ORDERNOSTYLENO"></xsl:variable>
                                                                <xsl:if test="$ID = ORDERNOSTYLENO">
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
                                                                                <xsl:value-of select="MODE_SHIPMENT" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="SUPPLIER_NAME" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="INCOTERM" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="SHIPMENTDT" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>

                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="MAD" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>


                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="BOOK_QTY" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>

                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="QTY_GREENLIGHT" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="DT_GREENLIGHT" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="INC_RECIED_DT"/>
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
                                                        <IMG border="0" alt="expand/collapse section" id="con_sum{ORDERNOSTYLENO}p" child="book_sum{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                                    </td>
                                                    <td colspan="9" width="730px" class="formHeading">
                                                        [BOOKING DETAILS]
                                                    </td>
                                                </tr>
                                                <tr class="collapsed" bgcolor="#ffffff" id="book_sum{ORDERNOSTYLENO}">

                                                    <td class="summaryDetail">
                                                    </td>
                                                    <td colspan="9" class="summaryDetail">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr class="formHeading">
                                                                <td></td>
                                                                <td width="150px" class="formHeading"> Booking Dt</td>
                                                                <td width="150px" class="formHeading"> Mode</td>
                                                                <td width="150px" class="formHeading"> Origin</td>
                                                                <td width="150px" class="formHeading">Exptno</td>
                                                                <td width="150px" class="formHeading"> Pieces</td>
                                                                <td width="150px" class="formHeading"> Consignee</td>
                                                                <td width="150px" class="formHeading"> Cargo Expt</td>
                                                                <td width="150px" class="formHeading"> Doc Expt</td>
                                                                <td width="150px" class="formHeading"> Appr Expt</td>
                                                                <td width="150px" class="formHeading"> ETD</td>
                                                                <td width="150px" class="formHeading"> ETA</td>
                                                            </tr>
                                                            <xsl:for-each select="//NewDataSet/Table2">
                                                                <xsl:variable name="BK_ORDERNOSTYLENO" select="ORDERNOSTYLENO"></xsl:variable>
                                                                <xsl:if test="$ID = ORDERNOSTYLENO">
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
                                                                            <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_JobView('{EXPTNO}')" >
                                                                                <xsl:value-of select="EXPTNO" />
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
                                            </table>
                                        </td>
                                    </tr>
                                </xsl:for-each>
                            </xsl:if>

                            <xsl:if test="$GRID ='0'">
                                <xsl:for-each select="//NewDataSet/Table1">
                                    <xsl:variable name="ID" select="ORDERNOSTYLENO"></xsl:variable>
                                    <tr>
                                        <td class="formHeading">
                                            <IMG border="0" alt="expand/collapse section" id="src{ORDERNOSTYLENO}p" child="src{ORDERNOSTYLENO}" name="{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic('{ORDERNOSTYLENO}','c')" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                            <label  style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_Order()"  >
                                                <xsl:value-of select="ORDERNOSTYLENO" disable-output-escaping="yes"/>
                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="9">
                                            <table class="collapsed" bgcolor="#ffffff" id="src{ORDERNOSTYLENO}" width="100%">
                                                <tr class="formHeading">
                                                    <td width="10px" class="summaryDetail">
                                                        <IMG border="0" alt="expand/collapse section" id="con_sum{ORDERNOSTYLENO}p" child="con_sum{ORDERNOSTYLENO}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
                                                    </td>
                                                    <td colspan="9" width="730px" class="summaryDetail">
                                                        [ORDER FOLLOW UP DETAILS]
                                                    </td>
                                                </tr>
                                                <tr class="collapsed" bgcolor="#ffffff" id="con_sum{ORDERNOSTYLENO}">
                                                    <td class="summaryDetail">
                                                    </td>
                                                    <td colspan="9" class="summaryDetail">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr class="formHeading">
                                                                <td></td>
                                                                <td width="80px" class="formHeading"> Origin</td>
                                                                <td width="85px"  class="formHeading">Mode</td>
                                                                <td width="150px" class="formHeading">Exptno</td>
                                                                <td width="150px" class="formHeading">Shipper</td>
                                                                <td width="75px" class="formHeading"> Incoterm</td>
                                                                <td width="75px" class="formHeading"  > Shipmentdt</td>
                                                                <td width="75px" class="formHeading"> pcs</td>
                                                                <td width="80px" class="formHeading"> CBM</td>
                                                                <td width="75px" class="formHeading"> Entrydt</td>

                                                            </tr>
                                                            <xsl:for-each select="//NewDataSet/Table1">
                                                                <xsl:variable name="IN_ORDERNOSTYLENO" select="ORDERNOSTYLENO"></xsl:variable>
                                                                <xsl:if test="$ID = ORDERNOSTYLENO">
                                                                    <tr>
                                                                        <td></td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="origin" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="mode" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="javascript:return parent.fnClick_JobView('{EXPTNO}')" >
                                                                                <xsl:value-of select="EXPTNO" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="SHIPPER_NAME" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="incoterm" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="ersthpdt" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>

                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="typeofpcs" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="cbm" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                                            </label>
                                                                        </td>
                                                                        <td class="summaryDetail" style="text-align:left;">
                                                                            <label style="color: #0000FF" >
                                                                                <xsl:value-of select="entrydt" />
                                                                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
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
                            </xsl:if>
                                                                                
                        </xsl:for-each>
                    </table>
                </div>
            </body>

        </html>
    </xsl:template>
</xsl:stylesheet>
