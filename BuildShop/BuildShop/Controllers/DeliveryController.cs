using Microsoft.AspNetCore.Mvc;

namespace BuildShopPresentationLayer.Controllers
{
	[ApiController]
	public class DeliveryController : ControllerBase
	{
		private readonly IDeliveryService _service;

		public DeliveryController(IDeliveryService service)
		{
			_service = service;
		}

		[HttpGet]
		[ProducesResponseType(typeof(List<Delivery>), StatusCodes.Status200OK)]
		[Route("[controller]")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAll();
			
			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(typeof(Delivery), StatusCodes.Status200OK)]
		[Route("[controller]/{id}")]
		public async Task<IActionResult> GetById([FromBody] int id)
		{
			var result = await _service.GetById(id);
			
			return Ok(result);
		}

		[HttpPost]
		[ProducesResponseType(typeof(Delivery), StatusCodes.Status200OK)]
		[Route("[controller]/create")]
		public async Task<IActionResult> Create([FromBody] Delivery delivery)
		{
			if (delivery is null || !ModelState.IsValid)
			{
				return BadRequest("Invalid model");
			}

			var result = await _service.Create(delivery);

			return Ok(result);
		}

		[HttpPut]
		[ProducesResponseType(typeof(Delivery), StatusCodes.Status200OK)]
		[Route("[controller]/update")]
		public async Task<IActionResult> Update([FromBody] Delivery delivery)
		{
			if (delivery is null || !ModelState.IsValid)
			{
				return BadRequest("Invalid model");
			}

			var result = await _service.Update(delivery);

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
