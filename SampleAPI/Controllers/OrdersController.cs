using Microsoft.AspNetCore.Mvc;
using SampleAPI.Entities;
using SampleAPI.Repositories;
using SampleAPI.Requests;

namespace SampleAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderRepository _orderRepository;
		// Add more dependencies as needed.

		public OrdersController(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		[HttpGet("/v1/orders")]
		[ProducesResponseType(StatusCodes.Status200OK)] // TODO: Add all response types
		public async Task<ActionResult<List<Order>>> GetOrders()
		{
			return _orderRepository.GetRecentOrders();
		}

		[HttpPost("/v1/orders")]
		[ProducesResponseType(StatusCodes.Status200OK)] // TODO: Add all response types
		public async Task<int> NewOrder(Order data)
		{

			if (data.Name == null)
			{
				return await Task.FromResult(StatusCodes.Status400BadRequest).ConfigureAwait(false);
			}

			try
			{
				_orderRepository.AddNewOrder(data);
			}
			catch (Exception)
			{
				return await Task.FromResult(StatusCodes.Status500InternalServerError).ConfigureAwait(false);
			}

			return await Task.FromResult(StatusCodes.Status201Created).ConfigureAwait(false);

		}

		/// TODO: Add an endpoint to allow users to create an order using <see cref="CreateOrderRequest"/>.
	}
}
