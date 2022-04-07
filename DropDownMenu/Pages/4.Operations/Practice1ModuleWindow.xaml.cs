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
using System.Windows.Shapes;

namespace DropDownMenu.Pages._4.Operations
{
    /// <summary>
    /// Логика взаимодействия для Practice1ModuleWindow.xaml
    /// </summary>
    public partial class Practice1ModuleWindow : Window
    {
        public Practice1ModuleWindow()
        {
            InitializeComponent();
            BuildDiagram();
        }

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
            createLink(A, B,2);
            createLink(A, D, 3);
            createLink(A, E, 5);
            createLink(B, C, 10);
            createLink(C, E, 2);
            createLink(C, H, 5);
            createLink(C, I, 6);
            createLink(D, F, 8);
            createLink(F, H, 3);
            createLink(F, E, 7);
            createLink(F, G, 4);
            createLink(G, I, 11);


            var layout = new SpringLayout();
            diagram.Behavior = Behavior.MoveNodes;
            layout.Arrange(diagram);
        }

        private void createLink(ShapeNode origin, ShapeNode dest, int num)
        {
           var link = diagram.Factory.CreateDiagramLink(origin, dest);
            link.HeadShape = null;
            link.Text = num.ToString();
        }
    }

    
}
