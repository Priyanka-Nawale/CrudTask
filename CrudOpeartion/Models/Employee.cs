﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudOpeartion.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime DOB { get; set; }
    }
}