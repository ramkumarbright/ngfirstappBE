using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstAppServices
{
    public static class Extensions
    {
        public static Users GetPayLoad(RequestModel input)
        {

            return (Users)input.Payload;

            //return Convert.ChangeType(input, typeof(T));
        }
    }
}