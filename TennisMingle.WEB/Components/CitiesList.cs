using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisMingle.API.Entities;

namespace TennisMingle.WEB.Components
{
    public class CitiesList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
