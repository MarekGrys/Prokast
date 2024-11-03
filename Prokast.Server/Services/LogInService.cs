using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Prokast.Server.Entities;
using System.Text;
using System;
using System.Security.Cryptography;
using System.Linq;
using Microsoft.AspNetCore.Mvc;



namespace Prokast.Server.Services
{
    public interface ILogInService
    {
        List<AccountLogIn> GetLogIns();
        // string getHashed (string text);
        void CompareAccount([FromBody] string login,[FromBody] string password);
    }
    

    public class LogInService: ILogInService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;
       


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
    


    public LogInService(ProkastServerDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AccountLogIn> GetLogIns() 
        {
            var logins = _dbContext.AccountLogIn.ToList();
            return logins;
        }
        public void CompareAccount([FromBody]string login, [FromBody]string password) {

            var account = _dbContext.AccountLogIn.FirstOrDefault(x => x.Account_Login == login);
            if (account == null) { throw new Exception("Nie ma takiego konta"); }
            if (account.Account_Password != getHashed(password)) { throw new Exception("Niepoprawne hasło"); }
        }
    }
}
