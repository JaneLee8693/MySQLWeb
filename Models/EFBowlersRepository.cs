using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLWeb.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext context { get; set; }

        public EFBowlersRepository (BowlersDbContext temp)
        {
            context = temp;
        }
        public IQueryable<Bowler> Bowlers => context.Bowlers;
        public IQueryable<Team> Teams => context.Teams;

        public void SaveBowler(Bowler b)
        {
            if (b.BowlerID == 0)
            {
                context.Bowlers.Add(b);

            }
            context.SaveChanges();
        }

        public void UpdateBowler(Bowler b)
        {
            context.Bowlers.Update(b);
            context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            context.Bowlers.Remove(b);
            context.SaveChanges();
        }
    }
}
