<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
      <tr>
        <td nowrap="1" width="300px" class="header">Document Name</td>
        <td nowrap="1" width="150px" class="header">Recevied On</td>
        <td nowrap="1" width="150px" class="header">Acknowledged On</td>
        <td nowrap="1" width="50px" class="header" ></td>
      </tr>
      <xsl:for-each select="//NewDataSet/Table">
        <tr class="row">
          <td class="content" align="left">
            <xsl:value-of select="DocName" />
          </td>
          <td class="content" align="left">
            <xsl:value-of select="ReceivedOn" />
          </td>
          <td class="content" align="left">
            <xsl:value-of select="AcknowledgedOn" />
          </td>
          <td class="content"  align="center">
            <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="fnEdit_DocCallForUs_Dtls('{pk_tblIndex}','{DocName}','{ReceivedOn}','{ISEDIT}')" alt="Edit Document Call For Us Details {DocName}"/>
            <img src="../../INCLUDE/img/thrash.gif" class="cur"  onclick="fnDelete_DocCallForUs_Dtls('{pk_tblIndex}','{DocName}','{ISEDIT}')" alt="Delete Document Call For Us Details{DocName}"/>
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="4" class="foot">
          <xsl:if test="count(//NewDataSet/Table)!=1">
            <xsl:value-of select="count(//NewDataSet/Table)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/Table)=1">
            1 Record
          </xsl:if>
        </td>
      </tr>
    </table>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

    </table>

  </xsl:template>
</xsl:stylesheet>
