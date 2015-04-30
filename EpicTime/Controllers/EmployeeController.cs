using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EpicTime.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EpicTime.Controllers
{
    public class EmployeeController : ApiController
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }

        public EmployeeController()
            : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())))
        {
        }

        public EmployeeController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }

        // GET: api/Employee
        public IQueryable GetEmployees()
        {
            var employees = EmployeeDB.GetAll().Select(x => new 
            { 
                id = x.Id,
                firstName= x.FirstName,
                lastName = x.LastName,
                email = x.Email,
                applicationUserId = x.ApplicationUserId,
                businessId = x.BusinessId
            });
            return employees;
        }

        // GET: api/Employee/5
        [ResponseType(typeof(Employee))]
        public HttpResponseMessage GetEmployee(int id)
        {
            Employee employee = EmployeeDB.Get(id);
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, employee);
        }

        // PUT: api/Employee/5
        public HttpResponseMessage PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            if (id != employee.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, employee);
            }

            EmployeeDB.Update(employee);

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
         
        // POST: api/Employee
        public HttpResponseMessage PostEmployee(CreateEmployeeVM createEmployeeVM)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            //check if user name exists

            //create user
            var userModel = new ApplicationUser() { UserName = createEmployeeVM.UserName };
            
            //get current employee logged in 
            Employee currentEmployee = EmployeeDB.GetByUserId(User.Identity.GetUserId());
            var result = UserManager.Create(userModel, "password");
            //create employee
            Employee newEmployee = new Employee() {
                ApplicationUserId = userModel.Id,
                BusinessId = currentEmployee.BusinessId, 
                Email = createEmployeeVM.Email, 
                FirstName = createEmployeeVM.FirstName, 
                LastName = createEmployeeVM.LastName
            };
            EmployeeDB.Create(newEmployee);

            //return CreatedAtRoute("DefaultApi", new { id = createEmployeeVM.UserName }, createEmployeeVM);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Employee/5
        public HttpResponseMessage DeleteEmployee(int id)
        {
            Employee employee = EmployeeDB.Get(id);
            if (employee == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            ApplicationUser user = UserManager.FindById(employee.ApplicationUserId);
            EmployeeDB.Delete(id);
            UserManager.Delete(user);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}