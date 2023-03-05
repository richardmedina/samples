using CustomImpls.Data.Entities;
using CustomImpls.Ef.Sp;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace CustomImpls.Data
{
    public class DataDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=MyDemo;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True;Integrated Security=True");
        }

        public int CallStoredProcedure(object storedProcedure)
        {
            //var connection = Database.GetDbConnection();
            string spName = GetSpName(storedProcedure);
            var parameters = GetSpParameters(storedProcedure);

            var sqlCommandQuery = $"EXEC {spName} " +
                string.Join(",", parameters.Select(param => param.ParameterName));

            var result = Database.ExecuteSqlRaw(sqlCommandQuery, parameters);

            return result;
        }

        private string GetSpName(object storedProcedure)
        {
            var type = storedProcedure.GetType();
            var attr = type.GetCustomAttribute<StoredProcedureAttribute>();
            if (attr == null) throw new NotImplementedException("Object does not implement StoredProcedureAttribute");

            return attr.Name;
        }

        private List<SqlParameter> GetSpParameters(object storedProcedure)
        {
            var parameters = new List<SqlParameter>();

            var type = storedProcedure.GetType();

            var props = type.GetProperties();

            foreach (var prop in props)
            {
                var customAttr = prop.GetCustomAttribute<StoredProcedureParameterAttribute>();

                if (customAttr != null)
                {
                    var value = prop.GetValue(storedProcedure);
                    if (value == null) throw new ArgumentNullException();

                    var sqlParameter = new SqlParameter(customAttr.Name, value);

                    parameters.Add(sqlParameter);
                }
            }
            return parameters;
        }
    }
}