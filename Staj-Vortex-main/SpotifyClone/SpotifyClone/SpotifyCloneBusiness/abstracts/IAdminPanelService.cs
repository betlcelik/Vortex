using SpotifyClone.Core.dtos.AdminPanelDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Business.abstracts
{
    public interface IAdminPanelService
    {
        IDataResult<SystemStatisticDto> GetSystemStatiscs();
    }
}
