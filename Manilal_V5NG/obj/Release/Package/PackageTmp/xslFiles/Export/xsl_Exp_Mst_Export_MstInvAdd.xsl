<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <div id="tableContainer" class="divSpace">
            <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="800px">
                <tr class="DataGridFixedHeader">
                    <td nowrap="1" class="header">Action</td>
                    <td nowrap="1" class="header">Invoicing Address</td>
                    <td nowrap="1" class="header">GST No.</td>
                    <td nowrap="1" class="header">GST ARN No.</td>
                </tr>
                <xsl:for-each select="//NewDataSet/Table1">
                    <tr class="summaryDetail">
                        <td class="summaryDetail"  align="center" >
                            <img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_Exp_MstInvAdd('{ID}','{INVADD1}','{INVADD2}','{INVADD3}','{INPINCODE}','{INVPINPOS}','{INVCITY}','{INVSTATE}','{INVCOUNTRY}','{GST_NO}','{GST_ARNNO}','{GSTTITLE}','{GSTCONTP}','{GSTTELNO}','{GSTMOBNO}','{GSTCONTEMAIL}','{INVSTATETIN}')" alt="Edit Details {INVADDRESS}"/>
                            <!--<img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fnDelete_Exp_MstInvAdd('{ID}')" alt="Delete Details {INVADDRESS}" />-->
                        </td>
                        <td class="summaryDetail" NOWRAP="" align="left">
                            <xsl:value-of select="INVADDRESS" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail" NOWRAP="" align="left">
                            <xsl:value-of select="GST_NO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail" NOWRAP="" align="left">
                            <xsl:value-of select="GST_ARNNO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                    </tr>
                </xsl:for-each>
                <tr valign="top">
                    <td colspan="8" class="foot">
                        <xsl:if test="count(//NewDataSet/Table1)!=1">
                            <xsl:value-of select="count(//NewDataSet/Table1)"/> Records
                        </xsl:if>
                        <xsl:if test="count(//NewDataSet/Table1)=1">
                            1 Record
                        </xsl:if>
                    </td>
                </tr>
            </table>
        </div>
    </xsl:template>
</xsl:stylesheet>
