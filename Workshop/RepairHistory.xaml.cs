using Database;
using Models;
using System.Collections.Generic;
using System.Windows;

namespace Workshop
{
    /// <summary>
    /// Interaction logic for RepairHistory.xaml
    /// </summary>
    public partial class RepairHistory : Window
    {

        public RepairHistory(string vin)
        {
            InitializeComponent();
            AddData(vin);
        }

        private void AddData(string vin)
        {
            List<RepairTablePresentation> repairs = Repository.FillCollection<RepairTablePresentation>("workshop_repair_history_data", new { vin = vin });

            repairsData.ItemsSource = repairs;
        }
    }
}
