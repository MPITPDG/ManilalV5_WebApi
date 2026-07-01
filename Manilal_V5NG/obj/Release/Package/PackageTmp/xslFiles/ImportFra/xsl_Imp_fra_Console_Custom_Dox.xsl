<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <div id="tableContainer" class="divSpace">
            <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
                <tr class="DataGridFixedHeader">
                    <td nowrap="1" width="60px" class="header" ></td>
                    <td nowrap="1" class="header">Custom Dox Type</td>
                    <td nowrap="1" class="header">Custom Dox No</td>
                    <td nowrap="1" class="header">Custom Dox Dt</td>
                    <td nowrap="1" class="header">No Of Pallet </td>

                </tr>
                <xsl:for-each select="//NewDataSet/Table1">
                    <tr class="summaryDetail">
                        <td class="summaryDetail"  align="center" >
                            <img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_DoxType('{PKID}','{FK_CUSTOM_DOX_TYPE}','{CUSTOM_CLEAR_NO}','{CUSTOM_CLEAR_DT}','{NO_OF_PALLET}')" alt="Edit Details {id}"/>

                        </td>
                        <td class="summaryDetail" NOWRAP="" align="left">
                            <xsl:value-of select="CUSTOM_DOX_TYPE" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail" NOWRAP="" align="left">
                            <xsl:value-of select="CUSTOM_CLEAR_NO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail" NOWRAP="" align="left">
                            <xsl:value-of select="CUSTOM_CLEAR_DT" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>
                        <td class="summaryDetail" NOWRAP="" align="left">
                            <xsl:value-of select="NO_OF_PALLET" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </td>


                    </tr>
                </xsl:for-each>
            </table>
        </div>
    </xsl:template>
</xsl:stylesheet>
