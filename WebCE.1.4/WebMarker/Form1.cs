using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using mshtml;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


namespace WebMarker
{
    public partial class Form1 : Form
    {

        HTMLMarkerClass.DOM _dom;
        //string _dir = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\original\";
        //string _dir = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\test\";
        string _dir = @"annotated2\";
        string _destdir = @"annotated2\";
        /*string _dir = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\Gelenler\grup5\sonuc\";
        string _destdir = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\Gelenler\grup5\sonuc\";*/
        string _xmldir = @"";
        ArrayList files;
        int file_id;
        //string _dir = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\annotated\";
        //private string _dir = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\";
        //string _dir = @"C:\Projeler\WebMarker\L3S-GN1-20100130203947-00001\original\";

        //string _dir = @"Grup1\";
        //string _destdir = @"Grup1\Sonuc\";

        ArrayList _list;
        private TreeNode _treeNode;
        private string _savehtmldoc;
        private string _lastselected_outerHTML;

        Hashtable _ht = new Hashtable();//for ruleset

        private void FillTree(int key, TreeNode _tnchild)
        {
            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();
            ArrayList _htmain = _dom.FindChilds(_list, key);
            HTMLMarkerClass.element _element = (HTMLMarkerClass.element)_list[key];

            foreach (HTMLMarkerClass.element d in _htmain)
            {
                TreeNode _tn = _tnchild.Nodes.Add(d.id.ToString(), d.elementName);
                FillTree(d.id, _tn);
            }

        }

        private void PrepareDOMTreeView(string _htmldoc)
        {
            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();
            _list = _dom.prepareDOM(_htmldoc);

            TreeNode _tn = DOMtreeView.Nodes.Add("0", "<html>");

            ArrayList _listchild0 = _dom.FindChilds(_list, 0);

            foreach (HTMLMarkerClass.element d in _listchild0)
            {               
                _treeNode = _tn.Nodes.Add(d.id.ToString(), d.elementName);

                FillTree(d.id, _treeNode);
            } 
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_Parse_Click(object sender, EventArgs e)
        {            
            DOMtreeView.Nodes.Clear();

            //try
            //{
            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();

                DateTime _start = DateTime.Now;
                string _htmldoc = "";
                if (!TXT_FileName.Text.Contains("http://"))
                {
                    TextReader textReader = new StreamReader(_dir + TXT_FileName.Text);
                    _htmldoc = textReader.ReadToEnd();
                    textReader.Close();
                }
                else
                {
                    _htmldoc = HTMLMarkerClass.downloader.GetHtmlContent(TXT_FileName.Text);
                }
                _htmldoc = _htmldoc.Replace("\r\n", "");

                webBrowser1.ScriptErrorsSuppressed = true;
                //webBrowser1.DocumentText = _htmldoc;   
               
                PrepareDOMTreeView(_htmldoc);
                _savehtmldoc = _dom.savehtmlContent;//for prepearing a new file

            
            TimeSpan _t = DateTime.Now.Subtract(_start);             
            LBL_Time.Text = _t.TotalMilliseconds.ToString() + " ms";

                if (_htmldoc.Contains("className::MAIN"))
                    lbl_dENae.Text = "MAIN OK";
                else
                    lbl_dENae.Text = "----------";
                //contextMenuStrip1.Enabled = true;
            /*}
            catch
            {
                LBL_Time.Text = "Control your file || internet connection || web pages(start with http://)";
                contextMenuStrip1.Enabled = false;
                throw;
            }*/
            
        }

        private void DOMtreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int id = Convert.ToInt32(DOMtreeView.SelectedNode.Name);
            HTMLMarkerClass.element _element = (HTMLMarkerClass.element)_list[id];
            HTMLMarkerClass.element _elementust = new HTMLMarkerClass.element();
            if (_element.elementlinked_id >= 0)
            _elementust = (HTMLMarkerClass.element)_list[_element.elementlinked_id];

            webBrowser1.DocumentText = _element.outerHTML;

            listBox_Information.Items.Clear();
            listBox_Information.Items.Add("id : " + _element.id.ToString() + " : " + _element.elementName);
            listBox_Information.Items.Add("Tag : " + _element.tagName);
            if (_element.elementlinked_id >= 0)
            listBox_Information.Items.Add("linked id : " + _element.elementlinked_id.ToString() + " : " + _elementust.elementName);
            listBox_Information.Items.Add("WordsCount : " + _element.wordCount.ToString());
            listBox_Information.Items.Add("DensityInHTML : " + _element.DensityinHTML.ToString());
            listBox_Information.Items.Add("LinkCount : " + _element.LinkCount);
            listBox_Information.Items.Add("wordCountinLink : " + _element.wordCountinLink);
            listBox_Information.Items.Add("meanofWordinLinks : " + _element.meanofWordinLinks.ToString());
            listBox_Information.Items.Add("meanofWordinLinksinAllWords : " + _element.meanofWordinLinksAllWords.ToString());
            listBox_Information.Items.Add("WordsCount_AE : " + _element.wordCount_AE.ToString());
            listBox_Information.Items.Add("DensityInHTML_AE : " + _element.DensityinHTML_AE.ToString());
            listBox_Information.Items.Add("LinkCount_AE : " + _element.LinkCount_AE);
            listBox_Information.Items.Add("wordCountinLink_AE : " + _element.wordCountinLink_AE);
            listBox_Information.Items.Add("meanofWordinLinks_AE : " + _element.meanofWordinLinks_AE.ToString());
            listBox_Information.Items.Add("meanofWordinLinksinAllWords_AE : " + _element.meanofWordinLinksAllWords_AE.ToString());
            listBox_Information.Items.Add("ClassName : " + _element.className);
            listBox_Information.Items.Add("PredictedClassName : " + _element.predicted_className);
            listBox_Information.Items.Add("Relevant : " + _element.relevant);

            lbl_dENae.Text = "DensityInHTML_AE : " + _element.DensityinHTML_AE.ToString();

            _lastselected_outerHTML = _element.outerHTML;

            bool sonuc = HTMLMarkerClass.desicionClass.determineIrrevelantLayout(_element);
            listBox_Information.Items.Add("Relevant Prediction : " + (!sonuc).ToString());
        }

        private string[] findTagANDOtherPart(string html)
        {
            string _starttag = html;
            int _start = _starttag.IndexOf('<');
            int _end = _starttag.IndexOf('>');
            _starttag = _starttag.Substring(_start, _end - _start + 1);
            string otherparts = html.Substring(_end - _start + 1, html.Length - (_end - _start + 1));

            string[] _res = new string[2];
            _res[0] = _starttag;
            _res[1] = otherparts;

            return  _res;
        }


        private void linksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::ADVERTISEMENTS-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {  
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::MENU-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
          
        }

        private void linksRelatedWithArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::LINKS-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void headLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::HEADLINE-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void mainofArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::MAIN-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void summaryofArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::SUMMARY-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void commentsofArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::COMMENTS-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void tagsofArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::TAGSOFARTICLE-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void sAVEFILEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter sw = File.CreateText(_destdir + TXT_FileName.Text);
            //StreamWriter sw = new StreamWriter(_destdir+TXT_FileName.Text);
            sw.WriteLine(_savehtmldoc);
            sw.Close();

        }

        private void bannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::BANNER-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            files = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(_dir);
            files.AddRange(di.GetFiles("*.*"));
            file_id = 0;
            TXT_No.Text = (file_id + 1).ToString();
            TXT_FileName.Text = files[file_id].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            file_id--;
            if (file_id < 0)
                file_id = 0;
            TXT_No.Text = (file_id + 1).ToString();
            TXT_FileName.Text = files[file_id].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            file_id++;
            if (file_id > files.Count - 1)
                file_id = files.Count - 1;
            TXT_No.Text = (file_id + 1).ToString();
            TXT_FileName.Text = files[file_id].ToString();
        }

        private void linksRelatedWithArticleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::LINKSRELATEDWITHARTICLE-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void copyrightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::COPYRIGHT-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void TXT_No_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                file_id = Convert.ToInt32(TXT_No.Text);
                file_id--;
            }
            catch
            {
                file_id = 0;              
            }

            TXT_FileName.Text = files[file_id].ToString();
        }

        private void ınformationAboutArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _res = findTagANDOtherPart(_lastselected_outerHTML);
            string resultstr = _res[0] + "<!--className::INFORMATIONABOUTARTICLE-->" + _res[1];
            _savehtmldoc = _savehtmldoc.Replace(_lastselected_outerHTML, resultstr);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*files = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(_dir);
            files.AddRange(di.GetFiles("*.*"));

            ArrayList files2 = new ArrayList();
            DirectoryInfo di2 = new DirectoryInfo(_destdir);
            files2.AddRange(di2.GetFiles("*.*"));

            for (int i = 0; i < files.Count; i++)
            {
                bool bul = false;
                for (int j = 0; j < files2.Count; j++)
                {
                    if (files[i].ToString() == files2[j].ToString())
                    {
                        bul = true;
                        break;
                    }
                }

                if (!bul)
                    File.Copy(_dir + files[i], @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\kalandosyalar\" + files[i]);                    
            }*/
            
            

            /*DOMtreeView.Nodes.Clear();

            //try
            //{
            DateTime _start = DateTime.Now;
            string _htmldoc = "";
            if (!TXT_FileName.Text.Contains("http://"))
            {
                TextReader textReader = new StreamReader(@"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\original\" + TXT_FileName.Text);
                _htmldoc = textReader.ReadToEnd();
                textReader.Close();
            }
            else
            {
                _htmldoc = new WebClient().DownloadString(@TXT_FileName.Text);
            }
            _htmldoc = _htmldoc.Replace("\r\n", "");
            webBrowserMini.DocumentText = _htmldoc;

            PrepareDOMTreeView(_htmldoc);
            _savehtmldoc = HTMLMarkerClass.DOM.savehmtlContent;//for prepearing a new file

            TimeSpan _t = DateTime.Now.Subtract(_start);
            if (_t.Seconds != 0)
                LBL_Time.Text = _t.Seconds.ToString() + "." + _t.Milliseconds.ToString() + " ms";
            else
                LBL_Time.Text = _t.Milliseconds.ToString() + " ms";*/
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();

            string _d = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\annotatedtoo\";

            files = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(_d);
            files.AddRange(di.GetFiles("*.*"));

            TextWriter tw = new StreamWriter("erd_relatedLayouts.arff");

            tw.WriteLine("@relation class_relation");
            tw.WriteLine("@attribute 'tagName' {BODY, TD, DIV}");            
            tw.WriteLine("@attribute 'pos' real");
            tw.WriteLine("@attribute 'has_id' real");
            tw.WriteLine("@attribute 'has_class' real");
            tw.WriteLine("@attribute 'has_idORclass' real");
            tw.WriteLine("@attribute 'wordCount' real");
            tw.WriteLine("@attribute 'densityinHTML' real");
            tw.WriteLine("@attribute 'LinkCount' real");
            tw.WriteLine("@attribute 'wordCountinLink' real");
            tw.WriteLine("@attribute 'meanofWordinLinks' real");
            tw.WriteLine("@attribute 'meanofWordinLinksAllWords' real");            
            tw.WriteLine("@attribute 'wordCount_AE' real");
            tw.WriteLine("@attribute 'densityinHTML_AE' real");
            tw.WriteLine("@attribute 'LinkCount_AE' real");
            tw.WriteLine("@attribute 'wordCountinLink_AE' real");
            tw.WriteLine("@attribute 'meanofWordinLinks_AE' real");
            tw.WriteLine("@attribute 'meanofWordinLinksAllWords_AE' real");
            tw.WriteLine("@attribute 'class' {relevantLayout, irrelevantLayout}");
            tw.WriteLine("@data");

            //files.Count
            for (int i = 0; i < files.Count; i++)
            {
                try
                {
                    TextReader textReader = new StreamReader(_d + files[i].ToString());
                    string _htmldoc = textReader.ReadToEnd();
                    textReader.Close();
                    ArrayList _mylist = _dom.prepareDOM(_htmldoc);

                    foreach (HTMLMarkerClass.element d in _mylist)
                    {
                        //if (d.tagName == "DIV" || d.tagName == "TD"|| d.tagName == "UL")
                        //if(d.className != null)
                        if (d.tagName == "DIV" || d.tagName == "TD" || d.tagName == "BODY")
                        {
                            string _cn = "irrelevantLayout";
                            if (d.className != null)
                            {
                                _cn = d.className;
                                if (d.className == "MAIN")
                                    _cn = "relevantLayout";
                                else
                                    _cn = "irrelevantLayout";
                            }

                            tw.WriteLine(d.tagName + "," + d.id + "," + d.tag_id + "," + d.tag_class + "," + d.tag_idORclass + "," + d.wordCount + "," + d.DensityinHTML + "," + d.LinkCount + "," + d.wordCountinLink + "," + d.meanofWordinLinks + "," + d.meanofWordinLinksAllWords +
                                        "," + d.wordCount_AE + "," + d.DensityinHTML_AE + "," + d.LinkCount_AE + "," + d.wordCountinLink_AE + "," + d.meanofWordinLinks_AE + "," + d.meanofWordinLinksAllWords_AE +
                                        "," + _cn);
                        }
                    }                    
                }
                catch
                {

                }
            }

            // close the stream
            tw.Close();                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();

            string _htmldoc = "";
            if (!TXT_FileName.Text.Contains("http://"))
            {
                TextReader textReader = new StreamReader(_dir + TXT_FileName.Text);
                _htmldoc = textReader.ReadToEnd();
                textReader.Close();
            }
            else
            {
                _htmldoc = new WebClient().DownloadString(@TXT_FileName.Text);
            }
            _htmldoc = _htmldoc.Replace("\r\n", "");
            
            ArrayList _mylist = _dom.prepareDOM(_htmldoc);

            string _sonuclar = "";            
            ArrayList _tagnames = new ArrayList();           
            
            foreach (HTMLMarkerClass.element d in _mylist)
            {            
                if(HTMLMarkerClass.desicionClass.determineLayout(d))
                {                        
                    if (!_sonuclar.Contains(d.outerHTML)) //if parent layout loads, childs don't need load
                    {
                            _sonuclar = _sonuclar + d.outerHTML_AE;
                            _tagnames.Add("MAINCONTENT: " + d.elementName.ToString());
                    }
                }

                string _hi = HTMLMarkerClass.desicionClass.determineHEADLINE_INFORMATION(d);
                if (_hi == "HEADLINE" || _hi == "INFORMATIONABOUTARTICLE")
                {     
                    _tagnames.Add(_hi + ": " + d.elementName.ToString() + ":" + d.BagofWords.ToString());
                }
            }

            /*listBox1.Items.Clear();
            webBrowser1.DocumentText =  _sonuclar;
            foreach (string item in _tagnames)
            {
                listBox1.Items.Add(item);
            } */           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();
            //HEADLINE PREDICTION
            string _d = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\annotatedtoo\";

            files = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(_d);
            files.AddRange(di.GetFiles("*.*"));

            TextWriter tw = new StreamWriter("erd_allhi4.arff");

            tw.WriteLine("@relation class_relation");
            tw.WriteLine("@attribute 'tagName' {DIV, FONT, H1, H2, H3, H4, H5, LI, SPAN, TD, UL}");
            tw.WriteLine("@attribute 'id' real");
            tw.WriteLine("@attribute 'elementlinked_id' real");
            tw.WriteLine("@attribute 'tag_id' real");
            tw.WriteLine("@attribute 'tag_class' real");
            tw.WriteLine("@attribute 'tag_idORclass' real");
            tw.WriteLine("@attribute 'dot_endofstence' real");            
            tw.WriteLine("@attribute 'wordCount' real");
            tw.WriteLine("@attribute 'DensityinHTML' real");
            tw.WriteLine("@attribute 'LinkCount' real");
            tw.WriteLine("@attribute 'wordCountinLink' real");
            tw.WriteLine("@attribute 'meanofWordinLinks' real");
            tw.WriteLine("@attribute 'meanofWordinLinksAllWords' real");
            tw.WriteLine("@attribute 'wordCount_AE' real");
            tw.WriteLine("@attribute 'densityinHTML_AE' real");
            tw.WriteLine("@attribute 'LinkCount_AE' real");
            tw.WriteLine("@attribute 'wordCountinLink_AE' real");
            tw.WriteLine("@attribute 'meanofWordinLinks_AE' real");
            tw.WriteLine("@attribute 'meanofWordinLinksAllWords_AE' real");
            tw.WriteLine("@attribute 'distanceBetweenMainLayout' real");
            tw.WriteLine("@attribute 'class' {HEADLINE, INFORMATIONABOUTARTICLE, IRRELEVANT}");
            tw.WriteLine("@data");

            //files.Count
            for (int i = 0; i < files.Count; i++)
            {
                try
                {
                    TextReader textReader = new StreamReader(_d + files[i].ToString());
                    string _htmldoc = textReader.ReadToEnd();
                    textReader.Close();
                    ArrayList _mylist = _dom.prepareDOM(_htmldoc);

                    foreach (HTMLMarkerClass.element d in _mylist)
                    {
                        //|| d.tagName == "P" d.tagName == "LI" || ||  d.tagName == "SMALL" d.tagName == "B" || || d.tagName == "STRONG" || d.tagName == "EM"
                        if (d.className != null)
                            if (d.tagName == "DIV" || d.tagName == "FONT" || d.tagName == "H1" || d.tagName == "H2"
                                || d.tagName == "H4" || d.tagName == "H5" || d.tagName == "SPAN"  || d.tagName == "TD" || d.tagName == "UL")
                            {
                                if (d.className == "SUMMARYOFARTICLE" || d.className == "COMMENTSOFARTICLE")
                                    d.className = "INFORMATIONABOUTARTICLE";

                                if (d.className == "HEADLINE" || d.className == "INFORMATIONABOUTARTICLE")
                                {                                    
                                    tw.WriteLine(d.tagName + "," + d.id + "," + d.elementlinked_id + "," + d.tag_id + "," + d.tag_class + "," + d.tag_idORclass + "," + d.dot_endofstence + "," + d.wordCount + "," + d.DensityinHTML + "," + d.LinkCount + "," + d.wordCountinLink + "," + d.meanofWordinLinks + "," + d.meanofWordinLinksAllWords +
                                                 "," + d.wordCount_AE + "," + d.DensityinHTML_AE + "," + d.LinkCount_AE + "," + d.wordCountinLink_AE + "," + d.meanofWordinLinks_AE + "," + d.meanofWordinLinksAllWords_AE +
                                                 "," + d.distanceBetweenMainLayout + "," + d.className);

                                }
                                else
                                    tw.WriteLine(d.tagName + "," + d.id + "," + d.elementlinked_id + "," + d.tag_id + "," + d.tag_class + "," + d.tag_idORclass + "," + d.dot_endofstence + "," + d.wordCount + "," + d.DensityinHTML + "," + d.LinkCount + "," + d.wordCountinLink + "," + d.meanofWordinLinks + "," + d.meanofWordinLinksAllWords +
                                                 "," + d.wordCount_AE + "," + d.DensityinHTML_AE + "," + d.LinkCount_AE + "," + d.wordCountinLink_AE + "," + d.meanofWordinLinks_AE + "," + d.meanofWordinLinksAllWords_AE +
                                                 "," + d.distanceBetweenMainLayout + ",IRRELEVANT");
                            }
                    }
                }
                catch
                {

                }
            }
            // close the stream
            tw.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();
            string _d = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\annotated2\";
            files = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(_d);
            files.AddRange(di.GetFiles("*.*"));
            TextWriter tw = new StreamWriter("erd_LD.arff");
            tw.WriteLine("@relation class_relation");
            tw.WriteLine("@attribute 'tagName' {BODY, TD, DIV}");
            tw.WriteLine("@attribute 'wordCount_AE' real");
            tw.WriteLine("@attribute 'densityinHTML_AE' real");
            tw.WriteLine("@attribute 'LinkCount_AE' real");
            tw.WriteLine("@attribute 'wordCountinLink_AE' real");
            tw.WriteLine("@attribute 'meanofWordinLinks_AE' real");
            tw.WriteLine("@attribute 'meanofWordinLinksAllWords_AE' real");
            tw.WriteLine("@attribute 'wordCount' real");
            tw.WriteLine("@attribute 'DensityinHTML' real");
            tw.WriteLine("@attribute 'LinkCount' real");
            tw.WriteLine("@attribute 'wordCountinLink' real");
            tw.WriteLine("@attribute 'meanofWordinLinks' real");
            tw.WriteLine("@attribute 'meanofWordinLinksAllWords' real");
            tw.WriteLine("@attribute 'id' real");
            tw.WriteLine("@attribute 'elementlinked_id' real");
            tw.WriteLine("@attribute 'tag_id' real");
            tw.WriteLine("@attribute 'tag_class' real");
            tw.WriteLine("@attribute 'tag_idORclass' real");
            tw.WriteLine("@attribute 'class' {irrelevantLayout, otherLayouts}");
            tw.WriteLine("@data");

            //files.Count
            for (int i = 0; i < files.Count; i++)
            {
                try
                {
                    TextReader textReader = new StreamReader(_d + files[i].ToString());
                    string _htmldoc = textReader.ReadToEnd();
                    textReader.Close();
                    ArrayList _mylist = _dom.prepareDOM(_htmldoc);

                    foreach (HTMLMarkerClass.element d in _mylist)
                    {
                        if(d.className != null)
                        if (d.tagName == "BODY" || d.tagName == "DIV" || d.tagName == "TD")
                        {
                            string _cn = "irrelevantLayout";
                            if (d.className != null)
                            {
                                _cn = d.className;
                                if (d.className == "ADVERTISEMENTS" || d.className == "BANNER"
                                    || d.className == "MENU" || d.className == "LINKS"
                                    || d.className == "LINKSRELATEDWITHARTICLE")
                                    _cn = "irrelevantLayout";
                                else
                                    _cn = "otherLayouts";
                            }

                            tw.WriteLine(d.tagName + "," 
                                + d.wordCount_AE + "," + d.DensityinHTML_AE + "," + d.LinkCount_AE + ","
                                + d.wordCountinLink_AE + "," + d.meanofWordinLinks_AE + "," + d.meanofWordinLinksAllWords_AE + ","
                                + d.wordCount + "," + d.DensityinHTML + "," + d.LinkCount + "," 
                                + d.wordCountinLink + "," + d.meanofWordinLinks + "," + d.meanofWordinLinksAllWords + ","
                                + d.id + "," + d.elementlinked_id + ","
                                + d.tag_id + "," + d.tag_class + "," + d.tag_idORclass + ","
                                + _cn);
                        }
                    }
                }
                catch
                {

                }
            }
            // close the stream
            tw.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _dom = new HTMLMarkerClass.DOM();

            DateTime _start = DateTime.Now;

            string _htmldoc = "";
            if (!TXT_FileName.Text.Contains("http://"))
            {
                TextReader textReader = new StreamReader(_dir + TXT_FileName.Text);
                _htmldoc = textReader.ReadToEnd();
                textReader.Close();
            }
            else
            {
                _htmldoc = new WebClient().DownloadString(@TXT_FileName.Text);
            }
            _htmldoc = _htmldoc.Replace("\r\n", "");            

            ArrayList _mylist = _dom.prepareDOM(_htmldoc);           

            TimeSpan _t = DateTime.Now.Subtract(_start);
            LBL_Time.Text = _t.TotalMilliseconds.ToString() + " ms";

            _dom.ProduceXMLFile(_htmldoc, _xmldir, "test.xml");

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);

            webBrowser1.Navigate(appPath + "\\test.xml");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DateTime _start = DateTime.Now;

            string _htmldoc = "";
            if (!TXT_FileName.Text.Contains("http://"))
            {
                TextReader textReader = new StreamReader(_dir + TXT_FileName.Text);
                _htmldoc = textReader.ReadToEnd();
                textReader.Close();
            }           

            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n";
            xml = xml + "<page>\r\n";
            if (_dom != null)
            {
                if (_dom._xmllist != null)
                {
                    foreach (HTMLMarkerClass.xml_elemet _xml in _dom._xmllist)
                        if (_xml.predicted_className == "HEADLINE")
                            xml = Fast_Retrieve(_xml, xml, _htmldoc, "title");
                    foreach (HTMLMarkerClass.xml_elemet _xml in _dom._xmllist)
                        if (_xml.predicted_className == "INFORMATIONABOUTARTICLE")
                            xml = Fast_Retrieve(_xml, xml, _htmldoc, "information");
                    foreach (HTMLMarkerClass.xml_elemet _xml in _dom._xmllist)
                        if (_xml.predicted_className == "MAIN")
                            xml = Fast_Retrieve(_xml, xml, _htmldoc, "main");
                }
                else
                    xml = xml + "Click 'Preapeare XML File for a given web page'\r\n";
            }
            else
                xml = xml + "Click 'Preapeare XML File for a given web page'\r\n";
         
            xml = xml + "</page>\r\n";

            System.IO.StreamWriter file = new System.IO.StreamWriter(_xmldir + "test.xml");
            file.WriteLine(xml);

            file.Close();           

            TimeSpan _t = DateTime.Now.Subtract(_start);
            lbl_dENae.Text = _t.TotalMilliseconds.ToString() + " ms";

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);

            webBrowser1.Navigate(appPath + "\\test.xml");
        }

        private string Fast_Retrieve(HTMLMarkerClass.xml_elemet _xml, string xml, string _htmldoc, string xmltagname)
        {
            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();

            string p_ename = _xml.parent_elementName;
            string ename = _xml.elementName;

            if (p_ename.Contains(","))
            {
                string[] s = p_ename.Split(',');
                p_ename = s[0];              
            }

            p_ename = p_ename.Replace(" ", ".");
            p_ename = p_ename.Replace(":", ".");
            p_ename = p_ename.Replace("(", ".");
            p_ename = p_ename.Replace(")", ".");
            p_ename = p_ename.Replace("?", ".");
            p_ename = p_ename.Replace("*", ".");

            if (ename.Contains(","))
            {
                string[] s = ename.Split(',');
                ename = s[0];               
            }

            ename = ename.Replace(" ", ".");
            ename = ename.Replace(":", ".");
            ename = ename.Replace("(", ".");
            ename = ename.Replace(")", ".");
            ename = ename.Replace("?", ".");
            ename = ename.Replace("*", ".");

            if (p_ename != "")
            {
                if (!_ht.ContainsKey(p_ename))
                {
                    string[] htmlcon = HTMLMarkerClass.webfilter.Contents_of_givenLayout_Tags_TESTER(_htmldoc, p_ename);
                    string[] htmlcon2 = new string[2];

                    _ht.Add(p_ename, htmlcon);
                    if (htmlcon != null)
                    if (htmlcon.Length == 1)
                        if (!_ht.ContainsKey(ename))
                        {
                            htmlcon2 = HTMLMarkerClass.webfilter.Contents_of_givenLayout_Tags_TESTER(htmlcon[0], ename);
                            _ht.Add(ename, htmlcon2);
                        }
                        else
                            htmlcon2 = (string[])_ht[ename];


                    if (htmlcon2 != null)
                    if (htmlcon2.Length == 1)
                    {
                        htmlcon2[0] = HTMLMarkerClass.HTML.stripHtml(htmlcon2[0]);
                        xml = xml + "<" + xmltagname + " tag=\"" + _dom.clear_illegal_characters_for_XML(ename) + "\" parenttag=\"" + _dom.clear_illegal_characters_for_XML(p_ename) + "\"  >\r\n" + HTMLMarkerClass.HTML.stripHtml(htmlcon2[0]) + "</" + xmltagname + ">\r\n";
                    }
                    else
                        xml = xml + "<" + xmltagname + " tag=\"" + _dom.clear_illegal_characters_for_XML(ename) + "\" parenttag=\"" + _dom.clear_illegal_characters_for_XML(p_ename) + "\"  >\r\n ... ERROR ... </" + xmltagname + ">\r\n";
                    
                }
                else
                {
                    string[] htmlcon = (string[])_ht[p_ename];
                    string[] htmlcon2 = new string[2];

                    if (htmlcon != null)
                    if (htmlcon.Length == 1)
                        if (!_ht.ContainsKey(ename))
                        {
                            htmlcon2 = HTMLMarkerClass.webfilter.Contents_of_givenLayout_Tags_TESTER(htmlcon[0], ename);
                            _ht.Add(ename, htmlcon2);
                        }
                        else
                            htmlcon2 = (string[])_ht[ename];

                    if(htmlcon2 != null)
                    if (htmlcon2.Length == 1)
                    {
                        htmlcon2[0] = HTMLMarkerClass.HTML.stripHtml(htmlcon2[0]);
                        xml = xml + "<" + xmltagname + " tag=\"" + _dom.clear_illegal_characters_for_XML(ename) + "\" parenttag=\"" + _dom.clear_illegal_characters_for_XML(p_ename) + "\"  >\r\n" + HTMLMarkerClass.HTML.stripHtml(htmlcon2[0]) + "</" + xmltagname + ">\r\n";
                    }
                    else
                        xml = xml + "<" + xmltagname + " tag=\"" + _dom.clear_illegal_characters_for_XML(ename) + "\" parenttag=\"" + _dom.clear_illegal_characters_for_XML(p_ename) + "\"  >\r\n ... ERROR ... </" + xmltagname + ">\r\n";


                }
            }
            else //parent boş ise direkt köke bak
            {
                if (!_ht.ContainsKey(ename))
                {
                    string[] htmlcon = HTMLMarkerClass.webfilter.Contents_of_givenLayout_Tags_TESTER(_htmldoc, ename);

                    if (htmlcon != null)
                    {
                        _ht.Add(ename, htmlcon);

                        if (htmlcon != null)
                        if (htmlcon.Length == 1)
                        {
                            htmlcon[0] = HTMLMarkerClass.HTML.stripHtml(htmlcon[0]);
                            xml = xml + "<" + xmltagname + " tag=\"" + _dom.clear_illegal_characters_for_XML(ename) + "\" parenttag=\"" + _dom.clear_illegal_characters_for_XML(p_ename) + "\"  >\r\n" + HTMLMarkerClass.HTML.stripHtml(htmlcon[0]) + "</" + xmltagname + ">\r\n";
                        }
                        else
                            xml = xml + "<" + xmltagname + " tag=\"" + _dom.clear_illegal_characters_for_XML(ename) + "\" parenttag=\"" + _dom.clear_illegal_characters_for_XML(p_ename) + "\"  >\r\n ... ERROR ... </" + xmltagname + ">\r\n";
                    }
                }
                else
                {
                    string[] htmlcon = (string[])_ht[ename];
                    if (htmlcon != null)
                    if (htmlcon.Length == 1)
                    {
                        htmlcon[0] = HTMLMarkerClass.HTML.stripHtml(htmlcon[0]);
                        xml = xml + "<" + xmltagname + " tag=\"" + _dom.clear_illegal_characters_for_XML(ename) + "\" parenttag=\"" + _dom.clear_illegal_characters_for_XML(p_ename) + "\"  >\r\n" + HTMLMarkerClass.HTML.stripHtml(htmlcon[0]) + "</" + xmltagname + ">\r\n";
                    }
                    else
                        xml = xml + "<" + xmltagname + " tag=\"" + _dom.clear_illegal_characters_for_XML(ename) + "\" parenttag=\"" + _dom.clear_illegal_characters_for_XML(p_ename) + "\"  >\r\n ... ERROR ... </" + xmltagname + ">\r\n";
                }

            }

            return xml;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _savehtmldoc = _savehtmldoc.Replace("::LINKS-", "::LINKS2-");
            _savehtmldoc = _savehtmldoc.Replace("::MENU", "::LINKS");
            _savehtmldoc = _savehtmldoc.Replace("::LINKS2-", "::MENU-");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();

            string _d = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\annotated2\";
            files = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(_d);
            files.AddRange(di.GetFiles("*.*"));
            TextWriter tw = new StreamWriter("erd_MHI.arff");
            tw.WriteLine("@relation class_relation");
            tw.WriteLine("@attribute 'tagName' {BODY, DIV, TD, FONT, H1, H2, H3, H4, H5, LI, SPAN, UL}");
            tw.WriteLine("@attribute 'wordCount_AE' real");
            tw.WriteLine("@attribute 'densityinHTML_AE' real");
            tw.WriteLine("@attribute 'LinkCount_AE' real");
            tw.WriteLine("@attribute 'wordCountinLink_AE' real");
            tw.WriteLine("@attribute 'meanofWordinLinks_AE' real");
            tw.WriteLine("@attribute 'meanofWordinLinksAllWords_AE' real");
            tw.WriteLine("@attribute 'wordCount' real");
            tw.WriteLine("@attribute 'DensityinHTML' real");
            tw.WriteLine("@attribute 'LinkCount' real");
            tw.WriteLine("@attribute 'wordCountinLink' real");
            tw.WriteLine("@attribute 'meanofWordinLinks' real");
            tw.WriteLine("@attribute 'meanofWordinLinksAllWords' real");
            tw.WriteLine("@attribute 'id' real");
            tw.WriteLine("@attribute 'elementlinked_id' real");
            tw.WriteLine("@attribute 'tag_id' real");
            tw.WriteLine("@attribute 'tag_class' real");
            tw.WriteLine("@attribute 'tag_idORclass' real");
            tw.WriteLine("@attribute 'class' {IRRELEVANT, MAIN, HEADLINE, INFORMATIONABOUTARTICLE}");
            tw.WriteLine("@data");

            for (int i = 0; i < files.Count; i++)
            {
                try
                {
                    TextReader textReader = new StreamReader(_d + files[i].ToString());
                    string _htmldoc = textReader.ReadToEnd();
                    textReader.Close();
                    ArrayList _mylist = _dom.prepareDOM(_htmldoc);

                    foreach (HTMLMarkerClass.element d in _mylist)
                    {
                        if (d.className != null)
                            if (d.tagName == "BODY" || d.tagName == "DIV" || d.tagName == "TD" || d.tagName == "FONT" || d.tagName == "H1" 
                                || d.tagName == "H2" || d.tagName == "H3"  || d.tagName == "H4" || d.tagName == "H5" || 
                                d.tagName == "SPAN" || d.tagName == "UL")
                            {
                                if (d.className == "SUMMARYOFARTICLE" || d.className == "COMMENTSOFARTICLE")
                                    d.className = "INFORMATIONABOUTARTICLE";
                                string _cn = d.className;
                                if (d.className == "MAIN" || d.className == "HEADLINE" || d.className == "INFORMATIONABOUTARTICLE")
                                    _cn = d.className;
                                else
                                    _cn = "IRRELEVANT";

                                tw.WriteLine(d.tagName + ","
                                    + d.wordCount_AE + "," + d.DensityinHTML_AE + "," + d.LinkCount_AE + ","
                                    + d.wordCountinLink_AE + "," + d.meanofWordinLinks_AE + "," + d.meanofWordinLinksAllWords_AE + ","
                                    + d.wordCount + "," + d.DensityinHTML + "," + d.LinkCount + ","
                                    + d.wordCountinLink + "," + d.meanofWordinLinks + "," + d.meanofWordinLinksAllWords + ","
                                    + d.id + "," + d.elementlinked_id + ","
                                    + d.tag_id + "," + d.tag_class + "," + d.tag_idORclass + ","
                                    + _cn);
                            }
                    }
                }
                catch
                {

                }
            }
            // close the stream
            tw.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();
            string _d = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\annotated2\";
            files = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(_d);
            files.AddRange(di.GetFiles("*.*"));
            TextWriter tw = new StreamWriter("timeeff.txt");
            for (int i = 0; i < files.Count; i++)
            {
                //try
                //{
                    TextReader textReader = new StreamReader(_d + files[i].ToString());
                    string _htmldoc = textReader.ReadToEnd();
                    textReader.Close();

                    _htmldoc = HTMLMarkerClass.HTML.trimOptions(_htmldoc);
                    _htmldoc = HTMLMarkerClass.HTML.trimScript(_htmldoc);  

                    DateTime _start = DateTime.Now;
                    ArrayList _mylist = _dom.prepareDOM(_htmldoc);
                    TimeSpan _t2 = DateTime.Now.Subtract(_start);


                    _start = DateTime.Now;
                    int h = 0; int ia = 0; int m = 0; int mdiv = 0;
                    int ph = 0; int pia = 0; int pm = 0; int pmdiv = 0;

                    string xml = "";
                    foreach (HTMLMarkerClass.xml_elemet _xml in _dom._xmllist)
                        if (_xml.predicted_className == "HEADLINE")
                        {
                            xml = Fast_Retrieve(_xml, "", _htmldoc, "title");
                            h++;
                            if(xml.Contains("... ERROR ..."))
                                ph++;
                        }
                    foreach (HTMLMarkerClass.xml_elemet _xml in _dom._xmllist)
                        if (_xml.predicted_className == "INFORMATIONABOUTARTICLE")
                        {
                            xml = Fast_Retrieve(_xml, "", _htmldoc, "information");
                            ia++;
                            if (xml.Contains("... ERROR ..."))
                                pia++;
                        }

                    foreach (HTMLMarkerClass.xml_elemet _xml in _dom._xmllist)
                        if (_xml.predicted_className == "MAIN")
                        {
                            xml = Fast_Retrieve(_xml, "", _htmldoc, "main");
                            m++;
                            if (xml.Contains("... ERROR ..."))
                                pm++;

                            if (_xml.elementName.Contains("DIV"))
                            {
                                mdiv++;
                                if (xml.Contains("... ERROR ..."))
                                    pmdiv++;
                            }
                        }
                    TimeSpan _t3 = DateTime.Now.Subtract(_start);

                    tw.WriteLine(_t2.TotalMilliseconds.ToString() + " " + _t3.TotalMilliseconds.ToString() + " " 
                        + h.ToString() + " " + ph.ToString() + " " + ia.ToString() + " " + pia.ToString() + " " + m.ToString() + " " + pm.ToString()
                        + " " + mdiv.ToString() + " " + pmdiv.ToString());
                    
                /*}
                catch
                {

                }*/
            }
            // close the stream
            tw.Close();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
             //
            StreamReader file = new StreamReader("C:/MySpace/MyProjects/WebMarker/L3S-GN1-20100130203947-00001/url-mapping.txt");
            ArrayList _allfilename = new ArrayList();
            ArrayList _alldomainname = new ArrayList();
            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                string pattern = @"<urn:uuid:(.*?)>";
                Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
                MatchCollection matchList = exp.Matches(line);
                _allfilename.Add(matchList[0].Groups[1].ToString()+".html");
                pattern = @"http://(.*?)/";
                exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
                matchList = exp.Matches(line);
                _alldomainname.Add(matchList[0].Groups[1].ToString());                
            }

            HTMLMarkerClass.DOM _dom = new HTMLMarkerClass.DOM();

            string _d = @"C:\MySpace\MyProjects\WebMarker\L3S-GN1-20100130203947-00001\annotated2\";
            files = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(_d);
            files.AddRange(di.GetFiles("*.*"));
            TextWriter tw = new StreamWriter("crawler.arff");
            tw.WriteLine("@relation class_relation");
            tw.WriteLine("@attribute 'tagName' {BODY, TD, DIV}");
            tw.WriteLine("@attribute 'wordCount_AE' real");
            tw.WriteLine("@attribute 'densityinHTML_AE' real");
            tw.WriteLine("@attribute 'LinkCount_AE' real");
            tw.WriteLine("@attribute 'wordCountinLink_AE' real");
            tw.WriteLine("@attribute 'meanofWordinLinks_AE' real");
            tw.WriteLine("@attribute 'meanofWordinLinksAllWords_AE' real");
            tw.WriteLine("@attribute 'wordCount' real");
            tw.WriteLine("@attribute 'DensityinHTML' real");
            tw.WriteLine("@attribute 'LinkCount' real");
            tw.WriteLine("@attribute 'wordCountinLink' real");
            tw.WriteLine("@attribute 'meanofWordinLinks' real");
            tw.WriteLine("@attribute 'meanofWordinLinksAllWords' real");
            tw.WriteLine("@attribute 'tag_idORclass' real");
            tw.WriteLine("@attribute 'similarity_with_other_web_page' real");
            tw.WriteLine("@attribute 'class' {main, menu, links, irrelevantLayout, otherLayouts}");
            tw.WriteLine("@data");

            //files.Count
            for (int i = 0; i < files.Count; i++)
            {
                try
                {
                    string filename1 = files[i].ToString();
                    string filename1_domainname = "";
                    for(int m = 0; m < _alldomainname.Count; m++)
                    {
                        if(filename1 == _allfilename[m].ToString())
                            filename1_domainname = _alldomainname[m].ToString();
                    }

                    string filename2 = "";
                    for(int m = 0; m < _allfilename.Count; m++)
                    {
                        if (filename1 != _allfilename[m].ToString())
                            if (filename1_domainname == _alldomainname[m].ToString())
                                filename2 = _allfilename[m].ToString();

                    }

                    if (filename2 != "")
                    {
                        TextReader textReader = new StreamReader(_d + filename1);
                        string _htmldoc = textReader.ReadToEnd();
                        textReader.Close();
                        TextReader textReader2 = new StreamReader(_d + filename2);
                        string _htmldoc2 = textReader2.ReadToEnd();
                        textReader2.Close();

                        ArrayList _mylist1 = _dom.prepareDOM(_htmldoc);

                        HTMLMarkerClass.DOM _dom2 = new HTMLMarkerClass.DOM();

                        ArrayList _mylist2 = _dom2.prepareDOM(_htmldoc2);

                        for (int m = 0; m < _mylist1.Count; m++)
                        {
                            HTMLMarkerClass.element _element1 = (HTMLMarkerClass.element)_mylist1[m];
                            if (_element1.tagName == "DIV" || _element1.tagName == "TD")
                            {
                                int count_of_similar_element = 0;
                                string bagofword2 = "";
                                for (int n = 0; n < _mylist2.Count; n++)
                                {
                                    HTMLMarkerClass.element _element2 = (HTMLMarkerClass.element)_mylist2[n];
                                    if (_element1.elementName == _element2.elementName)
                                    {
                                        count_of_similar_element++;
                                        bagofword2 = _element2.BagofWords_AE;
                                    }

                                    if (count_of_similar_element > 1)
                                        break;
                                }

                                if (count_of_similar_element == 1)
                                {
                                    //calculate similarity
                                    _element1.similarity_with_other_web_page = HTMLMarkerClass.similarity.Cossine_Similarity(_element1.BagofWords_AE, bagofword2);
                                    _mylist1[m] = (HTMLMarkerClass.element)_element1;
                                }
                                //if count_of_similar_element = 0, there is no same layout
                                //if count_of_similar_element > 1, there is a lot of layouts in web page so this element is ignored
                            }//if DIV OR TD
                        }

                        //similarity_control*/

                        foreach (HTMLMarkerClass.element d in _mylist1)
                        {
                            if (d.className != null)                                
                                if (d.tagName == "BODY" || d.tagName == "DIV" || d.tagName == "TD")
                                {
                                    string _cn = "irrelevantLayout";
                                    if (d.className != null)
                                    {
                                        _cn = d.className;

                                        if (d.className == "ADVERTISEMENTS" || d.className == "BANNER")
                                            _cn = "irrelevantLayout";
                                        else
                                            _cn = "otherLayouts";

                                        if (d.className == "MENU" || d.className == "LINKSRELATEDWITHARTICLE")
                                            if (d.className == "MENU")
                                                _cn = "menu";
                                            else
                                                _cn = "";

                                        if (d.className == "LINKS")
                                            _cn = "links";
                                        if (d.className == "MAIN")
                                            _cn = "main";
                                    }

                                    if (_cn != "")
                                        tw.WriteLine(d.tagName + ","
                                            + d.wordCount_AE + "," + d.DensityinHTML_AE + "," + d.LinkCount_AE + ","
                                            + d.wordCountinLink_AE + "," + d.meanofWordinLinks_AE + "," + d.meanofWordinLinksAllWords_AE + ","
                                            + d.wordCount + "," + d.DensityinHTML + "," + d.LinkCount + ","
                                            + d.wordCountinLink + "," + d.meanofWordinLinks + "," + d.meanofWordinLinksAllWords + ","
                                            + d.tag_idORclass + "," + d.similarity_with_other_web_page + "," 
                                            + _cn);
                                }
                        }
                    }//if filename 2 ok
                }
                catch
                {

                }
            }
            // close the stream
            tw.Close();
        }
    }
    
}
