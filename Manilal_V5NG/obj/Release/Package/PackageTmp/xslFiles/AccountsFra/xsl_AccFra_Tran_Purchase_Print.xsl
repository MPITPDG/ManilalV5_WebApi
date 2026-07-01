<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<table width="100%" border="1" cellspacing="1" cellpadding="5" align="center">

			<tr align="center">
				<td width="35%" height="9">
					<strong>
						<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
							ACCOUNT
						</font>
					</strong>
				</td>
				<td width="16%">
					<strong>
						<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
							MAWB/MBL
						</font>
					</strong>
				</td>
				<td width="20%">
					<strong>
						<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
							CONSOLE / JOB#
						</font>
					</strong>
				</td>

				<td width="15%">
					<strong>
						<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
							PAYMENT EURO
						</font>
					</strong>
				</td>
				<td width="14%">
					<strong>
						<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
							RECEIVABLE EURO
						</font>
					</strong>
				</td>
				<td height="27">
					<strong>
						<font face="Verdana, Arial, Helvetica, sans-serif" size="2">SHORT NARRATION</font>
					</strong>
				</td>
				<!--<xsl:for-each select="//NewDataSet/Table0">
          <xsl:choose>
            <xsl:when test="DISPLAYMODE!='1'">
              <td width="15%">
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    PAYMENT EURO
                  </font>
                </strong>
              </td>
              <td width="14%">
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    RECEIVABLE EURO
                  </font>
                </strong>
              </td>
            </xsl:when>
            <xsl:otherwise>
              <td width="15%">
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    PAYMENT <xsl:value-of select="CUR_SNAME" />
                  </font>
                </strong>
              </td>
              <td width="14%">
                <strong>
                  <font size="2" face="Verdana, Arial, Helvetica, sans-serif">
                    RECEIVABLE <xsl:value-of select="CUR_SNAME" />
                  </font>
                </strong>
              </td>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:for-each>-->
			</tr>

			<xsl:for-each select="//NewDataSet/Table1">
				<tr>
					<!--<xsl:choose>
						<xsl:when test="ACCOUNT!='TOTAL'">-->
							<td height="27">
								<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
									<xsl:value-of select="ACCTNAME" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</font>
							</td>
							<td align="center">
								<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
									<xsl:value-of select="MAWBMBL" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</font>
							</td>
							<td align="center">
								<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
									<xsl:value-of select="JOBNO" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</font>
							</td>
							<td align="center">
								<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
									<xsl:value-of select='format-number(INVOICEEURO, "###,##0.00")' />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</font>
							</td>
							<td align="center">
								<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
									<xsl:value-of select='format-number(DEDUCTIONEURO, "###,##0.00")' />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</font>
							</td>
							<td align="left" colspan="4">
								<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
									<xsl:value-of select="NARRATION" />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</font>
							</td>
						<!--</xsl:when>
						<xsl:otherwise>
							<td height="27" colspan="3">
								<strong>
									<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
										<xsl:value-of select="ACCTNAME" />
										<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
									</font>
								</strong>
							</td>
						</xsl:otherwise>
					</xsl:choose>-->

					<!--<xsl:choose>
						<xsl:when test="DISPLAYMODE='1'">
							<td align="center">
								<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
									<xsl:value-of select='format-number(INVOICE_NONEURO, "###,##0.00")' />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</font>
							</td>
							<td align="center">
								<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
									<xsl:value-of select='format-number(DEDUCTION_NONEURO, "###,##0.00")' />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</font>
							</td>
						</xsl:when>
						<xsl:otherwise>
							<td align="center">
								<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
									<xsl:value-of select='format-number(INVOICEEURO, "###,##0.00")' />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</font>
							</td>
							<td align="center">
								<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
									<xsl:value-of select='format-number(DEDUCTIONEURO, "###,##0.00")' />
									<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
								</font>
							</td>
						</xsl:otherwise>
					</xsl:choose>-->

				</tr>
				<!--<xsl:if test="ACCOUNT!='TOTAL'">
					<tr>
						<td height="27">
							<strong>
								<font face="Verdana, Arial, Helvetica, sans-serif" size="2">SHORT NARRATION</font>
							</strong>
						</td>
						<td align="left" colspan="4">
							<font size="2" face="Verdana, Arial, Helvetica, sans-serif">
								<xsl:value-of select="NARRATION" />
								<xsl:text disable-output-escaping="yes">&amp;nbsp;</xsl:text>
							</font>
						</td>
					</tr>
				</xsl:if>-->
			</xsl:for-each>
		</table>
	</xsl:template>
</xsl:stylesheet>
