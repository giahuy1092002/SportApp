﻿using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SportApp_Domain.Entities;
using SportApp_Infrastructure.Model.Owner;
using SportApp_Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Repositories
{
    public class OwnerRepository : Repository<Owner>,IOwnerRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SportAppDbContext _context;
        public OwnerRepository(SportAppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<bool> Create(CreateOwnerModel request)
        {
            var owner = await Entities.FirstOrDefaultAsync(x => x.UserId == request.UserId);
            if (owner != null) throw new Exception("Owner is exist");
            try
            {
                var obj = new Owner
                {
                    UserId = request.UserId,
                };
                Entities.Add(obj);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> Delete(Guid ownerId)
        {
            try
            {
                var owner = await Entities.FirstOrDefaultAsync(c => c.Id == ownerId);
                var user = await _context.Users.FirstOrDefaultAsync(u=>u.Id==owner.UserId);
                Entities.Remove(owner);
                _context.Users.Remove(user);
                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                throw;
            }
        }
    }
}
