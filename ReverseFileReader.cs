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
			char ch;
			bool isReadAll = false;

			// For each line in lines from end of file:
			// If caught Exception from seeking
			//     break (reached beginning of file)
			// Else
			//     push byte into character array and continue.
			using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{
				for (offset = 1; newlineCount < lines; offset++)
				{
					try
					{
						fs.Seek(-offset, SeekOrigin.End);
					}
					catch (Exception)
					{
						isReadAll = true;
						break;
					}

					buffer.Add(ch = Convert.ToChar(fs.ReadByte()));

					if (ch == delimiter)
					{
						newlineCount++;
					}
				}
			}

			// Remove the last newline if the whole file was not read.
			int trim = isReadAll ? buffer.Count : buffer.Count - Environment.NewLine.Length;
			buffer = buffer.GetRange(0, trim);
			buffer.Reverse();	
			return new string(buffer.ToArray());
		}
	}
}
