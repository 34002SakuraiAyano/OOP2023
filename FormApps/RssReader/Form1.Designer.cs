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
            this.btGet = new System.Windows.Forms.Button();
            this.lbRssTitle = new System.Windows.Forms.ListBox();
            this.wbBrowser = new System.Windows.Forms.WebBrowser();
            this.rbMain = new System.Windows.Forms.RadioButton();
            this.gbToppics = new System.Windows.Forms.GroupBox();
            this.rbEnter = new System.Windows.Forms.RadioButton();
            this.rbGrobal = new System.Windows.Forms.RadioButton();
            this.rbSports = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gbToppics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUrl
            // 
            this.tbUrl.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbUrl.Location = new System.Drawing.Point(22, 20);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(703, 31);
            this.tbUrl.TabIndex = 0;
            // 
            // btGet
            // 
            this.btGet.Location = new System.Drawing.Point(774, 23);
            this.btGet.Name = "btGet";
            this.btGet.Size = new System.Drawing.Size(58, 28);
            this.btGet.TabIndex = 1;
            this.btGet.Text = "取得";
            this.btGet.UseVisualStyleBackColor = true;
            this.btGet.Click += new System.EventHandler(this.btGet_Click);
            // 
            // lbRssTitle
            // 
            this.lbRssTitle.FormattingEnabled = true;
            this.lbRssTitle.ItemHeight = 12;
            this.lbRssTitle.Location = new System.Drawing.Point(22, 57);
            this.lbRssTitle.Name = "lbRssTitle";
            this.lbRssTitle.Size = new System.Drawing.Size(810, 136);
            this.lbRssTitle.TabIndex = 2;
            this.lbRssTitle.SelectedIndexChanged += new System.EventHandler(this.lbRssTitle_SelectedIndexChanged_1);
            // 
            // wbBrowser
            // 
            this.wbBrowser.Location = new System.Drawing.Point(243, 211);
            this.wbBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBrowser.Name = "wbBrowser";
            this.wbBrowser.ScriptErrorsSuppressed = true;
            this.wbBrowser.Size = new System.Drawing.Size(589, 479);
            this.wbBrowser.TabIndex = 3;
            // 
            // rbMain
            // 
            this.rbMain.AutoSize = true;
            this.rbMain.Location = new System.Drawing.Point(23, 28);
            this.rbMain.Name = "rbMain";
            this.rbMain.Size = new System.Drawing.Size(47, 16);
            this.rbMain.TabIndex = 4;
            this.rbMain.TabStop = true;
            this.rbMain.Text = "主要";
            this.rbMain.UseVisualStyleBackColor = true;
            // 
            // gbToppics
            // 
            this.gbToppics.Controls.Add(this.rbEnter);
            this.gbToppics.Controls.Add(this.rbGrobal);
            this.gbToppics.Controls.Add(this.rbSports);
            this.gbToppics.Controls.Add(this.rbMain);
            this.gbToppics.Location = new System.Drawing.Point(22, 244);
            this.gbToppics.Name = "gbToppics";
            this.gbToppics.Size = new System.Drawing.Size(111, 182);
            this.gbToppics.TabIndex = 5;
            this.gbToppics.TabStop = false;
            // 
            // rbEnter
            // 
            this.rbEnter.AutoSize = true;
            this.rbEnter.Location = new System.Drawing.Point(23, 140);
            this.rbEnter.Name = "rbEnter";
            this.rbEnter.Size = new System.Drawing.Size(57, 16);
            this.rbEnter.TabIndex = 8;
            this.rbEnter.TabStop = true;
            this.rbEnter.Text = "エンタメ";
            this.rbEnter.UseVisualStyleBackColor = true;
            // 
            // rbGrobal
            // 
            this.rbGrobal.AutoSize = true;
            this.rbGrobal.Location = new System.Drawing.Point(23, 69);
            this.rbGrobal.Name = "rbGrobal";
            this.rbGrobal.Size = new System.Drawing.Size(47, 16);
            this.rbGrobal.TabIndex = 6;
            this.rbGrobal.TabStop = true;
            this.rbGrobal.Text = "国際";
            this.rbGrobal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbGrobal.UseVisualStyleBackColor = true;
            // 
            // rbSports
            // 
            this.rbSports.AutoSize = true;
            this.rbSports.Location = new System.Drawing.Point(23, 107);
            this.rbSports.Name = "rbSports";
            this.rbSports.Size = new System.Drawing.Size(61, 16);
            this.rbSports.TabIndex = 5;
            this.rbSports.TabStop = true;
            this.rbSports.Text = "スポーツ";
            this.rbSports.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("BIZ UDPゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 220);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "トピックス:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 779);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbToppics);
            this.Controls.Add(this.wbBrowser);
            this.Controls.Add(this.lbRssTitle);
            this.Controls.Add(this.btGet);
            this.Controls.Add(this.tbUrl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbToppics.ResumeLayout(false);
            this.gbToppics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Button btGet;
        private System.Windows.Forms.ListBox lbRssTitle;
        private System.Windows.Forms.WebBrowser wbBrowser;
        private System.Windows.Forms.RadioButton rbMain;
        private System.Windows.Forms.GroupBox gbToppics;
        private System.Windows.Forms.RadioButton rbEnter;
        private System.Windows.Forms.RadioButton rbGrobal;
        private System.Windows.Forms.RadioButton rbSports;
        private System.Windows.Forms.Label label1;
    }
}
