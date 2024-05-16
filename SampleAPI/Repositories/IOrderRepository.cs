using SampleAPI.Entities;
using SampleAPI.Requests;

namespace SampleAPI.Repositories
{
	public interface IOrderRepository
	{
		// TODO: Create repository methods.

		public List<Order> GetRecentOrders();
		public void AddNewOrder(Order order);
	}
}
