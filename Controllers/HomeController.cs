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
        private IBowlersRepository repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string teamName)
        {
            //HttpContext.Session.Remove("id");

            ViewBag.TeamName = teamName;

            var blah = repo.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team.TeamName == teamName || teamName == null)
                .ToList();

            return View(blah);
        }

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.New = true;
            //Bowler b = new Bowler();
            ViewBag.Team = repo.Teams.ToList();
            return View("Form");
        }

        [HttpPost]
        public IActionResult Form(Bowler b)
        {

            if (ModelState.IsValid)
            {
                //_repo.AddBowler(b);
                repo.SaveBowler(b);

                return View("Confirmation");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int BowlerId)
        {
            ViewBag.New = false;
            ViewBag.Team = repo.Teams.ToList();
            var application = repo.Bowlers.Single(x => x.BowlerID == BowlerId);
            return View("Form", application);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            repo.UpdateBowler(b);
            repo.SaveBowler(b);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int BowlerId)
        {
            var application = repo.Bowlers.Single(x => x.BowlerID == BowlerId);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            repo.DeleteBowler(b);
            return RedirectToAction("Index");
        }
    }
}
