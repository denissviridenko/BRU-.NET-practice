using Microsoft.AspNetCore.Mvc;

namespace BuildShopPresentationLayer.Controllers
{
	[ApiController]
	public class ItemController : ControllerBase
	{
		private readonly IDeliveryService _service;

		public ItemController(IItemService service)
		{
			_service = service;
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<Item>), StatusCodes.Status200OK)]
		[Route("[controller]")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAll();

			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
		[Route("[controller]/{id}")]
		public async Task<IActionResult> GetById([FromBody] int id)
		{
			var result = await _service.GetById(id);

			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
		[Route("[controller]/create")]
		public async Task<IActionResult> Create([FromBody] Item item)
		{
			if (item is null || !ModelState.IsValid)
			{
				return BadRequest("Invalid model");
			}

			var result = await _service.Create(item);

			return Ok(result);
		}

		[HttpPut]
		[ProducesResponseType(typeof(Item), StatusCodes.Status200OK)]
		[Route("[controller]/update")]
		public async Task<IActionResult> Update([FromBody] Item item)
		{
			if (item is null || !ModelState.IsValid)
			{
				return BadRequest("Invalid model");
			}

			var result = await _service.Update(item);

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
