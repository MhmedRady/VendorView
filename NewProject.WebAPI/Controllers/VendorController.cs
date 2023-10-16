
using Microsoft.AspNetCore.Mvc;
using VendorView.API;
using VendorView.Application;
using VendorView.Domain;
using VendorView.Domain.BaseEntities;
using VendorView.WebApi.GenaricController;

namespace VendorView.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : GenaricController<int, Vendor, VendorDto, CreateVendorInput>
    {
        public VendorController(ICrudGenericManager<int, Vendor, VendorDto, CreateVendorInput> genericService) : base(genericService)
        {
        }
    }
}
