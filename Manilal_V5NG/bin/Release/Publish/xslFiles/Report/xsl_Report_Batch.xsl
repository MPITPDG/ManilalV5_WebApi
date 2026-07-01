<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <div id="tableContainer" class="divSpace">
      <table cellpadding="2" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="100%">
        <tr class="DataGridFixedHeader">
          <td nowrap="1" width="50px" class="header"></td>
          <td nowrap="1" width="130px" class="header">STATUS</td>
          <td nowrap="1" width="50%" class="header">REPORT NAME</td>
          <td nowrap="1" width="50%" class="header">SEARCH CRITERIA</td>
          <td nowrap="1" width="120px" class="header">STARTED</td>
          <td nowrap="1" width="120px" class="header">COMPLETED</td>
          <td nowrap="1" width="120px" class="header">USER NAME</td>
        </tr>
        <xsl:for-each select="//NewDataSet/Table2">
          <xsl:choose>
            <xsl:when test="STATUS='IN PROCESS'">
              <tr nowrap="1" class="cur" style="color:Navy;" onMouseout="this.style.color='Red'" onmouseover="this.style.color='black'"  onclick="parent.fn_InProcess('{PKID}')" alt="View Curent Status {REPORTNAME}">
                <td class="summaryDetail" align="center" >
                  <div width="100%" align="center">
                    <xsl:value-of select="PERCENTAGE" />%
                  </div>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <div width="104px" align="left">
                    <img height="7px" width ="{PERCENTAGE}%" src="../../include/img/progress_bar.gif"></img>
                  </div>

                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="REPORTNAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="SEARCHCRITERIA" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="STARTED" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="COMPLETED" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="USERNAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </xsl:when>
            <xsl:when test="STATUS='DOWNLOAD PENDING'">
              <tr nowrap="1"  class="summaryDetail" style="color:Green;">
                <td class="summaryDetail" align="center" >
                  <div width="100%" align="center">
                    <img src="../../include/img/Dwnload_xl.jpg" class="cur"  onclick="parent.fn_Batch_Download('{PKID}','{MODE}');window.open('../../DATA/ExportToExcelBatch/output/{FILENAME}','','toolbar=no,menubar=no,width=10,height=10,top=0,left=0,scrollbars=no')" alt="Download Report {REPORTNAME}"/>
                  </div>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="STATUS" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="REPORTNAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="SEARCHCRITERIA" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="STARTED" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="COMPLETED" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="USERNAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </xsl:when>
            <xsl:when test="STATUS='CANCELLED'">
              <tr nowrap="1"  class="summaryDetail" style="color:Red;">
                <td class="summaryDetail" align="center" >
                  <div width="100%" align="center">
                    <img src="../../include/img/icon-pencil-x.gif" class="cur" alt="{REPORTNAME} Report is Cancelled "/>
                  </div>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="STATUS" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="REPORTNAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="SEARCHCRITERIA" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="STARTED" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="COMPLETED" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="USERNAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </xsl:when>
            <xsl:otherwise>
              <tr nowrap="1"  class="summaryDetail">
                <td class="summaryDetail" align="center" >
                  <div width="100%" align="center">
                    <img src="../../include/img/download.gif" class="cur"  onclick="parent.fn_Batch_Download('{PKID}','{MODE}');window.open('../../DATA/ExportToExcelBatch/output/{FILENAME}','','toolbar=no,menubar=no,width=10,height=10,top=0,left=0,scrollbars=no')" alt="Download Report {REPORTNAME}"/>
                  </div>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="STATUS" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="REPORTNAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="SEARCHCRITERIA" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="STARTED" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="COMPLETED" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="summaryDetail" align="left">
                  <xsl:value-of select="USERNAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:for-each>
      </table>
    </div>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">
    </table>
  </xsl:template>
</xsl:stylesheet>
