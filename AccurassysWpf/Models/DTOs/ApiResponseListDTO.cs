using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccurassysWpf.Models.DTOs
{
    public class ApiResponseListDTO<T>
    {
        public int TotalPages { get; set; }
        public List<T> GenericData { get; set; } = new List<T>();
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
