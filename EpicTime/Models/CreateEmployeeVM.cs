﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicTime.Models
{
    public class CreateEmployeeVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}