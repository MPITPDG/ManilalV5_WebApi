<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <table border='0' cellpadding='0' cellspacing='0' width='650px' class="subTbl">
      <tr>
        <td>
          <xsl:if test="count(//NewDataSet/Table4)!=0">
            <table border='0' cellpadding='0' cellspacing='0' width='650px'>
              <tr>
                <td class='tdHeaderLeft'>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class='tdHeader'>DATE</td>
                <td class='tdHeader'>TIME</td>
                <td class='tdHeader'>REMARK</td>
              </tr>
              <xsl:for-each select="//NewDataSet/Table4">
                <tr>
                  <td class='tdNormalLeft'>
                    <xsl:value-of select="APPT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="APPTDT" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdNormal'>
                    <xsl:value-of select="APPTTIME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdNormalRight'>
                    <xsl:value-of select="APPTRMRK" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
              </xsl:for-each>
            </table>
          </xsl:if>
        </td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>