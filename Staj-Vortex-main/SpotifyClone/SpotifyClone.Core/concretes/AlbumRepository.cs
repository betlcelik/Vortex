using System;
using System.Linq.Expressions;
using Spotify.core.concretes;
using Spotify.core.DbConnection.EntityFramework;
using Spotify.core.dtos.AlbumDto;
using Spotify.core.dtos.SongDto;
using SpotifyClone.Core.abstracts;

namespace SpotifyClone.Core.concretes
{
	public class AlbumRepository : Repository<AlbumDto>, IAlbumRepository
	{
        private readonly DataBaseConnection _context;
        public AlbumRepository(DataBaseConnection context) : base(context)
        {
            _context = context;
        }

        /*
        public IEnumerable<AlbumDto> GetAll(Expression<Func<AlbumDto,bool>> filter=null)
        {
            var albums = base.GetAll(filter);

            foreach (var album in albums)
            {
                album.totalTracks=GetTotalTracksByAlbumId(album.id);
            }
            return albums;
        }*/

        public int GetTotalTracksByAlbumId(int albumId)
        {
           return _context.Songs.Count(song => song.albumId == albumId);
        }
    }
}

