using Data;
using Database;
using Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WorkshopServices;
using WorkshopServices.Implementation;

namespace Workshop
{
    public class MainWindowModelView : INotifyPropertyChanged
    {
        private ICarService _carSrvice;
        private Car car_;
        public List<int> year;
        public List<Car> listCar;
        int selectedYear;
        private List<Make> CarMake;
        public string selectedMake;
        public int selectedMakeIndex = -1;
        private List<CarModel> CarModel;

        public string Vin
        {
            get { return car_.Vin; }
            set
            {
                car_.Vin = value;
                OnPropertyChanged("Vin");
            }

        }


        public List<Car> ListCar
        {
            get { return listCar; }
            set
            {
                listCar = value;
                OnPropertyChanged("ListCar");
            }
        }

        public List<int> yearBook
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("yearBook");
            }
        }

        public int SelectedYearBook
        {
            get { return selectedYear; }
            set
            {
                selectedYear = value;
                OnPropertyChanged("SelectedYearBook");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindowModelView()
        {
            selectedYear = 0;
            _carSrvice = new CarService(new CarRepository());
            car_ = new Car();
            listCar = new List<Car>();
            year = new List<int>();
            yearBook = getDate();
            Make = getAllMake();
            
        }

        public List<Make> Make
        {
            get { return CarMake; }
            set
            {
                CarMake = value;
                OnPropertyChanged("Make");
               // CarModel = getAllModel();
            }
        }
        public string SelectedMake
        {
            get { return selectedMake; }
            set
            {
                selectedMake = value;
                OnPropertyChanged("SelectedMake");
               
            }

        }
        public int SelectedMakeIndex
        {
            get { return selectedMakeIndex; }
            set
            {
                selectedMakeIndex = value;
                OnPropertyChanged("SelectedMakeIndex");
                
            }

        }

        public List<CarModel> Model
        {
            get { return CarModel; }
            set
            {
                CarModel = value;
                OnPropertyChanged("Model");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand getCar { get { return new RelayCommand(GettingCar, VinExcute); } }

        private void GettingCar()
        {
            listCar = null;
            car_.Vin = Vin;
            ListCar = getCarClick();
        }

        private bool VinExcute()
        {
            /*if (Vin != "" && Vin != null)
                return !CarExist(car_);
            else*/
            return !CarExist(car_);
        }

        private bool CarExist(Car _car)
        {
            return false;
        }

        public List<Car> getCarClick()
        {
            Result<Car> car = _carSrvice.GetByVin(car_.Vin);
            if (car.Success)
            {
                List<Car> list = new List<Car>();
                list.Add(car.Data);
                return list;
            }
            else
                MessageBox.Show(car.Message);
            return null;
        }

        public List<int> getDate()
        {
            List<int> year_ = new List<int>();
            DateTime a = DateTime.Now;
            int actualYear = a.Year;
            int minYear = 1950;
            for (int i = actualYear; i >= minYear; i--)
            {
                year_.Add(i);
            }
            return year_;
        }

        public List<Make> getAllMake()
        {
            List<Make> car_ = new List<Make>();
            Result<List<Make>> car = _carSrvice.GetAvailableMakes();
            foreach (Make singleCar in car.Data)
                car_.Add(singleCar);
            return car_;
        }

        public bool selectedCarMake()
        {
            if (selectedMakeIndex > -1)
                return true;
            else
                return false;

        }
         public List<CarModel> getAllModel()
         {
             if (selectedCarMake())
             {
                 Result<List<CarModel>> model = _carSrvice.GetModelByMake(selectedMake);
                 
                 foreach (CarModel singleModel in model.Data)
                     model.Data.Add(singleModel);
                 return model.Data;
             }
             else
                 return null;


         }
    
    }

}
