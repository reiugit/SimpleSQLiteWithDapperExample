using Microsoft.Data.Sqlite;
using Dapper;
using SimpleSQLiteExample.KeyHandler;
using SimpleSQLiteWithDapperExample.Comparer;

using var connection = new SqliteConnection("Data Source=database.db");
connection.Open();
connection.Execute("DROP TABLE IF EXISTS Products; CREATE TABLE Products (Id INTEGER PRIMARY KEY, Name TEXT);");

await connection.CompareInsertOne(); // compare 'Dapper' with 'Microsoft.Data.Sqlite only'
await connection.CompareQueryOne();

KeyHandler.WaitForAnyKey();
