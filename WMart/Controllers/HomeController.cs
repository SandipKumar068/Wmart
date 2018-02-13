using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WMart.Models;

namespace WMart.Controllers
{

    
    public class HomeController : Controller
    {
        private WMartEntities db = new WMartEntities();
        
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
        public ActionResult RsvpForm([Bind(Include = "CId,Name,CEmail,CPhone,Status")] Attend attend)
        {
            if (string.IsNullOrEmpty(attend.Name))
            {
                ModelState.AddModelError("Name", "Please enter Name");
            }
            if (string.IsNullOrEmpty(attend.CEmail))
            {
                ModelState.AddModelError("CEmail", "Please enter Email");
            }
            if (!string.IsNullOrEmpty(attend.CEmail))
            {
            Regex emailRegex = new Regex(".+@.+.com+");
            if (!emailRegex.IsMatch(attend.CEmail))
                ModelState.AddModelError("CEmail", "Please enter valid email");
            }
            if (string.IsNullOrEmpty(attend.CPhone))
            {
                ModelState.AddModelError("CPhone", "Please enter Phone");
            }
           



            
            if (ModelState.IsValid)
            {
                db.Attends.Add(attend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
                 
            else
            {
                return View();
            }

           
        }
           
           
        

        public ActionResult Example()
        {
            return View();
        }

    }
}