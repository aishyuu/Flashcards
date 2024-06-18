using Dapper;
using Microsoft.Data.SqlClient;

namespace Flashcards
{
    internal class DbUtilities
    {
        public static void Initialize()
        {
            var connectionString = "Server=localhost\\SQLEXPRESS;Initial Catalog=FlashcardsDB; Integrated Security = true;TrustServerCertificate=True";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var sql = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Stacks')
                            CREATE TABLE Stacks (
                            Id int IDENTITY(1,1) NOT NULL,
                            Name NVARCHAR(30) NOT NULL UNIQUE,
                            PRIMARY KEY (Id)
                            );";

                    connection.Execute(sql);

                    sql = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Flashcards')
                        CREATE TABLE Flashcards(
                        Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
                        Question NVARCHAR(30) NOT NULL,
                        Answer NVARCHAR(30) NOT NULL,
                        StackId int NOT NULL
                            FOREIGN KEY
                            REFERENCES Stacks(Id)
                            ON DELETE CASCADE
                            ON UPDATE CASCADE
                        );";

                    connection.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
