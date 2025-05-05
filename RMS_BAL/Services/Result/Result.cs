using RMS_BAL.Services.Result;
using RMS_Models.Models.API_Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_BAL.Services.Result
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        // Constructor for success
        public static Result<T> SuccessResult(T data)
        {
            return new Result<T> { Success = true, Data = data, Message = "Operation successful." };
        }

        // Constructor for failure with a message
        public static Result<T> FailureResult(string message)
        {
            return new Result<T> { Success = false, Message = message };
        }
<<<<<<< HEAD

        //internal static Result<CustomerTitle> SuccessResult(CustomerTitle updatedGroup)
        //{
        //    throw new NotImplementedException();
        //}
=======
        public static Result<T> ValidationResult(string message)
        {
            return new Result<T> { Success = true, Message = message };
        }

        public class ServiceResult<T> : ServiceResult
        {
            public T? Data { get; set; }
        }
>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274
    }
}



