<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
            <tr>
                <td nowrap="1" class="header">Type Of Charge</td>
                <td nowrap="1" class="header">Receipt Number</td>
                <td nowrap="1" class="header">Paid Date</td>
                <td nowrap="1" class="header">Amount</td>
                <td nowrap="1" class="header">Remark</td>
                <td nowrap="1" width="20px" class="header" ></td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table">
                <tr class="row">
                    <td class="content" align="left">
                        <xsl:value-of select="SteType" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="SteRecNo" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="StePaydt" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="SteAmount" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="SteRemark" />
                    </td>
                    <td class="content"  align="center">
                        <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="fnEdit_SteAgent_Dtls('{pk_tblIndex}','{SteType}','{SteRecNo}','{StePaydt}','{SteAmount}','{SteTypeValue}','{SteRemark}')" alt="Edit Steamer Agent Charge Details {SteRecNo}"/>
                        <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="fnDelete_SteAgent_Dtls('{pk_tblIndex}','{SteRecNo}')" alt="Delete Steamer Agent Charge Details{SteRecNo}"/>
                    </td>
                </tr>
            </xsl:for-each>
            <tr valign="top">
                <td colspan="6" class="foot">
                    <xsl:if test="count(//NewDataSet/Table)!=1">
                        <xsl:value-of select="count(//NewDataSet/Table)"/> Records
                    </xsl:if>
                    <xsl:if test="count(//NewDataSet/Table)=1">
                        1 Record
                    </xsl:if>
                </td>
            </tr>
        </table>
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

        </table>

    </xsl:template>
</xsl:stylesheet>
