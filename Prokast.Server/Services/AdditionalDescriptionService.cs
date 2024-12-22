using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using Prokast.Server.Models.ResponseModels;

namespace Prokast.Server.Services
{
    public class AdditionalDescriptionService : IAdditionalDescriptionService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;
        Random random = new Random();

        public AdditionalDescriptionService(ProkastServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region Create
        public async Task<Response> CreateAdditionalDescription([FromBody] AdditionalDescriptionCreateDto description, int clientID)
        {
            var input = _mapper.Map<AdditionalDescriptionCreateDto>(description);

            if (input == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Błędnie podane dane" };
                return responseNull;
            }

            var additionalDescription = new AdditionalDescription()
            {
                ClientID = clientID,
                Title = input.Title,
                Region = input.Region,
                Value = input.Value,
            };

            await _dbContext.AdditionalDescriptions.AddAsync(additionalDescription);
            await _dbContext.SaveChangesAsync();

            var response = new Response() { ID = random.Next(1, 100000), ClientID = clientID };
            return response;
        }
        #endregion


        public async Task<Response> GetAllDescriptions(int clientID)
        {
            var addDescList = _dbContext.AdditionalDescriptions.Where(x => x.ClientID == clientID).ToList();
            var response = new AdditionalDescriptionGetResponse() { ID = random.Next(1, 100000), Model = addDescList };
            if (addDescList.Count() == 0)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), errorMsg = "Brak parametrów" };
                return responseNull;
            }
            return response;
        }

        public async Task<Response> GetDescriptionsByID(int ID, int clientID)
        {
            var addDesc = _dbContext.AdditionalDescriptions.Where(x => x.ID == ID && x.ClientID == clientID).ToList();
            var response = new AdditionalDescriptionGetResponse() { ID = random.Next(1, 100000), Model = addDesc };
            if (addDesc.Count() == 0)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), errorMsg = "Nie ma takiego parametru" };
                return responseNull;
            }
            return response;
        }

        public async Task<Response> GetDescriptionsByNames(string Title, int clientID)
        {
            var addDesc = _dbContext.AdditionalDescriptions.Where(x => x.Title.Contains(Title) && x.ClientID == clientID).ToList();
            var response = new AdditionalDescriptionGetResponse() { ID = random.Next(1, 100000), Model = addDesc };
            if (addDesc.Count() == 0)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), errorMsg = "Nie ma takiego parametru" };
                return responseNull;
            }
            return response;

        }

        public async Task<Response> GetDescriptionByRegion(int Region, int clientID)
        {
            var addDesc = _dbContext.AdditionalDescriptions.Where(x => x.Region == Region && x.ClientID == clientID).ToList();
            var response = new AdditionalDescriptionGetResponse() { ID = random.Next(1, 100000), Model = addDesc };
            if (addDesc.Count() == 0)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), errorMsg = "Nie ma takiego parametru" };
                return responseNull;
            }
            return response;

        }

        public async Task<Response> EditAdditionalDescription(int clientID, int ID, AdditionalDescriptionCreateDto data)
        {
            var findDescription = _dbContext.AdditionalDescriptions.FirstOrDefault(x => x.ClientID == clientID && x.ID == ID);


            if (findDescription == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Nie ma takiego modelu!" };
                return responseNull;
            }

            findDescription.Title = data.Title;
            findDescription.Region = data.Region;
            findDescription.Value = data.Value;
            await _dbContext.SaveChangesAsync();

            var response = new AdditionalDescriptionEditResponse() { ID = random.Next(1, 100000), ClientID = clientID, AdditionalDescriptionEdit = findDescription };

            return response;
        }

        public async Task<Response> DeleteAdditionalDescription(int clientID, int ID)
        {
            var findAdditionalDescription = _dbContext.AdditionalDescriptions.FirstOrDefault(x => x.ClientID == clientID && x.ID == ID);


            if (findAdditionalDescription == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Nie ma takiego modelu!" };
                return responseNull;
            }

            _dbContext.AdditionalDescriptions.Remove(findAdditionalDescription);
            await _dbContext.SaveChangesAsync();

            var response = new DeleteResponse() { ID = random.Next(1, 100000), ClientID = clientID, deleteMsg = "Parametr został usumięty" };

            return response;
        }
    }
}
