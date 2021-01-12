using Common.Enums;
using Common.Extensions;
using DataAccessLayer.AutoMapperConfig;
using DataAccessLayer.Repositories;
using DataAccessLayer.Uof;
using PointBet.Data.Domains;
using PointBet.Data.Models;
using System.Linq;

namespace PointBet.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IAutoMapperConfiguration autoMapper;

        private readonly IGenericRepository<User> userRepo;

        public UserService(IUnitOfWork unitOfWork, IAutoMapperConfiguration autoMapper)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;

            userRepo = this.unitOfWork.Repository<User>();
        }

        #region Methods

        public UserModel Authenticate(string username, string password)
        {
            var user = userRepo.Find(x => x.Username == username && x.State == (int)State.Active);

            if (user != null && user.Password.Length > 0)
            {
                byte[] hashBytes = user.Password;

                var hash = new PasswordHash(hashBytes);

                if (!hash.Verify(password))
                    return null;

                user = userRepo.Filter(x => x.Id == user.Id && x.State == (int)State.Active, null, "UserRole").FirstOrDefault();

                return autoMapper.MapObject<User, UserModel>(user);
            }

            return null;
        }

        public UserModel CreateUser(string username, string password, int userRoleId)
        {
            if (userRepo.Exist(x => x.Username == username))
                return null;

            var pass = new PasswordHash(password);

            var newUser = new User
            {
                Username = username,
                Password = pass.ToArray(),
                UserRoleId = userRoleId
            };

            return autoMapper.MapObject<User, UserModel>(userRepo.Add(newUser));
        }

        public UserModel EditUser(string username, decimal? totalPoint, int? userRoleId, string password = "")
        {
            var user = userRepo.Filter(x => x.Username == username && x.State == (int)State.Active, null, "UserRole").FirstOrDefault();
            var changeFlag = false;

            if(!string.IsNullOrWhiteSpace(password))
            {
                var pass = new PasswordHash(password);
                user.Password = pass.ToArray();
                changeFlag = true;
            }

            if (totalPoint.HasValue)
            {
                user.TotalPoint += totalPoint.Value;
                changeFlag = true;
            }

            if (userRoleId.HasValue)
            {
                user.UserRoleId = userRoleId;
                changeFlag = true;
            }             

            return changeFlag ? autoMapper.MapObject<User, UserModel>(userRepo.Update(user)) : autoMapper.MapObject<User, UserModel>(user);        }

        #endregion

    }
}
