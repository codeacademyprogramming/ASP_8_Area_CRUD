﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokP201.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokP201.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class GenreController : Controller
    {
        private readonly PustokContext _context;

        public GenreController(PustokContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View(_context.Genres.Include(x=>x.Books).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();


            return RedirectToAction("index");
        }


    }
}
