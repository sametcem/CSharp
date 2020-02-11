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

namespace Task03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var w = new Window2();
            w.Show();
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
           var w3i4 = new Window1();
           w3i4.Show();
        }

        private void ButtonBase_OnClick3(object sender, RoutedEventArgs e)
        {
            var studentedit = new StudentEditDialog();
            studentedit.Show();
        }
    }

    
}
