using AutoMapper;
using ControlPersonalData.Domain.Entities;
using ControlPersonalData.Application.DTOs;

namespace ControlPersonalData.Application.Mappings
{
    /// <summary>
    /// The domain to DTO mapping profile.
    /// </summary>
    public class DomainToDTOMappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainToDTOMappingProfile"/> class.
        /// </summary>
        public DomainToDTOMappingProfile() {
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserFilterDTO>().ReverseMap();
        }
    }
}
