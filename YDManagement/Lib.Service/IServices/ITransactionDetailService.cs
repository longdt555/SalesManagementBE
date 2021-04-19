﻿using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.Services.IServices;

namespace Lib.Service.IServices
{
    public interface ITransactionDetailService : IReadOnlyService<TransactionDto>
    {
        TransactionDetail Create(TransactionDetail obj);
       
    }
}
