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
        FinalProjectDataset.UserDataTable tblUser = new FinalProjectDataset.UserDataTable();

        public User GetUserByUserNameAndUserPassword(String email, String password)
        {
            tblUser = adpUser.GetUserByUserNameAndUserPassword(email, password);
            User user = null;
            if (tblUser.Count > 0)
            {
                var row = tblUser[0];

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

        public bool DeleteUserAccount(int UserId)
        {
            int result = adpUser.Delete(UserId);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}