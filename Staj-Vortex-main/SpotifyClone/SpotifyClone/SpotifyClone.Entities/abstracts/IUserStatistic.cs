using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities.abstracts
{
    public interface IUserStatistic
    {
       [Key]
       int id { get; set; }
       int userId { get; set; }
       int? mostLikedGenreId { get; set; }
       int? mostListenedArtistId { get; set; }
       int numberOfLikedSongs { get; set; }
       int numberOfPlaylists { get; set; }

    }
}
