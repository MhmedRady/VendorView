using VendorView.Domain;
using VendorView.Shared;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using VendorView.Repositories;
using AutoMapper;

namespace VendorView.Application;

public class VendorService : CrudGenericManager<int, Vendor, VendorDto, CreateVendorInput>, IVendorService
{
    private readonly IGeneralRepository<Vendor, int> _repository;
    private readonly IMapper _mapper;
    public VendorService(IGeneralRepository<Vendor, int> repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
}


