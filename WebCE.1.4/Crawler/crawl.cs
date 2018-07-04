using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//additional packages
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;
using System.IO;

namespace Crawler
{
    public class kayit
    {
        public string URL;
        public string HTML_Content;
        public string XML_Content;
        public int URL_Count;
    }

    public class Crawler
    {//base url
        public string default_url;
        //encoding sık kontrolü sorun yaratır.
        //en son encoding bilgisini kullan
        public string last_error;
        private Encoding last_encoding;
        private int error_cnt;

        //Hashtable link eklerken var olan linkleri eklememek için bellekte kontrolünde kullanıldı.
        //veritabanının yükü hafifletildi.
        private Hashtable all_links;

        //bazı linkler id, article_id ve özel bir numara içeriyor. Bunların kontrolü için kullanılacak.
        private ArrayList kayitlar;

        public bool crawl(string baslangic_url, string directoryname)
        {
            all_links = new Hashtable();
            kayitlar = new ArrayList();

            download_given_links(baslangic_url, 0);
            saveAllFiles(directoryname);

            return true;
        }

        public bool crawl(string baslangic_url, string directoryname, int count)
        {
            all_links = new Hashtable();
            kayitlar = new ArrayList();

            download_given_links(baslangic_url, count);
            saveAllFiles(directoryname);

            return true;
        }

        // Display results to a text
        public int download_given_links(string baslangic_url, int count)
        {
            default_url = baslangic_url;
            default_url = baslangic_url.ToString().Substring(0, baslangic_url.ToString().LastIndexOf("/") + 1);

            kayit _k = new kayit();

            string html_content = download(baslangic_url);
            _k.URL = baslangic_url;
            _k.HTML_Content = html_content;
            if (html_content != "")
                _k.URL_Count = Add_links_to_Hashtable(html_content, baslangic_url);

            kayitlar.Add(_k);

            int i = 1;

            int cnt = all_links.Count;//all records, changeable

            if (count > 0)
                cnt = count;

            while (i < cnt)
            {
                _k = new kayit();
                html_content = download(all_links[i - 1].ToString());

                if (html_content != "")
                {
                    _k.URL = all_links[i - 1].ToString();
                    _k.HTML_Content = html_content;
                    default_url = all_links[i - 1].ToString().Substring(0, all_links[i - 1].ToString().LastIndexOf("/") + 1);

                    _k.URL_Count = Add_links_to_Hashtable(html_content, baslangic_url);

                    kayitlar.Add(_k);                    
                }
                i++;
            }         

            return 0;
        }

        public bool saveAllFiles(string directoryname)
        {
            if (!Directory.Exists(directoryname))
            {
                Directory.CreateDirectory(directoryname);
            }

            StreamWriter file = new StreamWriter(directoryname + "\\0000.txt");
            foreach (kayit _k in kayitlar)
            { 
                file.WriteLine(_k.URL + "," + _k.URL_Count.ToString() + "," + _k.HTML_Content.Length.ToString());
            }

            file.Close();

            int i = 1;
            foreach (kayit _k in kayitlar)
            {
                StreamWriter file2;
                if(i.ToString().Length == 1)
                    file2 = new StreamWriter(directoryname + "\\000" + i.ToString() + ".html");
                else if (i.ToString().Length == 2)
                    file2 = new StreamWriter(directoryname + "\\00" + i.ToString() + ".html");
                else if (i.ToString().Length == 3)
                    file2 = new StreamWriter(directoryname + "\\0" + i.ToString() + ".html");
                else
                    file2 = new StreamWriter(directoryname + "\\" + i.ToString() + ".html");                

                file2.WriteLine(_k.HTML_Content);
                file2.Close();
                i++;
            }

            return true;
        }

        // Display results to a text
        public string download(string URL)
        {
            WebResponse response = GetResponse(URL);

            if (response != null)
            {
                if (last_encoding == null)
                    last_encoding = Encoding.Default;

                StreamReader reader = new StreamReader(response.GetResponseStream(), last_encoding);

                string content = reader.ReadToEnd();

                if (error_cnt == 2)
                {
                    last_error = "2 kere aynı sayfa istendi...";
                    return "";
                }

                if (content.Contains("�"))
                {
                    error_cnt++;

                    last_encoding = Encoding.Default;
                    content = download(URL);
                }

                if (content.Contains("Ã") || content.Contains("Ä"))
                {
                    error_cnt++;

                    last_encoding = Encoding.UTF8;
                    content = download(URL);
                }

                error_cnt = 0;


                //Eğer sayfa bulunamadı türünden hata var ise içeri temizle
                //Milliyet için
                //<strong>SAYFA BULUNAMADI  !!!</strong>
                //Hürriyet için
                //Aradığınız sayfa <b>http://www.hurriyet.com.tr</b> üzerinde bulunamadı.
                //Sabah için
                //Sayfa Bulunamadı!</font>

                content = RepeairTurkishCharacter(content);


                return content;
            }

            else return "";
        }

        // Display results to a webpage
        private WebResponse GetResponse(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.KeepAlive = false;
                request.Method = "GET";
                request.AllowAutoRedirect = false;

                /*if (ozeldurum == true)
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.MediaType = "text/html;charset=utf-8";
                    request.UserAgent = "MSIE 7.0";
                }*/
                //request.Proxy = WebProxy.GetDefaultProxy();
                //request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
                return request.GetResponse();
            }

            catch (WebException e)
            {
                last_error = "Web sayfası açılamadı: " + e;
                return null;
            }

            catch (IOException e)
            {
                last_error = "Dosya Yaratılamadı: " + e;
                return null;
            }
        }

        //REGULAR EXPRESSIONS for extracting links
        public int Add_links_to_Hashtable(string html_content, string baslangic_url)
        {
            int cnt = all_links.Count;
            int total_links_in_a_web_page = 0;
            //links in javascript //for Milliyet
            string pattern = @"openWindow\('(.*?)'\)";
            Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            MatchCollection matchList = exp.Matches(html_content);

            total_links_in_a_web_page = total_links_in_a_web_page + matchList.Count;

            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];
                if (match.Value.Length > 0)
                {
                    string web_page = match.Groups[1].Value;

                    web_page = web_page.ToLower();

                    if (web_page.Length != 0)
                    {
                        web_page = repair_link(web_page, baslangic_url);
                        if (web_page != "")
                        {
                            //primary key                           
                            if (!all_links.ContainsValue(web_page))
                            {
                                all_links.Add(cnt++, web_page);
                            }
                        }
                    }
                }
            }

            //for Sabah 2002-2003
            pattern = @"popup\('(.*?)'";
            exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            matchList = exp.Matches(html_content);

            total_links_in_a_web_page = total_links_in_a_web_page + matchList.Count;

            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];
                if (match.Value.Length > 0)
                {
                    string web_page = match.Groups[1].Value;

                    web_page = web_page.ToLower();

                    if (web_page.Length != 0)
                    {
                        web_page = repair_link(web_page, baslangic_url);
                        if (web_page != "")
                        {
                            all_links.Add(cnt++, web_page);
                        }
                    }
                }
            }


            //for a href
            pattern = "href=\"(.*?)\"";            
            exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            matchList = exp.Matches(html_content);

            total_links_in_a_web_page = total_links_in_a_web_page + matchList.Count;

            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];
                if (match.Value.Length > 0)
                {
                    string web_page = match.Groups[1].Value;
                    if (web_page.Length != 0)
                    {
                        web_page = repair_link(web_page, baslangic_url);
                        if (web_page != "")
                        {
                            //primary key                           
                            if (!all_links.ContainsValue(web_page))
                            {
                                all_links.Add(cnt++, web_page);
                            }
                        }
                    }
                }
            }

            //for a href2
            pattern = "href='(.*?)'";
            exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            matchList = exp.Matches(html_content);

            total_links_in_a_web_page = total_links_in_a_web_page + matchList.Count;

            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];
                if (match.Value.Length > 0)
                {
                    string web_page = match.Groups[1].Value;
                    if (web_page.Length != 0)
                    {
                        web_page = repair_link(web_page, baslangic_url);
                        if (web_page != "")
                        {
                            //primary key                           
                            if (!all_links.ContainsValue(web_page))
                            {
                                all_links.Add(cnt++, web_page);
                            }
                        }
                    }
                }
            }

            //for xml
            pattern = "<link>(.*?)</link>";
            exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            matchList = exp.Matches(html_content);

            total_links_in_a_web_page = total_links_in_a_web_page + matchList.Count;

            for (int i = 0; i < matchList.Count; i++)
            {
                Match match = matchList[i];
                if (match.Value.Length > 0)
                {
                    string web_page = match.Groups[1].Value;
                    if (web_page.Length != 0)
                    {
                        web_page = repair_link(web_page, baslangic_url);
                        if (web_page != "")
                        {
                            //primary key                           
                            if (!all_links.ContainsValue(web_page))
                            {
                                all_links.Add(cnt++, web_page);
                            }
                        }
                    }
                }
            }

            
            
            return total_links_in_a_web_page;
        }

        //linkleri kontrol etmeliyiz o web sitesi dışında bir durum varsa eklememeliyiz.
        public string repair_link(string web_page, string baslangic_url)
        {
            //http://www.milliyet.com.tr/Yazar.aspx?aType=YazarDetay&ArticleID=1041442&amp;AuthorID=86&amp;Date=01.01.2009&amp;b=PKK, AKPden korktu, taktik degistirdi&amp;a=Mehmet Ali Birand
            web_page = web_page.Replace("amp;", "");
            string base_url = FindBaseUrl(baslangic_url);

            web_page = web_page.Trim();

            //his_ sabaha özel
            if (!web_page.Contains(base_url))
                web_page = "";                      

            return web_page;
        }

        //İşlem yapılan URL bulunması için
        public string FindBaseUrl(string url)
        {
            string result = "";
            string pattern = @"http://.*?/";
            Regex exp = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);

            MatchCollection matchList = exp.Matches(url);

            if (matchList.Count > 0)
            {
                Match match = matchList[0];
                result = match.Groups[0].Value;
            }

            return result;
        }

        private string RepeairTurkishCharacter(string content)
        {
            content = content.Replace("&#252;", "ü");
            content = content.Replace("&#220;", "Ü");
            content = content.Replace("&#231;", "ç");
            content = content.Replace("&#199;", "Ç");
            content = content.Replace("&#351;", "ş");
            content = content.Replace("&#350;", "Ş");
            content = content.Replace("&#286;", "Ğ");
            content = content.Replace("&#287;", "ğ");
            content = content.Replace("&#305;", "ı");
            content = content.Replace("&#304;", "İ");
            content = content.Replace("&#246;", "ö");
            content = content.Replace("&#214;", "Ö");
            return content;
        }

        //http://arsiv.sabah.com.tr/arsiv/2003/01/02/s02.html
        //http://webarsiv.hurriyet.com.tr/2003/12/31/hurriyetim.asp
        //http://arsiv.sabah.com.tr/2004/01/02/yaz27-50-105-20040101.html
        //http://www.sabah.com.tr/Yasam/2010/03/14/mucevher_fuarinda_hirsizlik
        //http://www.milliyet.com.tr/hakkari-de-askerlere-ates-acildi/siyaset/sondakika/14.03.2010/1211267/default.htm?ver=32
        //http://hurarsiv.hurriyet.com.tr/goster/haberler.aspx?id=2065&tarih=2008-03-02
        //http://www.milliyet.com.tr/2006/01/01/

        private static bool IsInteger(string theValue)
        {
            try
            {
                Convert.ToInt32(theValue);
                return true;
            }
            catch
            {
                return false;
            }
        } //IsInteger
       
    }
}