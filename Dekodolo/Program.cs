using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings;

namespace Dekodolo
{
    class Program
    {
        static void Main(string[] args)
        {
            var karakterek = new List<Karakter>();
            using var sr = new StreamReader(
                @"..\..\..\src\bank.txt",
                System.Text.Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                char b = char.Parse(sr.ReadLine());
                bool[,] m = new bool[7, 4];
                for (int s = 0; s < 7; s++)
                {
                    string sor = sr.ReadLine();
                    for (int o = 0; o < sor.Length; o++)
                    {
                        m[s, o] = sor[o] == '1' ? true : false;
                    }
                }
                karakterek.Add(new Karakter(b, m));
            }
            Console.WriteLine($"Karakterek száma: {karakterek.Count} db");

            char input = '\0';
            bool res = false;
            do
            {
                Console.Write("Input:  ");
                res = char.TryParse(Console.ReadLine(), out input);
            } while (!res || (input < 65 || input > 90));
        }
    }
}
