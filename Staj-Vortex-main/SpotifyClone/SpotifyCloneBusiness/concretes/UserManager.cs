using System;
using System.Linq.Expressions;
using Spotify.core.dtos.MembershipDto;
using Spotify.core.dtos.UserDto;
using Spotify.entities.concretes;
using SpotifyClone.Business.abstracts;
using SpotifyClone.Core.abstracts;
using SpotifyClone.Core.dtos.UserDto;
using SpotifyClone.Core.dtos.UserStatisticDto;
using SpotifyClone.Core.Utilities.Results.Abstract;
using SpotifyClone.Core.Utilities.Results.Concretes;
using SpotifyClone.Core.Validation;
using SpotifyClone.Entities.concretes;

namespace SpotifyClone.Business.concretes
{
	public class UserManager : IUserService
	{

        private readonly IUserRepository _userRepository;
        private readonly IMembershipService _membershipService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly IPlaylistService _playlistService;
        private readonly ILikedSongsService _likedSongsService;
        private readonly IPaymentService _paymentService;

        public UserManager(IUserRepository userRepository, IMembershipService membershipService, IUserStatisticService userStatisticService,IPlaylistService  playlistService,ILikedSongsService likedSongsService,IPaymentService paymentService)
		{
            _userRepository = userRepository;
            _membershipService = membershipService;
            _userStatisticService = userStatisticService;
            _playlistService = playlistService;
            _likedSongsService = likedSongsService;
            _paymentService = paymentService;
		}

        public IResult Delete(UserDto user)
        {
            var membership = _membershipService.GetByUserId(user.id).Data.FirstOrDefault();
            _membershipService.DeleteById(membership.id);
            _userRepository.Delete(user);
          
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IResult DeleteById(int id)
        {    
            var user = GetById(id).Data;
            var userPlaylists = _playlistService.GetByUserId(id).Data;
            var membership = _membershipService.GetByUserId(user.id).Data.FirstOrDefault();
            var userStatistic= _userStatisticService.GetUserStatisticByUserId(user.id).Data.FirstOrDefault();
            var userLikedSongs=_likedSongsService.GetAllByUserId(user.id).Data;

            if(userPlaylists != null)
            {
                foreach (Playlist playlist in userPlaylists)
                {
                    _playlistService.DeleteById(playlist.id);
                }
            }
            
            if(userLikedSongs != null)
            {
                foreach (LikedSongs likedSong in userLikedSongs)
                {
                    _likedSongsService.DeleteById(likedSong.id);
                }
            }
            
            if(userStatistic != null)
            {
                _userStatisticService.DeleteById(userStatistic.id);
            }
            if(membership != null)
            {
                _membershipService.DeleteById(membership.id);
            }

            user.state = "passive";
            Update(user);
            // _userRepository.DeleteById(id);
            return new SuccessResult("Kullanıcı silindi.");
        }

        public IDataResult<IEnumerable<UserDto>> GetAll()
        {
            return new SuccessDataResult<IEnumerable<UserDto>>(_userRepository.GetAll(),"Kullanıcılar listelendi.");
        }

        public IDataResult<IEnumerable<UserDto>> GetAllActiveUsers()
        {
            return new SuccessDataResult<IEnumerable<UserDto>>(_userRepository.GetAll(user => user.state.Equals("active")), "Aktif Kullanıcılar Listelendi");
        }
        //getactiveusers
        public IDataResult<UserDto> GetById(int id)
        {
            return new SuccessDataResult<UserDto>(_userRepository.GetById(id));
        }


        
        public IResult Insert(UserDto user)
        {

            DateTime startDateTime = DateTime.Now.ToUniversalTime().Date;
            user.creationDate = startDateTime;
            user.state = "active";
            _userRepository.Insert(user);
            

            MembershipDto membershipDto = new MembershipDto();
            membershipDto.membershipTypeId = 1;
            membershipDto.userId = user.id;
            membershipDto.startDate = startDateTime;
            membershipDto.endDate = DateTime.MaxValue;
            _membershipService.Insert(membershipDto);

            UserStatisticDto userStatisticDto = new UserStatisticDto();
            userStatisticDto.userId = user.id;
           // userStatisticDto.mostLikedGenreId = -1;
            userStatisticDto.numberOfPlaylists = 0;
            userStatisticDto.numberOfLikedSongs = 0;
            _userStatisticService.AddUserStatistics(userStatisticDto);

            return new SuccessResult("Kullanıcı eklendi.");
          
        }

        public IResult Update(UserDto user)
        {
            var _user = _userRepository.GetById(user.id);
            user.password = _user.password;
            _userRepository.Update(user);
            
            return new SuccessResult("Kullanıcı bilgileri güncellendi.");
          
        }

        public IDataResult<UserDto> LogIn(UserLoginDto userLoginDto)
        {

            if(userLoginDto != null)
            {
                UserDto user = _userRepository.Get(user =>
                (user.userName == userLoginDto.loginCredential || user.email == userLoginDto.loginCredential) &&
                    user.password == userLoginDto.password);

                if (user != null)
                {
                    return new SuccessDataResult<UserDto>(user, "Giriş başarılı");
                }

                else
                {
                    return new ErrorDataResult<UserDto>(null, "Bilgileri eksik veya hatalı girdiniz");
                }

            }
            else
            {
                return new ErrorDataResult<UserDto>(null, "Gerekli alanları dolduruğunuzdan emin olun ");
            }
           
        }

       public IResult UpdatePassword(UserUpdatePasswordDto user)
        {
            var _user= _userRepository.GetById(user.id);
            if(user != null && _user!= null)
            {
                if (_user.password.Equals(user.oldPassword) )
                {
                    if (user.newPassword.Equals(user.newPasswordRepeat))
                    {
                        _user.password = user.newPassword;
                        _userRepository.Update(_user);
                        return new SuccessResult("Şifre güncellendi");
                    }
                    return new ErrorResult("Giridiğiniz şifreler uyuşmuyor");
                }

                return new ErrorResult("Eksik ya da hatalı bilgi girdiniz");
                
            }

            return new ErrorResult("Eksik ya da hatalı bilgi");
        }

        public IDataResult<UserDto> GetByEmail(string _email)
        {
            return new SuccessDataResult<UserDto>(_userRepository.Get(user=> user.email.Equals(_email)));
        }

        public IDataResult<UserDto> GetByUserName(string userName)
        {
            return new SuccessDataResult<UserDto>(_userRepository.Get(user => user.userName.Equals(userName)));
        }

        public IDataResult<IEnumerable<UserDto>> GetAllFreeUsers()
        {
            var freeMemberships= _membershipService.GetAllFreeMemberships().Data.ToList();
            List<UserDto> freeUsers = new List<UserDto>();
            foreach (var freeMembership in freeMemberships)
            {
                freeUsers.Add(GetById(freeMembership.userId).Data);
            }
            return new SuccessDataResult<IEnumerable<UserDto>>(freeUsers,"Free Kullancılar Listeleniyor");
        }

        public IDataResult<IEnumerable<UserDto>> GetAllPremiumUsers()
        {
            var premiumMemberships=_membershipService.GetAllPremimumMemberships().Data.ToList();
            List<UserDto> premiumUsers = new List<UserDto>();
            foreach(var premiumMembership in premiumMemberships)
            {
                premiumUsers.Add(GetById(premiumMembership.userId).Data);
            }
            return new SuccessDataResult<IEnumerable<UserDto>>(premiumUsers,"Premium Kullanıcılar Listeleniyor");
        }

        public IDataResult<IEnumerable<UserDto>> GetAllStudentUsers()
        {
            var studentMemberships=_membershipService.GetAllStudentMemberships().Data.ToList(); 
            List<UserDto> studentUsers = new List<UserDto>();
            foreach ( var studentMembership in studentMemberships)
            {
                studentUsers.Add(GetById(studentMembership.userId).Data);
            }
            return new SuccessDataResult<IEnumerable<UserDto>>(studentUsers, "Öğrenci Kullanıcılar Listeleniyor");
        }
    }
}

