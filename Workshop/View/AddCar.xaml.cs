using System.Windows;

namespace Workshop
{
    public partial class AddCar : Window
    {
        public AddCar(string vin)
        {
            InitializeComponent();
            this.DataContext = new AddEditCarViewModel(vin);
        }

    }
}
