using System;
using System.Collections.Generic;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Models;
namespace Infrastructure.Mapper{
    public class MappingProfile : Profile{
        public MappingProfile() {
            CreateMap<AnimalCreateModel, Animals>();
            CreateMap<Animals, AnimalItemModel>()
                .ForMember(x => x.SpecieName, opt => opt.MapFrom(x => x.Specie.Name));
            CreateMap<CustomerCreateModel, Customer>();
            CreateMap<AppointmentCreateModel, Appointment>();
            CreateMap<MedicalRecordCreateModel, MedicalRecord>();
            CreateMap<SpecieCreateModel, Specie>();
        }
    }
}
