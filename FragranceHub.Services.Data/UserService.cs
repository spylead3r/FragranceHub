using FragranceHub.Data.Models;
using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Data;


namespace FragranceHub.Services.Data
{
    public class UserService : IUserService
    {
        private readonly FragranceHubDbContext dbContext;

        public UserService(FragranceHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

     
    }
}
