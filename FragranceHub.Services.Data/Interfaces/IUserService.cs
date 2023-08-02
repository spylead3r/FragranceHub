using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Services.Data.Interfaces
{
    public interface IUserService
    {
        public Task<string> GetUserIdAsync(string id);
    }
}
