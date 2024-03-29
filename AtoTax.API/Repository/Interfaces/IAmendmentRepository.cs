﻿using AtoTax.API.GenericRepository;
using AtoTax.Domain.Entities;

namespace AtoTax.API.Repository.Interfaces
{
    public interface IAmendmentRepository : IRepository<Amendment>
    {
        Task<Amendment> UpdateAsync(Amendment entity);

    }
}
