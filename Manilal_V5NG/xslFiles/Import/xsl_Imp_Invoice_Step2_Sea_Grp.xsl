<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="SummaryDetail" WIDTH="100%">
      <tr class="DataGridFixedHeader">
        <th class="locked" nowrap="1"></th>
        <!--TYPE_STATUS -->
        <th class="locked" nowrap="1"></th>
        <!--CONTAINERNO -->
        <th class="locked" nowrap="1"></th>
        <!--CONSOLENO -->
        <th nowrap="1"></th>
        <!--INVOICED -->
        <th nowrap="1"></th>
        <!--ORIGIN -->
        <th nowrap="1"></th>
        <!--DESTINATION_CITY -->
        <th nowrap="1"></th>
        <!--JOBGRP -->
        <th nowrap="1"></th>
        <!--CBM -->
        <th nowrap="1"></th>
        <!--ETA -->
        <th nowrap="1"></th>
        <!--EXCHANGE_RATE -->
        <th nowrap="1" colspan="2" align="center">CONSOLE FEE</th>
        <!--CONSOLE_FEE_USD_AMOUNT -->
        <th nowrap="1">T1</th>
        <!--CONSOLE_EURO_AMOUNT -->
        <th nowrap="1" colspan="2" >DECHARGEMENT</th>
        <!--TYPE_STATUS -->
        <th nowrap="1" colspan="2" align="center">FRET MARITIME</th>
        <!--FREIGHT_EUR_AMOUNT -->
        <th nowrap="1">BAF</th>
        <!--BAF -->
        <th nowrap="1">CAF</th>
        <!--CAF -->
        <th nowrap="1" align="center">THC</th>
        <th nowrap="1" align="center">LS</th>
        <th nowrap="1" align="center">BL</th>
        <th nowrap="1" align="center">ISPS</th>
        <th nowrap="1" align="center">MULTI STOP</th>
        <th nowrap="1" align="center">TRACTION ANV/ZEE/LEH</th>
        <th nowrap="1" colspan="2" align="center">TRUCKING BLR/TUTI</th>
        <th nowrap="1" align="center">TRANSPORT</th>
        <th nowrap="1" colspan="2" align="center">FABRICATION</th>
        <th nowrap="1" align="center">DEMONTAGE</th>
        <th nowrap="1" align="center">PEAGE DOUANE</th>
        <th nowrap="1" align="center">SCAN</th>
        <th nowrap="1" align="center">INSPECTION PHYSIQUE</th>
        <th nowrap="1" align="center">HEURE DATTENTE</th>
        <th nowrap="1" align="center">MESURE GAZ</th>        
        <th nowrap="1"></th>
        <!--PO_COMMANDES -->
      </tr>
      <tr class="DataGridFixedHeader">
        <th class="locked" nowrap="1">TYPE</th>
        <th class="locked" nowrap="1">Container NO</th>
        <th class="locked" nowrap="1">CONSOLE NO.</th>
        <th nowrap="1">INVOICED</th>
        <th nowrap="1">ORIGIN</th>
        <th nowrap="1">DESTINATION</th>
        <th nowrap="1">JOB NO.</th>
        <th nowrap="1">CBM</th>
        <th nowrap="1">ETA DATE</th>
        <th nowrap="1">EXCHANGE RATE</th>
        <th nowrap="1">USD RATE/CTR.</th>
        <!--CONSOLE_FEE_USD_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!--CONSOLE_FEE_USD_AMOUNT -->
        <th nowrap="1">EUR RATE</th>
        <!--T1 -->
        <th nowrap="1">RATE</th>
        <!--DECHARGEMENT_EURO_RATE -->
        <th nowrap="1">EUR AMOUNT</th>
        <!--DECHARGEMENT_EURO_AMOUNT -->
        <th nowrap="1">USD RATE</th>
        <!--FREIGHT_USD_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- FREIGHT_EUR_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- BAF -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- CAF -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- THC_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- LS_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- BL_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- ISPS_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- MULTISTOP_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- TRACTION_EURO_AMOUNT -->
        <th nowrap="1">USD AMOUNT</th>
        <!-- TRUCKING_USD_BANG_TUTI -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- TRUCKING_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- TRANSPORT_EURO_AMOUNT -->
        <th nowrap="1">USD AMOUNT</th>
        <!-- FABRICATION_USD_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- FABRICATION_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- DEMONTAGE_GOH_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- PEAGE_DOUANE_LEH_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- SCAN_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- INSPECTION_PHYSIQUE_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- HEURE_DATTENTE_EURO_AMOUNT -->
        <th nowrap="1">EUR AMOUNT</th>
        <!-- MESURE_GAZ_EURO_AMOUNT -->
        <th nowrap="1">PO NUMBER</th>
      </tr>
      <xsl:for-each select="//NewDataSet/Table">
        <tr class="row">
          <td class="locked" align="left">
            <xsl:value-of select="TYPE_STATUS" disable-output-escaping="yes"/>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="locked" nowrap="1" align="left">
            <xsl:value-of select="CONTAINERNO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td class="locked" nowrap="1" align="left">
            <xsl:value-of select="CONSOLENO" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td  nowrap="1" align="left">
            <xsl:value-of select="INVOICED" disable-output-escaping="yes"/>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="ORIGIN" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="DESTINATION_CITY" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="JOBGRP" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="CBM" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="ETA" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="EXCHANGE_RATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="CONSOLE_FEE_USD_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="CONSOLE_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="T1_EUR_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="DECHARGEMENT_EURO_RATE" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="DECHARGEMENT_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="FREIGHT_USD_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="FREIGHT_EUR_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="BAF_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="CAF_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="THC_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="LS_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="BL_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="ISPS_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="MULTISTOP_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="TRACTION_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="TRUCKING_USD_BANG_TUTI" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="TRUCKING_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="TRANSPORT_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="FABRICATION_USD_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="FABRICATION_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="DEMONTAGE_GOH_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="PEAGE_DOUANE_LEH_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="SCAN_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="INSPECTION_PHYSIQUE_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="HEURE_DATTENTE_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" style="text-align:right;">
            <xsl:value-of select="MESURE_GAZ_EURO_AMOUNT" />
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
          <td nowrap="1" align="left">
            <xsl:value-of select="PO_COMMANDES" disable-output-escaping="yes"/>
            <xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
          </td>
        </tr>
      </xsl:for-each>
      <tr valign="top">
        <td colspan="3" class="locked" style="text-align:left">
          <xsl:if test="count(//NewDataSet/Table)!=1">
            <xsl:value-of select="count(//NewDataSet/Table0)"/> Records
          </xsl:if>
          <xsl:if test="count(//NewDataSet/Table)=1">
            1 Record
          </xsl:if>
        </td>
        <td colspan="40" class="foot">

        </td>
      </tr>
    </table>
    <table cellpadding="2" cellspacing="0" border="1" bordercolor="white" class="infotable">

    </table>

  </xsl:template>
</xsl:stylesheet>
