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
    public partial class UserControlAlgsPractice2 : UserControl
    {
        private List<string> correct = new List<string>();
        public UserControlAlgsPractice2()
        {
            InitializeComponent();
            BuildDiagram();
            correctFill();
        }

        private void correctFill()
        {
            correct.Add("A");
            correct.Add("B");
            correct.Add("C");
            correct.Add("D");
            correct.Add("E");
            correct.Add("F");
            correct.Add("G");
            correct.Add("H");
            correct.Add("I");
            correct.Add("J");
            correct.Add("K");
        }


        private ShapeNode[] nodes;
        private void BuildDiagram()
        {
            Rect nodeBounds = new Rect(0, 0, 50, 50);
            var A = diagram.Factory.CreateShapeNode(nodeBounds);
            A.Text = "A";
            var B = diagram.Factory.CreateShapeNode(nodeBounds);
            B.Text = "B";
            var C= diagram.Factory.CreateShapeNode(nodeBounds);
            C.Text = "C";
            var D = diagram.Factory.CreateShapeNode(nodeBounds);
            D.Text = "D";
            var E = diagram.Factory.CreateShapeNode(nodeBounds);
            E.Text = "E";
            var F = diagram.Factory.CreateShapeNode(nodeBounds);
            F.Text = "F";
            var G = diagram.Factory.CreateShapeNode(nodeBounds);
            G.Text = "G";
            var H = diagram.Factory.CreateShapeNode(nodeBounds);
            H.Text = "H";
            var I = diagram.Factory.CreateShapeNode(nodeBounds);
            I.Text = "I";
            var J = diagram.Factory.CreateShapeNode(nodeBounds);
            J.Text = "J";
            var K = diagram.Factory.CreateShapeNode(nodeBounds);
            K.Text = "K";
            diagram.Factory.CreateDiagramLink(A, B).HeadShape = null;
            diagram.Factory.CreateDiagramLink(A, C).HeadShape = null;
            diagram.Factory.CreateDiagramLink(A, D).HeadShape = null;
            diagram.Factory.CreateDiagramLink(B, E).HeadShape = null;
            diagram.Factory.CreateDiagramLink(B, F).HeadShape = null;
            diagram.Factory.CreateDiagramLink(C, F).HeadShape = null;
            diagram.Factory.CreateDiagramLink(E, I).HeadShape = null;
            diagram.Factory.CreateDiagramLink(E, J).HeadShape = null;
            diagram.Factory.CreateDiagramLink(D, G).HeadShape = null;
            diagram.Factory.CreateDiagramLink(D, H).HeadShape = null;
            diagram.Factory.CreateDiagramLink(G, K).HeadShape = null;
            diagram.Factory.CreateDiagramLink(H, K).HeadShape = null;
            var layout = new SpringLayout();
            diagram.Behavior = Behavior.SelectOnly;
            layout.Arrange(diagram);

            ShapeNode[]  mnodes = {A,B,C,D,E,F,G,H,I,J,K};
            nodes = mnodes;
            ClearColor();
        }

        private void diagram_KeyDown(object sender, KeyEventArgs e)
        {
            var layout = new SpringLayout();
            layout.Arrange(diagram);
        }

        private bool checkDuplicate(string label)
        {
            foreach(var vertex in list)
            {
                if (vertex == label) return false;
            }
            return true;
        }

        private void ClearColor()
        {
            foreach (var node in nodes)
            {
                node.Brush = Brushes.LightBlue;
            }
        }
        private List<string> list = new List<string>();
        
        private void diagram_NodeClicked(object sender, MindFusion.Diagramming.Wpf.NodeEventArgs e)
        {
            
            if (!checkDuplicate(e.Node.Text)) return;
            
            e.Node.Brush = Brushes.OrangeRed;
            list.Add(e.Node.Text);
            labelPath.Content += e.Node.Text;
            if (list.Count == 11)
            {
                if (list.SequenceEqual(correct))
                {
                    UserControlActions.AddRecord("Практическое задание 'Обход в ширину' пройдено");
                    UserControlStat.SetProgress(2, "P2");
                    MessageBox.Show("Молодец, всё правильно!");
                    return;
                }
                else
                {
                    MessageBox.Show("Неверная последовательность");
                    ClearColor();
                    list.Clear();
                    labelPath.Content = "Последовательность:";
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearColor();
            list.Clear();
            labelPath.Content = "Последовательность:";
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
