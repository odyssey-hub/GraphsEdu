using DropDownMenu.Pages._4.Operations;
using MindFusion.Diagramming.Wpf;
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
    public partial class UserControlOperationsPractice1 : UserControl
    {
        private ShapeNode[] nodes;
        public UserControlOperationsPractice1()
        {
            InitializeComponent();
            BuildSkull();
        }

        private void BuildSkull()
        {
            Rect nodeBounds = new Rect(0, 0, 50, 50);
            var A = diagram2.Factory.CreateShapeNode(nodeBounds);
            A.Text = "A";
            var B = diagram2.Factory.CreateShapeNode(nodeBounds);
            B.Text = "B";
            var C = diagram2.Factory.CreateShapeNode(nodeBounds);
            C.Text = "C";
            var D = diagram2.Factory.CreateShapeNode(nodeBounds);
            D.Text = "D";
            var E = diagram2.Factory.CreateShapeNode(nodeBounds);
            E.Text = "E";
            var F = diagram2.Factory.CreateShapeNode(nodeBounds);
            F.Text = "F";
            var G = diagram2.Factory.CreateShapeNode(nodeBounds);
            G.Text = "G";
            var H = diagram2.Factory.CreateShapeNode(nodeBounds);
            H.Text = "H";
            var I = diagram2.Factory.CreateShapeNode(nodeBounds);
            I.Text = "I";
            var layout = new SpringLayout();
            diagram2.Behavior = Behavior.DrawLinks;
            layout.Arrange(diagram2);
            ShapeNode[] mnodes = { A, B, C, D, E, F, G, H, I };
            nodes = mnodes;
        }

        private void diagram_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            Practice1ModuleWindow window = new Practice1ModuleWindow();
            window.Show();
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (checkSkull())
            {
                UserControlActions.AddRecord("Практическое задание 'Построение минимального остова графа' пройдено");
                UserControlStat.SetProgress(3, "P1");
                MessageBox.Show("Молодец, всё правильно!");
            }
            else
            {
                MessageBox.Show("Минимальный остов построен неверно");
            }
        }

        private bool checkSkull()
        {
            bool isCorrect = true;
            //A
            int score = 0;
            foreach (var link in nodes[0].GetAllLinks())
            {
                if (link.Destination == nodes[1] || link.Destination == nodes[3] || link.Destination == nodes[4]
                    || link.Origin == nodes[1] || link.Origin == nodes[3] || link.Origin == nodes[4]) score++;
            }
            if (score < 3) isCorrect = false;
            //B
            if (nodes[1].GetAllLinks().Count != 1) isCorrect = false;
            //C
            score = 0;
            foreach (var link in nodes[2].GetAllLinks())
            {
                if (link.Destination == nodes[8] || link.Destination == nodes[7] || link.Destination == nodes[4]
                    || link.Origin == nodes[7] || link.Origin == nodes[8] || link.Origin == nodes[4]) score++;
            }
            if (score < 3) isCorrect = false;
            //D
            if (nodes[3].GetAllLinks().Count != 1) isCorrect = false;
            //E
            if (nodes[4].GetAllLinks().Count != 2) isCorrect = false;
            //F
            score = 0;
            foreach (var link in nodes[5].GetAllLinks())
            {
                if (link.Destination == nodes[7] || link.Destination == nodes[6]
                    || link.Origin == nodes[7] || link.Origin == nodes[6]) score++;
            }
            if (score < 2) isCorrect = false;
            //G
            if (nodes[6].GetAllLinks().Count != 1) isCorrect = false;
            //H
            if (nodes[7].GetAllLinks().Count != 2) isCorrect = false;
            //I
            if (nodes[8].GetAllLinks().Count != 1) isCorrect = false;
            return isCorrect;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            diagram2.ClearAll();
            BuildSkull();
        }

        private void diagram2_LinkCreating(object sender, LinkValidationEventArgs e)
        {
            e.Link.HeadShape = null;
        }
    }
}
