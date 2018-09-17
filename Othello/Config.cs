using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
	static class Config
	{
		public static readonly int Size = 8;

		public static readonly string LogDirectory = "./logs";

		public static readonly string FileExtension = ".txt";

		public static readonly char Black = 'b';
		public static readonly char White = 'w';
		public static readonly char Draw = 'd';

		public static readonly string End = "END";
	}
}
