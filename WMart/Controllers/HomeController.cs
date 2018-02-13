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
            if (!string.IsNullOrEmpty(attend.CEmail))
            {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(attend.CEmail))
                {
                    ModelState.AddModelError("CEmail", "Email is not valid");
                }
            }
            else
            {
                ModelState.AddModelError("CEmail", "Email is required");
            }
            if (!string.IsNullOrEmpty(attend.CPhone))
            {
                string phoneRegex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
                Regex re = new Regex(phoneRegex);
                if (!re.IsMatch(attend.CPhone))
                {
                    ModelState.AddModelError("CPhone", "Mobile No. is not valid");
                }
            }
            else
            {
                ModelState.AddModelError("CPhone", "Mobile No. is required");
            }
            //if (string.IsNullOrEmpty(attend.CPhone))
            //{
            //    ModelState.AddModelError("CPhone", "Please enter Phone");
            //}
           
            if (ModelState.IsValid)
            {
                db.Attends.Add(attend);
                db.SaveChanges();
                return RedirectToAction("Example");
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