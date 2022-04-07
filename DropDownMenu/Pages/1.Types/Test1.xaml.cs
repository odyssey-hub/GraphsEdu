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
    public partial class Test1: UserControl
    {
        private int score = 0;
        private int i = 0;
        private List<Question> list;
        public Test1()
        {
            InitializeComponent();
            
            
        }

        private void loadList()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("SQLite1.dat", FileMode.OpenOrCreate))
            {
                list = (List<Question>)formatter.Deserialize(fs);
            }
            List<Question> nlist = new List<Question>();
            for (int i=0; i < 5; i++)
            {
                nlist.Add(list[i]);
            }
            list = nlist;
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            
            if (GetChecked() == list[i].correct) score++;
            i++;
            if (i == list.Count)
            {
                string rank = "";
                switch (score)
                {
                    case 0: rank = "5 неправильных ответов"; break;
                    case 1: rank = "4 неправильных ответа"; break;
                    case 2: rank = "3 неправильных ответа"; break;
                    case 3: rank = "2 неправильных ответа"; break;
                    case 4: rank = "1 неправильный ответ"; break;
                    case 5: rank = "Тест пройден."; break;
                }
                MessageBox.Show(rank);
                if (score == 5)
                {
                    UserControlStat.SetProgress(0, "T");
                    UserControlActions.AddRecord("Тест по теме 'Основы' пройден");
                    i = 0;
                    score = 0;
                    NextQuestion();
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
