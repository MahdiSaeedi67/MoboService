using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentService.Controllers.V1
{
    public class DefaultController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}