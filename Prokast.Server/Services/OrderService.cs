using AutoMapper;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using Prokast.Server.Models.OrderModels;
using Prokast.Server.Models.ResponseModels;
using Prokast.Server.Services.Interfaces;
using System.Text;

namespace Prokast.Server.Services
{
    public class OrderService: IOrderService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;
        Random random = new Random();

        public OrderService(ProkastServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Response CreateOrder(OrderCreateDto orderCreateDto, int clientID)
        {
            var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Błędnie podane dane" };
            if (orderCreateDto == null)
            {
                return responseNull;
            }

            const string znaki = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder trackingID = new StringBuilder();
            
            for (int i = 0; i < 20; i++)
            {
                int index = random.Next(znaki.Length);
                trackingID.Append(znaki[index]);
            }

            var order = new Order
            {
                ShopOrderID = orderCreateDto.ShopOrderID,
                OrderDate = orderCreateDto.OrderDate,
                TotalPrice = orderCreateDto.TotalPrice,
                TotalWeightKg = orderCreateDto.TotalWeightKg,
                PaymentMethod = orderCreateDto.PaymentMethod,
                CreationDate = orderCreateDto.CreationDate,
                UpdateDate = orderCreateDto.UpdateDate,
                TrackingID = trackingID.ToString(),
            };

            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();

            order = _dbContext.Orders.FirstOrDefault(x => x.TrackingID == trackingID.ToString());

            var customer = new Customer
            {
                OrderID = order.ID,
                FirstName = orderCreateDto.FirstName,
                LastName = orderCreateDto.LastName,
                Email = orderCreateDto.Email,
                PhoneNumber = orderCreateDto.PhoneNumber,
            };

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            var response = new Response() { ID = random.Next(1, 100000), ClientID = clientID };
            return response;
        }
    }
}
