<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <STYLE>
      .initial { background-color: #DDDDDD; color:#000000 }
      .normal { background-color: #CCCCCC }
      .highlight { background-color: #8888FF }
    </STYLE>


    <table cellpadding="0" cellspacing="0" WIDTH="100%" height="100%" class="MailsummaryDetail1">
      <xsl:for-each select="//NewDataSet/Table">
        <tr valign="top" height="20px">
          <td class="formheading">
            <xsl:value-of select="ALERT_TYPE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;-&amp;nbsp;</xsl:text>
            <xsl:value-of select="ALERT_DESC" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;-&amp;nbsp;</xsl:text>
            <xsl:value-of select="CITY" />
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top" height="100%" width="100%">
        <td>
          <div class="divSpace" width="100%">
            <table cellpadding="2" cellspacing="0" WIDTH="100%">
              <tr class="DataGridFixedHeader">
                <td nowrap="1" class="MailHead">
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="MailHead">
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="MailHead">STARTED</td>
                <td nowrap="1" class="MailHead">COMPLETED</td>
                <td nowrap="1" class="MailHead">REMARKS</td>
                <td nowrap="1" class="MailHead">USER NAME</td>
              </tr>
              <xsl:for-each select="//NewDataSet/Table1">
                <tr nowrap="1" id="{PKID}" class="MailsummaryDetail" onclick="parent.fnClick_Mail('{PKID}','{STATUS}','{REMARKS}')" onMouseOver="parent.fn_LogMail_Css(this,'Over')" onMouseOut="parent.fn_LogMail_Css(this,'Out')">
                  <td align="left" class="MailLog">
                    <xsl:choose>
                      <xsl:when test ="STATUS='COMPLETED'">
                        <img src="../../include/img/right1.gif" alt="Completed"></img>
                      </xsl:when>
                      <xsl:otherwise>
                        <img src="../../include/img/icon-delete.gif" alt="Incompleted"></img>
                      </xsl:otherwise>
                    </xsl:choose>
                  </td>
                  <td class="MailLog" width="17px">
                    <img src="../../include/img/mifiles.gif" alt="View mail in new window." onclick="parent.fnClick_MailNew('{PKID}','{STATUS}','{REMARKS}')"></img>
                  </td>

                  <td nowrap="1" class="MailLog">
                    <xsl:value-of select="STARTED" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td nowrap="1" class="MailLog">
                    <xsl:value-of select="COMPLETED" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td align="left" class="MailLog">
                    <xsl:value-of select="REMARKS" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td nowrap="1" align="left" class="MailLog">
                    <xsl:value-of select="USERNAME" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td>
                    <xsl:if test="ISADMIN='SA'">
                      <img src="../../include/img/file.gif" alt="View Log." onclick="parent.fnClick_MailLog('{PKID}','{STATUS}','{REMARKS}')"></img>
                    </xsl:if>
                  </td>
                </tr>
              </xsl:for-each>
            </table>
          </div>
        </td>
      </tr>
      <tr>
        <td></td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet>
