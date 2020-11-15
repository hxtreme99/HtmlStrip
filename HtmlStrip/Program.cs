﻿using System;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

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
<<<<<<< HEAD
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
=======
            
            Console.WriteLine("HtmlStrip");
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: htmlstrip filename");
                return;
            }

            string code = "";
            string[] tokens=args[0].Split('.');

            if (tokens[tokens.Length - 1].Equals("html"))
            {
                if (!File.Exists(args[0]))
                {
                    Console.WriteLine($"Error: file {args[0]} does not exist.");
                    return;
                }
                code = System.IO.File.ReadAllText(args[0]);

            }

            else
            {

                WebClient client = new WebClient();
                string teste1 = "https://pt.wikipedia.org/wiki/Madeira_(regi%C3%A3o_aut%C3%B3noma)";
                string teste2 = "https://pt.lipsum.com/feed/html";
                string teste3 = "https://pt.wikipedia.org/wiki/Poncha";
                string teste4 = "https://pt.wikipedia.org/wiki/Portugal";
                code = client.DownloadString(teste4);
            }
            //string[] tokens_p=Regex.Split(downloadString, @"<[p]>|<[p][ ][^<>]+>|</[p]>");

            string[] tokens_p = Regex.Split(code, @"<[p]>|<[p][ ][^<>]+>|</[p]>");
            string concatenar = "";
            for (int i = 1;i< tokens_p.Length;i+=2)

            {
                concatenar = string.Concat(concatenar, tokens_p[i]);
                concatenar = string.Concat(concatenar, "\n");
            }


            
            string[] tokens_apagar = Regex.Split(concatenar, @"<[^<>]+>");

            concatenar = "";
            for (var i = 0; i < tokens_apagar.Length; i += 1) { 
>>>>>>> cristovao
                concatenar = string.Concat(concatenar, tokens_apagar[i]);

<<<<<<< HEAD
            Console.WriteLine(concatenar);
            Console.WriteLine("End");
            Console.WriteLine("Henrique");
=======
        Console.WriteLine(concatenar);

>>>>>>> cristovao
        }
    }
}