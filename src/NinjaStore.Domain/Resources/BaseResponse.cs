using System;
using System.Collections.Generic;
using System.Text;

namespace NinjaStore.Domain.Resources
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Success = false;
            Result = string.Empty;
            Message = string.Empty;
        }
        public bool Success { get; set; }
        public object Result { get; set; } 
        public string Message { get; set; }
    }
}
