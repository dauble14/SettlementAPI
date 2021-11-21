using Microsoft.Extensions.Logging;
using SettlementAPI.Core.IConfiguration;
using SettlementAPI.Core.IRepositories;
using SettlementAPI.Core.Repositories;
using SettlementAPI.Entities;
using System;
using System.Threading.Tasks;

namespace SettlementAPI.Core
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SettlementDbContext _context;
        private readonly ILogger _logger;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(
            SettlementDbContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context=context;
            _logger=loggerFactory.CreateLogger<UnitOfWork>();
            Users = new UserRepository(_context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
