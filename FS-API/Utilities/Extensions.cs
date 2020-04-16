using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FS_API
{
    public static class Extensions
    {
        public static Users GetPayLoad(RequestModel input)
        {


            // Users obj = (Users)input.Payload;
            Users obj = JsonConvert.DeserializeObject<Users>(input.Payload.ToString());

            return obj;

            //return Convert.ChangeType(input, typeof(T));
        }
    }
}