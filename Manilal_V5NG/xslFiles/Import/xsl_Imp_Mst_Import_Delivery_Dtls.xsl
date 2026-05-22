<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" style="width: 100%;">
            <tr>
                <td nowrap="1" width="94px" class="header">Our/Hired</td>
                <td nowrap="1" width="95px" class="header">Truck/Supplier</td>
                <td nowrap="1" width="94px" class="header">Truck No</td>
                <td nowrap="1" width="94px" class="header">Truck Type</td>
                <td nowrap="1" width="94px" class="header">Rate Agreed</td>
                <td nowrap="1" width="94px" class="header">Date</td>
                <td nowrap="1" width="95px" class="header">Remarks</td>
                <td nowrap="1" width="5px" class="header" ></td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table">
                <tr class="row">
                    <td class="content" align="left">
                        <xsl:value-of select="OH_truck" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="truck" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="TruckNo" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="TruckType" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="RateAgreed" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="DelDate" />
                    </td>
                    <td class="content" align="left">
                        <xsl:value-of select="DelRemark" />
                    </td>
                    <td class="content"  align="center">
                        <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="fnEdit_Delivery_Dtls('{pk_tblIndex}','{OH_truck}','{truck}','{TruckNo}','{TruckType}','{RateAgreed}','{DelDate}','{DelRemark}','{trackValue}')" alt="Edit Delivery Details {truck}"/>
                        <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="fnDelete_Delivery_Dtls('{pk_tblIndex}','{truck}')" alt="Delete Delivery Details{truck}"/>
                    </td>
                </tr>
            </xsl:for-each>
            <tr valign="top">
                <td colspan="8" class="foot">
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
