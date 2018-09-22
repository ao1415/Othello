namespace Othello
{
	partial class ReplayForm
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.buttonFirst = new System.Windows.Forms.Button();
			this.buttonBack = new System.Windows.Forms.Button();
			this.buttonSop = new System.Windows.Forms.Button();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonLast = new System.Windows.Forms.Button();
			this.comboBoxSpeed = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(576, 386);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// buttonFirst
			// 
			this.buttonFirst.Location = new System.Drawing.Point(12, 404);
			this.buttonFirst.Name = "buttonFirst";
			this.buttonFirst.Size = new System.Drawing.Size(32, 23);
			this.buttonFirst.TabIndex = 1;
			this.buttonFirst.Text = "<<";
			this.buttonFirst.UseVisualStyleBackColor = true;
			this.buttonFirst.Click += new System.EventHandler(this.buttonFirst_Click);
			// 
			// buttonBack
			// 
			this.buttonBack.Location = new System.Drawing.Point(50, 404);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(48, 23);
			this.buttonBack.TabIndex = 2;
			this.buttonBack.Text = "<";
			this.buttonBack.UseVisualStyleBackColor = true;
			this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
			// 
			// buttonSop
			// 
			this.buttonSop.Enabled = false;
			this.buttonSop.Location = new System.Drawing.Point(104, 404);
			this.buttonSop.Name = "buttonSop";
			this.buttonSop.Size = new System.Drawing.Size(48, 23);
			this.buttonSop.TabIndex = 3;
			this.buttonSop.Text = "■";
			this.buttonSop.UseVisualStyleBackColor = true;
			this.buttonSop.Click += new System.EventHandler(this.buttonSop_Click);
			// 
			// buttonNext
			// 
			this.buttonNext.Location = new System.Drawing.Point(158, 404);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(48, 23);
			this.buttonNext.TabIndex = 4;
			this.buttonNext.Text = ">";
			this.buttonNext.UseVisualStyleBackColor = true;
			this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
			// 
			// buttonLast
			// 
			this.buttonLast.Location = new System.Drawing.Point(212, 404);
			this.buttonLast.Name = "buttonLast";
			this.buttonLast.Size = new System.Drawing.Size(32, 23);
			this.buttonLast.TabIndex = 5;
			this.buttonLast.Text = ">>";
			this.buttonLast.UseVisualStyleBackColor = true;
			this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
			// 
			// comboBoxSpeed
			// 
			this.comboBoxSpeed.Enabled = false;
			this.comboBoxSpeed.FormattingEnabled = true;
			this.comboBoxSpeed.Items.AddRange(new object[] {
            "普通",
            "高速"});
			this.comboBoxSpeed.Location = new System.Drawing.Point(515, 406);
			this.comboBoxSpeed.Name = "comboBoxSpeed";
			this.comboBoxSpeed.Size = new System.Drawing.Size(73, 20);
			this.comboBoxSpeed.TabIndex = 6;
			this.comboBoxSpeed.Text = "普通";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(456, 409);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 7;
			this.label1.Text = "再生速度";
			// 
			// ReplayForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 436);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxSpeed);
			this.Controls.Add(this.buttonLast);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.buttonSop);
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.buttonFirst);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ReplayForm";
			this.Text = "ReplayForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReplayForm_FormClosing);
			this.Load += new System.EventHandler(this.ReplayForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button buttonFirst;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.Button buttonSop;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonLast;
		private System.Windows.Forms.ComboBox comboBoxSpeed;
		private System.Windows.Forms.Label label1;
	}
}