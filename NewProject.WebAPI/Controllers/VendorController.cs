
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
        private readonly IVendorService _vendorService;
        public VendorController(IVendorService vendorService) : base(vendorService)
        {
            _vendorService = vendorService;
        }
    }
}
