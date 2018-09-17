using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
	class PlayerProcess
	{
		public string name;

		public ProcessStartInfo startInfo = null;
		public Process process = null;

		public TextBox cin = null;
		public TextBox cout = null;
		public TextBox cerr = null;
	}
}
