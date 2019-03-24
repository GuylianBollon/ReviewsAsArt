using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Models
{
    internal interface IWerkRepository
    {
        void AddWerk(Werk werk);
        void SaveChanges();
        IEnumerable<Werk> GetWerks();
    }
}
