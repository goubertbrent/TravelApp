﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelAppBackend.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
