<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" style="width: 100%;">
      <tr class="DataGridFixedHeader">
        <td nowrap="1" width="50px" class="header" ></td>
        <td nowrap="1" width="200px" class="header">From.</td>
        <td nowrap="1" width="200px" class="header">To</td>
        <td nowrap="1" width="280px" class="header">Alphabet</td>
      </tr>
      <xsl:for-each select="//NewDataSet/Table">
        <tr class="summaryDetail">
          <td class="summaryDetail"  align="center">
            <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fnEdit_Pkg_Dtls('{TBL_INDEXID}','{PKGNOID}','{EXPTNO}','{FROM}','{TO}','{ALPHABET}')" alt="Edit Pkg Details"/>
            <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="parent.fnDelete_Pkg_Dtls('{TBL_INDEXID}','{PKGNOID}','{FROM}','{TO}','{EXPTNO}')" alt="Delete Pkg Details"/>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="FROM" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="TO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ALPHABET" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="4" class="foot">
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
