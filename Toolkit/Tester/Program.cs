using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FinckInc.Toolkit.Extensions;

namespace Tester
{
	class Program
	{
		static void Main(string[] args)
		{
			Test();
		}

		private static void Test()
		{
			string stuff = new Exception("Bite me!").ToFullString();
			string xmlStuff = new Object().ToXmlString();
		}
	}
}
