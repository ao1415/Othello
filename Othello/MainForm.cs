using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
	public partial class MainForm : Form
	{
		private CancellationTokenSource _tokenSource = null;

		public MainForm()
		{
			InitializeComponent();
		}

		private void buttonExePath01_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				textExePath01.Text = openFileDialog.FileName;
			}
		}

		private void buttonExePath02_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				textExePath02.Text = openFileDialog.FileName;
			}
		}

		private async void buttonStart_ClickAsync(object sender, EventArgs e)
		{
			buttonStart.Enabled = false;
			buttonStop.Enabled = true;

			textExePath01.Enabled = false;
			textExePath02.Enabled = false;
			buttonExePath01.Enabled = false;
			buttonExePath02.Enabled = false;

			numericBattleCount.Enabled = false;
			textLifetime.Enabled = false;
			checkLogOutput.Enabled = false;

			textPlayer01Cin.Text = string.Empty;
			textPlayer01Cout.Text = string.Empty;
			textPlayer01Cerr.Text = string.Empty;

			textPlayer02Cin.Text = string.Empty;
			textPlayer02Cout.Text = string.Empty;
			textPlayer02Cerr.Text = string.Empty;

			//非同期で起動する

			decimal battleCount = numericBattleCount.Value;

			textGameLog.Text = string.Empty;

			if (int.TryParse(textLifetime.Text, out int lifeTime))
			{
				string exePath01 = textExePath01.Text;
				string exePath02 = textExePath02.Text;

				bool log = checkLogOutput.Checked;

				textGameLog.Text += "ゲーム開始" + Environment.NewLine;

				if (_tokenSource == null) _tokenSource = new CancellationTokenSource();
				var token = _tokenSource.Token;

				for (int i = 0; i < battleCount; i++)
				{
					PlayerProcess player01 = new PlayerProcess();
					PlayerProcess player02 = new PlayerProcess();
					//偶奇回数目の対戦で白黒を入れ替える
					if (i % 2 == 0)
					{
						player01.startInfo = new ProcessStartInfo(exePath01);
						player01.cin = textPlayer01Cin;
						player01.cout = textPlayer01Cout;
						player01.cerr = textPlayer01Cerr;

						player02.startInfo = new ProcessStartInfo(exePath02);
						player02.cin = textPlayer02Cin;
						player02.cout = textPlayer02Cout;
						player02.cerr = textPlayer02Cerr;
					}
					else
					{
						player02.startInfo = new ProcessStartInfo(exePath01);
						player02.cin = textPlayer01Cin;
						player02.cout = textPlayer01Cout;
						player02.cerr = textPlayer01Cerr;

						player01.startInfo = new ProcessStartInfo(exePath02);
						player01.cin = textPlayer02Cin;
						player01.cout = textPlayer02Cout;
						player01.cerr = textPlayer02Cerr;
					}

					Engine engine = new Engine(player01, player02, lifeTime, log, this);

					string result = await engine.GameTaskAsync(token);

					textGameLog.Text += result + Environment.NewLine;
				}
			}
			else
			{
				textGameLog.Text = "持ち時間の値が異常です";
			}

			//実行完了後
			buttonStart.Enabled = true;
			buttonStop.Enabled = false;

			textExePath01.Enabled = true;
			textExePath02.Enabled = true;
			buttonExePath01.Enabled = true;
			buttonExePath02.Enabled = true;

			numericBattleCount.Enabled = true;
			textLifetime.Enabled = true;
			checkLogOutput.Enabled = true;
		}

		private void buttonStop_Click(object sender, EventArgs e)
		{
			buttonStart.Enabled = true;
			buttonStop.Enabled = false;

			textExePath01.Enabled = true;
			textExePath02.Enabled = true;
			buttonExePath01.Enabled = true;
			buttonExePath02.Enabled = true;

			numericBattleCount.Enabled = true;
			textLifetime.Enabled = true;
			checkLogOutput.Enabled = true;

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			textExePath01.Text = Properties.Settings.Default.Player01;
			textExePath02.Text = Properties.Settings.Default.Player02;

			numericBattleCount.Value = Properties.Settings.Default.BattleCount;
			textLifetime.Text = Properties.Settings.Default.Lifetime.ToString();

			checkLogOutput.Checked = Properties.Settings.Default.Log;

			Directory.CreateDirectory(Config.LogDirectory);

		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Player01 = textExePath01.Text;
			Properties.Settings.Default.Player02 = textExePath02.Text;

			Properties.Settings.Default.BattleCount = numericBattleCount.Value;

			if (int.TryParse(textLifetime.Text, out int lifetime))
			{
				Properties.Settings.Default.Lifetime = lifetime;
			}

			Properties.Settings.Default.Log = checkLogOutput.Checked;

			Properties.Settings.Default.Save();

		}

	}
}
