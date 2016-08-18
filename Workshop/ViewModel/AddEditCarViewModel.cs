using Data;
using Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using WorkshopServices;
using WorkshopServices.Implementation;

namespace Workshop
{
    public class AddEditCarViewModel : INotifyPropertyChanged
    {
        private ICarService _carSrvice;
        Car car;

        public event PropertyChangedEventHandler PropertyChanged;
        //public ICommand getCar { get { return new RelayCommand(MakeChoosen); } }

        public string Vin
        {
            get { return car.Vin; }
            set { car.Vin = value; }
        }

        public string Make
        {
            get {
                Console.WriteLine("123");
                return car.Make; }
            set
            {
                Console.WriteLine("1234");
                car.Make = value;
                //OnPropertyChanged("MakeChoosen");
            }
        }

        public string Model
        {
            get { return car.Model; }
            set
            {
                car.Model = value;
            }
        }

        public int Yearbook
        {
            get { return car.Yearbook; }
            set { car.Yearbook = value; }
        }

        public string Engine
        {
            get { return car.Engine; }
            set { car.Engine = value; }
        }

        public List<Make> MakeList
        {
            get { return _carSrvice.GetAvailableMakes().Data; }
            set { return;  }
        }

        public string SelectedMake
        {
            get { return car.Make; }
            set
            {
                car.Make = value;
                OnPropertyChanged("Make");
            }
        }

        public AddEditCarViewModel(string vin)
        {
            _carSrvice = new CarService(new CarRepository());
            car = new Car();

            if (vin != null && vin != "")
                car = _carSrvice.GetByVin(vin).Data;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
