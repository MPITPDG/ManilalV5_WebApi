<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
  
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable" WIDTH="100%">
      <xsl:variable name="cnt" select="0"></xsl:variable>   
      <xsl:for-each select="//NewDataSet/Table">
        <xsl:variable name="GrpId" select="GRPID"></xsl:variable>
        <xsl:if test ="$cnt + position()='1'">
          <tr class="DataGridFixedHeader">          
            <td nowrap="1" width="5px" class="header" ></td>
            <td nowrap="1" width="5px" class="header" ></td>
            <td nowrap="1" width="90px" class="header">Order No.</td>
            <td nowrap="1" width="90px" class="header">Ref. No</td>
            <td nowrap="1" width="100px" class="header">JobNo</td>
            <td nowrap="1" width="100px" class="header">Shipper</td>
            <td nowrap="1" width="100px" class="header">Consignee</td>
            <!--<td nowrap="1" width="100px" class="header">Item Desc</td>-->
            <td nowrap="1" width="60px" class="header">Pieces</td>
            <td nowrap="1" width="60px" class="header">Pcs Type</td>
            <td nowrap="1" width="60px" class="header">Pkgs</td>
            <!--<td nowrap="1" width="100px" class="header">Gr.Wt</td>-->
            <!--<td nowrap="1" width="100px" class="header">NetWt</td>-->
            <!--<td nowrap="1" width="100px" class="header">Volume</td>-->
            <td nowrap="1" width="90px" class="header">Booking On</td>
            <td nowrap="1" width="95px" class="header">DocsRecvdE</td>
            <td nowrap="1" width="95px" class="header">CargoRecvdE</td>           
            <td nowrap="1" width="95px" class="header">ETD</td>
            <td nowrap="1" width="90px" class="header">ETA</td>
            <td nowrap="1" width="90px" class="header">Appr Extd</td>
            <!--<td nowrap="1" width="90px" class="header">Cargo Recvd</td>-->
            <td nowrap="1" width="90px" class="header">App. Dt</td>
            <td nowrap="1" width="90px" class="header">App. By</td>
            <xsl:if test="$GrpId='2'">
              <td nowrap="1" width="90px" class="header">Sup.Cont dt.</td>
              <!--<td nowrap="1" width="100px" class="header">Shipment conf</td>
              <td nowrap="1" width="100px" class="header">New Ship dt</td>-->
            </xsl:if>
			 <xsl:if test="$GrpId='3'">
                  <td nowrap="1" width="90px" class="header">Ref/Assorti</td>
                  <!--<td nowrap="1" width="100px" class="header">Shipment conf</td>
              <td nowrap="1" width="100px" class="header">New Ship dt</td>-->
              </xsl:if>
            <!--<td nowrap="1" width="100px" class="header">Exptno </td>-->
          </tr>
        </xsl:if>
      </xsl:for-each>
      <xsl:for-each select="//NewDataSet/Table1">
        <xsl:variable name="NewGrpId" select="GRPID"></xsl:variable>
        <tr class="summaryDetail">
          <td class="summaryDetail"  align="center">
            <img src="../../INCLUDE/img/edit_item.gif" class="cur"  onclick="parent.fnEdit_Booking_OrderNo_Dtls('{ORDERID}','{ORDERNO}','{STYLENO}','{ITEMDESC}','{PIECES}','{TYPEOFPCS}','{PKGS}','{GRWT}','{NETWT}','{VOLUME}','{BOOKINGDT}','{CARGOEXPECT}','{DOCSEXPECT}','{ETDEXPECT}','{ETAEXPECT}','{CONCODE}','{MODE}','{EXPTNO}','{APPROVALDT}','{CARGORECVDDT}','{EXPCODE}','{EXPORTER}','{ISTRANS}','{ETDTRANS}','{ETATRANS}','{IS_REBOOKING}','{EDITFLAG}','{ACTLAPPROVAL}','{ACTLAPPROVALBY}','{SHIP_CONFIRM}','{NEW_SHIP_DT}','{SUP_CONTACT_DT}','{REF_ASSORTI}')" alt="Edit OrderNo {ORDERNO} and Style No {STYLENO}"/>
            <!--<img src="../../INCLUDE/img/add.jpg" class="cur"  onclick="parent.fn_NewBookingOrd()" alt="Add New Booking"/>-->
          </td>
          <td class="summaryDetail"  align="center" >
            <img src="../../include/img/ARROW_DOWN1.jpg" class="cur"  onclick="parent.fnUpload_Document('{ORDERNO}','{STYLENO}', '{MODE}','{EXPCODE}')" alt="Download documents For Order No. {ORDERNO} and Style No. {STYLENO} Uploaded by Shipper"/>
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
          <!--<td class="summaryDetail" NOWRAP="" align="left">
                        <xsl:value-of select="GRWT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class="summaryDetail" NOWRAP="" align="left">
                        <xsl:value-of select="NETWT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class="summaryDetail" NOWRAP="" align="left">
                        <xsl:value-of select="VOLUME" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
           </td>-->
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="BOOKINGDT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>        
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="DOCSEXPECT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="CARGOEXPECT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
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
          <!--<td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="CARGORECVDDT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>-->
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ACTLAPPROVAL" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="summaryDetail" NOWRAP="" align="left">
            <xsl:value-of select="ACTLAPPROVALBY" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <xsl:if test="$NewGrpId='2'">
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="SUP_CONTACT_DT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
			  
            <!--<td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="SHIP_CONFIRM" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>
            <td class="summaryDetail" NOWRAP="" align="left">
              <xsl:value-of select="NEW_SHIP_DT" />
              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            </td>-->
          </xsl:if>
			 <xsl:if test="$NewGrpId='3'">
                <td class="summaryDetail" NOWRAP="" align="left">
                    <xsl:value-of select="REF_ASSORTI" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
            </xsl:if>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="22" class="foot">
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
