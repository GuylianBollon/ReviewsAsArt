using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Models
{
    internal interface ICommentaarRepository
    {
        void VoegScoreToe(Commentaar commentaar);
        void NeemScoreAf(Commentaar commentaar);
        void SaveChanges();
    }
}
