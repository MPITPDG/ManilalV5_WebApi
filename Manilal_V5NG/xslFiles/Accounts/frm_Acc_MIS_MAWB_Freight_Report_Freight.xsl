<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div class="divSpace" id="tableContainer">
      <table cellpadding="0" cellspacing="0" border="1" bordercolor="white" width="100%">
        <tr height="25px">
          <th valign="top" class="locked" width="100px">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>
          <th valign="top" class="locked" width="100px">
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </th>          
          <th colspan="3" align="center">TOTAL</th>
          <xsl:for-each select="//NewDataSet/Table">
            <th colspan="3" align="center">
              <xsl:value-of select="ACCTNAME"/>
            </th>
          </xsl:for-each>
        </tr>
        <tr height="25px">
          <th valign="top" class="locked" width="100px">MAWBNO</th>
          <th valign="top" class="locked" width="100px">MAWBDT</th>
          <th nowrap="1" align="center">Expense</th>
          <th nowrap="1" align="center">Recovery</th>
          <th nowrap="1" align="center">Difference</th>
          <xsl:for-each select="//NewDataSet/Table">
            <th nowrap="1" align="center">Expense</th>
            <th nowrap="1" align="center">Recovery</th>
            <th nowrap="1" align="center">Difference</th>
          </xsl:for-each>
        </tr>
        <xsl:for-each select="//NewDataSet/Table1">
          <tr>
            <xsl:for-each select="*">
              <xsl:if test="local-name(.)!='TBL'">
                <xsl:choose>
                  <xsl:when test="local-name(.)='MAWBNO'">
                    <td class="locked">
                      <b>
                        <xsl:value-of select="current()"/>
                      </b>
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                  </xsl:when>
                  <xsl:when test="local-name(.)='MAWBDT'">
                    <td class="locked">
                      <b>
                        <xsl:value-of select="current()"/>
                      </b>
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                  </xsl:when>
                  <xsl:otherwise>
                    <td align="right" style="text-align:right;">
                      <xsl:value-of select="current()"/>
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                  </xsl:otherwise>
                </xsl:choose>
              </xsl:if>
            </xsl:for-each>
          </tr>
        </xsl:for-each>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
