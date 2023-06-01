using System;
namespace SpotifyClone.Core.dtos.SongDto
{
	public class SongUpdateDto
	{
       
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string duration { get; set; }
        public string availableMarkets { get; set; }

    }
}

