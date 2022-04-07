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
    public partial class UserControlMinLection2 : UserControl
    {

        public UserControlMinLection2()
        {
            InitializeComponent();
            TextBlock.Text = "Данный алгоритм является алгоритмом на графах, который изобретен нидерландским ученым Э. Дейкстрой в 1959 году. Алгоритм находит кратчайшее расстояние от одной из вершин графа до всех остальных и работает только для графов без ребер отрицательного веса.\n" +
                "Шаг 1. Всем вершинам, за исключением первой, присваивается вес равный бесконечности, а первой вершине – 0.\n" +
                "Шаг 2.Все вершины не выделены.\n" +
                "Шаг 3.Первая вершина объявляется текущей.\n" +
                "Шаг 4.Вес всех невыделенных вершин пересчитывается по формуле: вес невыделенной вершины есть минимальное число из старого веса данной вершины, суммы веса текущей вершины и веса ребра, соединяющего текущую вершину с невыделенной.\n" +
                "Шаг 5.Среди невыделенных вершин ищется вершина с минимальным весом.Если таковая не найдена, то есть вес всех вершин равен бесконечности, то маршрут не существует.Следовательно, выход.Иначе, текущей становится найденная вершина. Она же выделяется.\n" +
                "Шаг 6.Если текущей вершиной оказывается конечная, то путь найден, и его вес есть вес конечной вершины.\n" +
                "Шаг 7.Переход на шаг 4.\n" +
                "D - массив кратчайших путей, где D[i] - где D[i] - кратчайший путь от 1 вершины к i (если путь не существует ставится INF)\n" +
                "S - множество вершин, до которых найден кратчайший путь\n" +
                "W - текущая вершина, до которой было найдено кратчайшее расстояние в предыдущей итерации\n" +
                "i - номер итерации";
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("https://www.youtube.com/watch?v=-cuoV89nRGo&t=428s");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlStat.SetProgress(4, "L2");
            UserControlActions.AddRecord("Лекция 'Алгоритм Дейкстры' просмотрена");
        }
    }
}
