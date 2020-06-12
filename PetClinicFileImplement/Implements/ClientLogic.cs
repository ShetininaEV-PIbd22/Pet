using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using PetClinicFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinicFileImplement.Implements
{
    public class ClientLogic: IClientLogic
    {
        private readonly FileDataListSingleton source;

        public ClientLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ClientBindingModel model)
        {
            Client element = source.Clients.FirstOrDefault(rec => rec.Login == model.Login ||rec.Phone == rec.Phone 
           ||rec.Email==model.Email && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть такой клиент");
            };
            if (model.Id.HasValue)
            {
                element = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден.");
                }
            }
            else
            {
                int maxId = source.Clients.Count > 0 ? source.Clients.Max(rec => rec.Id) : 0;
                element = new Client { Id = maxId + 1 };
                source.Clients.Add(element);
            }
            element.FIO = model.FIO;
            element.Login = model.Login;
            element.Password = model.Password;
            element.Email = model.Email;
            element.Phone = model.Phone;
        }

        public void Delete(ClientBindingModel model)
        {
            Client client = source.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (client != null)
            {
                source.Clients.Remove(client);
            }
            else
            {
                throw new Exception("Клиент не найден");
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            return source.Clients
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new ClientViewModel
            {
                Id = rec.Id,
                FIO = rec.FIO,
                Login = rec.Login,
                Password = rec.Password,
                Email=rec.Email,
                Phone=rec.Phone
            })
            .ToList();
        }
    }
}
