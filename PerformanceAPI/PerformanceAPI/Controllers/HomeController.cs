﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PerformanceAPI.Models;

namespace PerformanceAPI.Controllers
{
    public class HomeController : Controller
    {
        db database = new db();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult PerformanceReport()
        {
            return View();
        }

        public IActionResult SalaryInformation()
        {
            return View();
        }

        public IActionResult Employee()
        {
            return View();
        }

        public IActionResult PredictionSummaryReport()
        {
            return View();
        }

        public IActionResult ActualsSummaryReport()
        {
            return View();
        }

        public IActionResult Projections()
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
