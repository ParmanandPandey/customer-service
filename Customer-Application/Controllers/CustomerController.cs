using Customer.BusinessLogic.Contracts;
using Customer.Model.Requests;
using Customer_Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Customer_Application.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILoginService loginService;
        private readonly ICustomerService customerService;
        public CustomerController(ILoginService loginService, ICustomerService customerService)
        {
            this.loginService = loginService;
            this.customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(CustomerLoginModel loginModel)
        {
            bool isVerified = false;
            if (ModelState.IsValid)
            {
                isVerified = await loginService.VerifyUser(loginModel);
            }
            if (isVerified)
            {
                TempData["LoginMessege"] = "Login Success";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["LogginMessage"] = "Loggin failed!";
            }
            return View();
        }

        //private readonly ICustomerService customerService;
        //public CustomerController(ICustomerService customerService)
        //{
        //    this.customerService = customerService;
        //}
        [HttpGet]
        public IActionResult AddCustomers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomers(CustomerAddRequestModel customerRequest)
        {
            var result = await customerService.AddCustomer(customerRequest);
            if (result?.Response == null && (result?.CustomerId != Guid.Empty || result?.CustomerId != null))
            {
                TempData["userAdded"] = true;
                //TempData["AddedMessage"] = "Thankyu You are Registered";
                
                return RedirectToAction(nameof(Login));
            }
            else
            {
                TempData["userAdded"] = false;
                return View();
            }
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

        public IActionResult Privacy2()
        {
            return View();
        }
    }
}
