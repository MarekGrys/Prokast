using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prokast.Server.Entities;
using Prokast.Server.Models;


namespace Prokast.Server.Services
{
    public class ParamsService : IParamsService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;
        Random random = new Random();
        
        public ParamsService(ProkastServerDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Response CreateCustomParam([FromBody] CustomParamsDto customParamsDto, int clientID ) 
        {
            var param = _mapper.Map<CustomParamsDto>(customParamsDto);
            
            var customParam = new CustomParams
            {
                Name = param.Name,
                Type = param.Type.ToString(),
                Value = param.Value.ToString(),
                ClientID = clientID
            };

            _dbContext.CustomParams.Add(customParam);
            _dbContext.SaveChanges();

            var response = new Response() { ID = random.Next(1,100000), ClientID = clientID, Model = param };
            return response;
        }

        public Response GetAllParams(int clientID)
        {
            var paramList = _dbContext.CustomParams.Where(x => x.ClientID == clientID).ToList();
            var response = new Response() { ID = random.Next(1,100000), ClientID = clientID, Model = paramList };
            if(paramList.Count() == 0)
            {
                var responseNull = new Response() { ID = random.Next(1, 100000), ClientID = clientID, Model = "Klient nie ma parametrów" };
                return responseNull;
            }
            return response;
        }

        public Response GetParamsByID(int clientID, int ID)
        {
            var param = _dbContext.CustomParams.Where(x => x.ClientID == clientID && x.ID == ID);
            var response = new Response() { ID = random.Next(1, 100000), ClientID = clientID, Model = param };
            if (param.Count() == 0)
            {
                var responseNull = new Response() { ID = random.Next(1, 100000), ClientID = clientID, Model = "Nie ma takiego parametru" };
                return responseNull;
            }   
            return response;

        }

        public Response GetParamsByName(int clientID, string name) 
        {
            var param = _dbContext.CustomParams.Where(x => x.ClientID == clientID && x.Name == name).ToList();
            var response = new Response() { ID = random.Next(1, 100000), ClientID = clientID, Model = param };
            if (param.Count() == 0)
            {
                var responseNull = new Response() { ID = random.Next(1, 100000), ClientID = clientID, Model = "Nie ma modelu z taką nazwą" };
                response = responseNull;
            }
            return response;
        }

    }
}
