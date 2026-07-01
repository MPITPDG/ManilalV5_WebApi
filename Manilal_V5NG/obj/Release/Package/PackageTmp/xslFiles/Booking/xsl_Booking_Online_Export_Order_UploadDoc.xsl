<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>

        <!--<link href="../include/css/ManilalStyleSheet.css" type="text/css" rel="stylesheet" />-->
        <link href="../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
      </head>

      <table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
        <tr class="DataGridFixedHeader">
          <td nowrap="1" width="100px" class="header" ></td>
          <td nowrap="1" width="325px" class="header">Doc Name</td>
          <td nowrap="1" width="325px" class="header">File Name</td>
          <!--<td nowrap="1" width="100px" class="header">View</td>-->
        </tr>

        <xsl:if test="count(//NewDataSet/Table1)!=''">
          <xsl:for-each select="//NewDataSet/Table1">
            <tr class="summaryDetail">
              <td class="summaryDetail"  align="center" >
                <!--<img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_UploadDoc('{ID}','{DOC_ID}','{FILENAME}','{FULLPATH}')" alt="Edit Details {id}"/>-->
                <!--<img src="../include/img/thrash.gif" class="cur"  onclick="parent.fn_UploadDoc_delete('{UPLOADID}','{UPLOADPATH}')" alt="Remove document {DOCNAME}" />-->
              </td>
              <td class="summaryDetail" NOWRAP="" align="left">
                <xsl:value-of select="DOCNAME" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="summaryDetail" NOWRAP="" align="left">
                <xsl:value-of select="FILENAME" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <!--<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="FULLPATH" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>-->
            </tr>
          </xsl:for-each>
        </xsl:if>
        <xsl:if test="count(//NewDataSet/Table)!=''">
          <xsl:for-each select="//NewDataSet/Table">
            <tr class="summaryDetail">
              <td class="summaryDetail"  align="center" >
                <!--<img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_order('{ID}','{DOC_ID}')" alt="Edit Details {DOCNAME}"/>-->
                <!--<img src="../include/img/thrash.gif" class="cur"  onclick="parent.fn_UploadDoc_delete('{UPLOADID}','{UPLOADPATH}')" alt="Remove document {DOCNAME}" />-->
              </td>
              <td class="summaryDetail" NOWRAP="" align="left">
                <xsl:value-of select="DOCNAME" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td class="summaryDetail" NOWRAP="" align="left">
                <xsl:value-of select="FILENAME" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <!--<td class="summaryDetail" NOWRAP="" align="left">
										<xsl:value-of select="FULLPATH" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</td>-->
            </tr>
          </xsl:for-each>

        </xsl:if>
        <tr valign="top">
          <td colspan="3" class="foot">
            <xsl:choose>
              <xsl:when test="count(//NewDataSet/Table1)!=''">
                <xsl:value-of select="count(//NewDataSet/Table)"/> Records
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
    </html>
  </xsl:template>
</xsl:stylesheet>
