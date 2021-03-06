using AutoMapper;
using RS2_Vjezbe.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS2_Vjezba.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Korisnici, RS2_Vjezbe.Models.Korisnici>();
            CreateMap<Database.Proizvodi , RS2_Vjezbe.Models.Proizvodi>(); 
            CreateMap<Database.JediniceMjere , RS2_Vjezbe.Models.JediniceMjere>();

            CreateMap<ProizvodiInsertRequest , Database.Proizvodi>();
            CreateMap<Database.Proizvodi , ProizvodiInsertRequest>();
            CreateMap<ProizvodiUpdateRequest, Database.Proizvodi>();
            CreateMap<Database.Proizvodi, ProizvodiUpdateRequest>();

            CreateMap<JediniceMjereUpsertRequest, Database.JediniceMjere>();
            CreateMap<Database.JediniceMjere, JediniceMjereUpsertRequest>();

        }
    }
}
