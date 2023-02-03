using NPOI.SS.Formula.Functions;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Shared.Model
{
    public class ResponseGeneric<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; } 
    }
}
