<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
            <tr>
                <td nowrap="1" class="header">Duty Paid</td>
                <td nowrap="1" class="header">Interest INR</td>
                <td nowrap="1" class="header">Duty Paid On</td>
                <td nowrap="1" class="header">Cash No</td>
                <td nowrap="1" class="header">Duty Remarks</td>
                <td nowrap="1" width="20px" class="header" ></td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table">
                <tr class="row">
                    <td class="content" align="left">
                        <xsl:value-of select="DutyPaid" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="DutyIns" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="DutyPaidOn" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="DutyCashNo" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="DutyRemark" />
                    </td>
                    <td class="content"  align="center">
                        <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="fnEdit_Duty_Dtls('{pk_tblIndex}','{DutyPaid}','{DutyIns}','{DutyPaidOn}','{DutyCashNo}','{DutyRemark}')" alt="Edit Duty Details {DutyPaid}"/>
                        <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="fnDelete_Duty_Dtls('{pk_tblIndex}','{DutyPaid}')" alt="Delete Duty Details{DutyPaid}"/>
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
