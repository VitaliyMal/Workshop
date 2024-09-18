using Workshop.Server.DTOs.SecurityDTOs;
using Workshop.Server.Entity;
using Workshop.Server.Utility;

namespace Workshop.Server.Mapper
{
    public static class SecurityMapper
    {
        public static User ToEntity(this SecurityRequest securityRequest)
        {
            return new User()
            {
                Login = securityRequest.Login,
                Password = Encoder.ComputeSHA256Hash(securityRequest.Password),
            };
        }

        public static SecurityResponse ToResponse(this User user)
        {
            return new SecurityResponse(user.Id);
        }
    }
}
