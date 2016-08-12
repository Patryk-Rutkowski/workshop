using Database;
using Extensions;
using Data;
using System.Windows;
using WorkshopServices;
using WorkshopServices.Implementation;
using System.Collections.Generic;
using System;
using System.Windows.Controls;

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
            DateTime a = DateTime.Now;
            int actualYear = a.Year;
            int minYear = 1950;
            InitializeComponent();
            _carSrvice = new CarService(new CarRepository());

            Result<List<Make>> car = _carSrvice.GetAvailableMakes();
            foreach(Make singleCar in car.Data)
                make_combo.Items.Add(singleCar);
          
            for(int i = actualYear;  i >= minYear; i-- )
                yearbokk_combo.Items.Add(i);
        }

        private void getCar_Click(object sender, RoutedEventArgs e)
        {
            Result<Car> car = _carSrvice.GetByVin(vin.Text);
            if (car.Success)
            {
                    List<Car> list = new  List<Car>();
                    list.Add(car.Data); 
                    car_gird.ItemsSource = null;
                    car_gird.ItemsSource = list;
             }
            else
                MessageBox.Show(car.Message);
          }

        private void ChangeButtonState(bool state)
        {
            repair_history_button.IsEnabled = state;
            add_repair_button.IsEnabled = state;
            edit_button.IsEnabled = state;
            delete_button.IsEnabled = state;
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

        private void make_combo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ChangeButtonState(false);
            Result<List<CarModel>> model = _carSrvice.GetModelByMake(make_combo.SelectedItem.ToString());
            model_combo.Items.Clear();
            foreach (CarModel singleModel in model.Data)
                model_combo.Items.Add(singleModel);
        }

        private void model_combo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            car_gird.UnselectAll();
            if (yearbokk_combo.SelectedIndex > -1  && model_combo.SelectedIndex > -1 && make_combo.SelectedIndex > -1)
            {
                Result<List<Car>> car = _carSrvice.GetByModelMarkYearbook(make_combo.SelectedItem.ToString(), model_combo.SelectedItem.ToString(), Convert.ToInt32(yearbokk_combo.SelectedItem));
                if (car.Success)
                {
                    car_gird.ItemsSource = null;
                    car_gird.Items.Refresh();
                    car_gird.ItemsSource = car.Data;
                }
                else
                    MessageBox.Show(car.Message);
            }
        }

        private void car_gird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(car_gird.SelectedItem != null && car_gird.SelectedItem is Car)
                ChangeButtonState(true);
        }

        private void yearbokk_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeButtonState(false);
            if (yearbokk_combo.SelectedIndex > -1 && model_combo.SelectedIndex > -1 && make_combo.SelectedIndex > -1)
            {
                Result<List<Car>> car = _carSrvice.GetByModelMarkYearbook(make_combo.SelectedItem.ToString(), model_combo.SelectedItem.ToString(), Convert.ToInt32(yearbokk_combo.SelectedItem));
                if (car.Success)
                {
                    car_gird.ItemsSource = null;
                    car_gird.Items.Refresh();
                    car_gird.ItemsSource = car.Data;
                }
                else
                    MessageBox.Show(car.Message);
            }

        }

        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.Show();
        }
    }
}
