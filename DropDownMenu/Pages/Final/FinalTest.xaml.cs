using BeautySolutions.View.ViewModel;
using DropDownMenu.Classes;
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
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class FinalTest : UserControl
    {
        private int score = 0;
        private int i = 0;
        private List<Question> list = new List<Question>();
        public FinalTest()
        {
            InitializeComponent();
            
        }

        private void loadList()
        {
            List<Question> nlist = new List<Question>();
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("SQLite1.dat", FileMode.OpenOrCreate))
            {
                nlist = (List<Question>)formatter.Deserialize(fs);
            }
            var rand = new Random();
            nlist = nlist.OrderBy(x => rand.Next()).ToList();
            for (int i=0; i < 15; i++)
            {
                list.Add(nlist[i]);
            }
            /*
            var set = new HashSet<Question>();
            while(set.Count != 15)
            {
                set.Add(list[rand.Next(0, 24)]);
            }
            */
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            
            if (GetChecked() == list[i].correct) score++;
            i++;
            if (i == list.Count)
            {
                int irank = 15 - score;
                string rank = $"{irank} неправильных ответов. Тест не пройден";
                if (irank > 3) MessageBox.Show(rank);
                if (score > 12)
                {
                    UserControlStat.SetProgress(5, "T");
                    UserControlActions.AddRecord("Итоговый тест пройден");
                    MessageBox.Show("Молодец, тест пройден!");
                    Complete();
                    return;
                }
                else
                {
                    i = 0;
                    score = 0;
                    NextQuestion();
                    return;
                }
            }
            NextQuestion();
            

        }

        private void Complete()
        {
            labelComplete.Visibility = Visibility.Visible;
            question.Visibility = Visibility.Collapsed;
            Radio1.Visibility = Visibility.Collapsed;
            Radio2.Visibility = Visibility.Collapsed;
            Radio3.Visibility = Visibility.Collapsed;
            Radio4.Visibility = Visibility.Collapsed;
            btnAnswer.Visibility = Visibility.Collapsed;
        }

        private void NextQuestion()
        {
            Radio1.IsChecked = true;
            question.Text = list[i].question;
            Radio1.Content = list[i].ans1;
            Radio2.Content = list[i].ans2;
            Radio3.Content = list[i].ans3;
            Radio4.Content = list[i].ans4;         
        }

        private string GetChecked()
        {
            string check = "";
            if (Radio1.IsChecked == true) check = Radio1.Content.ToString();
            if (Radio2.IsChecked == true) check = Radio2.Content.ToString();
            if (Radio3.IsChecked == true) check = Radio3.Content.ToString();
            if (Radio4.IsChecked == true) check = Radio4.Content.ToString();
            return check;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            loadList();
            NextQuestion();
        }
    }
}
