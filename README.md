# WebCE
WEB Content Extractor (WEBCE) is an open source project that has two effective algorithms to eliminate uninformative blocks and efficiently extract content blocks from web pages. Moreover WEBCE produce a XML File that contains main, headline, and information about the article for a given web page.

WEBCE is a two-step algorithm. In the first step, we remove noisy blocks and then classify each block according the features given in the previous section. In the second step, a rule based parser uses the output of the first step - a well-formed structure - to extract the main content.

In first step, we use the sub-tree raising method of decision tree learning method for the extraction of the content blocks. We establish our learning method to DIV and TD html tags. Therefore, in second step we effectively parse web pages by using these tags.

<a href="https://www.e-adys.com/webce/" target="_blank">Click for images...</a>

# Publications
<b>A hybrid approach for extracting informative content from web pages.</b> Uzun, E.; Agun, H., V.; and Yerlikaya, T. Information Processing and Management, 49(4): 928-944. 2013. 

<a href="https://www.e-adys.com/yayinlar/" target="_blank">Click for bibtex, downloads, all publications...</a>
