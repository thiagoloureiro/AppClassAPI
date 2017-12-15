using Dapper;
using Data.Dapper.Interface;
using Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Dapper.Class
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public List<Messages> ListMessages()
        {
            List<Messages> ret;
            using (var db = GetMySqlConnection())
            {
                const string sql = @"select idmsg, nomemsg, datamsg, imagemsg, checkmsg, textmsg from appmensagens";

                ret = db.Query<Messages>(sql, commandType: CommandType.Text).ToList();
            }

            return ret;
        }

        public List<Messages> ListMessages(int id)
        {
            List<Messages> ret;
            using (var db = GetMySqlConnection())
            {
                const string sql = @"select idmsg, nomemsg, datamsg, imagemsg, checkmsg, textmsg from appmensagens where id_usuario = @Id";

                ret = db.Query<Messages>(sql, new { Id = id }, commandType: CommandType.Text).ToList();
            }

            return ret;
        }
    }
}