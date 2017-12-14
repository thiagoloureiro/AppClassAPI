using Model;
using System.Collections.Generic;

namespace Service.Interface
{
    public interface IMessageService
    {
        List<Messages> ListMessages();
    }
}