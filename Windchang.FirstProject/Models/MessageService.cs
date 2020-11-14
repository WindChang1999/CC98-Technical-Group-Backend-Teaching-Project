using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Windchang.FirstProject.Models
{
    public class MessageService
    {
        public ShortMessageModel[] GetAllMessage()
        {
            return Messages.ToArray();
        }
        public void AddMessage(ShortMessageModel shortMessage)
        {
            Messages.Add(shortMessage);
        }
        public void AddMessage(string sender, string content)
        {
            ShortMessageModel shortMessage = new ShortMessageModel
            {
                Sender = sender,
                Content = content
            };
            Messages.Add(shortMessage);
        }
        private List<ShortMessageModel> Messages = new List<ShortMessageModel>();
    }
}
