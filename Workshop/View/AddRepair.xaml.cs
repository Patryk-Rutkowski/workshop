using Database;
using Data;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using Database.Interface;

namespace Workshop
{
    /// <summary>
    /// Interaction logic for AddRepair.xaml
    /// </summary>
    public partial class AddRepair : Window
    {

        public AddRepair(string numberVin)
        {
            this.DataContext = new AddRepairModelView(numberVin);
            InitializeComponent();
        }
    }
}
