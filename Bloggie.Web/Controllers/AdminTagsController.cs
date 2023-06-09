﻿using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminTagsController : Controller
    {
        private readonly ITagInterface tagRepository;

        //private BloggieDbContext _bloggieDbContext;
        public AdminTagsController(ITagInterface tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        //Adding Tags Get Method
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }

        //Adding Tags Post Method
        [HttpPost]
        [ActionName("Add")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            //var name = addTagRequest.Name;
            //var display = addTagRequest.DisplayName;

            var tag = new Tag { 
            Name = addTagRequest.Name,
            DisplayName = addTagRequest.DisplayName
            };
           await tagRepository.AddAsync(tag);
           return RedirectToAction("List");
        }

        //Listing Tags
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
           var tags = await tagRepository.GetAllAsync();
            return View(tags);
        }

        //Edit Page View Action
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id)
        {
            // First usage var tag = bloggieDbContext.Tags.Find(id);

            //Second usage
            var tag = await tagRepository.GetAsync(id);
            if (tag != null)
            {
                var editTagReq = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };
                return View(editTagReq);
            }
            return View(null);    
        }

        //Adding Edit Post Method
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };
            var updatedTag = await tagRepository.UpdateAsync(tag);
            if (updatedTag != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });

        }

        //Delete Post Method
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);
            if (deletedTag != null)
            {
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

    }
}