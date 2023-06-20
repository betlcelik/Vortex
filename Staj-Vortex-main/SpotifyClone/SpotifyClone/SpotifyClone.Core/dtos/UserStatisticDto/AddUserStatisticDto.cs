using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.dtos.UserStatisticDto
{
    public class AddUserStatisticDto
    {
        public AddUserStatisticDto()
        {
                
        }

        public int userId { get; set; }
        public int mostLikedGenreId { get; set; }
        public int mostListenedArtistId { get; set; }
        public int numberOfLikedSongs { get; set; }
        public int numberOfPlaylists { get; set; }
    }
}
