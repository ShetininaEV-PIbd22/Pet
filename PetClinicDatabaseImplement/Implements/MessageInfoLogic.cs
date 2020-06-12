using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDatabaseImplement.Implements
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        public void Create(MessageInfoBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                MessageInfo element = context.MessageInfos.FirstOrDefault(rec =>
               rec.MessageId == model.MessageId);
                if (element != null)
                {
                    throw new Exception("Уже есть письмо с таким идентификатором");
                }
                int? clientId = context.Clients.FirstOrDefault(rec => rec.Login ==
               model.FromMailAddress)?.Id;
                context.MessageInfos.Add(new MessageInfo
                {
                    MessageId = model.MessageId,
                    ClientId = clientId,
                    SenderName = model.FromMailAddress,
                    DateDelivery = model.DateDelivery,
                    Subject = model.Subject,
                    Body = model.Body.ToString()
                });
                context.SaveChanges();
            }
        }
        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                return context.MessageInfos
                .Where(rec => model == null || rec.ClientId == model.ClientId)
                .Select(rec => new MessageInfoViewModel
                {
                    MessageId = rec.MessageId,
                    SenderName = rec.SenderName,
                    DateDelivery = rec.DateDelivery,
                    Subject = rec.Subject,
                    Body = rec.Body
                })
               .ToList();
            }
        }
    }
}
