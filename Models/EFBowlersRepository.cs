﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLWeb.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }

        public EFBowlersRepository (BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;

        public void SaveBowlers(Bowler b)
        {
            _context.Update(b);
            _context.SaveChanges();
        }

        public void AddBowler(Bowler b)
        {
            if (b.BowlerID == 0)
            {
                _context.Bowlers.Add(b);
            }
            
            _context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            _context.Bowlers.Remove(b);
            _context.SaveChanges();
        }
    }
}
