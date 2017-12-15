using Data.Dapper.Interface;
using Model;
using Service.Interface;
using System.Collections.Generic;

namespace Service.Class
{
    public class MessageService : IMessageService
    {
        private IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public List<Messages> ListMessages()
        {
            return _messageRepository.ListMessages();
        }

        public List<Messages> ListMessages(int id)
        {
            return _messageRepository.ListMessages(id);
        }
    }
}