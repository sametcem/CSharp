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

namespace ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Bu sekilde de tanımlayabiliriz.
            var item = new ListBoxItem();
            item.Content = "Element A";

            StudentsListBox.Items.Add(item);
        }

        private void StudentsListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Selection changed!");
        }
    }
}
