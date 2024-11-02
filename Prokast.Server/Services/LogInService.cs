using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Prokast.Server.Entities;

namespace Prokast.Server.Services
{
    public interface ILogInService
    {
        List<Account_Log_In2> GetLogIns();
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

        public List<Account_Log_In2> GetLogIns() 
        {
            var logins = _dbContext.Account_Log_In2.ToList();
            return logins;
        }
    }
}
