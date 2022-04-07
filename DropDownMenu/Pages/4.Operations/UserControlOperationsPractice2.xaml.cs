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
    public partial class UserControlOperationsPractice2 : UserControl
    {
        private ShapeNode[] nodes;
        public UserControlOperationsPractice2()
        {
            InitializeComponent();
            BuildDiagram();
            clearColor();
        }

        private void BuildDiagram()
        {
            Rect nodeBounds = new Rect(0, 0, 50, 50);
            var A = diagram2.Factory.CreateShapeNode(nodeBounds);
            var B = diagram2.Factory.CreateShapeNode(nodeBounds);
            var C = diagram2.Factory.CreateShapeNode(nodeBounds);
            var D = diagram2.Factory.CreateShapeNode(nodeBounds);
            var E = diagram2.Factory.CreateShapeNode(nodeBounds);
            var F = diagram2.Factory.CreateShapeNode(nodeBounds);
            var G = diagram2.Factory.CreateShapeNode(nodeBounds);
            var H = diagram2.Factory.CreateShapeNode(nodeBounds);
            diagram2.Factory.CreateDiagramLink(A, B);
            diagram2.Factory.CreateDiagramLink(A,C);
            diagram2.Factory.CreateDiagramLink(B, C);
            diagram2.Factory.CreateDiagramLink(B, E);
            diagram2.Factory.CreateDiagramLink(B, G);
            diagram2.Factory.CreateDiagramLink(C, D);
            diagram2.Factory.CreateDiagramLink(C, E);
            diagram2.Factory.CreateDiagramLink(D, F);
            diagram2.Factory.CreateDiagramLink(E, F);
            diagram2.Factory.CreateDiagramLink(E, H);
            diagram2.Factory.CreateDiagramLink(G, H);
            diagram2.Factory.CreateDiagramLink(H, F);

            var layout = new SpringLayout();
            diagram2.Behavior = Behavior.MoveNodes;
            layout.Arrange(diagram2);
            ShapeNode[] mnodes = { A, B, C, D, E, F, G, H};
            nodes = mnodes;
        }

        private void diagram2_NodeDoubleClicked(object sender, MindFusion.Diagramming.Wpf.NodeEventArgs e)
        {
            clearColor();
            if (textBox.Text == "") return;
            e.Node.Text = textBox.Text;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
        }

        private bool checkSort()
        {
            clearColor();
            List<ShapeNode> error_nodes = new List<ShapeNode>();
            bool isSorted = true;
            foreach(var node in nodes)
            {
                int node_num = 0;
                try
                {
                    node_num = Convert.ToInt32(node.Text);
                } catch (Exception)
                {
                    return false;
                }
                foreach (var link in node.GetAllOutgoingLinks())
                {
                    int destination_num = Convert.ToInt32(link.Destination.Text);
                    if (node_num > destination_num)
                    {
                        error_nodes.Add(node);
                        isSorted = false;
                    }
                }
            }
            if (isSorted == false)
            {
                colorError(error_nodes);
            }
            return isSorted;
        }

        private void colorError(List<ShapeNode> list)
        {
            foreach(var node in list)
            {
                node.Brush = Brushes.Red;
            }
        }

        private void clearColor()
        {
            foreach(var node in nodes)
            {
                node.Brush = Brushes.LightBlue;
            }
        }

        private void clearText()
        {
            foreach (var node in nodes)
            {
                node.Text = "";
            }
        }


        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (checkSort())
            {
                UserControlStat.SetProgress(3, "P2");
                UserControlActions.AddRecord("Практическое задание 'Топологическая сортировка' выполнено");
                MessageBox.Show("Молодец, всё правильно!");
            }
            else
            {
                MessageBox.Show("Граф не отсортирован");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            clearColor();
            clearText();
        }

        private void diagram_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
            }
            catch (Exception)
            {
                textBox.Text = "";
            }
        }
    }
}
