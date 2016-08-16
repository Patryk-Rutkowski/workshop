using Database;
using Data;
using System.Collections.Generic;
using System.Windows;
using WorkshopServices.Interface;
using Database.Implementation;
using WorkshopServices.Implementation;

namespace Workshop
{
    /// <summary>
    /// Interaction logic for RepairHistory.xaml
    /// </summary>
    public partial class RepairHistory : Window
    {
        private IRepairService _carSrvice;

        public RepairHistory(string vin)
        {
            _carSrvice = new RepairService(new RepairRepository());
            InitializeComponent();
            AddData(vin);
        }

        private void AddData(string vin)
        {
           // List<RepairTablePresentation> repairs = Repository.FillCollection<RepairTablePresentation>("workshop_get_repair_historyby_vin", new { vin = vin });
           Result<List<RepairTablePresentation>> repairs = _carSrvice.GetRepairHistoryByVin(vin);
            repairsData.ItemsSource = repairs.Data;
        }
    }
}
