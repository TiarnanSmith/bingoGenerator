using bingoApp.Model;
using bingoApp.FileHandle;

namespace bingoApp
{
    public class BingoClass
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">Number of People</param>
        /// <param name="name">File name</param>
        public static void CreateBingo(int n, string name)
        {
            string p = @"C:\Users\tiarn\Desktop\Programing\BingoSystem\bingoApp\Model\Bingo.csv";

            BingoSystem bingo = new BingoSystem(p, n, 5, 5);
            string[][,] strings = new string[bingo.Grid.Count][,];

            for (int i = 0; i < bingo.Grid.Count; i++)
            {
                strings[i] = bingo.Grid[i].BingoSquares;
            }
            string p2 = $@"C:\Users\tiarn\Desktop\Programing\BingoSystem\bingoApp\PDFOuputs\{name}.pdf";
            PDFSystem pdf = new PDFSystem(strings, p2);
        }

        public static void PrintBingo()
        {
            string p = @"C:\Users\tiarn\Desktop\Programing\BingoSystem\bingoApp\Model\Bingo.csv";
            BingoSystem bingo = new BingoSystem(p, 1, 3, 5);
            for (int i = 0; i < bingo.Grid.Count; i++)
            {
                BingoGrid grid = bingo.Grid[i];
                Console.WriteLine(grid.outputGrid());
                Console.WriteLine("\n");
            }
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of People");
            dynamic nS = Console.ReadLine();
            try
            {
                nS = Convert.ToInt32(nS);
            }
            catch 
            {
                throw new Exception("Invalid Input");
            }
            Console.WriteLine("FileName");
            string path = Console.ReadLine();

            BingoClass.CreateBingo(nS, path);
        }
    }
}