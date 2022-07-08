using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bingoApp.Model
{
    public class BingoSystem
    {
        private List<BingoGrid> _grid;
        public List<BingoGrid> Grid => _grid;

        /// <summary>
        /// Constructor of <see cref="BingoSystem"/>
        /// </summary>
        /// <param name="path">Path of phrases CSV</param>
        /// <param name="ReciverOfBingo">The number of bingos to be be created</param>
        /// <param name="x">Width of the Bingo</param>
        /// <param name="y">Height of the Bingo</param>
        public BingoSystem(string path, int ReciverOfBingo, int x, int y)
        {
            BingoConstants.CreateConstants(path);
            _grid = new List<BingoGrid>();

            for (int i = 0; i < ReciverOfBingo; i++)
            {
                BingoGrid bingoGrid = new BingoGrid(x, y);
                _grid.Add(bingoGrid);
            }
        }
    }
}
