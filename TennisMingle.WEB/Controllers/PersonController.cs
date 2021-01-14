using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TennisMingle.API.Entities;
using TennisMingle.WEB.Models;

namespace TennisMingle.WEB.Controllers
{
    public class PersonController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PersonController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // GET: PersonController
        public async Task<IActionResult> GetPersons()
        {
            return View();
        }

        // GET: PersonController/Details/5
        public async Task<IActionResult> GetPerson(int id)
        {
            return View();
        }

        // GET: PersonController/Create
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePerson(AppUser person)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPerson(int personId, AppUser person)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePerson(int personId, AppUser person)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
