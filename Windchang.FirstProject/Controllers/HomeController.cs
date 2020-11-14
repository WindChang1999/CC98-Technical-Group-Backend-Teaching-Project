using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Windchang.FirstProject.Models;

namespace Windchang.FirstProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Message([FromServices]MessageService messageService)
        {
/*
            ShortMessageModel[] messages = new ShortMessageModel[2];
            messages[0] = new ShortMessageModel();
            messages[1] = new ShortMessageModel();
            messages[0].Sender = "Alice";
            messages[0].Content = "Hello from Alice";
            messages[1].Sender = "Bob";
            messages[1].Content = "Hello from Bob";
*/
            return View(messageService.GetAllMessage());
        }

        public IActionResult ResponseAddMessage([FromServices]MessageService messageService, ShortMessageModel data)
        {
            messageService.AddMessage(data);
            this.TempData["responseAddMessage"]= "Add message success";
            return RedirectToAction("Message");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
