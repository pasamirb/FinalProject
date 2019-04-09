/* 
* FileName: Global.aspx.cs
* Principal Author:  Samir Patel
* Secondary Author:  Smit Patel
* Summary: Global class
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FinalProject.model;


namespace FinalProject
{
    /// <summary> Global Class.</summary>
    public class Global : System.Web.HttpApplication
    {
        /// <summary> called when application starts</summary>
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        /// <summary> called when new session starts</summary>
        protected void Session_Start(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Session["user"] = new User();
        }

        /// <summary> called when application begins request</summary>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        /// <summary> called when application requests authentication</summary>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        /// <summary> called when application throw error</summary>
        protected void Application_Error(object sender, EventArgs e)
        {

        }

        /// <summary> called when session ends</summary>
        protected void Session_End(object sender, EventArgs e)
        {
            Session["user"] = new User();
        }

        /// <summary> called when application ends</summary>
        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}