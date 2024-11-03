using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Prokast.Server.Entities;

namespace Prokast.Server.Services
{
    public interface ILogInService
    {
        List<AccountLogIn> GetLogIns();
    }

    public class LogInService: ILogInService
    {
        private readonly ProkastServerDbContext _dbContext;
        private readonly IMapper _mapper;

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
    }
}
