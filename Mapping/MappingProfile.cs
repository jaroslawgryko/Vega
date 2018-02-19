using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Vega.Controllers.Resources;
using Vega.Core.Models;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resources

            CreateMap<Photo, PhotoResource>();

            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));


            CreateMap<Marka, MarkaResource>();
            CreateMap<Marka, KeyValuePairResource>();

            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Atrybut, KeyValuePairResource>();

            CreateMap<Pojazd, SavePojazdResource>()
            .ForMember(pr => pr.Kontakt, opt => opt.MapFrom(p => new KontaktResources { Nazwa = p.KontaktNazwa, Email = p.KontaktEmail, Telefon = p.KontaktTelefon} ))
            .ForMember(pr => pr.Atrybuty, opt => opt.MapFrom(p => p.Atrybuty.Select(pa => pa.AtrybutId)) );

            CreateMap<Pojazd, PojazdResource>()
            .ForMember(pr => pr.Marka, opt => opt.MapFrom(p => p.Model.Marka))
            .ForMember(pr => pr.Kontakt, opt => opt.MapFrom(p => new KontaktResources { Nazwa = p.KontaktNazwa, Email = p.KontaktEmail, Telefon = p.KontaktTelefon} ))
            .ForMember(pr => pr.Atrybuty, opt => opt.MapFrom(p => p.Atrybuty.Select(pa => new KeyValuePairResource { Id = pa.Atrybut.Id, Nazwa = pa.Atrybut.Nazwa })) );            


            //API Resources to Domain
            CreateMap<PojazdQueryResource, PojazdQuery>();

            CreateMap<SavePojazdResource, Pojazd>()
            .ForMember(p => p.Id, opt => opt.Ignore())
            .ForMember(p => p.KontaktNazwa, opt => opt.MapFrom(pr => pr.Kontakt.Nazwa))
            .ForMember(p => p.KontaktEmail, opt => opt.MapFrom(pr => pr.Kontakt.Email))
            .ForMember(p => p.KontaktTelefon, opt => opt.MapFrom(pr => pr.Kontakt.Telefon))
            .ForMember(p => p.Atrybuty, opt => opt.Ignore())
            .AfterMap((pr, p) => {
                // Remove unselected atrybuty
                
                var removedAtrybuty = p.Atrybuty.Where(a => !pr.Atrybuty.Contains(a.AtrybutId));               
                foreach (var a in removedAtrybuty)
                    p.Atrybuty.Remove(a);

                // Add new atrybuty

                var addedAtrybuty = pr.Atrybuty.Where(id => !p.Atrybuty.Any(a => a.AtrybutId == id)).Select(id => new PojazdAtrybut { AtrybutId = id });
                foreach (var a in addedAtrybuty)
                    p.Atrybuty.Add(a);

            });

            CreateMap<PojazdQueryResource, PojazdQuery>();
        }
    }
}