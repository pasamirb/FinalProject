/* 
* FileName: UserService.cs
* Principal Author:  Samir Patel
* Secondary Author:  Smit Patel
* Summary: Service Class for User entity
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.model;

namespace FinalProject.service
{
    /// <summary>
    /// Service class for User Entity
    /// </summary>
    public class UserService
    {
        /// <summary> Stores the User Table Adapter object </summary>
        UserTableAdapter adpUser = new UserTableAdapter();

        /// <summary> Stores the User DataTable object </summary>
        FinalProjectDataset.UserDataTable tblUser = new FinalProjectDataset.UserDataTable();

        /// <summary>
        /// Get User by UserName and Password
        /// </summary>
        /// <param name="email">Contains email address</param>
        /// <param name="password">contains password</param>
        /// <returns>User Object</returns>
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

        /// <summary>
        /// Delete User based on userId
        /// </summary>
        /// <param name="UserId">Contains UserId</param>
        /// <returns>Boolean Value</returns>
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