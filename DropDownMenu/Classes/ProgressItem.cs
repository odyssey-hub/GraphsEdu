using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDownMenu.Classes
{
    [Serializable]
    public class ProgressItem
    {
        public int L1 { get; set; }
        public int L2 { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int T { get; set; }

        public int Score { get; set; }

        public ProgressItem(int score)
        {
            L1 = 0;
            L2 = 0;
            P1 = 0;
            P2 = 0;
            T = 0;
            Score = score;
        }

        public int Sum()
        {
            return L1 + L2 + P1 + P2 + T;
        }

        public int GetProgress()
        {
            return (Sum() * 100) / Score;
        }
    }
}
