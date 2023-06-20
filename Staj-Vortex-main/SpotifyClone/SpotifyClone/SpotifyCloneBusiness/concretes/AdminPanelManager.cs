using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.AdminPanelDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Business.concretes
{
    public class AdminPanelManager : IAdminPanelService
    {
        private SystemStatisticDto _statisticDto;
        private IAdminPanelRepository _adminPanelRepository;

        public AdminPanelManager(IAdminPanelRepository adminPanelRepository)
        {
                _statisticDto = new SystemStatisticDto();
            _adminPanelRepository = adminPanelRepository;

        }
        public IDataResult<SystemStatisticDto> GetSystemStatiscs()
        {

            _statisticDto.numberOfRegisteredUsers = _adminPanelRepository.GetRegisteredUsersCount(); 
            _statisticDto.numberOfPaidMembership=_adminPanelRepository.GetPaidUsersCount();
            _statisticDto.numberOfSongs=_adminPanelRepository.GetNumberOfSongs();
            return new SuccessDataResult<SystemStatisticDto>(_statisticDto,"Sistem istatistikleri listeleniyor");
        }
    }
}
