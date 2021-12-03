using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        private readonly Options.IdentityOptions _identity;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public SettlementService(
            IUnitOfWork unitOfWork, 
            Options.IdentityOptions identity, 
            IMapper mapper,
            UserManager<User> userManager
            )
        {
            _unitOfWork = unitOfWork;
            _identity = identity;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CreateSettlementDTO> CreateAsync(CreateSettlementDTO model)
        {
            var userMail = _identity.UserMail;
            var user = await _userManager.FindByNameAsync(userMail);
            

            var settlement = new Settlement
            {
                Currency = model.Currency,
                Amount = model.Amount,
                UserId =user.Id

            };

            await _unitOfWork.Settlements.Insert(settlement);
            await _unitOfWork.CompleteAsync();
            return model;
        }
    }
}
