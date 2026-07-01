<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
      <tr>
        <td nowrap="1" width="150px" class="header">Account Name</td>
        <td nowrap="1" width="120px" class="header">Item</td>
        <td nowrap="1" width="120px" class="header">Entry Type</td>
        <td nowrap="1" width="100px" class="header">Job No</td>
        <td nowrap="1" width="100px" class="header">Bill No</td>
        <td nowrap="1" width="100px" class="header">Amount</td>
        <td nowrap="1" width="100px" class="header">Deduction</td>
        <td nowrap="1" width="120px" class="header">Department</td>
        <td nowrap="1" width="120px" class="header">Narration</td>
        <td nowrap="1" width="80px" class="header" ></td>
      </tr>
      <xsl:for-each select="//NewDataSet/Table1">
        <tr class="row">
          <td class="content" align="left">
            <xsl:value-of select="Account_Name" />
          </td>
          <td class="content" align="left">
            <xsl:value-of select="Item" />
          </td>
          <td class="content" align="left">
            <xsl:value-of select="JOBNO" />
          </td>
          <td class="content" align="left">
            <xsl:value-of select="BILLNO" />
          </td>
          <td class="content" align="left">
            <xsl:value-of select="AMOUNT" />
          </td>
          <td class="content" align="left">
            <xsl:value-of select="DEDUCTION" />
          </td>
          <td class="content" align="left">
            <xsl:value-of select="Department" />
          </td>
          <td class="content" align="left">
            <xsl:value-of select="NARRATION" />
          </td>
          <td class="content"  align="center" >
            <img src="../../include/img/edit_item.gif" class="cur"  onclick="fnPopulate_BRBPCRCPCE_Dtls('{ID}','{ENTRYNO}','{CLIENT}','{JOBNO}','{BILLNO}','{DEDUCTION}','{AMOUNT}','{ENTRYTYPE}','{EMP_CODE}','{USERNAME}','{CRPARENTENTRYNO}','{NARRATION}','{IS_NOT_EDIT_ABLE}','{ITEMCODE}','{DEPTID}','{VGUID}','{ACCOUNT_NAME}','{ITEM}','{DEPARTMENT}','{ACC_BANKDTLS_ID}','{STATUS}')" alt="Edit Details {Account_Name}"/>
            <img src="../../include/img/thrash.gif" class="cur"  onclick="fnDelete_BRBPCRCPCE_Dtls('{ID}','{VGUID}','{IS_NOT_EDIT_ABLE}',)" alt="Delete Details{Account_Name}"/>
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
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

    </table>

  </xsl:template>
</xsl:stylesheet>
