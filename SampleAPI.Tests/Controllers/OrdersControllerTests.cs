using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SampleAPI.Controllers;
using SampleAPI.Entities;
using SampleAPI.Repositories;
using SampleAPI.Requests;

namespace SampleAPI.Tests.Controllers
{
	public class OrdersControllerTests
	{
		[Fact]
		public void GetOrdersTest()
		{
			var mockToDoService = new Mock<IOrderRepository>();
			mockToDoService.Setup(repo => repo.GetRecentOrders())
				.Returns(
				new List<Order>() { new Order { Deleted = false, Name = "Mock-1", Description = "Mock-des", EntryDate = 12345, Invoiced = true, UID = "uuid4" } }
				);

			var controller = new OrdersController(mockToDoService.Object);
			var result = controller.GetOrders();
			Assert.Equal(result.Result?.Value?.Count, 1);
		}
	}
}

