<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
            <tr>
                <td nowrap="1" width="180px" class="header">Invoice No</td>
                <td nowrap="1" width="250px" class="header">Invoice Date</td>
                <td nowrap="1" width="50px" class="header" ></td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table">
                <tr class="row">
                    <td class="content"  width="180px" align="left">
                        <xsl:value-of select="Invoice_No" />
                    </td>
                    <td class="content"  width="250px" align="left">
                        <xsl:value-of select="Invoice_Date" />
                    </td>
                    <td class="content"  width="50px"  align="center">
                        <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="fnEdit_Invoice_Dtls('{pk_tblIndex}','{Invoice_No}','{Invoice_Date}')" alt="Edit Container Details {ContainerNumber}"/>
                        <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="fnDelete_Invoice_Dtls('{pk_tblIndex}','{Invoice_No}')" alt="Delete Invoice Details{Invoice_No}"/>
                    </td>
                </tr>
            </xsl:for-each>
            <tr valign="top">
                <td colspan="3" class="foot">
                    <xsl:if test="count(//NewDataSet/Table)!=1">
                        <xsl:value-of select="count(//NewDataSet/Table)"/> Record(s)
                    </xsl:if>
                    <xsl:if test="count(//NewDataSet/Table)=1">
                        1 Record(s)
                    </xsl:if>
                </td>
            </tr>
        </table>
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

        </table>

    </xsl:template>
</xsl:stylesheet>
