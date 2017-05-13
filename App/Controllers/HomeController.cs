using Infrastrkture.Commands;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastrkture.Services;
using Infrastrkture.Commands.Accounts;
using Infrastructure.DTO;
using App.Models;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        AccountDTO currentUser;
        protected readonly ICommandDispatcher _CommandDispatcher;
        private readonly IAccountService _AccountService;

        public HomeController(IAccountService accountService, ICommandDispatcher commandDispatcher)
        {
            _CommandDispatcher = commandDispatcher;
            _AccountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Login()
        {
            //ViewData["Message"] = "Your application description page.";
            var Model = new LoginModel();
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> LoginProcessing(LoginModel Model)
        {
            await _CommandDispatcher.Dispatch(new GetAccount(Model.Email, Model.Password));
            return View();
        }

        public async Task<IActionResult> LogonProcessing(LoginModel Model)
        {
            ForwardingModel forwardingModel = new ForwardingModel();
            if (Model.CheckBoxR)
            {
                await _CommandDispatcher.Dispatch(new AddAccount(Model.UserNameR, Model.EmailR, Model.PasswordR));
                forwardingModel.Input = "About";
            }
            forwardingModel.Input = "Index";
            return View(forwardingModel);
        }
    }
}
