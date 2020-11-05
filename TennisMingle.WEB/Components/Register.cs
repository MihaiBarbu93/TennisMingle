using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisMingle.WEB.Components
{
    public class Register : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
