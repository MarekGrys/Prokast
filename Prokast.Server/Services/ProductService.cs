using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using Prokast.Server.Models.ResponseModels;
using System.Collections.Immutable;
using System.Linq;

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
        public async Task<Response> CreateProduct([FromBody] ProductCreateDto productCreateDto, int clientID)
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
                Photos = "-1",
                PriceListID = -1
                
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            var newProduct = _dbContext.Products.FirstOrDefault(x => x.ClientID == clientID && x.Name == input.Name);

            foreach (var item in input.AdditionalNames)
            {
                var name = new AdditionalName
                {
                    ClientID = clientID,
                    Title = item.Title.ToString(),
                    Region = item.Region,
                    Value = item.Value.ToString()
                };
                await _dbContext.AdditionalName.AddAsync(name);
                await _dbContext.SaveChangesAsync();
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
                await _dbContext.CustomParams.AddAsync(param);
                await _dbContext.SaveChangesAsync();
            }

            foreach (var item in input.Photos)
            {
                var param = new Photo
                {
                    Name = item.Name.ToString(),
                    

                    Value = item.Value.ToString(),
                    ProductId = newProduct.ID,
                    ClientID = clientID
                };
                await _dbContext.Photos.AddAsync(param);
                await _dbContext.SaveChangesAsync();
            }


            var priceList = new PriceLists
            {
                Name = input.PriceList.Name,
                ClientID = clientID,
            };
            await _dbContext.PriceLists.AddAsync(priceList);
            await _dbContext.SaveChangesAsync();
            
            var newPriceList = _dbContext.PriceLists.FirstOrDefault(x => x.Name == input.PriceList.Name && x.ClientID == clientID);
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
                await _dbContext.Prices.AddAsync(price);
                await _dbContext.SaveChangesAsync();
            }

            List<int> additionalNames = new List<int>();
            foreach (var item in input.AdditionalNames)
            {
                additionalNames.Add(_dbContext.AdditionalName.FirstOrDefault(x => x.Title == item.Title && x.ClientID == clientID).ID);
            }
            
            List<int> dictionaryParams = new List<int>();
            foreach (var item in input.DictionaryParams)
            {
                dictionaryParams.Add(_dbContext.DictionaryParams.FirstOrDefault(x => x.Name == item.Name).ID);


            }

            List<int> photos = new List<int>();
            foreach (var item in input.Photos)
            {
                photos.Add(_dbContext.Photos.FirstOrDefault(x => x.Name == item.Name && x.ClientID == clientID).Id);
            }

            List<int> customParams = new List<int>();
            foreach (var item in input.CustomParams)
            {
                customParams.Add(_dbContext.CustomParams.FirstOrDefault(x => x.Name == item.Name && x.ClientID == clientID).ID);
            }

            newProduct.AdditionalNames = string.Join(",", additionalNames);         
            newProduct.DictionaryParams = string.Join(",", dictionaryParams);
            newProduct.CustomParams = string.Join(",", customParams);
            newProduct.Photos = string.Join(",", photos);
            newProduct.PriceListID = newPriceList.ID;

            await _dbContext.SaveChangesAsync();

            var response = new Response() { ID = random.Next(1, 100000), ClientID = clientID };
            return response;
        }
        #endregion

        #region Get
        public async Task<Response> GetProducts([FromBody] ProductGetFilter productGetFilter, int clientID)
        {
            var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Błędnie podane dane" };
            var products = _dbContext.Products.Where(x => x.ClientID == clientID);
           
            var input = _mapper.Map<ProductGetFilter>(productGetFilter);
           
            if (input == null)
            {
                return responseNull;
            }

            if (!products.Any())
            {
                responseNull.errorMsg = "Klient nie ma produktów";
                return responseNull;
            }

            if (input.ProductIDList != null && input.ProductIDList.Count != 0)
            {
                products = products.Where(x => input.ProductIDList.Contains(x.ID));
            }
            
           if(input.CreationDate != null)
            {
                products = products.Where(x => x.AdditionDate < input.CreationDate);
            }

            if (input.ModificationDate != null)
            {
                products = products.Where(x => x.ModificationDate < input.ModificationDate);
            }

            if (input.ProductName != null)
            {
                products = products.Where(x => x.Name.Contains(input.ProductName));
            }

            var productList = products.ToList();

            var returnList = new List<ProductGet>();

            var additionalNames = _dbContext.AdditionalName.ToList();
            var customParams = _dbContext.CustomParams.ToList();
            var dictionaryParams = _dbContext.DictionaryParams.ToList();
            var priceList = _dbContext.PriceLists.ToList();
            var prices = _dbContext.Prices.ToList();
            foreach (var product in productList)
            {
                var productAdditionalNames = additionalNames.Where(x => product.AdditionalNames.Split(",").ToList().
                    Contains(x.ID.ToString())).ToList();

                var productCustomParams = customParams.Where(x => product.CustomParams.Split(",").ToList().
                    Contains(x.ID.ToString())).ToList();

                var productDictionaryParams = dictionaryParams.Where(x => product.DictionaryParams.Split(",").ToList().
                    Contains(x.ID.ToString())).ToList();

                var productPriceLists = priceList.FirstOrDefault(x => x.ID == product.PriceListID);

                var productPrices = prices.Where(x => x.PriceListID == productPriceLists.ID).ToList();

                returnList.Add(new ProductGet() 
                {
                    ID = product.ID,
                    ClientID = clientID,
                    Name = product.Name,
                    SKU = product.SKU,
                    EAN = product.EAN,
                    Description = product.Description,
                    AdditionalNames = productAdditionalNames,
                    DictionaryParams = productDictionaryParams,
                    CustomParams = productCustomParams,
                    PriceList = new PriceListAll() 
                    {
                        ID = productPriceLists.ID,
                        Name= productPriceLists.Name,
                        ClientID= clientID,
                        Prices = productPrices
                    },
                    AdditionDate = product.AdditionDate,
                    ModificationDate = product.ModificationDate
                });

            }
            var response = new ProductsGetResponse() { ID = random.Next(0, 100000), ClientID = clientID, Model = returnList };
            return response;

        }
        #endregion


        #region Delete
        public async Task<DeleteResponse> DeleteProduct(int clientID, int productID)
        {
            var products = _dbContext.Products.FirstOrDefault(x => x.ClientID == clientID && x.ID == productID);
            if (products == null)
            {
                var responseNull = new DeleteResponse() { ID = random.Next(1, 100000), ClientID = clientID, deleteMsg = "Nie ma takiego produktu!" };
                return responseNull;
            }

            var prices = _dbContext.Prices.ToList();

            var _priceList = _dbContext.PriceLists.ToList();
            
            var additionalNames = _dbContext.AdditionalName.ToList();
        
            var productAdditionalNames = additionalNames.Where(x => products.AdditionalNames.Split(",").ToList().
                Contains(x.ID.ToString())).ToList();

            var productPriceLists = _priceList.FirstOrDefault(x => x.ID == products.PriceListID);

            var productPrices = prices.Where(x => x.PriceListID == productPriceLists.ID).ToList();




            foreach (var item in productAdditionalNames)
            {
                _dbContext.Remove(item);
            }
            foreach (var item in productPrices)
            {
                _dbContext.Remove(item);

            }                
            _dbContext.Remove(productPriceLists);
            _dbContext.Remove(products);
            await _dbContext.SaveChangesAsync();

            var response = new DeleteResponse() { ID = random.Next(1, 100000), ClientID = clientID, deleteMsg = "Produkt został usunięty" };
            return response;

        }

        #endregion



        #region Edit
        public async Task<Response> EditProduct(ProductEdit productEdit, int clientID, int productID)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ID == productID && x.ClientID == clientID);
            if (product == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Nie ma takiego produktu!" };
                return responseNull;
            }

            product.Name = productEdit.Name;
            product.SKU = productEdit.SKU;
            product.EAN = productEdit.EAN;
            product.Description = productEdit.Description;
            product.ModificationDate = DateTime.Now;
            await _dbContext.SaveChangesAsync();

            var response = new ProductEditResponse() { ID = random.Next(1, 100000), ClientID = clientID, Model = productEdit };
            return response;

        }

        #endregion




    }
}
