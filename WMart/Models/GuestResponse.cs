using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMart.Models
{
    public class GuestResponse
    {
       [Key] 
        public int CId { get; set; }

       
        public string Name { get; set; }

       
       
        public string CEmail { get; set; }
       

       
        public string CPhone { get; set; }


        public string Status { get; set; }
    }
}