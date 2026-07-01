<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
   
      <!--<head>
        <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
      </head>-->
      <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="830px">
        <tr class="DataGridHeader_xslt">
            <td nowrap="1" class="header"></td>
          <td nowrap="1" class="header">Enclosure</td>
        </tr>
        
          <xsl:for-each select="//NewDataSet/Table2">
            <tr class="summaryDetail"  >
                <td class="summaryDetail" align="center" >
                    <img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fn_Populate_Enclosure('{ID}','{ENCLOSURE}')" alt="Edit Details "/>
                    <img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fnDelete_Enclouser('{ID}')" alt="Delete Details" />
                </td>
              <td class="summaryDetail_xslt" NOWRAP="" align="left">
                <xsl:value-of select="ENCLOSURE" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
          </xsl:for-each>      
         
        <tr valign="top">
          <td colspan="3" class="foot">
            <xsl:if test="count(//NewDataSet/Table2)!=1">
              <xsl:value-of select="count(//NewDataSet/Table2)"/> Records
            </xsl:if>
            
           
          </td>
        </tr>
      </table>
    
  </xsl:template>
</xsl:stylesheet>
