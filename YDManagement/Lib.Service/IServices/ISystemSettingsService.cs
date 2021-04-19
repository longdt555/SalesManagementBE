﻿using Lib.Data.Entity;
using Lib.Service.Dtos;
using System.Collections.Generic;
using Lib.Service.Services.IServices;

namespace Lib.Service.IServices
{
    public interface ISystemSettingsService : IReadOnlyService<SystemSettingsDto>
    {
        SystemSettings Create(SystemSettings obj);
        void Update(SystemSettings obj);
        void Delete(int id);
        void DeleteMany(List<int> ids);
        int GetRecordCount();
    }
}
