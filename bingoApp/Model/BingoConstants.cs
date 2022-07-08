using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bingoApp.Model
{
    public class BingoConstants
    {
        public static Dictionary<int, string> BingoConst = new Dictionary<int, string>();

        public static void CreateConstants(string path)
        {
            BingoConst.Clear();
            string[] bingoPhrases = File.ReadAllLines(path);

            for (int i = 0; i < bingoPhrases.Length; i++)
            {
                BingoConst.Add(i, bingoPhrases[i]);
            }
        }
    }
}
