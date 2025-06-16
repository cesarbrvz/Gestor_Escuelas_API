using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorEscuelas.Utils
{
    public class ResultOperation<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static ResultOperation<T> SuccessResult(T data, string? message = null)
        {
            return new ResultOperation<T> { Success = true, Data = data, Message = message };
        }

        public static ResultOperation<T> FailureResult(string message)
        {
            return new ResultOperation<T> { Success = false, Message = message };
        }
    }
}
