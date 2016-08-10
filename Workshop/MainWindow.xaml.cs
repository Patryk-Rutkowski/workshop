using Database;
using Models;
using System.Windows;

namespace Workshop
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

        private void getCar_Click(object sender, RoutedEventArgs e)
        {
            string vinFromTextBox = vin.Text;
            Car car = Repository.FillObject<Car>("test", new { vin = vin.Text });

            if (car != null)
            {
                ChangeButtonState(true);
                made.Content = car.Make;
                model.Content = car.Model;
                yearbook.Content = car.Yearbook;
                engine.Content = car.Engine;
            }
        }

        private void ChangeButtonState(bool state)
        {
            repair_history_button.IsEnabled = state;
            add_repair_button.IsEnabled = state;
        }

        private void repair_history_button_Click(object sender, RoutedEventArgs e)
        {
            RepairHistory repairHistory = new RepairHistory(vin.Text);
            repairHistory.Show();
        }

        private void add_repair_button_Click(object sender, RoutedEventArgs e)
        {
            AddRepair addRepair = new AddRepair(vin.Text);
            addRepair.Show();
        }
    }
}
