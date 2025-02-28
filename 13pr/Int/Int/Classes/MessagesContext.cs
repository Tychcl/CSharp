using Int.Interfaces;
using Int.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
    
namespace Int.Classes
{
    public class MessagesContext : Messages, IMessages
    {
        public static List<Messages> AllMessages;
        public MessagesContext() =>
            this.All(out AllMessages);

        public MessagesContext(string Massage, DateTime Create, int IdUser, string image) : base (Massage, Create, IdUser,image) {}
        public MessagesContext(string Massage, DateTime Create, int IdUser): base (Massage, Create, IdUser) { }

        public void All(out List<Messages> Messages) =>
            Messages = new List<Messages>();

        public void Delete()=>
            AllMessages.Remove(this);

        public void Save(bool Update=false){
            if (Update==false)
                AllMessages.Add(this);
        }
        public void Save(int id, int useridt, string text)
        {
            Models.Messages msg = AllMessages.Find(x => x.IdUser == useridt & x.Id == id);
            msg.Massage = text;
            msg.izm = false;
        }

    }
}
