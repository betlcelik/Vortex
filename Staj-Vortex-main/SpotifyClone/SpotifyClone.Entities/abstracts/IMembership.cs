using System;
using System.ComponentModel.DataAnnotations;

namespace Spotify.entities.abstracts
{
	public interface IMembership
	{
        [Key]
        int id { get; set; }

		string type { get; set; }
		int price { get; set; }
		int userId { get; set; }
        DateTime startDate { get; set; }
		DateTime endDate { get; set; }
    }
}

