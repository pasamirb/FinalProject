using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.model;

namespace FinalProject.service
{
    public class MessageService
    {
        MessageProductUserTableAdapter adpMessageProductUser = 
            new MessageProductUserTableAdapter();
        FinalProjectDataset.MessageProductUserDataTable tblMessageProductUser = 
            new FinalProjectDataset.MessageProductUserDataTable();
        public List<Message> GetMessages(int UserId,int ProductId,User user)
        {
            List<Message> messages = new List<Message>();
            
            tblMessageProductUser = adpMessageProductUser.GetMessages(UserId, ProductId);

            System.Diagnostics.Debug.WriteLine(tblMessageProductUser.GetErrors());

            if(tblMessageProductUser.Count > 0)
            {
                
                foreach (var row in tblMessageProductUser)
                {
                    Message message;
                    if(row.MessageFromUserId == user.UserId)
                    {
                        message = new Message(row.MessageText,row.UserImage,row.MessageCreationDateTime,row.MessageFromUserId,false);

                    }
                    else
                    {
                        message = new Message(row.MessageText, row.UserImage, row.MessageCreationDateTime, row.MessageFromUserId, true);
                    }
                    messages.Add(message);
                    //string senderName = row.UserFirstName.ToString();
                    //System.Diagnostics.Debug.WriteLine(row.);
                }
            }
            return messages;
        }
    }
}