using HH2;
using HH2.Entities;
using Microsoft.EntityFrameworkCore;

namespace HH2Tests.Api.IntegrationTests
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"Server=DESKTOP-LR50E8B;Database=HH2Db;Trusted_Connection=True;";

        public DbContext CreateContext()
            => new DbContext(
                new DbContextOptionsBuilder<DbContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
    }
}