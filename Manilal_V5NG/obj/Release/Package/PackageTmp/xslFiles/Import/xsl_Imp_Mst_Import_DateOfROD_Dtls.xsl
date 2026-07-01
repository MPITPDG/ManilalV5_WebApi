<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
            <tr>
                <td nowrap="1" width="195px" class="header">Date Of Receipt of Document</td>
                <td nowrap="1" width="425px" class="header">Remarks</td>
                <td nowrap="1" width="100px" class="header" ></td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table">
                <tr class="row">
                    <td class="content" align="left">
                        <xsl:value-of select="DateOfRODdt" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="DateOfRODremark" />
                    </td>
                    <td class="content"  align="center">
                        <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="fnEdit_DateOfROD_Dtls('{pk_tblIndex}','{DateOfRODdt}','{DateOfRODremark}')" alt="Edit Date Of Receipt Of Document Details {DateOfRODdt}"/>
                        <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="fnDelete_DateOfROD_Dtls('{pk_tblIndex}','{DateOfRODdt}')" alt="Delete Date Of Receipt Of Document Details{DateOfRODdt}"/>
                    </td>
                </tr>
            </xsl:for-each>
            <tr valign="top">
                <td colspan="3" class="foot">
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
