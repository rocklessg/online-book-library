﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Model.DTO.RequestDTO.RegistrationRequestDTO, Model.User>();

            CreateMap<Model.User, Model.DTO.ResponseDTO.LoginResponseDTO>()
                .ForMember(dest => dest.Name, option => option.MapFrom(src =>
                            $"{src.FirstName} {src.LastName}"));


        }
    }
}
