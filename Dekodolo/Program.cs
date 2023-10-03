using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings;
using System.Linq;

namespace Dekodolo
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = Beolvas(@"..\..\..\src\bank.txt");
            Console.WriteLine($"Karakterek száma: {bank.Count} db");

            char input = '\0';
            bool res = false;
            do
            {
                Console.Write("Input:  ");
                res = char.TryParse(Console.ReadLine(), out input);
            } while (!res || (input < 65 || input > 90));

            var mgj = bank.SingleOrDefault(k => k.Betu == input);
            if (mgj is not null) Console.Write(mgj.Kirajzol());
            else Console.WriteLine("Nincs ilyen a bankban");
        }

        static List<Karakter> Beolvas(string eleresiUt)
        {
            var karakterek = new List<Karakter>();
            using var sr = new StreamReader(
                eleresiUt,
                Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                char b = char.Parse(sr.ReadLine());
                bool[,] m = new bool[7, 4];
                for (int s = 0; s < m.GetLength(0); s++)
                {
                    string sor = sr.ReadLine();
                    for (int o = 0; o < m.GetLength(1); o++)
                    {
                        m[s, o] = sor[o] == '1';
                    }
                }
                karakterek.Add(new Karakter(b, m));
            }
            return karakterek;
        }

    }
}
