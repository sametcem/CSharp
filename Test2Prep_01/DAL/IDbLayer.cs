using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2PrepTekrar.Models;

namespace Test2PrepTekrar.DAL
{
    public interface IDbLayer
    {
        IEnumerable<Player> GetPlayers();
        IEnumerable<Team> GetTeams();
        Player GetPlayer(int id);

        void AddPlayer(Player newPlayer);
        void DeletePlayer(int deletedPlayerid);
        void UpdatePlayer(Player updatedPlayer);



    }
}
