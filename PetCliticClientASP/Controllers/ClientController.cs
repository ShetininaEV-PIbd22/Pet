using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PetClinicBusinessLogic.BindingModels;
using PetClinicBusinessLogic.Interfaces;
using PetClinicBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace PetClinicRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientLogic _logic;
        private readonly IMessageInfoLogic _messageLogic;
        private readonly int _passwordMaxLength = 25;
        private readonly int _passwordMinLength = 6;
        public ClientController(IClientLogic logic, IMessageInfoLogic messageLogic)
        {
            _logic = logic;
            _messageLogic = messageLogic;
        }
        [HttpGet]
        public ClientViewModel Login(string login, string password) => _logic.Read(new ClientBindingModel { Login = login, Password = password })?[0];
        [HttpPost]
        public void Register(ClientBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }
        [HttpPost]
        public void UpdateData(ClientBindingModel model)
        {
            CheckData(model);
            _logic.CreateOrUpdate(model);
        }
        private void CheckData(ClientBindingModel model)
        {
            if (model.Password.Length > _passwordMaxLength || model.Password.Length < _passwordMinLength)
            {
                throw new Exception($"Пароль длиной от {_passwordMinLength} до {_passwordMaxLength}");
            }
        }
        
        public List<ClientViewModel> GetClientList() => _logic.Read(null).ToList();
        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) => _messageLogic.Read(new MessageInfoBindingModel { ClientId = clientId });
    }
}