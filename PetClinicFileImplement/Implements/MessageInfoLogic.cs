using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicFileImplement.Implements
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly FileDataListSingleton source;

        public MessageInfoLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void Create(MessageInfoBindingModel model)
        {
            MessageInfo element = source.MessageInfos.FirstOrDefault(rec => rec.MessageId == model.MessageId);

            if (element != null)
            {
                throw new Exception("Уже есть письмо с таким идентификатором");
            }

            int? clientId = source.Clients.FirstOrDefault(rec => rec.Login == model.FromMailAddress)?.Id;

            source.MessageInfos.Add(new MessageInfo
            {
                MessageId = model.MessageId,
                ClientId = clientId,
                SenderName = model.FromMailAddress,
                DateDelivery = model.DateDelivery,
                Subject = model.Subject,
                Body = model.Body
            });
        }
        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            return source.MessageInfos
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

