<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
      </head>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="850px">
      <tr class="DataGridFixedHeader">
        <!--<td nowrap="1" class="header"></td>-->
        <td nowrap="1" class="header">JOBNO</td>
        <td nowrap="1" class="header">PKG</td>
        <td nowrap="1" class="header">PROP.wEIGHT</td>
         
      </tr>
      <xsl:for-each select="//NewDataSet/Table1">
        <tr class="summaryDetail">
          <!--<td class="summaryDetail"  align="center">
            <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fnEdit_Pur_Dtls('{ID}','{INVNO}','{JOBNO}','{NOOFPKGS}','{WEIGHT}' )" alt="Edit Invoice Job Details({JOBNO})"/>            
          </td>-->
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="JOBNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="NOOFPKGS" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="WEIGHT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
           
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="7" class="foot">
          <xsl:if test="count(//NewDataSet/Table1)!=1">
            <xsl:value-of select="count(//NewDataSet/Table1)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/Table1)=1">
            1 Record
          </xsl:if>
        </td>
      </tr>
    </table>
    </html>
  </xsl:template>
</xsl:stylesheet>
