using Database;
using Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Workshop
{
    /// <summary>
    /// Interaction logic for AddRepair.xaml
    /// </summary>
    public partial class AddRepair : Window
    {
        List<Category> categories;
        List<Mechanic> mechanics;
        string vin = null;

        public AddRepair(string vin)
        {
            this.vin = vin;
            categories = Repository.FillCollection<Category>("workshop_get_categories", new { });
            mechanics = Repository.FillCollection<Mechanic>("workshop_all_mechanics", new { });


            foreach (Mechanic singleMechanic in mechanics)
                mechanicsComboBox.Items.Add(singleMechanic);

            foreach (Category singleCat in categories)
                categoryComboBox.Items.Add(singleCat);
        }

        private void categoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Repository repository = new Repository();
            partsComboBox.Items.Clear();
            List<Part> parts = Repository.FillCollection<Part>("workshop_get_parts_by_category", new { category_id = ((Category)categoryComboBox.SelectedItem).ID });

            foreach (Part singlePart in parts)
                partsComboBox.Items.Add(singlePart);
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Repository.InsertObject("workshop_insert_repair", new {
                vin = vin,
                price = Double.Parse(repairPrice.Text.ToString()),
                mileage = Int32.Parse(mileage.Text.ToString()),
                repair_date = DateTime.Parse(repairDate.Text),
                mechanic_id = ((Mechanic)mechanicsComboBox.SelectedItem).ID,
                parts_rice = Double.Parse(partsPrice.Text.ToString())
            });
        }
    }
}
