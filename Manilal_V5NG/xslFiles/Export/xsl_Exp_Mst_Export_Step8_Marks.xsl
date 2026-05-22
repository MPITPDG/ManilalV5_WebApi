<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div id="tableContainer" class="divSpace">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
      <tr class="DataGridFixedHeader">
        <td nowrap="1" width="10px" class="header" ></td>
        <td nowrap="1" width="100%" class="header">Marks and Remarks</td>
      </tr>
      <xsl:for-each select="//NewDataSet/Table">
        <tr class="row">
          <td class="summaryDetail"  align="center">
            <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fnEdit_Marks_Dtls('{TBL_INDEXID}','{ID}','{EXPTNO}','{MARKS_REMARKS}')" alt="Edit Details {MARKS_REMARKS}"/>
            <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="parent.fnDelete_Marks_Dtls('{TBL_INDEXID}','{ID}','{EXPTNO}','{MARKS_REMARKS}')" alt="Delete Details{MARKS_REMARKS}"/>
          </td>
          <td class="summaryDetail" align="left">
            <xsl:value-of select="MARKS_REMARKS" />
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="2" class="foot">
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
