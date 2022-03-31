using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySQLWeb.Models;

namespace MySQLWeb.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public TeamViewComponent(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];

            var teams = repo.Bowlers.Select(x => x.Team.TeamName).Distinct().OrderBy(x => x);

            return View(teams);
        }
    }
}
