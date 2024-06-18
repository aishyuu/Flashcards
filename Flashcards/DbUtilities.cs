using Dapper;
using Microsoft.Data.SqlClient;

namespace Flashcards
{
    internal class DbUtilities
    {
        public static void Initialize()
        {
            var connectionString = "Server=localhost\\SQLEXPRESS;Initial Catalog=DapperDB; Integrated Security = true;TrustServerCertificate=True";

            using (var connection = new SqlConnection(connectionString))
            {
                var sql = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Stacks')
                            CREATE TABLE Stacks (
                            Id int IDENTITY(1,1) NOT NULL,
                            Name NVARCHAR(30) NOT NULL UNIQUE,
                            PRIMARY KEY (Id)
                            );";

                connection.Execute(sql);
            }
        }
    }
}
