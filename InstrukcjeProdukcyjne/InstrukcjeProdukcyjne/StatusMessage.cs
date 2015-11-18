using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne
{
    
    public class StatusMessage
    {
        public StatusMessage(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
