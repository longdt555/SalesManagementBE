﻿using Lib.Data.Entity;
using Lib.Service.Dtos;
using System.Collections.Generic;
using Lib.Service.Services.IServices;

namespace Lib.Service.IServices
{
    public interface ICustomerProfileService : IReadOnlyService<CustomerProfileDto>
    {
        CustomerProfile Create(CustomerProfile obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        void Update(CustomerProfile obj);
    }
}
