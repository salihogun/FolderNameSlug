using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace URLSlug
{
    class Program
    {
        static string[] allFiles;
        static string[] allFiles2;
        public const int MaxValue = 5000;

        static void Main(string[] args)
        {

            for (int i = 0; i < MaxValue; i++)
            {
                Console.Write("*");
            }

            var dosya = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory()).ToList();
            var klasor = System.IO.Directory.GetDirectories(System.IO.Directory.GetCurrentDirectory()).ToList();

            var fileNames = new List<string>();
            klasor.ForEach(o => fileNames.Add(Path.GetFileNameWithoutExtension(o)));
            var dirNames = new List<string>();
            dosya.ForEach(p => dirNames.Add(Path.GetFileNameWithoutExtension(p)));
            allFiles = new string[fileNames.Count];
            allFiles2 = new string[dirNames.Count];
            int j = 0;
            for (j = 0; j < fileNames.Count; j++)
            {

                allFiles[j] = fileNames[j];

                FileInfo info = new FileInfo(Directory.GetCurrentDirectory() + "/" + allFiles[j]);
                info.MoveTo(Directory.GetCurrentDirectory() + "/" + UrlSlug(allFiles[j]));

            }
            for (int k = 0; k < dirNames.Count; k++)
            {

                if (dirNames[k] == "URLSlug" || dirNames[k] == "URLSlug.exe")
                {
                    allFiles2[k] = dirNames[k];
                }
                else
                {
                    allFiles2[k] = dirNames[k];
                    FileInfo info2 = new FileInfo(Directory.GetCurrentDirectory() + "\\" + allFiles2[k] + "." + dosya[k].Split('.').Last());
                    info2.MoveTo(Directory.GetCurrentDirectory() + "\\" + UrlSlug(allFiles2[k]) + "." + dosya[k].Split('.').Last());
                }

            }

        }

        public static string UrlSlug(string ALink)
        {
            var tr = new[] { "ş", "Ş", "İ", "ı", "ğ", "Ğ", "ü", "Ü", "Ö", "ö", "ç", "Ç", "%" };
            var eng = new[] { "s", "s", "i", "i", "g", "g", "u", "u", "o", "o", "c", "c", "" };
            //Dictionary<string, string> replaceDictionary = new Dictionary<string, string>();
            //replaceDictionary.Add("ş", "s");


            //string mylongtext = "dfhgklkfdhgkldşfhkg5ikifkisşskfkgdşhşlŞLFKGHİŞDLFGHK";

            for (int i = 0; i < 12; i++)
            {
                ALink = ALink.Replace(tr[i], eng[i]);
            }
            ALink = delSpace(ALink);
            ALink = ALink.ToLower();
            ALink = ALink.Trim();

            return ALink;
        }



        static string delSpace(string link)
        {
            Regex r = new Regex(@"\s+");

            link = r.Replace(link, @"-");
            return link;
        }
    }
}
