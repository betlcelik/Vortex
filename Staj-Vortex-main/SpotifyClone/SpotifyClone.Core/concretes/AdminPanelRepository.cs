using Spotify.core.DbConnection.EntityFramework;
using SpotifyClone.Core.abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.concretes
{
    public class AdminPanelRepository : IAdminPanelRepository
    {
        private readonly DataBaseConnection _context;

        public AdminPanelRepository(DataBaseConnection context)
        {
                _context = context;
        }

        public int GetNumberOfAlbums()
        {
            return _context.Albums.Count();
        }

        public int GetNumberOfArtists()
        {
            return _context.Artists.Count();
        }

        public int GetNumberOfSongs()
        {
            return _context.Songs.Count();
        }

        public int GetPaidUsersCount()
        {
            return _context.Memberships.Count(membership => membership.membershipTypeId != 1);
        }

        public int GetRegisteredUsersCount()
        {
           
            return _context.Users.Count();
        }

        public double GetTotalIncome()
        {
            return _context.Payments.Sum(payment => payment.price);
            
        }
    }
}
