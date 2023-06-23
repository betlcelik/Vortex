using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.dtos.LikedSongsDto
{
    public class LikedSongsWithoutIdDto
    {
        public LikedSongsWithoutIdDto()
        {
                
        }
        public int userId { get; set; }
        public int songId { get; set; }
    }
}
