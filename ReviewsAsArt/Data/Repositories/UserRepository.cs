using Microsoft.EntityFrameworkCore;
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _gebruikers;
        private readonly ApplicationDbContext _adc;

        public UserRepository(ApplicationDbContext adc)
        {
            _gebruikers = adc.Users;
            _adc = adc;
        }

        public void Add(User user)
        {
            _gebruikers.Add(user);
        }

        public User GetBy(string name)
        {
            return _gebruikers.FirstOrDefault(u => u.UserName == name);
        }

        public IEnumerable<User> GetUsers()
        {
            return _gebruikers.ToList();
        }

        public void SaveChanges()
        {
            _adc.SaveChanges();
        }

        public IEnumerable<Review> ToonReviewsVanSubscripties(IEnumerable<User> users)
        {
            if (users == null)
                throw new ArgumentNullException(nameof(users));

            IEnumerable<Review> r = null;
            foreach (User user in users)
            {
                foreach (Review re in _gebruikers.Find(user).Reviews)
                {
                    r.Append(re);
                }
            }
            return r;
        }

        public IEnumerable<Review> ToonReviewsVanUser(User user)
        {
            return _gebruikers.Find(user).Reviews;
        }
    }
}
