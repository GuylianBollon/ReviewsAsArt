using Microsoft.EntityFrameworkCore;
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Data.Repositories
{
    public class CommentaaarRepository : ICommentaarRepository
    {
        private readonly DbSet<Commentaar> _dsc;
        private readonly ApplicationDbContext _adc;
        public CommentaaarRepository(ApplicationDbContext adc)
        {
            _dsc = adc.Commentaars;
            _adc = adc;
        }
        public void NeemScoreAf(Commentaar commentaar)
        {
            _dsc.Find(commentaar).Score--;
        }

        public void SaveChanges()
        {
            _adc.SaveChanges();
        }

        public void VoegScoreToe(Commentaar commentaar)
        {
            _dsc.Find(commentaar).Score++;
        }
    }
}
