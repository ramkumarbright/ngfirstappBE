using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FS_API
{
    public class ResultViewModel
    {
        public object Response { get; set; }
        public string Error { get; set; }
    }

    public class RequestModel
    {
        public object Payload { get; set; }
        public string Headers { get; set; }
    }
}