﻿using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<CheeseCategory> categories = context.Categories.ToList();

            return View(categories);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addcategoryviewmodel = new AddCategoryViewModel();

            return View(addcategoryviewmodel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addcategoryviewmodel)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addcategoryviewmodel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            };  

            return View(addcategoryviewmodel);
        }
    }
}
