
namespace CalendarApp {
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btDayCalc = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.dtOneYear = new System.Windows.Forms.Button();
            this.dt = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dtTenyear = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(34, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "日付：";
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtpDate.Location = new System.Drawing.Point(126, 38);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(190, 31);
            this.dtpDate.TabIndex = 1;
            // 
            // btDayCalc
            // 
            this.btDayCalc.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btDayCalc.Location = new System.Drawing.Point(62, 95);
            this.btDayCalc.Name = "btDayCalc";
            this.btDayCalc.Size = new System.Drawing.Size(120, 43);
            this.btDayCalc.TabIndex = 2;
            this.btDayCalc.Text = "日数計算";
            this.btDayCalc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btDayCalc.UseVisualStyleBackColor = true;
            this.btDayCalc.Click += new System.EventHandler(this.btDayCalc_Click);
            // 
            // tbMessage
            // 
            this.tbMessage.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbMessage.Location = new System.Drawing.Point(428, 56);
            this.tbMessage.Multiline = true;
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(261, 184);
            this.tbMessage.TabIndex = 3;
            // 
            // dtOneYear
            // 
            this.dtOneYear.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtOneYear.Location = new System.Drawing.Point(62, 178);
            this.dtOneYear.Name = "dtOneYear";
            this.dtOneYear.Size = new System.Drawing.Size(102, 43);
            this.dtOneYear.TabIndex = 4;
            this.dtOneYear.Text = "－年";
            this.dtOneYear.UseVisualStyleBackColor = true;
            this.dtOneYear.Click += new System.EventHandler(this.dtOneYear_Click);
            // 
            // dt
            // 
            this.dt.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dt.Location = new System.Drawing.Point(62, 237);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(102, 45);
            this.dt.TabIndex = 5;
            this.dt.Text = "－月";
            this.dt.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(62, 303);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 42);
            this.button3.TabIndex = 6;
            this.button3.Text = "－日";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dtTenyear
            // 
            this.dtTenyear.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dtTenyear.Location = new System.Drawing.Point(218, 177);
            this.dtTenyear.Name = "dtTenyear";
            this.dtTenyear.Size = new System.Drawing.Size(98, 45);
            this.dtTenyear.TabIndex = 7;
            this.dtTenyear.Text = "＋年";
            this.dtTenyear.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(218, 237);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 43);
            this.button5.TabIndex = 8;
            this.button5.Text = "＋月";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(218, 300);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 45);
            this.button6.TabIndex = 9;
            this.button6.Text = "＋日";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 450);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dtTenyear);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dt);
            this.Controls.Add(this.dtOneYear);
            this.Controls.Add(this.tbMessage);
            this.Controls.Add(this.btDayCalc);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "カレンダーアプリ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btDayCalc;
        private System.Windows.Forms.TextBox tbMessage;
        private System.Windows.Forms.Button dtOneYear;
        private System.Windows.Forms.Button dt;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button dtTenyear;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

