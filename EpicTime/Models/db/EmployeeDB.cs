using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace EpicTime.Models
{
    public class EmployeeDB
    {
        public static IQueryable<Employee> GetAll()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Employees;
        }

        public static Employee Get(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Employees.FirstOrDefault(x => x.Id == id);
        }

        public static Employee GetByUserId(string userId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Employees.FirstOrDefault(x =>x.ApplicationUserId == userId);
        }

        public static void Update(Employee employee)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static int Create(Employee employee)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return employee.Id;
            }
        }

        public static void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Employee employee = db.Employees.FirstOrDefault(c => c.Id == id);
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }
    }
}