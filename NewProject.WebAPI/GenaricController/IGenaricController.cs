using Microsoft.AspNetCore.Mvc;
using VendorView.API;
using VendorView.Application;

namespace VendorView.WebApi.GenaricController
{

    public interface IGenaricController<TKey, ReadDto, WriteDto> where ReadDto : class where WriteDto : class
    {
        public Task<IActionResult> GetAll([FromQuery] PaginationViewModel<ReadDto> model);
        public Task<IActionResult> GetByIdAsync(int id);
        public Task<IActionResult> Create([FromForm] WriteDto model);
        public Task<IActionResult> Update(TKey id, [FromForm] WriteDto model);
        public Task<IActionResult> Delete(TKey id);
    }
}
