using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using WebCalculator.Models;

namespace WebCalculator.DatabaseConnections
{
    /// <summary>
    /// Database context for history database.
    /// </summary>
    public class HistoryDatabaseContext : DbContext
    {
        /// <summary>
        /// Expressions in history.
        /// </summary>
        public DbSet<ExpressionModel> Expressions { get; set; }
        public HistoryDatabaseContext(DbContextOptions<HistoryDatabaseContext> options) : base(options)
        {
            
        }

        /// <summary>
        /// Gets saved history from database.
        /// </summary>
        /// <returns>Latest 10 results.</returns>
        public List<string> GetHistory()
        {
            return (from expression in Expressions
                                     orderby expression.ID descending
                                     select expression).Take(10).ToList().ConvertAll((x) => $"{x.Expression} = {x.Result}");
        }
    }
}
