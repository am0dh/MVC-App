using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCapp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCapp.Controllers
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


        public IActionResult Encode(string? str)
        {
            string newStr;
            if (str != null) {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(str);
                newStr= System.Convert.ToBase64String(plainTextBytes);
            }
            else { newStr = ""; }
            ViewBag.Encode = newStr;


            return View();
        }
        
        public IActionResult Decode(string? str)
        {
            string newStr;
            if (str != null )
            {
                var base64EncodedBytes = System.Convert.FromBase64String(str);
                newStr = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            else { newStr = ""; }
            ViewBag.Decode = newStr;


            return View();
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
