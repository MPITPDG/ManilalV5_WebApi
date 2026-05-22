<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <html>
      <head>
        <link href="../include/css/ManilalStyleSheet_XSLT.css" type="text/css" rel="stylesheet" />
        <!--<link href="../include/css/ManilalStyleSheet.css" type="text/css" rel="stylesheet" />-->
      </head>
      <table cellpadding="0" cellspacing="0" border="0" bordercolor="white" class="infotable" WIDTH="750px">
        <tr class="DataGridFixedHeader">
          <td nowrap="1" width="5px" class="header" ></td>
          <td nowrap="1" width="5px" class="header" ></td>
          <td nowrap="1" width="70px" class="header">Order No.</td>
          <td nowrap="1" width="70px" class="header">Ref. No</td>
          <td nowrap="1" width="100px" class="header">JobNo</td>
          <td nowrap="1" width="100px" class="header">Shipper</td>
          <td nowrap="1" width="100px" class="header">Consignee</td>
          <!--<td nowrap="1" width="100px" class="header">Item Desc</td>-->

          <td nowrap="1" width="50px" class="header">Pcs</td>
          <td nowrap="1" width="60px" class="header">PcsType</td>
          <td nowrap="1" width="50px" class="header">Pkgs</td>
          <td nowrap="1" width="60px" class="header">GrWt</td>
          <!--<td nowrap="1" width="100px" class="header">NetWt</td>-->
          <td nowrap="1" width="50px" class="header">Vol</td>
          <td nowrap="1" width="80px" class="header">Booking On</td>
          <td nowrap="1" width="80px" class="header">Cargo Expected Handover</td>
          <td nowrap="1" width="80px" class="header">Docs Expected Handover</td>
          <!--<td nowrap="1" width="100px" class="header">ETD</td>
                <td nowrap="1" width="100px" class="header">ETA</td>
                <td nowrap="1" width="100px" class="header">Approval Expected</td>
                <td nowrap="1" width="100px" class="header">Cargo Recvd</td>-->


          <!--<td nowrap="1" width="100px" class="header">Exptno </td>-->
        </tr>
        <xsl:for-each select="//NewDataSet/Table">
          <tr class="summaryDetail">
            <td class="summaryDetail"  align="center">
              <img src="../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fnEdit_Booking_OrderNo_Dtls('{ORDERID}','{ORDERNO}','{STYLENO}','{ITEMDESC}','{PIECES}','{TYPEOFPCS}','{PKGS}','{GRWT}','{NETWT}','{VOLUME}','{BOOKINGDT}','{CARGOEXPECT}','{DOCSEXPECT}','{MODE}','{CONCODE}','{EXPCODE}','{EXPORTER}','{EXPTNO}','{IS_REBOOKING}','{ORIGIN}')" alt="Edit OrderNo {ORDERNO} and Style No {STYLENO}"/>
              <!--<img src="../../INCLUDE/img/add.jpg" class="cur"  onclick="parent.fn_NewBookingOrd()" alt="Add New Booking"/>-->
            </td>
            <td class="summaryDetail"  align="center" >
              <img src="../include/img/ARROW_UP1.jpg" class="cur"  onclick="parent.fnUpload_Document('{ORDERNO}','{STYLENO}', '{MODE}','{EXPCODE}')" alt="Upload document For Order No. {ORDERNO} and Style No. {STYLENO}"/>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="ORDERNO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="STYLENO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="EXPTNO" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="EXPORTER" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CONNAME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <!--<td class="summaryDetail" NOWRAP="" align="left">
                        <xsl:value-of select="ITEMDESC" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>-->

            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="PIECES" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="TYPEOFPCS" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="PKGS" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="GRWT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <!--<td class="summaryDetail" NOWRAP="" align="left">
                        <xsl:value-of select="NETWT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>-->
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="VOLUME" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="BOOKINGDT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>

            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="CARGOEXPECT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="DOCSEXPECT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <!--<td class="summaryDetail" NOWRAP="" align="left">
                        <xsl:value-of select="ETDEXPECT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class="summaryDetail" NOWRAP="" align="left">
                        <xsl:value-of select="ETAEXPECT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class="summaryDetail" NOWRAP="" align="left">
                        <xsl:value-of select="APPROVALDT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class="summaryDetail" NOWRAP="" align="left">
                        <xsl:value-of select="CARGORECVDDT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>-->


          </tr>
        </xsl:for-each>
        <tr valign="top">
          <td colspan="15" class="foot">
            <xsl:if test="count(//NewDataSet/Table)!=1">
              <xsl:value-of select="count(//NewDataSet/Table)"/> Records
            </xsl:if>
            <xsl:if test="count(//NewDataSet/Table)=1">
              1 Record
            </xsl:if>
          </td>
        </tr>
      </table>

    </html>
  </xsl:template>
</xsl:stylesheet>
