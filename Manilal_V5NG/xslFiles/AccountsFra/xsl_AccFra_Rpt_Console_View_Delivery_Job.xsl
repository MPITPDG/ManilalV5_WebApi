<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <table border='0' cellpadding='0' cellspacing='0' width='660px' class="subTbl">
      <xsl:for-each select="//NewDataSet/Table">
        <tr height="0px">
          <td width="120px">
          </td>
          <td width="200px">
          </td>
          <td width="120px">
          </td>
          <td width="200px">
          </td>
        </tr>
        <tr>
          <td class="tdHeaderLeft">
            CLIENT :
          </td>
          <td colspan="3" class="tdNormalRight">
            <xsl:value-of select="CLIENT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
        <tr>
          <td colspan="4">
            <xsl:if test="count(//NewDataSet/Table1)!=0">
              <div class="divSpace">
                <table border='0' cellpadding='0' cellspacing='0' width='650px'>
                  <tr>
                    <td class='tdHeaderLeft'>CONTAINER NO.</td>
                    <td class='tdHeader'>SIZE</td>
                    <td class='tdHeader'>PKGS</td>
                    <td class='tdHeader'>CBM</td>
                    <td class='tdHeader'>VESSEL</td>
                    <td class='tdHeader'>LINER</td>
                  </tr>
                  <xsl:for-each select="//NewDataSet/Table1">
                    <tr>
                      <td class='tdNormalLeft'>
                        <xsl:value-of select="CONTAINERNO" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="SIZE" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="NOOFPKGS" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="CBM" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="VESSEL" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormalRight'>
                        <xsl:value-of select="LINER" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                    </tr>
                  </xsl:for-each>
                </table>
              </div>
            </xsl:if>
          </td>
        </tr>
        <tr>
          <td colspan="4">
            <xsl:if test="count(//NewDataSet/Table2)!=0">
              <div class="divSpace">
                <table border='0' cellpadding='0' cellspacing='0' width='650px'>
                  <tr>
                    <td class='tdHeaderLeft'>MAWB</td>
                    <td class='tdHeader'>PKGS</td>
                    <td class='tdHeader'>WEIGHT</td>
                    <td class='tdHeader'>HAWB NO.</td>
                    <td class='tdHeader'>ORDER NO.</td>
                    <td class='tdHeader'>MP. REF.</td>
                  </tr>
                  <xsl:for-each select="//NewDataSet/Table2">
                    <tr>
                      <td class='tdNormalLeft'>
                        <xsl:value-of select="MAWB_NO" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="PKGS" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="WEIGHT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="HAWB_NO" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="ORDER_NO" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormalRight'>
                        <xsl:value-of select="MP_REF" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                    </tr>
                  </xsl:for-each>
                </table>
              </div>
            </xsl:if>
          </td>
        </tr>
        <tr>
          <td colspan="4">
            <xsl:if test="count(//NewDataSet/Table3)!=0">
              <div class="divSpace">
                <table border='0' cellpadding='0' cellspacing='0' width='650px'>
                  <tr>
                    <td class='tdHeaderLeft'>JOB NO.</td>
                    <td class='tdHeader'>HBL/HAWB NO.</td>
                    <td class='tdHeader'>DATE</td>
                    <td class='tdHeader'>TOTAL PKGS</td>
                    <td class='tdHeader'>PKGS</td>
                    <td class='tdHeader'>WEIGHT</td>
                    <td class='tdHeader'>VOLUME/CHBL WT.</td>
                    <td class='tdHeader'>FREIGHT</td>
                  </tr>
                  <xsl:for-each select="//NewDataSet/Table3">
                    <tr>
                      <td class='tdNormalLeft'>
                        <xsl:value-of select="JOBNO" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="HAWBNO" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="HAWBDT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="TOTAL_PKGS" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="PKGS" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="WEIGHT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormal'>
                        <xsl:value-of select="VOLUME_CHBL_WT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                      <td class='tdNormalRight'>
                        <xsl:value-of select="FREIGHT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </td>
                    </tr>
                  </xsl:for-each>
                </table>
              </div>
            </xsl:if>
          </td>
        </tr>
        <tr>
          <td colspan="4" height="20px" class="trHeader">
          </td>
        </tr>
        <tr>
          <td colspan="4">
            <table border="0" width="640px">
              <tr>
                <td class="tdHeaderLeft" width="200px">
                  D/O GIVEN TO CONSIGNEE'S AGENT :
                </td>
                <td class="tdNormalRight" width="440px">
                  <xsl:value-of select="AGTNAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td colspan="4" height="20px" class="trHeader">
            <xsl:value-of select="APPT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
        <tr>
          <td class="tdHeaderLeft">
            TRANSPORTER :
          </td>
          <td colspan="3" class="tdNormalRight">
            <xsl:value-of select="AGTNAME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
        <tr>
          <td colspan="4" height="20px" class="trHeader">
            <xsl:value-of select="APPT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
        <tr>
          <td colspan="4" height="20px" class="trHeader">
            <xsl:value-of select="DELIVERYTO_TITLE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
        <tr>
          <td class="tdHeaderLeft">
            TRANSPORTER :
          </td>
          <td colspan="3" class="tdNormalRight">
            <xsl:value-of select="DELIVERYTO_TITLE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
        <tr>
          <td class="tdHeaderLeft">
            Delivery Address :
          </td>
          <td colspan="3" class="tdNormalRight">
            <xsl:value-of select="ADD1" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            <xsl:value-of select="ADD2" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            <xsl:value-of select="ADD3" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            <xsl:value-of select="PINCODE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            <xsl:value-of select="CITY_NAME" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            <xsl:value-of select="CITY_COUNTRY" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
        <tr>
          <td class="tdHeaderLeft">
            Telephone :
          </td>
          <td colspan="3" class="tdNormalRight">
            <xsl:value-of select="TELEPHONE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
        <tr>
          <td class="tdHeaderLeft">
            Fax :
          </td>
          <td colspan="3" class="tdNormalRight">
            <xsl:value-of select="FAX" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
        <tr>
          <td class="tdHeaderLeft">
            Contact Person :
          </td>
          <td colspan="3" class="tdNormalRight">
            <xsl:value-of select="CONTACT1" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            <xsl:value-of select="CONTACT2" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
            <xsl:value-of select="CONTACT3" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
        <xsl:if test="count(//NewDataSet/Table4)!=0">
          <tr height="100%">
            <td colspan="4">
              <table border='0' cellpadding='0' cellspacing='0' width='650px'>
                <tr>
                  <td class='tdHeaderLeft'>
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td class='tdHeader'>DATE</td>
                  <td class='tdHeader'>TIME</td>
                  <td class='tdHeader'>REMARK</td>
                </tr>
                <xsl:for-each select="//NewDataSet/Table4">
                  <tr>
                    <td class='tdNormalLeft'>
                      <xsl:value-of select="APPT" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class='tdNormal'>
                      <xsl:value-of select="APPTDT" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class='tdNormal'>
                      <xsl:value-of select="APPTTIME" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                    <td class='tdNormalRight'>
                      <xsl:value-of select="APPTRMRK" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </td>
                  </tr>
                </xsl:for-each>
              </table>
            </td>
          </tr>
        </xsl:if>
      </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>