<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
      <tr class="DataGridFixedHeader">
        <td nowrap="1" width="5px" class="header" ></td>
        <td nowrap="1" width="100px" class="header">Order No.</td>
        <td nowrap="1" width="100px" class="header">Reference No</td>
        <td nowrap="1" width="100px" class="header">Pieces</td>
        <td nowrap="1" width="100px" class="header">Type of Pieces</td>
        <td nowrap="1" width="100px" class="header">Warehouse</td>
        <td nowrap="1" width="100px" class="header">Item Description</td>
        <td nowrap="1" width="100px" class="header">Pkgs</td>
        <td nowrap="1" width="100px" class="header">Gr. Wt</td>
        <td nowrap="1" width="100px" class="header">Net Wt</td>
        <td nowrap="1" width="100px" class="header">Volume</td>
        <td nowrap="1" width="100px" class="header">Chbl. Wt.</td>
        <td nowrap="1" width="100px" class="header">LSD Date</td>
        <td nowrap="1" width="100px" class="header">DRN Date</td>
        <td nowrap="1" width="100px" class="header">FOB Value</td>
        <td nowrap="1" width="100px" class="header">Currency </td>
      </tr>
      <xsl:for-each select="//NewDataSet/Table">
        <tr class="summaryDetail">
          <td class="summaryDetail"  align="center">
            <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fnEdit_OrderNo_Dtls('{TBL_INDEXID}','{ORDERID}','{EXPTNO}','{ORDERNO}','{PIECES}','{TYPEOFPCS}','{WAREHOUSE}','{PKGS}','{GRWT}','{VOLUME}','{NETWT}','{CHBLWT}','{ITEMDESC}','{LSD}','{STYLENO}','{FOBVALUE}','{CURENCY}','{DRNDATE}')" alt="Edit OrderNo Details {ORDERNO}"/>
            <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="parent.fnDelete_OrderNo_Dtls('{TBL_INDEXID}','{ORDERNO}','{ORDERID}','{EXPTNO}')" alt="Delete OrderNo Details{ORDERNO}"/>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ORDERNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="STYLENO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="PIECES" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="TYPEOFPCS" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="WAREHOUSE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ITEMDESC" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="PKGS" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="GRWT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="VOLUME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="NETWT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="CHBLWT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="LSD" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="DRNDATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="FOBVALUE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="CURENCY" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="16" class="foot">
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
