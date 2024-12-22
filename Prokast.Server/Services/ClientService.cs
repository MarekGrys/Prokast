﻿using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prokast.Server.Entities;
using Prokast.Server.Models;
using System.Text;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Security.Cryptography;
using System.Linq;
using Prokast.Server.Models.ResponseModels;

namespace Prokast.Server.Services
{
    
    public class ClientService: IClientService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;
        Random random = new Random();

        public ClientService(ProkastServerDbContext dbContext, IMapper mapper)
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

        #region RegisterClient
        public async Task<Response> RegisterClient([FromBody] Registration registration) 
        { 
            var reg = _mapper.Map<Registration>(registration);
            if (reg == null)
            {
                var responseNull = new ErrorResponse() { ID = random.Next(1, 100000), errorMsg = "Błędne dane rejestracji" };
                return responseNull;
            }
            var account = new AccountLogIn
            {
                Login = registration.Login,
                Password = getHashed(registration.Password)
            };
           
            await _dbContext.AccountLogIn.AddAsync(account);
            await _dbContext.SaveChangesAsync(); 
                var test = _dbContext.AccountLogIn.FirstOrDefault(x => x.Login == account.Login);

            var client = new Client
            {
                AccountID = test.ID,
                FirstName = reg.FirstName,
                LastName = reg.LastName,
                BusinessName = reg.BusinessName,
                NIP = reg.NIP,
                Address = reg.Address,
                PhoneNumber = reg.PhoneNumber,
                PostalCode = reg.PostalCode,
                City = reg.City,
                Country = reg.Country

            };
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync(); 

            var response = new ClientRegisterResponse() { ID = random.Next(1, 100000), ClientID = test.ID, Registration = reg };
            return response;

        }
        #endregion

    }
}
