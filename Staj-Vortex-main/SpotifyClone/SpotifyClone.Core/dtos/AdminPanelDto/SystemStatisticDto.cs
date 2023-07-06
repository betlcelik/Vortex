using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.dtos.AdminPanelDto
{
    public class SystemStatisticDto
    {
        public int numberOfRegisteredUsers  {get; set; }
        public int numberOfPaidMembership { get; set; }
        public int numberOfSongs { get; set; }
        public int numberOfAlbums { get; set; }
        public int numberOfArtists { get; set;}

    }
}
