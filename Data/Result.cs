using Data;

namespace Data
{
    public class Result<T>
    {

        public T Data { get; set; }
        public string Message { get; set; } = null;
        public bool Success { get; set; } = true;

        public Result(T data)
        {
            this.Data = data;
        }

        public void ErrorIfDataNull()
        {
            if (Data == null)
            {
                //TODO Zapis do tabeli z errorami
                Success = false;
                Message = "Nie znaleziono obiektu";
            }
                
        }

        public void InsertCheck()
        {
            DMLResult insertResult = (DMLResult)(object)Data;
            if (!insertResult.Success)
            {
                //TODO Zapis do tabeli z errorami
                Success = false;
                Message = "";
            }
        }

    }
}
