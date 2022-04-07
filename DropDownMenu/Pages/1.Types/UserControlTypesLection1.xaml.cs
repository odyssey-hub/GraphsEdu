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
    public partial class UserControlTypesLection1 : UserControl
    {

        public UserControlTypesLection1()
        {
            InitializeComponent();
            

            TextBlock.Text = "1.Граф — абстрактный математический объект, представляющий собой множество вершин графа и набор рёбер, то есть соединений между парами вершин. \n"
            + "2.Связный граф — набор вершин и связей между ними. Это означает, что между любой парой вершин этого графа существует как минимум один путь. \n"
            + "3.Ориентированный граф(кратко орграф) — граф, рёбрам которого присвоено направление. Неориентированный граф -у ребёр нет направлений \n"
            + "4.Смешанным называют граф, в котором имеются рёбра хотя бы двух из упомянутых трёх разновидностей(звенья, дуги, петли). \n"
            + "5.Мультиграфом называется граф, в котором пары вершин могут быть соединены более чем одним ребром, то есть содершащий кратные рёбра, но не содержащий петель. \n"
            + "6.Граф без дуг(то есть неориентированный), без петель и кратных рёбер называется обыкновенным. \n"
            + "7.Граф заданного типа называют полным, если он содержит все возможные для этого типа рёбра(при неизменном множестве вершин). \n"
            + "8.Взвешенный граф — граф, каждому ребру которого поставлено в соответствие некое значение(вес ребра). \n"
            + "9.Эйлеровым циклом(путем) графа называется цикл(путь), содержащий все ребра графа ровно один раз.Граф, обладающий эйлеровым циклом, называется эйлеровым графом. \n"
            + "10.Цикломатическое число графа -для связных графов равно m(число вершин)-n(число рёбер) + 1\n"
            + "11.Путь - последовательность вершин, в которой каждая вершина соединена со следующим ребром. \n "
            + "12.Контур - путь, начальная и конечная вершины которого совпадают.";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlStat.SetProgress(0, "L1");
            UserControlActions.AddRecord("Лекция 'Типы и виды графов' просмотрена");

        }


        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("https://function-x.ru/graphs2_definitions_classes.html");
            
        }
    }
}
