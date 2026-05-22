<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
      <table cellpadding="1" cellspacing="1" width="100%" border="0" bordercolor="white" class="infotable">
        <xsl:for-each select="//NewDataSet/Table1">
          <xsl:variable name="CONSOLE" select="CONSOLENO"></xsl:variable>
          <tr class="collapsed" bgcolor="#ffffff" id="CS{CONSOLENO}">
            <td class="summaryDetail">
              <div id="tableContainer" class="divSpace" style="width:100%">
              <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr class="summaryDetail">
                  <td colspan="2">
                    CBM - <xsl:value-of select="VOLUME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td>
                    IMPORTER - 
                  </td>
                  <td colspan="3">
                    <xsl:value-of select="IMPORTER_NAME" disable-output-escaping="yes" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr class="summaryDetail">
                  <td colspan="2">
                    ORIGIN - <xsl:value-of select="SENTFROM" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td colspan="4">
                    DESTINATION - <xsl:value-of select="DESTINATION" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                </tr>
                <tr class="formheading">
                  <td class="header">VOUCHER NO.</td>
                  <td class="header">DATE</td>
                  <td class="header">CHARGE TYPE</td>
                  <td class="header">PAYMENT EURO</td>
                  <td class="header">RECOVERY EURO</td>
                  <td class="header">DIFF EURO.</td>
                </tr>
                <xsl:for-each select="//NewDataSet/Table3">
                  <xsl:if test="$CONSOLE = CONSOLENO_CS">
                    <tr>
                      <td class="summaryDetail">
                        <xsl:value-of select="VOUCHER_NO" disable-output-escaping="yes" />
                      </td>
                      <td class="summaryDetail">
                        <xsl:value-of select="TRAN_DATE" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class="summaryDetail">
                        <xsl:value-of select="CHRGDESC" disable-output-escaping="yes" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class="summaryDetail">
                        <xsl:value-of select="PAYMENT_EURO" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class="summaryDetail">
                        <xsl:value-of select="RECOVERY_EURO" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class="summaryDetail">
                        <xsl:value-of select="DIFF_EURO" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                    </tr>
                  </xsl:if>
                </xsl:for-each>
              </table>
              </div>
            </td>
          </tr>
          <xsl:for-each select="//NewDataSet/Table2">
            <xsl:variable name="ID_JOB" select="JOBNO"></xsl:variable>
            <xsl:if test="CONSOLENO_JOB=$CONSOLE">
              <tr class="collapsed" bgcolor="#ffffff" id="JS{JOBNO}">
                <td class="summaryDetail">
                  <div id="tableContainer" class="divSpace" style="width:100%">
                  <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr class="summaryDetail">
                      <td colspan="2">
                        CBM - <xsl:value-of select="VOLUME" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td>
                        IMPORTER - 
                      </td>
                      <td colspan="3">
                        <xsl:value-of select="IMPORTER_NAME" disable-output-escaping="yes" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                    </tr>
                    <tr class="summaryDetail">
                      <td colspan="2">
                        ORIGIN - <xsl:value-of select="SENTFROM" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td colspan="4">
                        DESTINATION - <xsl:value-of select="DESTINATION" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                    </tr>
                    <tr class="formheading">
                      <td class="header">VOUCHER NO.</td>
                      <td class="header">DATE</td>
                      <td class="headr">CHARGE TYPE</td>
                      <td class="header">PAYMENT EURO</td>
                      <td class="header">RECOVERY EURO</td>
                      <td class="header">DIFF EURO.</td>
                    </tr>
                    <xsl:for-each select="//NewDataSet/Table4">
                      <xsl:if test="$CONSOLE = CONSOLENO_JS and JOBNO_JS=$ID_JOB">
                        <tr>
                          <td class="summaryDetail">
                            <xsl:value-of select="VOUCHER_NO" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td class="summaryDetail">
                            <xsl:value-of select="TRAN_DATE" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td class="summaryDetail">
                            <xsl:value-of select="CHRGDESC" disable-output-escaping="yes"/>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td class="summaryDetail">
                            <xsl:value-of select="PAYMENT_EURO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td class="summaryDetail">
                            <xsl:value-of select="RECOVERY_EURO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                          <td class="summaryDetail">
                            <xsl:value-of select="DIFF_EURO" />
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                          </td>
                        </tr>
                      </xsl:if>
                    </xsl:for-each>
                  </table>
                  </div>
                </td>
              </tr>
            </xsl:if>
          </xsl:for-each>
        </xsl:for-each>
      </table>
  </xsl:template>
</xsl:stylesheet>
