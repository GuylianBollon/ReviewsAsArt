using Microsoft.EntityFrameworkCore;
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Data.Repositories
{
    public class WerkRepository : IWerkRepository
    {
        private readonly DbSet<Werk> _Werken;
        private readonly ApplicationDbContext _adc;

        public WerkRepository(ApplicationDbContext adc)
        {
            _Werken = adc.Werken;
            _adc = adc;
        }
        public void AddWerk(Werk werk)
        {
            _Werken.Add(werk);
        }

        public void SaveChanges()
        {
            _adc.SaveChanges();
        }

        public IEnumerable<Werk> GetWerks()
        {
            return _Werken.ToList();
        }
    }
}
