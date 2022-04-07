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
    public partial class UserControlOperationsLection2 : UserControl
    {

        public UserControlOperationsLection2()
        {
            InitializeComponent();
            TextBlock.Text = "Топологически отсортированным называется такой граф, в котором любое ребро ведёт от вершины с меньшим номером к вершине с большим номером";
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText("https://habr.com/ru/post/100953/");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlActions.AddRecord("Лекция 'Топологически пройденный граф' просмотрена");
            UserControlStat.SetProgress(3, "L2");
        }
    }
}
