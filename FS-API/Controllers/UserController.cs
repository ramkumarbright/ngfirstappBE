using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FS_API.Controllers
{
    public class UserController : ApiController
    {

        // GET api/<controller>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1111", "value2" };
        //}

        [HttpGet]
        public ResultViewModel Get(int? id=null)
        {
            var rest = new ResultViewModel();
            try
            {
                rest.Response = UserDL.GetAllUsers(id);
            }
            catch (Exception ex)
            {

                rest.Error = ex.Message;
               // throw;
            }
            return rest;
        }


        public ResultViewModel Post(RequestModel req)
        {
            var res = new ResultViewModel();
            try
            {
                //UserDL dl = new UserDL();
                var data = Extensions.GetPayLoad(req);
                res.Response = UserDL.AddUser(data);
                // TODO: Add insert logic here

                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return res;
        }
    }

  



    // // GET api/<controller>/5
    // public string Get(int id)
    // {
    //     return "value";
    // }

    // // POST api/<controller>
    // public void Post([FromBody]string value)
    // {
    // }

    // // PUT api/<controller>/5
    // public void Put(int id, [FromBody]string value)
    // {
    // }

    // // DELETE api/<controller>/5
    // public void Delete(int id)
    // {
    // }
}
