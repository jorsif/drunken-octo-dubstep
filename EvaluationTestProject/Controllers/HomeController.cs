﻿using System;
using System.Linq;
using System.Web.Mvc;
using EvaluationTestProject.DAL;

namespace EvaluationTestProject.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext db = new BlogContext();
        
        //
        // GET: /Home/

        public ActionResult Index()
        {
            // uncomment this code to get a compile error
            // return false;
            return View(db.Blogs.ToList());
        }

        public ActionResult Failure()
        {
            throw new InvalidOperationException("I told you not to press it.");                
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}