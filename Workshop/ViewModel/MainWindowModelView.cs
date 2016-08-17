using Data;
using Database;
using Extensions;
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
using WorkshopServices.Implementation;

namespace Workshop
{
    public class MainWindowModelView : INotifyPropertyChanged
    {
        public ICarService _carSrvice;
        public Car car_;
        public Car car__;
        public List<int> year;
        public List<Car> listCar;
        public List<Make> carMake;
        public List<CarModel> CarModel;
        public int selectedYear;
        public int selectedCarIndex = -1;
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
            car__ = new Car();
            listCar = new List<Car>();
            year = new List<int>();
            Yearbook = getDate();
            Make = getAllMake();
        }

  

        public string Vin
        {
            get { return car__.Vin; }
            set
            {
                car__.Vin = value;
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
                    ListCar = GetCarMakeModelYearbook();
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
                    ListCar = GetCarMakeModelYearbook();
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
        public int SelectedCarIndex
        {
            get { return selectedCarIndex; }
            set
            {
                selectedCarIndex = value;
                OnPropertyChanged("SelectedCarIndex");
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
        public ICommand AddCar { get { return new RelayCommand(CreateCar, NewCar); } }
        public ICommand EditCar {  get { return new RelayCommand(Edit, VinExcute); } }

        private void Edit()
        {
            if (selectedCarIndex > -1)
            {
                Edit edit = new Edit(SelectedListCar.Vin, SelectedListCar.Make, SelectedListCar.Model, SelectedListCar.Yearbook, SelectedListCar.Engine);
                edit.Show();
            }
            else
                MessageBox.Show("Wybierz samochod", "Error");
        }

        private bool NewCar()
        {
            return true;
        }

        private void CreateCar()
        {
            AddCar newCar = new AddCar();
            newCar.Show();
        }


        public void GettingCar()
        {
            listCar = null;
            ListCar = null;
            car__.Vin = Vin;
            ListCar = GetCarClick();
        }

        public bool VinExcute()
        {
            return !CarExist(car_);
        }

        public bool CarExist(Car _car)
        {
            if(_car == null)
            return false;
            else
            {
                _car = new Car();
                return false;
            }
        }

        public List<Car> GetCarClick()
        {

            Result<Car> car = _carSrvice.GetByVin(car__.Vin);
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
            if (selectedCarIndex > -1)
            {
                RepairHistory repairHistory = new RepairHistory(SelectedListCar.Vin);
                repairHistory.Show();
            }
            else
                MessageBox.Show("Wybierz samochod", "Error");
        }
        public void AddRepairVin()
        {
            if (selectedCarIndex <= -1)
                MessageBox.Show("Wybierz samochod", "Error");
            else
            {
                AddRepair repairAdd = new AddRepair(SelectedListCar.Vin);
                repairAdd.Show();
            }
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


