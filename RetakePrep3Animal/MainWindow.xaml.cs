using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using RetakePrep3Animal.Model;

namespace RetakePrep3Animal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AnimDbCon db;

        public MainWindow()
        {
            InitializeComponent();
            db = new AnimDbCon();
            getSource();
        }


        public void getSource()
        {
           // var result = db.Animals.Include(e => e.AnimalType).Include(e => e.Owner).ToList();
           var result = db.Animals.ToList();
           AnimalDataGrid.ItemsSource = result;

        }

        private void Add_Button_OnClick(object sender, RoutedEventArgs e)
        {
            int maxID = 0;
            db.Animals.ToList().ForEach(p =>
            {
                if (p.IdAnimal > maxID)
                {
                    maxID = p.IdAnimal;
                }
            });
            Window a1 = new AddAnimal(db.Owners.ToList(),db.AnimalTypes.ToList(), this, maxID);
            a1.Show();
        }

        private void Delete_Button_OnClick_Button_OnClick(object sender, RoutedEventArgs e)
        {
            var anm = (Animal)AnimalDataGrid.SelectedItem;
            db.Animals.Remove(db.Animals.ToList().First(p => p.IdAnimal == anm.IdAnimal));
            db.SaveChanges();
            getSource();
        }

        private void AnimalDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int count = AnimalDataGrid.SelectedItems.Count;
            AnimalCount.Content = "You choosed " + count + " Animals";
        }

        public void AddnewAnimal(Animal newAnimal)
        {
            db.Animals.Add(newAnimal);
            db.SaveChanges();
            getSource();

        }
    }
}
