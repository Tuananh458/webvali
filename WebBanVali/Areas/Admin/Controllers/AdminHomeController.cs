﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanVali.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}