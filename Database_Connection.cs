using System;
using MySql.Data.MySqlClient;

public class Database_Connection
{
    private string connectionString = "server=localhost; database=StudentInfoDB; uid=root; pwd=Keypass_2003;";

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}
