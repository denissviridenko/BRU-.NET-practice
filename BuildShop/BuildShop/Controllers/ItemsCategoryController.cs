using Microsoft.AspNetCore.Mvc;

namespace BuildShopPresentationLayer.Controllers
{
	[ApiController]
	public class ItemsCategoryController : ControllerBase
	{
		private readonly IItemsCategoryService _service;

		public ItemsCategoryController(IItemsCategoryService service)
		{
			_service = service;
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<ItemsCategory>), StatusCodes.Status200OK)]
		[Route("[controller]")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAll();

			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(typeof(ItemsCategory), StatusCodes.Status200OK)]
		[Route("[controller]/{id}")]
		public async Task<IActionResult> GetById([FromBody] int id)
		{
			var result = await _service.GetById(id);

			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(typeof(Delivery), StatusCodes.Status200OK)]
		[Route("[controller]/create")]
		public async Task<IActionResult> Create([FromBody] ItemsCategory itemsCategory)
		{
			if (itemsCategory is null || !ModelState.IsValid)
			{
				return BadRequest("Invalid model");
			}

			var result = await _service.Create(itemsCategory);

			return Ok(result);
		}

		[HttpPut]
		[ProducesResponseType(typeof(ItemsCategory), StatusCodes.Status200OK)]
		[Route("[controller]/update")]
		public async Task<IActionResult> Update([FromBody] ItemsCategory itemsCategory)
		{
			if (itemsCategory is null || !ModelState.IsValid)
			{
				return BadRequest("Invalid model");
			}

			var result = await _service.Update(itemsCategory);

			return Ok(result);
		}

		[HttpDelete]
		[ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
		[Route("[controller]/delete")]
		public async Task<IActionResult> Delete([FromBody] int id)
		{
			var result = await _service.Delete(id);

			return Ok(result);
		}
	}
}
