using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EpicTime.Models
{
    public class EpicTimeDataBaseInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            //var employees = new List<Employee>();

            //employees.Add(new Employee
            //{
            //    FirstName = "Alex"
            //});
            //employees.Add(new Employee
            //{
            //    FirstName = "Kyle"
            //});
            //employees.Add(new Employee
            //{
            //    FirstName = "Bob"
            //});
            //employees.Add(new Employee
            //{
            //    FirstName = "Hulk",
            //    LastName = "Hogan"
            //});

            //employees.ForEach(a => context.Employees.Add(a));

            context.SaveChanges();
        }
    }
}