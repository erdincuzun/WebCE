using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLMarkerClass
{
    public static class desicionClass
    {
                         
        /* Desicion Tree for finding Main Layout 
           J48 pruned tree
        */

        public static bool determineIrrevelantLayout(HTMLMarkerClass.element d)
        {            
        if (d.meanofWordinLinksAllWords <= 0.334821) 
	        if (d.wordCount_AE <= 0) return true;
	        else 
		        if (d.meanofWordinLinksAllWords <= 0.163462)
                    if (d.wordCount <= 2)
                    {
                        if (d.tagName == "BODY") return false;
                        if (d.tagName == "TD") return false;
                        if (d.tagName == "DIV")
                        {
                            if (d.DensityinHTML <= 0.003273)
                                if (d.DensityinHTML_AE <= 0.003145)
                                    if (d.DensityinHTML_AE <= 0.002534)
                                        if (d.tag_idORclass <= 0)
                                            if (d.DensityinHTML <= 0.00182)
                                                if (d.wordCount <= 1)
                                                    if (d.DensityinHTML <= 0.001148)
                                                        if (d.DensityinHTML <= 0.000967) return false;
                                                        else return true;
                                                    else return false;
                                                else
                                                    if (d.DensityinHTML <= 0.001779) return false;
                                                    else return true;
                                            else return false;
                                        else
                                            if (d.DensityinHTML <= 0.00105) return false;
                                            else return true;
                                    else return false;
                                else return true;
                            else return false;
                        }
                    }
                    else
                        if (d.wordCount_AE <= 2)
                            if (d.meanofWordinLinksAllWords <= 0.033333) return false;
                            else
                                if (d.meanofWordinLinks <= 1.894737) return true;
                                else
                                    if (d.DensityinHTML_AE <= 0.002096) return false;
                                    else
                                        if (d.LinkCount <= 2) return true;
                                        else return false;
                        else return false;
		        else 
			        if (d.DensityinHTML_AE <= 0.207895) 
				        if (d.wordCountinLink_AE <= 14) 
					        if (d.meanofWordinLinks_AE <= 1.365854) return true;
					        else 
						        if (d.meanofWordinLinksAllWords_AE <= 0.287129) return false;
						        else 
							        if (d.wordCount <= 36) 
								        if (d.wordCount <= 21) 
									        if (d.meanofWordinLinks <= 2.416667) return true;
									        else 
										        if (d.meanofWordinLinksAllWords <= 0.294118) return true;
										        else return false;
								        else return false;
							        else return true;
				        else return true;
			        else 
				        if (d.wordCount <= 187) 
					        if (d.wordCount <= 132) return false;
					        else return true;
				        else return false;
        else 
	        if (d.meanofWordinLinksAllWords <= 0.571429) 
		        if (d.LinkCount <= 1) 
			        if (d.LinkCount_AE <= 0) return true;
			        else 
				        if (d.wordCountinLink <= 2) 
					        if (d.DensityinHTML <= 0.005338) return true;
					        else return false;
				        else 
					        if (d.meanofWordinLinksAllWords <= 0.520325) return false;
					        else 
						        if (d.DensityinHTML <= 0.015306) return false;
						        else return true;
		        else 
			        if (d.meanofWordinLinks_AE <= 2.679245) return true;
			        else 
				        if (d.tag_idORclass <= 0) return true;
				        else 
					        if (d.wordCount_AE <= 9) return true;
					        else return false;
	        else 
		        if (d.meanofWordinLinksAllWords_AE <= 4) 
			        if (d.wordCountinLink <= 5) 
				        if (d.meanofWordinLinksAllWords <= 1.125) 
					        if (d.meanofWordinLinks_AE <= 2.75) 
						        if (d.tag_idORclass <= 0) 
							        if (d.wordCount <= 4) 
								        if (d.meanofWordinLinks_AE <= 0.888889) return true;
								        else return false;
							        else return true;
						        else return true;
					        else 
						        if (d.DensityinHTML_AE <= 0.009464) 
							        if (d.DensityinHTML <= 0.006711) 
								        if (d.DensityinHTML <= 0.004831) return true;
								        else return false;
							        else return true;
						        else return false;
				        else return true;
			        else return true;
		        else 
			        if (d.meanofWordinLinksAllWords_AE <= 6) return true;
			        else return false;

        return false;
        }

        public static bool determineLayout(HTMLMarkerClass.element d)
        {
                  /*int c = 0;
                  if (d.elementName.Contains("\"col one\""))
                      c = 1;*/

            if (d.tagName == "BODY" || d.tagName == "DIV" || d.tagName == "TD")
            {
                if (d.wordCount_AE <= 137)
                    if (d.DensityinHTML_AE <= 0.081716) return false;
                    else
                        if (d.meanofWordinLinksAllWords_AE <= 0.10989) return true;
                        else return false;
                else
                        if (d.meanofWordinLinksAllWords_AE <= 0.243478)
                        {
                            if (d.tagName == "BODY") return true;
                            if (d.tagName == "TD") return true;
                            if (d.tagName == "DIV") return true;
                        }
                        else
                            if (d.DensityinHTML_AE <= 0.537954) return false;
                            else return true;
            }
            else
                return false;

            return false;
        }

        public static string determineHEADLINE_INFORMATION(HTMLMarkerClass.element d)
        {
            if (d.wordCount > 3)
            {
                if (d.DensityinHTML_AE <= 0.126168)
                {
                    if (d.LinkCount <= 0)
                    {
                        if (d.tagName == "DIV")
                        {
                            if (d.wordCount_AE <= 0) return "IRRELEVANT";
                            else
                                if (d.wordCount <= 22)
                                    if (d.wordCount_AE <= 8)
                                        if (d.wordCount <= 2)
                                            if (d.tag_idORclass <= 0)
                                                if (d.DensityinHTML <= 0.001241) return "IRRELEVANT";
                                                else
                                                    if (d.wordCount <= 1)
                                                        if (d.DensityinHTML_AE <= 0.002865) return "INFORMATIONABOUTARTICLE";
                                                        else return "IRRELEVANT";
                                                    else return "IRRELEVANT";
                                            else
                                                if (d.DensityinHTML_AE <= 0.002534) return "IRRELEVANT";
                                                else
                                                    if (d.DensityinHTML <= 0.002874) return "HEADLINE";
                                                    else return "IRRELEVANT";
                                        else
                                            if (d.tag_idORclass <= 0) return "INFORMATIONABOUTARTICLE";
                                            else
                                                if (d.wordCount_AE <= 4)
                                                    if (d.wordCount_AE <= 2)
                                                        if (d.DensityinHTML <= 0.002845) return "HEADLINE";
                                                        else
                                                            if (d.wordCount <= 4) return "IRRELEVANT";
                                                            else return "INFORMATIONABOUTARTICLE";
                                                    else
                                                        if (d.DensityinHTML_AE <= 0.002336) return "IRRELEVANT";
                                                        else return "INFORMATIONABOUTARTICLE";
                                                else
                                                    if (d.wordCount <= 7)
                                                        if (d.DensityinHTML <= 0.007174)
                                                            if (d.DensityinHTML <= 0.00455) return "HEADLINE";
                                                            else return "INFORMATIONABOUTARTICLE";
                                                        else return "HEADLINE";
                                                    else return "IRRELEVANT";
                                    else
                                        if (d.tag_idORclass <= 0)
                                            if (d.DensityinHTML <= 0.015009) return "IRRELEVANT";
                                            else
                                                if (d.wordCount <= 9) return "IRRELEVANT";
                                                else
                                                    if (d.wordCount <= 17)
                                                        if (d.wordCount <= 11) return "INFORMATIONABOUTARTICLE";
                                                        else
                                                            if (d.wordCount <= 12) return "HEADLINE";
                                                            else
                                                                if (d.wordCount <= 13) return "INFORMATIONABOUTARTICLE";
                                                                else
                                                                    if (d.wordCount <= 16) return "HEADLINE";
                                                                    else return "INFORMATIONABOUTARTICLE";
                                                    else
                                                        if (d.DensityinHTML <= 0.019534) return "IRRELEVANT";
                                                        else
                                                            if (d.DensityinHTML <= 0.033019) return "INFORMATIONABOUTARTICLE";
                                                            else return "MAIN";
                                        else
                                            if (d.wordCount <= 12)
                                                if (d.wordCount <= 9) return "INFORMATIONABOUTARTICLE";
                                                else return "HEADLINE";
                                            else return "INFORMATIONABOUTARTICLE";
                                else
                                    if (d.DensityinHTML <= 0.079926) return "IRRELEVANT";
                                    else return "MAIN";
                        }
                        if (d.tagName == "FONT")
                        {
                            if (d.wordCount <= 12)
                                if (d.DensityinHTML <= 0.00339)
                                    if (d.wordCount <= 1) return "IRRELEVANT";
                                    else return "INFORMATIONABOUTARTICLE";
                                else return "HEADLINE";
                            else
                                if (d.DensityinHTML_AE <= 0.024242) return "INFORMATIONABOUTARTICLE";
                                else return "IRRELEVANT";
                        }
                        if (d.tagName == "H1") return "HEADLINE";
                        if (d.tagName == "H2")
                        {
                            if (d.wordCount <= 16) return "HEADLINE";
                            else
                                if (d.DensityinHTML <= 0.020531) return "HEADLINE";
                                else return "IRRELEVANT";
                        }
                        if (d.tagName == "H3")
                            if (d.wordCount <= 10) return "HEADLINE";
                            else
                                if (d.DensityinHTML <= 0.021529) return "IRRELEVANT";
                                else return "HEADLINE";
                        if (d.tagName == "H4")
                        {
                            if (d.wordCount <= 2) return "HEADLINE";
                            else
                                if (d.wordCount <= 11) return "INFORMATIONABOUTARTICLE";
                                else return "IRRELEVANT";
                        }
                        if (d.tagName == "H5")
                        {
                            if (d.wordCount <= 4)
                                if (d.tag_idORclass <= 0) return "HEADLINE";
                                else return "INFORMATIONABOUTARTICLE";
                            else return "INFORMATIONABOUTARTICLE";
                        }
                        if (d.tagName == "LI") return "HEADLINE";
                        if (d.tagName == "SPAN")
                        {
                            if (d.wordCount <= 6) return "INFORMATIONABOUTARTICLE";
                            else
                                if (d.tag_idORclass <= 0)
                                    if (d.DensityinHTML <= 0.019432) return "INFORMATIONABOUTARTICLE";
                                    else return "IRRELEVANT";
                                else return "HEADLINE";
                        }
                        if (d.tagName == "TD")
                        {
                            if (d.wordCount_AE <= 1) return "IRRELEVANT";
                            else
                                if (d.wordCount <= 10)
                                    if (d.wordCount_AE <= 5)
                                        if (d.wordCount_AE <= 2)
                                            if (d.tag_idORclass <= 0)
                                                if (d.DensityinHTML <= 0.014382) return "INFORMATIONABOUTARTICLE";
                                                else return "IRRELEVANT";
                                            else return "HEADLINE";
                                        else
                                            if (d.DensityinHTML <= 0.018717) return "INFORMATIONABOUTARTICLE";
                                            else return "IRRELEVANT";
                                    else
                                        if (d.wordCount <= 6) return "HEADLINE";
                                        else
                                            if (d.DensityinHTML_AE <= 0.009381) return "INFORMATIONABOUTARTICLE";
                                            else
                                                if (d.wordCount_AE <= 8)
                                                    if (d.wordCount <= 7)
                                                        if (d.DensityinHTML <= 0.014019) return "HEADLINE";
                                                        else
                                                            if (d.DensityinHTML_AE <= 0.01847) return "IRRELEVANT";
                                                            else return "INFORMATIONABOUTARTICLE";
                                                    else return "INFORMATIONABOUTARTICLE";
                                                else
                                                    if (d.DensityinHTML <= 0.021635)
                                                        if (d.DensityinHTML <= 0.015172) return "IRRELEVANT";
                                                        else
                                                            if (d.DensityinHTML <= 0.020253) return "HEADLINE";
                                                            else return "IRRELEVANT";
                                                    else return "INFORMATIONABOUTARTICLE";
                                else
                                    if (d.wordCount_AE <= 20) return "IRRELEVANT";
                                    else return "INFORMATIONABOUTARTICLE";
                        }
                        if (d.tagName == "UL")
                        {
                            if (d.tag_idORclass <= 0)
                                if (d.wordCount <= 7) return "IRRELEVANT";
                                else return "INFORMATIONABOUTARTICLE";
                            else return "IRRELEVANT";
                        }
                    }
                    else
                    {
                        if (d.tagName == "DIV") return "IRRELEVANT";
                        if (d.tagName == "FONT")
                        {
                            if (d.meanofWordinLinksAllWords <= 0.4375)
                                if (d.wordCountinLink <= 3) return "INFORMATIONABOUTARTICLE";
                                else return "IRRELEVANT";
                            else return "IRRELEVANT";
                        }
                        if (d.tagName == "H1") return "HEADLINE";
                        if (d.tagName == "H2") return "HEADLINE";
                        if (d.tagName == "H3") return "HEADLINE";
                        if (d.tagName == "H4") return "HEADLINE";
                        if (d.tagName == "H5") return "HEADLINE";
                        if (d.tagName == "LI") return "IRRELEVANT";
                        if (d.tagName == "SPAN")
                        {
                            if (d.meanofWordinLinksAllWords_AE <= 4) return "IRRELEVANT";
                            else return "INFORMATIONABOUTARTICLE";
                        }
                        if (d.tagName == "TD") return "IRRELEVANT";
                        if (d.tagName == "UL") return "IRRELEVANT";
                    }
                }
                else
                    if (d.meanofWordinLinksAllWords_AE <= 0.273684)
                        if (d.DensityinHTML_AE <= 0.238491)
                        {
                            if (d.tagName == "DIV")
                            {
                                if (d.LinkCount_AE <= 5) return "MAIN";
                                else return "IRRELEVANT";
                            }
                            if (d.tagName == "FONT") return "IRRELEVANT";
                            if (d.tagName == "H1") return "HEADLINE";
                            if (d.tagName == "H2") return "HEADLINE";
                            if (d.tagName == "H3") return "HEADLINE";
                            if (d.tagName == "H4") return "HEADLINE";
                            if (d.tagName == "H5") return "HEADLINE";
                            if (d.tagName == "LI") return "IRRELEVANT";
                            if (d.tagName == "SPAN") return "IRRELEVANT";
                            if (d.tagName == "TD") return "IRRELEVANT";
                            if (d.tagName == "UL") return "IRRELEVANT";
                        }
                        else return "MAIN";
                    else
                        if (d.meanofWordinLinks_AE <= 9) return "IRRELEVANT";
                        else
                            if (d.wordCount <= 177) return "IRRELEVANT";
                            else return "MAIN";
            }
            else
                return "IRRELEVANT";

            return "IRRELEVANT";
        }

        public static double DecisionHeadline(string headline, string main)
        {
            headline = HTMLMarkerClass.HTML.clear_illegal_characters_for_HTML(headline);
            main = HTMLMarkerClass.HTML.clear_illegal_characters_for_HTML(main);

            string[] _h_array = headline.Split(' ');
            string[] _m_array = main.Split(' ');

            int similar = 0;
            foreach (string h in _h_array)
            {
                foreach (string m in _m_array)
                {
                    if(h==m)
                    {
                        similar++;
                        break;
                    }

                }
            }

            return (double)similar / _h_array.Length;
        }


        //for crawler
        
         public static string DecisionLAYOUT5(HTMLMarkerClass.element d)
        {
        if (d.DensityinHTML_AE <= 0.211828) 
	        if (d.LinkCount <= 0) 
		        if (d.wordCount_AE <= 0) return "irrelevantLayout";
		        else 
			        if (d.DensityinHTML <= 0.078947) return "otherLayouts";
			        else 
				        if (d.wordCount_AE <= 330) return "main";
				        else return "otherLayouts";
	        else 
		        if (d.meanofWordinLinks <= 3.166667) 
			        if (d.wordCount_AE <= 0) 
				        if (d.LinkCount <= 2) return "irrelevantLayout";
				        else 
					        if (d.meanofWordinLinks_AE <= 0.555556) return "menu";
					        else return "irrelevantLayout";
			        else 
				        if (d.meanofWordinLinksAllWords <= 0.459627) 
					        if (d.LinkCount <= 5) 
						        if (d.DensityinHTML_AE <= 0.090115) 
							        if (d.wordCount_AE <= 3) 
								        if (d.DensityinHTML_AE <= 0.006486) 
									        if (d.wordCount <= 64) 
										        if (d.LinkCount <= 2) 
											        if (d.tag_idORclass <= 0) 
												        if (d.LinkCount <= 1) 
													        if (d.wordCount <= 19) return "links";
													        else return "irrelevantLayout";
												        else return "otherLayouts";
											        else 
												        if (d.DensityinHTML_AE <= 0.002063) return "irrelevantLayout";
												        else return "otherLayouts";
										        else 
											        if (d.wordCountinLink <= 5)
                                                    {
												        if (d.tagName == "BODY") return "links";
												        if (d.tagName == "TD") return "links";
												        if (d.tagName == "DIV") 
													        if (d.wordCount <= 16) return "irrelevantLayout";
													        else return "links";
                                                    }
											        else 
												        if (d.tag_idORclass <= 0) 
													        if (d.LinkCount <= 3) 
														        if (d.wordCountinLink <= 6) 
                                                                {
															        if (d.tagName == "BODY") return "links";
															        if (d.tagName == "TD") return "otherLayouts";
															        if (d.tagName == "DIV") return "links";
														        else return "links";
                                                                }
													        else return "otherLayouts";
												        else 
													        if (d.meanofWordinLinks <= 2.318182) return "irrelevantLayout";
													        else return "links";
									        else return "otherLayouts";
								        else return "menu";
							        else 
								        if (d.tag_idORclass <= 0) 
									        if (d.meanofWordinLinksAllWords_AE <= 0.384615) 
										        if (d.wordCountinLink <= 2) 
											        if (d.LinkCount_AE <= 1) 
												        if (d.DensityinHTML_AE <= 0.009922) 
													        if (d.wordCount_AE <= 32) return "links";
													        else return "otherLayouts";
												        else return "otherLayouts";
											        else return "irrelevantLayout";
										        else return "otherLayouts";
									        else 
										        if (d.LinkCount_AE <= 2) 
											        if (d.LinkCount_AE <= 1) return "otherLayouts";
											        else return "irrelevantLayout";
										        else return "menu";
								        else 
									        if (d.meanofWordinLinks_AE <= 1.833333) return "menu";
									        else return "otherLayouts";
						        else 
							        if (d.meanofWordinLinksAllWords_AE <= 0.037037) return "main";
							        else return "otherLayouts";
					        else 
						        if (d.meanofWordinLinksAllWords <= 0.065934) 
							        if (d.wordCountinLink <= 38) return "main";
							        else return "otherLayouts";
						        else 
							        if (d.meanofWordinLinks <= 2.137931) 
								        if (d.tag_idORclass <= 0) return "menu";
								        else 
									        if (d.LinkCount <= 8) return "otherLayouts";
									        else 
										        if (d.LinkCount <= 12) return "links";
										        else return "menu";
							        else 
								        if (d.tag_idORclass <= 0) return "links";
								        else 
									        if (d.meanofWordinLinks_AE <= 1.133333) 
										        if (d.wordCount <= 728) return "links";
										        else return "menu";
									        else return "menu";
				        else 
					        if (d.wordCountinLink <= 5) 
						        if (d.meanofWordinLinksAllWords <= 1.125) 
							        if (d.wordCountinLink <= 3) 
								        if (d.LinkCount_AE <= 1) 
									        if (d.DensityinHTML_AE <= 0.004831) 
										        if (d.wordCount_AE <= 2)
                                                {
											        if (d.tagName == "BODY") return "irrelevantLayout";
											        if (d.tagName == "TD") return "menu";
											        if (d.tagName == "DIV") 
												        if (d.LinkCount_AE <= 0) return "irrelevantLayout";
												        else return "menu";
                                                }
										        else return "otherLayouts";
									        else return "otherLayouts";
								        else 
									        if (d.meanofWordinLinks <= 1.25) return "menu";
									        else 
										        if (d.tag_idORclass <= 0) 
											        if (d.wordCount <= 4) return "otherLayouts";
											        else return "menu";
										        else return "links";
							        else 
								        if (d.DensityinHTML <= 0.00277) return "links";
								        else 
									        if (d.meanofWordinLinksAllWords_AE <= 0.916667) return "menu";
									        else 
										        if (d.meanofWordinLinks_AE <= 1.5) return "otherLayouts";
										        else 
											        if (d.DensityinHTML_AE <= 0.005278) return "links";
											        else return "menu";
						        else 
							        if (d.meanofWordinLinksAllWords_AE <= 1.4) 
								        if (d.meanofWordinLinks_AE <= 1.833333) 
									        if (d.tag_idORclass <= 0) return "menu";
									        else 
										        if (d.DensityinHTML_AE <= 0.001621) return "links";
										        else return "menu";
								        else 
									        if (d.meanofWordinLinksAllWords <= 1.666667) return "menu";
									        else return "irrelevantLayout";
							        else 
								        if (d.meanofWordinLinksAllWords_AE <= 2.25) 
									        if (d.wordCount_AE <= 2) 
										        if (d.DensityinHTML_AE <= 0.002475) 
											        if (d.LinkCount_AE <= 1) 
												        if (d.wordCount_AE <= 1) 
													        if (d.DensityinHTML_AE <= 0.00146) 
														        if (d.DensityinHTML_AE <= 0.00105) 
                                                                {
															        if (d.tagName == "BODY") return "links";
															        if (d.tagName == "TD") return "links";
															        if (d.tagName == "DIV") return "menu";														
                                                                }
                                                                else return "menu";
													        else 
														        if (d.DensityinHTML_AE <= 0.001597) return "links";
														        else 
															        if (d.DensityinHTML_AE <= 0.001797) return "menu";
															        else 
																        if (d.tag_idORclass <= 0) return "links";
																        else return "menu";
												        else 
													        if (d.tag_idORclass <= 0) return "links";
													        else return "menu";
											        else return "menu";
										        else 
											        if (d.tag_idORclass <= 0) return "menu";
											        else 
                                                    {
												        if (d.tagName == "BODY") return "links";
												        if (d.tagName == "TD") return "links";
												        if (d.tagName == "DIV") return "menu";
                                                    }
									        else return "links";
								        else return "menu";
					        else 
						        if (d.meanofWordinLinksAllWords_AE <= 1.285714) 
							        if (d.meanofWordinLinks <= 2.131579) return "menu";
							        else 
								        if (d.meanofWordinLinksAllWords <= 0.705036) 
									        if (d.wordCount <= 14) return "otherLayouts";
									        else 
										        if (d.meanofWordinLinks_AE <= 2.8) return "menu";
										        else return "links";
								        else 
									        if (d.meanofWordinLinks <= 2.689655) return "menu";
									        else 
										        if (d.LinkCount <= 17) 
											        if (d.DensityinHTML_AE <= 0.001385) return "links";
											        else return "menu";
										        else 
											        if (d.LinkCount <= 31) return "links";
											        else return "menu";
						        else 
							        if (d.meanofWordinLinksAllWords_AE <= 6) 
								        if (d.LinkCount <= 3) 
									        if (d.wordCountinLink_AE <= 7) return "links";
									        else return "menu";
								        else return "menu";
							        else return "otherLayouts";
		        else 
			        if (d.meanofWordinLinksAllWords <= 0.571429) 
				        if (d.meanofWordinLinksAllWords <= 0.219512) 
					        if (d.meanofWordinLinks <= 21) 
                            {
						        if (d.tagName == "BODY") return "otherLayouts";
						        if (d.tagName == "TD") 
							        if (d.wordCount_AE <= 20) 
								        if (d.DensityinHTML <= 0.212121) return "otherLayouts";
								        else return "links";
							        else return "links";
						        if (d.tagName == "DIV") 
							        if (d.wordCountinLink <= 9) return "otherLayouts";
							        else 
								        if (d.DensityinHTML_AE <= 0.002237) 
									        if (d.wordCount_AE <= 1) return "menu";
									        else return "otherLayouts";
								        else 
									        if (d.wordCount <= 145) return "otherLayouts";
									        else return "main";
                            }
					        else return "irrelevantLayout";
				        else 
					        if (d.meanofWordinLinks_AE <= 3.75) 
						        if (d.wordCount_AE <= 103) 
							        if (d.meanofWordinLinksAllWords_AE <= 0.404255) return "links";
							        else return "menu";
						        else return "main";
					        else 
						        if (d.LinkCount <= 2) return "otherLayouts";
						        else return "links";
			        else 
				        if (d.meanofWordinLinks <= 4.022222)
                            if (d.wordCount <= 24)
                                if (d.LinkCount_AE <= 0)
                                    if (d.DensityinHTML_AE <= 0.002999)
                                        if (d.tag_idORclass <= 0)
                                            if (d.DensityinHTML <= 0.001789) return "menu";
                                            else return "links";
                                        else
                                            if (d.DensityinHTML_AE <= 0.002035) return "menu";
                                            else return "links";
                                    else
                                        if (d.LinkCount <= 3)
                                            if (d.wordCount <= 11)
                                                if (d.meanofWordinLinksAllWords <= 1.2) return "menu";
                                                else return "irrelevantLayout";
                                            else return "irrelevantLayout";
                                        else
                                            if (d.LinkCount <= 6)
                                                if (d.tag_idORclass <= 0)
                                                    if (d.wordCountinLink <= 15) return "links";
                                                    else return "menu";
                                                else return "menu";
                                            else return "links";
                                else
                                    if (d.meanofWordinLinksAllWords <= 1.021739)
                                        if (d.LinkCount_AE <= 4)
                                        {
                                            if (d.tagName == "BODY") return "otherLayouts";
                                            if (d.tagName == "TD") return "otherLayouts";
                                            if (d.tagName == "DIV")
                                                if (d.wordCount_AE <= 12)
                                                    if (d.DensityinHTML_AE <= 0.015595)
                                                        if (d.meanofWordinLinks_AE <= 3.566667) return "links";
                                                        else return "menu";
                                                    else return "irrelevantLayout";
                                                else
                                                    if (d.tag_idORclass <= 0)
                                                        if (d.wordCount_AE <= 16) return "menu";
                                                        else return "otherLayouts";
                                                    else return "otherLayouts";
                                        }
                                        else
                                            if (d.meanofWordinLinksAllWords_AE <= 0.9) return "menu";
                                            else return "links";
                                    else
                                        if (d.tag_idORclass <= 0)
                                            if (d.meanofWordinLinksAllWords_AE <= 1.4)
                                                if (d.LinkCount_AE <= 3)
                                                    if (d.wordCount_AE <= 4)
                                                        if (d.DensityinHTML_AE <= 0.004378) return "menu";
                                                        else return "links";
                                                    else return "menu";
                                                else return "links";
                                            else return "menu";
                                        else
                                            if (d.meanofWordinLinks <= 3.761905)
                                                if (d.wordCount_AE <= 9) return "links";
                                                else return "menu";
                                            else
                                                if (d.wordCount <= 2) return "menu";
                                                else return "otherLayouts";
                            else
                            {
                                if (d.tagName == "BODY") return "links";
                                if (d.tagName == "TD")
                                    if (d.LinkCount <= 7) return "menu";
                                    else
                                        if (d.meanofWordinLinksAllWords <= 0.775758) return "menu";
                                        else return "links";
                                if (d.tagName == "DIV")
                                    if (d.LinkCount <= 9) return "links";
                                    else
                                        if (d.LinkCount_AE <= 1)
                                            if (d.meanofWordinLinks <= 3.419355)
                                                if (d.meanofWordinLinks <= 3.327273) return "links";
                                                else return "menu";
                                            else return "links";
                                        else
                                            if (d.tag_idORclass <= 0)
                                                if (d.LinkCount <= 14) return "menu";
                                                else return "links";
                                            else return "menu";
                            }
				        else return "links";
        else 
	        if (d.meanofWordinLinksAllWords_AE <= 0.3) return "main";
	        else 
		        if (d.meanofWordinLinks_AE <= 3.307692) return "menu";
		        else 
			        if (d.meanofWordinLinks_AE <= 8.7) 
				        if (d.tag_idORclass <= 0) return "links";
				        else 
					        if (d.LinkCount_AE <= 42) return "links";
					        else return "menu";
			        else return "main";


             return "irrelevantLayout";
        }



    }//class
}//namespace
