using BeautySolutions.View.ViewModel;
using DropDownMenu.Classes;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow main;

        public MainWindow()
        {           
            InitializeComponent();
            main = this;
            //Script();
            LoadStat();
            BuildMenu();
            
            
        }

        private void Script()
        {
            List<Question> questions = new List<Question>();
            string storagePath = Directory.GetCurrentDirectory() + "\\Questions";
            var fileStorage = new List<string[]>();
            try
            {
                var filePaths = Directory.GetFiles(storagePath, "*.txt");
                var sortedPaths = filePaths.ToList<string>();
                sortedPaths.Sort(new FileComparer());
                foreach (string path in sortedPaths)
                {
                    string[] fileLines = System.IO.File.ReadAllLines(path, Encoding.UTF8);
                    if (fileLines[0].Contains("�"))
                    {
                        fileLines = System.IO.File.ReadAllLines(path, Encoding.Default);
                    }

                    fileStorage.Add(fileLines);
                }
                foreach (string[] fileLines in fileStorage)
                {
                    string question = fileLines[0];
                    string ans1 = fileLines[1];
                    string ans2 = fileLines[2];
                    string ans3 = fileLines[3];
                    string ans4 = fileLines[4];
                    string correct = fileLines[5];
                    questions.Add(new Question(question, ans1, ans2, ans3, ans4, correct));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream("SQLite1.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, questions);
            }
        }
        private List<ProgressItem> progressItems;
        private List<ProgressItem> LoadStat()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("PSQLite.dat", FileMode.OpenOrCreate))
            {
                progressItems = (List<ProgressItem>)formatter.Deserialize(fs);
            }
            return progressItems;
        }

        public static List<SubItem> subItems =  new List<SubItem>();
        public static StackPanel menu;
        private void BuildMenu()
        {
            var menuTypes = new List<SubItem>();
            menuTypes.Add(CreateSubItem(0,"L1", "Л. Типы графов", new UserControlTypesLection1()));
            menuTypes.Add(CreateSubItem(0, "P1", "П1. Типы графов ", new UserControlTypesPractice1()));
            menuTypes.Add(CreateSubItem(0, "P2", "П2. Типы графов", new UserControlTypesPractice2()));
            menuTypes.Add(CreateSubItem(0, "T", "Тест", new Test1()));
            var itemTypes = new ItemMenu("Основы", menuTypes, PackIconKind.ShareVariant);
            Menu.Children.Add(new UserControlMenuItem(itemTypes, this));

            var menuMatrix = new List<SubItem>();
            menuMatrix.Add(CreateSubItem(1, "L1", "Л. Матрицы", new UserControlMatrixLection1()));
            menuMatrix.Add(CreateSubItem(1, "P1", "П1. Матрицы", new UserControlMatrixPractice1()));
            menuMatrix.Add(CreateSubItem(1, "P2", "П2. Матрицы", new UserControlMatrixPractice2()));
            menuMatrix.Add(CreateSubItem(1, "T", "Тест", new Test2()));
            var itemMatrix = new ItemMenu("Задание графа", menuMatrix, PackIconKind.Apps);
            Menu.Children.Add(new UserControlMenuItem(itemMatrix, this));

            var menuAlg = new List<SubItem>();
            menuAlg.Add(CreateSubItem(2, "L1", "Л1. Обход в глубину", new UserControlAlgsLection1()));
            menuAlg.Add(CreateSubItem(2, "P1", "П1. Обход в глубину", new UserControlAlgsPractice1()));
            menuAlg.Add(CreateSubItem(2, "L2", "Л2. Обход в ширину", new UserControlAlgsLection2()));
            menuAlg.Add(CreateSubItem(2, "P2", "П2. Обход в ширину", new UserControlAlgsPractice2()));
            menuAlg.Add(CreateSubItem(2, "T", "Тест", new Test3()));
            var itemAlg = new ItemMenu("Обходы графа",menuAlg,PackIconKind.Graphql);
            Menu.Children.Add(new UserControlMenuItem(itemAlg, this));

            var menuOperations = new List<SubItem>();
            menuOperations.Add(CreateSubItem(3, "L1", "Л1. Мин.остов", new UserControlOperationsLection1()));
            menuOperations.Add(CreateSubItem(3, "P1", "П1. Мин.остов", new UserControlOperationsPractice1()));
            menuOperations.Add(CreateSubItem(3, "L2", "Л2. Топ. сортировка", new UserControlOperationsLection2()));
            menuOperations.Add(CreateSubItem(3, "P2", "П2. Топ. сортировка", new UserControlOperationsPractice2()));
            menuOperations.Add(CreateSubItem(3, "T", "Тест", new Test4()));
            var itemOperations = new ItemMenu("Операции", menuOperations, PackIconKind.Settings);
            Menu.Children.Add(new UserControlMenuItem(itemOperations, this));

            var menuMin = new List<SubItem>();
            menuMin.Add(CreateSubItem(4, "L1", "Л1. Нахождение кратч. пути", new UserControlMinLection1()));
            menuMin.Add(CreateSubItem(4, "P1", "П1. Нахождение кратч. пути", new UserControlMinPractice1()));
            menuMin.Add(CreateSubItem(4, "L2", "Л2. Алгоритм Дейкстры", new UserControlMinLection2()));
            menuMin.Add(CreateSubItem(4, "P2", "П2. Алгоритм Дейкстры", new UserControlMinPractice2()));
            menuMin.Add(CreateSubItem(4, "T", "Тест", new Test5()));
            var itemMin = new ItemMenu("Кратчайший путь", menuMin, PackIconKind.Infinity);
            Menu.Children.Add(new UserControlMenuItem(itemMin, this));

            var menuTest = new List<SubItem>();
            menuTest.Add(CreateSubItem(5, "T", "Начать тест", new FinalTest()));
            var itemTest = new ItemMenu("Итоговый тест",menuTest,PackIconKind.CheckBox);
            Menu.Children.Add(new UserControlMenuItem(itemTest, this));

            var menuStat = new List<SubItem>();
            menuStat.Add(new SubItem("Прогресс",new UserControlStat()));
            menuStat.Add(new SubItem("Действия", new UserControlActions()));
            var itemStat = new ItemMenu("Статистика", menuStat, PackIconKind.ChartBar);
            Menu.Children.Add(new UserControlMenuItem(itemStat, this));

            menu = Menu;
        }

       

        public void Update()
        {
            menu.Children.Clear();
            subItems.Clear();
            LoadStat();
            BuildMenu();
        }


        private SubItem CreateSubItem(int i, string param, string name, UserControl us)
        {
            var SubItem = new SubItem(name, us);
            int field = 0;
            switch (param)
            {
                case "L1": field = progressItems[i].L1;break;
                case "L2": field = progressItems[i].L2; break;
                case "P1": field = progressItems[i].P1; break;
                case "P2": field = progressItems[i].P2; break;
                case "T": field = progressItems[i].T; break;
            }
            if (field == 1) SubItem.Color = Brushes.LightGreen;
            subItems.Add(SubItem);
            return SubItem;
        }


        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if(screen!=null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) Environment.Exit(0);
            if (result == MessageBoxResult.No) return;
        }

        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /*
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) Environment.Exit(0);
            if (result == MessageBoxResult.No) return;
            */
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            } catch (Exception)
            {

            }
            
        }

        private void PackIcon_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Update();
        }

        private void PackIcon_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Update();
        }

        private void PackIcon_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
    class FileComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int numberx = Convert.ToInt32(System.IO.Path.GetFileName(x).Trim(".txt".ToCharArray()));
            int numbery = Convert.ToInt32(System.IO.Path.GetFileName(y).Trim(".txt".ToCharArray()));
            if (numberx > numbery)
            {
                return 1;
            }
            else if (numberx < numbery)
            {
                return -1;
            }
            return 0;
        }
    }
}

