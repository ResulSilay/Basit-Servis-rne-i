using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IlanWeb.Models;

namespace IlanWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            String data = Methods.SendRequest("http://localhost:53485/api/values", EnumHelper.POST);
            ViewBag.sonuc = data;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
