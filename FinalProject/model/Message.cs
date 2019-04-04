using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.model
{
    public class Message
    {
        public string MessageText { get; private set; }
        public string UserImg { get; private set; }
        public DateTime MessageCreationDate { get; private set; }
        public int MessageFromUserId { get; private set; }
        public Boolean isSender { get; private set; }

        public Message(string messageText, string userImg, DateTime messageCreationDate, int messageFromUserId, bool isSender)
        {
            MessageText = messageText;
            UserImg = userImg;
            MessageCreationDate = messageCreationDate;
            MessageFromUserId = messageFromUserId;
            this.isSender = isSender;
        }

        public Message()
        {
        }
    }


}