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
using System.Windows.Shapes;
using RetakePrep3Animal.Model;

namespace RetakePrep3Animal
{
   
    public partial class AddAnimal : Window
    {
        MainWindow _mainWindow;
        private int newID;

        public AddAnimal()
        {
            InitializeComponent();
        }

        public AddAnimal(List<Owner> owners, List<AnimalType> animalTypes,MainWindow main,int maxID)
        {
            InitializeComponent();
            ComboBoxOwner.ItemsSource = owners;
            ComboBoxAnimalType.ItemsSource = animalTypes;
            _mainWindow = main;
            newID = maxID + 1;
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            var newAnimal = new Animal
            {
                IdAnimal =  newID,
                Name = TextBoxName.Text,
                IdAnimalType = ((AnimalType)ComboBoxAnimalType.SelectedItem).IdAnimalType,
                IdOwner = ((Owner)ComboBoxOwner.SelectedItem).IdOwner
            };

            _mainWindow.AddnewAnimal(newAnimal);
            Close();
        }
        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
