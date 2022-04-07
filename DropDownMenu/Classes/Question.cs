using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDownMenu.Classes
{
    [Serializable]
    public class Question
    {
        public string question;
        public string ans1;
        public string ans2;
        public string ans3;
        public string ans4;
        public string correct;

        public Question(string q, string ans1, string ans2, string ans3, string ans4, string c)
        {
            question = q;
            this.ans1 = ans1;
            this.ans2 = ans2;
            this.ans3 = ans3;
            this.ans4 = ans4;
            correct = c;
        }
    }
}
