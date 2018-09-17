using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
	class Engine
	{

		/// <summary>初期持ち時間</summary>
		private readonly int lifeTime;
		/// <summary>ログファイル出力フラグ</summary>
		private readonly bool log;

		private MainForm mainForm;

		/// <summary>プロセス管理</summary>
		private PlayerProcess player01 = new PlayerProcess();
		private PlayerProcess player02 = new PlayerProcess();

		/// <summary>リプレイ用のログ</summary>
		private string replayLog = string.Empty;

		public Engine(PlayerProcess player01, PlayerProcess player02, int lifeTime, bool log, MainForm mainForm)
		{
			this.player01 = player01;
			this.player02 = player02;

			this.lifeTime = lifeTime;
			this.log = log;

			this.mainForm = mainForm;

		}

		public async Task<string> GameTaskAsync(CancellationToken token)
		{

			Init();

			string size = Config.Size.ToString();
			string time = (lifeTime * 1000).ToString();

			bool check = true;

			check &= InitProcess();

			player01.name = await ReadlineAsync(player01);
			player02.name = await ReadlineAsync(player02);

			check &= CheckPlayerName();

			if (check)
			{
				Writeline(player01, size);
				Writeline(player01, time);
				Writeline(player01, Config.Black.ToString());

				Writeline(player02, size);
				Writeline(player02, time);
				Writeline(player02, Config.White.ToString());

				while (true)
				{
					string command = await player01.process.StandardOutput.ReadLineAsync();

					break;
				}

				FileWrite();
			}

			Close();
			
			return "result";
		}

		private void Init()
		{
		}

		private bool InitProcess()
		{
			player01.startInfo.UseShellExecute = false;
			player01.startInfo.RedirectStandardInput = true;
			player01.startInfo.RedirectStandardOutput = true;
			player01.startInfo.RedirectStandardError = true;

			player02.startInfo.UseShellExecute = false;
			player02.startInfo.RedirectStandardInput = true;
			player02.startInfo.RedirectStandardOutput = true;
			player02.startInfo.RedirectStandardError = true;

			try
			{
				player01.process = Process.Start(player01.startInfo);
			}
			catch (Exception e)
			{
				LogWriteLine(mainForm.textGameLog, "起動に失敗しました:" + e.ToString());
				return false;
			}

			try
			{
				player02.process = Process.Start(player02.startInfo);
			}
			catch (Exception e)
			{
				LogWriteLine(mainForm.textGameLog, "起動に失敗しました:" + e.ToString());
				return false;
			}

			return true;
		}

		private void Close()
		{
			player01.process.WaitForExit();
			player02.process.WaitForExit();
			player01.process.Dispose();
			player02.process.Dispose();


		}

		private void FileWrite()
		{
			DateTime dt = DateTime.Now;
			string fileDate = dt.ToString("yyyyMMddHHmmss");

			string directoryPath = Config.LogDirectory + "/" + fileDate;
			Directory.CreateDirectory(directoryPath);

			string replayFileName = directoryPath + "/" + "replay_" + player01.name + "_" + player02.name + Config.FileExtension;
			File.WriteAllText(replayFileName, replayLog);

			if (log)
			{
				string cinFileName = directoryPath + "/";
				File.WriteAllText(cinFileName + "1_in_" + player01.name + Config.FileExtension, GetLogText(player01.cin));
				File.WriteAllText(cinFileName + "2_in_" + player02.name + Config.FileExtension, GetLogText(player02.cin));

				string coutFileName = directoryPath + "/";
				File.WriteAllText(coutFileName + "1_out_" + player01.name + Config.FileExtension, GetLogText(player01.cout));
				File.WriteAllText(coutFileName + "2_out_" + player02.name + Config.FileExtension, GetLogText(player02.cout));

				string cerrFileName = directoryPath + "/";
				File.WriteAllText(cerrFileName + "1_err_" + player01.name + Config.FileExtension, GetLogText(player01.cerr));
				File.WriteAllText(cerrFileName + "2_err_" + player02.name + Config.FileExtension, GetLogText(player02.cerr));
			}
		}

		private bool CheckPlayerName()
		{
			char[] invalidChars = Path.GetInvalidFileNameChars();

			if (player01.name.IndexOfAny(invalidChars) >= 0)
			{
				LogWriteLine(mainForm.textGameLog, "無効なユーザ名です:" + player01.name);
				return false;
			}
			if (player02.name.IndexOfAny(invalidChars) >= 0)
			{
				LogWriteLine(mainForm.textGameLog, "無効なユーザ名です:" + player02.name);
				return false;
			}

			return true;
		}

		private void Writeline(PlayerProcess player, string str)
		{
			player.process.StandardInput.WriteLine(str);
			LogWriteLine(player.cin, str);
		}
		private async Task<string> ReadlineAsync(PlayerProcess player)
		{
			string cout = await player.process.StandardOutput.ReadLineAsync();
			LogWriteLine(player.cout, cout);

			return cout;
		}
		private string ReadErrline(PlayerProcess player)
		{
			string cerr = player.process.StandardError.ReadLine();
			LogWriteLine(player.cerr, cerr);

			return cerr;
		}

		private void LogWriteLine(TextBox textbox, string str)
		{
			mainForm.Invoke(new Action<TextBox, string>((control, text) =>
			{
				control.AppendText(text + Environment.NewLine);
				control.Refresh();
			}), new object[] { textbox, str });
		}

		private string GetLogText(TextBox textbox)
		{
			string text = (string)mainForm.Invoke(new Func<TextBox, string>((control) =>
			   {
				   return (string)control.Text.Clone();
			   }), textbox);

			return text;
		}


	}
}
