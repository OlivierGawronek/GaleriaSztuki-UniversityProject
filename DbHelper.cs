using Npgsql;
using System;
using System.Data;
using Microsoft.Extensions.Configuration;

public static class DbHelper
{
    private static readonly string connectionString;

    static DbHelper()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        connectionString = config.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string not found.");
    }

    public static NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }

    public static DataTable GetDataTable(string sql, NpgsqlParameter[] parameters = null)
    {
        using (var conn = GetConnection())
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                using (var reader = cmd.ExecuteReader())
                {
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }
    }
}