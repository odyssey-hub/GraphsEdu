using MindFusion.Diagramming.Wpf.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class UserControlMinPractice2 : UserControl
    {

        public UserControlMinPractice2()
        {
            InitializeComponent();
            

        }

        class Iteration
        {
            public string i { get; set; }
            public string W { get; set; }
            public string S { get; set; }
            public string D2 { get; set; }
            public string D3 { get; set; }
            public string D4 { get; set; }

            public Iteration()
            {

            }

            public Iteration(string i)
            {
                this.i = i;
                W = "";
                S = "";
                D2 = "";
                D3 = "";
                D4 = "";
            }

            public Iteration(string i,string D4)
            {
                this.i = i;
                this.D4 = D4;
                W = "";
                S = "";
                D2 = "";
                D3 = "";
            }

            public Iteration(string i, string S,bool g)
            {
                this.i = i;
                this.S = S;
                W = "";
                D2 = "";
                D3 = "";
                D4 = "";
            }

            public Iteration(string i, string S, string W, string D2, string D3, string D4)
            {
                this.i = i;
                this.W = W;
                this.S = S;
                this.D2 = D2;
                this.D3 = D3;
                this.D4 = D4;
            }

            public override bool Equals(object obj)
            {
                if (obj.GetType() != this.GetType()) return false;
                Iteration it = (Iteration)obj;
                if (it.i == this.i && it.S == this.S && it.W == this.W && it.D2 == this.D2 && it.D3 == this.D3 && it.D4 == this.D4)
                    return true;
                else return false;
            }
        }
        private List<Iteration> iterations = new List<Iteration>();
        private void datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            iterations.Clear();
            iterations.Add(new Iteration("1","INF"));
            iterations.Add(new Iteration("2"));
            iterations.Add(new Iteration("3","132",true));
            iterations.Add(new Iteration("4"));
            datagrid.ItemsSource = iterations;
            datagrid.CanUserAddRows = false;
            datagrid.CanUserDeleteRows = false;
            datagrid.CanUserSortColumns = false;
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            List<Iteration> correct = new List<Iteration>();
            correct.Add(new Iteration("1","1","","10","3","INF"));
            correct.Add(new Iteration("2", "13", "3", "7", "", "14"));
            correct.Add(new Iteration("3", "132", "2", "", "", "14"));
            correct.Add(new Iteration("4", "1324", "4", "7", "3", "14"));
            if (correct.SequenceEqual(iterations))
            {
                UserControlStat.SetProgress(4, "P2");
                UserControlActions.AddRecord("Практическое задание 'Алгоритм Дейкстры' выполнено");
                MessageBox.Show("Молодец, всё правильно!");
            } else
            {
                string error = "Таблица заполнена неправильно:\n";
                for (int i=0; i < 4; i++)
                {
                    if (!correct[i].Equals(iterations[i])) error += $"{i+1} итерация заполнена неправильно\n";
                }
                MessageBox.Show(error);
            }

        }
    }
}
