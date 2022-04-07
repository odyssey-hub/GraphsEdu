using System.Windows.Controls;
using System.Windows.Media;

namespace BeautySolutions.View.ViewModel
{
    public class SubItem
    {
        public SubItem(string name, UserControl screen = null)
        {
            Name = name;
            Screen = screen;
            Color = Brushes.White;
        }

        public string Name { get; private set; }
        public UserControl Screen { get; private set; }
        public Brush Color { get; set; }


    }
}