namespace CqrsTraining.Dto.Results
{
    public class DataResult<T>
    {
        public DataResult(T data)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
