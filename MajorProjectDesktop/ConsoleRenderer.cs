using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32.SafeHandles;






namespace MajorProjectDesktop
{
    internal class ConsoleRenderer
	{

        public StringBuilder buffer = new StringBuilder();
		public const string BlackBG = "\u001b[40m";
		public const string RedBG = "\u001b[41m";
		public const string GreenBG = "\u001b[42m";
		public const string YelowBG = "\u001b[43m";
		public const string BlueBG = "\u001b[44m";
		public const string MagentaBG = "\u001b[45m";
		public const string CyanBG = "\u001b[46m";
		public const string WhiteBG = "\u001b[47m";
        private Stream stdout = Console.OpenStandardOutput();

		public ConsoleRenderer(int w, int h){
 
                        var stdout = Console.OpenStandardOutput();
			var con = new StreamWriter(stdout, Encoding.ASCII);
            con.AutoFlush = true;
			Console.SetOut(con);
                        buffer.EnsureCapacity(w * h);

		}

		public void ClearScreen() {
			buffer.Clear();
		}
		public void AddColoredCellToBuffer(string bgCol){
			buffer.Append(bgCol + ' ');
		}

		public void BufferNextLine()
		{
			buffer.Append("\u001b[40m\n");

                }
        public void drawBuffer() {
           stdout.WriteAsync(Encoding.ASCII.GetBytes(buffer + BlackBG + '\n'), 0, buffer.Length + BlackBG.Length + 1);	
	}
    }
}
