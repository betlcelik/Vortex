using System;
using Microsoft.EntityFrameworkCore;
using Spotify.core.dtos.AlbumDto;
using Spotify.core.dtos.ArtistDto;
using Spotify.core.dtos.CountryDto;
using Spotify.core.dtos.GenreDto;
using Spotify.core.dtos.MembershipDto;
using Spotify.core.dtos.PlaylistDto;
using Spotify.core.dtos.SongDto;
using Spotify.core.dtos.UserDto;
using Spotify.entities.abstracts;
using Spotify.entities.concretes;
using SpotifyClone.Core.dtos.LikedSongsDto;
using SpotifyClone.Core.dtos.MembershipTypeDto;
using SpotifyClone.Core.dtos.PlaylistSongDto;
using SpotifyClone.Core.dtos.SavedAlbumsDto;
using SpotifyClone.Core.dtos.SavedSongsDto;

namespace Spotify.core.DbConnection.EntityFramework
{
	public class DataBaseConnection : DbContext
	{
        public DataBaseConnection(DbContextOptions<DataBaseConnection> options): base(options)
        {
           
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
   
        }

        


        public DbSet<UserDto> Users { get; set; }
        public DbSet<SongDto> Songs { get; set; }
        public DbSet<PlaylistDto> Playlists { get; set; }
        public DbSet<MembershipDto> Memberships { get; set; }
        public DbSet<MembershipTypeDto> MembershipTypes { get; set; }
        public DbSet<GenreDto> Genres { get; set; }
        public DbSet<CountryDto> Countries { get; set; }
        public DbSet<ArtistDto> Artists { get; set; }
        public DbSet<AlbumDto> Albums { get; set; }
        public DbSet<PlaylistSongDto> PlaylistSongs { get; set; }
        public DbSet<LikedSongsDto> LikedSongs { get; set; }
        public DbSet<SavedSongsDto> SavedSongs { get; set; }
        public DbSet<SavedAlbumsDto> SavedAlbums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TABLE Name Moderators For PostgreSQL
            modelBuilder.Entity<LikedSongsDto>(x =>
            {
                x.ToTable("LikedSongs");
            });

        }
        #endregion



    }
}

