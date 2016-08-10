namespace Models
{
    public class Mechanic
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int ID { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
