using System;
using System.IO;
using System.Collections.Generic;

namespace Tail
{
	public class ReverseFileReader
	{
		/// <summary>
		/// Returns the end-contents of a file as a string.
		/// Starts reading from the end and attempts to
		/// read in the specified number of lines.
		/// </summary>
		public static string Read(string filename, int lines)
		{
			long offset;
			int newlineCount = 0;
			char delimiter = Environment.NewLine[0];
			List<char> buffer = new List<char>();

			// From end of file:
			// If newline
			//   break
			// Else push bytes into character array
			using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{
				for (offset = 1; newlineCount < lines; offset++) {
					try {
						fs.Seek(-offset, SeekOrigin.End);
					} catch (Exception) {
						break;
					}

					int read = fs.ReadByte();
					char ch = Convert.ToChar(read);

					if (ch == delimiter) {
						newlineCount++;
					}

					buffer.Add(ch);
				}
			}

			buffer.Reverse();
			return new string(buffer.ToArray());
		}
	}
}
