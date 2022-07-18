using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class HttpResponse
    {
        public string Message { get; set; }
        public int Code { get; set; }

        public Stream Stream { get; set; }
        public object Data { get; set; }
        public HttpResponse()
        {

        }
        public HttpResponse(string Message, int Code)
        {
            this.Message = Message;
            this.Code = Code;
        }
    }

}
