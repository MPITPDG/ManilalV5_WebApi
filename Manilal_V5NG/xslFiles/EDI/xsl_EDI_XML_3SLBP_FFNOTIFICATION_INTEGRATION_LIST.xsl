<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <link href="../../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
      </head>
      <body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" onclick="outliner();" >
        <div id="tableContainer" class="divSpace" style="width:100%" >
          <table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="550px">
            <tr class="DataGridFixedHeader">
              <!--<td nowrap="1" width="60px" class="header" ></td>-->
              <td nowrap="1" width="250px" class="header">FILE NAME</td>
			  <td nowrap="1" width="160px" class="header">TYPE</td>
              <!--<td nowrap="1" width="90px" class="header">INCOMING TIME</td>
			  <td nowrap="1" width="90px" class="header">UPLOAD TIME</td>-->
              <td nowrap="1" width="100px" class="header">UPLOADED BY</td>
              
            </tr>
            <xsl:for-each select="//NewDataSet/Table1">
              <tr class="summaryDetail">
                 <!--<td class="summaryDetail"  align="center" >
						      <img src="../../include/img/edit_item.gif" class="cur"  onclick="parent.fnPopulate_BRBPCRCPCE_Dtls('{ID}','{ENTRYNO}','{CLIENT}','{JOBNO}','{BILLNO}','{DEDUCTION}','{AMOUNT}','{ENTRYTYPE}','{EMP_CODE}','{USERNAME}','{CRPARENTENTRYNO}','{NARRATION}','{IS_NOT_EDIT_ABLE}','{ITEMCODE}','{DEPTID}','{VGUID}','{ACCOUNT_NAME}','{ITEM}','{DEPARTMENT}','{ACC_BANKDTLS_ID}','{CB_STATUS}','{ISJOBREPORT}','{EMP_CODE_VALUE}','{ITEM_DATAVALUE}')" alt="Edit Details {ACCOUNT_NAME}"/>
						      <img src="../../include/img/thrash.gif" class="cur"  onclick="parent.fnDelete_BRBPCRCPCE_Dtls('{ID}','{VGUID}','{IS_NOT_EDIT_ABLE}','{ACC_BANKDTLS_ID}')" alt="Delete Details {ACCOUNT_NAME}" />
					      </td>-->
                <td class="summaryDetail" NOWRAP="" align="left">
                  <xsl:value-of select="FILENAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
				<td class="summaryDetail" NOWRAP="" align="right">
					<xsl:value-of select="TYPE" />
					<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
				</td>
				  <!--<td class="summaryDetail" NOWRAP="" align="right">
                  <xsl:value-of select="INCOMING_TIME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
				  <td class="summaryDetail" NOWRAP="" align="right">
					  <xsl:value-of select="UPLOAD_TIME" />
					  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
				  </td>-->
                <td class="summaryDetail" NOWRAP="" align="right">
                  <xsl:value-of select="MAKERID" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                
              </tr>
            </xsl:for-each>
            <tr valign="top">
              <td colspan="3" class="foot">
                <xsl:if test="count(//NewDataSet/Table1)!=1">
                  <xsl:value-of select="count(//NewDataSet/Table1)"/> Records
                </xsl:if>
                <xsl:if test="count(//NewDataSet/Table1)=1">
                  1 Record
                </xsl:if>
              </td>
            </tr>
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>