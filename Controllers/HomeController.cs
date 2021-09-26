using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCJSONSettings.Models;

namespace WebAppMVCJSONSettings.Controllers
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
            var builder = new ConfigurationBuilder()
              .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();
            var MiJSONProperty = config["MiJSONProperty"];  

            return View(model: MiJSONProperty);
        }

        public IActionResult Builder2()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var dataconfig = builder.Build();
            return View("Index", model: dataconfig["Mi2ndProperty"]);
        }

        public ActionResult Builder3()
        {
            ConfigurationBuilder ConfigurationBuilder_ = new ConfigurationBuilder();
            ConfigurationBuilder_.AddJsonFile($"appsettings.json", true, true);
            IConfigurationRoot Build = ConfigurationBuilder_.Build();           
            return View("Index", model: Build["Information"]);
        }

        public ActionResult Builder4()
        {
            ConfigurationBuilder ConfigurationBuilder_ = new ConfigurationBuilder();
            ConfigurationBuilder_.AddJsonFile($"appsettings.json", true, true);
            ConfigurationRoot Builder = (ConfigurationRoot)ConfigurationBuilder_.Build();
            return View("Index",model: Builder["Prop4"]);
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
