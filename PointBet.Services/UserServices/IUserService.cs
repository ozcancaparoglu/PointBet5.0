using PointBet.Data.Models;

namespace PointBet.Services.UserServices
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        UserModel CreateUser(string username, string password, int userRoleId);
        UserModel EditUser(string username, decimal? totalPoint, int? userRoleId, string password = "");
    }
}