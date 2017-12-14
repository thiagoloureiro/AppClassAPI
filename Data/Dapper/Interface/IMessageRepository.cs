using Model;
using System.Collections.Generic;

namespace Data.Dapper.Interface
{
    public interface IMessageRepository
    {
        List<Messages> ListMessages();
    }
}