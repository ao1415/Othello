using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
	class GameEngine
	{

		private readonly string exePath1;
		private readonly string exePath2;

		private readonly int lifeTime;
		private readonly bool log;

		public Form mainForm;
		public TextBox player01Cin;
		public TextBox player01Cout;
		public TextBox player01Cerr;
		public TextBox player02Cin;
		public TextBox player02Cout;
		public TextBox player02Cerr;

		private char[,] table = new char[Config.Size, Config.Size];

		private ProcessStartInfo player01StartInfo;
		private ProcessStartInfo player02StartInfo;
		private Process player01;
		private Process player02;

		public GameEngine(string exePath1, string exePath2, int lifeTime, bool log)
		{
			this.exePath1 = exePath1;
			this.exePath2 = exePath2;

			this.lifeTime = lifeTime;
			this.log = log;
		}

		public async Task<string> GameTaskAsync(CancellationToken token)
		{

			Init();

			while (true)
			{
				break;
			}

			Close();

			await Task.Delay(1000);

			return "result";
		}

		private void Init()
		{
			for (int y = 0; y < Config.Size; y++)
			{
				for (int x = 0; x < Config.Size; x++)
				{
					table[y, x] = Cell.Empty;
				}
			}
			table[Config.Size / 2 - 0, Config.Size / 2 - 0] = Cell.White;
			table[Config.Size / 2 - 1, Config.Size / 2 - 0] = Cell.Black;
			table[Config.Size / 2 - 0, Config.Size / 2 - 1] = Cell.Black;
			table[Config.Size / 2 - 1, Config.Size / 2 - 1] = Cell.White;

			string[] player01String = new string[3];
			string[] player02String = new string[3];

			player01String[0] = Config.Size.ToString();
			player01String[1] = (lifeTime * 100).ToString();
			player02String[0] = player01String[0];
			player02String[1] = player01String[1];

			player01String[2] = "b";
			player02String[2] = "w";

			player01StartInfo = new ProcessStartInfo(exePath1);
			player02StartInfo = new ProcessStartInfo(exePath2);

			player01StartInfo.UseShellExecute = false;
			player01StartInfo.RedirectStandardInput = true;
			player01StartInfo.RedirectStandardOutput = true;
			player01StartInfo.RedirectStandardError = true;

			player02StartInfo.UseShellExecute = false;
			player02StartInfo.RedirectStandardInput = true;
			player02StartInfo.RedirectStandardOutput = true;
			player02StartInfo.RedirectStandardError = true;

			player01 = Process.Start(player01StartInfo);
			player02 = Process.Start(player02StartInfo);

			Writeline(player01, player01Cin, player01String[0]);
			Writeline(player01, player01Cin, player01String[1]);
			Writeline(player01, player01Cin, player01String[2]);

			Writeline(player02, player02Cin, player02String[0]);
			Writeline(player02, player02Cin, player02String[1]);
			Writeline(player02, player02Cin, player02String[2]);


		}

		private void Close()
		{
			player01.WaitForExit();
			player02.WaitForExit();
			player01.Dispose();
			player02.Dispose();
		}

		private void Writeline(Process player, TextBox textbox, string str)
		{
			player.StandardInput.WriteLine(str);
			LogWriteLine(textbox, str);
		}

		private void LogWriteLine(TextBox textbox, string str)
		{
			mainForm.Invoke(new Action<TextBox, string>((control, text) =>
			{
				control.AppendText(text + Environment.NewLine);
				control.Refresh();
			}), new object[] { textbox, str });
		}


		static class Config
		{
			public static readonly int Size = 8;
		}
		static class Cell
		{
			public static char Empty = '-';
			public static char Black = 'b';
			public static char White = 'w';
		}

	}
}
