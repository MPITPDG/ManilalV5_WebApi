<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div id="tableContainer" class="divSpace" width="100%">
      <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
        <tr class="DataGridFixedHeader">
          <td nowrap="1" width="20px" class="header" ></td>
          <td nowrap="1" width="100px" class="header">No Of Pkgs</td>
          <td nowrap="1" width="120px" class="header">Recd Date</td>
          <td nowrap="1" width="200px" class="header">Recd Where</td>
          <td nowrap="1" width="120px" class="header">Recd Locally</td>
        </tr>
        <xsl:for-each select="//NewDataSet/Table">
          <tr class="summaryDetail">
            <td class="summaryDetail"  align="center">
              <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_RecpOfCargo_Dtls('{TBL_INDEXID}','{CARGOID}','{GUID}','{EXPTNO}','{NOOFPKGS}','{RECDDATE}','{RECDTIME}','{RECDWHERE}','{RECDLOCAL}','{RECDLOCALTIME}')" alt="Edit Details {NOOFPKGS}"/>
              <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="parent.fnDelete_RecpOfCargo_Dtls('{TBL_INDEXID}','{CARGOID}','{EXPTNO}','{NOOFPKGS}')" alt="Delete Details {NOOFPKGS}'"/>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="NOOFPKGS" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="RECDDATE" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              <xsl:value-of select="RECDTIME" />
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="RECDWHERE" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="RECDLOCAL" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              <xsl:value-of select="RECDLOCALTIME" />
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
    </div>
  </xsl:template>
</xsl:stylesheet>
