using Microsoft.EntityFrameworkCore;
using ContractService;
using System.Collections.Generic;

namespace ContractService
{
    public class ContractContext : DbContext
    {
        public ContractContext(DbContextOptions<ContractContext> options) : base(options) { }

        public DbSet<Contract> Contracts { get; set; }
    }
}