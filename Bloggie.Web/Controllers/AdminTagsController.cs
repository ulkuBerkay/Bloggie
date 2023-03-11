﻿using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{

    public class AdminTagsController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //[ActionName("Add")]
        //public IActionResult SubmitTag()
        //{
        //    //var name = Request.Form["name"];
        //    //var displayName = Request.Form["displayName"];
        //    return View("Add");
        //}

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest)
        {
            var name = addTagRequest.Name;
            var display = addTagRequest.DisplayName;
            return View("Add");
        }
    }
}
