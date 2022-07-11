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
            CreateMap<Database.VrsteProizvodum, RS2_Vjezbe.Models.VrsteProizvodum>();

            CreateMap<ProizvodiInsertRequest , Database.Proizvodi>();
            CreateMap<Database.Proizvodi , ProizvodiInsertRequest>();
            CreateMap<ProizvodiUpdateRequest, Database.Proizvodi>();
            CreateMap<Database.Proizvodi, ProizvodiUpdateRequest>();
            CreateMap<KorisniciInsertRequest, Database.Korisnici>();
            CreateMap<Database.Korisnici, KorisniciInsertRequest>();
            CreateMap<KorisniciUpdateRequest, Database.Korisnici>();
            CreateMap<Database.Korisnici, KorisniciUpdateRequest>();

            CreateMap<JediniceMjereUpsertRequest, Database.JediniceMjere>();
            CreateMap<Database.JediniceMjere, JediniceMjereUpsertRequest>();
            CreateMap<VrsteProizvodumUpsertRequest, Database.VrsteProizvodum>();
            CreateMap<Database.VrsteProizvodum, VrsteProizvodumUpsertRequest>();

        }
    }
}
