using AutoMapper;
using SettlementAPI.Entities;
using SettlementAPI.Models;
using SettlementAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SettlementAPI.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, LoginUserDTO>().ReverseMap();
            CreateMap<User, UserFriendDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Settlement, CreateSettlementDTO>().ReverseMap();
            CreateMap<Settlement, SettlementDTO>().ReverseMap();
        }
    }
}
