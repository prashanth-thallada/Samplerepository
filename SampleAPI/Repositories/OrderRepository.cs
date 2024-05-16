using Microsoft.EntityFrameworkCore;
using SampleAPI.Entities;
using SampleAPI.Requests;

namespace SampleAPI.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		public static SampleApiDbContext? sampleApiDbContextInstance { get; set; }

		public OrderRepository(SampleApiDbContext sampleApiDbContext)
		{
			sampleApiDbContextInstance = sampleApiDbContext;
		}

		public async void AddNewOrder(Order order)
		{
			if (sampleApiDbContextInstance != null)
			{
				sampleApiDbContextInstance.Orders.Add(order);
				sampleApiDbContextInstance.SaveChanges();
			}
		}

		public List<Order> GetRecentOrders()
		{
			if (sampleApiDbContextInstance != null)
			{
				return sampleApiDbContextInstance.Orders.ToList();
			}
			return new List<Order>();
		}

		public void AddNewOrder()
		{
			throw new NotImplementedException();
		}
	}
}
