using Dapper;
using Microsoft.Data.Sqlite;
using SimpleSQLiteExample.Domain;

namespace SimpleSQLiteWithDapperExample.Comparer;

internal static class QueryOneComparerExtensions
{
    public static async Task CompareQueryOne(this SqliteConnection connection)
    {
        // 1. Query one row with 'Dapper'
        {
            var product = await connection.QueryFirstAsync<Product>(
                sql: "SELECT * FROM Products where Id=@Id;",
                param: new { Id = 1 });

            Console.WriteLine(product.Name);
        }

        // 2. Query one row with 'Microsoft.Data.Sqlite'
        {
            using var queryCommand = new SqliteCommand(
                commandText: "SELECT * FROM Products where Id=@Id;",
                connection: connection);

            queryCommand.Parameters.AddWithValue("Id", 2);

            using var reader = queryCommand.ExecuteReader();
            reader.Read();
            var productName = reader.GetString(1);

            Console.WriteLine(productName);
        }
    }
}
