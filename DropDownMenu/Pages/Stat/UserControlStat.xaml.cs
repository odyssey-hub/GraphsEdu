using DropDownMenu.Classes;
using FileManagerUI.Custom_Controls;
using MindFusion.Diagramming.Wpf.Layout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DropDownMenu
{
    /// <summary>
    /// Interaction logic for UserControlDashboard.xaml
    /// </summary>
    public partial class UserControlStat : UserControl
    {
        public static List<ProgressItem> progressItems = new List<ProgressItem>();
        public UserControlStat()
        {
            InitializeComponent();
            LoadData();
            //CreateData();
            gauge.LabelFormatter = value => value + "%"; 
        }

        public static void SetProgress(int i, string field)
        {
            switch (field)
            {
                case "L1": progressItems[i].L1 = 1; break;
                case "L2": progressItems[i].L2 = 1; break;
                case "P1": progressItems[i].P1 = 1; break;
                case "P2": progressItems[i].P2 = 1; break;
                case "T": progressItems[i].T = 1; break;
                default: break;
            }
            Rewrite();
        }

        private static void Rewrite()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("PSQLite.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, progressItems);
            }
        }

        private void CreateData()
        {
            List<ProgressItem> progresses = new List<ProgressItem>();
            progresses.Add(new ProgressItem(4));
            progresses.Add(new ProgressItem(4));
            progresses.Add(new ProgressItem(5));
            progresses.Add(new ProgressItem(5));
            progresses.Add(new ProgressItem(5));
            progresses.Add(new ProgressItem(3));
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("PSQLite.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, progresses);
            }
        }

        private void LoadData()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("PSQLite.dat", FileMode.OpenOrCreate))
            {
                progressItems = (List<ProgressItem>)formatter.Deserialize(fs);
            }
        }

        private void CardButtons_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
            CardButtons[] C = { C1, C2, C3, C4, C5 };
            for (int i=0; i < C.Length; i++)
            {
                C[i].Progress = progressItems[i].GetProgress();
                string progress = "";
                if (progressItems[i].L1 == 1) progress += "Л1/";
                if (progressItems[i].L2 == 1) progress += "Л2/";
                if (progressItems[i].P1 == 1) progress += "П1/";
                if (progressItems[i].P2 == 1) progress += "П2/";
                if (progressItems[i].T == 1) progress += "Тест";
                if (progressItems[i].T == 0 && progress != "") progress = progress.Remove(progress.Length - 1,1);
                C[i].text2 = progress;
            }
            Overall();
        }


        private void Overall()
        {
            int overall_score = 0;
            int my_score = 0;
            foreach(var item in progressItems)
            {
                overall_score += item.Score;
                my_score += item.Sum();
            }
            double value = (my_score*100) / overall_score;
            gauge.Value =  Math.Floor(value);
        }

    }
}
