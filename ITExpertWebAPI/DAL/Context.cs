using ITExpertWebAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace ITExpertWebAPI.DAL
{
    public class Context : DbContext
    {

        private readonly ILogger<Context> _logger;
        public DbSet<DataObjectEntity> DataObjects { get; set; }

        public Context(DbContextOptions<Context> options, ILogger<Context> logger) : base(options)
        {
            _logger = logger;
            try
            {
                Database.EnsureCreated();
            }
            catch (SqlException e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}
