using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CA_TriMots
{
    class Program
    {
        static List<string> Text { get; set; }
        static List<string> Text2 { get; set; }
        static Dictionary<string, int> TextDictionary { get; set; }
        static object Lock { get; set; }
        static void Main(string[] args)
        {
            string filePath = @"lorem5.txt";
            List<string> text, text2;

            //Read 50 lines for sorting
            /*text = ReadNumberOfLines(5000, filePath);

            text2 = new List<string>();
            foreach (var line in text)
            {
                //text2.AddRange(line.Split(new Char[] { ' ', ',', '.', ':', ';', '!', '?', '\t' }));
                text2.AddRange(line.Split());
            }
            text2.Sort();*/

            Text = new List<string>();
            Text2 = new List<string>();
            TextDictionary = new Dictionary<string, int>();
            Lock = new object();
            /*Text = ReadNumberOfLines(50, filePath);
            SplitLines(Text);
            SortWords(Text2);*/
            //ReadFile(filePath); 
            Parallel.ForEach(File.ReadLines(filePath), (line, _, lineNumber) =>
            {
                var splitLine = line.Split();
                //splitLine.ToList().ForEach(w => Regex.Replace(w, @"[^\w\s]", ""));
                foreach (var word in splitLine)
                {
                    //Regex.Replace(word, @"[^\w\s]", "");
                    /*lock (Lock)
                    {
                        if (TextDictionary.ContainsKey(word))
                        {
                            TextDictionary[word]++;
                        }
                        else
                        {
                            TextDictionary.TryAdd(word, 1);
                        }
                    }*/
                    Text.Add(word);
                    //Text2.Add(word);
                }
            });
        }
        /*static void ReadFile(string path)
        {
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    //Regex.Replace(line, @"[^\w\s]", "");
                    if (text)
                    {

                    }
                }

            }
            SplitLines(Text);
            SortWords(Text2);
        }*/
        static void SplitLines(List<string> text)
        {
            Text.ForEach(t => Text2.AddRange(t.Split()));
        }
        static void SortWords(List<string> text)
        {
            text.Sort();
        }
        static async Task<List<string>> ReadAllLinesAsync(string path)
        {
            List<string> lines = new List<string>();
            using (StreamReader streamReader = new StreamReader(path))
            {
                lines.Add(await streamReader.ReadToEndAsync());
            }
            return lines;
        }
        static List<string> ReadNumberOfLines(int numberOfLines, string path)
        {
            List<string> lines = new List<string>();
            for (int i = 0; i < numberOfLines; i++)
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    lines.Add(Regex.Replace(streamReader.ReadLine(), @"[^\w\s]", ""));
                }
            }
            return lines;
        }
    }
}
