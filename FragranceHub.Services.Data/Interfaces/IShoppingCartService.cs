﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Services.Data.Interfaces
{
    public interface IShoppingCartService
    {
        Task AddToCart(string fragranceId, string userId, int quantity);
    }
}
