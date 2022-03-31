using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Index(string teamName)
        {
            //HttpContext.Session.Remove("id");

            ViewBag.TeamName = teamName ?? "Home";

            var blah = _repo.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == teamName || teamName == null)
                .ToList();

            return View(blah);
        }

        [HttpGet]
        public IActionResult Form()
        {
            //ViewBag.Teams = _repo.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Form(Bowler b)
        {


            if (ModelState.IsValid)
            {
                //_repo.AddBowler(b);
                _repo.SaveBowler(b);

                return RedirectToAction("Confirmation", b);
            }
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
        public IActionResult Delete(Bowler b)
        {
            _repo.DeleteBowler(b);
            return RedirectToAction("Index");
        }
    }
}
