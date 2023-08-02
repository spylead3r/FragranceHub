using FragranceHub.Services.Data.Interfaces;
using FragranceHub.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Services.Data
{
    public class UserService : IUserService
    {
        private readonly FragranceHubDbContext dbContext;

        public UserService(FragranceHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<string> GetUserIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
