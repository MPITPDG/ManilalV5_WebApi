<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <script language="javascript" type="text/javascript">
      function fn_Open(CtrlName)
      {
      if(CtrlName != '')
      {
      url = '../../data/'+document.getElementById(CtrlName).value
      window.open(url)
      }
      }
    </script>

    <div id="tableContainer">
      <table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
        <tr class="DataGridFixedHeader">
          <td nowrap="1" width="325px" class="header">Doc Name</td>
          <td nowrap="1" width="325px" class="header">File Name</td>
        </tr>

        <xsl:if test="count(//NewDataSet/Table2)!=''">
          <xsl:for-each select="//NewDataSet/Table2">
            <tr class="summaryDetail">
              <td class="summaryDetail" NOWRAP="" align="left">
                <xsl:value-of select="DOCNAME" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="summaryDetail" NOWRAP="" align="left">
                <A onclick="javascript:fn_Open('hd{UPLOADID}');" style="color:blue;cursor:hand;text-decoration: underline;">
                  <xsl:value-of select="FILENAME" />
                </A>
                <input type="hidden" id="hd{UPLOADID}" runat="server" value="{UPLOADPATH}"/>
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
          </xsl:for-each>
        </xsl:if>
        <xsl:if test="count(//NewDataSet/Table)!=''">
          <xsl:for-each select="//NewDataSet/Table">
            <tr class="summaryDetail">
              <td class="summaryDetail" NOWRAP="" align="left">
                <xsl:value-of select="DOCNAME" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="summaryDetail" NOWRAP="" align="left">
                <A onclick="javascript:fn_Open('hd{UPLOADID}');" style="color:blue;cursor:hand;text-decoration: underline;">
                  <xsl:value-of select="FILENAME" />
                </A>
                <input type="hidden" id="hd{UPLOADID}" runat="server" value="{UPLOADPATH}"/>
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
          </xsl:for-each>

        </xsl:if>
        <tr valign="top">
          <td colspan="2" class="foot">
            <xsl:choose>
              <xsl:when test="count(//NewDataSet/Table2)!=''">
                <xsl:value-of select="count(//NewDataSet/Table2)"/> Records
              </xsl:when>
              <xsl:when test="count(//NewDataSet/Table)!=''">
                <xsl:value-of select="count(//NewDataSet/Table)"/> Records
              </xsl:when>
              <xsl:otherwise>
                0 Record
              </xsl:otherwise>
            </xsl:choose>
          </td>
        </tr>
      </table>
    </div>
  </xsl:template>
</xsl:stylesheet>
