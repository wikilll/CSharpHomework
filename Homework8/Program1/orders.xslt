<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <head>
        <title>Order System</title>
      </head>
      <body>
        <h2>Order System</h2>
        <ul>
          <xsl:for-each select="ArrayOfOrder/Order">
            <li>
              <xsl:value-of select="CustomerNum"/>
              <br/>
              <xsl:value-of select="CustomerName"/>
            </li>
            <table>
              <tr bgcolor="#ADD8E6">
                <th>Commodity</th>
                <th>Price</th>
                <th>Quantity</th>
              </tr>
              <xsl:for-each select="Orderdetails/Orderdetail">
                <tr>
                  <td>
                    <xsl:value-of select="CommodityName"/>
                  </td>
                  <td>
                    <xsl:value-of select="CommodityPrice"/>
                  </td>
                  <td>
                    <xsl:value-of select="CommodityNum"/>
                  </td>
                </tr>
              </xsl:for-each>
            </table>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
