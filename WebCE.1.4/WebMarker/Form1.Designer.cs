namespace WebMarker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MyPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DOMtreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.linksRelatedWithArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linksRelatedWithArticleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.linksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ınformationAboutArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainofArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryofArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commentsofArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsofArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyrightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAVEFILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.lbl_dENae = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.TXT_No = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LBL_Time = new System.Windows.Forms.Label();
            this.BTN_Parse = new System.Windows.Forms.Button();
            this.TXT_FileName = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listBox_Information = new System.Windows.Forms.ListBox();
            this.MyPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyPanel
            // 
            this.MyPanel.Controls.Add(this.panel2);
            this.MyPanel.Controls.Add(this.panel1);
            this.MyPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MyPanel.Location = new System.Drawing.Point(0, 0);
            this.MyPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MyPanel.Name = "MyPanel";
            this.MyPanel.Size = new System.Drawing.Size(536, 550);
            this.MyPanel.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DOMtreeView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 193);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 357);
            this.panel2.TabIndex = 7;
            // 
            // DOMtreeView
            // 
            this.DOMtreeView.ContextMenuStrip = this.contextMenuStrip1;
            this.DOMtreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DOMtreeView.Location = new System.Drawing.Point(0, 0);
            this.DOMtreeView.Margin = new System.Windows.Forms.Padding(4);
            this.DOMtreeView.Name = "DOMtreeView";
            this.DOMtreeView.Size = new System.Drawing.Size(536, 357);
            this.DOMtreeView.TabIndex = 6;
            this.DOMtreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.DOMtreeView_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bannerToolStripMenuItem,
            this.toolStripMenuItem2,
            this.linksRelatedWithArticleToolStripMenuItem,
            this.linksRelatedWithArticleToolStripMenuItem1,
            this.linksToolStripMenuItem,
            this.headLineToolStripMenuItem,
            this.ınformationAboutArticleToolStripMenuItem,
            this.mainofArticleToolStripMenuItem,
            this.summaryofArticleToolStripMenuItem,
            this.commentsofArticleToolStripMenuItem,
            this.tagsofArticleToolStripMenuItem,
            this.copyrightToolStripMenuItem,
            this.sAVEFILEToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(205, 290);
            this.contextMenuStrip1.Tag = "";
            // 
            // bannerToolStripMenuItem
            // 
            this.bannerToolStripMenuItem.Name = "bannerToolStripMenuItem";
            this.bannerToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.bannerToolStripMenuItem.Text = "Banner";
            this.bannerToolStripMenuItem.Click += new System.EventHandler(this.bannerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(204, 22);
            this.toolStripMenuItem2.Text = "Menu";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // linksRelatedWithArticleToolStripMenuItem
            // 
            this.linksRelatedWithArticleToolStripMenuItem.Name = "linksRelatedWithArticleToolStripMenuItem";
            this.linksRelatedWithArticleToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.linksRelatedWithArticleToolStripMenuItem.Text = "Links";
            this.linksRelatedWithArticleToolStripMenuItem.Click += new System.EventHandler(this.linksRelatedWithArticleToolStripMenuItem_Click);
            // 
            // linksRelatedWithArticleToolStripMenuItem1
            // 
            this.linksRelatedWithArticleToolStripMenuItem1.Name = "linksRelatedWithArticleToolStripMenuItem1";
            this.linksRelatedWithArticleToolStripMenuItem1.Size = new System.Drawing.Size(204, 22);
            this.linksRelatedWithArticleToolStripMenuItem1.Text = "LinksRelatedWithArticle";
            this.linksRelatedWithArticleToolStripMenuItem1.Click += new System.EventHandler(this.linksRelatedWithArticleToolStripMenuItem1_Click);
            // 
            // linksToolStripMenuItem
            // 
            this.linksToolStripMenuItem.Name = "linksToolStripMenuItem";
            this.linksToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.linksToolStripMenuItem.Text = "Advertisements";
            this.linksToolStripMenuItem.Click += new System.EventHandler(this.linksToolStripMenuItem_Click);
            // 
            // headLineToolStripMenuItem
            // 
            this.headLineToolStripMenuItem.Name = "headLineToolStripMenuItem";
            this.headLineToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.headLineToolStripMenuItem.Text = "HeadLine";
            this.headLineToolStripMenuItem.Click += new System.EventHandler(this.headLineToolStripMenuItem_Click);
            // 
            // ınformationAboutArticleToolStripMenuItem
            // 
            this.ınformationAboutArticleToolStripMenuItem.Name = "ınformationAboutArticleToolStripMenuItem";
            this.ınformationAboutArticleToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.ınformationAboutArticleToolStripMenuItem.Text = "InformationAboutArticle";
            this.ınformationAboutArticleToolStripMenuItem.Click += new System.EventHandler(this.ınformationAboutArticleToolStripMenuItem_Click);
            // 
            // mainofArticleToolStripMenuItem
            // 
            this.mainofArticleToolStripMenuItem.Name = "mainofArticleToolStripMenuItem";
            this.mainofArticleToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.mainofArticleToolStripMenuItem.Text = "MainofArticle";
            this.mainofArticleToolStripMenuItem.Click += new System.EventHandler(this.mainofArticleToolStripMenuItem_Click);
            // 
            // summaryofArticleToolStripMenuItem
            // 
            this.summaryofArticleToolStripMenuItem.Name = "summaryofArticleToolStripMenuItem";
            this.summaryofArticleToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.summaryofArticleToolStripMenuItem.Text = "SummaryofArticle";
            this.summaryofArticleToolStripMenuItem.Click += new System.EventHandler(this.summaryofArticleToolStripMenuItem_Click);
            // 
            // commentsofArticleToolStripMenuItem
            // 
            this.commentsofArticleToolStripMenuItem.Name = "commentsofArticleToolStripMenuItem";
            this.commentsofArticleToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.commentsofArticleToolStripMenuItem.Text = "CommentsofArticle";
            this.commentsofArticleToolStripMenuItem.Click += new System.EventHandler(this.commentsofArticleToolStripMenuItem_Click);
            // 
            // tagsofArticleToolStripMenuItem
            // 
            this.tagsofArticleToolStripMenuItem.Name = "tagsofArticleToolStripMenuItem";
            this.tagsofArticleToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.tagsofArticleToolStripMenuItem.Text = "TagsofArticle";
            this.tagsofArticleToolStripMenuItem.Click += new System.EventHandler(this.tagsofArticleToolStripMenuItem_Click);
            // 
            // copyrightToolStripMenuItem
            // 
            this.copyrightToolStripMenuItem.Name = "copyrightToolStripMenuItem";
            this.copyrightToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.copyrightToolStripMenuItem.Text = "Copyright";
            this.copyrightToolStripMenuItem.Click += new System.EventHandler(this.copyrightToolStripMenuItem_Click);
            // 
            // sAVEFILEToolStripMenuItem
            // 
            this.sAVEFILEToolStripMenuItem.Name = "sAVEFILEToolStripMenuItem";
            this.sAVEFILEToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.sAVEFILEToolStripMenuItem.Text = "SAVE FILE";
            this.sAVEFILEToolStripMenuItem.Click += new System.EventHandler(this.sAVEFILEToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button12);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.lbl_dENae);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.TXT_No);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.LBL_Time);
            this.panel1.Controls.Add(this.BTN_Parse);
            this.panel1.Controls.Add(this.TXT_FileName);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(536, 193);
            this.panel1.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(290, 203);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 27);
            this.button4.TabIndex = 21;
            this.button4.Text = "2";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_2);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(3, 269);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(353, 27);
            this.button12.TabIndex = 20;
            this.button12.Text = "Calculate Time Efficiency for All Web Pages";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(3, 236);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(353, 27);
            this.button11.TabIndex = 19;
            this.button11.Text = "Prepeare ARFF File: Main, Headline and Other inf.";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(4, 151);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(353, 34);
            this.button9.TabIndex = 17;
            this.button9.Text = "SET Parser for extracted rules";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(4, 113);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(353, 32);
            this.button8.TabIndex = 16;
            this.button8.Text = "Preapeare XML File for a given web page";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 203);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(353, 27);
            this.button7.TabIndex = 15;
            this.button7.Text = "Prepeare ARFF File: Relevant Layout";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lbl_dENae
            // 
            this.lbl_dENae.AutoSize = true;
            this.lbl_dENae.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_dENae.ForeColor = System.Drawing.Color.DarkRed;
            this.lbl_dENae.Location = new System.Drawing.Point(84, 54);
            this.lbl_dENae.Name = "lbl_dENae";
            this.lbl_dENae.Size = new System.Drawing.Size(20, 18);
            this.lbl_dENae.TabIndex = 11;
            this.lbl_dENae.Text = "...";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(35, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(17, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "L";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // TXT_No
            // 
            this.TXT_No.Location = new System.Drawing.Point(3, 4);
            this.TXT_No.Name = "TXT_No";
            this.TXT_No.Size = new System.Drawing.Size(34, 26);
            this.TXT_No.TabIndex = 9;
            this.TXT_No.TextChanged += new System.EventHandler(this.TXT_No_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(43, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 36);
            this.button2.TabIndex = 8;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 36);
            this.button1.TabIndex = 7;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LBL_Time
            // 
            this.LBL_Time.AutoSize = true;
            this.LBL_Time.Location = new System.Drawing.Point(84, 36);
            this.LBL_Time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Time.Name = "LBL_Time";
            this.LBL_Time.Size = new System.Drawing.Size(20, 18);
            this.LBL_Time.TabIndex = 5;
            this.LBL_Time.Text = "...";
            // 
            // BTN_Parse
            // 
            this.BTN_Parse.Location = new System.Drawing.Point(4, 76);
            this.BTN_Parse.Margin = new System.Windows.Forms.Padding(4);
            this.BTN_Parse.Name = "BTN_Parse";
            this.BTN_Parse.Size = new System.Drawing.Size(353, 32);
            this.BTN_Parse.TabIndex = 0;
            this.BTN_Parse.Text = "Genearate DOM tree for a given web page";
            this.BTN_Parse.UseVisualStyleBackColor = true;
            this.BTN_Parse.Click += new System.EventHandler(this.BTN_Parse_Click);
            // 
            // TXT_FileName
            // 
            this.TXT_FileName.Location = new System.Drawing.Point(59, 6);
            this.TXT_FileName.Margin = new System.Windows.Forms.Padding(4);
            this.TXT_FileName.Name = "TXT_FileName";
            this.TXT_FileName.Size = new System.Drawing.Size(469, 26);
            this.TXT_FileName.TabIndex = 3;
            this.TXT_FileName.Text = "0acd5213-35e1-4039-adb5-6c7611911b9e.html";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(536, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(513, 550);
            this.panel3.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.webBrowser1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(513, 304);
            this.panel5.TabIndex = 9;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(513, 304);
            this.webBrowser1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.listBox_Information);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 304);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(513, 246);
            this.panel4.TabIndex = 8;
            // 
            // listBox_Information
            // 
            this.listBox_Information.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Information.FormattingEnabled = true;
            this.listBox_Information.ItemHeight = 18;
            this.listBox_Information.Location = new System.Drawing.Point(0, 0);
            this.listBox_Information.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_Information.Name = "listBox_Information";
            this.listBox_Information.Size = new System.Drawing.Size(513, 246);
            this.listBox_Information.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 550);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.MyPanel);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "WebToXML";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MyPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MyPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_Parse;
        private System.Windows.Forms.TextBox TXT_FileName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView DOMtreeView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox listBox_Information;
        private System.Windows.Forms.Label LBL_Time;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem linksRelatedWithArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainofArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summaryofArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commentsofArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagsofArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAVEFILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bannerToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem linksRelatedWithArticleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyrightToolStripMenuItem;
        private System.Windows.Forms.TextBox TXT_No;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem ınformationAboutArticleToolStripMenuItem;
        private System.Windows.Forms.Label lbl_dENae;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button4;
    }
}

