using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Bwire.EntityFrameworkCore
{
    public static class BwireDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BwireDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BwireDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
