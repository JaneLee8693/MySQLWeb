using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySQLWeb.Models;

namespace MySQLWeb.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public TeamsViewComponent(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var teams = repo.Teams.ToList();

            return View(teams);
        }
    }
}
