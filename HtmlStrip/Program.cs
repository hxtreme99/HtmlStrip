using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace HtmlStrip
{
    class Program
    {
       static string split_string(string [] separator,string concatenar)
        {
            
            string[] tokens_b = concatenar.Split(separator, StringSplitOptions.None);

            concatenar = "";
            for (int i = 0; i < tokens_b.Length; i += 1)
            {
                concatenar = string.Concat(concatenar, tokens_b[i]);
            }
            return concatenar;
        }
        static void Main(string[] args)
        {

            WebClient client = new WebClient();
            string teste1 = "https://pt.wikipedia.org/wiki/Madeira_(regi%C3%A3o_aut%C3%B3noma)";
            string teste2 = "https://pt.lipsum.com/feed/html";
            string teste3 = "https://pt.wikipedia.org/wiki/Poncha";
            string teste4 = "https://pt.wikipedia.org/wiki/Portugal";
            string downloadString = client.DownloadString(teste4);

            string[] tokens_p=Regex.Split(downloadString, @"<[p]>|<[p][ ][^<>]+>|</[p]>");
            
            string concatenar = "";
            for (int i = 1;i< tokens_p.Length;i+=2)
            {
                concatenar=string.Concat(concatenar,tokens_p[i]);
                concatenar = string.Concat(concatenar,"\n");
            }

            string[] tokens_ahref = Regex.Split(concatenar, @"<[a][ ][^<>]+>|</[a]>");
            concatenar = "";
            for (int i = 0; i < tokens_ahref.Length; i += 1)
            {
                concatenar = string.Concat(concatenar, tokens_ahref[i]);
            }

            concatenar=split_string(new string[] { "<b>", "</b>" },concatenar);
            concatenar = split_string(new string[] { "<i>", "</i>" },concatenar);

           
            
            string[] tokens_apagar = Regex.Split(concatenar, @"<[^<>]+>");
            concatenar = "";
            for (int i = 0; i < tokens_apagar.Length; i += 1)
            {
                concatenar = string.Concat(concatenar, tokens_apagar[i]);
            }

            Console.WriteLine(concatenar);
        }

    }
}
