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
    public partial class UserControlMatrixPractice1 : UserControl
    {

        public UserControlMatrixPractice1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            BuildDiagram();
            TextBox[,] matrixBoxesAdj = { { M11, M12, M13, M14, M15 }, { M21, M22, M23, M24, M25 }, { M31, M32, M33, M34, M35 },
                { M41, M42, M43, M44, M45 },  { M51,M52,M53,M54,M55} };
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    matrixBoxesAdj[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                    matrixBoxesAdj[i, j].VerticalAlignment = VerticalAlignment.Center;
                    matrixBoxesAdj[i, j].Text = "0";
                    matrixBoxesAdj[i, j].HorizontalContentAlignment = HorizontalAlignment.Center;
                    matrixBoxesAdj[i, j].SelectionStart = 1;
                    matrixBoxesAdj[i, j].SelectionLength = 1;
                    var g1 = matrixBoxesAdj[i, j].BorderThickness;
                    g1.Bottom = 0;
                    matrixBoxesAdj[i, j].BorderThickness = g1;
                }
            TextBox[,] matrixBoxesInc = { { R11, R12, R13, R14, R15 ,R16}, { R21, R22, R23, R24, R25 , R26},
            { R31, R32, R33, R34, R35, R36 }, { R41, R42, R43, R44, R45, R46 }, { R51, R52, R53, R54, R55 , R56}};
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 6; j++)
                {
                    matrixBoxesInc[i, j].HorizontalAlignment = HorizontalAlignment.Center;
                    matrixBoxesInc[i, j].VerticalAlignment = VerticalAlignment.Center;
                    matrixBoxesInc[i, j].Text = "0";
                    matrixBoxesInc[i, j].HorizontalContentAlignment = HorizontalAlignment.Center;
                    matrixBoxesInc[i, j].SelectionStart = 1;
                    matrixBoxesInc[i, j].SelectionLength = 1;
                    var g1 = matrixBoxesInc[i, j].BorderThickness;
                    g1.Bottom = 0;
                    matrixBoxesInc[i, j].BorderThickness = g1;
                }
        }

        private TextBox[,] getMatrixInc()
        {
            TextBox[,] matrixBoxesInc = { { R11, R12, R13, R14, R15 ,R16}, { R21, R22, R23, R24, R25 , R26},
            { R31, R32, R33, R34, R35, R36 }, { R41, R42, R43, R44, R45, R46 }, { R51, R52, R53, R54, R55 , R56}};
            return matrixBoxesInc;
        }

        private TextBox[,] getMatrixAdj()
        {
            TextBox[,] matrixBoxesAdj = { { M11, M12, M13, M14, M15 }, { M21, M22, M23, M24, M25 }, { M31, M32, M33, M34, M35 },
                { M41, M42, M43, M44, M45 },  { M51,M52,M53,M54,M55} };
            return matrixBoxesAdj;
        }


        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            bool checkadj = checkAdj(getMatrixAdj());
            bool checkinc = checkInc(getMatrixInc());
            if (checkadj && checkinc)
            {
                UserControlStat.SetProgress(1, "P1");
                UserControlActions.AddRecord("Практическое задание 'Нахождение матриц по графу' пройдено");
                MessageBox.Show("Молодец, всё правильно!");
            } else if (!checkadj && !checkinc)
            {
                MessageBox.Show("Обе матрицы заполнены неверно");
                
            } else if (!checkinc)
            {
                MessageBox.Show("Матрица инцидентности заполнена неверно");
            } else
            {
                MessageBox.Show("Матрица смежности заполнена неверно");
            }
        }

        private bool checkAdj(TextBox[,] Matrix)
        {
            Matrix = getMatrixAdj();
            string[,] answer = { {"0","5","0","6","8"}, { "0", "0", "7", "0", "0" },
            {"0","0","0","0","0"}, {"0","0","0","0","4"}, {"0","0","3","0","0"}};
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (String.Compare(Matrix[i, j].Text, answer[i, j]) != 0) return false;
                }
            return true;
        }

        private bool checkInc(TextBox[,] Matrix)
        {
            Matrix = getMatrixInc();
            string[,] answer = { {"0","0","0","0","0", "0"}, { "5", "0", "0", "0", "0","0"},
            {"0","0","0","0","3","7"}, {"0","0","6","0","0","0"}, {"0","8","0","4","0","0"}};
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 6; j++)
                {
                    if (String.Compare(Matrix[i, j].Text, answer[i, j]) != 0) return false;
                }
            return true;
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
            var AB = diagram.Factory.CreateDiagramLink(nodeA,nodeB);
            AB.Text = "5";
            var AE = diagram.Factory.CreateDiagramLink(nodeA,nodeE);
            AE.Text = "8";
            var AD = diagram.Factory.CreateDiagramLink(nodeA,nodeD);
            AD.Text = "6";
            var DE = diagram.Factory.CreateDiagramLink(nodeD,nodeE);
            DE.Text = "4";
            var EC = diagram.Factory.CreateDiagramLink(nodeE,nodeC);
            EC.Text = "3";
            var BC = diagram.Factory.CreateDiagramLink(nodeB,nodeC);
            BC.Text = "7";
            diagram.Behavior = MindFusion.Diagramming.Wpf.Behavior.MoveNodes;
            var layout = new AnnealLayout();
            layout.Arrange(diagram);
            
        }

        private void diagram_KeyDown(object sender, KeyEventArgs e)
        {
            BuildDiagram();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var layout = new AnnealLayout();
                layout.Arrange(diagram);
            }
            
        }
    }
}
