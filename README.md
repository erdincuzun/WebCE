# WebCE
WEB Content Extractor (WEBCE) is an open source project that has two effective algorithms to eliminate uninformative blocks and efficiently extract content blocks from web pages. Moreover WEBCE produce a XML File that contains main, headline, and information about the article for a given web page.

WEBCE is a two-step algorithm. In the first step, we remove noisy blocks and then classify each block according the features given in the previous section. In the second step, a rule based parser uses the output of the first step - a well-formed structure - to extract the main content.

In first step, we use the sub-tree raising method of decision tree learning method for the extraction of the content blocks. We establish our learning method to DIV and TD html tags. Therefore, in second step we effectively parse web pages by using these tags.

<a href="https://www.e-adys.com/webce/" target="_blank">Click for images...</a>

# Python_Scikit-Learn
The codes of this directory are written with Python. Scikit-learn library is used for evaluating feature selection tecniques and classifiers. 

# Publications
<b>A hybrid approach for extracting informative content from web pages.</b> Uzun, E.; Agun, H., V.; and Yerlikaya, T. Information Processing and Management, 49(4): 928-944. 2013. 

<b>Web content extraction by using decision tree learning.</b> Uzun, E.; Agun, H., V.; and Yerlikaya, T. In 2012 20th Signal Processing and Communications Applications Conference (SIU), pages 1-4, 2012. 

<b>A lightweight parser for extracting useful contents from web pages.</b> Uzun, E.; Yerlikaya, T.; and Kurt, M. In 2nd International Symposium on Computing in Science & Engineering-ISCSE 2011, Kusadasi, Aydin, Turkey, pages 67-73, 2011. 

<b>Analyzing of the Evolution of Web Pages by Using a Domain Based Web Crawler.</b> Uzun, E.; Yerlikaya, T.; and Kurt, M. In Techsys, 26-28 May, Plovdiv, Bulgaria, pages 151-156, 2011. 

<a href="https://www.e-adys.com/yayinlar/" target="_blank">Click for bibtex, downloads, all publications...</a>
