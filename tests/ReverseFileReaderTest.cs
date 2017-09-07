using System;
// using System.Runtime.Extensions;
using System.IO;
using NUnit.Framework;

namespace Tail {

	[TestFixture]
	public class ReverseFileReaderTest {
		private string expectedAlphabet = "abc\ndef\nghi\njkl\nmno\npqr\nstu\nvwx\nyz!\n";

		[Test]
		public void ReadAlphabet() {
			// string path = Path.Combine(System.Environment.CurrentDirectory, "/tests/alphabet.txt");
			string got = ReverseFileReader.Read("./tests/alphabet.txt", 20);

			Assert.AreEqual(expectedAlphabet, got);
		}
	}
}
