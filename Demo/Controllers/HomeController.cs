using Demo.Language;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> sharedLocalizer;

        public HomeController(IStringLocalizer<SharedResource> SharedLocalizer)
        {
            sharedLocalizer = SharedLocalizer;
        }
        public IActionResult Index()
        {
            ViewBag.msg = sharedLocalizer["Dashboard"];
            return View();
        }


    }
}