using Database;
using Models;
using System.Windows;
using WorkshopServices;
using WorkshopServices.Implementation;

namespace Workshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ICarService _carSrvice;

        public MainWindow()
        {
            InitializeComponent();
            _carSrvice = new CarService(new CarRepository());
        }

        private void getCar_Click(object sender, RoutedEventArgs e)
        {
            Car car = _carSrvice.GetByVin(vin.Text);

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
