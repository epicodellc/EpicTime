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

            var employees = new List<Employee>();

            employees.Add(new Employee
            {
                Name = "Alex"
            });
            employees.Add(new Employee
            {
                Name = "Kyle"
            });
            employees.Add(new Employee
            {
                Name = "Bob"
            });
            employees.Add(new Employee
            {
                Name = "Hulk Hogan"
            });

            employees.ForEach(a => context.Employees.Add(a));

            context.SaveChanges();
        }
    }
}