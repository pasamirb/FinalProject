using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.model
{
    public class User
    {
        public int UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Image { get; private set; }
        public string Company { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime CreationDate { get; private set; }

    }
}