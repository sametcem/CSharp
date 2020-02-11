using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test2PrepTekrar.DAL;
using Test2PrepTekrar.Models;

namespace Test2PrepTekrar.Controllers
{
    public class PlayersController : Controller
    {
        public readonly IDbLayer _context; // cannot be changed.  This is DI -> Dependency Injection(Using constructor)

        public PlayersController(IDbLayer context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Players = _context.GetPlayers();
            ViewBag.Teams = _context.GetTeams();


            return View();
        }

        [HttpPost]
        public IActionResult Create(Player playertoAdd)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Players = _context.GetPlayers();
                ViewBag.Teams = _context.GetTeams();


                return View("Index",playertoAdd);
            }

            _context.AddPlayer(playertoAdd);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.DeletePlayer(id);
            return Redirect("/Players/Index");
        }

        public IActionResult UpdatePlayerForm(int id)
        {
            var player = _context.GetPlayer(id);
            ViewBag.Player = player;
            ViewBag.Teams = _context.GetTeams();
            return View();
        }

        public IActionResult Update(int id, string FirstName, string LastName, string BirthDate, int IdTeam)
        {
            var player = _context.GetPlayer(id);
            player.FirstName = FirstName;
            player.LastName = LastName;
            player.BirthDate = BirthDate;
            player.IdTeam = IdTeam;
            _context.UpdatePlayer(player);
            return Redirect("Index");
        }
    }
}