﻿
namespace RssReader {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.rbMain = new System.Windows.Forms.RadioButton();
            this.gbToppics = new System.Windows.Forms.GroupBox();
            this.rbEnter = new System.Windows.Forms.RadioButton();
            this.rbGrobal = new System.Windows.Forms.RadioButton();
            this.rbSports = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.favoritetListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbToppics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUrl
            // 
            this.tbUrl.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbUrl.Location = new System.Drawing.Point(88, 26);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(649, 31);
            this.tbUrl.TabIndex = 0;
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(22, 130);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(351, 124);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.SelectedIndexChanged += new System.EventHandler(this.lbRssTitle_SelectedIndexChanged_1);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbBrowser.Location = new System.Drawing.Point(22, 260);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.ScriptErrorsSuppressed = true;
            this.wbBrowser.Size = new System.Drawing.Size(715, 336);
            this.wbBrowser.TabIndex = 3;
            // 
            // rbMain
            // 
            this.rbMain.AutoSize = true;
            this.rbMain.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbMain.Location = new System.Drawing.Point(6, 16);
            this.rbMain.Name = "rbMain";
            this.rbMain.Size = new System.Drawing.Size(50, 20);
            this.rbMain.TabIndex = 4;
            this.rbMain.TabStop = true;
            this.rbMain.Text = "主要";
            this.rbMain.UseVisualStyleBackColor = true;
            this.rbMain.CheckedChanged += new System.EventHandler(this.rbMain_CheckedChanged);
            // 
            // gbToppics
            // 
            this.gbToppics.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gbToppics.Controls.Add(this.rbEnter);
            this.gbToppics.Controls.Add(this.rbGrobal);
            this.gbToppics.Controls.Add(this.rbSports);
            this.gbToppics.Controls.Add(this.rbMain);
            this.gbToppics.Location = new System.Drawing.Point(94, 79);
            this.gbToppics.Name = "gbToppics";
            this.gbToppics.Size = new System.Drawing.Size(279, 45);
            this.gbToppics.TabIndex = 5;
            this.gbToppics.TabStop = false;
            // 
            // rbEnter
            // 
            this.rbEnter.AutoSize = true;
            this.rbEnter.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbEnter.Location = new System.Drawing.Point(200, 16);
            this.rbEnter.Name = "rbEnter";
            this.rbEnter.Size = new System.Drawing.Size(73, 20);
            this.rbEnter.TabIndex = 8;
            this.rbEnter.TabStop = true;
            this.rbEnter.Text = "エンタメ";
            this.rbEnter.UseVisualStyleBackColor = true;
            this.rbEnter.CheckedChanged += new System.EventHandler(this.rbEnter_CheckedChanged);
            // 
            // rbGrobal
            // 
            this.rbGrobal.AutoSize = true;
            this.rbGrobal.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbGrobal.Location = new System.Drawing.Point(62, 16);
            this.rbGrobal.Name = "rbGrobal";
            this.rbGrobal.Size = new System.Drawing.Size(50, 20);
            this.rbGrobal.TabIndex = 6;
            this.rbGrobal.TabStop = true;
            this.rbGrobal.Text = "国際";
            this.rbGrobal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbGrobal.UseVisualStyleBackColor = true;
            this.rbGrobal.CheckedChanged += new System.EventHandler(this.rbGrobal_CheckedChanged);
            // 
            // rbSports
            // 
            this.rbSports.AutoSize = true;
            this.rbSports.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.rbSports.Location = new System.Drawing.Point(120, 16);
            this.rbSports.Name = "rbSports";
            this.rbSports.Size = new System.Drawing.Size(74, 20);
            this.rbSports.TabIndex = 5;
            this.rbSports.TabStop = true;
            this.rbSports.Text = "スポーツ";
            this.rbSports.UseVisualStyleBackColor = true;
            this.rbSports.CheckedChanged += new System.EventHandler(this.rbSports_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SeaShell;
            this.label1.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(1, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "トピックス : ";
            // 
            // favoritetListBox
            // 
            this.favoritetListBox.BackColor = System.Drawing.SystemColors.Info;
            this.favoritetListBox.FormattingEnabled = true;
            this.favoritetListBox.ItemHeight = 12;
            this.favoritetListBox.Location = new System.Drawing.Point(483, 82);
            this.favoritetListBox.Name = "favoritetListBox";
            this.favoritetListBox.Size = new System.Drawing.Size(254, 172);
            this.favoritetListBox.TabIndex = 8;
            this.favoritetListBox.SelectedIndexChanged += new System.EventHandler(this.favoritetListBox_SelectedIndexChanged_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(379, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 58);
            this.button1.TabIndex = 9;
            this.button1.Text = "お気に入り";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SeaShell;
            this.label2.Font = new System.Drawing.Font("HG丸ｺﾞｼｯｸM-PRO", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "URL :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(760, 608);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.favoritetListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbToppics);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.tbUrl);
            this.Name = "Form1";
            this.Text = "RSSリーダー";
            this.gbToppics.ResumeLayout(false);
            this.gbToppics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbBrowser;
        private System.Windows.Forms.RadioButton rbMain;
        private System.Windows.Forms.GroupBox gbToppics;
        private System.Windows.Forms.RadioButton rbEnter;
        private System.Windows.Forms.RadioButton rbGrobal;
        private System.Windows.Forms.RadioButton rbSports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox favoritetListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}

