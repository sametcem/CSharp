using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2PrepTekrar.Models;

namespace Test2PrepTekrar.DAL
{
    public class SqlServerDataLayer : IDbLayer
    {
        private readonly PlayerDbCon _context;

        public SqlServerDataLayer(PlayerDbCon context)
        {
            _context = context;
        }


        public void AddPlayer(Player newPlayer)
        {
            _context.Player_apbd.Add(newPlayer);
            _context.SaveChanges();
        }

        public void DeletePlayer(int deletedPlayerid)
        {
            var player = _context.Player_apbd.FirstOrDefault(p => p.IdPlayer == deletedPlayerid);

            if( player != null)
            {
                _context.Player_apbd.Remove(player);
                _context.SaveChanges();
            }
        }

        public Player GetPlayer(int id)
        {
            return _context.Player_apbd.FirstOrDefault(p => p.IdPlayer == id);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _context.Player_apbd
                                        .Include(p => p.Team)    // JOIN 
                                        .OrderBy(p => p.LastName)
                                        .ThenBy(p => p.FirstName)
                                        .ToList();
        }

        public IEnumerable<Team> GetTeams()
        {
            return _context.Team_apbd.OrderBy(t => t.Name).ToList();
        }

        public void UpdatePlayer(Player updatedPlayer)
        {
            if (updatedPlayer != null)
            {
                _context.Player_apbd.Update(updatedPlayer);
                _context.SaveChanges();
            }
        }
    }
}
