using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.dtos.PlaylistDto
{
    public class PlaylistDeleteDto
    {
        public PlaylistDeleteDto()
        {
                
        }
        public int id { get; set; }
        public int userId { get; set; }
    }
}
