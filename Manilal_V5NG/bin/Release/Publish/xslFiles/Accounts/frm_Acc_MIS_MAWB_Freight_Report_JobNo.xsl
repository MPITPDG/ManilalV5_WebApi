<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div class="divSpace" id="tableContainer">
      <table cellpadding="0" cellspacing="0" border="1" bordercolor="white" width="100%">
        <tr height="25px" valign="top">
          <th nowrap="1" width="100px" align="center" class="locked">MAWB No.</th>
          <th nowrap="1" width="100px" align="center" class="locked">MAWB No.</th>
          <th nowrap="1" width="100px" align="center">Job No.</th>
          <th nowrap="1" width="100%" align="center">Client Name</th>
          <th nowrap="1" width="100px" align="right">Expense</th>
          <th nowrap="1" width="100px" align="right">Recovery</th>
          <th nowrap="1" width="100px" align="right">Difference</th>
          <th nowrap="1" width="150px" align="center">Remarks</th>
        </tr>
        <xsl:for-each select="//NewDataSet/Table2">
          <tr>
            <td NOWRAP="" class="locked">
              <b>
                <xsl:value-of select="MAWBNO" />
              </b>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td NOWRAP="" class="locked">
              <b>
                <xsl:value-of select="MAWBDT" />
              </b>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td NOWRAP="">
              <a onclick="javascript:parent.fn_JobSummary1('{JOBNO}','{DRAMT}','{CRAMT}','{DIFF}','{REMARK}');" style="color:Blue;cursor:hand;">
                <b>
                  <xsl:value-of select="JOBNO" />
                </b>
              </a>
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td NOWRAP="">
              <xsl:value-of select="CLIENT_NAME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td NOWRAP="" style="text-align:right;">
              <xsl:value-of select="DRAMT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td NOWRAP="" style="text-align:right;">
              <xsl:value-of select="CRAMT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td NOWRAP="" style="text-align:right;">
              <xsl:value-of select="DIFF" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td NOWRAP="">
              <xsl:value-of select="REMARK" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
          </tr>
        </xsl:for-each>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
