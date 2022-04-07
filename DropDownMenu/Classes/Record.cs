using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropDownMenu.Classes
{
    [Serializable]
    public class Record
    {
        private static int counter;
        private int id;
        private string action;
        private string date;
        private string time;

        public int ID { get { return id; } set { id = value; } }

        public string Action { get { return action; } set { action = value; } }
        public string Date { get { return date; } set { date = value; } }
        public string Time { get { return time; } set { time = value; } }

        public Record(string action)
        {
            this.action = action;
            DateTime dateTime = DateTime.Now;
            date = dateTime.ToShortDateString();
            time = dateTime.ToShortTimeString();
        }
    }
}
