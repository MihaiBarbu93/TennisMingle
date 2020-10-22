using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Models;

namespace TennisMingle.WEB.Components
{
    public class CitiesList: ViewComponent
    {
        private readonly AppDbContext _context;
        public CitiesList(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var cities = _context.Cities;
            return View(cities);
        }
    }
}
