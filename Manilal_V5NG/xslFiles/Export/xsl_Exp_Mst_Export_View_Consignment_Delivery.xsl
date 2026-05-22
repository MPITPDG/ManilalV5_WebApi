<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <table width="100%" border="1" cellspacing="3" cellpadding="3">
      <xsl:for-each select="//NewDataSet/Table">
        <tr bgcolor="#99CCFF">
          <td colspan="8" height="2">
            <div align="left">
              <table width="100%">
                <tr>
                  <td width="15%" valign="top">
                    <b>
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        Client
                      </font>
                    </b>
                  </td>
                  <td width="2%" valign="top">
                    <b>
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">:</font>
                    </b>
                  </td>
                  <td width="83%">
                    <b>
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        <xsl:value-of select="CLIENT" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        <br/>
                      </font>
                    </b>
                  </td>
                </tr>
              </table>
            </div>
          </td>
        </tr>
        <!-- CONTAINER DETAILS-->
        <xsl:if test="count(//NewDataSet/Table1)!=0">
          <tr bgcolor="#99CCFF">
            <td colspan="8" align="center">
              <table width="100%" border="1" cellspacing="1" cellpadding="3">
                <tr bgcolor="#99CCFF">
                  <td width="17%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          CONTAINER NO
                        </font>
                      </b>
                    </div>
                  </td>
                  <td width="6%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">SIZE</font>
                      </b>
                    </div>
                  </td>
                  <td width="7%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">PKGS</font>
                      </b>
                    </div>
                  </td>
                  <td width="12%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CBM</font>
                      </b>
                    </div>
                  </td>
                  <td width="19%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">VESSEL</font>
                      </b>
                    </div>
                  </td>
                  <td width="19%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">AGENT</font>
                      </b>
                    </div>
                  </td>
                  <td width="15%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">LINER</font>
                      </b>
                    </div>
                  </td>
                </tr>
                <xsl:for-each select="//NewDataSet/Table1">
                  <tr bgcolor="#00FFFF">
                    <td width="17%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="CONTAINERNO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="6%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="SIZE" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="7%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="PKGS" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="12%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="CBM" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="19%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="VESSEL" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="19%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="AGENT_NAME" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="15%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="LINER_NAME" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                  </tr>
                </xsl:for-each>
              </table>
            </td>
          </tr>
        </xsl:if>
        <!-- END CONTAINER DETAILS-->
        <!-- MAWB DETAILS-->
        <xsl:if test="count(//NewDataSet/Table2)!=0">
          <tr bgcolor="#99CCFF">
            <td colspan="8" align="center">
              <table width="100%" border="1" cellspacing="1" cellpadding="3">
                <tr bgcolor="#99CCFF">
                  <td width="17%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          MAWB
                        </font>
                      </b>
                    </div>
                  </td>
                  <td width="6%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">PKGS</font>
                      </b>
                    </div>
                  </td>
                  <td width="7%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">WEIGHT</font>
                      </b>
                    </div>
                  </td>
                  <td width="12%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">HAWB NO.</font>
                      </b>
                    </div>
                  </td>
                  <td width="19%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">ORDER NO.</font>
                      </b>
                    </div>
                  </td>
                  <td width="15%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">MP. REF.</font>
                      </b>
                    </div>
                  </td>
                </tr>
                <xsl:for-each select="//NewDataSet/Table2">
                  <tr bgcolor="#00FFFF">
                    <td width="17%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="MAWB_NO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="6%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="PKGS" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="7%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="WEIGHT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="12%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="HAWB_NO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="19%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="ORDER_NO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>

                    <td width="15%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="MP_REF" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                  </tr>
                </xsl:for-each>
              </table>
            </td>
          </tr>
        </xsl:if>
        <!-- END MAWB DETAILS-->
        <!-- JOB DETAILS-->
        <xsl:if test="count(//NewDataSet/Table3)!=0">
          <tr bgcolor="#99CCFF">
            <td colspan="8" align="center">
              <table width="100%" border="1" cellspacing="1" cellpadding="3">
                <tr>
                  <td width="20%" height="2">
                    <div align="center">
                      <b>
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                          JOB NO.
                        </font>
                      </b>
                    </div>
                  </td>
                  <td width="15%" height="2">
                    <div align="center">
                      <b>
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                          HBL/ HAWB NO.
                        </font>
                      </b>
                    </div>
                  </td>
                  <td width="10%" height="2">
                    <div align="center">
                      <b>
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">DATE</font>
                      </b>
                    </div>
                  </td>
                  <td width="10%" height="2">
                    <div align="center">
                      <b>
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                          TOTAL PKGS
                        </font>
                      </b>
                    </div>
                  </td>
                  <td width="10%" height="2">
                    <div align="center">
                      <b>
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                          PKGS
                        </font>
                      </b>
                    </div>
                  </td>
                  <td width="10%" height="2">
                    <div align="center">
                      <b>
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">WEIGHT</font>
                      </b>
                    </div>
                  </td>
                  <td width="15%" height="2">
                    <div align="center">
                      <b>
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
                          VOLUME/ CHBL WT.
                        </font>
                      </b>
                    </div>
                  </td>
                  <td width="10%" height="2">
                    <div align="center">
                      <b>
                        <font face="Verdana, Arial, Helvetica, sans-serif" size="2">FREIGHT</font>
                      </b>
                    </div>
                  </td>
                </tr>
                <xsl:for-each select="//NewDataSet/Table3">
                  <tr bgcolor="#00FFFF">
                    <td width="20%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="JOBNO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="15%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="HBL_HAWBNO" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="10%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="JOB_DATE" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="10%" bgcolor="#00FFFF">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="TOTAL_PKGS" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="10%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="PKGS" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="10%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="WEIGHT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="15%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="VOLUME_CHBL" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="10%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="FREIGHT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                  </tr>
                </xsl:for-each>
              </table>
            </td>
          </tr>
        </xsl:if>
        <!-- END JOB DETAILS-->
        <tr bgcolor="#99CCFF">
          <td colspan="8">
            <table width="100%" border="1" cellspacing="2" cellpadding="2">
              <tr>
                <td bgcolor="#99CCFF">
                  <b>
                    <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                      <xsl:value-of select="DELIVERYTO_TITLE" />
                      <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                    </font>
                  </b>
                </td>
              </tr>
              <xsl:choose>
                <xsl:when test="DORDER='AGT'">
                  <tr>
                    <td bgcolor="#99CCFF" align="center">
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        <xsl:value-of select="AGTNAME" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </font>
                    </td>
                  </tr>
                </xsl:when>
                <xsl:when test="DORDER='CONSG'">
                  <tr>
                    <td bgcolor="#99CCFF" align="center">
                      <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                        <xsl:value-of select="CONSGPLACE" />
                        <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                      </font>
                    </td>
                  </tr>
                </xsl:when>
                <xsl:otherwise>
                  <tr>
                    <td bgcolor="#99CCFF">
                      <table width="100%" border="1" cellspacing="2" cellpadding="2">
                        <tr bgcolor="#99CCFF">
                          <td width="34%" valign="top">
                            <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                              <b>
                                Delivery
                                Address
                              </b>
                            </font>
                          </td>
                          <td width="57%">
                            <font face="Verdana, Arial, Helvetica, sans-serif" size="2">
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
                              <br/>
                              Telephone : <xsl:value-of select="TELEPHONE" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text><br/>
                              Fax :  <xsl:value-of select="FAX" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text><br/>
                              Contact Person : <xsl:value-of select="CONTACT_PERSON" />
                              <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                            </font>
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                </xsl:otherwise>
              </xsl:choose>
            </table>
          </td>
        </tr>
        <xsl:if test="count(//NewDataSet/Table4)!=0">
          <tr bgcolor="#99CCFF">
            <td colspan="8" height="2">
              <table width="100%" border="1" cellspacing="2" cellpadding="2">
                <tr bgcolor="#99CCFF">
                  <td width="28%">
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </td>
                  <td width="13%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">DATE</font>
                      </b>
                    </div>
                  </td>
                  <td width="12%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          TIME
                        </font>
                      </b>
                    </div>
                  </td>
                  <td width="47%">
                    <div align="center">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">REMARK</font>
                      </b>
                    </div>
                  </td>
                </tr>
                <xsl:for-each select="//NewDataSet/Table4">
                  <tr bgcolor="#99CCFF">
                    <td width="28%">
                      <b>
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="APPT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </b>
                    </td>
                    <td width="13%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="APPTDT" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="12%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="APPTTIME" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
                    </td>
                    <td width="47%">
                      <div align="center">
                        <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                          <xsl:value-of select="APPTRMRK" />
                          <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                        </font>
                      </div>
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