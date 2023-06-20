using Spotify.entities.concretes;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos;
using SpotifyClone.Core.dtos.UserStatisticDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using SpotifyClone.Entities.concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Business.concretes
{
    public class UserStatisticManager : IUserStatisticService
    {
        private readonly IUserStatisticRepository _userStatisticRepository;
        private readonly IMembershipService _membershipService;
        public UserStatisticManager(IUserStatisticRepository userStatisticRepository,IMembershipService membershipService)
        {
            _userStatisticRepository = userStatisticRepository;
            _membershipService = membershipService;
            
        }

        public IResult AddUserStatistics(UserStatisticDto addUserStatisticDto)
        {
            _userStatisticRepository.Insert(addUserStatisticDto);
            return new SuccessResult();
        }

        public IDataResult<IEnumerable<UserStatisticDto>> GetUserStatisticByUserId(int userId)
        {
            var userType=_membershipService.GetByUserId(userId).Data.FirstOrDefault().membershipTypeId;
            if(userType == 1)
            {
                return new ErrorDataResult<IEnumerable<UserStatisticDto>>(null,"Kullanıcı istatistikleri sadece ücretli üyelikler için geçerlidir"+userType);
            }
            
            var userStatistics = _userStatisticRepository.GetAll(userStatistic => userStatistic.userId == userId);
            return new SuccessDataResult<IEnumerable<UserStatisticDto>>(userStatistics," " + userType);
        }

        public IResult IncreaseLikedSongs(int userId)
        {     
            
            var userStatisticResult=GetUserStatisticByUserId(userId);
            if (userStatisticResult.Success)
            {
                var _userStatistics= userStatisticResult.Data.FirstOrDefault();
                if (_userStatistics != null)
                {
                    _userStatistics.numberOfLikedSongs++;
                    Update(_userStatistics);
                    return new SuccessResult();
                }
            }
            return new ErrorResult("Beğenilen şarkılara eklenemedi");
          
        }

        public IResult DecraseLikedSongs(int userId)
        {
            var userStatisticResult = GetUserStatisticByUserId(userId);
            if (userStatisticResult.Success)
            {
                var _userStatistics = userStatisticResult.Data.FirstOrDefault();
                if (_userStatistics != null)
                {
                    _userStatistics.numberOfLikedSongs--;
                    Update(_userStatistics);
                    return new SuccessResult();
                }
            }
            return new ErrorResult("Başarısız");
        }

        public IResult IncreasePlayLists(int userId)
        {
            var userStatisticResult = GetUserStatisticByUserId(userId);
            if (userStatisticResult.Success)
            {
                var _userStatistics = userStatisticResult.Data.FirstOrDefault();
                if (_userStatistics != null)
                {
                    _userStatistics.numberOfPlaylists++;
                    Update(_userStatistics);
                    return new SuccessResult();
                }
            }
            return new ErrorResult("Başarısız");
        }

        public IResult DecrasePlayLists(int userId)
        {
            var userStatisticResult = GetUserStatisticByUserId(userId);
            if (userStatisticResult.Success)
            {
                var _userStatistics = userStatisticResult.Data.FirstOrDefault();
                if (_userStatistics != null)
                {
                    _userStatistics.numberOfPlaylists--;
                    Update(_userStatistics);
                    return new SuccessResult();
                }
            }
            return new ErrorResult("Başarısız");
        }

        public IResult Update(UserStatisticDto updateUserStatisticDto)
        {
            var _usersStatistic = _userStatisticRepository.GetById(updateUserStatisticDto.id);
            _userStatisticRepository.Update(_usersStatistic);
            return new SuccessResult("Kullanıcı istatistikleri güncellendi");
        }

       
        }

        
    }

