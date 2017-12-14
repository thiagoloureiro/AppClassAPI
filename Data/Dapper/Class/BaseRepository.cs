using MySql.Data.MySqlClient;
using System.Configuration;

namespace Data.Dapper.Class
{
    public abstract class BaseRepository
    {
        public string connstring = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;

        public MySqlConnection GetMySqlConnection(bool open = true,
            bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {
            string cs = "Server=mysql762.umbler.com; Port=41890; Database=appclassbd; Uid=portinexd; Pwd=senha123";

            var csb = new MySqlConnectionStringBuilder(cs)
            {
                AllowZeroDateTime = allowZeroDatetime,
                ConvertZeroDateTime = convertZeroDatetime
            };
            var conn = new MySqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }
    }
}