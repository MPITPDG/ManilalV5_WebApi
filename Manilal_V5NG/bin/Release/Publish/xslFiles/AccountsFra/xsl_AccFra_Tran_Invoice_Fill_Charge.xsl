<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
       
            <!--<head>
                <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
            </head>-->
            <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="850px">
                <xsl:for-each select="//NewDataSet/Table">
                    <xsl:variable name="Ex_Rate" select="EX_RATE"></xsl:variable>
                    <tr class="DataGridHeader_xslt">
                        <td nowrap="1" class="header"></td>
                        <td nowrap="1" class="header">CHARG CODE</td>
                        <td nowrap="1" class="header">ACCOUNT NAME</td>
                        <td nowrap="1" class="header">DESCRIPTION</td>
                        <td nowrap="1" class="header">DESCRIPTION1</td>
                        <td nowrap="1" class="header">TAXABLE</td>
                        <td nowrap="1" class="header">EURO</td>
                        <xsl:if test="$Ex_Rate!=1">
                            <td nowrap="1" class="header">DOLLAR AMT</td>
                        </xsl:if>
                    </tr>

                    <xsl:for-each select="//NewDataSet/Table3">
                        <xsl:variable name="CHRGCODE" select="CHRGCODE"></xsl:variable>
                        <xsl:if test="$CHRGCODE!='NORECORD'">
                            <tr class="summaryDetail" >
                                <td  class="summaryDetail"  align="center">
                                    <img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fn_delete_Account('{ID}','{is_Editable}','{CHRGCODE}')" alt="Edit Details "/>
                                    <img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fn_populate_Account('{ID}' ,'{CHRGCODE}','{ACCOUNT}','{CHRGDESC}','{CHRGDESC1}','{TAXABLE}','{AMTEURO}','{is_Editable}','{AMT}')" alt="Edit Invoice Charg Details({CHRGCODE})"/>
                                </td>
                                <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                    <xsl:value-of select="CHRGCODE" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </td>
                                <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                    <xsl:value-of select="ACCOUNT_NAME" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </td>
                                <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                    <xsl:value-of select="CHRGDESC" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </td>
                                <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                    <xsl:value-of select="CHRGDESC1" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </td>
                                <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                    <xsl:value-of select="TAXABLE" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </td>
                                <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                    <xsl:value-of select="AMTEURO" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </td>
                                <xsl:if test="$Ex_Rate!=1">
                                    <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                        <xsl:value-of select="AMT" />
                                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                    </td>
                                </xsl:if>
                            </tr>
                        </xsl:if>
                    </xsl:for-each>
                    <xsl:for-each select="//NewDataSet/Table5">
                        <tr >
                            <td class="summaryDetail_xslt"  align="center">
                                <img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fn_delete_Account('{ID}')" alt="Edit Details "/>
                                <img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fn_populate_Account('{ID}' ,'{CHRGCODE}','{ACCOUNT}','{CHRGDESC}','{CHRGDESC1}','{TAXABLE}','{AMTEURO}','{is_Editable}','{AMT}')" alt="Edit Invoice Charg Details({CHRGCODE})"/>
                            </td>
                            <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                <xsl:value-of select="CHRGCODE" />
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                <xsl:value-of select="ACCOUNT_NAME" />
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                <xsl:value-of select="CHRGDESC" />
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                <xsl:value-of select="CHRGDESC1" />
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                <xsl:value-of select="TAXABLE" />
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                <xsl:value-of select="AMTEURO" />
                                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </td>
                            <xsl:if test="$Ex_Rate!=1">
                                <td class="summaryDetail_xslt" NOWRAP="" align="left">
                                    <xsl:value-of select="AMT" />
                                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                                </td>
                            </xsl:if>
                        </tr>
                    </xsl:for-each>

                    <tr valign="top">
                        <xsl:if test="$Ex_Rate!=1">
                            <td colspan="8" class="foot">
                                <xsl:if test="count(//NewDataSet/Table3)!=1">
                                    <xsl:value-of select="count(//NewDataSet/Table3)"/> Records
                                </xsl:if>
                                <xsl:if test="count(//NewDataSet/Table3)=1">
                                    1 Record
                                </xsl:if>
                            </td>
                        </xsl:if>
                        <xsl:if test="$Ex_Rate=1">
                            <td colspan="7" class="foot">
                                <xsl:if test="count(//NewDataSet/Table3)!=1">
                                    <xsl:value-of select="count(//NewDataSet/Table3)"/> Records
                                </xsl:if>
                                <xsl:if test="count(//NewDataSet/Table3)=1">
                                    1 Record
                                </xsl:if>
                            </td>
                        </xsl:if>

                    </tr>
                </xsl:for-each>
            </table>
       
    </xsl:template>
</xsl:stylesheet>
