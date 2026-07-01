<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div id="tableContainer" class="divSpace" width="100%">
      <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
        <tr class="DataGridFixedHeader">
          <td nowrap="1" width="100%" class="header">Marks and Remarks</td>
        </tr>
        <xsl:for-each select="//NewDataSet/TblMarks">
          <tr class="row">
            <td class="summaryDetail" align="left">
              <xsl:value-of select="MARKS_REMARKS" />
            </td>
          </tr>
        </xsl:for-each>
        <tr valign="top">
          <td class="foot">
            <xsl:if test="count(//NewDataSet/TblMarks)!=1">
              <xsl:value-of select="count(//NewDataSet/TblMarks)"/> Records
            </xsl:if>
            <xsl:if test="count(//NewDataSet/TblMarks)=1">
              1 Record
            </xsl:if>
          </td>
        </tr>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
