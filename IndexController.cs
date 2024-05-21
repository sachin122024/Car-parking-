using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carparking1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.EnterpriseServices.CompensatingResourceManager;

namespace Carparking1.Controllers
{
    public class IndexController : Controller
    {
        
        // GET: Index
        //[HttpPost]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact cont)
        {
            DbContext db = new DbContext();
           var  data = db.Contact(cont);

            if (data == true)
            {
                ModelState.Clear();
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        // user insert

        [HttpGet]
        public ActionResult userInsert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult userInsert(register reg)
        {
            DbContext db = new DbContext();
            bool check = db.insertRegister(reg);
            if (check == true)
            {
                return RedirectToAction("userList"); 
            }
            return View();
        }

        //user List

        public ActionResult userList()
        {
            DbContext db = new DbContext();
            List<register> user = db.Getuser();
            return View(user);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DbContext dbc = new DbContext();
            var row = dbc.Getuser().Find(Model =>Model.Id == id);
            return View(row); 
        }

        [HttpPost]
        public ActionResult Edit(register reg)
        {
            DbContext db = new DbContext();
            bool check = db.userUpdate(reg);
            if (check == true)
            {
                
                ViewBag.Message = "Data updated";
                return RedirectToAction("userList");

            }
            else
            {
                ViewBag.Message = "Data not updated";
            }
            return View();
        }


        // user delete action

        [HttpGet]
        public ActionResult Delete(int id)
        {
            DbContext dbc = new DbContext();
            var row = dbc.Getuser().Find(Model => Model.Id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(register reg)
        {
            DbContext db = new DbContext();
            bool check = db.userDelete(reg);
            if (check == true)
            {
               
                ViewBag.Message = "Data Deleted";
                return RedirectToAction("userList");

            }
            else
            {
                ViewBag.Message = "Data not Deleted";
            }
            return View();
        }


        /*
         
        public ActionResult Login(string username, string password)
        {
            login obj = new login();

            string ConnectionString = "server=DESKTOP-CSSP1KT;Initial Catalog=carParking;Integrated Security=true;";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into login values('"+username+"','"+password+"')",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            con.Close();
            


            return View();
        }

        

        */

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registration(register reg)
        {
            DbContext db = new DbContext();

            bool check = db.insertRegister(reg);

            if (check == true)
            {
                ModelState.Clear();
            }
            return View();

        }




        //Method


        


       










    }
}