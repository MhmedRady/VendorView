using Microsoft.AspNetCore.Mvc;
using VendorView.API;
using VendorView.Application;
using VendorView.Domain.BaseEntities;

namespace VendorView.WebApi.GenaricController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenaricController<TKey, Entity, ReadDto, WriteDto> : ControllerBase where ReadDto : class where WriteDto : class where Entity : class
    {

        private readonly ICrudGenericManager<TKey, Entity, ReadDto, WriteDto> _genericService;

        public GenaricController(ICrudGenericManager<TKey, Entity, ReadDto, WriteDto> genericService)
        {
            _genericService = genericService;
        }
        [HttpPost]
        [Route("Create[controller]")]
        public async Task<IActionResult> Create([FromForm] WriteDto model)
        {
            var result = await _genericService.AddAsync(model);
            if (result is null)
            {
                return this.AppFailed();
            }
            return this.AppSuccess(result);
        }

        [HttpDelete]
        [Route("Delete[controller]/{id}")]
        public async Task<IActionResult> Delete(TKey id)
        {
            var result = await _genericService.Remove(id);
            return result ? this.AppDeleteSuccess(result) : this.AppDeleteFailed();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] PaginationViewModel<ReadDto> model)
        {
            var result = await _genericService.GetAll(null, null);
            var finalResult = new PaginationViewModel<List<ReadDto>>()
            {
                Count = result.Count(),
                Data = result.ToList(),
                PageIndex = model.PageIndex,
                PageSize = model.PageSize
            };
            return this.AppSuccess(finalResult);
        }

        [HttpGet]
        [Route("Get[controller]ById/{id}")]
        public async Task<IActionResult> GetByIdAsync(TKey id)
        {
            var result = await _genericService.GetById(id);
            return result is null ? this.AppNotFound() : this.AppSuccess(result);
        }

        [HttpPut]
        [Route("Update[controller]/{id}")]
        public async Task<IActionResult> Update(TKey id, [FromForm] WriteDto model)
        {
            var result = await _genericService.UpdateById(id, model);
            if (result is null)
            {
                return this.AppFailed();
            }
            return this.AppSuccess(result);
        }
    }
}
