﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenLogin.Models
{
    public class asset
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Role { set; get; }
        public DateTime RegistrationDate { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
    }
}