﻿using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IFeeCollectionLedgerRepository : IRepository<FeeCollectionLedger>
    {

        Task<FeeCollectionLedger> UpdateAsync(FeeCollectionLedger entity);
    }
}
