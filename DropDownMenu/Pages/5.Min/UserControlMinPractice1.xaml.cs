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
    public partial class UserControlMinPractice1 : UserControl
    {
        private DiagramLink[] links;
        public UserControlMinPractice1()
        {
            InitializeComponent();
            BuildDiagram();
        }


        private void BuildDiagram()
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
            links = new DiagramLink[13];
            int i = 0;
            links[i++] = createLink(A, B, 4);
            links[i++] = createLink(A, C, 1);
            links[i++] = createLink(B, C, 1);
            links[i++] = createLink(B, D, 3);
            links[i++] = createLink(B, C, 1);
            links[i++] = createLink(B, E, 2);
            links[i++] = createLink(E, G, 2);
            links[i++] = createLink(C, F, 7);
            links[i++] = createLink(D, G, 3);
            links[i++] = createLink(D, F, 1);
            links[i++] = createLink(F, G, 1);
            links[i++] = createLink(B, G, 5);
            links[i++] = createLink(C, D, 5);
            

            var layout = new SpringLayout();
            diagram2.Behavior = Behavior.MoveNodes;
            layout.Arrange(diagram2);
            //ShapeNode[] mnodes = { A, B, C, D, E, F, G};
            //nodes = mnodes;
        }

        private DiagramLink createLink(ShapeNode origin, ShapeNode dest, int num)
        {
            var link = diagram2.Factory.CreateDiagramLink(origin, dest);
            link.Text = num.ToString();
            return link;
        }

        private void diagram_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void diagram2_LinkClicked(object sender, LinkEventArgs e)
        {
            e.Link.TextBrush = Brushes.Red;
            e.Link.Stroke = Brushes.Red;
            e.Link.HeadStroke = Brushes.Red;
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                UserControlStat.SetProgress(4, "P1");
                UserControlActions.AddRecord("Практическое задание 'Нахождение кратчайшего пути' выполнено");
                MessageBox.Show("Молодец, всё правильно!");
            }
            else
            {
                MessageBox.Show("Неправильный кратчайший путь");
            }
        }


        private bool check()
        {
            bool isCorrect = true;
            for (int i = 0; i < links.Length; i++)
            {
                if (i == 0 || i == 5 || i == 6)
                {
                    if (links[i].Stroke != Brushes.Red) isCorrect = false;
                    continue;
                }
                if (links[i].Stroke == Brushes.Red) isCorrect = false;
            }
            return isCorrect;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            diagram2.ClearAll();
            BuildDiagram();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
