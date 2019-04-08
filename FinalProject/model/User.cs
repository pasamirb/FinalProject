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
        public string Password { get; set; }
        public string Email { get; private set; }
        public string Image { get; private set; }
        public string Company { get; private set; }
        public long Phone { get; private set; }
        public DateTime CreationDate { get; private set; }
        private bool IsSellerCompany;

        public bool IsCompany
        {
            get {
                if(string.Equals(Company, string.Empty) || string.IsNullOrEmpty(Company))
                    return false;
                return true;
            }
            set { IsCompany = value; }
        }


        public User(int userId, string firstName, string lastName, string userName, string password, string email, string image, string company, long phone, DateTime creationDate)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            Email = email;
            Image = image;
            Company = company;
            Phone = phone;
            CreationDate = creationDate;
        }

        public User()
        {

        }
    }
}