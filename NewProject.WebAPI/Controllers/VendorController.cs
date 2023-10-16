
using Microsoft.AspNetCore.Mvc;
using VendorView.API;
using VendorView.Application;

namespace VendorView.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationViewModel<VendorDto> model)
        {
            var result = await _vendorService.GetAll(null, null);
            var finalResult = new PaginationViewModel<List<VendorDto>>()
            {
                Count = result.Count(),
                Data = result.ToList(),
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };
            return this.AppSuccess(finalResult);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _vendorService.GetById(id);
            return result is null? this.AppNotFound() : this.AppSuccess(result);
        }


        [HttpPost]
        [Route("CreateVendor")]
        public async Task<IActionResult> Create([FromForm] CreateVendorInput model)
        {
            var result = await _vendorService.AddAsync(model);
            if (result is null)
            {
                return this.AppFailed();
            }
            return this.AppSuccess(result);
        }

        [HttpPut]
        [Route("UpdateVendor/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateVendorInput model)
        {
            var isExist = await _vendorService.IsExistedAsync(v => v.Id == id);
            if (!isExist) {
                return this.AppFailed("Vendor Not Exist");
            }
            var result = await _vendorService.UpdateById(id,model);
            if (result is null)
            {
                return this.AppFailed();
            }
            return this.AppSuccess(result);
        }

        [HttpDelete]
        [Route("DeleteVendor/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isExist = await _vendorService.IsExistedAsync(v => v.Id == id);
            if (!isExist)
            {
                return this.AppFailed("Vendor Not Exist");
            }
            var result = await _vendorService.Remove(id);
            return result? this.AppDeleteSuccess(result): this.AppDeleteFailed();
        }

    }
}
