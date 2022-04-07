using DropDownMenu.Classes;
using MindFusion.Diagramming.Wpf.Layout;
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
    /// Interaction logic for UserControlDashboard.xaml
    /// </summary>
    public partial class UserControlActions : UserControl
    {

        public static List<Record> records = new List<Record>();

        public UserControlActions()
        {
            InitializeComponent();
            LoadRecords();
        }

        private void LoadRecords()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<Record> list = new List<Record>();
            try
            {
                using (FileStream fs = new FileStream("ASQLite.dat", FileMode.OpenOrCreate))
                {
                    records = (List<Record>)formatter.Deserialize(fs);
                }
            } catch (Exception)
            {

            }
            
        }

        public static void AddRecord(string action)
        {
            Record record = new Record(action);
            record.ID = records.Count;
            records.Add(record);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream("ASQLite.dat", FileMode.OpenOrCreate))
                {

                    formatter.Serialize(fs, records);
                }
            } catch (Exception)
            {

            }
            
        }

        private void datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<Record> list = new List<Record>();
            int i = 0;
            try
            {
                using (FileStream fs = new FileStream("ASQLite.dat", FileMode.OpenOrCreate))
                {
                    list = (List<Record>)formatter.Deserialize(fs);
                }
            } 
            catch (Exception)
            {

            }
            datagrid.ItemsSource = list;
            datagrid.IsReadOnly = true;
        }


    }
}
