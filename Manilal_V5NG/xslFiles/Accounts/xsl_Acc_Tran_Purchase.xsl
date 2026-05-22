<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
            <tr>
                <td nowrap="1" width="150px" class="header">Account Name</td>
                <td nowrap="1" width="120px" class="header">Item</td>
                <td nowrap="1" width="100px" class="header">Job No</td>
                <td nowrap="1" width="100px" class="header">Amount</td>
                <td nowrap="1" width="100px" class="header">Deduction</td>
                <td nowrap="1" width="120px" class="header">Narration</td>
                <td nowrap="1" width="80px" class="header" ></td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table1">
                <tr class="row">
                    <td class="content" align="left">
                        <xsl:value-of select="pur_account_NM" />
                    </td>
                    <td class="content" align="left">
                      <xsl:value-of select="ItemName" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="pur_jobno" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="pur_amount" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="pur_deduction" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="pur_desc" />
                    </td>
                    <td class="content"  align="center" >
                        <img src="../../include/img/edit_item.gif" class="cur"  onclick="fnEdit_Purchase_Dtls('{pk_tblIndex}','{pur_code}','{pur_account}','{pur_account_NM}','{pur_jobno}','{pur_amount}','{pur_deduction}','{pur_desc}','{fk_GUID}','{Detailid}','{ED_Flag}','{ItemCode}','{ItemDate}','{ItemName}')" alt="Edit Details {pur_jobno}"/>
                        <img src="../../include/img/thrash.gif" class="cur"  onclick="fnDelete_Purchase_Dtls('{pk_tblIndex}','{pur_jobno}','{ED_Flag}','{pur_amount}','{pur_deduction}')" alt="Delete Details{pur_jobno}"/>
                    </td>
                </tr>
            </xsl:for-each>
            <tr valign="top">
                <td colspan="7" class="foot">
                    <xsl:if test="count(//NewDataSet/Table1)!=1">
                        <xsl:value-of select="count(//NewDataSet/Table1)"/> Records
                    </xsl:if>
                    <xsl:if test="count(//NewDataSet/Table1)=1">
                        1 Record
                    </xsl:if>
                </td>
            </tr>
        </table>
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

        </table>

    </xsl:template>
</xsl:stylesheet>
