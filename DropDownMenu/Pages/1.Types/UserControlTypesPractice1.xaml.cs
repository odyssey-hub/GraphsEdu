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
    public partial class UserControlTypesPractice1 : UserControl
    {

        public UserControlTypesPractice1()
        {
            InitializeComponent();
            BuildDiagram();
           
        }

        private void BuildDiagram()
        {
            
            Rect nodeBounds = new Rect(0, 0, 50, 50);
            var nodeA = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeA.Text = "A";
            var nodeB = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeB.Text = "B";
            var nodeC = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeC.Text = "C";
            var nodeD = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeD.Text = "D";
            var nodeE = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeE.Text = "E";
            var nodeF = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeF.Text = "F";
            diagram.Factory.CreateDiagramLink(nodeB, nodeA).Text =  "5";
            diagram.Factory.CreateDiagramLink(nodeA, nodeE).Text = "4";
            diagram.Factory.CreateDiagramLink(nodeE, nodeF).Text = "7";
            diagram.Factory.CreateDiagramLink(nodeF, nodeA).Text = "1";
            diagram.Factory.CreateDiagramLink(nodeE, nodeD).Text = "4";
            diagram.Factory.CreateDiagramLink(nodeD, nodeC).Text = "3";
            diagram.Factory.CreateDiagramLink(nodeC, nodeB).Text = "2";

            diagram.Behavior = MindFusion.Diagramming.Wpf.Behavior.MoveNodes;
            var layout = new SpringLayout();
            layout.Arrange(diagram);
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (checkType() && checkNumber() && checkCycle())
            {
                MessageBox.Show("Всё правильно, молодец!");
                UserControlActions.AddRecord("Практическое занятие 'Определение вида графа' пройдено ");
                UserControlStat.SetProgress(0, "P1");
               
            }
            if (!checkType()) MessageBox.Show("Неверно определен один из видов графа");
            else if (!checkNumber()) MessageBox.Show("Неверное цикломатическое число");
            else if (!checkCycle()) MessageBox.Show("Неверно определен контур");
        }

        private bool checkType()
        {
            bool[] checks = { (bool)check1.IsChecked, (bool)check2.IsChecked, (bool)check3.IsChecked, (bool)check4.IsChecked, (bool)check5.IsChecked, (bool)check6.IsChecked };
            if (ComboBox.SelectedIndex == 1 && !checks[0] && !checks[1] && !checks[2] && checks[3] && checks[4] && !checks[5]) return true;
            else return false;
        }

        private bool checkNumber()
        {
            if (CycleNumber.Text == "2") return true;
            else return false;
        }

        private bool checkCycle()
        {
            if (Kontur.Text == "AEDCBA" || Kontur.Text == "EDCBAE" || Kontur.Text == "DCBAED" || Kontur.Text == "CBAEDC" || Kontur.Text == "BAEDCB"
                 || Kontur.Text == "AEFA" || Kontur.Text == "EFAE" || Kontur.Text == "FAEF") return true;
            else return false;
        }

        private void diagram_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
