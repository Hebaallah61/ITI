<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="books">


<xsl:text>review of 3.5= </xsl:text> 
<xsl:value-of select="count(/books/book[review=3.5])"/>

<xsl:element name="br"/>
<xsl:element name="br"/>

<xsl:text>review of 4= </xsl:text> 
<xsl:value-of select="count(/books/book[review=4])"/>

</xsl:template>
</xsl:stylesheet>

<!--<xsl:value-of select="count(/books/book[review=4])"/>-->
