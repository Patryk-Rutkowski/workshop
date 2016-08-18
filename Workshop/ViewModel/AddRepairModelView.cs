using Data;
using Database;
using Database.Implementation;
using Database.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WorkshopServices;
using WorkshopServices.Implementation;
using WorkshopServices.Interface;

namespace Workshop
{
    public class AddRepairModelView : INotifyPropertyChanged
    {
        public List<Category> categories = new List<Category>();
        public List<ComboBoxMechanic> mechanics;// = new Result<List<Mechanic>>();
        public List<ComboBoxPart> parts;
        public ObservableCollection<ComboBoxPart> czesci = new ObservableCollection<ComboBoxPart>();
        private int indexCategory = -1;
        private int cenaNaprawy;
        private int cenaCzesci;
        private string vin = null;
        string przebieg;
        private ComboBoxMechanic mechanik;
        private DateTime data = DateTime.Now;
        private ComboBoxPart nazwaCzesci;
        public event PropertyChangedEventHandler PropertyChanged;
        public IMechanicsService _mechanicsRepository;
        public ICategoryService _categoryRepository;
        public IPartService _partRepository;
        public IRepairService _repairRepository;


        public AddRepairModelView(string vinNumber)
        {
            vin = vinNumber;
            Initialize();
        }

        private void Initialize()
        {
            _mechanicsRepository = new MechanicsService(new MechanicsRepository());
            _categoryRepository = new CategoryService(new CategoryRepository());
            _partRepository = new PartService(new PartRepository());
            _repairRepository = new RepairService(new RepairRepository());
            Mechanics = GetAllMechanics();
            GetAllCategory = GetCategory();
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<ComboBoxMechanic> Mechanics
        {
            get { return mechanics; }
            set
            {
                mechanics = value;
                OnPropertyChanged("Mechanics");
            }
        }

        public List<Category> GetAllCategory
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("GetAllCategory");
            }
        }

        public List<ComboBoxPart> GetParts
        {
            get { return parts; }
            set
            {
                parts = value;
                OnPropertyChanged("GetParts");
            }
        }

        public int CategoryIndex
        {
            get { return indexCategory; }
            set
            {
                indexCategory = value;
                GetParts = GetAllParts();
                OnPropertyChanged("CategoryName");
            }
        }
        public string Przebieg
        {
            get { return przebieg; }
            set
            {
                przebieg = value;
                OnPropertyChanged("Przebieg");
            }
        }

        public int CenaNaprawy
        {
            get { return cenaNaprawy; }
            set
            {
                cenaNaprawy = value;
                OnPropertyChanged("CenaNaprawy");
            }
        }

        public int CenaCzesci
        {
            get { return cenaCzesci; }
            set
            {
                cenaCzesci = value;
                OnPropertyChanged("CenaCzesci");
            }
        }

        public DateTime Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }
        public ComboBoxPart SelectedPart
        {
            get { return nazwaCzesci; }
            set
            {
                nazwaCzesci = value;
                OnPropertyChanged("SelectedPart");
            }
        }


        public ComboBoxMechanic SelectedMechanic
        {
            get { return mechanik; }
            set
            {
                mechanik = value;
                OnPropertyChanged("SelectedMechanic");
            }
        }
        public ObservableCollection<ComboBoxPart> SetParts
        {
            get { return czesci; }
            set
            {
                czesci = value;
                OnPropertyChanged("SetParts");
            }
        }
        public ICommand AddPart { get { return new RelayCommand(SetPartToList, CheckValue); } }

        public ICommand AddAll { get { return new RelayCommand(ExecuteOrder, CheckAll); } }

        private bool CheckAll()
        {
            if (CenaNaprawy != 0 && CenaCzesci != 0 && Przebieg != null && data != null && czesci.Count != 0)
                return true;
            else
                return false;
        }

        private void ExecuteOrder()
        {
            int[] partsId = new int[czesci.Count];
            for (int i = 0; i < czesci.Count; i++)
            {
                partsId[i] = czesci[i].Id;
                MessageBox.Show(partsId[i].ToString());
            }
           Result<DMLResult> repair = _repairRepository.CreateNewRepair(vin,Convert.ToDouble(CenaNaprawy), Convert.ToInt32(Przebieg), data, SelectedMechanic.Id, Convert.ToDouble(CenaCzesci), partsId);
        }

        public List<ComboBoxMechanic> GetAllMechanics()
        {
            List<ComboBoxMechanic> mechanicsAll = new List<ComboBoxMechanic>();
            Result<List<ComboBoxMechanic>> mechaniker = _mechanicsRepository.GetIdNameMechanics();
            foreach (ComboBoxMechanic singleMechanic in mechaniker.Data)
                mechanicsAll.Add(singleMechanic);
            return mechanicsAll;
        }

        public List<Category> GetCategory()
        {
            List<Category> categoryAll = new List<Category>();
            Result<List<Category>> categories1 = _categoryRepository.GetAllCategories();
            foreach (Category singleCat in categories1.Data)
                categoryAll.Add(singleCat);
            return categoryAll;
        }

        public List<ComboBoxPart> GetAllParts()
        {
            List<ComboBoxPart> listParts = new List<ComboBoxPart>();
            Result<List<ComboBoxPart>> parts = _partRepository.GetPartsByCategory(indexCategory + 1);   // Repository.FillCollection<Part>("workshop_get_parts_by_category", new { category_id = SelectedName });
            foreach (ComboBoxPart singlePart in parts.Data)
                listParts.Add(singlePart);
            return listParts;
        }

        public void SetPartToList()
        {
            ComboBoxPart czesc = new ComboBoxPart();

            czesc= nazwaCzesci;
            czesci.Add(czesc);
            SetParts = czesci;
        }
        public bool CheckValue()
        {
            if (SelectedPart != null)
                return true;
            else
                return false;
        }
}

}

