namespace Models
{
    public class Part
    {

        public int ID { get; set; }
        public string Name { get; set; }
        int CategoryID { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
