using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Hosting.Server;
using StackExchange.Redis;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
            //return Json("username:" + username + ", password:"+password);
        }
        [HttpPost]
        //[Route("Login")]
        [AllowAnonymous]
        public  ActionResult Login(string username, int password) {
            var count = 0; 

            using (var conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Login;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
           {
                conn.Open();
                using (var command = new SqlCommand("select count(*) from Login where username=@username and password= @password" ))
                {
                    command.Parameters.AddWithValue("username", @username);
                    command.Parameters.AddWithValue("password", @password);
                    command.Connection = conn;
                    count = (int)command.ExecuteScalar();
                }

            }
            if (count == 0)
            {
                return View();
            }

            //return Redirect("http://localhost:60809/Dashboard");
            return RedirectToAction("Index", "Dashboard");

        }
    }
}

