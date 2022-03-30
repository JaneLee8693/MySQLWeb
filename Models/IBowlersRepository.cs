using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLWeb.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        public void SaveChanges(Bowler b);
        public void AddBowler(Bowler b);
        public void DeleteBowler(Bowler b);
    }
}
