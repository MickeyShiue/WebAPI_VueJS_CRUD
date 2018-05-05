using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_VueJS_CRUD.Models
{
    public class UserProfile
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string PhoneNum { get; set; }
        public string Address { get; set; }
    }
}