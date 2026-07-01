<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
      <tr>
        <td nowrap="1" width="150px" class="header">Container Number</td>
        <td nowrap="1" width="250px" class="header">Container Size \ Type</td>
        <td nowrap="1" width="200px" class="header">No Of Packages</td>
        <td nowrap="1" width="50px" class="header" ></td>
      </tr>
      <xsl:for-each select="//NewDataSet/Table">
        <tr class="row">
          <td class="content"  width="180px" align="left">
            <xsl:value-of select="ContainerNumber" />
          </td>
          <td class="content"  width="250px" align="left">
            <xsl:value-of select="ContainerSize" />
          </td>
          <td class="content"  width="200px" align="left">
            <xsl:value-of select="NoOfPackages" />
          </td>
          <td class="content"  width="50px"  align="center">
            <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="fnEdit_Good_Dtls('{pk_tblIndex}','{ContainerNumber}','{ContainerSize}','{NoOfPackages}','{ContLength}','{ContType}')" alt="Edit Container Details {ContainerNumber}"/>
            <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="fnDelete_Good_Dtls('{pk_tblIndex}','{ContainerNumber}')" alt="Delete Container Details{ContainerNumber}"/>
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="4" class="foot">
          <xsl:if test="count(//NewDataSet/Table)!=1">
              No of Container(s) <xsl:value-of select="count(//NewDataSet/Table)"/> 
          </xsl:if>
          <xsl:if test="count(//NewDataSet/Table)=1">
              No of Container(s) 1
          </xsl:if>
        </td>
      </tr>
    </table>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

    </table>

  </xsl:template>
</xsl:stylesheet>
