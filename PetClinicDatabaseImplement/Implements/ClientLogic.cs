using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.ViewModels;
using PetClinicDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetClinicDatabaseImplement.Implements
{
    public class ClientLogic: IClientLogic
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                Client client = context.Clients.FirstOrDefault(rec => rec.Login == model.Login || rec.Phone == rec.Phone
                || rec.Email == model.Email && rec.Id != model.Id);
                if (client != null)
                {
                    throw new Exception("Уже есть такой клиент");
                };
                if (model.Id.HasValue)
                {
                    client = context.Clients.FirstOrDefault(rec=> rec.Id == model.Id);
                    
                    if (client == null)
                    {
                        throw new Exception("Клиент не найден.");
                    }
                }
                else
                {
                    client = new Client();
                    context.Clients.Add(client);
                }
                client.FIO = model.FIO;
                client.Login = model.Login;
                client.Password = model.Password;
                client.Email = model.Email;
                client.Phone = model.Phone;
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                Client client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден.");
                }
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            using (var context = new PetClinicDatabase())
            {
                return context.Clients
                .Where(rec => model == null || rec.Id == model.Id ||
                rec.Login == model.Login && rec.Password == model.Password)
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    FIO = rec.FIO,
                    Login = rec.Login,
                    Email=rec.Email,
                    Phone=rec.Phone,
                    Password = rec.Password
                })
                .ToList();
            }
        }
    }
}
