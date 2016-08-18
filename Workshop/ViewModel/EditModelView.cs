using Data;
using Resolvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WorkshopServices;

namespace Workshop
{
   public class EditModelView : INotifyPropertyChanged
    {
        public EditModelView(string vin, string makeCar, string modelCar, int yearCar, string engineCar)
        {
            vinNumber = vin;
            make = makeCar;
            model = modelCar;
            year = yearCar;
            engine = engineCar;

        }
        public event PropertyChangedEventHandler PropertyChanged;
        private string make;
        private string vinNumber;
        private string model;
        private int year;
        private string engine;
        private ICarService _carService = ICarServiceResolver.Get();

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Vin
        {
            get { return vinNumber; }
            set
            {
                vinNumber = value;
                OnPropertyChanged("Vin");
            }
        }
        public string Make
        {
            get { return make; }
            set
            {
                make = value;
                OnPropertyChanged("Make");
            }
        }
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                OnPropertyChanged("Model");
            }
        }

        public string Engine
        {
            get { return engine; }
            set
            {
                engine = value;
                OnPropertyChanged("Engine");
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        public ICommand EditCar { get { return new RelayCommand(Add, AllExist); } }
        public bool AllExist()
        {
            if (Vin != null && Make != null && Model != null && Year != 0 && Engine != null)
                return true;
            else
                return false;
        }
        private void Add()
        {
            Result<DMLResult> result = _carService.UpdateCar(Make, Model, Year, Engine, Vin);
            MessageBox.Show("Zmieniles auto poprawnie");
        }
    }
}
