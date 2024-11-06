using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccurassysWpf.Models.DTOs
{
    public class ApiResponseDTO<T>
    {
        public int TotalPages { get; set; }
        public T GenericData { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
