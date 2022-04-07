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
    public partial class UserControlMatrixPractice2 : UserControl
    {
        private ShapeNode nodeA;
        private ShapeNode nodeB;
        private ShapeNode nodeC;
        private ShapeNode nodeD;
        private ShapeNode nodeE;
        public UserControlMatrixPractice2()
        {
            InitializeComponent();
            BuildDiagram();
            TextBox[,] matrixBoxesAdj = { { M11, M12, M13, M14, M15 }, { M21, M22, M23, M24, M25 }, { M31, M32, M33, M34, M35 },
                { M41, M42, M43, M44, M45 },  { M51,M52,M53,M54,M55} };
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    matrixBoxesAdj[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                    matrixBoxesAdj[i, j].VerticalAlignment = VerticalAlignment.Center;
                    if (matrixBoxesAdj[i, j].Text != "1") matrixBoxesAdj[i, j].Text = "0";
                    matrixBoxesAdj[i, j].HorizontalContentAlignment = HorizontalAlignment.Center;
                    matrixBoxesAdj[i, j].SelectionStart = 1;
                    matrixBoxesAdj[i, j].SelectionLength = 1;
                    var g1 = matrixBoxesAdj[i, j].BorderThickness;
                    g1.Bottom = 0;
                    matrixBoxesAdj[i, j].BorderThickness = g1;
                    matrixBoxesAdj[i, j].IsEnabled = false;
                }
        }



        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            bool a = CheckA();
            bool b = CheckB();
            bool c = CheckC();
            bool d = CheckD();
            bool E = CheckE();
            if (a && b && c && d && E)
            {
                UserControlStat.SetProgress(1, "P2");
                UserControlActions.AddRecord("Практическое задание 'Построение графа по матрице смежности' пройдено");
                MessageBox.Show("Молодец! Всё правильно!");
                return;
            }
            string error = "";
            if (!a) error += " Неверные дуги у вершины A \n";
            if (!b) error += " Неверные дуги у вершины B \n";
            if (!c) error += " Неверные дуги у вершины C \n";
            if (!d) error += " Неверные дуги у вершины D \n";
            if (!E) error += " Неверные дуги у вершины E \n";
            MessageBox.Show(error);   
        }

        private bool CheckA()
        {
            var collection = nodeA.GetAllOutgoingLinks();
            int score = 0;
            foreach (var link in collection)
            {
                var text = link.Destination.Text;
                if (text == "B" || text == "D")  score++;
            }
            if (score == 2) return true;
            else return false;
        }

        private bool CheckB()
        {
            var collection = nodeB.GetAllOutgoingLinks();
            int score = 0;
            foreach (var link in collection)
            {
                var text = link.Destination.Text;
                if (text == "C" || text == "D" || text == "E") score++;
            }
            if (score == 3) return true;
            else return false;
        }

        private bool CheckC()
        {
            var collection = nodeC.GetAllOutgoingLinks();
            int score = 0;
            foreach (var link in collection)
            {
                var text = link.Destination.Text;
                if (text == "E") score++;
            }
            if (score == 1) return true;
            else return false;
        }

        private bool CheckD()
        {
            var collection = nodeD.GetAllOutgoingLinks();
            int score = 0;
            foreach (var link in collection)
            {
                var text = link.Destination.Text;
                if (text == "D" || text == "E") score++;
            }
            if (score == 2) return true;
            else return false;
        }
        private bool CheckE()
        {
            var collection = nodeE.GetAllOutgoingLinks();
            int score = 0;
            foreach (var link in collection)
            {
                var text = link.Destination.Text;
                if (text == "E") score++;
            }
            if (score == 1) return true;
            else return false;
        }

        private void M11_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            ((TextBox)sender).Text = "";
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void BuildDiagram()
        {
            Rect nodeBounds = new Rect(0, 0, 50, 50); 
            nodeA = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeA.Text = "A";
            nodeB = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeB.Text = "B";
            nodeC = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeC.Text = "C";
            nodeD = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeD.Text = "D";
            nodeE = diagram.Factory.CreateShapeNode(nodeBounds);
            nodeE.Text = "E";

            //diagram.;
            //diagram.Behavior = MindFusion.Diagramming.Wpf.Behavior.MoveNodes;
            //diagram.Behavior = MindFusion.Diagramming.Wpf.Behavior.Modify;
            diagram.Behavior = Behavior.DrawLinks;
            var layout = new SpringLayout();
            //layout.Randomize = false;
            layout.Arrange(diagram);
            
            
        }

        private void diagram_KeyDown(object sender, KeyEventArgs e)
        {
            //BuildDiagram();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
           // var layout = new AnnealLayout();
           // layout.Arrange(diagram);
        }
    }
}
