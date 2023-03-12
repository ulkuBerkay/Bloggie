﻿using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bloggie.Web.Models.ViewModels
{
    public class AddBlogPostRequest
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PubishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        
        //Listing tags from dB
        public IEnumerable<SelectListItem> Tags { get; set; }

        //For chosen tag
        public string SelectedTag { get; set; }

    }
}
