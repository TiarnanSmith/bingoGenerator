using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bingoApp.Model
{
    public class BingoGrid
    {
        private Random rand;

        private string[,] _bingoSquares;

        public string[,] BingoSquares => _bingoSquares;

        public BingoGrid(int x, int y)
        {
            _bingoSquares = new string[x, y];
            rand = new Random();

            createBingo();
        }

        /// <summary>
        /// Randomises the dictonary of BingoPhrases
        /// </summary>
        /// <param name="toRandom"></param>
        /// <returns></returns>
        private string[] bingoRandomize(string[] toRandom)
        {
            string[] bingo = new string[toRandom.Length];

            int k = 0;

            while (k != toRandom.Length)
            {
                int a = rand.Next(0, toRandom.Length);
                
                
                if (bingo[a] == null)
                {
                    bingo[a] = toRandom[k];
                    
                    k++;
                }
            }


            return bingo;
        }


        public void createBingo()
        {
            string[] consts = BingoConstants.BingoConst.Values.ToArray();
            consts = bingoRandomize(consts);

            string[,] a = _bingoSquares;
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = consts[k];
                    k++;
                }
            }

            _bingoSquares = a;
            
        }

        public string outputGrid()
        {
            string store = "";

            for (int i = 0; i < _bingoSquares.GetLength(1); i++)
            {
                for (int j = 0; j < _bingoSquares.GetLength(0); j++)
                {
                    ;
                    store += $"{_bingoSquares[j,i]}, ";
                }

                store += "\n";
            }

            return store;
        }
    }
}
