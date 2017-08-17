namespace TES30
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ObjectPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.scrollview2 = new TES30.Scrollview();
            this.SpriteTab = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.spritePainter1 = new TES30.Controls.SpritePainter();
            this.spriteSelector1 = new TES30.Controls.SpriteSelector();
            this.ConsoleTab = new System.Windows.Forms.TabPage();
            this.console1 = new TES30.Console();
            this.CodeTab = new System.Windows.Forms.TabPage();
            this.codeTree1 = new TES30.CodeTree();
            this.PropertyWindow = new TES30.Controls.Window();
            this.propertyEditor1 = new TES30.Controls.PropertyEditor();
            this.DetailsDisplay = new System.Windows.Forms.Label();
            this.DisplayName = new System.Windows.Forms.Label();
            this.teS_Button3 = new TES30.TES_Button();
            this.blockList1 = new TES30.BlockList();
            this.teS_Button1 = new TES30.TES_Button();
            this.scrollview1 = new TES30.Scrollview();
            this.teS_TabControl1 = new TES30.Controls.TES_TabControl();
            this.InfoTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.teS_textbox3 = new TES30.Controls.TES_textbox();
            this.label4 = new System.Windows.Forms.Label();
            this.teS_textbox4 = new TES30.Controls.TES_textbox();
            this.GameTab = new System.Windows.Forms.TabPage();
            this.teS_Button2 = new TES30.TES_Button();
            this.gameView1 = new TES30.Controls.GameView();
            this.ObjectPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SpriteTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ConsoleTab.SuspendLayout();
            this.CodeTab.SuspendLayout();
            this.codeTree1.SuspendLayout();
            this.PropertyWindow.SuspendLayout();
            this.blockList1.SuspendLayout();
            this.teS_TabControl1.SuspendLayout();
            this.InfoTab.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.GameTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObjectPage
            // 
            this.ObjectPage.BackColor = System.Drawing.Color.Black;
            this.ObjectPage.Controls.Add(this.splitContainer1);
            this.ObjectPage.ForeColor = System.Drawing.Color.White;
            this.ObjectPage.Location = new System.Drawing.Point(4, 25);
            this.ObjectPage.Name = "ObjectPage";
            this.ObjectPage.Padding = new System.Windows.Forms.Padding(3);
            this.ObjectPage.Size = new System.Drawing.Size(1083, 702);
            this.ObjectPage.TabIndex = 6;
            this.ObjectPage.Text = "Object";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.scrollview2);
            this.splitContainer1.Size = new System.Drawing.Size(1077, 696);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.TabIndex = 0;
            // 
            // scrollview2
            // 
            this.scrollview2.AutoScroll = true;
            this.scrollview2.BackColor = System.Drawing.Color.Yellow;
            this.scrollview2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollview2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrollview2.Location = new System.Drawing.Point(0, 0);
            this.scrollview2.Name = "scrollview2";
            this.scrollview2.Size = new System.Drawing.Size(356, 696);
            this.scrollview2.TabIndex = 0;
            this.scrollview2.Text = "scrollview2";
            // 
            // SpriteTab
            // 
            this.SpriteTab.BackColor = System.Drawing.Color.Black;
            this.SpriteTab.Controls.Add(this.splitContainer2);
            this.SpriteTab.ForeColor = System.Drawing.Color.White;
            this.SpriteTab.Location = new System.Drawing.Point(4, 25);
            this.SpriteTab.Name = "SpriteTab";
            this.SpriteTab.Padding = new System.Windows.Forms.Padding(3);
            this.SpriteTab.Size = new System.Drawing.Size(1083, 702);
            this.SpriteTab.TabIndex = 2;
            this.SpriteTab.Text = "Sprite";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.spritePainter1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.spriteSelector1);
            this.splitContainer2.Size = new System.Drawing.Size(1077, 696);
            this.splitContainer2.SplitterDistance = 358;
            this.splitContainer2.TabIndex = 0;
            // 
            // spritePainter1
            // 
            this.spritePainter1.BackColor = System.Drawing.Color.Black;
            this.spritePainter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spritePainter1.Location = new System.Drawing.Point(0, 0);
            this.spritePainter1.Name = "spritePainter1";
            this.spritePainter1.Size = new System.Drawing.Size(358, 696);
            this.spritePainter1.TabIndex = 1;
            // 
            // spriteSelector1
            // 
            this.spriteSelector1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spriteSelector1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spriteSelector1.Location = new System.Drawing.Point(0, 0);
            this.spriteSelector1.Name = "spriteSelector1";
            this.spriteSelector1.Size = new System.Drawing.Size(715, 696);
            this.spriteSelector1.TabIndex = 2;
            this.spriteSelector1.Text = "spriteSelector1";
            // 
            // ConsoleTab
            // 
            this.ConsoleTab.BackColor = System.Drawing.Color.Black;
            this.ConsoleTab.Controls.Add(this.console1);
            this.ConsoleTab.ForeColor = System.Drawing.Color.White;
            this.ConsoleTab.Location = new System.Drawing.Point(4, 25);
            this.ConsoleTab.Name = "ConsoleTab";
            this.ConsoleTab.Padding = new System.Windows.Forms.Padding(3);
            this.ConsoleTab.Size = new System.Drawing.Size(1083, 702);
            this.ConsoleTab.TabIndex = 0;
            this.ConsoleTab.Text = "Console";
            // 
            // console1
            // 
            this.console1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console1.Location = new System.Drawing.Point(3, 3);
            this.console1.Name = "console1";
            this.console1.Page = null;
            this.console1.Size = new System.Drawing.Size(1077, 696);
            this.console1.TabIndex = 1;
            this.console1.Text = "console1";
            // 
            // CodeTab
            // 
            this.CodeTab.BackColor = System.Drawing.Color.Black;
            this.CodeTab.Controls.Add(this.codeTree1);
            this.CodeTab.ForeColor = System.Drawing.Color.White;
            this.CodeTab.Location = new System.Drawing.Point(4, 25);
            this.CodeTab.Name = "CodeTab";
            this.CodeTab.Padding = new System.Windows.Forms.Padding(3);
            this.CodeTab.Size = new System.Drawing.Size(1083, 702);
            this.CodeTab.TabIndex = 1;
            this.CodeTab.Text = "Code";
            // 
            // codeTree1
            // 
            this.codeTree1.AutoScroll = true;
            this.codeTree1.BackColor = System.Drawing.Color.Black;
            this.codeTree1.Controls.Add(this.PropertyWindow);
            this.codeTree1.Controls.Add(this.blockList1);
            this.codeTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeTree1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeTree1.Location = new System.Drawing.Point(3, 3);
            this.codeTree1.Name = "codeTree1";
            this.codeTree1.Padding = new System.Windows.Forms.Padding(10);
            this.codeTree1.Size = new System.Drawing.Size(1077, 696);
            this.codeTree1.TabIndex = 1;
            this.codeTree1.Text = "codeTree1";
            // 
            // PropertyWindow
            // 
            this.PropertyWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyWindow.BackColor = System.Drawing.Color.Yellow;
            this.PropertyWindow.Controls.Add(this.propertyEditor1);
            this.PropertyWindow.Controls.Add(this.teS_Button3);
            this.PropertyWindow.Controls.Add(this.DetailsDisplay);
            this.PropertyWindow.Controls.Add(this.DisplayName);
            this.PropertyWindow.Location = new System.Drawing.Point(50, 50);
            this.PropertyWindow.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.PropertyWindow.Name = "PropertyWindow";
            this.PropertyWindow.Size = new System.Drawing.Size(977, 592);
            this.PropertyWindow.TabIndex = 4;
            this.PropertyWindow.Text = "window1";
            this.PropertyWindow.Visible = false;
            // 
            // propertyEditor1
            // 
            this.propertyEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyEditor1.AutoScroll = true;
            this.propertyEditor1.Details = this.DetailsDisplay;
            this.propertyEditor1.DisplayName = this.DisplayName;
            this.propertyEditor1.ForeColor = System.Drawing.Color.Black;
            this.propertyEditor1.LineHeight = 25;
            this.propertyEditor1.Location = new System.Drawing.Point(270, 343);
            this.propertyEditor1.Margin = new System.Windows.Forms.Padding(37, 15, 37, 15);
            this.propertyEditor1.Name = "propertyEditor1";
            this.propertyEditor1.Size = new System.Drawing.Size(4000, 1110);
            this.propertyEditor1.TabIndex = 3;
            this.propertyEditor1.Text = "propertyEditor1";
            // 
            // DetailsDisplay
            // 
            this.DetailsDisplay.AutoSize = true;
            this.DetailsDisplay.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsDisplay.ForeColor = System.Drawing.Color.DimGray;
            this.DetailsDisplay.Location = new System.Drawing.Point(255, 240);
            this.DetailsDisplay.Margin = new System.Windows.Forms.Padding(62, 0, 62, 0);
            this.DetailsDisplay.Name = "DetailsDisplay";
            this.DetailsDisplay.Size = new System.Drawing.Size(287, 17);
            this.DetailsDisplay.TabIndex = 1;
            this.DetailsDisplay.Text = "The starting block of the flow.";
            // 
            // DisplayName
            // 
            this.DisplayName.AutoSize = true;
            this.DisplayName.Font = new System.Drawing.Font("Courier New", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayName.ForeColor = System.Drawing.Color.Black;
            this.DisplayName.Location = new System.Drawing.Point(255, 111);
            this.DisplayName.Margin = new System.Windows.Forms.Padding(62, 0, 62, 0);
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Size = new System.Drawing.Size(108, 18);
            this.DisplayName.TabIndex = 0;
            this.DisplayName.Text = "StartBlock";
            // 
            // teS_Button3
            // 
            this.teS_Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.teS_Button3.ForeColor = System.Drawing.Color.Black;
            this.teS_Button3.Location = new System.Drawing.Point(4117, 1484);
            this.teS_Button3.Margin = new System.Windows.Forms.Padding(62, 21, 62, 21);
            this.teS_Button3.Name = "teS_Button3";
            this.teS_Button3.Size = new System.Drawing.Size(347, 66);
            this.teS_Button3.TabIndex = 2;
            this.teS_Button3.Text = "Ok";
            this.teS_Button3.Click += new System.EventHandler(this.teS_Button3_Click);
            // 
            // blockList1
            // 
            this.blockList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blockList1.AutoScroll = true;
            this.blockList1.BackColor = System.Drawing.Color.Yellow;
            this.blockList1.Controls.Add(this.teS_Button1);
            this.blockList1.Controls.Add(this.scrollview1);
            this.blockList1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockList1.Location = new System.Drawing.Point(50, 50);
            this.blockList1.Name = "blockList1";
            this.blockList1.Size = new System.Drawing.Size(977, 596);
            this.blockList1.TabIndex = 3;
            this.blockList1.Text = "blockList1";
            this.blockList1.Visible = false;
            this.blockList1.Click += new System.EventHandler(this.blockList1_Click);
            // 
            // teS_Button1
            // 
            this.teS_Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.teS_Button1.Location = new System.Drawing.Point(890, 555);
            this.teS_Button1.Name = "teS_Button1";
            this.teS_Button1.Size = new System.Drawing.Size(74, 27);
            this.teS_Button1.TabIndex = 3;
            this.teS_Button1.Text = "Cancel";
            // 
            // scrollview1
            // 
            this.scrollview1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scrollview1.AutoScroll = true;
            this.scrollview1.BackColor = System.Drawing.Color.Yellow;
            this.scrollview1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrollview1.Location = new System.Drawing.Point(25, 25);
            this.scrollview1.Name = "scrollview1";
            this.scrollview1.Size = new System.Drawing.Size(238, 492);
            this.scrollview1.TabIndex = 2;
            this.scrollview1.Text = "scrollview1";
            // 
            // teS_TabControl1
            // 
            this.teS_TabControl1.Controls.Add(this.ConsoleTab);
            this.teS_TabControl1.Controls.Add(this.CodeTab);
            this.teS_TabControl1.Controls.Add(this.SpriteTab);
            this.teS_TabControl1.Controls.Add(this.ObjectPage);
            this.teS_TabControl1.Controls.Add(this.InfoTab);
            this.teS_TabControl1.Controls.Add(this.GameTab);
            this.teS_TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teS_TabControl1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teS_TabControl1.HotTrack = true;
            this.teS_TabControl1.Location = new System.Drawing.Point(0, 0);
            this.teS_TabControl1.Multiline = true;
            this.teS_TabControl1.Name = "teS_TabControl1";
            this.teS_TabControl1.SelectedIndex = 0;
            this.teS_TabControl1.Size = new System.Drawing.Size(1091, 731);
            this.teS_TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.teS_TabControl1.TabIndex = 1;
            // 
            // InfoTab
            // 
            this.InfoTab.BackColor = System.Drawing.Color.Black;
            this.InfoTab.Controls.Add(this.tableLayoutPanel3);
            this.InfoTab.ForeColor = System.Drawing.Color.White;
            this.InfoTab.Location = new System.Drawing.Point(4, 25);
            this.InfoTab.Name = "InfoTab";
            this.InfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.InfoTab.Size = new System.Drawing.Size(1083, 702);
            this.InfoTab.TabIndex = 8;
            this.InfoTab.Text = "Info";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66667F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.teS_textbox3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.teS_textbox4, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel3.ForeColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1077, 696);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(352, 35);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // teS_textbox3
            // 
            this.teS_textbox3.BackColor = System.Drawing.Color.Yellow;
            this.teS_textbox3.DefaultText = "TES-30 Game";
            this.teS_textbox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teS_textbox3.Location = new System.Drawing.Point(361, 3);
            this.teS_textbox3.Name = "teS_textbox3";
            this.teS_textbox3.Size = new System.Drawing.Size(713, 29);
            this.teS_textbox3.TabIndex = 1;
            this.teS_textbox3.Value = null;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(352, 35);
            this.label4.TabIndex = 2;
            this.label4.Text = "Creator:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // teS_textbox4
            // 
            this.teS_textbox4.BackColor = System.Drawing.Color.Yellow;
            this.teS_textbox4.DefaultText = "Default company";
            this.teS_textbox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.teS_textbox4.Location = new System.Drawing.Point(361, 38);
            this.teS_textbox4.Name = "teS_textbox4";
            this.teS_textbox4.Size = new System.Drawing.Size(713, 29);
            this.teS_textbox4.TabIndex = 3;
            this.teS_textbox4.Value = null;
            // 
            // GameTab
            // 
            this.GameTab.BackColor = System.Drawing.Color.Black;
            this.GameTab.Controls.Add(this.teS_Button2);
            this.GameTab.Controls.Add(this.gameView1);
            this.GameTab.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameTab.ForeColor = System.Drawing.Color.White;
            this.GameTab.Location = new System.Drawing.Point(4, 25);
            this.GameTab.Name = "GameTab";
            this.GameTab.Size = new System.Drawing.Size(1083, 702);
            this.GameTab.TabIndex = 9;
            this.GameTab.Text = "Game";
            // 
            // teS_Button2
            // 
            this.teS_Button2.BackColor = System.Drawing.Color.Yellow;
            this.teS_Button2.ForeColor = System.Drawing.Color.Black;
            this.teS_Button2.Location = new System.Drawing.Point(3, 1);
            this.teS_Button2.Name = "teS_Button2";
            this.teS_Button2.Size = new System.Drawing.Size(75, 23);
            this.teS_Button2.TabIndex = 1;
            this.teS_Button2.Text = "Play";
            this.teS_Button2.Click += new System.EventHandler(this.teS_Button2_Click);
            // 
            // gameView1
            // 
            this.gameView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameView1.Location = new System.Drawing.Point(0, 27);
            this.gameView1.Name = "gameView1";
            this.gameView1.Playing = false;
            this.gameView1.Size = new System.Drawing.Size(1083, 675);
            this.gameView1.TabIndex = 0;
            this.gameView1.Text = "gameView1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1091, 731);
            this.Controls.Add(this.teS_TabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "TES-30";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ObjectPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.SpriteTab.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ConsoleTab.ResumeLayout(false);
            this.CodeTab.ResumeLayout(false);
            this.codeTree1.ResumeLayout(false);
            this.PropertyWindow.ResumeLayout(false);
            this.PropertyWindow.PerformLayout();
            this.blockList1.ResumeLayout(false);
            this.teS_TabControl1.ResumeLayout(false);
            this.InfoTab.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.GameTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage ObjectPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Scrollview scrollview2;
        private System.Windows.Forms.TabPage SpriteTab;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Controls.SpritePainter spritePainter1;
        private Controls.SpriteSelector spriteSelector1;
        private System.Windows.Forms.TabPage ConsoleTab;
        private Console console1;
        private System.Windows.Forms.TabPage CodeTab;
        private CodeTree codeTree1;
        private BlockList blockList1;
        private TES_Button teS_Button1;
        public Scrollview scrollview1;
        private Controls.TES_TabControl teS_TabControl1;
        private System.Windows.Forms.TabPage InfoTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private Controls.TES_textbox teS_textbox3;
        private System.Windows.Forms.Label label4;
        private Controls.TES_textbox teS_textbox4;
        private System.Windows.Forms.TabPage GameTab;
        private Controls.GameView gameView1;
        private TES_Button teS_Button2;
        private Controls.Window PropertyWindow;
        private TES_Button teS_Button3;
        private System.Windows.Forms.Label DetailsDisplay;
        private System.Windows.Forms.Label DisplayName;
        private Controls.PropertyEditor propertyEditor1;
    }
}