<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <!--<html>
            <head>
                <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
            </head>-->
            <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="850px">
                <tr class="DataGridHeader_xslt">
                    <td nowrap="1" class="header" ></td>
                    <td nowrap="1" class="header">BILL NO</td>
                    <td nowrap="1" class="header">AMT</td>
                     
                    
                </tr>
                <!--<xsl:for-each select="//NewDataSet/Table1">
                    <xsl:variable name="BILL" select="BILL"></xsl:variable>
                  <xsl:if test="$BILL=='BILLNO'">
                    <tr >
                        <td>
                            <img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fn_deleteBILL('{PKID}')" alt="Delete Details {BILLNO}" />
                        </td>
                       
                        <td class="summaryDetail_xslt" NOWRAP="" align="left">
                            <xsl:value-of select="BILLNO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt" NOWRAP="" align="left">
                            <xsl:value-of select="AMT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        

                    </tr>
                       </xsl:if>
                </xsl:for-each>-->
              <xsl:for-each select="//NewDataSet/Table4">
                 <tr >
                        <td>
                            <img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fn_deleteBILL('{PKID}')" alt="Delete Details {BILLNO}" />
                        </td>
                       
                        <td class="summaryDetail_xslt" NOWRAP="" align="left">
                            <xsl:value-of select="BILLNO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt" NOWRAP="" align="left">
                            <xsl:value-of select="AMT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        

                    </tr>
              
              </xsl:for-each>
                <!--<tr valign="top">
                    <td colspan="5" class="foot">
                        <xsl:if test="count(//NewDataSet/Table1)!=1">
                            <xsl:value-of select="count(//NewDataSet/Table1)"/> Records
                        </xsl:if>
                        <xsl:if test="count(//NewDataSet/Table1)=1">
                            1 Record
                        </xsl:if>
                    </td>
                </tr>-->
            </table>
        <!--</html>-->
    </xsl:template>
</xsl:stylesheet>