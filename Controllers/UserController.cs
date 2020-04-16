using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstAppServices.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult GetUser()
        {
            return Json("hello world",JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddUser(RequestModel req)
        {
            var res = new ResultViewModel();
            try
            {
                UserDL dl = new UserDL();
                var data = Extensions.GetPayLoad(req);
                res.Response = dl.AddUser(data);
                // TODO: Add insert logic here

                //return RedirectToAction("Index");
            }
            catch
            {
               
            }

            return Json(res, JsonRequestBehavior.DenyGet);
        }


        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
