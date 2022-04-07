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
    public partial class UserControlMinLection1 : UserControl
    {

        public UserControlMinLection1()
        {
            InitializeComponent();
            TextBlock.Text = "Взвешенный граф — граф, каждому ребру которого поставлено в соответствие некое значение(вес ребра). \n" +
                "Кратчайший путь – это путь в графе, то есть последовательность вершин и ребер, инцидентных двум соседним вершинам, и его длина." +
                "Нахождение кратчайшего пути на сегодняшний день является актуальной задачей." +
                "Существует множество различных алгоритмов нахождения кратчайшего пути" +
                "Кратчайший путь можно найти и вручную, построив дерево всех путей графа";
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("https://intuit.ru/studies/courses/648/504/lecture/11475?page=2");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlStat.SetProgress(4, "L1");
            UserControlActions.AddRecord("Лекция 'Кратчайший путь' просмотрена");
        }
    }
}
