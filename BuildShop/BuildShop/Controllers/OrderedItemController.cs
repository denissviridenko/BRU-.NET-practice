using Microsoft.AspNetCore.Mvc;

namespace BuildShopPresentationLayer.Controllers
{
	[ApiController]
	public class OrderedItemController : ControllerBase
	{
		private readonly IOrderedItemService _service;

		public OrderedItemController(IOrderedItemService service)
		{
			_service = service;
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<OrderedItem>), StatusCodes.Status200OK)]
		[Route("[controller]")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAll();

			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(typeof(OrderedItem), StatusCodes.Status200OK)]
		[Route("[controller]/{id}")]
		public async Task<IActionResult> GetById([FromBody] int id)
		{
			var result = await _service.GetById(id);

			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(typeof(OrderedItem), StatusCodes.Status200OK)]
		[Route("[controller]/create")]
		public async Task<IActionResult> Create([FromBody] OrderedItem orderedItem)
		{
			if (orderedItem is null || !ModelState.IsValid)
			{
				return BadRequest("Invalid model");
			}

			var result = await _service.Create(orderedItem);

			return Ok(result);
		}

		[HttpPut]
		[ProducesResponseType(typeof(OrderedItem), StatusCodes.Status200OK)]
		[Route("[controller]/update")]
		public async Task<IActionResult> Update([FromBody] OrderedItem orderedItem)
		{
			if (orderedItem is null || !ModelState.IsValid)
			{
				return BadRequest("Invalid model");
			}

			var result = await _service.Update(orderedItem);

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
