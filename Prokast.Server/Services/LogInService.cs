using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using System.Text;
using System;
using System.Security.Cryptography;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Prokast.Server.Models.ResponseModels;



namespace Prokast.Server.Services
{


    public class LogInService :  ILogInService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;
        Random random = new Random();

        public LogInService(ProkastServerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public static string getHashed(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        #region GetAll
        public async Task<Response> GetLogIns(int clientID)
        {
            var logins = _dbContext.AccountLogIn.ToList();
            if (logins.Count() == 0)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = clientID, errorMsg = "Klient nie ma parametrów" };
                return responseNull;
            }
            var response = new LogInGetResponse() {ID = random.Next(1,100000),ClientID = clientID, Model = logins};
            return response;
        }
        #endregion

        #region LogIn
        public async Task<Response> Log_In([FromBody] LoginRequest loginRequest)
        {

            var account = _dbContext.AccountLogIn.FirstOrDefault(x => x.Login == loginRequest.Login);
            if (account == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = -1, errorMsg = "Nie ma takiego konta" };
                return responseNull;
            }

            var client = _dbContext.Clients.FirstOrDefault(x => x.AccountID == account.ID);
            if (client == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = -1, errorMsg = "Błędny login" };
                return responseNull;
            }
                

            if (account.Password != getHashed(loginRequest.Password))
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), ClientID = -1, errorMsg = "Błędne hasło" };
                return responseNull;
            }

            if (client.Subscription is null || client.Subscription < DateTime.Now)
            {
                var responseFalse = new LogInLoginResponse() { ID = random.Next(1, 100000), ClientID = client.ID, IsSubscribed = false };
                return responseFalse;
            }

            var response = new LogInLoginResponse() {ID = random.Next(1,100000), ClientID = client.ID, IsSubscribed = true };
            return response;
        }
        #endregion
    }
}
