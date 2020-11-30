using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoreLinq;
using Newtonsoft.Json;
using TennisMingle.API.Entities;
using TennisMingle.WEB.Models;

namespace TennisMingle.WEB.Components
{
    public class Register : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            EntityViewModel entity = new EntityViewModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44313/api/persons"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    entity.Persons = JsonConvert.DeserializeObject<HashSet<AppUser>>(apiResponse);
                }
            }

            return View(entity);
        }
    }
}
