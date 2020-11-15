using System;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace HtmlStrip
{
    class Program
    {
        public static string titulos(string concatenar,string pattern,string tokens_p,string espacos)
        {
            string[] tokens_h = Regex.Split(tokens_p, @pattern);
            for (int a = 1; a < tokens_h.Length; a += 2)
            {
                concatenar = string.Concat(concatenar, "\n");
                concatenar = string.Concat(concatenar, espacos); ;
                tokens_h[a] = apagar_lixo(tokens_h[a]);
                concatenar = string.Concat(concatenar, tokens_h[a]);
                concatenar = string.Concat(concatenar, "\n\n"); ;
            }
            return concatenar;
        }

        public static string paragrafos(string code)
        {
            string[] tokens_p = Regex.Split(code, @"<[p]>|<[p][ ][^<>]+>|</[p]>");
            string concatenar = "";
            for (int i = 0; i < tokens_p.Length; i++)
            {
                if (i % 2 == 0)
                {
                    concatenar = titulos(concatenar, "<h1[^<>]*>|</h1>", tokens_p[i], "");
                    concatenar = titulos(concatenar, "<h2[^<>]*>|</h2>", tokens_p[i], " ");
                    concatenar = titulos(concatenar, "<h3[^<>]*>|</h3>", tokens_p[i], "  ");

                }
                else
                {
                    concatenar = string.Concat(concatenar, tokens_p[i]);
                    concatenar = string.Concat(concatenar, "\n");
                }
            }
            return concatenar;
        }

        public static string limpar(string concatenar,string pattern)
        {
            string[] tokens_sup = Regex.Split(concatenar, @pattern);
            concatenar = "";
            for (var i = 0; i < tokens_sup.Length; i += 2)
            {
                concatenar = string.Concat(concatenar, tokens_sup[i]);
            }
            return concatenar;
        }

        public static string apagar_lixo(string concatenar)
        {
            string[] tokens_apagar = Regex.Split(concatenar, @"<[^<>]+>");
            concatenar = "";
            for (var i = 0; i < tokens_apagar.Length; i += 1)
            {
                concatenar = string.Concat(concatenar, tokens_apagar[i]);
            }
            return concatenar;
        }

        static void Main(string[] args)
        {
            
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: htmlstrip filename");
                Console.WriteLine("or");
                Console.WriteLine("Usage: htmlstrip url");
                Console.WriteLine("If you want to save the text in a file type: htmlstrip (filename or url) save");
                return;
            }

            string code;
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
                code = client.DownloadString(args[0]);
            }

            string concatenar = paragrafos(code);

            concatenar = limpar(concatenar, "<sup[^<>]*>|</sup[^<>]*>");

            concatenar = apagar_lixo(concatenar);

            Console.WriteLine(concatenar);

            if (args.Length>1) {
                if (args[1].Equals("save"))
                {
                    File.WriteAllText("texto.txt", concatenar);
                }
            }
        }
    }
}