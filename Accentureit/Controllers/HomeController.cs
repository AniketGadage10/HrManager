using Accentureit.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using BOL;
using System.Collections.Generic;

using System;
using Microsoft.VisualBasic;
using System.Globalization;

using BLL;

namespace Accentureit.Controllers
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
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        public IActionResult getList()
        {
           List<BOL.Emp> list =BLL.Emp.getList();
           ViewBag.List = list;
            return View();
        }

        [HttpPost]
        public IActionResult GetByID(string id)
        {
            BOL.Emp e=BLL.Emp.Getbyid(int.Parse(id));
            Console.WriteLine(e);
            ViewBag.Emp = e;
            return View();
        }

        [HttpPost]
        public IActionResult delete(String id)
        {
            BLL.Emp.deleteemp(int.Parse(id));
            return RedirectToAction("getList");
        }
        

        [HttpPost]
        public IActionResult Update(String eid, String name, String email, String psw, String department, String date)
        {
            BOL.Emp e = new BOL.Emp(int.Parse(eid), name, email, psw, Enum.Parse<Department>(department), DateOnly.Parse(date));
            BLL.Emp.UpdateEmp(e);
            return RedirectToAction("getList");
        }

        [HttpPost]
        public IActionResult Register(String eid, String name, String email, String psw, String department, String date)
        {
            BOL.Emp e = new BOL.Emp(int.Parse(eid), name, email, psw, Enum.Parse<Department>(department),DateOnly.Parse(date));
            BLL.Emp.insertEmp(e); 
            return RedirectToAction("getList");
        }


        [HttpGet]
        public IActionResult Login()
        {
            this.ViewData["welcome"] = "Welcome To Accenture";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string psw)
        {
            BOL.Emp EMP=BLL.Emp.validate(email,psw);
            if(EMP==null) {
                return RedirectToAction("Register");
            }
            this.ViewData["emp"] = EMP;
            return View("Emp");
        }

        public IActionResult Emp()
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