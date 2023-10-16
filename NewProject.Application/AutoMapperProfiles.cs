using AutoMapper;
using VendorView.Domain;

namespace VendorView.Application;

public class AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserInput, ApplicationUser>();
            CreateMap<ApplicationUser, UserDto>();
        }
    }

    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<CreateVendorInput, Vendor>();
            CreateMap<Vendor, VendorDto>();
        }
    }
}