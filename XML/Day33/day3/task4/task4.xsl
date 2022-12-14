<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="CATALOG">
<table border="1" >
<tbody>
<tr bgcolor="yellow">
<th>TITLE</th>
<th>ARTIST</th>
</tr>
<xsl:for-each select="CD[PRICE>10]" data-type="number">
<tr>          
<td><xsl:value-of select="TITLE"/></td>
<td><xsl:value-of select="ARTIST"/></td>
</tr>
</xsl:for-each>
</tbody>
</table>
</xsl:template>
</xsl:stylesheet>
