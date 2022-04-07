using DropDownMenu.Classes;
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
    /// Interaction logic for UserControlProviders.xaml
    /// </summary>
    public partial class UserControlProviders : UserControl
    {
        public List<Record> records;
        public UserControlProviders()
        {
            InitializeComponent();
            
            
        }

        private void datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            records = new List<Record>();
            records.Add(new Record("Проверка"));
            records.Add(new Record("Проверка2"));
            records.Add(new Record("Проверка3"));
            records.Add(new Record("Проверка3"));
            records.Add(new Record("Проверка3"));
            records.Add(new Record("Проверка3"));
            records.Add(new Record("Проверка3"));
            records.Add(new Record("Проверка3"));
            records.Add(new Record("Проверка3"));
            records.Add(new Record("Проверка3"));
            records.Add(new Record("Проверка3"));
            records.Add(new Record("Проверка3"));
            records.Add(new Record("Проверка3"));
            datagrid.ItemsSource = records;
            datagrid.IsReadOnly = true;
        }
    }
}
