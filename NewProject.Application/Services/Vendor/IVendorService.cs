using VendorView.Domain;
using VendorView.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using VendorView.Domain.BaseEntities;
using System.Linq.Expressions;

namespace VendorView.Application;

public interface IVendorService: ICrudGenericManager<int, Vendor, VendorDto, CreateVendorInput>
{

}
