/* 
* FileName: Messge.cs
* Principal Author:  Smit Patel
* Secondary Author:  Samir Patel
* Summary: Model Class for Message entity
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.model
{
    /// <summary>  Model class for Message Entity. </summary>
    public class Message
    {
        /// <summary> Store the Message Text. </summary>
        public string MessageText { get; private set; }

        /// <summary> Store the Image name of User. </summary>
        public string UserImg { get; private set; }

        /// <summary> Store the value of the User Image. </summary>
        public string UserImage { get; private set; }
        
        /// <summary> Store the Date and Time of Message Creation. </summary>
        public DateTime MessageCreationDate { get; private set; }

        /// <summary> Store for the Message From User ID. </summary>
        public int MessageFromUserId { get; private set; }
      
        /// <summary> Store the information about weather user if sender or not. </summary>
        public Boolean isSender { get; private set; }


        /// <summary> The class constructor with parameters. </summary>
        public Message(string messageText, string userImage, DateTime messageCreationDate, int messageFromUserId, bool isSender)
        {
            MessageText = messageText;
            UserImage = userImage;
            MessageCreationDate = messageCreationDate;
            MessageFromUserId = messageFromUserId;
            this.isSender = isSender;
        }

        /// <summary> The class constructor. </summary>
        public Message()
        {
        }
    }
}