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
    public partial class UserControlTypesPractice2 : UserControl
    {

        public UserControlTypesPractice2()
        {
            InitializeComponent();
            TextBlock.Text = "Задание: постройте граф, который будет обладать следующими свойствами:\n -Нет изолированных вершин\n -Содержит петли(хотя бы 1)\n -Полный\n";
            nodes = new List<DiagramNode>();
            BuildDiagram();
        }

        private void BuildDiagram()
        {
            diagram.AllowLinksRepeat = false;
            var layout = new GridLayout();
            layout.Arrange(diagram);
        }

        private void diagram_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void diagram_LinkCreating(object sender, MindFusion.Diagramming.Wpf.LinkValidationEventArgs e)
        {
            e.Link.HeadShape = null;
        }
        private int i = 1;
        private List<DiagramNode> nodes;
        private void diagram_NodeCreated(object sender, MindFusion.Diagramming.Wpf.NodeEventArgs e)
        {
            e.Node.Text = i.ToString();
            nodes.Add(e.Node);
            i++;
        }

        private bool checkConnectivity()
        {
            foreach(var node in diagram.Nodes)
            {
                int count = node.GetAllLinks().Count;
                if (checkLoopNode(node)) count--;
                if (count <= 0) return false;
            }
            return true;
        }

        private bool checkLoop()
        {
            foreach (var node in diagram.Nodes)
            {
                var links = node.GetAllLinks();
                foreach(var link in links)
                {
                    if (link.Destination == node && link.Origin == node) return true;
                }
            }
            return false;
        }

        private bool checkLoopNode(DiagramNode node)
        {
            var links = node.GetAllLinks();
            foreach (var link in links)
            {
                if (link.Destination == node && link.Origin == node) return true;
            }
            return false;
        }

        private int LoopsCount()
        {
            if (!checkLoop()) return 0;
            int count = 0;
            foreach (var node in diagram.Nodes)
            {
                var links = node.GetAllLinks();
                foreach (var link in links)
                {
                    if (link.Destination == node && link.Origin == node) count++;
                }
            }
            return count;
        }

        private bool checkFull()
        {
            int full_k = diagram.Nodes.Count - 1;
            foreach (var node in diagram.Nodes)
            {
                int local_linkscount = node.GetAllLinks().Count;
                if (checkLoopNode(node)) local_linkscount--;
                if (local_linkscount != full_k) return false;
            }
            return true;
        }

        private void btnAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (checkConnectivity() && checkLoop() && checkFull())
            {
                UserControlActions.AddRecord("Практическое задание 'Построение графа по параметрам' пройдено");
                UserControlStat.SetProgress(0, "P2");
                MessageBox.Show("Молодец, всё правильно!");
                return;
            }
            string error = "Граф не обладает следующими свойствами:\n";
            if (!checkConnectivity()) error += "Нет изолированных вершин\n";
            if (!checkLoop()) error += "Содержит петли\n";
            if (!checkFull()) error += "Полный\n";
            MessageBox.Show(error);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            diagram.ClearAll();
            nodes.Clear();
            i = 1;
        }
    }
}
