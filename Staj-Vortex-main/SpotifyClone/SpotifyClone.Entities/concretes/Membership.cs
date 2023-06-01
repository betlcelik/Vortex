using System;
using System.ComponentModel.DataAnnotations;
using Spotify.entities.abstracts;

namespace Spotify.entities.concretes
{
	public class Membership : IMembership
	{
		public Membership()
		{
		}

        [Key]
        public int id { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public int userId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}

