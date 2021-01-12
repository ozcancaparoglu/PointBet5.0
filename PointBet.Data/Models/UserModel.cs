using Common.Entities;

namespace PointBet.Data.Models
{
    public class UserModel : EntityBaseModel
    {
        public string Username { get; set; }

        public byte[] Password { get; set; }

        public decimal TotalPoint { get; set; }

        public int? UserRoleId { get; set; }

        public virtual UserRoleModel UserRole { get; set; }
    }
}
