<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="books">
<table border="1" >
<xsl:for-each select="book">
<tr>          
<td><xsl:value-of select="position()"/></td>
<td><xsl:value-of select="author"/></td>
<td><xsl:value-of select="title"/></td>
<td><xsl:value-of select="price"/></td>
</tr>
</xsl:for-each>
</table>
</xsl:template>
</xsl:stylesheet>
