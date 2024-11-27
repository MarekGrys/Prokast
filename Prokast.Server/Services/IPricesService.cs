using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;

namespace Prokast.Server.Services
{
    public interface IPricesService
    {
        Response CreatePriceList([FromBody] PriceListsDto priceLists, int clientID);
        Response CreatePrice([FromBody] PricesDto prices, int priceListID, int clientID);
    }
}
