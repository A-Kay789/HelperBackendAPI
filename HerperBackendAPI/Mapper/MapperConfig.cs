using System;
using AutoMapper;
using HelperBackendAPI.Entity.Entity;
using HerperBackendAPI.Model;

namespace HerperBackendAPI.Mapper;

public class MapperConfig:Profile
{
    public MapperConfig()
    {
        CreateMap<UserModel, User>().ReverseMap();
        CreateMap<UserLoginModel, User>();
        CreateMap<UserListModel, User>();

        CreateMap<MasterServiceModel,MasterService>().ReverseMap();
    }
}
