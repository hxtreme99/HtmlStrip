using System;
using System.Net;
using System.Text.RegularExpressions;

namespace HtmlStrip
{
    class Program
    {
        static string split_string(string[] separator, string concatenar)
        {
            var tokens_b = concatenar.Split(separator, StringSplitOptions.None);

            concatenar = "";
            for (var i = 0; i < tokens_b.Length; i += 1) concatenar = string.Concat(concatenar, tokens_b[i]);
            return concatenar;
        }

        static void Main(string[] args)
        {
            var client = new WebClient();
            var teste1 = "https://pt.wikipedia.org/wiki/Madeira_(regi%C3%A3o_aut%C3%B3noma)";
            var teste2 = "https://pt.lipsum.com/feed/html";
            var teste3 = "https://pt.wikipedia.org/wiki/Poncha";
            var teste4 = "https://pt.wikipedia.org/wiki/Portugal";
            var downloadString = client.DownloadString(teste4);

            var tokens_p = Regex.Split(downloadString, @"<[p]>|<[p][ ][^<>]+>|</[p]>");

            var concatenar = "";
            for (var i = 1; i < tokens_p.Length; i += 2)
            {
                concatenar = string.Concat(concatenar, tokens_p[i]);
                concatenar = string.Concat(concatenar, "\n");
            }

            var tokens_ahref = Regex.Split(concatenar, @"<[a][ ][^<>]+>|</[a]>");
            concatenar = "";
            for (var i = 0; i < tokens_ahref.Length; i += 1)
                concatenar = string.Concat(concatenar, tokens_ahref[i]);

            concatenar = split_string(new[]
            {
                "<b>",
                "</b>"
            }, concatenar);
            concatenar = split_string(new[]
            {
                "<i>",
                "</i>"
            }, concatenar);

            var tokens_apagar = Regex.Split(concatenar, @"<[^<>]+>");
            concatenar = "";
            for (var i = 0; i < tokens_apagar.Length; i += 1)
                concatenar = string.Concat(concatenar, tokens_apagar[i]);

            Console.WriteLine(concatenar);
        }
    }
}