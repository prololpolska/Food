﻿using Infrastrkture.Commands;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastrkture.Services;
using Infrastrkture.Commands.Accounts;
using Infrastructure.DTO;
using App.Models;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        AccountDTO currentUser;
        protected readonly ICommandDispatcher _CommandDispatcher;
        private readonly IAccountService _AccountService;
        private readonly IMemoryCache _memoryCache;
        private readonly SharedModel _sharedModel;

        public HomeController(IAccountService accountService, ICommandDispatcher commandDispatcher, IMemoryCache memoryCache, SharedModel sharedModel)
        {
            _CommandDispatcher = commandDispatcher;
            _AccountService = accountService;
            _memoryCache = memoryCache;
            _sharedModel = sharedModel;
        }

        public IActionResult Index()
        {
            ViewData.Add("sharedModel.accountOrLogin", _sharedModel.accountOrLogin);
            ViewData.Add("sharedModel.accountOrLoginTarget", _sharedModel.accountOrLoginTarget);
            return View();
        }

        public IActionResult Login()
        {
            ViewData.Add("sharedModel.accountOrLogin", _sharedModel.accountOrLogin);
            ViewData.Add("sharedModel.accountOrLoginTarget", _sharedModel.accountOrLoginTarget);
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> LoginProcessing(LoginModel Model)
        {
            ViewData.Add("sharedModel.accountOrLogin", _sharedModel.accountOrLogin);
            ViewData.Add("sharedModel.accountOrLoginTarget", _sharedModel.accountOrLoginTarget);
            ForwardingModel forwardingModel = new ForwardingModel();
            forwardingModel.Input = "Index";
            await _CommandDispatcher.Dispatch(new GetAccount(Model.Email, Model.Password));
            currentUser = _memoryCache.Get<AccountDTO>("accountDto");
            if (currentUser != null)
            {
                forwardingModel.Input = "Account";
                _sharedModel.accountOrLogin = "Konto";
                _sharedModel.accountOrLoginTarget = "Account";
            }
            return View(forwardingModel);
        }

        public async Task<IActionResult> LogonProcessing(LoginModel Model)
        {
            ViewData.Add("sharedModel.accountOrLogin", _sharedModel.accountOrLogin);
            ViewData.Add("sharedModel.accountOrLoginTarget", _sharedModel.accountOrLoginTarget);
            ForwardingModel forwardingModel = new ForwardingModel();
            forwardingModel.Input = "Index";
            if (Model.CheckBoxR)
            {
                await _CommandDispatcher.Dispatch(new AddAccount(Model.UserNameR, Model.EmailR, Model.PasswordR));
                currentUser = _memoryCache.Get<AccountDTO>("accountDto");
                if(currentUser != null)
                {
                    forwardingModel.Input = "Account";
                    _sharedModel.accountOrLogin = "Konto";
                    _sharedModel.accountOrLoginTarget = "Account";
                }
            }
            return View(forwardingModel);
        }

        public async Task<IActionResult> Account()
        {
            ViewData.Add("sharedModel.accountOrLogin", _sharedModel.accountOrLogin);
            ViewData.Add("sharedModel.accountOrLoginTarget", _sharedModel.accountOrLoginTarget);
            currentUser = _memoryCache.Get<AccountDTO>("accountDto");
            if(currentUser == null)
            {
                return StatusCode(403);
            }
            if(currentUser.Role == "Admin")
            {
                ViewData.Add("accountRole.action", "Admin");
                ViewData.Add("accountRole.info", "Dodaj dietę");
            }
            else
            {

                ViewData.Add("accountRole.action", "Buy");
                ViewData.Add("accountRole.info", "Kup dietę");
            }
            ViewData["Message"] = $"Witaj {currentUser.UserName}";
            return View();
        }

        public async Task<IActionResult> Buy()
        {
            ViewData.Add("sharedModel.accountOrLogin", _sharedModel.accountOrLogin);
            ViewData.Add("sharedModel.accountOrLoginTarget", _sharedModel.accountOrLoginTarget);
            currentUser = _memoryCache.Get<AccountDTO>("accountDto");
            if (currentUser == null)
            {
                return StatusCode(403);
            }
            return View();
        }

        public async Task<IActionResult> Admin()
        {
            ViewData.Add("sharedModel.accountOrLogin", _sharedModel.accountOrLogin);
            ViewData.Add("sharedModel.accountOrLoginTarget", _sharedModel.accountOrLoginTarget);
            currentUser = _memoryCache.Get<AccountDTO>("accountDto");
            if (currentUser == null)
            {
                return StatusCode(403);
            }
            if(currentUser.Role != "Admin")
            {
                return StatusCode(403);
            }
            return View();
        }
    }
}
