using MindFusion.Diagramming.Wpf;
using MindFusion.Diagramming.Wpf.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class UserControlAlgsLection2 : UserControl
    {

        public UserControlAlgsLection2()
        {
            InitializeComponent();
            BuildDiagram();
            
        }
        private ShapeNode[] nodes;
        private void BuildDiagram()
        {
            Rect nodeBounds = new Rect(0, 0, 50, 50);
            var A = diagram.Factory.CreateShapeNode(nodeBounds);
            A.Text = "A";
            var B = diagram.Factory.CreateShapeNode(nodeBounds);
            B.Text = "B";
            var C = diagram.Factory.CreateShapeNode(nodeBounds);
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
            diagram.Factory.CreateDiagramLink(A, B).HeadShape = null;
            diagram.Factory.CreateDiagramLink(A, C).HeadShape = null;
            diagram.Factory.CreateDiagramLink(A, D).HeadShape = null;
            diagram.Factory.CreateDiagramLink(A, E).HeadShape = null;
            diagram.Factory.CreateDiagramLink(B, F).HeadShape = null;
            diagram.Factory.CreateDiagramLink(F, H).HeadShape = null;
            diagram.Factory.CreateDiagramLink(D, G).HeadShape = null;
            diagram.Factory.CreateDiagramLink(G, I).HeadShape = null;
            var layout = new TreeLayout();
            layout.Type = TreeLayoutType.Centered;
            diagram.Behavior = MindFusion.Diagramming.Wpf.Behavior.MoveNodes;
            layout.Arrange(diagram);
            ShapeNode[] mnodes = { A, B, C, D, E, F, G, H, I};
            nodes = mnodes;
        }
        private int i = 0;
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (i == 9)
            {
                labelPath.Content = "Последовательность: ";
                ClearColor();
                i = 0;
            }
            
            Step(nodes[i]);
            i++;
        }
        private void ClearColor()
        {
            foreach (var node in nodes)
            {
                node.Brush = Brushes.LightBlue;
            }
        }

        private void Step(ShapeNode node)
        {
            node.Brush = Brushes.OrangeRed;
            labelPath.Content += node.Text;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UserControlActions.AddRecord("Лекция 'Обход в ширину' просмотрена");
            UserControlStat.SetProgress(2, "L2");
        }
    }
}
