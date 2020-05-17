using AutoMapper;
using HRControlNet.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaakService.Models;

namespace TaakService.AutoMapper
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Taak, TaakModel>();
        }
    }
}
