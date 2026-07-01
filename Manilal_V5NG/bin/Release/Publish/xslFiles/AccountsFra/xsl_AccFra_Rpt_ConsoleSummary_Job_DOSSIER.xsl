<?xml version='1.0' ?>
<xsl:stylesheet xmlns:xsl='http://www.w3.org/1999/XSL/Transform' version='1.0'>
  <xsl:template match='/'>
    <xsl:for-each select='//NewDataSet/Table'>
    <table width="100%" border="0" align="center" cellpadding="2" cellspacing="2">
      <tr>
        <td>
          <div align="center">
            <strong>
              <font size="5" face="verdana">
                <u>
                  <xsl:value-of select="CMP_NAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </u>
              </font>
            </strong>
          </div>
        </td>
      </tr>
      <tr>
        <td>
          <div align="center">
            <strong>
              <font size="3" face="vardana">
                <xsl:value-of select="CMP_CITY" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </font>
            </strong>
          </div>
        </td>
      </tr>
    </table>
    <table width="100%" border="1" cellspacing="3" cellpadding="3">
      <tr>
        <td>
          <div align="center">
            <font size="5" face="Arial">
              <strong>
                <xsl:value-of select="HEADER" />
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </strong>
            </font>
          </div>
        </td>
      </tr>
      <tr>
        <td height="93">
          <table width="100%" border="1" cellspacing="1" cellpadding="3">
            <tr>
              <td width="15%">
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">INCOTERM</font>
                </strong>
              </td>
              <td width="39%">
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="INCOTERM" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
              <td width="14%">
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    N DOSSIER
                  </font>
                </strong>
              </td>
              <td width="32%">
                <font size="3" face="Verdana, Arial, Helvetica, sans-serif">
                  <strong>
                    <xsl:value-of select="JOBNO" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </strong>
                </font>
              </td>
            </tr>
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">SHIPPER</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="SHIPPER" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">AGENT</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="SM_AGENT" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CONSIGNEE</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="CONSIGNEE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
              <td height="2" valign="top">
                <b>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    Freight
                  </font>
                </b>
              </td>
              <td height="2">
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="FREIGHT" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td>
          <div align="center">
            <font size="3" face="Arial">
              <strong>ARRIVEE</strong>
            </font>
          </div>
        </td>
      </tr>
      <tr>
        <td>
          <table width="100%" border="1" cellspacing="1" cellpadding="3">
            <tr>
              <td rowspan="9"></td>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    <xsl:value-of select="MAWB_NBL_LABEL" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="MAWB_NBL_VALUE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    <xsl:value-of select="HAWB_NHBL_LABEL" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="HAWB_NHBL_VALUE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">P.O.L.</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <strong>
                    <xsl:value-of select="POL" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </strong>
                </font>
              </td>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    NB COLIS
                  </font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="NB_COLIS" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">E.T.D.</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="ETD" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">POIDS</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="POIDS" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CIE</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="CIE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">VOL</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="VOL" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">E.T.A.</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="ETA" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">NATURE</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="NATURE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">P.O.D.</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <strong>
                    <xsl:value-of select="POD" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </strong>
                </font>
              </td>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">REF</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="REF"  disable-output-escaping="yes" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    <xsl:value-of select="DD_FCL_LABEL" disable-output-escaping="yes" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="DD_FCL_VALUE" disable-output-escaping="yes"/>
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
              <td rowspan="2">
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">AUTRES</font>
                </strong>
              </td>
              <td rowspan="2">
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="AUTRES"  disable-output-escaping="yes" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    <xsl:value-of select="VOL_NAVIRE_LABEL" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="VOL_NAVIRE_VALUE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <!-- IF AIR-->
            <xsl:if test="MODE='A'">
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    <xsl:value-of select="VOL_NAVIRE_LABEL" />
                    <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                  </font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:value-of select="VOL_NAVIRE_VALUE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            </xsl:if>
            <!-- END-->
          </table>
        </td>
      </tr>
      <tr>
        <td>
          <div align="center">
            <font size="3" face="Arial">
              <strong>LIVRAISON</strong>
            </font>
          </div>
        </td>
      </tr>
      <tr>
        <td>
          <table width="66%" border="1" cellspacing="1" cellpadding="3">
            <tr>
              <td width="9%" rowspan="2"></td>
              <td width="17%">
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    L.E
                  </font>
                </strong>
              </td>
              <td width="74%">
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
            <tr>
              <td>
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">CHEZ</font>
                </strong>
              </td>
              <td>
                <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </font>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td>
          <div align="center">
            <font size="3" face="Arial">
              <strong>OBSERVATIONS</strong>
            </font>
          </div>
        </td>
      </tr>
      <tr>
        <td>
          <table width="100%" height="186" border="1" cellpadding="3" cellspacing="1">
            <tr>
              <td width="6%">
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
              <td width="94%">
                <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>