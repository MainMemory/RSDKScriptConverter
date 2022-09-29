using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSDKScriptConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length < 3)
			{
				Console.WriteLine("Usage: RSDKScriptConverter infmt outfmt infile [outfile]");
				Console.WriteLine();
				Console.WriteLine("Formats:");
				Console.WriteLine("\tv3\tRSDKv3 RetroScript");
				Console.WriteLine("\tv4\tRSDKv4 RetroScript");
				Console.WriteLine("\tv4Old\tRSDKv4 RetroScript (old format)");
			}
			else
			{
				ScriptEngine srceng;
				switch (args[0].ToLowerInvariant())
				{
					case "v3":
						srceng = new ScriptEngineV3();
						break;
					case "v4":
						srceng = new ScriptEngineV4();
						break;
					case "v4old":
						srceng = new ScriptEngineV4Old();
						break;
					default:
						Console.WriteLine("Unknown input format {0}", args[0]);
						return;
				}
				ScriptEngine dsteng;
				switch (args[1].ToLowerInvariant())
				{
					case "v3":
						dsteng = new ScriptEngineV3();
						break;
					case "v4":
						dsteng = new ScriptEngineV4();
						break;
					case "v4old":
						dsteng = new ScriptEngineV4Old();
						break;
					default:
						Console.WriteLine("Unknown output format {0}", args[1]);
						return;
				}
				string infile = args[2];
				string outfile;
				if (args.Length > 3)
					outfile = args[3];
				else
					outfile = $"{Path.ChangeExtension(infile, null)}_{args[1]}{Path.GetExtension(infile)}";
				dsteng.WriteScript(outfile, srceng.ReadScript(infile));
			}
		}
	}
}
