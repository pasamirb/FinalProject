/* 
* FileName: MessgeService.cs
* Principal Author:  Smit Patel
* Secondary Author:  Samir Patel
* Summary: Service Class for Message entity
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FinalProject.FinalProjectDatasetTableAdapters;
using FinalProject.model;

namespace FinalProject.service
{
    /// <summary> Service class for Message Entity.</summary>
    public class MessageService
    {
        /// <summary> Store the MessageProductUser Adapter object. </summary>
        MessageProductUserTableAdapter adpMessageProductUser = 
            new MessageProductUserTableAdapter();
        /// <summary> Store the MessageProductUser Table object. </summary>
        FinalProjectDataset.MessageProductUserDataTable tblMessageProductUser = 
            new FinalProjectDataset.MessageProductUserDataTable();

        /// <summary> Method to Get Messages. </summary>
        /// <returns>Return list of messages.</returns>
        /// <param name="UserId"> User ID.</param>
        /// <param name="ProductId"> Product ID</param>
        /// <param name="user"> User Object</param>
        public List<Message> GetMessages(int UserId,int ProductId,User user)
        {
            /// <summary>  Store the Message List. </summary>
            List<Message> messages = new List<Message>();
            tblMessageProductUser = adpMessageProductUser.GetMessages(UserId, ProductId);

            System.Diagnostics.Debug.WriteLine(tblMessageProductUser.GetErrors());

            if(tblMessageProductUser.Count > 0)
            {
                foreach (var row in tblMessageProductUser)
                {
                    /// <summary>  Store the Message object. </summary>
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