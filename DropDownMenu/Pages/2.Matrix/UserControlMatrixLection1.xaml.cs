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
    public partial class UserControlMatrixLection1 : UserControl
    {

        public UserControlMatrixLection1()
        {
            InitializeComponent();
            TextBlock.Text = "Граф можно задать следующими способами:" +
            "1.Матрица смежности - это вид представления графа в виде матрицы, когда пересечение столбцов и строк задаёт дуги. Используя матрицу смежности, можно задать вес дуг и ориентацию. Каждая строка и столбец матрицы соответствуют вершинам, номер строки соответствует вершине, из которой выходит дуга, а номер столбца - в какую входит дуга."
 + "2.Матрица инцидентности — одна из форм представления графа, в которой указываются связи между инцидентными элементами графа(ребро(дуга) и вершина). Столбцы матрицы соответствуют ребрам, строки — вершинам.Ненулевое значение в ячейке матрицы указывает связь между вершиной и ребром(их инцидентность).";
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("https://graphonline.ru/wiki/%D0%A1%D0%BF%D1%80%D0%B0%D0%B2%D0%BA%D0%B0/%D0%9C%D0%B0%D1%82%D1%80%D0%B8%D1%86%D0%B0%D0%A1%D0%BC%D0%B5%D0%B6%D0%BD%D0%BE%D1%81%D1%82%D0%B8");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlActions.AddRecord("Лекция 'Матрица смежности и инцидентности' просмотрена");
            UserControlStat.SetProgress(1, "L1");
        }
    }
}
