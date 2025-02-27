using Prokast.Server.Models;
using Prokast.Server.Models.OrderModels;

namespace Prokast.Server.Services.Interfaces
{
    public interface IOrderService
    {
        Response CreateOrder(OrderCreateDto orderCreateDto, int clientID);
        Response GetAllOrders(int clientID);
        Response GetOrder(int clientID, int orderID);
    }
}
