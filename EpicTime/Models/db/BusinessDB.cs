using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicTime.Models
{
    public class BusinessDB
    {
        public static int Create(Business business)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            db.Businesses.Add(business);
            db.SaveChanges();
            return business.Id;
        }
    }
}