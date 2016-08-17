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
        public RepairHistory(string vin)
        {
            this.DataContext = new RepairHistoryModelView(vin);
            InitializeComponent();
        }
    }
}
