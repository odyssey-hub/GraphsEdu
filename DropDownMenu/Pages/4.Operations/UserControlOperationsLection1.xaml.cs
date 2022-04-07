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
    public partial class UserControlOperationsLection1 : UserControl
    {

        public UserControlOperationsLection1()
        {
            InitializeComponent();
            TextBlock.Text = "Минимальное остовное дерево (или минимальное покрывающее дерево) в связанном взвешенном неориентированном графе — это остовное дерево этого графа, имеющее минимальный возможный вес, где под весом дерева понимается сумма весов входящих в него рёбер. \n" +
                "Задача о нахождении минимального остовного дерева часто встречается в подобной постановке: допустим, есть n городов, которые необходимо соединить дорогами, так, чтобы можно было добраться из любого города в любой другой (напрямую или через другие города). Разрешается строить дороги между заданными парами городов и известна стоимость строительства каждой такой дороги. Требуется решить, какие именно дороги нужно строить, чтобы минимизировать общую стоимость строительства. \n" +
                "Эта задача может быть сформулирована в терминах теории графов как задача о нахождении минимального остовного дерева в графе, вершины которого представляют города, рёбра — это пары городов, между которыми можно проложить прямую дорогу, а вес ребра равен стоимости строительства соответствующей дороги. ";
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("https://www.youtube.com/watch?v=vm_9-vnV7PE");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlActions.AddRecord("Лекция 'Минимальный остов графа' пройдена");
            UserControlStat.SetProgress(3, "L1");
        }
    }
}
