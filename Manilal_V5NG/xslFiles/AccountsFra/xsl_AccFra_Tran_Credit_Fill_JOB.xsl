<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <html>
            <head>
                <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
            </head>
            <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="850px">
                <tr class="DataGridHeader_xslt">
                    <td nowrap="1" class="header" ></td>
                    <td nowrap="1" class="header">JOBNO</td>
                    <td nowrap="1" class="header">PKGS</td>
                    <td nowrap="1" class="header">WEIGHT</td>
                    <!--<td nowrap="1" class="header">INVOICENO</td>-->
                </tr>
                <xsl:for-each select="//NewDataSet/Table1">
                    <xsl:variable name="JOBNO" select="JOBNO"></xsl:variable>
                    <tr >
                        <td>
                            <img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fn_deleteJob('{JOBNO}')" alt="Delete Details {JOBNO}" />
                        </td>
                        <td class="summaryDetail_xslt" NOWRAP="" align="left">
                            <xsl:value-of select="JOBNO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt" NOWRAP="" align="left">
                            <xsl:value-of select="PKGS" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail_xslt" NOWRAP="" align="left">
                            <xsl:value-of select="WEIGHT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <!--<td>
                            <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
                                <tr >
                                    <xsl:for-each select="//NewDataSet/Table1">
                                        <xsl:if test="$JOBNO=JOB_NO">
                                            <tr>
                                                <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                                    <label style="color: #0000FF;text-decoration:underline;cursor:hand" onclick="parent.fn_Print_job('{INVNO}')">
                                                        <xsl:value-of select="INVNO" />
                                                    </label>

                                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                                </td>
                                            </tr>
                                        </xsl:if>
                                    </xsl:for-each>
                                </tr>
                            </table>
                        </td>-->

                    </tr>
                </xsl:for-each>
                <tr valign="top">
                    <td colspan="5" class="foot">
                        <xsl:if test="count(//NewDataSet/Table1)!=1">
                            <xsl:value-of select="count(//NewDataSet/Table1)"/> Records
                        </xsl:if>
                        <xsl:if test="count(//NewDataSet/Table1)=1">
                            1 Record
                        </xsl:if>
                    </td>
                </tr>
            </table>
        </html>
    </xsl:template>
</xsl:stylesheet>