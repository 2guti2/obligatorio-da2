using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ObligatorioDA2.EntityFrameworkCore.EntityFrameworkCore
{
    public static class ContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<Context> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<Context> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}