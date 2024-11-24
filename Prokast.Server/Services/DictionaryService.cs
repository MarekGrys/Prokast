using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prokast.Server.Entities;
using Prokast.Server.Models;


namespace Prokast.Server.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;
        Random random = new Random();

        public DictionaryService(ProkastServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region GetAllParams
        public Response GetAllParams()
        {
            var paramList = _dbContext.DictionaryParams.ToList();
            var response = new Response() { ID = random.Next(1, 100000), Model = paramList };
            if (paramList.Count() == 0)
            {
                var responseNull = new Response() { ID = random.Next(1, 100000),  Model = "Brak parametrów" };
                return responseNull;
            }
            return response;
        }
        #endregion

        #region GetParamsByID
        public Response GetParamsByID( int ID)
        {
            var param = _dbContext.DictionaryParams.Where(x => x.ID == ID);
            var response = new Response() { ID = random.Next(1, 100000),  Model = param };
            if (param.Count() == 0)
            {
                var responseNull = new Response() { ID = random.Next(1, 100000),  Model = "Nie ma takiego parametru" };
                return responseNull;
            }
            return response;

        }
        #endregion

        #region GetParamsByName
        public Response GetParamsByName( string name)
        {
            var param = _dbContext.DictionaryParams.Where(x => x.Name == name).ToList();


            var response = new Response() { ID = random.Next(1, 100000), Model = param };
            if (param.Count() == 0)
            {
                var responseNull = new Response() { ID = random.Next(1, 100000), Model = "Nie ma modelu z taką nazwą" };
                response = responseNull;
            }
            return response;
        }
        #endregion

        #region ReturningValuesByName
        public Response GetParamsByRegion (int region)
        {
            var param = _dbContext.DictionaryParams.Where(x => x.IdRegion == region).ToList();

            List<string> paramList = new List<string>();
            foreach ( var x in param)
            {
                if (!paramList.Contains(x.Name))
                {
                    paramList.Add(x.Name);
                }
                
            }

            var response = new Response() { ID = random.Next(1, 100000), Model = paramList };
            if (param.Count() == 0)
            {
                var responseNull = new Response() { ID = random.Next(1, 100000), Model = "Nie ma takiego regionu" };
                response = responseNull;
            }
            return response;
        }

        public Response GetValuesByName (string name)
        {
            var param = _dbContext.DictionaryParams.Where(x => x.Name == name).ToList();

            List<string> paramList = new List<string>();
            foreach( var x in param)
            {
                paramList.Add(x.Value);
            }
            var response = new Response() { ID = random.Next(1, 100000), Model = paramList };
            if (param.Count() == 0)
            {
                var responseNull = new Response() { ID = random.Next(1, 100000), Model = "Błędna nazwa" };
                response = responseNull;
            }
            return response;
        }
        #endregion

    }
}
