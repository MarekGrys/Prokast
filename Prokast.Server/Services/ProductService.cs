using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using Prokast.Server.Models.ResponseModels;
using System.Collections.Immutable;

namespace Prokast.Server.Services
{
    public class ProductService: IProductService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;
        Random random = new Random();

        public ProductService(ProkastServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region Create
        public Response CreateProduct([FromBody] ProductCreateDto productCreateDto, int clientID)
        {
            var input = _mapper.Map<ProductCreateDto>(productCreateDto);
            var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Błędnie podane dane" };
            if (input == null)
            {
                return responseNull;
            }
            List<string> AdditionalNamesTitles = new List<string>();
            foreach (var item in input.AdditionalNames) 
            {
                AdditionalNamesTitles.Add(item.Title);
            }

            var product = new Product
            {
                ClientID = clientID,
                Name = input.Name,
                SKU = input.SKU,
                EAN = input.EAN,
                Description = input.Description,
                AdditionalNames = "-1",
                DictionaryParams = "-1",
                CustomParams = "-1",
                PriceListID = -1
                
            };

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            var newProduct = _dbContext.Products.FirstOrDefault(x => x.ClientID == clientID);

            foreach (var item in input.AdditionalNames)
            {
                var name = new AdditionalName
                {
                    ClientID = clientID,
                    Title = item.Title.ToString(),
                    Region = item.Region,
                    Value = item.Value.ToString()
                };
                _dbContext.AdditionalName.Add(name);
                _dbContext.SaveChanges();
            }

            foreach(var item in input.CustomParams)
            {
                var param = new CustomParams
                {
                    Name = item.Name.ToString(),
                    Type = item.Type.ToString(),
                    Value = item.Value.ToString(),
                    ClientID = clientID
                };               
                _dbContext.CustomParams.Add(param);
                _dbContext.SaveChanges();
            }

            var priceList = new PriceLists
            {
                Name = input.PriceList.Name,
                ClientID = clientID,
            };
            _dbContext.PriceLists.Add(priceList);
            _dbContext.SaveChanges();
            
            var newPriceList = _dbContext.PriceLists.FirstOrDefault(x => x.Name == input.PriceList.Name);
            foreach(var item in input.Prices)
            {
                var price = new Prices
                {
                    Name = item.Name,
                    RegionID = item.RegionID,
                    Netto = item.Netto,
                    VAT = item.VAT,
                    Brutto = item.Brutto,
                    PriceListID = newPriceList.ID
                };
                _dbContext.Prices.Add(price);
                _dbContext.SaveChanges();
            }

            List<int> additionalNames = new List<int>();
            foreach (var item in input.AdditionalNames)
            {
                additionalNames.Add(_dbContext.AdditionalName.FirstOrDefault(x => x.Title == item.Title).ID);
            }
            
            List<int> dictionaryParams = new List<int>();
            foreach (var item in input.DictionaryParams)
            {
                dictionaryParams.Add(_dbContext.DictionaryParams.FirstOrDefault(x => x.Name == item.Name).ID);
            }

            List<int> customParams = new List<int>();
            foreach (var item in input.CustomParams)
            {
                customParams.Add(_dbContext.CustomParams.FirstOrDefault(x => x.Name == item.Name).ID);
            }

            newProduct.AdditionalNames = string.Join(",", additionalNames);         
            newProduct.DictionaryParams = string.Join(",", dictionaryParams);
            newProduct.CustomParams = string.Join(",", customParams);
            newProduct.PriceListID = newPriceList.ID;

            _dbContext.SaveChanges();

            var response = new Response() { ID = random.Next(1, 100000), ClientID = clientID };
            return response;
        }
        #endregion
    }
}
