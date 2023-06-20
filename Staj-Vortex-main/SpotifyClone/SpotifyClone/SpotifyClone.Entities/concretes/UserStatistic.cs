using SpotifyClone.Entities.abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities.concretes
{
    public class UserStatistic : IUserStatistic
    {
        public UserStatistic()
        {
                
        }
        [Key]

        public int id { get; set; }
        public int userId { get; set; }
        public int? mostLikedGenreId { get; set; }
        public int? mostListenedArtistId { get; set; }
        public int numberOfLikedSongs { get; set; }
        public int numberOfPlaylists { get; set; }
    }
}
