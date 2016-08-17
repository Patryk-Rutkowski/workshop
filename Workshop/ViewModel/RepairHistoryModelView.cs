using Data;
using Database.Implementation;
using Resolvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkshopServices.Implementation;
using WorkshopServices.Interface;

namespace Workshop
{
    class RepairHistoryModelView : INotifyPropertyChanged
    {
        public List<RepairTablePresentation> repairStory = new List<RepairTablePresentation>();
        private IRepairService _carSrvice;

        public RepairHistoryModelView(string vin)
        {
            _carSrvice = IRepairServiceResolver.Get();
            AddData(vin);
        }

        public event PropertyChangedEventHandler PropertyChanged;
       
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public List<RepairTablePresentation> ShowHistory
        {
            get { return repairStory; }
            set
            {
                repairStory = value;
                OnPropertyChanged("ShowHistory");
            }
        }
        private void AddData(string vin)
        {
            Result<List<RepairTablePresentation>> repairs = _carSrvice.GetRepairHistoryByVin(vin);
            ShowHistory = repairs.Data;
        }
       
    }
           
}
