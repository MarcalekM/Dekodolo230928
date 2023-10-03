using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekodolo
{
    class Karakter
    {
        public char Betu { get; set; }
        public bool[,] Matrix { get; set; }

        public string Kirajzol()
        {
            string karakterKep = string.Empty;
            for (int s = 0; s < Matrix.GetLength(0); s++)
            {
                for (int o = 0; o < Matrix.GetLength(1); o++)
                {
                    karakterKep += Matrix[s, o] ? 'X' : ' ';
                }
                karakterKep += '\n';
            }
            return karakterKep;
        }

        public Karakter(char betu, bool[,] matrix)
        {
            Betu = betu;
            Matrix = matrix;
        }
    }
}
