using AutoMapper;
using Azure;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using Prokast.Server.Models.ResponseModels;
using System.Web.Http;
using Response = Prokast.Server.Models.Response;

namespace Prokast.Server.Services
{
    public class PricesService: IPricesService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;
        Random random = new Random();

        public PricesService(ProkastServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Response CreatePriceList([FromBody] PriceListsDto priceLists, int clientID)
        {
            var input = _mapper.Map<PriceListsDto>(priceLists);
            if (input == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Błędnie podane dane" };
                return responseNull;
            }
            var priceList = new PriceLists
            {
                Name = input.Name.ToString(),
                ClientID = clientID
            };
            _dbContext.PriceLists.Add(priceList);
            _dbContext.SaveChanges();

            var response = new Response() { ID = random.Next(1, 100000), ClientID = clientID };
            return response;
        }

        public Response CreatePrice([FromBody] PricesDto prices, int priceListID, int clientID)
        {
           
            
            var input = _mapper.Map<PricesDto>(prices);
            if (input == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Błędnie podane dane" };
                return responseNull;
            }

            var list = _dbContext.PriceLists.FirstOrDefault(x => x.ID == priceListID);
            if (list == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Nie ma takiej listy" };
                return responseNull;
            }

            var price = new Prices
            {
                Name = input.Name.ToString(),
                RegionID = input.RegionID,
                Netto = input.Netto,
                VAT = input.VAT,
                Brutto = input.Brutto,
                PriceListID = priceListID,
            };

            _dbContext.Prices.Add(price);
            _dbContext.SaveChanges();

            var response = new Response() { ID = random.Next(1, 100000), ClientID = clientID };
            return response;
        }
    }
}
