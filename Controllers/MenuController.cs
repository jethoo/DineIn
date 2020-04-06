using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dineIN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Newtonsoft.Json;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dineIN.Controllers
{
    public class MenuController : Controller
    {

        private readonly DINE_INContext _context;

        public MenuController(DINE_INContext context)
        {
            _context = context;
        }


        //Action For Getting The Menu as data table
        public async Task<IActionResult> GetList()
        {
            var dishList = await _context.Dishes.ToListAsync();

            var newData = Json(new { data = dishList });

            return newData;

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
