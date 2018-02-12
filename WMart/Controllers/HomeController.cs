using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMart.Models;

namespace WMart.Controllers
{
    public class HomeController : Controller
    {
        int a = 6;
        // GET: Home
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning Sir" : "Good Afternoon Sir";
            
            return View();
        }
        //Creating new ActionResult for URL 
        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RsvpForm(GuestResponse wmart)
        {
            string constr = ConfigurationManager.ConnectionStrings["MvcConn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                {
                    string query = "INSERT INTO Attend(Name, CEmail, CPhone, Status) VALUES(@Name,@CEmail,@CPhone,@Status)";
                    query += " SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@Name", wmart.Name);
                        cmd.Parameters.AddWithValue("@CEmail", wmart.CEmail);
                        cmd.Parameters.AddWithValue("@CPhone", wmart.CPhone);
                        cmd.Parameters.AddWithValue("@Status", wmart.Status);

                        wmart.Name = Convert.ToString(cmd.ExecuteScalar());
                       
                        con.Close();
                    }
                }
            }

            return View(wmart);
        }

        public ActionResult Example()
        {
            return View();
        }

    }
}