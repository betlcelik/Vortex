using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.abstracts
{
    public interface IAdminPanelRepository
    {
        int GetRegisteredUsersCount();
        int GetPaidUsersCount();
        int GetNumberOfSongs();
        int GetNumberOfAlbums();
        int GetNumberOfArtists();
        double GetTotalIncome();
    }
}
