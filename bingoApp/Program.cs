using bingoApp.Model;
using bingoApp.FileHandle;

namespace bingoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string p = @"C:\Users\tiarn\Desktop\Programing\bingoApp\bingoApp\Model\Bingo.csv";
            
            BingoSystem bingo = new BingoSystem(p, 5, 3, 5);

            for (int i = 0; i < bingo.Grid.Count; i++)
            {
                BingoGrid grid = bingo.Grid[i];
                string p2 = $@"C:\Users\tiarn\Desktop\Programing\bingoApp\bingoApp\PDFOuputs\MadeBingo{i}.pdf";
                PDFSystem pdf = new PDFSystem(grid.BingoSquares, p2);
            }
        }

        private void PrintBingo()
        {
            string p = @"C:\Users\tiarn\Desktop\Programing\bingoApp\bingoApp\Model\Bingo.csv";
            BingoSystem bingo = new BingoSystem(p, 1, 3, 5);
            for (int i = 0; i < bingo.Grid.Count; i++)
            {
                BingoGrid grid = bingo.Grid[i];
                Console.WriteLine(grid.outputGrid());
                Console.WriteLine("\n");
            }
        }
    }
}