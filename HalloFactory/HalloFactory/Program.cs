using System.Data.Common;

Console.WriteLine("Hello Factory");

string conString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true"; ;

//DbProviderFactory factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
DbProviderFactory factory = Npgsql.NpgsqlFactory.Instance;

DbConnection connection = factory.CreateConnection();
connection.ConnectionString = conString;
connection.Open();

DbCommand command = connection.CreateCommand();
command.CommandText = "SELECT * FROM Employees";
DbDataReader reader = command.ExecuteReader();
while(reader.Read())
{
    Console.WriteLine(reader.GetString(reader.GetOrdinal("FirstName")));
    Console.WriteLine(reader.GetDateTime(reader.GetOrdinal("BirthDate")).ToShortDateString());
}






