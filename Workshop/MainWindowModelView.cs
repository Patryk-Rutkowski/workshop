using Data;
using NLog;
using Resolvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WorkshopServices;

namespace Workshop
{
    public class MainWindowModelView : INotifyPropertyChanged
    {
        public ICarService _carSrvice;
        public Car car_;
        public List<int> year;
        public List<Car> listCar;
        public List<Make> carMake;
        public List<CarModel> CarModel;
        public int selectedYear;
        public int selectedMakeIndex = -1;
        public int selectedModelIndex = -1;
        public string selectedMake;
        public string selectedModel;
        public bool selectedButton = false;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowModelView()
        {
            selectedYear = 0;
            _carSrvice = ICarServiceResolver.Get();
            car_ = new Car();
            listCar = new List<Car>();
            year = new List<int>();
            Yearbook = getDate();
            Make = getAllMake();
            
            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Debug("log message");
        }

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

        public List<int> Yearbook
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Yearbook");
            }
        }

        public int SelectedYearbook
        {
            get { return selectedYear; }
            set
            {
                selectedYear = value;
                OnPropertyChanged("SelectedYearbook");
                if (allSelected())
                {
                    ListCar = GetCarMakeModelYearbook();
                }
            }
        }

        public List<Make> Make
        {
            get { return carMake; }
            set
            {
                carMake = value;
                OnPropertyChanged("Make");
            }
        }

        public string SelectedMake
        {
            get { return selectedMake; }
            set
            {
                selectedMake = value;
                Model = getAllModel();
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

        public string SelectedModel
        {
            get { return selectedModel; }
            set
            {
                selectedModel = value;
                OnPropertyChanged("SelectedModel");
                if (allSelected())
                {
                    ListCar = GetCarMakeModelYearbook();
                }
            }

        }
        public int SelectedModelIndex
        {
            get { return selectedModelIndex; }
            set
            {
                selectedModelIndex = value;
                OnPropertyChanged("SelectedModel");
                if (allSelected())
                {
                    ListCar = GetCarMakeModelYearbook();
                }
            }
        }

        public bool OnButton
        {
            get { return selectedButton; }
            set
            {
                selectedButton = value;
                OnPropertyChanged("OnButton");
            }
        }

        public Car SelectedListCar
        {
            get { return car_; }
            set
            {
                car_ = value;
                OnButton = true;
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
        public ICommand AddRepairHistory { get { return new RelayCommand(AddRepairVin, VinExcute); } }
        public ICommand RepairHistory { get { return new RelayCommand ( HistoryRepair, VinExcute); } }
        public ICommand GetCar { get { return new RelayCommand(GettingCar, VinExcute); } }
        public void GettingCar()
        {
            listCar = null;
            car_.Vin = Vin;
            ListCar = null;
            ListCar = GetCarClick();
        }

        public bool VinExcute()
        {
            return !CarExist(car_);
        }

        public bool CarExist(Car _car)
        {
            return false;
        }

        public List<Car> GetCarClick()
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
        public void HistoryRepair()
        {
            RepairHistory repairHistory = new RepairHistory(SelectedListCar.Vin);
            repairHistory.Show();
        }
        public void AddRepairVin()
        {
            AddRepair repairAdd = new AddRepair(SelectedListCar.Vin);
            repairAdd.Show();
        }


        public List<Car> GetCarMakeModelYearbook()
        {
            List<Car> car_ = new List<Car>();
            Result<List<Car>> car = _carSrvice.GetByModelMarkYearbook(SelectedMake, SelectedModel, SelectedYearbook);
            if (car.Success)
            {
                foreach (Car singleCar in car.Data)
                    car_.Add(singleCar);
                return car_;
            }
            else
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
                Result<List<CarModel>> model = _carSrvice.GetModelByMake(SelectedMake);
                List<CarModel> car_ = new List<CarModel>();
                foreach (CarModel singleModel in model.Data)
                
                    car_.Add(singleModel);
                return car_;
            } 
             else
                 return null;
        }

        public bool allSelected()
        {
            if (selectedCarMake() && (SelectedModelIndex > -1) &&(SelectedYearbook > -1) )
            {
                    return true;
             }
            else
                return false;
        }
    }
    
}


