using Demo.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Demo.BL.Helper;
using Microsoft.AspNetCore.Authorization;

namespace Demo.Controllers
{
    [Authorize]

    public class MailController : Controller
    {
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail( MailVM model )
        {
        
            try {

                if (ModelState.IsValid)
                {
                    TempData["MSG"] = MailSender2.SendMail(model);
                    ModelState.Clear();
                    return View();
                }

                TempData["MSG"] = "Faild To send";
                ModelState.Clear();

                return View();

            }
            catch(Exception ex) {


                TempData["MSG"] = "Faild To send";
                ModelState.Clear();

                return View();


            }
        }
    }
}
