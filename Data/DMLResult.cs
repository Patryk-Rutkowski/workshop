namespace Data
{
    public class DMLResult
    {

        public int Count { get; set; }

        public bool Success { get { return Count > 0; } }

    }
}
