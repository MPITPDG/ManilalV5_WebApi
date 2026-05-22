<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet.css" type="text/css" rel="stylesheet" />
        <style>
          .expanded
          {
            color: black
          }
          .collapsed
          {
            DISPLAY: none
          }
        </style>
        <script language="javascript">
          function outliner () {
            oMe = window.event.srcElement
            //get child element
            var child = document.all[event.srcElement.getAttribute("child",false)];
            //if child element exists, expand or collapse it.
            if (null != child)
            child.className = child.className == "collapsed" ? "expanded" : "collapsed";
          }

          function changepic() {
            uMe = window.event.srcElement;
            var check = uMe.src.toLowerCase();
            if(check.lastIndexOf("img_plus.gif") != -1)
              uMe.src = "../../include/img/img_Minus.gif"
            else
              uMe.src = "../../include/img/img_Plus.gif"
          }
        </script>

      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" onclick="outliner();">
        <table cellpadding="2" cellspacing="0" width="150px" border="0" bordercolor="white" class="infotable">
          <xsl:for-each select="//NewDataSet/Table">
            <xsl:variable name="ID" select="PKID"></xsl:variable>
            <tr class="MailsummaryDetail">
              <td class="content">
                <IMG border="0" alt="expand/collapse section" child="src{PKID}" name="{PKID}" class="expandable" height="11" onclick="changepic()" src="../../include/img/img_Plus.gif" width="9" ></IMG>
              </td>
              <td class="MailsummaryDetail1">
                <img src="../../include/img/folder.jpg" alt="" width="13px" height="13px"></img>
              </td>
              <td class="MailsummaryDetail1">
                <xsl:value-of select="ALERT_TYPE" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
            <tr class="collapsed" bgcolor="#ffffff" id="src{PKID}">
              <td class="MailsummaryDetail1"></td>
              <td class="MailsummaryDetail1"></td>
              <td>
                <table width="97%" border="1" bordercolor="#dcdcdc" rules="cols" class="MailsummaryDetail">
                  <xsl:for-each select="//NewDataSet/Table1">
                    <xsl:if test="FKID = $ID">
                      <tr>
                        <td class="MailsummaryDetail">
                          <A onclick="javascript:parent.fnClick_AlertType(this,'{ID}')">
                          <img src="../../include/img/mail.jpg" height="11px" border="0" width="9px" alt="{ALERT_TYPE} Mails."></img>
                            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            <xsl:value-of select="CITY_NAME"/>
                          </A>
                        </td>
                      </tr>
                    </xsl:if>
                  </xsl:for-each>
                </table>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>