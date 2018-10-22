using System;
using System.IO;
using System.Text;

namespace srt_2_txt
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("The.Middle.S01E01.HDTV.XviD-2HD.srt");
            StringBuilder result = new StringBuilder();
            for(int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if(string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var firstChar = line[0];
                var isNumber = System.Text.RegularExpressions.Regex.IsMatch(firstChar.ToString(), @"[\d]");
                if(isNumber == false)
                {
                    line = line.Replace("<i>", "");
                    line = line.Replace("</i>", "");
                    if(line.EndsWith('.') || line.EndsWith('?'))
                    {
                        line = line + "  ";
                    }
                    else
                    {
                        // stence in 2 line
                        line = line + " ";
                    }

                    result.Append(line);
                }
            }
            File.WriteAllText("The.Middle.S01E01.HDTV.XviD-2HD.srt.txt", result.ToString());
            Console.Write(result.ToString());
        }
    }
}
