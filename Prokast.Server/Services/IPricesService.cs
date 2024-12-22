using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IPricesService
    {
        Task<Response> CreatePriceList([FromBody] PriceListsCreateDto priceLists, int clientID);
        Task<Response> CreatePrice([FromBody] PricesDto prices, int priceListID, int clientID);
        Task<Response> GetAllPriceLists(int clientID);
        Task<Response> GetPriceListsByName(int clientID, string name);
        Task<Response> GetAllPrices(int clientID, int priceListID);
        Task<Response> GetPricesByRegion(int clientID, int priceListID, int regionID);
        Task<Response> GetPricesByName(int clientID, int priceListID, string name);
        Task<Response> EditPrice(EditPriceDto editPriceDto, int clientID, int priceListID, int priceID);
        Task<Response> DeletePrice(int clientID, int priceListID, int priceID);
        Task<Response> DeletePriceList(int clientID, int priceListID);
    }
}
