using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Task6WebApp.Data.Entities;
using Task6WebApp.Data.Repository.Interfaces;
using Task6WebApp.Hubs;
using Task6WebApp.Models;

namespace Task6WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepositoryWrapper _repository;
        private readonly IHubContext<MessageHub> _messageHub;
        public HomeController(ILogger<HomeController> logger, 
            IRepositoryWrapper repository,
            IHubContext<MessageHub> messageHub)
        {
            _logger = logger;
            _repository = repository;
            _messageHub = messageHub;
        }

        public IActionResult Index()
        {
            var user = _repository.User.GetByNickName(User.Identity.Name);

            var model = new IndexViewModel()
            {
                Users = _repository.User.GetAllUsers(),
                MessageForUser = user.Messages
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            if(String.IsNullOrEmpty(model.MessageToUser) 
               || String.IsNullOrEmpty(model.MessageTitle)
               || String.IsNullOrEmpty(model.Message))
                return RedirectToAction("Index");

            if (_repository.User.GetByNickName(model.MessageToUser) is null)
            {
                return RedirectToAction("Index");
            }

            var message = new Message()
            {
                Body = model.Message,
                Title = model.MessageTitle,
                ToUser = _repository.User.GetByNickName(model.MessageToUser).Id,
                FromUser = User.Identity.Name,
                CreatedDate = DateTime.Now
            };
            CreateMessage(message, model.MessageToUser, new List<string>()
            {
                new Guid().ToString(), message.FromUser, message.CreatedDate.ToShortTimeString(), message.Title, message.Body
            });
            model = new IndexViewModel()
            {
                Users = _repository.User.GetAllUsers(),
                MessageForUser = _repository.User.GetByNickName(User.Identity.Name).Messages,
            };
            return RedirectToAction("Index");
        }

        public void CreateMessage(Message message, string user, List<string> letter)
        {
            _repository.Message.Create(message);
            _repository.Save();
            _messageHub.Clients.User(user).SendAsync("newMessage", letter).GetAwaiter().GetResult();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}