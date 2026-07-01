<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="SummaryDetail" WIDTH="100%">
      <tr>
        <td>
          <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="SummaryDetail">
            <tr>
              <td class="formheading" colspan="17">Racap General par MAWB</td>
            </tr>
            <tr class="formheading">
              <td nowrap="1" class="header">Origin Code</td>
              <td nowrap="1" class="header" width="100px" >Origin</td>
              <td nowrap="1" class="header">Airline Code</td>
              <td nowrap="1" class="header" width="150px" >Airline</td>
              <td nowrap="1" class="header">MAWB No.</td>
              <td nowrap="1" class="header">MAWB Date.</td>
              <td nowrap="1" class="header">Air Freight Rate</td>
              <td nowrap="1" class="header">All In</td>
              <td nowrap="1" class="header">FSC Rate</td>
              <td nowrap="1" class="header">FSC Payable On</td>
              <td nowrap="1" class="header">IRC Rate</td>
              <td nowrap="1" class="header">IRC Payable On</td>
              <td nowrap="1" class="header">X-Ray Rate</td>
              <td nowrap="1" class="header">X-Ray Payable On</td>
              <td nowrap="1" class="header">Paletisation</td>
              <td nowrap="1" class="header">Livrasison</td>
              <td nowrap="1" class="header">T1</td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table5">
              <tr class="row">
                <td class="content" align="left">
                  <xsl:value-of select="ORIGIN_CODE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="ORIGIN" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="IATA" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="AIRLINE_NAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="MAWBNO" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="MAWBDT" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="AIR_FREIGHT_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="ALL_IN" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="FSC_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="FSC_RATE_PAYABLEON" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="IRC_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="IRC_RATE_PAYABLEON" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="X_RAY_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="X_RAY_RATE_PAYABLEON" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="PALETISATION_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="DELIVERY_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="T1_RATE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </xsl:for-each>
            <tr valign="top">
              <td colspan="17" class="foot">
                <xsl:if test="count(//NewDataSet/Table5)!=1">
                  <xsl:value-of select="count(//NewDataSet/Table5)"/> Records
                </xsl:if>
                <xsl:if test="count(//NewDataSet/Table5)=1">
                  1 Record
                </xsl:if>
              </td>
            </tr>
	    <tr>
              <td class="formheading" colspan="17">
                <input id="CmdExportExcel" onclick="parent.fn_ExportExcel_Racap_General_par_MAWB()" style="cursor: hand" type="button"
                    value="Export to Excel Racap General par MAWB" />
              </td>
            </tr>
          </table>
        </td>
      </tr>

      <tr>
        <td>
          <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="SummaryDetail">
            <tr>
              <td class="formheading" colspan="4">AIRFREIGHT</td>
            </tr>
            <tr class="formheading">
              <td nowrap="1" class="header">CITY NAME</td>
              <td nowrap="1" class="header">AIR ETD</td>
              <td nowrap="1" class="header">RATE/KG</td>
              <td nowrap="1" class="header">VALIDATE</td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table">
              <tr class="row">
                <td class="content" align="left">
                  <xsl:value-of select="CITY_NAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="AIR_ETD" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="AIR_FREIGHT_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="AIR_FREIGHT_VALIDATE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </xsl:for-each>
            <tr valign="top">
              <td colspan="4" class="foot">
                <xsl:if test="count(//NewDataSet/Table)!=1">
                  <xsl:value-of select="count(//NewDataSet/Table)"/> Records
                </xsl:if>
                <xsl:if test="count(//NewDataSet/Table)=1">
                  1 Record
                </xsl:if>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td>
          <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="SummaryDetail" WIDTH="100%">
            <tr>
              <td class="formheading" colspan="13">SURCHARGES</td>
            </tr>
            <tr class="formheading">
              <td class="header"></td>
              <td class="header"></td>
              <td class="header"></td>
              <td class="header"></td>
              <td class="header" colspan="3" align="center">FSC</td>
              <td class="header" colspan="3" align="center">IRC</td>
              <td class="header" colspan="3" align="center">X-RAY</td>
            </tr>
            <tr class="formheading">
              <td nowrap="1" class="header">CITY NAME</td>
              <td nowrap="1" class="header">AIRLINE NAME</td>
              <td nowrap="1" class="header">AIR ETD</td>
              <td nowrap="1" class="header">CUR. CODE</td>
              <td nowrap="1" class="header">RATE/KG</td>
              <td nowrap="1" class="header">PAYABLEON</td>
              <td nowrap="1" class="header">VALIDATE</td>
              <td nowrap="1" class="header">RATE/KG</td>
              <td nowrap="1" class="header">PAYABLEON</td>
              <td nowrap="1" class="header">VALIDATE</td>
              <td nowrap="1" class="header">RATE/KG</td>
              <td nowrap="1" class="header">PAYABLEON</td>
              <td nowrap="1" class="header">VALIDATE</td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table1">
              <tr class="row">
                <td class="content" align="left">
                  <xsl:value-of select="CITY_NAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="content" align="left">
                  <xsl:value-of select="AIRLINE_NAME" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td nowrap="1" class="content" align="left">
                  <xsl:value-of select="AIR_ETD" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="CUR_CODE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="FSC_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="FSC_RATE_PAYABLEON" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="FSC_FREIGHT_VALIDATE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="IRC_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="IRC_RATE_PAYABLEON" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="IRC_FREIGHT_VALIDATE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="X_RAY_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="X_RAY_RATE_PAYABLEON" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="X_RAY_FREIGHT_VALIDATE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </xsl:for-each>
            <tr valign="top">
              <td colspan="13" class="foot">
                <xsl:if test="count(//NewDataSet/Table1)!=1">
                  <xsl:value-of select="count(//NewDataSet/Table1)"/> Records
                </xsl:if>
                <xsl:if test="count(//NewDataSet/Table1)=1">
                  1 Record
                </xsl:if>
              </td>
            </tr>
          </table>
        </td>
      </tr>
      <tr>
        <td>
          <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="SummaryDetail">
            <tr>
              <td class="formheading" colspan="8">OTHER CHARGES</td>
            </tr>
            <tr class="formheading">
              <td class="header"></td>
              <td class="header" colspan="2" align="center">DELIVERY CHARGE</td>
              <td class="header" colspan="2" align="center">PALETISATION</td>
              <td class="header" colspan="2" align="center">T1</td>
            </tr>
            <tr class="formheading">
              <td nowrap="1" class="header">AIR ETD</td>
              <td nowrap="1" class="header">RATE/KG</td>
              <td nowrap="1" class="header">VALIDATE</td>
              <td nowrap="1" class="header">RATE/KG</td>
              <td nowrap="1" class="header">VALIDATE</td>
              <td nowrap="1" class="header">RATE/KG</td>
              <td nowrap="1" class="header">VALIDATE</td>
            </tr>
            <xsl:for-each select="//NewDataSet/Table2">
              <tr class="row">
                <td class="content" align="left">
                  <xsl:value-of select="AIR_ETD" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="DELIVERY_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="DELIVERY_VALIDATE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="PALETISATION_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="PALETISATION_VALIDATE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="T1_RATE_KG" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
                <td class="content" align="left">
                  <xsl:value-of select="T1_RATE_VALIDATE" />
                  <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
                </td>
              </tr>
            </xsl:for-each>
            <tr valign="top">
              <td colspan="8" class="foot">
                <xsl:if test="count(//NewDataSet/Table2)!=1">
                  <xsl:value-of select="count(//NewDataSet/Table2)"/> Records
                </xsl:if>
                <xsl:if test="count(//NewDataSet/Table2)=1">
                  1 Record
                </xsl:if>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">
    </table>
  </xsl:template>
</xsl:stylesheet>
