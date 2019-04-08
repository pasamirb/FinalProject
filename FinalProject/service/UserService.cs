using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.model;

namespace FinalProject.service
{ 
    public class UserService
    {
        UserTableAdapter adpUser = new UserTableAdapter();
        FinalProjectDataset.UserDataTable table = new FinalProjectDataset.UserDataTable();

        public User GetUserByUserNameAndUserPassword(String email, String password)
        {
            table = adpUser.GetUserByUserNameAndUserPassword(email, password);
            User user = null;
            if (table.Count > 0)
            {
                var row = table[0];

                int UserId = row.UserId;
                string FirstName = row.UserFirstName;
                string LastName = row.UserLastName;
                string UserName = row.UserFirstName;
                string UserPassword = row.UserPassword;
                string Email = row.UserEmail;
                string Image = row.UserImage;
                string Company = (row.UserCompany ==  null) ? String.Empty : row.UserCompany.ToString();
                long Phone = row.UserPhone ;
                DateTime CreationDate = row.UserCreationDateTime;

                user = new User(UserId, FirstName, LastName, UserName, UserPassword, Email,
                Image, Company, Phone, CreationDate);
            }
            return user;
        }
    }
}