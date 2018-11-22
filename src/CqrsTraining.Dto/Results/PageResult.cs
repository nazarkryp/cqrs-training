using System.Collections.Generic;

namespace CqrsTraining.Dto.Results
{
    public class PageResult<T>
    {
        public PageResult(IEnumerable<T> data, int offset, int size, int total)
        {
            Data = data;
            Offset = offset;
            Size = size;
            Total = total;
        }

        public IEnumerable<T> Data { get; set; } 

        public int Offset { get; set; }

        public int Size { get; set; }

        public int Total { get; set; }
    }
}
