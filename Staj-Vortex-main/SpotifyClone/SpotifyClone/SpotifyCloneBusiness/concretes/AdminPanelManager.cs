using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.concretes;
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

        public IResult CalculateProfitAndLoss()
        {
            FinancialInformationsDto financialInformationsDto = new FinancialInformationsDto();
            financialInformationsDto.income = _adminPanelRepository.GetTotalIncome();
            double expenseInTL = financialInformationsDto.expenseInDollar * 24;
            double profitOrLoss = financialInformationsDto.income - expenseInTL;
            if (expenseInTL > financialInformationsDto.income)
            {
                return new SuccessResult("Sistem istatistiklerine göre " +(-1 * profitOrLoss).ToString()+ " Türk Lirası zarardasınız" );
            }

            return new SuccessResult("Sistem istatistiklerine göre " + (profitOrLoss).ToString() + " Türk Lirası kardasınız");
        }

        public IDataResult<SystemStatisticDto> GetSystemStatiscs()
        {

            _statisticDto.numberOfRegisteredUsers = _adminPanelRepository.GetRegisteredUsersCount(); 
            _statisticDto.numberOfPaidMembership=_adminPanelRepository.GetPaidUsersCount();
            _statisticDto.numberOfSongs=_adminPanelRepository.GetNumberOfSongs();
            return new SuccessDataResult<SystemStatisticDto>(_statisticDto,"Sistem istatistikleri listeleniyor");
        }

        public IResult GetTotalIncome()
        {
            FinancialInformationsDto financialInformationsDto = new FinancialInformationsDto();
            financialInformationsDto.income= _adminPanelRepository.GetTotalIncome();
            double totalIncome=_adminPanelRepository.GetTotalIncome();
            return new SuccessResult("Sistem Toplam Geliri : " + totalIncome);
           
        }
    }
}
