<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
      </head>
      <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="850px">
        <tr class="DataGridFixedHeader">
          <td nowrap="1" class="header"></td>
          <td nowrap="1" class="header">CHARG CODE</td>
          <td nowrap="1" class="header">ACCOUNT NAME</td>
          <td nowrap="1" class="header">DESCRIPTION</td>
          <td nowrap="1" class="header">DESCRIPTION1</td>
          <td nowrap="1" class="header">TAXABLE</td>
          <td nowrap="1" class="header">EURO</td>
        </tr>
        <xsl:for-each select="//NewDataSet/Table3">
          <tr class="summaryDetail">
            <td class="summaryDetail"  align="center">
              <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fn_populate_Account('{ID}' ,'{CHRGCODE}','{ACCOUNT}','{CHRGDESC}','{CHRGDESC1}','{TAXABLE}','{AMTEURO}','{is_Editable}')" alt="Edit Invoice Charg Details({CHRGCODE})"/>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CHRGCODE" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="ACCOUNT_NAME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CHRGDESC" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CHRGDESC1" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="TAXABLE" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="AMTEURO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
          </tr>
        </xsl:for-each>
        <tr valign="top">
          <td colspan="7" class="foot">
            <xsl:if test="count(//NewDataSet/Table3)!=1">
              <xsl:value-of select="count(//NewDataSet/Table3)"/> Records
            </xsl:if>
            <xsl:if test="count(//NewDataSet/Table3)=1">
              1 Record
            </xsl:if>
          </td>
        </tr>
      </table>
    </html>
  </xsl:template>
</xsl:stylesheet>
