using System;

namespace Data
{
    public class Repair
    {

        public int ID { get; set; }
        public double Price { get; set; }
        public int Mileage { get; set; }
        public DateTime RepairDate { get; set; }
        public string VIN { get; set; }
        public int MechanicID { get; set; }
        public double PartsPrice { get; set; }
    }
}
