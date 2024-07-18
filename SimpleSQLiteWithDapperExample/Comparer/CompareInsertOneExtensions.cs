using Dapper;
using Microsoft.Data.Sqlite;
using SimpleSQLiteExample.Dtos;

namespace SimpleSQLiteWithDapperExample.Comparer;

internal static class InsertOneComparerExtensions
{
    public static async Task CompareInsertOne(this SqliteConnection connection)
    {
        // 1. Insert one row with 'Dapper'
        {
            await connection.ExecuteAsync(
                sql: "INSERT INTO Products (Name) VALUES (@Name);",
                param: new CreateProductDto("Product 1 was created with Dapper."));
        }

        // 2. Insert one row with 'Microsoft.Data.Sqlite'
        {
            using var insertCommand = new SqliteCommand(
                commandText: "INSERT INTO Products (Name) VALUES (@Name);",
                connection: connection);

            insertCommand.Parameters.AddWithValue("@Name", "Product 2 was created with Microsoft.Data.Sqlite only.");

            insertCommand.ExecuteNonQuery();
        }
    }
}
