﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using Prokast.Server.Models.ResponseModels;


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

        #region CreateCustonParam
        public async Task<Response> CreateCustomParam([FromBody] CustomParamsDto customParamsDto, int clientID ) 
        {
            
            var param = _mapper.Map<CustomParamsDto>(customParamsDto);
            if (param == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Błędnie podane dane" };
                return responseNull;
            }

            var customParam = new CustomParams
            {
                Name = param.Name.ToString(),
                Type = param.Type.ToString(),
                Value = param.Value.ToString(),
                ClientID = clientID
            };
            

            await _dbContext.CustomParams.AddAsync(customParam);
            await _dbContext.SaveChangesAsync();

            var response = new Response() { ID = random.Next(1,100000), ClientID = clientID};
            return response;
        }
        #endregion

        #region GetAllParams
        public async Task<Response> GetAllParams(int clientID)
        {
            var paramList = _dbContext.CustomParams.Where(x => x.ClientID == clientID).ToList();
            var response = new ParamsGetResponse() { ID = random.Next(1,100000), ClientID = clientID, Model = paramList };
            if(paramList.Count() == 0)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Klient nie ma parametrów" };
                return responseNull;
            }
            return response;
        }
        #endregion

        #region GetParamsByID
        public async Task<Response> GetParamsByID(int clientID, int ID)
        {
            var param = _dbContext.CustomParams.Where(x => x.ClientID == clientID && x.ID == ID).ToList();
            var response = new ParamsGetResponse() { ID = random.Next(1, 100000), ClientID = clientID, Model = param };
            if (param.Count() == 0)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Nie ma takiego parametru" };
                return responseNull;
            }   
            return response;

        }
        #endregion

        #region GetParamsByName
        public async Task<Response> GetParamsByName(int clientID, string name) 
        {
            var param = _dbContext.CustomParams.Where(x => x.ClientID == clientID && x.Name.Contains(name)).ToList();

            
            var response = new ParamsGetResponse() { ID = random.Next(1, 100000), ClientID = clientID, Model = param };
            if (param.Count() == 0)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Nie ma modelu z taką nazwą" };
                return responseNull;
            }
            return response;
        }
        #endregion

        #region EditParams
        public async Task<Response> EditParams(int clientID, int ID, CustomParamsDto data)
        {
            var findParam = _dbContext.CustomParams.FirstOrDefault(x => x.ClientID == clientID && x.ID == ID);
            

            if (findParam == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Nie ma takiego modelu!" };
                return responseNull;
            }

            findParam.Name = data.Name;
            findParam.Type = data.Type;
            findParam.Value = data.Value;
            await _dbContext.SaveChangesAsync();

            var response = new ParamsEditResponse() { ID = random.Next(1, 100000), ClientID = clientID, customParams = findParam };
            
            return response;
        }
        #endregion

        #region DeleteParams
        public async Task<Response> DeleteParams(int clientID, int ID)
        {
            var findParam = _dbContext.CustomParams.FirstOrDefault(x => x.ClientID == clientID && x.ID == ID);


            if (findParam == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Nie ma takiego modelu!" };
                return responseNull;
            }

            _dbContext.Remove(findParam);
            await _dbContext.SaveChangesAsync();

            var response = new DeleteResponse() { ID = random.Next(1, 100000), ClientID = clientID, deleteMsg = "Parametr został usumięty" };

            return response;
        }
        #endregion
    }
}
