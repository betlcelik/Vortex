﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Spotify.entities.abstracts;

namespace Spotify.entities.concretes
{
	public class Playlist : IPlaylist
	{
		public Playlist()
		{
		}

        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public int userId { get; set; }
        public DateTime creationDate { get; set; }
        public int numberOfSongs { get; set; }
       


    }
}

