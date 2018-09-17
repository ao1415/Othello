namespace Othello
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.groupPlayer01 = new System.Windows.Forms.GroupBox();
			this.buttonExePath01 = new System.Windows.Forms.Button();
			this.textExePath01 = new System.Windows.Forms.TextBox();
			this.groupPlayer02 = new System.Windows.Forms.GroupBox();
			this.buttonExePath02 = new System.Windows.Forms.Button();
			this.textExePath02 = new System.Windows.Forms.TextBox();
			this.groupConfig = new System.Windows.Forms.GroupBox();
			this.checkLogOutput = new System.Windows.Forms.CheckBox();
			this.textLifetime = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.numericBattleCount = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.groupPlayer01Log = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textPlayer01Cerr = new System.Windows.Forms.TextBox();
			this.textPlayer01Cout = new System.Windows.Forms.TextBox();
			this.textPlayer01Cin = new System.Windows.Forms.TextBox();
			this.groupPlayer02Log = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textPlayer02Cerr = new System.Windows.Forms.TextBox();
			this.textPlayer02Cout = new System.Windows.Forms.TextBox();
			this.textPlayer02Cin = new System.Windows.Forms.TextBox();
			this.groupGameLog = new System.Windows.Forms.GroupBox();
			this.buttonStop = new System.Windows.Forms.Button();
			this.buttonStart = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.textGameLog = new System.Windows.Forms.TextBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.groupPlayer01.SuspendLayout();
			this.groupPlayer02.SuspendLayout();
			this.groupConfig.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericBattleCount)).BeginInit();
			this.groupPlayer01Log.SuspendLayout();
			this.groupPlayer02Log.SuspendLayout();
			this.groupGameLog.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupPlayer01
			// 
			this.groupPlayer01.Controls.Add(this.buttonExePath01);
			this.groupPlayer01.Controls.Add(this.textExePath01);
			this.groupPlayer01.Location = new System.Drawing.Point(12, 12);
			this.groupPlayer01.Name = "groupPlayer01";
			this.groupPlayer01.Size = new System.Drawing.Size(926, 49);
			this.groupPlayer01.TabIndex = 0;
			this.groupPlayer01.TabStop = false;
			this.groupPlayer01.Text = "Player01";
			// 
			// buttonExePath01
			// 
			this.buttonExePath01.Location = new System.Drawing.Point(888, 16);
			this.buttonExePath01.Name = "buttonExePath01";
			this.buttonExePath01.Size = new System.Drawing.Size(32, 23);
			this.buttonExePath01.TabIndex = 1;
			this.buttonExePath01.Text = "...";
			this.buttonExePath01.UseVisualStyleBackColor = true;
			this.buttonExePath01.Click += new System.EventHandler(this.buttonExePath01_Click);
			// 
			// textExePath01
			// 
			this.textExePath01.Location = new System.Drawing.Point(6, 18);
			this.textExePath01.Name = "textExePath01";
			this.textExePath01.Size = new System.Drawing.Size(876, 19);
			this.textExePath01.TabIndex = 0;
			// 
			// groupPlayer02
			// 
			this.groupPlayer02.Controls.Add(this.buttonExePath02);
			this.groupPlayer02.Controls.Add(this.textExePath02);
			this.groupPlayer02.Location = new System.Drawing.Point(12, 67);
			this.groupPlayer02.Name = "groupPlayer02";
			this.groupPlayer02.Size = new System.Drawing.Size(926, 49);
			this.groupPlayer02.TabIndex = 1;
			this.groupPlayer02.TabStop = false;
			this.groupPlayer02.Text = "Player02";
			// 
			// buttonExePath02
			// 
			this.buttonExePath02.Location = new System.Drawing.Point(888, 16);
			this.buttonExePath02.Name = "buttonExePath02";
			this.buttonExePath02.Size = new System.Drawing.Size(32, 23);
			this.buttonExePath02.TabIndex = 2;
			this.buttonExePath02.Text = "...";
			this.buttonExePath02.UseVisualStyleBackColor = true;
			this.buttonExePath02.Click += new System.EventHandler(this.buttonExePath02_Click);
			// 
			// textExePath02
			// 
			this.textExePath02.Location = new System.Drawing.Point(6, 18);
			this.textExePath02.Name = "textExePath02";
			this.textExePath02.Size = new System.Drawing.Size(876, 19);
			this.textExePath02.TabIndex = 1;
			// 
			// groupConfig
			// 
			this.groupConfig.Controls.Add(this.checkLogOutput);
			this.groupConfig.Controls.Add(this.textLifetime);
			this.groupConfig.Controls.Add(this.label2);
			this.groupConfig.Controls.Add(this.numericBattleCount);
			this.groupConfig.Controls.Add(this.label1);
			this.groupConfig.Location = new System.Drawing.Point(12, 122);
			this.groupConfig.Name = "groupConfig";
			this.groupConfig.Size = new System.Drawing.Size(926, 75);
			this.groupConfig.TabIndex = 2;
			this.groupConfig.TabStop = false;
			this.groupConfig.Text = "設定";
			// 
			// checkLogOutput
			// 
			this.checkLogOutput.AutoSize = true;
			this.checkLogOutput.Location = new System.Drawing.Point(231, 18);
			this.checkLogOutput.Name = "checkLogOutput";
			this.checkLogOutput.Size = new System.Drawing.Size(66, 16);
			this.checkLogOutput.TabIndex = 5;
			this.checkLogOutput.Text = "ログ出力";
			this.checkLogOutput.UseVisualStyleBackColor = true;
			// 
			// textLifetime
			// 
			this.textLifetime.Location = new System.Drawing.Point(82, 43);
			this.textLifetime.Name = "textLifetime";
			this.textLifetime.Size = new System.Drawing.Size(100, 19);
			this.textLifetime.TabIndex = 3;
			this.textLifetime.Text = "300";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "持ち時間(秒)";
			// 
			// numericBattleCount
			// 
			this.numericBattleCount.Location = new System.Drawing.Point(82, 18);
			this.numericBattleCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericBattleCount.Name = "numericBattleCount";
			this.numericBattleCount.Size = new System.Drawing.Size(100, 19);
			this.numericBattleCount.TabIndex = 1;
			this.numericBattleCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "対戦数";
			// 
			// groupPlayer01Log
			// 
			this.groupPlayer01Log.Controls.Add(this.label5);
			this.groupPlayer01Log.Controls.Add(this.label4);
			this.groupPlayer01Log.Controls.Add(this.label3);
			this.groupPlayer01Log.Controls.Add(this.textPlayer01Cerr);
			this.groupPlayer01Log.Controls.Add(this.textPlayer01Cout);
			this.groupPlayer01Log.Controls.Add(this.textPlayer01Cin);
			this.groupPlayer01Log.Location = new System.Drawing.Point(12, 338);
			this.groupPlayer01Log.Name = "groupPlayer01Log";
			this.groupPlayer01Log.Size = new System.Drawing.Size(460, 234);
			this.groupPlayer01Log.TabIndex = 3;
			this.groupPlayer01Log.TabStop = false;
			this.groupPlayer01Log.Text = "Player01 ログ";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 121);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 12);
			this.label5.TabIndex = 5;
			this.label5.Text = "エラー出力";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(237, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 4;
			this.label4.Text = "標準出力";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = "標準入力";
			// 
			// textPlayer01Cerr
			// 
			this.textPlayer01Cerr.Location = new System.Drawing.Point(8, 136);
			this.textPlayer01Cerr.Multiline = true;
			this.textPlayer01Cerr.Name = "textPlayer01Cerr";
			this.textPlayer01Cerr.ReadOnly = true;
			this.textPlayer01Cerr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textPlayer01Cerr.Size = new System.Drawing.Size(440, 88);
			this.textPlayer01Cerr.TabIndex = 2;
			// 
			// textPlayer01Cout
			// 
			this.textPlayer01Cout.Location = new System.Drawing.Point(231, 30);
			this.textPlayer01Cout.Multiline = true;
			this.textPlayer01Cout.Name = "textPlayer01Cout";
			this.textPlayer01Cout.ReadOnly = true;
			this.textPlayer01Cout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textPlayer01Cout.Size = new System.Drawing.Size(217, 88);
			this.textPlayer01Cout.TabIndex = 1;
			// 
			// textPlayer01Cin
			// 
			this.textPlayer01Cin.Location = new System.Drawing.Point(8, 30);
			this.textPlayer01Cin.Multiline = true;
			this.textPlayer01Cin.Name = "textPlayer01Cin";
			this.textPlayer01Cin.ReadOnly = true;
			this.textPlayer01Cin.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textPlayer01Cin.Size = new System.Drawing.Size(217, 88);
			this.textPlayer01Cin.TabIndex = 0;
			// 
			// groupPlayer02Log
			// 
			this.groupPlayer02Log.Controls.Add(this.label6);
			this.groupPlayer02Log.Controls.Add(this.label7);
			this.groupPlayer02Log.Controls.Add(this.label8);
			this.groupPlayer02Log.Controls.Add(this.textPlayer02Cerr);
			this.groupPlayer02Log.Controls.Add(this.textPlayer02Cout);
			this.groupPlayer02Log.Controls.Add(this.textPlayer02Cin);
			this.groupPlayer02Log.Location = new System.Drawing.Point(478, 338);
			this.groupPlayer02Log.Name = "groupPlayer02Log";
			this.groupPlayer02Log.Size = new System.Drawing.Size(460, 234);
			this.groupPlayer02Log.TabIndex = 4;
			this.groupPlayer02Log.TabStop = false;
			this.groupPlayer02Log.Text = "Player02 ログ";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 121);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 12);
			this.label6.TabIndex = 5;
			this.label6.Text = "エラー出力";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(237, 15);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 12);
			this.label7.TabIndex = 4;
			this.label7.Text = "標準出力";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 15);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 12);
			this.label8.TabIndex = 3;
			this.label8.Text = "標準入力";
			// 
			// textPlayer02Cerr
			// 
			this.textPlayer02Cerr.Location = new System.Drawing.Point(8, 136);
			this.textPlayer02Cerr.Multiline = true;
			this.textPlayer02Cerr.Name = "textPlayer02Cerr";
			this.textPlayer02Cerr.ReadOnly = true;
			this.textPlayer02Cerr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textPlayer02Cerr.Size = new System.Drawing.Size(440, 88);
			this.textPlayer02Cerr.TabIndex = 2;
			// 
			// textPlayer02Cout
			// 
			this.textPlayer02Cout.Location = new System.Drawing.Point(231, 30);
			this.textPlayer02Cout.Multiline = true;
			this.textPlayer02Cout.Name = "textPlayer02Cout";
			this.textPlayer02Cout.ReadOnly = true;
			this.textPlayer02Cout.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textPlayer02Cout.Size = new System.Drawing.Size(217, 88);
			this.textPlayer02Cout.TabIndex = 1;
			// 
			// textPlayer02Cin
			// 
			this.textPlayer02Cin.Location = new System.Drawing.Point(8, 30);
			this.textPlayer02Cin.Multiline = true;
			this.textPlayer02Cin.Name = "textPlayer02Cin";
			this.textPlayer02Cin.ReadOnly = true;
			this.textPlayer02Cin.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textPlayer02Cin.Size = new System.Drawing.Size(217, 88);
			this.textPlayer02Cin.TabIndex = 0;
			// 
			// groupGameLog
			// 
			this.groupGameLog.Controls.Add(this.buttonStop);
			this.groupGameLog.Controls.Add(this.buttonStart);
			this.groupGameLog.Controls.Add(this.label9);
			this.groupGameLog.Controls.Add(this.textGameLog);
			this.groupGameLog.Location = new System.Drawing.Point(12, 203);
			this.groupGameLog.Name = "groupGameLog";
			this.groupGameLog.Size = new System.Drawing.Size(926, 129);
			this.groupGameLog.TabIndex = 5;
			this.groupGameLog.TabStop = false;
			this.groupGameLog.Text = "ゲームコントロール";
			// 
			// buttonStop
			// 
			this.buttonStop.Enabled = false;
			this.buttonStop.Location = new System.Drawing.Point(89, 18);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(75, 23);
			this.buttonStop.TabIndex = 6;
			this.buttonStop.Text = "中止";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(8, 18);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 5;
			this.buttonStart.Text = "対戦開始";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_ClickAsync);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(472, 15);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(53, 12);
			this.label9.TabIndex = 4;
			this.label9.Text = "ゲームログ";
			// 
			// textGameLog
			// 
			this.textGameLog.Location = new System.Drawing.Point(474, 30);
			this.textGameLog.Multiline = true;
			this.textGameLog.Name = "textGameLog";
			this.textGameLog.ReadOnly = true;
			this.textGameLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textGameLog.Size = new System.Drawing.Size(440, 88);
			this.textGameLog.TabIndex = 0;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			this.openFileDialog.Title = "ファイルを選択する";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(946, 583);
			this.Controls.Add(this.groupGameLog);
			this.Controls.Add(this.groupPlayer02Log);
			this.Controls.Add(this.groupPlayer01Log);
			this.Controls.Add(this.groupConfig);
			this.Controls.Add(this.groupPlayer02);
			this.Controls.Add(this.groupPlayer01);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "Othell";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupPlayer01.ResumeLayout(false);
			this.groupPlayer01.PerformLayout();
			this.groupPlayer02.ResumeLayout(false);
			this.groupPlayer02.PerformLayout();
			this.groupConfig.ResumeLayout(false);
			this.groupConfig.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericBattleCount)).EndInit();
			this.groupPlayer01Log.ResumeLayout(false);
			this.groupPlayer01Log.PerformLayout();
			this.groupPlayer02Log.ResumeLayout(false);
			this.groupPlayer02Log.PerformLayout();
			this.groupGameLog.ResumeLayout(false);
			this.groupGameLog.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupPlayer01;
		private System.Windows.Forms.Button buttonExePath01;
		private System.Windows.Forms.TextBox textExePath01;
		private System.Windows.Forms.GroupBox groupPlayer02;
		private System.Windows.Forms.Button buttonExePath02;
		private System.Windows.Forms.TextBox textExePath02;
		private System.Windows.Forms.GroupBox groupConfig;
		private System.Windows.Forms.TextBox textLifetime;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numericBattleCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupPlayer01Log;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textPlayer01Cerr;
		private System.Windows.Forms.TextBox textPlayer01Cout;
		private System.Windows.Forms.TextBox textPlayer01Cin;
		private System.Windows.Forms.CheckBox checkLogOutput;
		private System.Windows.Forms.GroupBox groupPlayer02Log;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textPlayer02Cerr;
		private System.Windows.Forms.TextBox textPlayer02Cout;
		private System.Windows.Forms.TextBox textPlayer02Cin;
		private System.Windows.Forms.GroupBox groupGameLog;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button buttonStop;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		public System.Windows.Forms.TextBox textGameLog;
	}
}

