using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Message()
        {

            return View(MessageUsers.MessageOfUsers);
        }
    }
}
