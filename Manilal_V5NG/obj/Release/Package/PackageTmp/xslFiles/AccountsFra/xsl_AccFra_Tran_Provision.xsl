<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div id="tableContainer" class="divSpace">
      <table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="100%">
        <tr class="DataGridFixedHeader" height="20px">
          <td nowrap="1" width="60px" class="header" ></td>
          <td nowrap="1" width="100px" class="header">Account</td>
          <td nowrap="1" width="100px" class="header">Provision Euro</td>
          <td nowrap="1" width="100px" class="header">Account Euro</td>
          <td nowrap="1" width="150px" class="header">Remark</td>
        </tr>
        <xsl:for-each select="//NewDataSet/Table">
          <tr class="summaryDetail">
            <td class="summaryDetail"  align="center" >
              <img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_ConsoleProvision_Dtls('{ID}','{ACCOUNT}','{ACCTNAME}','{PROEURO}','{REMARK}')" alt="Edit Provision Details {ACCTNAME}"/>
              <!--<img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fnDelete_Provision('{ID}','{ACCTNAME}','{ISAUTHORISED}')" alt="Delete Provision Details {ACCTNAME}" />-->
            </td>

            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="ACCTNAME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="right">
              <xsl:value-of select="PROEURO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="right">
              <xsl:value-of select="INVOICEEURO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="REMARK" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
          </tr>
        </xsl:for-each>
        <tr valign="top">
          <td colspan="5" class="foot">
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
