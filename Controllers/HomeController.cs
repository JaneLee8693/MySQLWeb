using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySQLWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLWeb.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var blah = _repo.Bowlers
                .OrderBy(b => b.BowlerID)
                .Include(b => b.TeamId)
                .Include(b => b.TeamName);
            //.ToList();

            return View(blah);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var application = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View("Form", application);
        }

        [HttpPost]
        public IActionResult Edit(Bowler blah)
        {
            _repo.SaveBowler(blah);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var application = _repo.Bowlers.Single(x => x.BowlerID == id);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(Bowler stuff)
        {
            _repo.DeleteBowler(stuff);
            return RedirectToAction("Index");
        }
    }
}
