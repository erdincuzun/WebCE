using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

using mshtml;
using System.Text.RegularExpressions;
using System.IO;

namespace HTMLMarkerClass
{
    public class element
    {
        public int id;
        public int elementlinked_id;

        public string elementName;
        public string tagName;
        public string className;
        public string predicted_className;
        public int tag_id;
        public int tag_class;
        public int tag_idORclass;
        public int dot_endofstence;

        public string outerHTML;
        public string innerHTML;

        public string BagofWords;
        public int wordCount;
        public double DensityinHTML;
        public int LinkCount;
        public int wordCountinLink;
        public double meanofWordinLinks;
        public double meanofWordinLinksAllWords;
        //wordCountinLink/LinkCount

        public string outerHTML_AE;//After Extraction(AE) nested tags
        public string innerHTML_AE;
        public string BagofWords_AE;

        public int wordCount_AE;
        public double DensityinHTML_AE;
        public int LinkCount_AE;
        public int wordCountinLink_AE;
        public double meanofWordinLinks_AE;
        public double meanofWordinLinksAllWords_AE;

        public double similarity_with_other_web_page;

        public double distanceBetweenMainLayout;
        public bool relevant;
        public string parent_elementName;
    }

    public class xml_elemet
    {
        public string elementName;
        public string parent_elementName;
        public string predicted_className;
        public string content;
    }

    public class DOM
    {       
        public string savehtmlContent;
        public string resulthmtlContent;
        public Hashtable _ht;
        public ArrayList _list;
        public ArrayList _xmllist;

        public ArrayList prepareDOM(string htmlContent)
        {
            htmlContent = HTML.trimOptions(htmlContent);
            htmlContent = HTML.trimScript(htmlContent);

            IHTMLDocument2 htmlDocument = new mshtml.HTMLDocumentClass();            
            htmlDocument.write(htmlContent);

            IHTMLElementCollection allElements = htmlDocument.all;
            _ht = new Hashtable();
            _list = new ArrayList();
            _xmllist = new ArrayList();

            string _tempinner_text = "";
            if (htmlDocument.body != null)
            if (htmlDocument.body.innerText != null)
                _tempinner_text = htmlDocument.body.innerText.Replace("\r\n", "");

            element _firstelement = AnalyzeGivenHTML(htmlContent, _tempinner_text);
            int i = 0;
            foreach (IHTMLElement htmlelement in allElements)
            {
               
                if (htmlelement.outerHTML != null)
                {
                    element _element = new element();
                    _element.id = i;
                    _element.outerHTML = htmlelement.outerHTML;     
                    _element.outerHTML = _element.outerHTML.Replace("\r\n", "");
                    if (htmlelement.innerHTML != null)
                    {
                        _element.innerHTML = htmlelement.innerHTML;
                        _element.innerHTML = _element.innerHTML.Replace("\r\n", "");
                    }
                    else
                        _element.innerHTML = "";                    

                    if (_element.id == 0)
                    {
                        _element.elementlinked_id = -1;//root
                        savehtmlContent = _element.outerHTML;
                        resulthmtlContent = _element.outerHTML;
                    }
                    else
                        _element.elementlinked_id = 0;

                    if (htmlelement.tagName == "HTML")
                    {//html bazen geç geliyor...
                        savehtmlContent = _element.outerHTML;
                        resulthmtlContent = _element.outerHTML;
                    }

                    string _str = _element.outerHTML;
                    int _start = _str.IndexOf('<');
                    int _end = _str.IndexOf('>');
                    _element.elementName = _str.Substring(_start, _end - _start + 1);

                    //<!--className::(.*?)--> ???garanti başlangıçtaki olmalı diğerlerine kaymamalı????
                    _start = _str.IndexOf("<!--className::");
                    _end = _str.IndexOf("-->");
                    if (_start >= 0)
                    {
                        if (_start == _element.elementName.Length)
                        {
                            _start = 15 + _element.elementName.Length;
                            if (_end - _start > 0)
                                _element.className = _str.Substring(_start, _end - _start);
                        }
                    }

                    _element.tagName = htmlelement.tagName;
                    if(htmlelement.id != null)
                        _element.tag_id = 1;
                    if (htmlelement.className != null)
                        _element.tag_class = 1;

                    _element.tag_idORclass = _element.tag_id + _element.tag_idORclass;
                    if (_element.tag_idORclass == 2)
                        _element.tag_idORclass = 1;

                    string tempinner_text = htmlelement.innerText;
                    if (tempinner_text != null)
                    {
                        tempinner_text = tempinner_text.Replace("\r\n", " ");
                        tempinner_text = tempinner_text.Trim();
                    }
                    else
                        tempinner_text = "";

                    element _tempelement = AnalyzeGivenHTML(htmlelement.outerHTML, tempinner_text);
                    _element.BagofWords = _tempelement.BagofWords;
                    _element.wordCount = _tempelement.wordCount;
                    _element.DensityinHTML = (double)_element.wordCount / _firstelement.wordCount;
                    _element.LinkCount = _tempelement.LinkCount;
                    _element.wordCountinLink = _tempelement.wordCountinLink;
                    _element.meanofWordinLinks = _tempelement.meanofWordinLinks;
                    _element.meanofWordinLinksAllWords = _tempelement.meanofWordinLinksAllWords;

                    _element.similarity_with_other_web_page = 1;

                    _element.relevant = false;
                    _element.parent_elementName = "";
                    
                    _list.Add(_element);

                    int key = (int)htmlelement.sourceIndex;//for fast searching
                    _ht.Add(key, i);
                    i++;
                }
            }

            foreach (IHTMLElement htmlelement in allElements)
            {
                if (htmlelement.outerHTML != null)
                {
                    string[] _sonuclar = ExtractionofSubLayouts(htmlelement);
                    string tempinner_text = _sonuclar[1];
                    string tempOuterHTML = _sonuclar[2];
                    string tempinnerHTML = _sonuclar[3];
                    string str_i = _sonuclar[0];

                    i = Convert.ToInt32(str_i);

                    //After Extraction
                    element _element = (element)_list[i];                    
                    element _tempelement = AnalyzeGivenHTML_AE(tempOuterHTML, tempinner_text);

                    _element.outerHTML_AE = tempOuterHTML;
                    _element.innerHTML_AE = tempinnerHTML;
                    _element.BagofWords_AE = _tempelement.BagofWords_AE;                    
                    _element.wordCount_AE = _tempelement.wordCount_AE;
                    _element.DensityinHTML_AE = (double)_element.wordCount_AE / _firstelement.wordCount;
                    _element.LinkCount_AE = _tempelement.LinkCount_AE;
                    _element.wordCountinLink_AE = _tempelement.wordCountinLink_AE;
                    _element.meanofWordinLinks_AE = _tempelement.meanofWordinLinks_AE;
                    _element.meanofWordinLinksAllWords_AE = _tempelement.meanofWordinLinksAllWords_AE;

                    //dot endofcontent
                    if (htmlelement.innerText != null)
                        if (htmlelement.innerText.Trim() != "")
                            if (htmlelement.innerText[htmlelement.innerText.Length - 1] == '.')
                                _element.dot_endofstence = 1;
                            else
                                _element.dot_endofstence = 0;

                    if (_element.wordCount_AE > _element.wordCount)
                        _element.wordCount_AE = _element.wordCount; //istisnayi durum scriptler sorun olduğu için nadir bir durum...
                    _list[i] = _element;

                    if (htmlelement.tagName == "DIV" || htmlelement.tagName == "TD")
                    {
                        element _e = (element)_list[i];
                        if (_e.elementName.Contains("vAlign=bot"))
                            _e.relevant = true;

                        bool _decision = HTMLMarkerClass.desicionClass.determineIrrevelantLayout(_element);

                        if (_decision == false)
                        {                              
                            
                            _e.relevant = true;   
                            _list[i] = _e;

                            //Update child elements                            
                            for (int m = 0; m < _list.Count; m++)
                            {
                                element _et = (element)_list[m];
                                if (_et.elementlinked_id == _e.id)
                                {
                                    if (_et.tagName != "DIV")//div'ler için karar verme
                                        if (_et.tagName != "TD")
                                        {
                                            _et.relevant = true;
                                            _et.parent_elementName = _e.elementName;
                                            _list[m] = _et;
                                        }
                                }                                 
                            }//for m                               
                        }//decision = true
                    }//if div or td 
                }// if not null
            }//for each            

            for (int m = 0; m < _list.Count; m++)
            {
                element _element = (element)_list[m];
                if (_element.relevant == true)
                {
                    if (_element.tagName == "DIV" || _element.tagName == "TD")
                    {
                        bool _mainlayout = HTMLMarkerClass.desicionClass.determineLayout(_element);
                        if (_mainlayout)
                            _element.predicted_className = "MAIN";
                        else
                        {
                            _element.predicted_className = HTMLMarkerClass.desicionClass.determineHEADLINE_INFORMATION(_element);
                        }
                            
                    }
                    else
                    {
                        _element.predicted_className = HTMLMarkerClass.desicionClass.determineHEADLINE_INFORMATION(_element);
                        if(_element.predicted_className == "MAIN")
                            _element.predicted_className = "IRRELEVANT";
                    }

                    /*if (_element.predicted_className == "IRRELEVANT")
                        _element.predicted_className = "INFORMATIONABOUTARTICLE";*/

                    if (clear_illegal_characters_for_XML(_element.BagofWords_AE.Trim()).Trim() != "")
                    {
                        _list[m] = _element;

                        xml_elemet _xml = new xml_elemet();
                        _xml.elementName = _element.elementName;
                        _xml.content = _element.BagofWords_AE;
                        _xml.predicted_className = _element.predicted_className;
                        _xml.parent_elementName = _element.parent_elementName;
                        //equal content in _xml_list
                        bool find = false;
                        for (int v = 0; v < _xmllist.Count; v++)
                        {
                            xml_elemet item = (xml_elemet)_xmllist[v];
                            if (item.content == _xml.content)
                            {
                                item.elementName = item.elementName + ", " + _element.elementName;
                                _xmllist[v] = item;
                                find = true;
                            }                                
                        }

                        if(!find)
                        _xmllist.Add(_xml);
                    }
                }
            }

            return _list;
        }

        public string clear_illegal_characters_for_XML(string strOutput)
        {
            strOutput = strOutput.Replace("<", " ");
            strOutput = strOutput.Replace(">", " ");
            strOutput = strOutput.Replace("\"", " ");
            strOutput = strOutput.Replace("&", " ");
            strOutput = strOutput.Replace("€", " ");
            strOutput = strOutput.Replace("�", " ");
            strOutput = strOutput.Replace("|", " ");

            return strOutput;
        }

        public void ProduceXMLFile(string htmlContent, string save_dir, string filename) 
        {
            if (save_dir != "")
            {
                if (!Directory.Exists(save_dir))
                {
                    Directory.CreateDirectory(save_dir);
                }
            }

            prepareDOM(htmlContent);
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
            xml = xml + "<page>\r\n";
            foreach (xml_elemet _xml in _xmllist)
                if (_xml.predicted_className == "HEADLINE")
                {
                    /*string str_main = "";
                    foreach (xml_elemet _xmlmain in _xmllist)
                        if (_xmlmain.predicted_className == "MAIN")
                            str_main = str_main + " " + _xmlmain.content;
                    if(HTMLMarkerClass.desicionClass.DecisionHeadline(_xml.content, str_main) >= 0.4)*/
                    xml = xml + "<title tag=\"" + @clear_illegal_characters_for_XML(_xml.elementName) + "\" parenttag=\"" + @clear_illegal_characters_for_XML(_xml.parent_elementName) + "\"  >\r\n" + clear_illegal_characters_for_XML(_xml.content) + "</title>\r\n";                                        
                }
            foreach (xml_elemet _xml in _xmllist)
                if (_xml.predicted_className == "INFORMATIONABOUTARTICLE")
                    xml = xml + "<information tag=\"" + @clear_illegal_characters_for_XML(_xml.elementName) + "\" parenttag=\"" + @clear_illegal_characters_for_XML(_xml.parent_elementName) + "\">\r\n" + clear_illegal_characters_for_XML(_xml.content) + "</information>\r\n";

             foreach (xml_elemet _xml in _xmllist)
                if (_xml.predicted_className == "MAIN")
                    xml = xml + "<main tag=\"" + @clear_illegal_characters_for_XML(_xml.elementName) + "\" parenttag=\"" + @clear_illegal_characters_for_XML(_xml.parent_elementName) + "\">\r\n" + clear_illegal_characters_for_XML(_xml.content) + "\r\n</main>\r\n";

            xml = xml + "</page>\r\n";

            System.IO.StreamWriter file = new System.IO.StreamWriter(save_dir + filename);
            file.WriteLine(xml);

            file.Close();
        }

        public string[] ExtractionofSubLayouts(IHTMLElement htmlelement)
        {
            int key = (int)htmlelement.sourceIndex;
            int i = (int)_ht[key];

            string[] _sonuclar = new string[4];

            string tempOuterHTML = htmlelement.outerHTML;
            string tempinner_text = htmlelement.innerText;
            string tempinnerHTML = htmlelement.innerHTML;

            tempOuterHTML = tempOuterHTML.Replace("\r\n", "");

            if (tempinnerHTML != null)
            {
                tempinnerHTML = tempinnerHTML.Replace("\r\n", "");
            }
            else
                tempinnerHTML = "";


            if (tempinner_text != null)
            {
                tempinner_text = tempinner_text.Replace("\r\n", " ");
                tempinner_text = tempinner_text.Trim();
            }
            else
                tempinner_text = "";

            foreach (IHTMLElement htmlchild in (IHTMLElementCollection)htmlelement.children)
            {
                if (htmlchild.outerHTML != null)
                {
                    int keychild = (int)htmlchild.sourceIndex;
                    int ic = (int)_ht[keychild];
                    element _e = (element)_list[ic];
                    _e.elementlinked_id = i;
                    _list[ic] = _e;

                    if (_e.tagName == "DIV"
                        || _e.tagName == "TABLE" || _e.tagName == "TBODY" || _e.tagName == "TR" || _e.tagName == "TD"
                        || _e.tagName == "FORM" || _e.tagName == "CENTER")
                    {
                        if (tempOuterHTML != "")
                        {
                            //Clear child tags from bag of words
                            //Replace function clear all possible words so we write this algorithm
                            tempinner_text = StripOnlyFirstData(tempinner_text, _e.BagofWords);
                            //Clear child tags from outer html
                            //tempOuterHTML = tempOuterHTML.Replace(_e.outerHTML, "");                                    
                            tempOuterHTML = StripOnlyFirstData(tempOuterHTML, _e.outerHTML);
                            tempinnerHTML = StripOnlyFirstData(tempinnerHTML, _e.innerHTML);
                        }//
                    }//IF DIV TABLE ...
                }
            }//childrens

            _sonuclar[0] = i.ToString();
            _sonuclar[1] = tempinner_text;
            _sonuclar[2] = tempOuterHTML;
            _sonuclar[3] = tempinnerHTML;

            return _sonuclar;
        }

        public ArrayList FindChilds(ArrayList _list, int key)
        {
            ArrayList _listchild = new ArrayList();

            foreach (element d in _list)
            {                
                if (d.elementlinked_id == key)
                    if(d.outerHTML != null)
                        _listchild.Add(d);               
            }

            return _listchild;
        }
        
        //prepare information for a given hmtl
        public element AnalyzeGivenHTML(string html_content, string inner_text)
        {
            //html_content = RemoveScripts(html_content);
            element _element = new element();
            _element.BagofWords = inner_text;
            _element.wordCount = HTML.WordsCountGivenText(_element.BagofWords);


            string pattern = "href=.*?>(.*?)</a";
            Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            MatchCollection matchList = exp.Matches(html_content);
            string[] _list = new string[matchList.Count];
            string URL_INNER = "";
            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];
                if (match.Value.Length > 0)
                {                    
                    URL_INNER = URL_INNER + " " + HTML.stripHtml(match.Groups[1].Value);
                }
            }

            _element.LinkCount = matchList.Count;
            _element.wordCountinLink = HTML.WordsCountGivenText(URL_INNER);
            if (_element.LinkCount != 0)
                _element.meanofWordinLinks = (double)_element.wordCountinLink / _element.LinkCount;
            else
                _element.meanofWordinLinks = 0;

            if (_element.wordCount != 0)
                _element.meanofWordinLinksAllWords = (double)_element.wordCountinLink / _element.wordCount;
            else
                _element.meanofWordinLinksAllWords = 0;

            return _element;
        }

        //prepare information for a given hmtl
        public element AnalyzeGivenHTML_AE(string html_content, string inner_text)
        {
            //html_content = RemoveScripts(html_content);
            element _element = new element();
            _element.BagofWords_AE = inner_text;
            _element.wordCount_AE = HTML.WordsCountGivenText(_element.BagofWords_AE);

            string pattern = "href=.*?>(.*?)</a";
            Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            MatchCollection matchList = exp.Matches(html_content);
            string[] _list = new string[matchList.Count];
            string URL_INNER = "";
            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];
                if (match.Value.Length > 0)
                {
                    URL_INNER = URL_INNER + " " + HTML.stripHtml(match.Groups[1].Value);
                }
            }

            _element.LinkCount_AE = matchList.Count;
            _element.wordCountinLink_AE = HTML.WordsCountGivenText(URL_INNER);
            if (_element.LinkCount_AE != 0)
                _element.meanofWordinLinks_AE = (double)_element.wordCountinLink_AE / _element.LinkCount_AE;
            else
                _element.meanofWordinLinks_AE = 0;

            if (_element.wordCount_AE != 0)
                _element.meanofWordinLinksAllWords_AE = (double)_element.wordCountinLink_AE / _element.wordCount_AE;
            else
                _element.meanofWordinLinksAllWords = 0;

            return _element;
        }

        private string StripOnlyFirstData(string _htmlcontent, string extracted_data) 
        {
            int pos = _htmlcontent.IndexOf(extracted_data);
            if (pos >= 0)
            {
                string baslangic = "";
                string son = "";
                if (pos != 0)
                {
                    baslangic = _htmlcontent.Substring(0, pos);
                }

                if (extracted_data.Length + pos <= _htmlcontent.Length)
                    son = _htmlcontent.Substring(extracted_data.Length + pos, _htmlcontent.Length - extracted_data.Length - pos);

              _htmlcontent = baslangic + " " + son;
            }

            return _htmlcontent;
        }


        public ArrayList fingTAGibHTML(String htmlContent, String tagName, string filename)
        {
            DateTime _now = DateTime.Now;

            string id_name = "";
            if (tagName.Contains("id="))
                id_name = findElementName(tagName, "id=\"(.*?)\"");
            string class_name = "";
            if (tagName.Contains("class="))
                class_name = findElementName(tagName, "class=\"(.*?)\"");

            // Obtain the document interface
            //IHTMLDocument2 htmlDocument = (IHTMLDocument2)new mshtml.HTMLDocument();
            IHTMLDocument2 htmlDocument = new mshtml.HTMLDocumentClass();
            // Construct the document
            htmlDocument.write(htmlContent);
            // Extract all image elements
            // IHTMLElementCollection imgElements = htmlDocument.images;
            IHTMLElementCollection allElements = htmlDocument.all;
            ArrayList sonuc = new ArrayList();
            // Iterate all the elements and display tag names

            int elementsize = 0;
            int elementcnt = 0;
            foreach (IHTMLElement element in allElements)
            {
                string cn = "";
                if (element.className != null)
                    cn = element.className;
                string id = "";
                if (element.id != null)
                    id = element.id;

                if (element.tagName == "DIV" && cn == class_name && id == id_name)
                    sonuc.Add(element.innerText);

                if (element.innerHTML != null)
                    elementsize += element.innerHTML.Length;


                elementcnt++;
            }

            return sonuc;
        }

        //find patterns in html
        private string findElementName(string tagname, string pattern)
        {
            Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            MatchCollection matchList = exp.Matches(tagname);

            Match match = matchList[0];
            string _str = match.Groups[1].Value;

            return _str;
        }
        
    }//class DOM

    public class HTML
    {

        public static int WordsCountGivenText(string words)
        {
            // COMPRESS ALL WHITESPACE into a single space, seperating words
            if (words != null)
            {
                if (words.Length > 0)
                {
                    Regex r = new Regex(@"\s+");            //remove all whitespace
                    string compressed = r.Replace(words, " ");
                    return compressed.Split(' ').Length;
                }
                else
                {
                    return 0;
                }
            }
            else
                return 0;
        }

        //trim javascript
        public static string trimScript(string htmlDocText)
        {
            string bodyText = "";
            string trimJavascript = "<SCRIPT.*?>.*?</SCRIPT.*?>";
            Regex regexTrimJs = new Regex(trimJavascript, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            bodyText = regexTrimJs.Replace(htmlDocText, "");

            trimJavascript = "<script(?:\\s+[^>]*)?>.*?</script\\s*>";
            regexTrimJs = new Regex(trimJavascript, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            bodyText = regexTrimJs.Replace(bodyText, "");

            return bodyText;
        }

        //trim javascript
        public static string trimDIV(string htmlDocText)
        {
            string bodyText = "";
            string trimJavascript = "<DIV.*?</DIV.*?>";
            Regex regexTrimJs = new Regex(trimJavascript, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            bodyText = regexTrimJs.Replace(htmlDocText, "");

            trimJavascript = "<div.*?</div.*?>";
            regexTrimJs = new Regex(trimJavascript, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            bodyText = regexTrimJs.Replace(bodyText, "");

            return bodyText;
        }

        //trim javascript
        public static string trimTD(string htmlDocText)
        {
            string bodyText = "";
            string trimJavascript = "<TD.*?</TD.*?>";
            Regex regexTrimJs = new Regex(trimJavascript, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            bodyText = regexTrimJs.Replace(htmlDocText, "");

            trimJavascript = "<td.*?</td.*?>";
            regexTrimJs = new Regex(trimJavascript, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            bodyText = regexTrimJs.Replace(bodyText, "");

            return bodyText;
        }

        //trim options because it is negative effects on calculation of count
        public static string trimOptions(string words)
        {
            // COMPRESS ALL WHITESPACE into a single space, seperating words
            if (words != null)
            {
                if (words.Length > 0)
                {
                    Regex r = new Regex(@"<STYLE(?:\s+[^>]*)?>.*?</STYLE\s*>", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);                 //style
                    string compressed = r.Replace(words, " ");
                    r = new Regex(@"<select(?:\s+[^>]*)?>.*?</select\s*>", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);                 //select
                    compressed = r.Replace(compressed, " ");
                    return compressed;
                }
                else
                {
                    return "";
                }
            }
            else
                return "";
        }

        public static string stripHtml(string strOutput)
        {
            //Strips the HTML tags from strHTML
            if (strOutput != null)
            {
                /*if (strOutput.Contains("<script") || strOutput.Contains("<SCRIPT") || strOutput.Contains("<Script"))
                    strOutput = "xxx";*/
                strOutput = trimScript(strOutput);
                strOutput = trimDIV(strOutput);
                strOutput = trimTD(strOutput);

                System.Text.RegularExpressions.Regex _regex = new System.Text.RegularExpressions.Regex("<(.|\n)+?>");
                strOutput = _regex.Replace(strOutput, " ");
                strOutput = clear_illegal_characters_for_HTML(strOutput);
            }
            return strOutput;
        }

        public static string clear_illegal_characters_for_HTML(string strOutput)
        {
            strOutput = strOutput.Replace("&quot;", " ");
            strOutput = strOutput.Replace("&#39;", " ");
            strOutput = strOutput.Replace("\n", " ");
            strOutput = strOutput.Replace("\r", " ");
            strOutput = strOutput.Replace("\t", " ");
            strOutput = strOutput.Replace("&nbsp;", " ");
            strOutput = strOutput.Replace("\"", " ");
            strOutput = strOutput.Replace("\\", " ");
            strOutput = strOutput.Replace("`", "");
            strOutput = strOutput.Replace("’", "");
            strOutput = strOutput.Replace("<", " ");
            strOutput = strOutput.Replace(">", " ");
            strOutput = strOutput.Replace("|", " ");
            strOutput = strOutput.Replace("'", "");
            strOutput = strOutput.Replace(",", " ");
            strOutput = strOutput.Replace("?", " ");
            strOutput = strOutput.Replace("!", " ");
            strOutput = strOutput.Replace(".", " ");
            strOutput = strOutput.Replace("*", " ");
            strOutput = strOutput.Replace("-", " ");
            strOutput = strOutput.Replace("•", " ");
            strOutput = strOutput.Replace(":", " ");
            strOutput = strOutput.Replace("/", " ");
            strOutput = strOutput.Replace(";", " ");
            strOutput = strOutput.Replace("#", " ");
            strOutput = strOutput.Replace("(", " ");
            strOutput = strOutput.Replace(")", " ");
            strOutput = strOutput.Replace("$", " ");
            strOutput = strOutput.Replace("%", " ");
            strOutput = strOutput.Replace("&", " ");
            strOutput = strOutput.Replace("{", " ");
            strOutput = strOutput.Replace("}", " ");
            strOutput = strOutput.Replace("=", " ");
            strOutput = strOutput.Replace("]", " ");
            strOutput = strOutput.Replace("[", " ");
            strOutput = strOutput.Replace("*", " ");
            strOutput = strOutput.Replace("_", " ");
            strOutput = strOutput.Replace("-", " ");
            strOutput = strOutput.Replace("£", " ");
            strOutput = strOutput.Replace("é", " ");
            strOutput = strOutput.Replace("½", " ");
            strOutput = strOutput.Replace("~", " ");
            strOutput = strOutput.Replace("“", " ");
            strOutput = strOutput.Replace("»", " ");
            strOutput = strOutput.Replace("+", " ");
            strOutput = strOutput.Replace("‘", " ");
            strOutput = strOutput.Replace("@", " ");

            Regex _regex = new Regex(@"\s+", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            strOutput = _regex.Replace(strOutput, " ");

            return strOutput;
        }
    }//html class

    //alternative dom
    public class webfilter
    {
        //word count for a given word in a given text
        private static int CountofStartingTag(string Text, string tag)
        {
            int words;
            Regex reg = new Regex(@tag);
            MatchCollection mc = reg.Matches(Text);
            if (mc.Count > 0)
                words = mc.Count;
            else
                words = 0;

            return words;
        }

        //end tag for a given tag
        private static string find_EndTag(string _tag)
        {
            int end = _tag.IndexOf(" ");
            if(end==-1)
                end = _tag.IndexOf(">");

            string _result = _tag;
            if (end != -1)
            {
                _result = _tag.Substring(0, end) + ">";
                _result = _result.Replace("<", "</");
            }

            return _result;
        }

        //end tag for a given tag
        private static string find_StartTag(string _tag)
        {
            int end = _tag.IndexOf(" ");
            string _result = _tag;
            if (end != -1)
            {
                _result = _tag.Substring(0, end);
            }

            return _result;
        }

        //Tag'a ait bilgileri getiren fonksiyon
        //birden fazla sonuç varsa gösterebiliyor
        //nested özelliği regular expression sağlanamıyor. Bu fonksiyon sayesinde nested tapıda çözümleniyor.
        private static string[] GrabbingofHTMLTags(string _text, string _tag, int countofTag)
        {
            //bool var = false;
            //if (_tag.ToString().Contains("<table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" id=\"top_menu3\" align=\"left\">"))
            //{
            //    var = true;
            //}

            string[] _resultArray = new string[countofTag];

            string _endtag = find_EndTag(_tag);
            string _starttag = find_StartTag(_tag);

            int k = 0;
            for (int i = 0; i < countofTag; i++)
            {
                k = _text.IndexOf(_tag, k);
                if (k == -1) break;
                string str1 = "";
                if (k != -1)
                {
                    string str2 = _text.Substring(k);
                    str1 = _text.Substring(k);

                    k = k + _tag.Length;
                    //div içini ararken en son nerede kaldığımızı tutan etiket.
                    int l = str2.IndexOf(_endtag);
                    if (l != -1)
                        str1 = str2.Substring(0, l + _endtag.Length);
                    else
                        str1 = "";

                    int start_position = l + _endtag.Length;
                    while (CountofStartingTag(str1, _starttag) != CountofStartingTag(str1, _endtag))
                    {
                        l = str2.IndexOf(_endtag, start_position);

                        if (l == -1)
                            break;

                        str1 = str2.Substring(0, l + _endtag.Length);

                        start_position = l + _endtag.Length;
                    }
                }//if 1
                else
                    str1 = "";

                //extract only content
                if (str1 != "")
                {
                    if (str1.Length - _tag.Length > 0)
                    {
                        str1 = str1.Substring(_tag.Length, str1.Length - _tag.Length - _endtag.Length);
                        str1 = str1.Trim();
                        _resultArray[i] = str1;
                    }
                }
            }//for

            return _resultArray;
        }//end function

        //find patterns in html
        private static Hashtable filteringHTMLtags(string html_content, string pattern, Hashtable _tags)
        {
            Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            MatchCollection matchList = exp.Matches(html_content);

            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];
                string _str = match.Groups[0].Value;
                if (_str.Length > pattern.Length - 3)
                {
                    if (!_tags.ContainsKey(_str))
                        _tags.Add(_str, 1);
                    else
                        _tags[_str] = (int)_tags[_str] + 1;
                }
            }

            return _tags;
        }

        //find patterns in html
        private static Hashtable filteringHTMLtags_TESTER(string html_content, string pattern, Hashtable _tags)
        {
            Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);

            MatchCollection matchList = exp.Matches(html_content);

            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];

                if (!_tags.ContainsKey(matchList[i].ToString()))
                    _tags.Add(matchList[i].ToString(), 1);
                else
                    _tags[matchList[i].ToString()] = (int)_tags[matchList[i].ToString()] + 1;
            }

            return _tags;
        }

        //for a given tag
        private static Hashtable filtergivenHTMLtag_TESTER(string html_content, string pattern)
        {
            Hashtable _tags = new Hashtable();

            _tags = filteringHTMLtags_TESTER(html_content, pattern, _tags);

            return _tags;
        }

        //for test finding operation
        public static string[] Contents_of_givenLayout_Tags_TESTER(string html_content, string pattern)
        {
            Hashtable _tags_in_HTML = filtergivenHTMLtag_TESTER(html_content, pattern);
            string[] _content = null;

            int elementsize = 0;
            foreach (DictionaryEntry d in _tags_in_HTML)
            {
                string _tag = (string)d.Key;
                int _cnt = (int)d.Value;

                _content = GrabbingofHTMLTags(html_content, _tag, _cnt);
                string temp = "";
                for (int i = 0; i < _content.Length; i++)
                    temp = temp + _content[i];

                elementsize = elementsize + temp.Length;
            }   

            return _content;
        }
    }
}//namespace
