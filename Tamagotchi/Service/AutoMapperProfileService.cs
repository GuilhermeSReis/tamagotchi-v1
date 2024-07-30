using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Tamagotchi.Model;

namespace Tamagotchi.Service
{
    public class AutoMapperProfileService : Profile
    {
        public AutoMapperProfileService()
        {
            CreateMap<PokemonsDetailResModel, TamagotchiDtoModel>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Altura, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.Peso, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.XpBase, opt => opt.MapFrom(src => src.BaseExperience))
                .ForMember(dest => dest.Habilidades, opt => opt.MapFrom(src => src.Abilities));
                
        }
    }


    public class MascoteService
    {
        private readonly IMapper _mapper;

        public MascoteService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TamagotchiDtoModel CriarMascote(PokemonsDetailResModel pokemon)
        {
            return _mapper.Map<TamagotchiDtoModel>(pokemon);
        }

    }
}