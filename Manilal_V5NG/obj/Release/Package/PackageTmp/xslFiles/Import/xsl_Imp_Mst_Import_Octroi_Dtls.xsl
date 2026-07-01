<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" style="width: 100%;">
            <tr>
                <td nowrap="1" width="150px" class="header">Receipt Number</td>
                <td nowrap="1" width="150px" class="header">Paid Date</td>
                <td nowrap="1" width="150px" class="header">Amount</td>
                <td nowrap="1" width="200px" class="header">Remark</td>
                <td nowrap="1" width="50px" class="header" ></td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table">
                <tr class="row">
                    <td class="content" align="left" width="150px">
                        <xsl:value-of select="OctRecNo" />
                    </td>
                    <td class="content" align="left" width="150px">
                        <xsl:value-of select="OctRecPaidDT" />
                    </td>
                    <td class="content" align="left" width="150px">
                        <xsl:value-of select="OctAmount" />
                    </td>
                    <td class="content" align="left" width="200px">
                        <xsl:value-of select="OctRemark" />
                    </td>
                    <td class="content"  align="center" width="50px">
                        <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="fnEdit_Octroi_Dtls('{pk_tblIndex}','{OctRecNo}','{OctRecPaidDT}','{OctAmount}','{OctRemark}')" alt="Edit Octroi Details {OctRecNo}"/>
                        <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="fnDelete_Octroi_Dtls('{pk_tblIndex}','{OctRecNo}')" alt="Delete Octroi Details{OctRecNo}"/>
                    </td>
                </tr>
            </xsl:for-each>
            <tr valign="top">
                <td colspan="5" class="foot">
                    <xsl:if test="count(//NewDataSet/Table)!=1">
                        <xsl:value-of select="count(//NewDataSet/Table)"/> Records
                    </xsl:if>
                    <xsl:if test="count(//NewDataSet/Table)=1">
                        1 Record
                    </xsl:if>
                </td>
            </tr>
        </table>
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" style="width: 100%;">

        </table>

    </xsl:template>
</xsl:stylesheet>
