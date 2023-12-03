﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPB.Core.Model
{
    public  class Employee
    {
    
        public int EmployeeId { get; set; }

        [Key]
        public string? EmployeeAcenumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public bool IsLockedReservation { get; set; }



    }
}
