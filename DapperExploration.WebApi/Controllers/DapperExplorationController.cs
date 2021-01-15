using System.Collections.Generic;
using Dapper;
using DapperExploration.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Threading.Tasks;

namespace DapperExploration.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DapperExplorationController : ControllerBase
    {
        private const string SqlConnectionString =
            "User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=personal_site_db;";

        [HttpGet]
        public IEnumerable<JobExperience> GetDapper()
        {
            // Note:
            // NpgsqlConnection class is an administered type that connects with non-administered
            // using directive manages IDisposable objects and it ensures that Dispose() method is being called
            // even if a exception is thrown in the execution

            // Is the same than putting the code in a try block and then calling Dispose() method in the finally block
            // In fact, this is how the compiler traduces the using statement

            using var sqlConnection = new NpgsqlConnection(SqlConnectionString);
            var sqlCommand = @"SELECT ""Id"", ""Company"", ""Description"", ""TechStack"", ""JobPeriod_End"", ""JobPeriod_Start""
                                FROM public.""JobExperiences""";

            var dynamicParameters = new DynamicParameters();
            sqlCommand += " WHERE \"Company\" = @company";
            dynamicParameters.Add("Company", "Microsofta");

            var jobExperiences = sqlConnection.Query<JobExperience>(sqlCommand, dynamicParameters); 

            return jobExperiences;
        }
    }
}
