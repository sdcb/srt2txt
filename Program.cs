using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace srt_2_txt
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("The.Middle.S01E01.HDTV.XviD-2HD.srt");
            var result = String.Join(" ", lines
                .Where(x => x.Length > 0 && !Char.IsDigit(x[0]))
                .Select(x => x.Replace("<i>", "").Replace("</i>", ""))
                .Select(x => Regex.Replace(x, @"(.*)(\.|\?)$", "$1")));
            File.WriteAllText("The.Middle.S01E01.HDTV.XviD-2HD.srt.txt", result);
            Console.Write(result);
        }
    }
}
