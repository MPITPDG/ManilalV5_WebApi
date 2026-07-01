<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div id="tableContainer" class="divSpace">
      <table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" width="750px">
        <tr class="DataGridFixedHeader" height="20px">
          <td nowrap="1" width="60px" class="header" ></td>
          <td nowrap="1" width="100px" class="header">Account</td>
          <td nowrap="1" width="80px" class="header">Amount</td>
          <td nowrap="1" width="80px" class="header">Type</td>
			<td nowrap="1" width="100px" class="header">Supplier</td>
          <td nowrap="1" width="150px" class="header">Our Truck</td>
		  <td nowrap="1" width="150px" class="header">Remark</td>
        </tr>
        <xsl:for-each select="//NewDataSet/Table">
          <tr class="summaryDetail">
            <td class="summaryDetail"  align="center" >
              <img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_Provision('{ID}','{PRO_JOBNO}','{SUPPLIER}','{ACCOUNT}','{AMOUNT}','{PRO_TYPE}','{FK_TRUCKID}','{IS_NOT_EDIT_ABLE}','{REMARK}','{ISAUTHORISED}','{TYPENAME}')" alt="Edit Provision Details {ACCOUNT_NAME}"/>
              <img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fnDelete_Provision('{ID}','{PRO_JOBNO}','{IS_NOT_EDIT_ABLE}','{ACCOUNT_NAME}','{ISAUTHORISED}')" alt="Delete Provision Details {ACCOUNT_NAME}" />
            </td>
            
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="ACCOUNT_NAME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="right">
              <xsl:value-of select="AMOUNT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="right">
              <xsl:value-of select="TYPENAME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
			  <td class="summaryDetail" NOWRAP="" align="left">
				  <xsl:value-of select="SUPPLIER_NAME" />
				  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
			  </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="OUR_TRUCK" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
		  <td class="summaryDetail" NOWRAP="" align="left">
			  <xsl:value-of select="REMARK" />
			  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
		  </td>  
          </tr>
        </xsl:for-each>
        <tr valign="top">
          <td colspan="7" class="foot">
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
