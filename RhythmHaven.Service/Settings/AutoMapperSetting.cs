﻿using AutoMapper;
using RhythmHaven.Repository.Common;
using RhythmHaven.Repository.Entities;
using RhythmHaven.Repository.Enums;
using RhythmHaven.Service.BusinessModels.AuthenModels;
using RhythmHaven.Service.BusinessModels.UserModels;
using RhythmHaven.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmHaven.Service.Settings
{
    public class AutoMapperSetting : Profile
    {
        public AutoMapperSetting() 
        {
            CreateMap<SignUpModel, Account>().ReverseMap();
            CreateMap<SignUpModel, Account>()
                .ForMember(dest => dest.UnsignName, opt => opt.MapFrom(src => StringUtils.ConvertToUnSign(src.Name)))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Role.USER.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => AccountStatus.ACTIVE.ToString()));
                
            CreateMap<UserModel, Account>().ReverseMap();
            CreateMap<Account, UserProcessModel>().ReverseMap();
            CreateMap<Pagination<Account>, Pagination<UserModel>>().ConvertUsing<PaginationConverter<Account, UserModel>>();
        }
    }

    public class PaginationConverter<TSource, TDestination> : ITypeConverter<Pagination<TSource>, Pagination<TDestination>>
    {
        public Pagination<TDestination> Convert(Pagination<TSource> source, Pagination<TDestination> destination, ResolutionContext context)
        {
            var mappedItems = context.Mapper.Map<List<TDestination>>(source);
            return new Pagination<TDestination>(mappedItems, source.TotalCount, source.CurrentPage, source.PageSize);
        }
    }
}
