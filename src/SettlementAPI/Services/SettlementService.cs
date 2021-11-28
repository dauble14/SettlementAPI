using AutoMapper;
using SettlementAPI.Core.IConfiguration;
using SettlementAPI.Entities;
using SettlementAPI.Models;
using SettlementAPI.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Services
{
    public class SettlementService : ISettlementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IdentityOptions _identity;
        private readonly IMapper _mapper;
        public SettlementService(
            IUnitOfWork unitOfWork, 
            IdentityOptions identity, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _identity = identity;
            _mapper = mapper;
        }

        public async Task<CreateSettlementDTO> CreateAsync(CreateSettlementDTO model)
        {
            var settlement = new Settlement
            {
                Currency = model.Currency,
                Amount = model.Amount,
                UserId = "5f0269d8-1e86-447f-bab2-8eeb47e01e42"

            };

            await _unitOfWork.Settlements.Insert(settlement);
            await _unitOfWork.CompleteAsync();
            return model;
        }
    }
}
